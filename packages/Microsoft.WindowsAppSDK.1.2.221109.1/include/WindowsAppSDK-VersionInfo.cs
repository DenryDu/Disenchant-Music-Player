﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.WindowsAppSDK
{
    // Release information
    public class Release
    {
        /// The major version of the Windows App SDK release.
        public const ushort Major = 1;

        /// The minor version of the Windows App SDK release.
        public const ushort Minor = 2;

        /// The patch version of the Windows App SDK release.
        public const ushort Patch = 0;

        /// The major and minor version of the Windows App SDK release, encoded as a uint32_t (0xMMMMNNNN where M=major, N=minor).
        public const uint MajorMinor = 0x00010002;

        /// The Windows App SDK release's channel; for example, "preview", or empty string for stable.
        public const string Channel = "";

        /// The Windows App SDK release's version tag; for example, "preview2", or empty string for stable.
        public const string VersionTag = "";

        /// The Windows App SDK release's short-form version tag; for example, "p2", or empty string for stable.
        public const string VersionShortTag = "";

        /// The Windows App SDK release's version tag, formatted for concatenation when constructing identifiers; for example, "-preview2", or empty string for stable.
        public const string FormattedVersionTag = "";

        /// The Windows App SDK release's short-form version tag, formatted for concatenation when constructing identifiers; for example, "-p2", or empty string for stable.
        public const string FormattedVersionShortTag = "";
    }

    // Runtime information
    namespace Runtime
    {
        public class Identity
        {
            /// The Windows App SDK runtime's package identity's Publisher.
            public const string Publisher = "CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US";

            /// The Windows App SDK runtime's package identity's PublisherId.
            public const string PublisherId = "8wekyb3d8bbwe";
        }

        public class Version
        {
            /// The major version of the Windows App SDK runtime; for example, 1000.
            public const ushort Major = 2000;

            /// The minor version of the Windows App SDK runtime; for example, 446.
            public const ushort Minor = 677;

            /// The build version of the Windows App SDK runtime; for example, 804.
            public const ushort Build = 1750;

            /// The revision version of the Windows App SDK runtime; for example, 0.
            public const ushort Revision = 0;

            /// The version of the Windows App SDK runtime, as a uint64l for example, 0x03E801BE03240000.
            public const ulong UInt64 = 0x07D002A506D60000;

            /// The version of the Windows App SDK runtime, as a string (const wchar_t*); for example, "1000.446.804.0".
            public const string DotQuadString = "2000.677.1750.0";
        }

        namespace Packages
        {
            public class Framework
            {
                /// The Windows App SDK runtime's Framework package's family name.
                public const string PackageFamilyName = "Microsoft.WindowsAppRuntime.1.2_8wekyb3d8bbwe";
            }
            public class Main
            {
                /// The Windows App SDK runtime's Main package's family name.
                public const string PackageFamilyName = "MicrosoftCorporationII.WinAppRuntime.Main.1.2_8wekyb3d8bbwe";
            }
            public class Singleton
            {
                /// The Windows App SDK runtime's Singleton package's family name.
                public const string PackageFamilyName = "MicrosoftCorporationII.WinAppRuntime.Singleton_8wekyb3d8bbwe";
            }
            namespace DDLM
            {
                public class X86
                {
                    /// The Windows App SDK runtime's Dynamic Dependency Lifetime Manager (DDLM) package's family name, for x86.
                    public const string PackageFamilyName = "Microsoft.WinAppRuntime.DDLM.2000.677.1750.0-x8_8wekyb3d8bbwe";
                }
                public class X64
                {
                    /// The Windows App SDK runtime's Dynamic Dependency Lifetime Manager (DDLM) package's family name, for x64.
                    public const string PackageFamilyName = "Microsoft.WinAppRuntime.DDLM.2000.677.1750.0-x6_8wekyb3d8bbwe";
                }
                public class Arm64
                {
                    /// The Windows App SDK runtime's Dynamic Dependency Lifetime Manager (DDLM) package's family name, for arm64.
                    public const string PackageFamilyName = "Microsoft.WinAppRuntime.DDLM.2000.677.1750.0-a6_8wekyb3d8bbwe";
                }
            }
        }
    }
}
