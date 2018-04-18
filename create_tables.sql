CREATE SCHEMA f2t
CREATE TABLE [f2t].[Activity]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [ActivityName] NVARCHAR(50) NOT NULL, 
    [ActivityPrice] DECIMAL(18, 2) NOT NULL, 
    [ActivityRentalPrice] DECIMAL(18, 2) NOT NULL, 
    [EquipmentCanBeRented] BIT NULL, 
    [ActivityDescription] NVARCHAR(500) NOT NULL, 
    [ActivityPic1] NVARCHAR(1000) NOT NULL, 
    [ActivityPic2] NVARCHAR(1000) NOT NULL
)

CREATE TABLE [f2t].[Hotel]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [HotelName] NVARCHAR(50) NOT NULL, 
    [HotelLocation] NVARCHAR(255) NOT NULL, 
    [TotalNrOfBeds] INT NOT NULL, 
	[BedPricePerNight] DECIMAL(18, 2) NOT NULL,
	[HotelDescription] NVARCHAR(500),
    [PriceForTransport] DECIMAL(18,2) NOT NULL,
	[HotelAdress] NVARCHAR(500) NOT NULL,
    [HotelPic1] NVARCHAR(1000) NOT NULL, 
    [HotelPic2] NVARCHAR(1000) NOT NULL,
    [HotelPic3] NVARCHAR(1000) NOT NULL
)



CREATE TABLE [f2t].[Booking]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [BookingId] NVARCHAR(10) NOT NULL, 
    [TimeStamp] DateTime NOT NULL, 
    [DateFrom] DateTime NOT NULL, 
	[DateTo] DateTime NOT NULL,
	[HotelName] NVARCHAR(50),
	[NoPplForHotel] INT NOT NULL,
	[ActivityId] INT NOT NULL,
	[NoPplForActivity] int NOT NULL,
	[RentEquipment] bit NOT NULL,
	[Transport] bit NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[BookingEmail] NVARCHAR(50) NOT NULL,
	[BookingPhone] NVARCHAR(12) NOT NULL,
    [TotalCost] DECIMAL(18,2) NOT NULL,
    [TotalCostHotel] DECIMAL(18,2) NOT NULL,
    [TotalCostActivity] DECIMAL(18,2) NOT NULL,
    [TotalCostRenting] DECIMAL(18,2) NOT NULL,
    [TotalCostTransport] DECIMAL(18,2) NOT NULL,
	[TotalNoNights] INT NOT NULL,
	[ActivityName] NVARCHAR(50) NOT NULL,
    [IsEdited] BIT
)

CREATE TABLE [f2t].[ActToHot]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
	[HotelFk] INT NOT NULL,
	[ActivityFk] INT NOT NULL
)