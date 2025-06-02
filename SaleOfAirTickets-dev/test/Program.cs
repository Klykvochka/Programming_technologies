using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects;

namespace test
{
    public static class TestDataGenerator
    {
        public static Airlines[] GetAirlines()
        {

            return new Airlines[]
            {
                new Airlines(new Name("Авиалиния 1"), new Country("Россия")),
                new Airlines(new Name("Авиалиния 2"), new Country("Россия")),
                new Airlines(new Name("Авиалиния 3"), new Country("Россия"))
            };
        }
        public static Airports[] GetAirports()
        {

            return new Airports[]
            {
                new Airports(new Name("Аэропорт 1"), new Country("Россия"), new City("Москва")),
                new Airports(new Name("Аэропорт 2"), new Country("Россия"), new City("Спб")),
                new Airports(new Name("Аэропорт 3"), new Country("Россия"), new City("Новвосибирск"))
            };
        }
        public static Customers[] GetCustomers()
        {
            return new Customers[]
            {
                new Customers(new FirstName("Иван"), new LastName("Иванов"), new PhoneNumber("+79123456789"),new Email("ivan@example.com") ),
                new Customers(new FirstName("Петр"), new LastName("Петров"), new PhoneNumber("+79234567890"),new Email("petr@example.com") ),
                new Customers(new FirstName("Мария"), new LastName("Сидорова"), null,new Email("maria@example.com") )
            };
        }


        public static Flights[] GetFlights(Airlines[] airlines, Airports[] airports)
        {
            return new Flights[]
            {
                new Flights( airlines[0], airports[0], airports[1], DateTime.Now.AddHours(2), DateTime.Now.AddHours(5), new CountSeats(100)),
                new Flights( airlines[1], airports[1], airports[2], DateTime.Now.AddHours(4), DateTime.Now.AddHours(7), new CountSeats(300)),
                new Flights( airlines[2], airports[0], airports[2], DateTime.Now.AddHours(6), DateTime.Now.AddHours(9), new CountSeats(100))
            };
        }

        public static Passengers[] GetPassengers()
        {
            return new Passengers[]
            {
                new Passengers(new FirstName("Иван"), new LastName("Иванов"), new PhoneNumber("+79123456789"),new Email("ivan@example.com") , new Passport("1234 567890"), DateTime.Now.AddYears(-25)),
                new Passengers(new FirstName("Петр"), new LastName("Петров"), new PhoneNumber("+79234567890"),new Email("petr@example.com") , new Passport("9876 543210"), DateTime.Now.AddYears(-30)),
                new Passengers(new FirstName("Мария"), new LastName("Сидорова"), new PhoneNumber("+79634567890"), new Email("pe444tr@example.com"),  new Passport("5555 123456"), DateTime.Now.AddYears(-22))
            };
        }

        public static Tariffs[] GetTariffs(Airlines[] moderators)
        {

            return new Tariffs[]
            {
                new Tariffs(moderators[0], new Name("Эконом"), new Price(5000)),
                new Tariffs(moderators[1], new Name("Комфорт"), new Price(8000)),
                new Tariffs(moderators[2], new Name("Бизнес"), new Price(15000))
            };
        }

        public static Seats[] GetSeats(Airlines[] moderators, Flights[] flights, Tariffs[] tariffs)
        {

            return new Seats[]
            {
                new Seats(moderators[0], flights[0], tariffs[0], new SeatNumber(1)),
                new Seats(moderators[0], flights[1], tariffs[1], new SeatNumber(2)),
                new Seats(moderators[1], flights[2], tariffs[2], new SeatNumber(3))
            };
        }

    }


