-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

DROP TABLE [cafeteria].[tbt_order];
GO


DROP TABLE [cafeteria].[tbt_menu_item];
GO


DROP TABLE [cafeteria].[tbm_facility_cafeteria_mapping];
GO


DROP TABLE [cafeteria].[tbt_user_favorites];
GO


DROP TABLE [cafeteria].[tbt_menu];
GO


DROP TABLE [cafeteria].[tbm_user_role];
GO


DROP TABLE [cafeteria].[tbm_entitlement_mapping];
GO


DROP TABLE [cafeteria].[tbt_user_wishlist];
GO


DROP TABLE [cafeteria].[tbm_fooditem];
GO


DROP TABLE [cafeteria].[tbm_cafeteria];
GO


DROP TABLE [cafeteria].[tbm_facility];
GO


DROP TABLE [cafeteria].[tbm_user];
GO


DROP TABLE [cafeteria].[tbm_entitlement];
GO


DROP TABLE [cafeteria].[tbm_role];
GO


DROP TABLE [cafeteria].[tbm_vendor];
GO


DROP TABLE [cafeteria].[tbm_city];
GO



DROP SCHEMA [cafeteria];
GO


CREATE SCHEMA [cafeteria];
GO

--************************************** [cafeteria].[tbm_user]

CREATE TABLE [cafeteria].[tbm_user]
(
 [user_id]        NUMERIC(18,0) NOT NULL ,
 [city_code]      VARCHAR(10) NULL ,
 [facility_code]  VARCHAR(10) NULL ,
 [cafeteria_code] VARCHAR(10) NULL ,

 CONSTRAINT [PK_tbm_user] PRIMARY KEY CLUSTERED ([user_id] ASC)
);
GO



--************************************** [cafeteria].[tbm_entitlement]

CREATE TABLE [cafeteria].[tbm_entitlement]
(
 [entitlement_code]        VARCHAR(10) NOT NULL ,
 [entitlement_name]        VARCHAR(50) NOT NULL ,
 [entitlement_description] VARCHAR(100) NOT NULL ,

 CONSTRAINT [PK_tbm_entitlement] PRIMARY KEY CLUSTERED ([entitlement_code] ASC)
);
GO



--************************************** [cafeteria].[tbm_role]

CREATE TABLE [cafeteria].[tbm_role]
(
 [role_code]        VARCHAR(10) NOT NULL ,
 [role_description] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_tbm_role] PRIMARY KEY CLUSTERED ([role_code] ASC)
);
GO



--************************************** [cafeteria].[tbm_vendor]

CREATE TABLE [cafeteria].[tbm_vendor]
(
 [vendor_code] VARCHAR(10) NOT NULL ,
 [vendor_name] VARCHAR(100) NOT NULL ,

 CONSTRAINT [PK_tbm_vendor] PRIMARY KEY CLUSTERED ([vendor_code] ASC)
);
GO



--************************************** [cafeteria].[tbm_city]

CREATE TABLE [cafeteria].[tbm_city]
(
 [city_code] VARCHAR(10) NOT NULL ,
 [city_name] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_tbm_city] PRIMARY KEY CLUSTERED ([city_code] ASC)
);
GO



--************************************** [cafeteria].[tbm_user_role]

