USE [crispyspoonDB]
GO

----------------------- tbm_city -------------------------

INSERT INTO [cafeteria].[tbm_city]
           ([city_code]
           ,[city_name])
     VALUES
           ('PUN'
           ,'Pune')
GO

INSERT INTO [cafeteria].[tbm_city]
           ([city_code]
           ,[city_name])
     VALUES
           ('MUM'
           ,'Mumbai')
GO

INSERT INTO [cafeteria].[tbm_city]
           ([city_code]
           ,[city_name])
     VALUES
           ('CHE'
           ,'Chennai')
GO

INSERT INTO [cafeteria].[tbm_city]
           ([city_code]
           ,[city_name])
     VALUES
           ('BLR'
           ,'Bengarulu')
GO

INSERT INTO [cafeteria].[tbm_city]
           ([city_code]
           ,[city_name])
     VALUES
           ('HYD'
           ,'Hydrabad')
GO

----------------------- tbm_facility -------------------------

USE [crispyspoonDB]
GO

INSERT INTO [cafeteria].[tbm_facility]
           ([facility_code]
           ,[facility_name]
           ,[city_code])
     VALUES
           ('PUNH1'
           ,'Pune - Phase 1 - H1'
           ,'PUN')
GO

USE [crispyspoonDB]
GO

INSERT INTO [cafeteria].[tbm_facility]
           ([facility_code]
           ,[facility_name]
           ,[city_code])
     VALUES
           ('PUNH2'
           ,'Pune - Phase 1 - H2'
           ,'PUN')
GO

INSERT INTO [cafeteria].[tbm_facility]
           ([facility_code]
           ,[facility_name]
           ,[city_code])
     VALUES
           ('PUNISH'
           ,'Pune - Phase 1 - ISH'
           ,'PUN')
GO

----------------------- tbm_vendor -------------------------

USE [crispyspoonDB]
GO

INSERT INTO [cafeteria].[tbm_vendor]
           ([vendor_code]
           ,[vendor_name])
     VALUES
           ('PTV'
           ,'Puneri Tadka - Vendor')
GO

INSERT INTO [cafeteria].[tbm_vendor]
           ([vendor_code]
           ,[vendor_name])
     VALUES
           ('NGV'
           ,'New Gymkhana - Vendor')
GO

INSERT INTO [cafeteria].[tbm_vendor]
           ([vendor_code]
           ,[vendor_name])
     VALUES
           ('BMV'
           ,'Brahmana - Vendor')
GO




----------------------- tbm_cafeteria -------------------------

USE [crispyspoonDB]
GO

INSERT INTO [cafeteria].[tbm_cafeteria]
           ([cafeteria_code]
           ,[cafeteria_name]          
           ,[vendor_code])
     VALUES
           ('PUNTAD'
           ,'Puneri Tadka'
           ,'PTV')
GO

INSERT INTO [cafeteria].[tbm_cafeteria]
           ([cafeteria_code]
           ,[cafeteria_name]
           ,[vendor_code])
     VALUES
           ('NEWGYM'
           ,'New Gymkhana' 
           ,'NGV')
GO


INSERT INTO [cafeteria].[tbm_cafeteria]
           ([cafeteria_code]
           ,[cafeteria_name]           
           ,[vendor_code])
     VALUES
           ('BRAHMANA'
           ,'Brahmana Canteen'           
           ,'BMV')
GO

----------------------- tbm_facility_cafeteria_mapping -------------------------

USE [crispyspoonDB]
GO

INSERT INTO [cafeteria].[tbm_facility_cafeteria_mapping]
           ([facility_code]
           ,[cafeteria_code])
     VALUES
           'PUNH1'
           ,'PUNTAD'         
           )
GO

INSERT INTO [cafeteria].[tbm_facility_cafeteria_mapping]
           ([facility_code]
           ,[cafeteria_code])
     VALUES
           'PUNH2'
           ,'PUNTAD'         
           )
GO

INSERT INTO [cafeteria].[tbm_facility_cafeteria_mapping]
           ([facility_code]
           ,[cafeteria_code])
     VALUES
           'PUNH1'
           ,'NEWGYM'         
           )
GO

INSERT INTO [cafeteria].[tbm_facility_cafeteria_mapping]
           ([facility_code]
           ,[cafeteria_code])
     VALUES
           'PUNH2'
           ,'NEWGYM'         
           )
GO


INSERT INTO [cafeteria].[tbm_facility_cafeteria_mapping]
           ([facility_code]
           ,[cafeteria_code])
     VALUES
           'PUNISH'
           ,'BRAHMANA'         
           )
GO