    class Program
    {
        public static void Main(string[] args)
        {
            Airports[] airports = TestDataGenerator.GetAirports();
            Airlines[] airlines = TestDataGenerator.GetAirlines();
            Flights[] flights = TestDataGenerator.GetFlights(airlines, airports);
            Passengers[] passengers = TestDataGenerator.GetPassengers();
            Tariffs[] tariffs = TestDataGenerator.GetTariffs(airlines);
            Seats[] seats = TestDataGenerator.GetSeats(airlines, flights, tariffs);

            //Создали покупателя
            Customers Bob = new Customers(new FirstName("BOB"), new LastName("Kricher"), null, null);


            foreach (var airline in airlines)
                Console.WriteLine($"Airline Name: {airline.Name}, Country: {airline.Country}");


            Airlines air = new Airlines(new Name("Авиалиния 4"), new Country("Россия"));

            //Создаем тарифы
            Tariffs tr1 = air.MakeTariff(new Name("Эконом"), new Price(1000));
            Tariffs tr2 = air.MakeTariff(new Name("ПочтиЭконом"), new Price(2000));
            Tariffs tr3 = air.MakeTariff(new Name("Элитный"), new Price(3000));

            Flights fl1 = air.MakeFlight(airports[0], airports[1], DateTime.Now.AddHours(2), DateTime.Now.AddHours(5), new CountSeats(100));
            Flights fl2 = air.MakeFlight(airports[1], airports[2], DateTime.Now.AddHours(2), DateTime.Now.AddHours(7), new CountSeats(100));
            Flights fl3 = air.MakeFlight(airports[2], airports[1], DateTime.Now.AddHours(2), DateTime.Now.AddHours(5), new CountSeats(100));
            Flights fl4 = air.MakeFlight(airports[0], airports[2], DateTime.Now.AddHours(2), DateTime.Now.AddHours(9), new CountSeats(100));

            //Добавляем места на рейсы
            air.AirlineInitializeSeats(fl1);
            air.AirlineInitializeSeats(fl2);
            air.AirlineInitializeSeats(fl3);
            air.AirlineInitializeSeats(fl4);
            //Проверка
            foreach (var s in fl1.Seats)
            {
                Console.WriteLine($"{s.Id} {s.SeatNumber} {s.Free} {s.Tariff.Name} {s.Airline.Name}");
            }


            // Создаем пассажиров
            Passengers pas = Bob.CreatePassanger(new FirstName("Петя"), new LastName("Крит"), new PhoneNumber("754321314"), new Email("134234242"), new Passport("3219044674"), DateTime.Now.AddYears(-25));
            Passengers pas2 = Bob.CreatePassanger(new FirstName("Алиса"), new LastName("Марковна"), new PhoneNumber("32343333333336"), new Email("kjdnekdj"), new Passport("3219044674"), DateTime.Now.AddYears(-55));

            //Покупаем билет
            Bob.PurchaseTicket(new City("Москва"), new City("Спб"), DateTime.Now.AddHours(2), new Name("Элитный"), new SeatNumber(3), new FirstName("Петя"), new LastName("Крит"), air.Flights);
            Bob.PurchaseTicket(new City("Москва"), new City("Спб"), DateTime.Now.AddHours(2), new Name("Элитный"), new SeatNumber(6), new FirstName("Петя"), new LastName("Крит"), air.Flights);
            Bob.PurchaseTicket(new City("Москва"), new City("Спб"), DateTime.Now.AddHours(2), new Name("Элитный"), new SeatNumber(9), new FirstName("Петя"), new LastName("Крит"), air.Flights);
            Bob.PurchaseTicket(new City("Москва"), new City("Спб"), DateTime.Now.AddHours(2), new Name("ПочтиЭконом"), new SeatNumber(2), new FirstName("Алиса"), new LastName("Марковна"), air.Flights);
            Bob.PurchaseTicket(new City("Москва"), new City("Спб"), DateTime.Now.AddHours(2), new Name("ПочтиЭконом"), new SeatNumber(5), new FirstName("Алиса"), new LastName("Марковна"), air.Flights);

            //Пробуем повторно купить билет на то же место
            //Bob.PurchaseTicket(new City("Москва"), new City("Спб"), DateTime.Now.AddHours(2), new Name("Бомж3"), new SeatNumber(3), new FirstName("Алиса"), new LastName("Марковна"), air.Flights);

            //Смотрим все билеты у пассажира Боба 
            IReadOnlyCollection<Tickets> _ticketPas = Bob.CheckPassengerTickets(pas);
            
            foreach (var tick in _ticketPas)
            {
                Console.WriteLine($"{tick.Id} {tick.Seat.SeatNumber} " +
                    $"{tick.Passenger.FirstName} " +
                    $"{tick.Passenger.LastName} " +
                    $"{tick.Passenger.Passport} " +
                    $"{tick.Customer.FirstName} \n");
            }

            //Проверяем брони
            foreach (var tickpr in Bob.Booking)
            {
                Console.WriteLine($"{tickpr.Date} {tickpr.Status}");
            }
            Console.WriteLine("\n");

            //Проверяем занялось ли место
            foreach (var s in fl1.Seats)
            {
                Console.WriteLine($"{s.Id} {s.SeatNumber} {s.Free} {s.Tariff.Name} {s.Airline.Name}");
            }
            Console.WriteLine("\n");

            //Поиск билета
            var tic = Bob.CheckTicketByPassengerAndDate(pas, fl1);
            Console.WriteLine($"{tic.Id} {tic.Seat.SeatNumber} " +
                $"{tic.Passenger.FirstName} " +
                $"{tic.Passenger.LastName} " +
                $"{tic.Passenger.Passport} " +
                $"{tic.Customer.FirstName} " +
                $"{tic.IfIsActive} \n");
            Console.WriteLine("\n");

            //Закрываем билет
            Bob.CancelTicket(tic);
            Console.WriteLine($"{tic.Id} {tic.Seat.SeatNumber} " +
                $"{tic.Passenger.FirstName} " +
                $"{tic.Passenger.LastName} " +
                $"{tic.Passenger.Passport} " +
                $"{tic.Customer.FirstName} " +
                $"{tic.IfIsActive} \n");

            foreach (var rr in Bob.Booking)
            {
                Console.WriteLine($"{rr.Date} {rr.Status}");
            }
            Console.WriteLine("\n");

            foreach (var s in fl1.Seats)
            {
                Console.WriteLine($"{s.Id} {s.SeatNumber} {s.Free} {s.Tariff.Name} {s.Airline.Name}");
            }

        }
    }
}