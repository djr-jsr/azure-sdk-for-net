﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.JobPlan
{
    internal class JobPlanHeader
    {
        /// <summary>
        /// Version for the job plan schema.
        /// </summary>
        public string Version;

        /// <summary>
        /// The transfer id.
        /// </summary>
        public string TransferId;

        /// <summary>
        /// The time the job was created.
        /// </summary>
        public DateTimeOffset CreateTime;

        /// <summary>
        /// The type of operation this job is performing.
        /// </summary>
        public JobPlanOperation OperationType;

        /// <summary>
        /// A string ID of the source resource provider to use for rehydration.
        /// </summary>
        public string SourceProviderId;

        /// <summary>
        /// A string ID of the destination resource provider to use for rehydration.
        /// </summary>
        public string DestinationProviderId;

        /// <summary>
        /// Whether or not the enumeration of the parent container has completed.
        /// </summary>
        public bool EnumerationComplete;

        /// <summary>
        /// The current status of the transfer job.
        /// </summary>
        public DataTransferStatus JobStatus;

        /// <summary>
        /// The parent path for the source of the transfer.
        /// </summary>
        public string ParentSourcePath;

        /// <summary>
        /// The parent path for the destination of the transfer.
        /// </summary>
        public string ParentDestinationPath;

        public JobPlanHeader(
            string version,
            string transferId,
            DateTimeOffset createTime,
            JobPlanOperation operationType,
            string sourceProviderId,
            string destinationProviderId,
            bool enumerationComplete,
            DataTransferStatus jobStatus,
            string parentSourcePath,
            string parentDestinationPath)
        {
            Argument.AssertNotNull(version, nameof(version));
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotNullOrEmpty(sourceProviderId, nameof(sourceProviderId));
            Argument.AssertNotNullOrEmpty(destinationProviderId, nameof(destinationProviderId));
            Argument.AssertNotNull(createTime, nameof(createTime));
            Argument.AssertNotNullOrEmpty(parentSourcePath, nameof(parentSourcePath));
            Argument.AssertNotNullOrEmpty(parentDestinationPath, nameof(parentDestinationPath));

            if (sourceProviderId.Length > DataMovementConstants.JobPlanFile.ProviderIdMaxLength)
            {
                throw new ArgumentException("The provided sourceProviderId is too long.");
            }
            if (destinationProviderId.Length > DataMovementConstants.JobPlanFile.ProviderIdMaxLength)
            {
                throw new ArgumentException("The provided destinationProviderId is too long.");
            }

            Version = version;
            TransferId = transferId;
            CreateTime = createTime;
            OperationType = operationType;
            SourceProviderId = sourceProviderId;
            DestinationProviderId = destinationProviderId;
            EnumerationComplete = enumerationComplete;
            JobStatus = jobStatus;
            ParentSourcePath = parentSourcePath;
            ParentDestinationPath = parentDestinationPath;
        }

        public void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementConstants.JobPlanFile.VariableLengthStartIndex;
            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            WritePaddedString(writer, Version, DataMovementConstants.JobPlanFile.VersionStrNumBytes);

            // TransferId (write as bytes)
            Guid transferId = Guid.Parse(TransferId);
            writer.Write(transferId.ToByteArray());

            // CreateTime
            writer.Write(CreateTime.Ticks);

            // OperationType
            writer.Write((byte)OperationType);

            // SourceProviderId
            WritePaddedString(writer, SourceProviderId, DataMovementConstants.JobPlanFile.ProviderIdNumBytes);

            // DestinationProviderId
            WritePaddedString(writer, DestinationProviderId, DataMovementConstants.JobPlanFile.ProviderIdNumBytes);

            // EnumerationComplete
            writer.Write(Convert.ToByte(EnumerationComplete));

            // JobStatus
            writer.Write((int)JobStatus.ToJobPlanStatus());

            // ParentSourcePath offset/length
            byte[] parentSourcePathBytes = Encoding.UTF8.GetBytes(ParentSourcePath);
            JobPlanExtensions.WriteVariableLengthFieldInfo(writer, parentSourcePathBytes, ref currentVariableLengthIndex);

            // ParentDestinationPath offset/length
            byte[] parentDestinationPathBytes = Encoding.UTF8.GetBytes(ParentDestinationPath);
            JobPlanExtensions.WriteVariableLengthFieldInfo(writer, parentDestinationPathBytes, ref currentVariableLengthIndex);

            // ParentSourcePath
            writer.Write(parentSourcePathBytes);

            // ParentDestinationPath
            writer.Write(parentDestinationPathBytes);
        }

        public static JobPlanHeader Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            BinaryReader reader = new BinaryReader(stream);
            reader.BaseStream.Position = 0;

            // Version
            byte[] versionBuffer = reader.ReadBytes(DataMovementConstants.JobPlanFile.VersionStrNumBytes);
            string version = versionBuffer.ToString(DataMovementConstants.JobPlanFile.VersionStrLength);

            // Assert the schema version before continuing
            CheckSchemaVersion(version);

            // TransferId
            byte[] transferIdBuffer = reader.ReadBytes(DataMovementConstants.GuidSizeInBytes);
            string transferId = new Guid(transferIdBuffer).ToString();

            // CreateTime
            long createTimeTicks = reader.ReadInt64();
            DateTimeOffset createTime = new DateTimeOffset(createTimeTicks, new TimeSpan(0, 0, 0));

            // OperationType
            byte operationTypeByte = reader.ReadByte();
            JobPlanOperation operationType = (JobPlanOperation)operationTypeByte;

            // SourceProviderId
            string sourceProviderId = ReadPaddedString(reader, DataMovementConstants.JobPlanFile.ProviderIdNumBytes);

            // DestinationProviderId
            string destProviderId = ReadPaddedString(reader, DataMovementConstants.JobPlanFile.ProviderIdNumBytes);

            // EnumerationComplete
            byte enumerationCompleteByte = reader.ReadByte();
            bool enumerationComplete = Convert.ToBoolean(enumerationCompleteByte);

            // JobStatus
            JobPlanStatus jobPlanStatus = (JobPlanStatus)reader.ReadInt32();

            // ParentSourcePath offset
            int parentSourcePathOffset = reader.ReadInt32();

            // ParentSourcePath length
            int parentSourcePathLength = reader.ReadInt32();

            // ParentDestPath offset
            int parentDestPathOffset = reader.ReadInt32();

            // ParentDestPath length
            int parentDestPathLength = reader.ReadInt32();

            // ParentSourcePath
            string parentSourcePath = null;
            if (parentSourcePathOffset > 0)
            {
                reader.BaseStream.Position = parentSourcePathOffset;
                byte[] parentSourcePathBytes = reader.ReadBytes(parentSourcePathLength);
                parentSourcePath = parentSourcePathBytes.ToString(parentSourcePathLength);
            }

            // ParentDestinationPath
            string parentDestinationPath = null;
            if (parentDestPathOffset > 0)
            {
                reader.BaseStream.Position = parentDestPathOffset;
                byte[] parentDestinationPathBytes = reader.ReadBytes(parentDestPathLength);
                parentDestinationPath = parentDestinationPathBytes.ToString(parentDestPathLength);
            }

            return new JobPlanHeader(
                version,
                transferId,
                createTime,
                operationType,
                sourceProviderId,
                destProviderId,
                enumerationComplete,
                jobPlanStatus.ToDataTransferStatus(),
                parentSourcePath,
                parentDestinationPath);
        }

        private static void WritePaddedString(BinaryWriter writer, string value, int setSizeInBytes)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            writer.Write(valueBytes);

            int padding = setSizeInBytes - valueBytes.Length;
            if (padding > 0)
            {
                char[] paddingArray = new char[padding];
                writer.Write(paddingArray);
            }
        }

        private static string ReadPaddedString(BinaryReader reader, int numBytes)
        {
            byte[] stringBytes = reader.ReadBytes(numBytes);
            return stringBytes.ToString(numBytes).TrimEnd('\0');
        }

        private static void CheckSchemaVersion(string version)
        {
            if (version != DataMovementConstants.JobPlanFile.SchemaVersion)
            {
                throw Errors.UnsupportedJobSchemaVersionHeader(version);
            }
        }
    }
}
