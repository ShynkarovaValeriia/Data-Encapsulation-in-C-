using System;

internal class SmartHomeDevice
{
    // Приватні поля
    private string deviceName;
    private string deviceType;
    private bool status;
    private float powerConsumption;

    // Звичайний конструктор
    public SmartHomeDevice()
    {
        deviceName = "";
        deviceType = "";
        status = false;
        powerConsumption = 0.0f;
    }

    // Параметризований конструктор
    public SmartHomeDevice(string deviceName, string deviceType, bool status, float powerConsumption)
    {
        this.deviceName = deviceName;
        this.deviceType = deviceType;
        this.status = status;
        // Перевірка
        if (powerConsumption < 0)
        {
            throw new ArgumentException("Споживання енергії не може бути від'ємним.");
        }
        this.powerConsumption = powerConsumption;
    }

    // Конструктор копіювання
    public SmartHomeDevice(SmartHomeDevice device)
    {
        this.deviceName = device.deviceName;
        this.deviceType = device.deviceType;
        this.status = device.status;
        this.powerConsumption = device.powerConsumption;
    }

    // Публічні властивості
    public string DeviceName
    {
        get { return deviceName; }
        set { deviceName = value; }
    }
    public string DeviceType
    {
        get { return deviceType; }
        set { deviceType = value; }
    }
    public bool Status
    {
        get { return status; }
        set { status = value; }
    }
    public float PowerConsumption
    {
        get { return powerConsumption; }
    }

    // Публічні методи
    public void TurnOn()
    {
        status = true;
    }
    public void TurnOff()
    {
        status = false;
    }
    public bool GetStatus()
    {
        return status;
    }
    public void PrintInfo()
    {
        Console.WriteLine("Назва пристрою: " + deviceName);
        Console.WriteLine("Тип пристрою: " + deviceType);
        if (status)
        {
            Console.WriteLine("Статус: ввімкнений");
        }
        else
        {
            Console.WriteLine("Статус: вимкнений");
        }
        Console.WriteLine("Споживання енергії: " + powerConsumption + " Вт");
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Пристрій 1:");
        SmartHomeDevice device = new SmartHomeDevice("Робот-пилосос", "Пилосос", false, 45f);
        device.PrintInfo();

        device.TurnOn();
        Console.WriteLine("\nПісля ввімкнення:");
        device.PrintInfo();

        Console.WriteLine("\nПристрій 2:");
        SmartHomeDevice device2 = new SmartHomeDevice();
        device2.DeviceName = "Розумна лампа";
        device2.DeviceType = "Розумна лампочка";
        device2.Status = true;
        device2.PrintInfo();

        Console.WriteLine("\nПристрій 3 (Копія 1):");
        SmartHomeDevice device3 = new SmartHomeDevice(device);
        device3.PrintInfo();

        Console.WriteLine("\nПомилка:");
        try
        {
            SmartHomeDevice device4 = new SmartHomeDevice("Зволожувач повітря", "Без поняття", false, -46.51f);
            device.PrintInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}
