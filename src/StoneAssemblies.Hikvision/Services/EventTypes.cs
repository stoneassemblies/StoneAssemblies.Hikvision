namespace StoneAssemblies.Hikvision.Services;

public static class EventMinorTypes
{
    public const int SwipeCardFail = 0x01;

    public const int SwipeCardPass = 0x02;

    public const int SwipeCardOpen = 0x03;

    public const int SwipeCardClose = 0x04;

    public const int DoorButtonOpen = 0x05;

    public const int DoorButtonClose = 0x06;

    public const int DoorOpen = 0x07;

    public const int DoorClose = 0x08;

    public const int FireButtonOpen = 0x09;

    public const int FireButtonClose = 0x0A;

    public const int DoorOpenTimeout = 0x0B;

    public const int DoorStress = 0x0C;

    public const int DoorUnStress = 0x0D;

    public const int AlarmIn = 0x0E;

    public const int AlarmInRecover = 0x0F;

    public const int TamperAlarm = 0x10;

    public const int TamperAlarmRecover = 0x11;

    public const int DoorOpenTooLong = 0x12;

    public const int DoorOpenTooLongRecover = 0x13;

    public const int MagneticDetect = 0x14;

    public const int MagneticDetectRecover = 0x15;

    public const int ButtonOpen = 0x16;

    public const int ButtonClose = 0x17;

    public const int RemoteOpen = 0x18;

    public const int RemoteClose = 0x19;

    public const int OpenStressPassword = 0x1A;

    public const int OpenStressFingerprint = 0x1B;

    public const int OpenStressCard = 0x1C;

    public const int OpenStressFingerprintAndPassword = 0x1D;

    public const int OpenStressCardAndPassword = 0x1E;

    public const int OpenStressFingerprintAndCard = 0x1F;

    public const int OpenStressFingerprintAndCardAndPassword = 0x20;

    public const int CloseStressPassword = 0x21;

    public const int CloseStressFingerprint = 0x22;

    public const int CloseStressCard = 0x23;

    public const int CloseStressFingerprintAndPassword = 0x24;

    public const int CloseStressCardAndPassword = 0x25;

    public const int FingerprintComparePass = 0x26;

    public const int FingerprintCompareFail = 0x27;

    public const int CloseStressFingerprintAndCard = 0x28;

    public const int CloseStressFingerprintAndCardAndPassword = 0x29;

    public const int InputPassword = 0x2A;

    public const int InputCard = 0x2B;

    public const int InputFingerprint = 0x2C;

    public const int InputPasswordAndFingerprint = 0x2D;

    public const int InputPasswordAndCard = 0x2E;

    public const int InputCardAndFingerprint = 0x2F;

    public const int InputCardAndFingerprintAndPassword = 0x30;

    public const int InputFingerprintAndPassword = 0x31;

    public const int InputFingerprintAndCardAndPassword = 0x32;

    public const int InputFingerprintAndCard = 0x33;

    public const int DoorOpenByCard = 0x34;

    public const int DoorOpenByFingerprint = 0x35;

    public const int DoorOpenByPassword = 0x36;

    public const int DoorOpenByFingerprintAndCard = 0x37;

    public const int DoorOpenByFingerprintAndPassword = 0x38;

    public const int DoorOpenByCardAndPassword = 0x39;

    public const int DoorOpenByFingerprintAndCardAndPassword = 0x3A;

    public const int DoorOpenByFirstCard = 0x3B;

    public const int RemoteCloseByHand = 0x3C;

    public const int RemoteOpenByHand = 0x3D;

    public const int OpenByFace = 0x3E;

    public const int OpenByFaceAndPassword = 0x3F;

    public const int OpenByFaceAndCard = 0x40;

    public const int OpenByFaceAndCardAndPassword = 0x41;
}