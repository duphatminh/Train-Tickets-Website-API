using TrainTicketsWebsite.Models;

namespace TrainTicketsWebsite.Data;

public class DbInitializer
{
     public static void Initialize(DataContext context)
     {
         context.Database.EnsureCreated();
         if (context.StationsInfo.Any()) return;

         var stations = new List<StationsDetailModel>
         {
             new StationsDetailModel()
             {
                 stationName = "1",
                 stationLocation = "Ho Chi Minh City"
             },
             new StationsDetailModel()
             {
                 stationName = "2",
                 stationLocation = "Ha Noi"
             },
             new StationsDetailModel()
             {
                 stationName = "3",
                 stationLocation = "Da Nang City"
             },
             new StationsDetailModel()
             {
                 stationName = "4",
                 stationLocation = "Ninh Binh City"
             },
             new StationsDetailModel()
             {
                 stationName = "5",
                 stationLocation = "Quang Ngai City"
             }
         };

         foreach (var station in stations)
         {
             context.StationsInfo.Add(station);
         }
         context.SaveChanges(); 
         
         if (context.TrainsInfo.Any()) return;
         
         var trains = new List<TrainsDetailModel>
         {
             new TrainsDetailModel()
             {
                 stationID = stations[0].stationID,
                 trainName = "SE1",
                 schedule = DateTime.Now,
                 departureStation = "Ho Chi Minh City",
                 arrivalStation = "Ha Noi",
                 departureTime = DateTime.Now,
                 arrivalTime = DateTime.Now,
             },
             new TrainsDetailModel()
             {
                 stationID = stations[1].stationID,
                 trainName = "SE2",
                 schedule = DateTime.Now,
                 departureStation = "Ha Noi",
                 arrivalStation = "Ho Chi Minh City",
                 departureTime = DateTime.Now,
                 arrivalTime = DateTime.Now,
             },
             new TrainsDetailModel()
             {
                 stationID = stations[1].stationID,
                 trainName = "SE3",
                 schedule = DateTime.Now,
                 departureStation = "Ha Noi",
                 arrivalStation = "Đa Nang City",
                 departureTime = DateTime.Now,
                 arrivalTime = DateTime.Now,
             },
             new TrainsDetailModel()
             {
                 stationID = stations[2].stationID,
                 trainName = "SE4",
                 schedule = DateTime.Now,
                 departureStation = "Da Nang City",
                 arrivalStation = "Ha Noi",
                 departureTime = DateTime.Now,
                 arrivalTime = DateTime.Now,
             },
             new TrainsDetailModel()
             {
                 stationID = stations[2].stationID,
                 trainName = "SE5",
                 schedule = DateTime.Now,
                 departureStation = "Da Nang City",
                 arrivalStation = "Ninh Binh City",
                 departureTime = DateTime.Now,
                 arrivalTime = DateTime.Now,
             },
             new TrainsDetailModel()
             {
                 stationID = stations[3].stationID,
                 trainName = "SE6",
                 schedule = DateTime.Now,
                 departureStation = "Ninh Binh City",
                 arrivalStation = "Da Nang City",
                 departureTime = DateTime.Now,
                 arrivalTime = DateTime.Now,
             },
             new TrainsDetailModel()
             {
                 stationID = stations[3].stationID,
                 trainName = "SE7",
                 schedule = DateTime.Now,
                 departureStation = "Ninh Binh City",
                 arrivalStation = "Quang Ngai City",
                 departureTime = DateTime.Now,
                 arrivalTime = DateTime.Now,
             },
             new TrainsDetailModel()
             {
                 stationID = stations[4].stationID,
                 trainName = "SE8",
                 schedule = DateTime.Now,
                 departureStation = "Quang Ngai City",
                 arrivalStation = "Ninh Binh City",
                 departureTime = DateTime.Now,
                 arrivalTime = DateTime.Now,
             },
         };

         foreach (var train in trains)
         {
             context.TrainsInfo.Add(train);
         }
         context.SaveChanges(); 
         
         if (context.CarriagesInfo.Any()) return;
         
         var carriages = new List<CarriagesDetailModel>
         {
            new CarriagesDetailModel()
            {
                trainID = trains[0].trainID,
                carriageName = "Bed Compartment",
                carriageType = "Bed",
                carriageStatus = "Available"
            },
            new CarriagesDetailModel()
            {
                trainID = trains[0].trainID,
                carriageName = "Bed Compartment",
                carriageType = "Bed",
                carriageStatus = "Available"
            },
            new CarriagesDetailModel()
            {
                trainID = trains[0].trainID,
                carriageName = "Soft Seat Compartment with Air Conditioner",
                carriageType = "Seat",
                carriageStatus = "Available"
            },
            new CarriagesDetailModel()
            {
                trainID = trains[0].trainID,
                carriageName = "Hard Seat Compartment with Air Conditioner",
                carriageType = "Seat",
                carriageStatus = "Available"
            },
         };

         foreach (var carriage in carriages)
         {
             context.CarriagesInfo.Add(carriage);
         }
         context.SaveChanges(); 
         
         if (context.CabinsInfo.Any()) return;
         
         var cabins = new List<CabinsDetailModel>
         {
             new CabinsDetailModel()
             {
                 carriageID = carriages[0].carriageID,
                 cabinName = "Cabin 1",
             },
             new CabinsDetailModel()
             {
                 carriageID = carriages[0].carriageID,
                 cabinName = "Cabin 2",
             },
             new CabinsDetailModel()
             {
                 carriageID = carriages[1].carriageID,
                 cabinName = "Cabin 1",
             },
             new CabinsDetailModel()
             {
                 carriageID = carriages[1].carriageID,
                 cabinName = "Cabin 2",
             },
             new CabinsDetailModel()
             {
                 carriageID = carriages[2].carriageID,
                 cabinName = "Cabin 1",
             },
             new CabinsDetailModel()
             {
                 carriageID = carriages[2].carriageID,
                 cabinName = "Cabin 2",
             },
             new CabinsDetailModel()
             {
                 carriageID = carriages[3].carriageID,
                 cabinName = "Cabin 1",
             },
             new CabinsDetailModel()
             {
                 carriageID = carriages[3].carriageID,
                 cabinName = "Cabin 2",
             },
         };
         
         foreach (var cabin in cabins)
         {
             context.CabinsInfo.Add(cabin);
         }
         context.SaveChanges(); 
         
         if (context.SeatsInfo.Any()) return;
         
         var seats = new List<Seats>
         {
             new Seats()
             {
                 cabinID = cabins[0].cabinID,
                 seatNumber = 1,
                 seatType = "Bed",
                 seatAvailability  = "Sold Out",
                 price = 1000000
             },
             new Seats()
             {
                 cabinID = cabins[0].cabinID,
                 seatNumber = 2,
                 seatType = "Bed",
                 seatAvailability  = "Empty",
                 price = 1000000
             },
             new Seats()
             {
                 cabinID = cabins[1].cabinID,
                 seatNumber = 1,
                 seatType = "Bed",
                 seatAvailability  = "Empty",
                 price = 1000000
             },
             new Seats()
             {
                 cabinID = cabins[1].cabinID,
                 seatNumber = 2,
                 seatType = "Bed",
                 seatAvailability  = "Empty",
                 price = 1000000
             },
            new Seats()
            {
                cabinID = cabins[2].cabinID,
                seatNumber = 1,
                seatType = "Bed",
                seatAvailability  = "Sold Out",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[2].cabinID,
                seatNumber = 2,
                seatType = "Bed",
                seatAvailability  = "Empty",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[2].cabinID,
                seatNumber = 3,
                seatType = "Bed",
                seatAvailability  = "Empty",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[2].cabinID,
                seatNumber = 4,
                seatType = "Bed",
                seatAvailability  = "Sold Out",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[2].cabinID,
                seatNumber = 5,
                seatType = "Bed",
                seatAvailability  = "Empty",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[2].cabinID,
                seatNumber = 6,
                seatType = "Bed",
                seatAvailability  = "Sold Out",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[3].cabinID,
                seatNumber = 1,
                seatType = "Bed",
                seatAvailability  = "Sold Out",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[3].cabinID,
                seatNumber = 2,
                seatType = "Bed",
                seatAvailability  = "Empty",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[3].cabinID,
                seatNumber = 3,
                seatType = "Bed",
                seatAvailability  = "Empty",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[3].cabinID,
                seatNumber = 4,
                seatType = "Bed",
                seatAvailability  = "Sold Out",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[3].cabinID,
                seatNumber = 5,
                seatType = "Bed",
                seatAvailability  = "Empty",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[3].cabinID,
                seatNumber = 6,
                seatType = "Bed",
                seatAvailability  = "Sold Out",
                price = 1000000
            },
            new Seats()
            {
                cabinID = cabins[4].cabinID,
                seatNumber = 1,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[4].cabinID,
                seatNumber = 2,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[4].cabinID,
                seatNumber = 3,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[4].cabinID,
                seatNumber = 4,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[4].cabinID,
                seatNumber = 5,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[5].cabinID,
                seatNumber = 1,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[5].cabinID,
                seatNumber = 2,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[5].cabinID,
                seatNumber = 3,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[5].cabinID,
                seatNumber = 4,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[5].cabinID,
                seatNumber = 5,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 300000
            },
            new Seats()
            {
                cabinID = cabins[6].cabinID,
                seatNumber = 1,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[6].cabinID,
                seatNumber = 2,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[6].cabinID,
                seatNumber = 3,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[6].cabinID,
                seatNumber = 4,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[6].cabinID,
                seatNumber = 5,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[7].cabinID,
                seatNumber = 1,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[7].cabinID,
                seatNumber = 2,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[7].cabinID,
                seatNumber = 3,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[7].cabinID,
                seatNumber = 4,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
            new Seats()
            {
                cabinID = cabins[7].cabinID,
                seatNumber = 5,
                seatType = "Seat",
                seatAvailability  = "Empty",
                price = 150000
            },
         };
         
        foreach (var seat in seats)
        {
            context.SeatsInfo.Add(seat);
        }
        
         context.SaveChanges();   
         
         if (context.UsersInfo.Any()) return;

         var users = new List<Users>
         {
             new Users()
             {
                userName = "duphatminh",
                email = "duphatminhh@gmail.com",
                phoneNumber = "0898489526",
                password = "123456",
                role = "Admin"
             },
             new Users()
             {
                 userName = "minhphatdu",
                 email = "duphatminhhh@gmail.com",
                 phoneNumber = "123454656",
                 password = "123456",
                 role = "Customer"
             },
             new Users()
             {
                 userName = "phatminhdu",
                 email = "duphatminhhhh@gmail.com",
                 phoneNumber = "5346436456",
                 password = "123456",
                 role = "Employee"
             },
             new Users()
             {
                 userName = "hihihiihihi",
                 email = "duphatminhhh@gmail.com",
                 phoneNumber = "1234567689",
                 password = "123456",
                 role = "Customer"
             },
         };

         foreach (var user in users)
         {
             context.UsersInfo.Add(user);
         }

         context.SaveChanges();
     }
}