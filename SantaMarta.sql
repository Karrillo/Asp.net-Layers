--Base de Datos--
CREATE DATABASE SantaMarta;

CREATE TABLE Emails(
Email varchar(50) UNIQUE NOT NULL,
Password varchar(100) NOT NULL
);

CREATE TABLE Users(
IDUser bigserial PRIMARY KEY,
Nickname varchar(15) UNIQUE NOT NULL,
Password varchar(50) NOT NULL,
Type boolean NOT NULL,
State boolean NOT NULL DEFAULT true
);

CREATE TABLE Persons(
IDPerson bigserial PRIMARY KEY,
Code varchar(20) UNIQUE NOT NULL,
Name varchar (30) NOT NULL,
FirstName varchar(15) NOT NULL,
SecondName varchar(15) NOT NULL,
NameCompany varchar (40) NOT NULL,
Phone varchar(9) NULL,
CellPhone varchar(9) NULL,
Email varchar(40) NULL,
Address varchar(70) NOT NULL
);

CREATE TABLE Clients(
IDClient bigserial PRIMARY KEY,
State boolean NOT NULL DEFAULT true,
IDPerson bigint NOT NULL,
CONSTRAINT fkey_client_idperson FOREIGN KEY(IDPerson) REFERENCES Persons(IDPerson)
);

CREATE TABLE Providers(
IDProvider bigserial PRIMARY KEY,
State boolean NOT NULL DEFAULT true,
IDPerson bigint NOT NULL,
CONSTRAINT fkey_provider_idperson FOREIGN KEY(IDPerson) REFERENCES Persons(IDPerson)
);

CREATE TABLE Categories(
IDCategory bigserial PRIMARY KEY,
Name varchar(50) UNIQUE NOT NULL,
State boolean NOT NULL DEFAULT true
);

CREATE TABLE SubCategories(
IDSubCategory bigserial PRIMARY KEY,
Name varchar(50) NOT NULL,
State boolean NOT NULL DEFAULT true,
IDCategory bigint NOT NULL,
CONSTRAINT fkey_subcategory_idcategory FOREIGN KEY(IDCategory) REFERENCES Categories(IDCategory)
);

CREATE TABLE Accounts(
IDAccount bigserial PRIMARY KEY,
Name varchar(30) UNIQUE NOT NULL,
State boolean NOT NULL DEFAULT true
);

CREATE TABLE Products(
IDProduct bigserial PRIMARY KEY,
Description varchar(70) NULL,
Price decimal(18,2) NOT NULL,
Code varchar(20) UNIQUE NOT NULL,
Name varchar(20) NOT NULL,
Tax decimal (18,2) NULL,
State boolean NOT NULL DEFAULT true,
IDProvider bigint NOT NULL,
CONSTRAINT fkey_product_idprovider FOREIGN KEY(IDProvider) REFERENCES Providers(IDProvider)
);

CREATE TABLE Details(
IDDetail bigserial PRIMARY KEY,
CurrentDate date NOT NULL,
IDUser bigint,
CONSTRAINT fkey_detail_iduser FOREIGN KEY(IDUser) REFERENCES Users(IDUser)
); 

CREATE TABLE Invoices(
IDInvoice bigserial PRIMARY KEY,
LimitDate date NULL,
Code varchar (30) NOT NULL,
Discount decimal (18,2) NULL,
Total decimal (18,2) NOT NULL,
State boolean NOT NULL DEFAULT true,
IDProvider bigint NOT NULL,
IDClient bigint NOT NULL,
IDDetail bigint NOT NULL,
CONSTRAINT fkey_invoice_idprovider FOREIGN KEY(IDProvider) REFERENCES Providers(IDProvider),
CONSTRAINT fkey_invoice_idclient FOREIGN KEY(IDClient) REFERENCES Clients(IDClient),
CONSTRAINT fkey_invoice_iddetail FOREIGN KEY(IDDetail) REFERENCES Details(IDDetail)
);

CREATE TABLE Sales(
IDSale bigserial PRIMARY KEY,
Quantity int NOT NULL,
Total decimal (18,2) NOT NULL,
IDDetail bigint NOT NULL,
IDProduct bigint NOT NULL,
CONSTRAINT fkey_sale_iddetail FOREIGN KEY(IDDetail) REFERENCES Details(IDDetail),
CONSTRAINT fkey_sale_idproduct FOREIGN KEY(IDProduct) REFERENCES Products(IDProduct)
);

CREATE TABLE Purchases(
IDSale bigserial PRIMARY KEY,
Quantity int NOT NULL,
Total decimal (18,2) NOT NULL,
IDDetail bigint NOT NULL,
IDProduct bigint NOT NULL,
CONSTRAINT fkey_sale_iddetail FOREIGN KEY(IDDetail) REFERENCES Details(IDDetail),
CONSTRAINT fkey_sale_idproduct FOREIGN KEY(IDProduct) REFERENCES Products(IDProduct)
);
 
CREATE TABLE AssetsLiabilities(
IDAssetLiability bigserial PRIMARY KEY,
CurrentDate date NOT NULL,
Code varchar (30) NOT NULL,
Rode decimal (18,2) NOT NULL,
Type boolean NOT NULL,
Description varchar(100) NULL,
Name varchar (70) NOT NULL,
State boolean NOT NULL DEFAULT true,
IDInvoice bigint NULL,
IDAccount bigint NOT NULL,
IDSubCategory bigint NOT NULL,
IDUser bigint NOT NULL,
CONSTRAINT fkey_invoice_iduser FOREIGN KEY(IDUser) REFERENCES Users(IDUser),
CONSTRAINT fkey_assetliability_idinvoice FOREIGN KEY(IDInvoice) REFERENCES Invoices(IDInvoice),
CONSTRAINT fkey_assetliability_idsubcategory FOREIGN KEY(IDSubCategory) REFERENCES SubCategories(IDSubCategory),
CONSTRAINT fkey_assetliability_idaccount FOREIGN KEY(IDAccount) REFERENCES Accounts(IDAccount)
);

--Funciones--
--Clientes--
CREATE OR REPLACE FUNCTION Insert_Client(
    _Code varchar(20),
    _Name varchar (30),
    _FirstName varchar(15),
    _SecondName varchar(15),
    _Phone varchar(9),
    _CellPhone varchar(9),
    _Email varchar(40),
    _Address varchar(70),
    _NameCompany varchar (40))
RETURNS VOID AS
$$
DECLARE _id bigint;
BEGIN
    INSERT INTO Persons (Code, Name, FirstName, SecondName, Phone, CellPhone, Email, Address, NameCompany)
    VALUES (_Code, _Name, _FirstName, _SecondName, _Phone, _CellPhone, _Email, _Address, _NameCompany)
    
    RETURNING IDPerson INTO _id;
    
    INSERT INTO Clients (IDPerson,State)
    VALUES (_id,true);
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Insert_Client_Provider(
    _IDClient bigint)
