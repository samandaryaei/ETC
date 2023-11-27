namespace ETC.PoliceInquery.Shared
{
    public enum PayOffStatus : short
    {
        HasBeenPayed = 9, //پرداخت شده
        HasBeenCanceled = 8,// باطل شده
        HasBeenPayedCanceled = 7,//باطل شده - پرداخت شده
        Pending = 6,//درحال بررسی
        Reserve = 1 | 2 | 3 | 4,//رزرو
        HasNotBeenPayed = 0//پرداخت نشده - وضعیت اولیه
    }
}
