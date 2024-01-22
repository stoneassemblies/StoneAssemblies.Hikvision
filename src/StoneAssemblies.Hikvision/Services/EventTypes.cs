namespace StoneAssemblies.Hikvision.Services
{
    public enum EventTypes
    {
        LegalCardPass = 0x01,

        CardAndPswPass = 0x02,

        CardAndPswFail = 0x03,

        CardAndPswTimeout = 0x04,

        CardAndPswOverTime = 0x05,

        CardNoRight = 0x06,

        CardInvalidPeriod = 0x07,

        CardOutOfDate = 0x08,

        InvalidCard = 0x09,

        AntiSneakFail = 0x0a,

        InterlockDoorNotClose = 0x0b,

        NotBelongMultiGroup = 0x0c,

        InvalidMultiVerifyPeriod = 0x0d,

        MultiVerifySuperRightFail = 0x0e,

        MultiVerifyRemoteRightFail = 0x0f,

        MultiVerifySuccess = 0x10,

        LeaderCardOpenBegin = 0x11,

        LeaderCardOpenEnd = 0x12,

        AlwaysOpenBegin = 0x13,

        AlwaysOpenEnd = 0x14,

        LockOpen = 0x15,

        LockClose = 0x16,

        DoorButtonPress = 0x17,

        DoorButtonRelease = 0x18,

        DoorOpenNormal = 0x19,

        DoorCloseNormal = 0x1a,

        DoorOpenAbnormal = 0x1b,

        DoorOpenTimeout = 0x1c,

        AlarmOutOn = 0x1d,

        AlarmOutOff = 0x1e,

        AlwaysCloseBegin = 0x1f,

        AlwaysCloseEnd = 0x20,

        MultiVerifyNeedRemoteOpen = 0x21,

        MultiVerifySuperPasswordVerifySuccess = 0x22,

        MultiVerifyRepeatVerify = 0x23,

        MultiVerifyTimeout = 0x24,

        DoorbellRinging = 0x25,

        FingerprintComparePass = 0x26,

        FingerprintCompareFail = 0x27,

        CardFingerprintVerifyPass = 0x28,

        CardFingerprintVerifyFail = 0x29,

        CardFingerprintVerifyTimeout = 0x2a,

        CardFingerprintPasswordVerifyPass = 0x2b,

        CardFingerprintPasswordVerifyFail = 0x2c,

        CardFingerprintPasswordVerifyTimeout = 0x2d,

        FingerprintPasswordVerifyPass = 0x2e,

        FingerprintPasswordVerifyFail = 0x2f,

        FingerprintPasswordVerifyTimeout = 0x30,

        FingerprintInexistence = 0x31,

        CardPlatformVerify = 0x32,

        CallCenter = 0x33,

        FireRelayTurnOnDoorAlwaysOpen = 0x34,

        FireRelayRecoverDoorRecoverNormal = 0x35,

        EmployeeNoAndFpVerifyPass = 0x45,

        EmployeeNoAndFpVerifyFail = 0x46,

        EmployeeNoAndFpVerifyTimeout = 0x47,

        EmployeeNoAndFpAndPwVerifyPass = 0x48,

        EmployeeNoAndFpAndPwVerifyFail = 0x49,

        EmployeeNoAndFpAndPwVerifyTimeout = 0x4a,

        FaceVerifyPass = 0x4b,

        FaceVerifyFail = 0x4c,

        EmployeeNoAndFaceVerifyPass = 0x4d,

        EmployeeNoAndFaceVerifyFail = 0x4e,

        EmployeeNoAndFaceVerifyTimeout = 0x4f,

        FaceRecognizeFail = 0x50,

        FirstCardAuthorizeBegin = 0x51,

        FirstCardAuthorizeEnd = 0x52,

        DoorLockInputShortCircuit = 0x53,

        DoorLockInputBrokenCircuit = 0x54,

        DoorLockInputException = 0x55,

        DoorContactInputShortCircuit = 0x56,

        DoorContactInputBrokenCircuit = 0x57,

        DoorContactInputException = 0x58,

        OpenButtonInputShortCircuit = 0x59,

        OpenButtonInputBrokenCircuit = 0x5a,

        OpenButtonInputException = 0x5b,

        DoorLockOpenException = 0x5c,

        DoorLockOpenTimeout = 0x5d,

        FirstCardOpenWithoutAuthorize = 0x5e,

        CallLadderRelayBreak = 0x5f,

        CallLadderRelayClose = 0x60,

        AutoKeyRelayBreak = 0x61,

        AutoKeyRelayClose = 0x62,

        KeyControlRelayBreak = 0x63,

        KeyControlRelayClose = 0x64,

        EmployeeNoAndPwPass = 0x65,

        EmployeeNoAndPwFail = 0x66,

        EmployeeNoAndPwTimeout = 0x67,

        CertificateBlackList = 0x71,

        LegalMessage = 0x72,

        IllegalMessage = 0x73,

        DoorOpenOrDormantFail = 0x75,

        AuthPlanDormantFail = 0x76,

        CardEncryptVerifyFail = 0x77,

        SubmarineBackReplyFail = 0x78,

        DoorOpenOrDormantOpenFail = 0x82,

        DoorOpenOrDormantLinkageOpenFail = 0x84,

        Trailing = 0x85,

        ReverseAccess = 0x86,

        ForceAccess = 0x87,

        ClimbingOverGate = 0x88,

        PassingTimeout = 0x89,

        IntrusionAlarm = 0x8a,

        FreeGatePassNotAuth = 0x8b,

        DropArmBlock = 0x8c,

        DropArmBlockResume = 0x8d,

        PasswordMismatch = 0x97,

        EmployeeNoNotExist = 0x98,

        CombinedVerifyPass = 0x99,

        CombinedVerifyTimeout = 0x9a,

        VerifyModeMismatch = 0x9b,

        InformalMifareCardVerifyFail = 0xa2,

        CpuCardEncryptVerifyFail = 0xa3,

        NfcDisableVerifyFail = 0xa4,

        EmCardRecognizeNotEnabled = 0xa8,

        M1CardRecognizeNotEnabled = 0xa9,

        CpuCardRecognizeNotEnabled = 0xaa,

        IdCardRecognizeNotEnabled = 0xab,

        CardSetSecretKeyFail = 0xac,

        LocalUpgradeFail = 0xad,

        RemoteUpgradeFail = 0xae,

        RemoteExtendModuleUpgradeSuccess = 0xaf,

        RemoteExtendModuleUpgradeFail = 0xb0,

        RemoteFingerPrintModuleUpgradeSuccess = 0xb1,

        RemoteFingerPrintModuleUpgradeFail = 0xb2,

        DynamicCodeVerifyPass = 0xb3,

        DynamicCodeVerifyFail = 0xb4,

        PasswordVerifyPass = 0xb5,

        EventCustom1 = 0x500,

        EventCustom2 = 0x501,

        EventCustom3 = 0x502,

        EventCustom4 = 0x503,

        EventCustom5 = 0x504,

        EventCustom6 = 0x505,

        EventCustom7 = 0x506,

        EventCustom8 = 0x507,

        EventCustom9 = 0x508,

        EventCustom10 = 0x509,

        EventCustom11 = 0x50a,

        EventCustom12 = 0x50b,

        EventCustom13 = 0x50c,

        EventCustom14 = 0x50d,

        EventCustom15 = 0x50e,

        EventCustom16 = 0x50f,

        EventCustom17 = 0x510,

        EventCustom18 = 0x511,

        EventCustom19 = 0x512,

        EventCustom20 = 0x513,

        EventCustom21 = 0x514,

        EventCustom22 = 0x515,

        EventCustom23 = 0x516,

        EventCustom24 = 0x517,

        EventCustom25 = 0x518,

        EventCustom26 = 0x519,

        EventCustom27 = 0x51a,

        EventCustom28 = 0x51b,

        EventCustom29 = 0x51c,

        EventCustom30 = 0x51d,

        EventCustom31 = 0x51e,

        EventCustom32 = 0x51f,

        EventCustom33 = 0x520,

        EventCustom34 = 0x521,

        EventCustom35 = 0x522,

        EventCustom36 = 0x523,

        EventCustom37 = 0x524,

        EventCustom38 = 0x525,

        EventCustom39 = 0x526,

        EventCustom40 = 0x527,

        EventCustom41 = 0x528,

        EventCustom42 = 0x529,

        EventCustom43 = 0x52a,

        EventCustom44 = 0x52b,

        EventCustom45 = 0x52c,

        EventCustom46 = 0x52d,

        EventCustom47 = 0x52e,

        EventCustom48 = 0x52f,

        EventCustom49 = 0x530,

        EventCustom50 = 0x531,

        EventCustom51 = 0x532,

        EventCustom52 = 0x533,

        EventCustom53 = 0x534,

        EventCustom54 = 0x535,

        EventCustom55 = 0x536,

        EventCustom56 = 0x537,

        EventCustom57 = 0x538,

        EventCustom58 = 0x539,

        EventCustom59 = 0x53a,

        EventCustom60 = 0x53b,

        EventCustom61 = 0x53c,

        EventCustom62 = 0x53d,

        EventCustom63 = 0x53e,

        EventCustom64 = 0x53f,
    }
}