CREATE TABLE [cafeteria].[tbm_user_role]
(
 [role_code] VARCHAR(10) NOT NULL ,
 [user_id]   NUMERIC(18,0) NOT NULL ,

 CONSTRAINT [PK_tbm_user_role] PRIMARY KEY CLUSTERED ([role_code] ASC, [user_id] ASC),
 CONSTRAINT [FK_153] FOREIGN KEY ([role_code])
  REFERENCES [cafeteria].[tbm_role]([role_code]),
 CONSTRAINT [FK_176] FOREIGN KEY ([user_id])
  REFERENCES [cafeteria].[tbm_user]([user_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_153] ON [cafeteria].[tbm_user_role] 
 (
  [role_code] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_176] ON [cafeteria].[tbm_user_role] 
 (
  [user_id] ASC
 )

GO


--************************************** [cafeteria].[tbm_entitlement_mapping]

CREATE TABLE [cafeteria].[tbm_entitlement_mapping]
(
 [role_code]        VARCHAR(10) NOT NULL ,
 [entitlement_code] VARCHAR(10) NOT NULL ,

 CONSTRAINT [PK_tbm_entitlements] PRIMARY KEY CLUSTERED ([role_code] ASC, [entitlement_code] ASC),
 CONSTRAINT [FK_129] FOREIGN KEY ([role_code])
  REFERENCES [cafeteria].[tbm_role]([role_code]),
 CONSTRAINT [FK_141] FOREIGN KEY ([entitlement_code])
  REFERENCES [cafeteria].[tbm_entitlement]([entitlement_code])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_129] ON [cafeteria].[tbm_entitlement_mapping] 
 (
  [role_code] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_141] ON [cafeteria].[tbm_entitlement_mapping] 
 (
  [entitlement_code] ASC
 )

GO


--************************************** [cafeteria].[tbt_user_wishlist]

CREATE TABLE [cafeteria].[tbt_user_wishlist]
(
 [wishlist_id] NUMERIC(18,0) NOT NULL ,
 [user_id]     NUMERIC(18,0) NOT NULL ,
 [item_name]   VARCHAR(50) NOT NULL ,
 [status]      VARCHAR(10) NOT NULL ,
 [remarks]     VARCHAR(50) NULL ,

 CONSTRAINT [PK_tbt_user_wishlist] PRIMARY KEY CLUSTERED ([wishlist_id] ASC),
 CONSTRAINT [FK_193] FOREIGN KEY ([user_id])
  REFERENCES [cafeteria].[tbm_user]([user_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_193] ON [cafeteria].[tbt_user_wishlist] 
 (
  [user_id] ASC
 )

GO


--************************************** [cafeteria].[tbm_fooditem]

CREATE TABLE [cafeteria].[tbm_fooditem]
(
 [item_code]        VARCHAR(10) NOT NULL ,
 [item_description] VARCHAR(100) NOT NULL ,
 [calorie_count]    NUMERIC(18,4) NOT NULL ,
 [item_veg_nonveg]  VARCHAR(1) NOT NULL ,
 [vendor_code]      VARCHAR(10) NOT NULL ,

 CONSTRAINT [PK_tbm_fooditem] PRIMARY KEY CLUSTERED ([item_code] ASC),
 CONSTRAINT [FK_164] FOREIGN KEY ([vendor_code])
  REFERENCES [cafeteria].[tbm_vendor]([vendor_code])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_164] ON [cafeteria].[tbm_fooditem] 
 (
  [vendor_code] ASC
 )

GO


--************************************** [cafeteria].[tbm_cafeteria]

CREATE TABLE [cafeteria].[tbm_cafeteria]
(
 [cafeteria_code] VARCHAR(10) NOT NULL ,
 [cafeteria_name] VARCHAR(100) NOT NULL ,
 [vendor_code]    VARCHAR(10) NOT NULL ,

 CONSTRAINT [PK_tbm_cafeteria] PRIMARY KEY CLUSTERED ([cafeteria_code] ASC),
 CONSTRAINT [FK_201] FOREIGN KEY ([vendor_code])
  REFERENCES [cafeteria].[tbm_vendor]([vendor_code])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_201] ON [cafeteria].[tbm_cafeteria] 
 (
  [vendor_code] ASC
 )

GO


--************************************** [cafeteria].[tbm_facility]

CREATE TABLE [cafeteria].[tbm_facility]
(
 [facility_code] VARCHAR(10) NOT NULL ,
 [facility_name] VARCHAR(100) NOT NULL ,
 [city_code]     VARCHAR(10) NOT NULL ,

 CONSTRAINT [PK_tbm_facility] PRIMARY KEY CLUSTERED ([facility_code] ASC),
 CONSTRAINT [FK_19] FOREIGN KEY ([city_code])
  REFERENCES [cafeteria].[tbm_city]([city_code])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_19] ON [cafeteria].[tbm_facility] 
 (
  [city_code] ASC
 )

GO


--************************************** [cafeteria].[tbm_facility_cafeteria_mapping]

CREATE TABLE [cafeteria].[tbm_facility_cafeteria_mapping]
(
 [facility_code]  VARCHAR(10) NOT NULL ,
 [cafeteria_code] VARCHAR(10) NOT NULL ,

 CONSTRAINT [PK_tbm_facility_cafeteria_mapping] PRIMARY KEY CLUSTERED ([facility_code] ASC, [cafeteria_code] ASC),
 CONSTRAINT [FK_205] FOREIGN KEY ([facility_code])
  REFERENCES [cafeteria].[tbm_facility]([facility_code]),
 CONSTRAINT [FK_210] FOREIGN KEY ([cafeteria_code])
  REFERENCES [cafeteria].[tbm_cafeteria]([cafeteria_code])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_205] ON [cafeteria].[tbm_facility_cafeteria_mapping] 
 (
  [facility_code] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_210] ON [cafeteria].[tbm_facility_cafeteria_mapping] 
 (
  [cafeteria_code] ASC
 )

GO


--************************************** [cafeteria].[tbt_user_favorites]

CREATE TABLE [cafeteria].[tbt_user_favorites]
(
 [user_id]   NUMERIC(18,0) NOT NULL ,
 [item_code] VARCHAR(10) NOT NULL ,

 CONSTRAINT [PK_tbt_user_favorites] PRIMARY KEY CLUSTERED ([user_id] ASC, [item_code] ASC),
 CONSTRAINT [FK_183] FOREIGN KEY ([user_id])
  REFERENCES [cafeteria].[tbm_user]([user_id]),
 CONSTRAINT [FK_189] FOREIGN KEY ([item_code])
  REFERENCES [cafeteria].[tbm_fooditem]([item_code])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_183] ON [cafeteria].[tbt_user_favorites] 
 (
  [user_id] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_189] ON [cafeteria].[tbt_user_favorites] 
 (
  [item_code] ASC
 )

GO


--************************************** [cafeteria].[tbt_menu]

CREATE TABLE [cafeteria].[tbt_menu]
(
 [menu_id]        NUMERIC(18,0) NOT NULL ,
 [menu_date]      DATE NOT NULL ,
 [meal_type]      VARCHAR(10) NOT NULL ,
 [menu_item_name] VARCHAR(50) NOT NULL ,
 [cafeteria_code] VARCHAR(10) NOT NULL ,

 CONSTRAINT [PK_tbt_menu] PRIMARY KEY CLUSTERED ([menu_id] ASC),
 CONSTRAINT [FK_56] FOREIGN KEY ([cafeteria_code])
  REFERENCES [cafeteria].[tbm_cafeteria]([cafeteria_code])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_56] ON [cafeteria].[tbt_menu] 
 (
  [cafeteria_code] ASC
 )

GO

CREATE NONCLUSTERED INDEX [Ind_menu_date_cafe] ON [cafeteria].[tbt_menu] 
 (
  [menu_date] ASC, 
  [cafeteria_code] ASC
 )

GO


--************************************** [cafeteria].[tbt_order]

CREATE TABLE [cafeteria].[tbt_order]
(
 [order_id]        NUMERIC(18,0) NOT NULL ,
 [menu_id]         NUMERIC(18,0) NOT NULL ,
 [user_id]         NUMERIC(18,0) NOT NULL ,
 [order_placed]    DATETIME NOT NULL ,
 [order_delivered] DATETIME NULL ,
 [order_printed]   DATETIME NULL ,
 [order_status]    VARCHAR(50) NULL ,
 [order_qr_code]   IMAGE NULL ,
 [order_rating]    NUMERIC(2,1) NULL ,

 CONSTRAINT [PK_tbt_order] PRIMARY KEY CLUSTERED ([order_id] ASC),
 CONSTRAINT [FK_100] FOREIGN KEY ([menu_id])
  REFERENCES [cafeteria].[tbt_menu]([menu_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_100] ON [cafeteria].[tbt_order] 
 (
  [menu_id] ASC
 )

GO


--************************************** [cafeteria].[tbt_menu_item]

CREATE TABLE [cafeteria].[tbt_menu_item]
(
 [item_code] VARCHAR(10) NOT NULL ,
 [menu_id]   NUMERIC(18,0) NOT NULL ,

 CONSTRAINT [PK_tbt_menu_item] PRIMARY KEY CLUSTERED ([item_code] ASC, [menu_id] ASC),
 CONSTRAINT [FK_82] FOREIGN KEY ([item_code])
  REFERENCES [cafeteria].[tbm_fooditem]([item_code]),
 CONSTRAINT [FK_87] FOREIGN KEY ([menu_id])
  REFERENCES [cafeteria].[tbt_menu]([menu_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_82] ON [cafeteria].[tbt_menu_item] 
 (
  [item_code] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_87] ON [cafeteria].[tbt_menu_item] 
 (
  [menu_id] ASC
 )

GO