RETURNS VOID AS
$$
BEGIN
    INSERT INTO Providers (IDPerson)
    (SELECT Clients.IDPerson FROM Clients INNER JOIN Persons ON Clients.IDPerson = Persons.IDPerson WHERE Clients.IDClient = _IDClient);
END;
$$ LANGUAGE 'plpgsql';

DROP TYPE IF EXISTS Type_Client CASCADE;
CREATE TYPE Type_Client AS
(
    IDPerson bigint,
    Code varchar(20),
    Name varchar (30),
    FirstName varchar(15),
    SecondName varchar(15),
    NameCompany varchar (40),
    Phone varchar(9),
    CellPhone varchar(9),
    Email varchar(40),
    Address varchar(70),
    IDClient bigint
);

CREATE OR REPLACE FUNCTION View_Client(
    _id bigint)
RETURNS SETOF Type_Client AS
$$
BEGIN
RETURN QUERY
    SELECT Persons.*,Clients.IDClient FROM Clients 
    INNER JOIN Persons on Clients.IDPerson = Persons.IDPerson 
    WHERE Clients.IDClient = _id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION update_Client(
    _Code varchar (20),
    _Name varchar (30),
    _FirstName varchar(15),
    _SecondName varchar(15),
    _Phone varchar(9),
    _CellPhone varchar(9),
    _Email varchar(40),
    _Address varchar(70),
    _NameCompany varchar (40),
    _id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Persons
    SET Code = _Code, Name = _Name, FirstName = _FirstName, SecondName = _SecondName, Phone = _Phone,CellPhone = _CellPhone, Email = _Email, Address = _Address, NameCompany = _NameCompany
    WHERE IDPerson = _id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Delete_Client(
    _id bigint)
RETURNS VOID AS
$$
BEGIN 
    UPDATE Clients
    SET State = false
    WHERE IDClient = _Id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Restore_Client(
    _id bigint)
RETURNS VOID AS
$$
BEGIN 
    UPDATE Clients
    SET State = true
    WHERE IDClient = _Id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION All_Clients_Active()
RETURNS SETOF Type_Client AS
$$
BEGIN 
RETURN QUERY
    SELECT Persons.*,Clients.IDClient FROM Clients INNER JOIN Persons on Clients.IDPerson = Persons.IDPerson 
    AND Clients.State = true AND Persons.NameCompany != 'Productos Alimenticios Santa Marta';
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION All_Clients_Deleted()
RETURNS SETOF Type_Client AS
$$
BEGIN 
RETURN QUERY
    SELECT Persons.*,Clients.IDClient FROM Clients INNER JOIN Persons on Clients.IDPerson = Persons.IDPerson AND Clients.State = false;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Seach_Client_Word(
    _Name varchar (60))
RETURNS SETOF Type_Client AS
$$
BEGIN
RETURN QUERY
    SELECT Persons.*, Clients.IDClient FROM Clients
    INNER JOIN Persons ON Clients.IDPerson = Persons.IDPerson AND Clients.State = true
    WHERE (LOWER(concat(Persons.FirstName::text,' '::text,  Persons.Secondname::text,' '::text, Persons.Name::text)) LIKE '%'|| LOWER(_Name) ||'%'
    OR LOWER(Persons.NameCompany) LIKE '%'|| LOWER(_Name) || '%' OR LOWER(Persons.Code) LIKE '%'|| LOWER(_Name) || '%')
    AND Persons.NameCompany != 'Productos Alimenticios Santa Marta';
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION ClientsAll()
RETURNS TABLE (Id bigint) AS
$$
BEGIN
RETURN QUERY
    SELECT Clients.IDPerson FROM Clients;
END; 
$$ LANGUAGE 'plpgsql'; 

--Proveedores
CREATE OR REPLACE FUNCTION Insert_Provider(
    _Code varchar (20),
    _Name varchar (30),
    _FirstName varchar(15),
    _SecondName varchar(15),
    _Phone varchar(9),
    _CellPhone varchar(9),
    _Email varchar(40),
    _Address varchar(70),
    _NameCompany varchar (40))
RETURNS VOID AS
$$
DECLARE _id bigint;
BEGIN
    INSERT INTO Persons (Code, Name, FirstName, SecondName, Phone, CellPhone, Email, Address, NameCompany)
    VALUES (_Code, _Name, _FirstName, _SecondName, _Phone, _CellPhone, _Email, _Address, _NameCompany)
    
    RETURNING IDPerson INTO _id;
    
    INSERT INTO Providers (IDPerson,State)
    VALUES (_id,true);
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Insert_Provider_Client(
    _IDProvider bigint)
RETURNS VOID AS
$$
BEGIN
    INSERT INTO Clients (IDPerson)
    (SELECT Providers.IDPerson FROM Providers INNER JOIN Persons ON Providers.IDPerson = Persons.IDPerson WHERE Providers.IDProvider = _IDProvider);
END;
$$ LANGUAGE 'plpgsql';

DROP TYPE IF EXISTS Type_Provider CASCADE;
CREATE TYPE Type_Provider AS
(
    IDPerson bigint,
    Code varchar (20),
    Name varchar (30),
    FirstName varchar(15),
    SecondName varchar(15),
    NameCompany varchar (40),
    Phone varchar(9),
    CellPhone varchar(9),
    Email varchar(40),
    Address varchar(70),
    IDProvider bigint
);

CREATE OR REPLACE FUNCTION View_Provider(
    _id bigint)
RETURNS SETOF Type_Provider AS
$$
BEGIN
RETURN QUERY
    SELECT Persons.*,Providers.IDProvider FROM Providers 
    INNER JOIN Persons on Providers.IDPerson = Persons.IDPerson
    WHERE Providers.IDProvider = _id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Update_Provider(
    _Code varchar (20),
    _Name varchar (30),
    _FirstName varchar(15),
    _SecondName varchar(15),
    _Phone varchar(9),
    _CellPhone varchar(9),
    _Email varchar(40),
    _Address varchar(70),
    _NameCompany varchar (40),
    _id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Persons
    SET Code = _Code, Name = _Name, FirstName = _FirstName, SecondName = _SecondName, Phone = _Phone,CellPhone = _CellPhone, Email = _Email, Address = _Address, NameCompany = _NameCompany
    WHERE IDPerson = _id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Delete_Provider(
    _id bigint)
RETURNS VOID AS
$$
BEGIN 
    UPDATE Providers
    SET State = false
    WHERE IDProvider = _Id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Restore_Provider(
    _id bigint)
RETURNS VOID AS
$$
BEGIN 
    UPDATE Providers
    SET State = true
    WHERE IDProvider = _Id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION All_Providers_Active()
RETURNS SETOF Type_Provider AS
$$
BEGIN
RETURN QUERY
    SELECT Persons.*,Providers.IDProvider FROM Providers INNER JOIN Persons on Providers.IDPerson = Persons.IDPerson AND Providers.State = true AND Persons.Namecompany != 'Productos Alimenticios Santa Marta';
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION All_Providers_Deleted()
RETURNS SETOF Type_Provider AS
$$
BEGIN
RETURN QUERY
    SELECT Persons.*,Providers.IDProvider FROM Providers INNER JOIN Persons on Providers.IDPerson = Persons.IDPerson AND Providers.State = false;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION ProvidersAll()
RETURNS TABLE (Id bigint) AS
$$
BEGIN
RETURN QUERY
    SELECT Providers.IDPerson FROM Providers;
END; 
$$ LANGUAGE 'plpgsql'; 

--Productos
CREATE OR REPLACE FUNCTION Insert_Product(
    _Description varchar(70),
    _Price decimal(18,2),
    _Tax decimal(18,2),
    _Code varchar(20),
    _Name varchar(20),
    _IDProvider bigint)   
RETURNS VOID AS
$$
BEGIN
    INSERT INTO Products(Description, Price, Tax, Code, Name, IDProvider, State)
    VALUES (_Description, _Price, _Tax, _Code, _Name, _IDProvider, true);
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Update_Product(
    _Description varchar(70),
    _Price decimal(18,2),
    _Tax decimal(18,2),
    _Code varchar(20),
    _Name varchar(20),
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Products
    SET Description = _Description, Price = _Price, Tax = _Tax, Code = _Code, Name = _Name
    WHERE IDProduct = _Id;
END;
$$ LANGUAGE 'plpgsql';

DROP TYPE IF EXISTS Type_Product CASCADE;
CREATE TYPE Type_Product AS
(
    IDProduct bigint,
    Description varchar(70),
    Price decimal(18,2),
    Code varchar(20),
    Name varchar(20),
    Tax decimal(18,2),
    State boolean,
    IDProvider bigint
);

CREATE OR REPLACE FUNCTION View_Product(
    _Id bigint)
RETURNS SETOF Type_Product AS
$$
BEGIN
RETURN QUERY
    SELECT Products.* FROM Products INNER JOIN Providers on Products.IDProvider = Providers.IDProvider 
    WHERE Products.IDProduct = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Delete_Product(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN  
    UPDATE Products 
    SET State = false
    WHERE IDProduct = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Restore_Product(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN  
    UPDATE Products 
    SET State = true
    WHERE IDProduct = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Provider_Products(
    _Id bigint)
RETURNS SETOF Type_Product AS 
$$
BEGIN
RETURN QUERY
    SELECT Products.* FROM Products INNER JOIN Providers on Products.IDProvider = Providers.IDProvider 
    WHERE Products.IDProvider = _Id AND Products.State = true;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION List_Providers()
RETURNS TABLE (IDProvider bigint, Name varchar(30), FirstName varchar(15), SecondName varchar(15), NameCompany varchar(40)) AS
$$
BEGIN 
RETURN QUERY
    SELECT Providers.IDProvider, Persons.Name, Persons.FirstName, Persons.SecondName, Persons.NameCompany 
    FROM Providers INNER JOIN Persons ON  Providers.IDPerson = Persons.IDPerson WHERE Persons.NameCompany != 'Productos Alimenticios Santa Marta' AND Providers.State = true;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION List_Products_Deleted()
RETURNS TABLE (IDProduct bigint, Description varchar(70), Price decimal(18,2), Code varchar(20), Name varchar(20), Tax decimal(18,2), State boolean, IDProvider bigint, NameCompany varchar(40), CodeProvider varchar(20), FullName text) AS
$$
BEGIN
RETURN QUERY
    SELECT Products.*, Persons.NameCompany, Persons.Code AS CodeProviders, Persons.Name ||' '|| Persons.FirstName ||' '|| Persons.SecondName AS FullName  FROM Products 
    INNER JOIN Providers on Products.IDProvider = Providers.IDProvider 
    INNER JOIN Persons ON Persons.IDPerson = Providers.IDPerson
    WHERE Products.State = false;
END;
$$ LANGUAGE 'plpgsql';

--productos propios
CREATE OR REPLACE FUNCTION Insert_Product_SM(
    _Description varchar(70),
    _Price decimal(18,2),
    _Code varchar(20),
    _Name varchar(20),
    _Tax decimal(18,2))
RETURNS VOID AS
$$
DECLARE _id bigint;
BEGIN
    _Id = (SELECT Providers.IDProvider FROM Providers INNER JOIN Persons ON Providers.IDPerson = Persons.IDPerson WHERE NameCompany = 'Productos Alimenticios Santa Marta');
    
    INSERT INTO Products(Description, Price, Code, Name, IDProvider, State, Tax)
    VALUES (_Description, _Price, _Code, _Name, _Id, true, _Tax);
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION List_Products_SM()
RETURNS SETOF Type_Product AS
$$
BEGIN
RETURN QUERY
    SELECT Products.* FROM Products 
    INNER JOIN Providers on Products.IDProvider = Providers.IDProvider 
    INNER JOIN Persons on Providers.IDPerson = Persons.IDPerson
    WHERE Persons.NameCompany = 'Productos Alimenticios Santa Marta' AND Products.State = true;
END;
$$ LANGUAGE 'plpgsql';

--Usuarios
CREATE OR REPLACE FUNCTION Insert_User(
    _Nickname varchar (15),
    _Password varchar(50),
    _Type boolean)
RETURNS VOID AS
$$
BEGIN
    INSERT INTO Users(Nickname, Password, Type)
    VALUES (_Nickname, _Password, _Type);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Update_User(
    _Nickname varchar (15),
    _Password varchar(50),
    _Type boolean,
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Users
    SET Nickname = _Nickname, Password = _Password, Type = _Type
    WHERE IDUser = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Delete_User(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Users
    SET State = false
    WHERE IDUser = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Restore_User(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Users
    SET State = true
    WHERE IDUser = _Id;
END; 
$$ LANGUAGE 'plpgsql';

DROP TYPE IF EXISTS Type_User CASCADE;
CREATE TYPE Type_User AS
(
    IDUser bigint,
    Nickname varchar (15),
    Password varchar(50),
    Type boolean,
    State boolean
);

CREATE OR REPLACE FUNCTION Check_User(
    _Nickname varchar (15),
    _Password varchar(50))
RETURNS SETOF Type_User AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM Users
    WHERE LOWER(Users.Nickname) = LOWER(_Nickname) AND Users.Password = _Password AND Users.State = true;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION List_Users()
RETURNS SETOF Type_User AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM Users WHERE Users.State = true;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION List_Users_Deleted()
RETURNS SETOF Type_User AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM Users WHERE Users.State = false;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Users(
    _id bigint)
RETURNS SETOF Type_User AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM Users WHERE Users.IDUser = _id;
END;
$$ LANGUAGE 'plpgsql';

--Cuentas--
CREATE OR REPLACE FUNCTION Insert_Account(
    _Name varchar(30))
RETURNS VOID AS
$$
BEGIN
    INSERT INTO Accounts (Name, State)
    VALUES (_Name, true);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Update_Account(
    _Name varchar(30),
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Accounts
    SET Name = _Name
    WHERE IDAccount = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Delete_Account(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN  
    UPDATE Accounts 
    SET State = false
    WHERE IDAccount = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Restore_Account(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN  
    UPDATE Accounts 
    SET State = true
    WHERE IDAccount = _Id;
END; 
$$ LANGUAGE 'plpgsql';

DROP TYPE IF EXISTS Type_Account CASCADE;
CREATE TYPE Type_Account AS
(
    IDAccount bigint,
    Name varchar (30),
    State boolean
);

CREATE OR REPLACE FUNCTION List_Accounts()
RETURNS SETOF Type_Account AS
$$
BEGIN 
RETURN QUERY
    SELECT * FROM Accounts WHERE Accounts.State = true;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION List_Accounts_Deleted()
RETURNS SETOF Type_Account AS
$$
BEGIN 
RETURN QUERY
    SELECT * FROM Accounts WHERE Accounts.State = false;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Account(
    _id bigint)
RETURNS SETOF Type_Account AS
$$
BEGIN 
RETURN QUERY
    SELECT * FROM Accounts WHERE Accounts.State = true AND Accounts.IDAccount = _id;
END;
$$ LANGUAGE 'plpgsql';

--Categorias--
CREATE OR REPLACE FUNCTION Insert_Category(
    _Name varchar(30))
RETURNS VOID AS
$$
BEGIN
    INSERT INTO Categories (Name, State)
    VALUES (_Name, true);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Update_Category(
    _Name varchar(30),
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Categories
    SET Name = _Name
    WHERE IDCategory = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Delete_Category(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN  
    UPDATE Categories 
    SET State = false
    WHERE IDCategory = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Restore_Category(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN  
    UPDATE Categories 
    SET State = true
    WHERE IDCategory = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Categories()
RETURNS TABLE (IDCategory bigint, Name varchar(50), State boolean) AS
$$
BEGIN
RETURN QUERY 
    SELECT * FROM Categories WHERE Categories.State = true;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Categories_Deleted()
RETURNS TABLE (IDCategory bigint, Name varchar(50), State boolean) AS
$$
BEGIN
RETURN QUERY 
    SELECT * FROM Categories WHERE Categories.State = false;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Category(
    _id bigint)
RETURNS TABLE (IDCategory bigint, Name varchar(50), State boolean) AS
$$
BEGIN 
RETURN QUERY
    SELECT * FROM Categories WHERE Categories.State = true AND Categories.IDCategory = _id;
END;
$$ LANGUAGE 'plpgsql';

--Sub Categorias
CREATE OR REPLACE FUNCTION Insert_SubCategory(
    _Name varchar(30),
    _IDCategory bigint)
RETURNS VOID AS
$$
BEGIN
    INSERT INTO SubCategories (Name, State, IDCategory)
    VALUES (_Name, true, _IDCategory);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Update_SubCategory(
    _Name varchar(30),
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE SubCategories
    SET Name = _Name
    WHERE IDSubCategory = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Delete_SubCategory(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN  
    UPDATE SubCategories 
    SET State = false
    WHERE IDSubCategory = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Restore_SubCategory(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN  
    UPDATE SubCategories 
    SET State = true
    WHERE IDSubCategory = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_SubCategories()
RETURNS TABLE (IDSubCategory bigint, Name varchar(50), State boolean, IDCategory bigint) AS
$$
BEGIN
RETURN QUERY 
    SELECT * FROM SubCategories WHERE SubCategories.State = true;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_SubCategories_Deleted()
RETURNS TABLE (IDSubCategory bigint, NameSubCategory varchar(50), StateCategory boolean, NameCategory varchar(50), StateSubCategory boolean) AS
$$
BEGIN
RETURN QUERY 
        SELECT s.IDSubCategory, s.Name AS NameSubCategory, s.State AS StateCategory, c.Name AS NameCategory, c.State AS StateSubCategory  
        FROM SubCategories AS s INNER JOIN Categories AS c ON s.IDCategory = c.IDCategory 
        WHERE s.State = false;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_SubCategory(
    _id bigint)
RETURNS TABLE (IDSubCategory bigint, Name varchar(50), State boolean, IDCategory bigint) AS
$$
BEGIN 
RETURN QUERY
    SELECT * FROM SubCategories WHERE SubCategories.State = true AND SubCategories.IDSubCategory = _id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_SubCategoryByCategory(
    _id bigint)
RETURNS TABLE (IDSubCategory bigint, Name varchar(50), State boolean, IDCategory bigint) AS
$$
BEGIN 
RETURN QUERY
    SELECT * FROM SubCategories WHERE SubCategories.State = true AND SubCategories.IDCategory = _id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_CategoryName(
    _id bigint)
RETURNS TABLE (Name varchar(50)) AS
$$
BEGIN 
RETURN QUERY
        SELECT DISTINCT ON(Categories.*) Categories.Name  FROM SubCategories 
        INNER JOIN Categories ON SubCategories.IDCategory = Categories.IDCategory 
        WHERE SubCategories.IDSubCategory = _id;
END;
$$ LANGUAGE 'plpgsql';

--Activos y Pasivos
CREATE OR REPLACE FUNCTION Insert_AssetLiability(
    _CurrentDate date,
    _Code varchar (30),
    _Rode decimal (18,2),
    _Type boolean,
    _Description varchar(100),
    _Name varchar(70),
    _IDAccount bigint,
    _IDSubCategory bigint,
    _IDUser bigint)
RETURNS VOID AS
$$
BEGIN
    INSERT INTO AssetsLiabilities (CurrentDate, Code, Rode, Type, Description, Name, IDAccount, IDSubCategory, IDUser)
    VALUES (_CurrentDate, _Code, _Rode, _Type, _Description, _Name, _IDAccount, _IDSubCategory, _IDUser);
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Insert_AssetLiability_Credit(
    _CurrentDate date,
    _Code varchar (30),
    _Rode decimal (18,2),
    _Type boolean,
    _Description varchar(100),
    _Name varchar(70),
    _IDAccount bigint,
    _IDSubCategory bigint,
    _IDUser bigint,
    _IDInvoice bigint)
RETURNS VOID AS
$$
BEGIN
    INSERT INTO AssetsLiabilities (CurrentDate, Code, Rode, Type, Description, Name, IDAccount, IDSubCategory, IDUser, IDInvoice)
    VALUES (_CurrentDate, _Code, _Rode, _Type, _Description, _Name, _IDAccount, _IDSubCategory, _IDUser, _IDInvoice);
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Delete_AssetLiability(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE AssetsLiabilities
    SET State = false 
    WHERE IDAssetLiability = _Id;
END;
$$ LANGUAGE 'plpgsql';

DROP TYPE IF EXISTS Type_AssetLiability CASCADE;
CREATE TYPE Type_AssetLiability AS
(
    IDAssetLiability bigint,
    CurrentDate date,
    Code varchar (30),
    Rode decimal (18,2),
    Type boolean,
    Description varchar(100),
    Name varchar(70),
    State boolean,
    IDInvoice bigint,
    IDAccount bigint,
    IDSubCategory bigint,
    IDUser bigint
);

CREATE OR REPLACE FUNCTION View_AssetLiability(
    _Id bigint)
RETURNS SETOF Type_AssetLiability AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM AssetsLiabilities WHERE IDAssetLiability = _Id;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION All_AssetsLiabilities()
RETURNS SETOF Type_AssetLiability AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM AssetsLiabilities WHERE State = true;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Date_Sum_AssetLiability(
    _DateMax date,
    _DateMin date,
    _Type boolean)
RETURNS TABLE (Total decimal (18,2)) AS
$$
BEGIN
RETURN QUERY
    SELECT SUM (AssetsLiabilities.Rode) as Total FROM AssetsLiabilities 
    WHERE AssetsLiabilities.CurrentDate >= _DateMin 
    AND AssetsLiabilities.CurrentDate <= _DateMax 
    AND AssetsLiabilities.Type = _Type 
    AND AssetsLiabilities.State = true;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Date_Account_AssetLiability(
    _DateMax date,
    _DateMin date)
RETURNS TABLE (Total decimal (18,2)) AS
$$
BEGIN
RETURN QUERY
    SELECT COUNT(*) AS Total FROM AssetsLiabilities 
    WHERE AssetsLiabilities.CurrentDate >= _DateMin AND AssetsLiabilities.CurrentDate <= _DateMax;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Date_AssetLiability(
    _DateMax date,
    _DateMin date)
RETURNS SETOF Type_AssetLiability AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM AssetsLiabilities 
    WHERE AssetsLiabilities.CurrentDate >= _DateMin AND AssetsLiabilities.CurrentDate <= _DateMax
     ORDER BY AssetsLiabilities.IdAssetLiability DESC;
END; 
$$ LANGUAGE 'plpgsql'; 

--Detalles
CREATE OR REPLACE FUNCTION Insert_Detail(
    _IDUser bigint)
RETURNS bigint AS
$$
DECLARE _id bigint;
BEGIN
    INSERT INTO Details (CurrentDate, IDUser)
    VALUES (now(), _IDUser)
    
    RETURNING IDDetail INTO _id;
    
    RETURN _id;
END;
$$ LANGUAGE 'plpgsql';

--Compras
CREATE OR REPLACE FUNCTION Insert_Purchase(
    _Quantity integer,
    _Total decimal,
    _IDDetail bigint,
    _IDProduct bigint)
RETURNS VOID AS
$$
BEGIN    
    INSERT INTO Purchases (Quantity, Total, IDDetail, IDProduct)
    VALUES (_Quantity, _Total, _IDDetail, _IDProduct);
END;
$$ LANGUAGE 'plpgsql';

--Ventas
CREATE OR REPLACE FUNCTION Insert_Sale(
    _Quantity integer,
    _Total decimal,
    _IDDetail bigint,
    _IDProduct bigint)
RETURNS VOID AS
$$
BEGIN    
    INSERT INTO Sales (Quantity, Total, IDDetail, IDProduct)
    VALUES (_Quantity, _Total, _IDDetail, _IDProduct);
END;
$$ LANGUAGE 'plpgsql';


--Factura--
CREATE OR REPLACE FUNCTION Insert_Invoice(
    _LimitDate date,
    _Code varchar (30),
    _Discount decimal (18,2),
    _Total decimal (18,2),
    _IDProvider bigint,
    _IDClient bigint,
    _IDDetail bigint)
RETURNS VOID AS
$$
BEGIN    
    INSERT INTO Invoices (LimitDate, Code, Discount, Total, IDProvider, IDClient, IDDetail)
    VALUES (_LimitDate, _Code, _Discount, _Total, _IDProvider, _IDClient, _IDDetail);
END;
$$ LANGUAGE 'plpgsql';

DROP TYPE IF EXISTS Type_Invoice CASCADE;
CREATE TYPE Type_Invoice AS
(
    IDInvoice bigint,
    LimitDate date,
    Code varchar (30),
    Discount decimal (18,2),
    Total decimal (18,2),
    State boolean,
    IDProvider bigint,
    IDClient bigint,
    IDDetail bigint,
    CurrentDate date,
    Name varchar (30),
    FirstName varchar (15),
    SecondName varchar (15), 
    NameCompany varchar (40)
);

CREATE OR REPLACE FUNCTION Delete_Invoice(
    _Id bigint)
RETURNS VOID AS
$$
BEGIN
    UPDATE Invoices 
    SET State = false
    WHERE IDInvoice = _Id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Check_AssestLiabilities(
    _id bigint)
RETURNS TABLE (State boolean) AS
$$
BEGIN 
RETURN QUERY
    SELECT DISTINCT ON (i.IDInvoice)i.State 
    FROM AssetsLiabilities AS i 
    WHERE i.IDInvoice = _id AND i.state = true;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Code_Invoice()
RETURNS TABLE (Code varchar(30)) AS
$$
BEGIN 
RETURN QUERY
    SELECT i.Code FROM Invoices AS i 
    INNER JOIN DETAILS AS d ON i.IDDetail = d.IDDetail 
    INNER JOIN SALES AS s ON s.IDDetail = d.IDDetail 
    ORDER BY i.IdInvoice DESC LIMIT 1;
END;
$$ LANGUAGE 'plpgsql';

DROP TYPE IF EXISTS Type_Details_Products CASCADE;
CREATE TYPE Type_Details_Products AS
(
    Code varchar(20),
    Name varchar(20),
    Price decimal(18,2),
    Tax decimal(18,2),
    Quantity integer,
    Total decimal(18,2)
);

CREATE OR REPLACE FUNCTION Views_Invoices_All_Sales()
RETURNS TABLE (IDInvoice bigint, Total decimal(18,2), State boolean, LimitDate date, Code varchar (30), CurrentDate date, Name varchar (30), FirstName varchar(15), SecondName varchar(15), NameCompany varchar(40), rode decimal (18,2)) AS
$$
BEGIN 
RETURN QUERY
    SELECT DISTINCT ON (i.IDInvoice) i.IDInvoice, i.Total, i.State, i.LimitDate, i.Code,
    d.CurrentDate, p.Name, p.FirstName, p.SecondName, p.NameCompany,
    (SELECT SUM(ass.Rode) FROM AssetsLiabilities ass
    INNER JOIN Invoices inv ON ass.IDInvoice = inv.IDInvoice
    WHERE ass.Type = true AND ass.IDInvoice = i.IDInvoice AND ass.State = true) AS Rode
    FROM Invoices i INNER JOIN Details d ON i.IDDetail = d.IDDetail 
    INNER JOIN Clients c ON i.IDClient = c.IDClient 
    INNER JOIN Persons p ON c.IDPerson = p.IDPerson
    INNER JOIN Sales s ON s.IDDetail = d.IDDetail 
    WHERE d.CurrentDate >= (CURRENT_DATE - INTERVAL '40 day') :: date
    ORDER BY i.IdInvoice DESC;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Views_Invoices_All_Sales_Expired()
RETURNS TABLE (IDInvoice bigint, Total decimal(18,2), State boolean, LimitDate date, Code varchar (30), CurrentDate date, Name varchar (30), FirstName varchar(15), SecondName varchar(15), NameCompany varchar(40), rode decimal (18,2)) AS
$$
BEGIN 
RETURN QUERY
    SELECT DISTINCT ON (i.IDInvoice) i.IDInvoice, i.Total, i.State, i.LimitDate, i.Code,
    d.CurrentDate, p.Name, p.FirstName, p.SecondName, p.NameCompany,
    (SELECT SUM(ass.Rode) FROM AssetsLiabilities ass
    INNER JOIN Invoices inv ON ass.IDInvoice = inv.IDInvoice
    WHERE ass.Type = true AND ass.IDInvoice = i.IDInvoice AND ass.State = true) AS Rode 
    FROM Invoices i INNER JOIN Details d ON i.IDDetail = d.IDDetail 
    INNER JOIN Clients c ON i.IDClient = c.IDClient 
    INNER JOIN Persons p ON c.IDPerson = p.IDPerson
    INNER JOIN Sales s ON s.IDDetail = d.IDDetail     
    WHERE i.LimitDate <= (CURRENT_DATE) :: date AND i.State = true
    AND i.Total - COALESCE ((SELECT SUM(ass.Rode) FROM AssetsLiabilities ass
    INNER JOIN Invoices inv ON ass.IDInvoice = inv.IDInvoice
    WHERE ass.Type = true AND ass.IDInvoice = i.IDInvoice AND ass.State = true),0) > 0
    ORDER BY i.IdInvoice DESC;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Views_Invoices_All_Purchase()
RETURNS TABLE (IDInvoice bigint, Total decimal(18,2), State boolean, LimitDate date, Code varchar (30), CurrentDate date, Name varchar(30), FirstName varchar(15), SecondName varchar(15), NameCompany varchar(40), rode decimal (18,2)) AS
$$
BEGIN
RETURN QUERY
    SELECT DISTINCT ON (i.IDInvoice) i.IDInvoice, i.Total, i.State, i.LimitDate, i.Code,
    d.CurrentDate, p.Name, p.FirstName, p.SecondName, p.NameCompany,
    (SELECT SUM(ass.Rode) FROM AssetsLiabilities ass
    INNER JOIN Invoices inv ON ass.IDInvoice = inv.IDInvoice
    WHERE ass.Type = false AND ass.IDInvoice = i.IDInvoice AND ass.State = true) AS Rode
    FROM Invoices i INNER JOIN Details d ON i.IDDetail = d.IDDetail 
    INNER JOIN Providers pp ON i.IDProvider = pp.IDProvider 
    INNER JOIN Persons p ON pp.IDPerson = p.IDPerson
    INNER JOIN Purchases as pr ON pr.IDDetail = d.IDDetail
    WHERE d.CurrentDate >= (CURRENT_DATE - INTERVAL '40 day') :: date
    ORDER BY i.IdInvoice DESC;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Views_Invoices_All_Purchase_Expired()
RETURNS TABLE (IDInvoice bigint, Total decimal(18,2), State boolean, LimitDate date, Code varchar (30), CurrentDate date, Name varchar(30), FirstName varchar(15), SecondName varchar(15), NameCompany varchar(40), rode decimal (18,2)) AS
$$
BEGIN
RETURN QUERY
    SELECT DISTINCT ON (i.IDInvoice) i.IDInvoice, i.Total, i.State, i.LimitDate, i.Code,
    d.CurrentDate, p.Name, p.FirstName, p.SecondName, p.NameCompany,
    (SELECT SUM(ass.Rode) FROM AssetsLiabilities ass
    INNER JOIN Invoices inv ON ass.IDInvoice = inv.IDInvoice
    WHERE ass.Type = false AND ass.IDInvoice = i.IDInvoice AND ass.State = true) AS Rode
    FROM Invoices i INNER JOIN Details d ON i.IDDetail = d.IDDetail 
    INNER JOIN Providers pp ON i.IDProvider = pp.IDProvider 
    INNER JOIN Persons p ON pp.IDPerson = p.IDPerson
    INNER JOIN Purchases as pr ON pr.IDDetail = d.IDDetail    
    WHERE i.LimitDate <= (CURRENT_DATE) :: date AND i.State = true
    AND i.Total - COALESCE ((SELECT SUM(ass.Rode) FROM AssetsLiabilities ass
    INNER JOIN Invoices inv ON ass.IDInvoice = inv.IDInvoice
    WHERE ass.Type = false AND ass.IDInvoice = i.IDInvoice AND ass.State = true),0) > 0
    ORDER BY i.IdInvoice DESC;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Invoice_Clients(
    _id bigint)
RETURNS SETOF Type_Invoice AS
$$
BEGIN
RETURN QUERY
    SELECT i.*, d.CurrentDate,p.Name, p.FirstName, p.SecondName, p.NameCompany FROM Invoices as i 
    INNER JOIN Details as d ON i.IDDetail = d.IDDetail 
    INNER JOIN Clients as c ON i.IDClient = c.IDClient 
    INNER JOIN Persons as p ON c.IDPerson = p.IDPerson 
    WHERE i.IDInvoice = _id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Invoice_Providers(
    _id bigint)
RETURNS SETOF Type_Invoice AS
$$
BEGIN
RETURN QUERY
    SELECT i.*, d.CurrentDate,p.Name, p.FirstName, p.SecondName, p.NameCompany FROM Invoices as i 
    INNER JOIN Details as d ON i.IDDetail = d.IDDetail 
    INNER JOIN Providers as pr ON i.IDProvider = pr.IDProvider 
    INNER JOIN Persons as p ON pr.IDPerson = p.IDPerson 
    WHERE i.IDInvoice = _id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Views_Invoice_Product_Sale(
    _id bigint)
RETURNS SETOF Type_Details_Products AS
$$
BEGIN
RETURN QUERY
    SELECT p.Code, p.Name, p.Price, p.Tax, s.Quantity, s.Total FROM Sales AS s 
    INNER JOIN products AS p ON s.IDProduct = p.IDProduct
    WHERE s.IDDetail = _id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Views_Invoice_Product_Purcase(
    _id bigint)
RETURNS SETOF Type_Details_Products AS
$$
BEGIN
RETURN QUERY
    SELECT pr.Code, pr.Name, pr.Price, pr.Tax, p.Quantity, p.Total FROM Purchases AS p 
    INNER JOIN products AS pr ON p.IDProduct = pr.IDProduct
    WHERE p.IDDetail = _id;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Invoice_AssetLiability(
    _Id bigint)
RETURNS SETOF Type_AssetLiability AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM AssetsLiabilities WHERE IDInvoice = _Id;
END; 
$$ LANGUAGE 'plpgsql';

--Unicos

CREATE OR REPLACE FUNCTION Check_Nickname(
    _Nickname varchar (15))
RETURNS TABLE (Nickname varchar (15)) AS
$$
BEGIN
RETURN QUERY
    SELECT Users.Nickname FROM Users
    WHERE LOWER(Users.Nickname) = LOWER(_Nickname);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Check_CodePersons(
    _Code varchar (15))
RETURNS TABLE (Code varchar (20)) AS
$$
BEGIN
RETURN QUERY
    SELECT Persons.Code FROM Persons
    WHERE LOWER(Persons.Code) = LOWER(_Code);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Check_CodeProduct(
    _Code varchar (20))
RETURNS TABLE (Code varchar (20)) AS
$$
BEGIN
RETURN QUERY
    SELECT Products.Code FROM Products
    WHERE LOWER(Products.Code) = LOWER(_Code);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Check_NameCategory(
    _Name varchar (50))
RETURNS TABLE (Name varchar (50)) AS
$$
BEGIN
RETURN QUERY
    SELECT Categories.Name FROM Categories
    WHERE LOWER(Categories.Name) = LOWER(_Name);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Check_NameAccount(
    _Name varchar (30))
RETURNS TABLE (Name varchar (30)) AS
$$
BEGIN
RETURN QUERY
    SELECT Accounts.Name FROM Accounts
    WHERE LOWER(Accounts.Name) = LOWER(_Name);
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Check_NameSubCategory(
    _Name varchar (30),
    _IDCategory bigint)
RETURNS TABLE (Name varchar (30)) AS
$$
BEGIN
RETURN QUERY
    SELECT Subcategories.Name FROM Subcategories
    WHERE LOWER(Subcategories.Name) = LOWER(_Name) AND Subcategories.IDCategory = _IDCategory;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Check_Payment(
    _Id bigint,
    _Type boolean)
RETURNS TABLE (IDInvoice bigint, Total decimal(18,2), Rode decimal(18,2)) AS
$$
BEGIN
RETURN QUERY
    SELECT DISTINCT ON (i.IDInvoice) i.IDInvoice, i.Total, 
    (SELECT SUM(ass.Rode) FROM AssetsLiabilities ass
     INNER JOIN Invoices inv ON ass.IDInvoice = inv.IDInvoice
     WHERE ass.Type = _type AND ass.IDInvoice = i.IDInvoice AND ass.State = true) AS Rode
     FROM Invoices i INNER JOIN Details d ON i.IDDetail = d.IDDetail WHERE i.IDInvoice = _Id;
END; 
$$ LANGUAGE 'plpgsql';

--Graficos
CREATE OR REPLACE FUNCTION Sum_Account()
RETURNS TABLE (Name varchar(30), Assets decimal(18,2), Liabilities decimal(18,2)) AS
$$
BEGIN
RETURN QUERY
    SELECT a.Name, SUM(CASE WHEN al.Type = true THEN al.Rode ELSE 0 END) as Assets,
    SUM(CASE WHEN al.Type = false THEN al.Rode ELSE 0 END) as Liabilities FROM Accounts AS a 
    INNER JOIN AssetsLiabilities as al ON a.IDAccount = al.IDAccount WHERE al.State = true
    GROUP BY a.Name;
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Sum_Category()
RETURNS TABLE (Name varchar(30), Sum decimal(18,2)) AS
$$
BEGIN
RETURN QUERY
    SELECT ca.Name, SUM(a.Rode)  FROM SubCategories AS c 
    INNER JOIN AssetsLiabilities as a ON c.IDSubCategory = a.IDSubCategory
    INNER JOIN Categories as ca ON ca.IDCategory = c.IDCategory WHERE a.State = true AND ca.State = true
    group by ca.Name;
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Sum_SubCategory(
    _name varchar(50))
RETURNS TABLE (Name varchar(30), Sum decimal(18,2)) AS
$$
BEGIN
RETURN QUERY
    SELECT c.Name, SUM(a.Rode) FROM SubCategories AS c 
    INNER JOIN AssetsLiabilities as a ON c.IDSubCategory = a.IDSubCategory
    INNER JOIN Categories as ca ON ca.IDCategory = c.IDCategory
    WHERE LOWER(ca.Name) = LOWER(_name) AND a.State = true AND c.State = true
    group by c.Name;
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Sum_AssetLiability_All()
RETURNS TABLE (Assets decimal(18,2), Liabilities decimal(18,2), Years text) AS
$$
BEGIN
RETURN QUERY
    SELECT SUM(CASE WHEN al.Type = true THEN al.Rode ELSE 0 END) as Assets,
    SUM(CASE WHEN al.Type = false THEN al.Rode ELSE 0 END) as Liabilities, 
    DATE_PART('years', al.CurrentDate)::text AS years
    FROM AssetsLiabilities as al WHERE al.State = true
    group by years;
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Sum_AssetLiability_Filter(
    _DateFilter varchar(10),
    _DateSearch varchar(10),
    _Date varchar(10))
RETURNS TABLE (Assets decimal(18,2), Liabilities decimal(18,2), Years text) AS
$$
BEGIN
RETURN QUERY
    SELECT SUM(CASE WHEN al.Type = true THEN al.Rode ELSE 0 END) as Assets,
    SUM(CASE WHEN al.Type = false THEN al.Rode ELSE 0 END) as Liabilities, 
    DATE_PART(_DateFilter, al.CurrentDate)::text AS dates
    FROM AssetsLiabilities as al WHERE DATE_PART(_DateSearch,CURRENT_DATE) = _Date :: double precision AND al.State = true
    group by dates;
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Sum_Products_All()
RETURNS TABLE (Name varchar(20), Date text, Sum bigint) AS
$$
BEGIN
RETURN QUERY
    SELECT p.Name, TO_CHAR(d.CurrentDate, 'YYYY') AS date, SUM(s.Quantity) AS total_sales
    FROM Sales AS s 
    INNER JOIN Products AS p ON s.IDProduct = p.IDProduct
    INNER JOIN Details AS d ON d.IDDetail = s.IDDetail
    WHERE p.State = true
    GROUP BY p.Name, TO_CHAR(d.CurrentDate, 'YYYY');
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Sum_Products_Filter(
    _Date int)
RETURNS TABLE (Name varchar(30), Date text, Sum bigint) AS
$$
BEGIN
RETURN QUERY
    SELECT p.Name, TO_CHAR(d.CurrentDate, 'MM') AS date, SUM(s.Quantity) AS total_sales
    FROM Sales AS s 
    INNER JOIN Products AS p ON s.IDProduct = p.IDProduct
    INNER JOIN Details AS d ON d.IDDetail = s.IDDetail
    WHERE p.State = true AND DATE_PART('years',d.CurrentDate) = _Date
    GROUP BY p.Name, TO_CHAR(d.CurrentDate, 'MM');
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Sum_Clients_All()
RETURNS TABLE (Name text, Sum decimal(18,2), Date text) AS
$$
BEGIN
RETURN QUERY
    SELECT concat(p.FirstName::text,' '::text,  p.Secondname::text,' '::text, p.Name::text) AS FullName,
    Sum(i.Total) AS total_sales, TO_CHAR(d.CurrentDate, 'YYYY') AS date
    FROM Persons AS p INNER JOIN Clients AS c ON p.IDPerson = c.IDPerson
    INNER JOIN Invoices AS i ON c.IDClient = i.IDClient
    INNER JOIN Details AS d ON i.IDDetail = d.IDDetail
    WHERE c.State = true AND p.NameCompany != 'Productos Alimenticios Santa Marta'
    group by FullName, TO_CHAR(d.CurrentDate, 'YYYY');
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Sum_Clients_Filter(
    _Date int)
RETURNS TABLE (Name text, Sum decimal(18,2), Date text) AS
$$
BEGIN
RETURN QUERY
    SELECT concat(p.FirstName::text,' '::text,  p.Secondname::text,' '::text, p.Name::text) AS FullName,
    Sum(i.Total) AS total_sales, TO_CHAR(d.CurrentDate, 'MM') AS date
    FROM Persons AS p INNER JOIN Clients AS c ON p.IDPerson = c.IDPerson
    INNER JOIN Invoices AS i ON c.IDClient = i.IDClient
    INNER JOIN Details AS d ON i.IDDetail = d.IDDetail
    WHERE c.State = true AND DATE_PART('years',d.CurrentDate) = _Date AND p.NameCompany != 'Productos Alimenticios Santa Marta'
    group by FullName, TO_CHAR(d.CurrentDate, 'MM');
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Insert_Email(
    _Email varchar(50),
    _Password varchar(100))
RETURNS VOID AS
$$
BEGIN
    INSERT INTO Emails (Email, Password)
    VALUES (_Email, _Password);
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Update_Email(
    _Email varchar (50),
    _Password varchar(100))
RETURNS VOID AS
$$
BEGIN
    UPDATE Emails
    SET Email = _Email, Password = _Password;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION View_Email()
RETURNS TABLE (Email varchar(50), Password varchar(100)) AS
$$
BEGIN
RETURN QUERY
    SELECT * FROM Emails;
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Check_Account(
    _id bigint)
RETURNS TABLE (State boolean) AS
$$
BEGIN
RETURN QUERY
    SELECT al.State FROM Accounts AS a 
    INNER JOIN AssetsLiabilities AS al ON a.IDAccount = al.IDAccount
    WHERE a.IDAccount = _id AND al.State = true GROUP BY al.State;
END; 
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Check_Category(
    _id bigint)
RETURNS TABLE (State boolean) AS
$$
BEGIN
RETURN QUERY
    SELECT al.State FROM SubCategories AS a 
    INNER JOIN AssetsLiabilities AS al ON a.IDSubCategory = al.IDSubCategory
    INNER JOIN Categories AS c ON c.IDCategory = a.IDCategory
    WHERE c.IDCategory = _id AND al.State = true GROUP BY al.State;
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Check_SubCategory(
    _id bigint)
RETURNS TABLE (State boolean) AS
$$
BEGIN
RETURN QUERY
    SELECT al.State FROM SubCategories AS a 
    INNER JOIN AssetsLiabilities AS al ON a.IDSubCategory = al.IDSubCategory
    WHERE a.IDSubCategory = _id AND al.State = true GROUP BY al.State;
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Get_IdProvider_Own()
RETURNS TABLE (IdProvider bigint) AS
$$
BEGIN
RETURN QUERY
    SELECT p.IdProvider FROM Providers AS p 
    INNER JOIN Persons AS pp ON p.IDPerson = pp.IDPerson 
    WHERE pp.NameCompany = 'Productos Alimenticios Santa Marta';
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Get_IdClient_Own()
RETURNS TABLE (IdProvider bigint) AS
$$
BEGIN
RETURN QUERY
    SELECT c.IdClient FROM Clients AS c 
    INNER JOIN Persons AS pp ON c.IDPerson = pp.IDPerson 
    WHERE pp.NameCompany = 'Productos Alimenticios Santa Marta';
END; 
$$ LANGUAGE 'plpgsql'; 

CREATE OR REPLACE FUNCTION Organization_System()
RETURNS VOID AS
$$
DECLARE _id bigint;
BEGIN
    INSERT INTO Persons (Code, Name, FirstName, SecondName, Phone, CellPhone, Email, Address, NameCompany)
    VALUES ('PnSM', 'Oscar', 'Carrillo', 'Alpizar', '2473-1516', '8343-2217', 'Oscarryllo@hotmail.com', 'Pital, San Carlos, Alajuela', 'Productos Alimenticios Santa Marta')
    
    RETURNING IDPerson INTO _id;
    
    INSERT INTO Clients (IDPerson,State)
    VALUES (_id,true);
        
    INSERT INTO Providers (IDPerson,State)
    VALUES (_id,true);

END;
$$ LANGUAGE 'plpgsql';


