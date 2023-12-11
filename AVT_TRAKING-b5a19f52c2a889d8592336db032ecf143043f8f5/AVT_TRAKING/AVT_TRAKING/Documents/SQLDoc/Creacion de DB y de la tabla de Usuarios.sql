use master
GO

create database VRT_TRAKING
GO

use VRT_TRAKING
GO
--##########################################################################################
--##################  TABLA DE USERS #######################################################
--##########################################################################################

create table users(
	idUsers varchar(36) primary key not null,
	nameUser varchar(20) not null,
	passwordUser varchar(25) not null
)
GO

--##########################################################################################
--##################  TABLA DE USERS #######################################################
--##########################################################################################

create table userAccess (
	idUsers varchar(36) not null,
	access varchar(30) not null
)
GO

ALTER TABLE userAccess WITH CHECK ADD CONSTRAINT pk_idUsers_access_userAccess
PRIMARY KEY(idUsers,access)
GO

ALTER TABLE userAccess WITH CHECK ADD CONSTRAINT fk_idUser_userAccess
FOREIGN KEY (idUsers) REFERENCES users(idUsers)
GO

declare @idAdminUser as varchar (36) = NEWID()
insert into users values (@idAdminUser, 'admin' , 'admin')
insert into userAccess values 
(@idAdminUser,'Backup'),
(@idAdminUser,'Clients'),
(@idAdminUser,'Company'),
(@idAdminUser,'Employees'),
(@idAdminUser,'Est. Projects'),
(@idAdminUser,'Est. Reports'),
(@idAdminUser,'Estimation'),
(@idAdminUser,'Expenses'),
(@idAdminUser,'Material'),
(@idAdminUser,'Material Code'),
(@idAdminUser,'Others'),
(@idAdminUser,'PBI'),
(@idAdminUser,'Projects'),
(@idAdminUser,'Reports'),
(@idAdminUser,'Scaffold Tracking'),
(@idAdminUser,'Setting'),
(@idAdminUser,'Setup'),
(@idAdminUser,'System'),
(@idAdminUser,'Time Enter Sheet'),
(@idAdminUser,'Work Code'),
(@idAdminUser,'Client Projects')


--##########################################################################################
--##################  TABLA DE EXPCODE #####################################################
--##########################################################################################

create table expCode(
	idExpCode int primary key not null,
	name varchar(50)
)
GO

insert into expCode values
(75414, 'Maintenance Insulation T&M'),
(75403, 'Maintenance Supuplies Insulation Matearial Only'),
(75413, 'Maintenance Painting'),
(75415, 'Maintenance ShutDown'),
(75416, 'Maintenance Demisters'),
(75418, 'Maintenance Scandffolding'),
(75419, 'Maintenance Office Janitorial'),
(75421, 'Non-routine Maintenance Suup Approval'),
(75425, 'Maintenance Mecanical Integrity Inspections'),
(75428, 'Maintenance Vessel Code Repair'),
(75507, 'Asbestos Removal'),
(75422, 'Small Upgrades'),
(1, 'Operations (O)'),
(2, 'Maintenanse - T&M (M)'),
(3, 'Shutdown (T)'),
(4, 'Capital (C)'),
(5, 'Maintenance(M)')
GO

--##########################################################################################
--##################  TABLA DE TYPEEMPLOYEE ################################################
--##########################################################################################

create table typeEmployee(
	idTypeEmploye int identity (20000,1) primary key not null,
	name varchar(20)
)
GO

insert into typeEmployee values ('Manager'),('Normal')
GO
--##########################################################################################
--##################  TABLA DE UNITMEASSUREMENTS ###########################################
--##########################################################################################
create table TrackElements(
	id int identity (1,1),
	typeElement varchar(40),
	element varchar(30)
)
GO
insert into TrackElements values
('Force or Reject',''),
('Source',''),
('Order Type','POWO'),
('Location ID','2'),
('Company Code','987'),
('Area',''),
('Group Name',''),
('Agreement','OUTAGE'),
('Level 3 ID',''),
('Level 4 ID',''),
('Hours Total',''),
('Hours Total Activity Code',''),
('Extra Charges $ Activity Code',''),
('Extra',''),
('Extra 1',''),
('Extra 2',''),
('Add Time','N'),
('Pay Type',''),
('R4 (Hrs)','0.00'),
('R5 (Hrs)','0.00'),
('R6 (Hrs)','0.00'),
('GL Account',''),
('ST Adders	',''),
('OT Adders	',''),
('DT Adders	',''),
('R4 Adders	',''),
('R5 Adders	',''),
('R6 Adders','')
--##########################################################################################
--##################  TABLA DE workTMLumpSum ###############################################
--##########################################################################################

create table workTMLumpSum (
	idWorkTmLumoSum int identity (30000,1) primary key not null,
	name varchar(30)
)
GO

insert into workTMLumpSum values('Lump-Sum'),('T&M'),('Unire Rate')
GO

--##########################################################################################
--##################  TABLA DE COSTDISTRIBUTION ############################################
--##########################################################################################

create table costDistribution(
	idCostDistribution bigint primary key not null ,
	name varchar(30)
)
GO

insert into costDistribution values (190100000000000,'First'),(290100000000000,'Secund')
GO

--##########################################################################################
--##################  TABLA DE COSTCODE ####################################################
--##########################################################################################

create table costCode(
	idCostCode bigInt primary key not null ,
	name varchar(30)
)
GO

insert into costCode values (240000000000000,'Fist'),(140000000000000,'Secund')
GO

--##########################################################################################
--##################  TABLA DE ABSENTS #####################################################
--##########################################################################################

create table absents(
	idAbsents varchar(36) primary key not null,
	dateAbsents date,
	hoursPaid float,
	explanation varchar(250),
	idEmployee varchar(36) 
)
GO

--##########################################################################################
--##################  TABLA DE ACTIVITY HOURS ##############################################
--##########################################################################################

create table activityHours(
	idActivityHours varchar(36) primary key not null,
	build float,
	material float,
	travel float,
	weather float,
	alarm float,
	safety float,
	stdBy float,
	other float,
	tag varchar(20),
	idModAux varchar(36),
	idDismantle varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE AREAS #####################################################
--##########################################################################################

create table areas(
	idArea int primary key not null,
	name varchar(30),
	cordinator varchar(50),
	idClient varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE CLASSIFICATION ##############################################
--##########################################################################################

create table classification(
	class varchar(10) primary key not null,
	name varchar(50)
)
GO

--##########################################################################################
--##################  TABLA DE CLIENTES ####################################################
--##########################################################################################

CREATE TABLE [dbo].[clients](
	[idClient] [varchar](36) primary key  NOT NULL,
	[numberClient] [int] NOT NULL,
	[firstName] [varchar](30) NULL,
	[middleName] [varchar](30) NULL,
	[lastName] [varchar](30) NULL,
	[companyName] [varchar](50) NULL,
	[idContact] [varchar](36) NULL,
	[idHomeAddress] [varchar](36) NULL,
	[estatus] [char](1) NULL,
	[photo] [image] NULL,
	[payTerms] [varchar](30) NULL
	)
	GO

--##########################################################################################
--##################  TABLA DE CLIENTES ####################################################
--##########################################################################################

create table clientsEst(
	idClientEst varchar(36) primary key not null,
	numberClient int,
	contactName varchar(30),
	companyName varchar(50),
	plant varchar(50),
	idContact varchar(36),
	idHomeAdress varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE COMPANY #####################################################
--##########################################################################################

create table company(
	idCompany varchar(36) primary key not null ,
	name varchar(30),
	country varchar(58),
	payTerms varchar(30),
	invoiceDescr text,
	idHomeAddress varchar(36),
	idContact varchar(36),
	img image
)
GO

--##########################################################################################
--##################  TABLA DE CONTACT #####################################################
--##########################################################################################

create table contact (
	idContact varchar(36) primary key not null,
	phoneNumber1 varchar(13),
	phoneNumber2 varchar(13),
	email varchar(50)
)
GO
--##########################################################################################
--##################  TABLA DE COST PROJECT EST ############################################
--##########################################################################################

CREATE TABLE [dbo].[costProjectEst](
	projectId varchar(30) NOT NULL,
	weekend date NOT NULL,
	scfCost float ,
	rmvCost float ,
	iiCost float ,
	pntCost float NULL,
)
GO
ALTER TABLE costProjectEst WITH CHECK ADD CONSTRAINT pk_projectId_weekend_costProjectEst
PRIMARY KEY (projectId,weekend)
GO
--##########################################################################################
--##################  TABLA DE DETALLEMATERIAL #############################################
--##########################################################################################

create table detalleMaterial(
	idDM varchar(36) primary key not null,
	resourceMaterial varchar(50),
	unitMesurement varchar(20),
	type varchar(30),
	price float,
	description varchar(100),
	size float,
	idMaterial varchar(36),
	idVendor varchar(36),
	partNum varchar(15)
)
GO

--##########################################################################################
--##################  TABLA DE DISMANTLE ###################################################
--##########################################################################################

create table dismantle(
	idDismantle varchar(36) primary key not null,
	tag varchar(20) not null,
	comments text ,
	reqCompany varchar(30),
	requestBy varchar(50),
	rentStopDate date,
	dismantleDate date,
	foreman varchar(30),
	erector varchar(30)
)
GO
--##########################################################################################
--##################  TABLA DE DRAWING #####################################################
--##########################################################################################

create table drawing(
	idDrawingNum varchar(45) primary key not null,
	[description] varchar(150),
	projectId varchar(30)
)
GO

--##########################################################################################
--##################  TABLA DE EIRHC #######################################################
--##########################################################################################

create table EqIRHC(
	[type]  varchar(25) not null,
	thickness float not null,
	laborProd float, 
	matRate float,
	eqRate float
)
GO

ALTER TABLE EqIRHC ADD CONSTRAINT pk_type_thickness_EqIRHC
PRIMARY KEY ([type],thickness)
GO

--##########################################################################################
--##################  TABLA DE EMPLOYEES ###################################################
--##########################################################################################

create table emails(
	email varchar(70) not null primary key,
	name varchar(50) ,
	status bit
)
GO

--##########################################################################################
--##################  TABLA DE EMPLOYEES ###################################################
--##########################################################################################

create table employees(
	idEmployee varchar(36) primary key not null,
	numberEmploye int not null,
	firstName varchar(30),
	lastName varchar(25),
	middleName varchar(25),
	socialNumber varchar(14),
	SAPNumber int,
	photo image,
	idHomeAdress varchar(36),
	idContact varchar(36),
	estatus char(1),
	typeEmployee varchar(20),
	perdiem bit
)
GO

--##########################################################################################
--##################  TABLA DE ENVIROMENT ##################################################
--##########################################################################################
CREATE TABLE [dbo].[enviroment](
	[idEnviroment] [varchar](40) primary key NOT NULL,
	[dueDays] [int] NULL
) 
GO
--##########################################################################################
--##################  TABLA DE EQUIPMENTEST ################################################
--##########################################################################################

create table equipmentEst(
	idEquimentEst int primary key not null,
	[description] varchar(45)not null,
	elevation int,
	systemPntEq varchar(10),
	pntOption varchar(25),
	[type] varchar(25),
	thick float,
	idJacket varchar(25),
	remIns bit,
	idLaborRateRmv varchar(40),
	sqrFtRmv float,
	idLaborRatePnt varchar(40),
	sqrFtPnt float,
	idLaborRateII varchar(40),
	sqrFtII float,
	bevel float,
	cutout float,
	acm bit,
	idDrawingNum varchar(45) not null
)
GO

--##########################################################################################
--##################  TABLA DE EQUIPMENT MATERIAL ##########################################
--##########################################################################################
CREATE TABLE equipmentMaterial(
	[type] varchar(25) NOT NULL,
	thick float NOT NULL,
	price money ,
	[description] [varchar](50) 
)
GO

ALTER TABLE equipmentMaterial WITH CHECK ADD CONSTRAINT pk_type_thick_EquipmentMaterial
PRIMARY KEY ([type],thick)
GO

--##########################################################################################
--##################  TABLA DE EQUIPMENT PROGRESS ##########################################
--##########################################################################################

create table equipmentProgress(
	tag int not null,
	weekending date not null,
	insRemoval int,
	insInstall int,
	paint int
)
GO

ALTER TABLE equipmentProgress WITH CHECK ADD CONSTRAINT pk_idTag_Weekending_Eq
PRIMARY KEY (tag,weekending)
GO

--##########################################################################################
--##################  TABLA DE EQINSUNITRATE ###############################################
--##########################################################################################

create table eqInsUnitRate(
	[type] varchar(25)not null,
	thick float not null,
	laborProd float,
	matRate float,
	eqRate float
)
GO

ALTER TABLE eqInsUnitRate WITH CHECK ADD CONSTRAINT PK_type_think_eqinsUnitRate
PRIMARY KEY([type],thick)
GO
--##########################################################################################
--##################  TABLA DE EQJKTUNITRATE ###############################################
--##########################################################################################

create table eqJktUnitRate(
	idJacket varchar(25) primary key not null,
	name varchar(60) not null,
	laborProd float,
	matFactor float,
	eqFactor float
)
GO

--##########################################################################################
--##################  TABLA DE EQPAINTUNITRATE #############################################
--##########################################################################################

create table eqPaintUnitRate(
	systemPntEq varchar(10)not null,
	pntOption varchar(25)not null,
	laborProd float,
	matRate float,
	eqRate float
)
GO
ALTER TABLE eqPaintUnitRate WITH CHECK ADD CONSTRAINT PK_systemPntEq_pntOption_eqPaintUnitRate
PRIMARY KEY(systemPntEq,pntOption)
GO

--##########################################################################################
--##################  TABLA DE ESTCOSTBUILD ################################################
--##########################################################################################
create table EstCostBuild(
	tag varchar(20) not null,
	idDrawingNum varchar(45)not null,
	projectId varchar(30) not null,
	M2 float,
	SHR float,
	SBHR float,
	SDHR float,
	SCOSTL float,
	SCOSTLB float,
	SCOSTLD float,
	SCOSTM float,
	SCOSTMB float,
	SCOSTMD float,
	SCOSTE float,
	SCOSTEB float,
	SCOSTED float,
	STCOST float
)
GO

ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT pk_idTag_idDrawingnum_projectId
PRIMARY KEY (tag,idDrawingNum,projectId)
GO
--##########################################################################################
--##################  TABLA DE ESTCOSTDISM #################################################
--##########################################################################################
create table EstCostDism(
	tag varchar(20) not null,
	idDrawingNum varchar(45)not null,
	projectId varchar(30) not null,
	M2 float,
	SHRD float,
	SBHRD float,
	SDHRD float,
	DSCOSTL float,
	DSCOSTM float,
	SCOSTMBD float,
	DSCOSTMD float,
	SCOSTEBD float,
	BSCOSTEB float,
	SCOSTEDD float
)
GO

ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT pk_idTag_idDrawingnum_projectId_Dism
PRIMARY KEY (tag,idDrawingNum,projectId)
GO
--##########################################################################################
--##################  TABLA DE ESTCOSTEQ ###################################################
--##########################################################################################
CREATE TABLE EstCostEq(
	tag varchar(20) not null,
	idDrawingNum varchar(45)not null,
	projectId varchar(30) not null,
--SCF
	IRESQF float,
	ACMH float ,
	EIRHRS float,
	EIRCOSTL float,
	EIRCOSTM float,
	EIRCOSTE float,
	EIRTCOST float,
--INSTALATION INSULATION
	IIESQF float,
	EIIHRS float,
	EIICOSTL float,
	EIICOSTM float,
	EIICOSTE float,
	EIITCOST float,
--PAINT 
	PESQF float,
	EPHRS float,
	EPCOSTL float,
	EPCOSTM float,
	EPCOSTE float,
	EPTCOST float
)
GO

ALTER TABLE EstCostEq ADD CONSTRAINT pk_tag_idDrawingnum_projectId_EstCostEq
PRIMARY KEY (tag,idDrawingNum,projectId)
GO

--##########################################################################################
--##################  TABLA DE ESTCOSTPP ###################################################
--##########################################################################################
create table EstCostPp(
	tag varchar(20) not null,
	idDrawingNum varchar(45)not null,
	projectId varchar(30) not null,
	IRELF float ,
	--ROMOVAL
	ACMH float ,
	PIRHRS float ,
	PIRCOSTL float ,
	PIRCOSTM float ,
	PIRCOSTE float ,
	PIRTCOST float ,
	--INSTALATION INSULATION
	IIELF float ,
	PIIHRS float ,
	PIICOSTL float ,
	PIICOSTM float ,
	PIICOSTE float ,
	PIITCOST float ,
	--PAINT
	PESQF float ,
	PPHRS float ,
	PPCOSTL float ,
	PPCOSTM float ,
	PPCOSTE float ,
	PPTCOST float
)
GO

ALTER TABLE EstCostPp ADD CONSTRAINT pk_tag_idDrawingNum_projecId
PRIMARY KEY (tag,idDrawingNum,projectId)
GO

--##########################################################################################
--##################  TABLA DE ESTCOSTSCF ##################################################
--##########################################################################################
create table EstCostScf(
	tag varchar(20) not null,
	idDrawingNum varchar(45)not null,
	projectId varchar(30) not null,
	M2 float,
	SHRD float,
	SBHRD float,
	DSCOSTL float,
	DSCOSTM float,
	SCOSTMBD float,
	DSCOSTMD float,
	SCOSTEBD float,
	BSCOSTEB float,
	SCOSTEDD float,
	SCM float,
	SHR float,
	SBHR float,
	SDHR float, 
	SCOSTL float,
	SCOSTLB float,
	SCOSTLD float,
	SCOSTM float,
	SCOSTMB float, 
	SCOSTMD float,
	SCOSTE float,
	SCOSTEB float,
	SCOSTED float,
	STCOST float,
	STCOSTB float,
	STCOSTD float
)
GO

ALTER TABLE EstCostScf ADD CONSTRAINT pk_tag_idDrawingNum_projectId
PRIMARY KEY (tag,idDrawingNum,projectId)
GO

--##########################################################################################
--##################  TABLA DE ESTMETERS ###################################################
--##########################################################################################

CREATE TABLE EstMeters(
	idEstMeters varchar(36) NOT NULL primary key,
	EstNumber varchar(36) ,
	PMANHRS float ,
	TLABOR float ,
	LDECKBP float ,
	LABORBP float ,
	LDECKDP float ,
	LABORDP float ,
	DECKMAD float ,
	MADPRIC float ,
	MA2DP float ,
	MA3DP float ,
	DECKDP float ,
	DPRICE float ,
	M2DP float ,
	M2EDP float ,
	M2MDP float ,
	M2LDP float ,
	M3DP float ,
	M3EDP float ,
	M3MDP float ,
	M3LDP float ,
	EDMA2C float ,
	EDMA3C float ,
	EDMA2 float ,
	EDMA3 float ,
	EDM2C float ,
	EDM3C float ,
	EDM2 float ,
	EDM3 float ,
	TIMESED float ,
	DA float ,
	DECKBP float ,
	BPRICE float ,
	M2BP float ,
	M2EBP float ,
	M2MBP float ,
	M2LBP float ,
	M3BP float ,
	M3EBP float ,
	M3MBP float ,
	M3LBP float 
)
GO



--##########################################################################################
--##################  TABLA DE EXISTENCES ##################################################
--##########################################################################################

create table existences(
	idDM varchar(36) primary key not null,
	quantity float
)
GO

--##########################################################################################
--##################  TABLA DE EXPENSES ####################################################
--##########################################################################################

create table expensesJobs (
	idExpenses varchar(36) not null,
	jobNo  bigint not null,
	Category varchar(12),
	PayItemType varchar(30),
	WorkType varchar(30),
	CostCode varchar(30),
	CustomerPositionID varchar(30),
	CustomerJobPositionDescription varchar(30),
	CBSFullNumber varchar(30),
	skillType varchar(100)
 )
go

--##########################################################################################
--##################  TABLA DE EXPENSES ####################################################
--##########################################################################################

create table expenses (
	idExpenses varchar(36) primary key not null,
	expenseCode varchar(36) not null,
	description varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE EXPENSESUSED ################################################
--##########################################################################################

create  table expensesUsed(
	idExpenseUsed  varchar(36) primary key not null,
	dateExpense  date not null,
	amount float not null,
	description varchar(100) null,
	idExpense varchar(36),
	idAux varchar(36),
	idEmployee varchar(36),
	idHorsWorked varchar(36),
	dayInserted Date
)
GO

--##########################################################################################
--##################  TABLA DE FACTOR ELEVATION PAINT ######################################
--##########################################################################################
CREATE TABLE factorElevationPaint(
	elevation int primary key NOT NULL,
	[percent] int
)
GO

--##########################################################################################
--##################  TABLA DE FACTOR ELEVATION SCAFFOLD ##################################
--##########################################################################################
create table factorElevationSCF(
	elevation int primary key not null,
	[percent] int 
)
GO
--##########################################################################################
--##################  TABLA DE HOMEADDRESS #################################################
--##########################################################################################

create table HomeAddress (
	idHomeAdress varchar(36) primary key not null,
	avenue varchar(80),
	number int,
	city varchar(20), 
	providence varchar(20),
	postalCode int
)
GO

--##########################################################################################
--##################  TABLA DE HOURS PROJECTS EST ##########################################
--##########################################################################################

CREATE TABLE [dbo].[hoursProjectEst](
	projectId varchar(30) NOT NULL,
	weekend date NOT NULL,
	scfHrs float NULL,
	rmvHrs float NULL,
	iiHrs float NULL,
	pntHrs float NULL,
)
GO
ALTER TABLE hoursProjectEst WITH CHECK ADD CONSTRAINT pk_projectId_weekend_hoursProjectEst
PRIMARY KEY (projectId,weekend)
go

--##########################################################################################
--##################  TABLA DE HOURSWORKED #################################################
--##########################################################################################

create table hoursWorked (
	idHorsWorked varchar(36) primary key not null,
	hoursST float,
	hoursOT float,
	hours3 float,
	dateWorked date,
	idEmployee varchar(36),
	idWorkCode int,
	idAux varchar(36),
	schedule varchar(10),
	jobNo bigint,
	dayinsert date
)
GO
--##########################################################################################
--##################  TABLA DE IMAGE CLIENT ################################################
--##########################################################################################

create table imageClient(
	name varchar(30) primary key not null,
	img image,
	imgDefault char(1)
)
GO

--##########################################################################################
--##################  TABLA DE INCOMING ####################################################
--##########################################################################################

create table incoming(
	ticketNum varchar(15) primary key not null,
	dateRecived date,
	recivedBy varchar(80),
	comment text,
	jobNo bigint
)
GO

--##########################################################################################
--##################  TABLA DE INSFITTING ##################################################
--##########################################################################################

create table insFitting(
	[type] varchar(25) primary key not null,
	support float,
	p90 float,
	p45 float,
	bend float,
	tee float,
	red float,
	cap float,
	flangePair float,
	flangeVlv float,
	controlVlv float,
	weldedVlv  float,
	bebel float,
	cutOut float
)
GO

--##########################################################################################
--##################  TABLA DE INVOICE #####################################################
--##########################################################################################

create table invoice(
	invoice varchar(20)not null,
	idPO bigint not null,
	idClient varchar(36)not null,
	startDate date,
	FinalDate date,
	invoiceDate date NULL,
	[status] bit NULL
)
GO

alter table invoice add constraint pk_idClient_idPO_invoice
primary key (invoice,idPO)
GO

--##########################################################################################
--##################  TABLA DE JOB #########################################################
--##########################################################################################

create table job (
	jobNo bigint primary key not null,
	workTMLumpSum varchar(40),
	costDistribution varchar(30),
	custumerNo int,
	contractNo int,
	costCode bigInt,
	idClient varchar(36),
	postingProject bigint
)
GO

--##########################################################################################
--##################  TABLA DE JOB CAT #####################################################
--##########################################################################################

create table jobCat(
	idJobCat varchar(25) primary key not null,
	cat varchar(35),
	days int,
	idClient varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE KPI #########################################################
--##########################################################################################

create table KPI(
	idKPI int identity(1,1) primary key not null,
	typeKPI varchar(15), 
	casePaint varchar(35),
	lead bit,
	stResistence bit,
	[description] varchar(150),
	jobNo bigint,
	idAux varchar(36),
	dateWorked date,
	thinck float,
	size float,
	SQF  float,
	LF  float,
	qty90 int,
	qty45 int,
	TEE int,
	RED int,
	CAP int,
	FLG int,
	FIT int,
	VLV int, 
	hoursST float,
	hoursOT float,
	install varchar(20)
)
GO

--##########################################################################################
--##################  TABLA DE LEG #########################################################
--##########################################################################################

create table leg(
	legID varchar(36)primary key not null,
	qty float,
	heigth float,
	tag varchar(20)
)
GO

--##########################################################################################
--##################  TABLA DE LABOR RATE ##################################################
--##########################################################################################
create table laborRate(
	idLaborRate varchar(40) primary key not null,
	insRate money,
	abatRate money,
	paintRate money,
	scafRate money
)
GO
--##########################################################################################
--##################  TABLA DE LIST EMAIL REPORT ###########################################
--##########################################################################################


create table listEmailReport(
	reportName varchar(50) not null ,
	email varchar(70) not null,
	statusSend bit ,
)
GO

ALTER TABLE listEmailReport ADD CONSTRAINT pk_listEmailReport
PRIMARY KEY (reportName , email)
GO

--##########################################################################################
--##################  TABLA DE MATERIAL ####################################################
--##########################################################################################

create table material(
	idMaterial varchar(36) primary key not null,
	number int not null,
	name varchar(50), 
	estatus char (1),
	code varchar(20)
)
GO

--##########################################################################################
--##################  TABLA DE MATERIALCLASS ###############################################
--##########################################################################################

create table materialClass(
	code varchar(20) primary key not null,
	description varchar(50)
)
GO

--##########################################################################################
--##################  TABLA DE MATERIAL HANDELING ##########################################
--##########################################################################################

create table materialHandeling(
	idMaterialHandeling varchar(36) primary key  not null,
	truck char(1),
	forklift char(1),
	trailer char(1),
	crane char(1),
	rope char(1),
	passed char(1),
	elevator char(1),
	tag varchar(20),
	idModAux varchar(36),
	idDismantle varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE MATERIAL ORDER ##############################################
--##########################################################################################

create table materialOrder (
	idOrder varchar (36) primary key not null,
	quantity float,
	price float,
	fecha date,
	idMaterial varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE MATERIAL USED ###############################################
--##########################################################################################

create table materialUsed (
	idMaterialUsed varchar(36) primary Key not null,
	dateMaterial date ,
	quantity float,
	amount float,
	description varchar(200),
	idAux varchar(36),
	idMaterial varchar(36),
	hoursST float,
)
GO

--##########################################################################################
--##################  TABLA DE MATERIAL PAYRATE ############################################
--##########################################################################################

create table payRate(
	idPayRate varchar(36) primary key not null ,
	payRate1 float,
	payRate2 float, 
	payRate3 float,
	idEmployee varchar(36),
	datePayRate dateTime
)
GO

--##########################################################################################
--##################  TABLA DE MATERIAL MATERIAL STATUS ####################################
--##########################################################################################

create table materialStatus(
	idMaterialStatus varchar(20) primary key not null
)
GO

--##########################################################################################
--##################  TABLA DE MATERIAL VENDOR #############################################
--##########################################################################################

create table vendor (
	idVendor varchar (36) primary key not null,
	numberVendor int not null,
	name varchar (50),
	descriptions varchar(80),
	estatus char(1)
)
GO

--##########################################################################################
--##################  TABLA DE MODIFICATION SCAFFOLD #######################################
--##########################################################################################

create table modification(
	idModAux varchar(36) primary key not null,
	idModification varchar(20),
	reqCompany varchar(50),
	requestBy varchar(50),
	modificationDate date,
	foreman varchar(30),
	erector varchar(30),
	comments text,
	tag varchar(20),
	status char(1)
)
GO

--##########################################################################################
--##################  TABLA DE OUTGOING ####################################################
--##########################################################################################

create table outGOing(
	ticketNum varchar(15) primary key not null,
	dateShipped date,
	comment text,
	shippedby varchar(80),
	superintendent varchar(80),
	jobNo bigint
)
GO

--##########################################################################################
--##################  TABLA DE OUTGOING ####################################################
--##########################################################################################

create table ownEmail(
	email varchar(70) primary key NOT NULL,
	pass varchar(50) NULL
)
GO

--##########################################################################################
--##################  TABLA DE PIPINGEST ###################################################
--##########################################################################################

create table pipingEst(
	idPipingEst int primary key not null,
	line varchar(20)not null,
	size float,
	[type]varchar(25),
	thick float,
	systemPntPP varchar(10),
	pntOption varchar(25),
	idJacket varchar(25),
	elevation int,
	idLaborRateRmv varchar(40),
	lFtRmv float,
	idLaborRatePnt varchar(40),
	lFtPnt float,
	p90Pnt int,
	p45Pnt int,
	pTeePnt int,
	pPairPnt int,
	pVlvPnt int,
	pControlPnt int,
	pWeldPnt int,
	idLaborRateII varchar(40),
	lFtII float,
	p90II int,
	p45II int,
	pBendII int,
	pTeeII int,
	pReducII int,
	pCapsII int,
	pPairII int,
	pVlvII int,
	pControlII int,
	pWeldII int,
	pCutOutII int,
	psupportII int,
	acm bit,
	st bit,
	idDrawingNum varchar(45)
)
GO

--##########################################################################################
--##################  TABLA DE PIPINGMATERIAL ##############################################
--##########################################################################################

create table pipingMaterial(
	size float not null,
	[type] varchar(25)not null,
	thick float not null, 
	price money,
	[description] varchar(50)
)
GO

--##########################################################################################
--##################  TABLA DE PIPING PROGRESS #############################################
--##########################################################################################
create table pipingProgress(
	tag int not null,
	weekending date not null,
	insRemoval int,
	insInstall int,
	paint int
)
GO

ALTER TABLE pipingProgress WITH CHECK ADD CONSTRAINT pk_Tag_Weekending_Pp
PRIMARY KEY (tag,weekending)
GO

--##########################################################################################
--##################  TABLA DE PNTFITTING ##################################################
--##########################################################################################

create table pntFitting(
	pntOption varchar(25) primary key not null,
	p90 float,
	p45 float,
	tee float,
	flangePair float,
	flangeVlv float,
	controlVlv float,
	weldedVlv float
)
GO

--##########################################################################################
--##################  TABLA DE PP FITTING MATERIAL #########################################
--##########################################################################################

CREATE TABLE ppFittingMaterial(
	size float NOT NULL,
	[type] varchar(25) NOT NULL,
	thick float NOT NULL,
	fitting varchar(25) NOT NULL,
	price money NULL,
	description varchar(50) NULL,
)
GO

ALTER TABLE ppFittingMaterial ADD CONSTRAINT pk_size_type_thick_fitting_ppFittingMaterial
PRIMARY KEY (size ,[type],thick,fitting)
GO

--##########################################################################################
--##################  TABLA DE PPINSUNITRATE ###############################################
--##########################################################################################

create table ppInsUnitRate(
	size float not null, 
	[type] varchar(25) not null,
	thick float not null,
	laborProd float,
	matRate float,
	eqRate float
)
GO

ALTER TABLE ppInsUnitRate ADD CONSTRAINT PK_size_type_thick_PPInsUnitRate 
PRIMARY KEY (size,[type] ,thick)
GO
--##########################################################################################
--##################  TABLA DE PPIRHC ######################################################
--##########################################################################################

create table PpIRHC(
	size float not null,
	[type] varchar(25) not null,
	thickness float not null,
	laborProd float,
	matRate float,
	eqRate float
)
GO

ALTER TABLE PpIRHC ADD CONSTRAINT pk_size_type_thickness_PpIRHC
PRIMARY KEY (size,[type],thickness)
GO

--##########################################################################################
--##################  TABLA DE PPJKTUNITRATE ###############################################
--##########################################################################################

create table ppJktUnitRate(
	idJacket varchar(25) primary key not null,
	name varchar(60) not null,
	laborProd float,
	matFactor float,
	eqFactor float 
)
GO

--##########################################################################################
--##################  TABLA DE PNTFITTING ##################################################
--##########################################################################################

create table ppPaintUnitRate(
	systemPntPP varchar(10)not null,
	pntOption varchar(25)not null,
	size float not null,
	laborProd float,
	matRate float,
	eqRate float
)
GO

--##########################################################################################
--##################  TABLA DE PRODUCT #####################################################
--##########################################################################################

create table product(
	idProduct int primary key not null,
	name varchar(60),
	weight float,
	weightMeasure float,
	price float,
	dailyRentalRate float,
	weeklyRentalRate float,
	monthlyRentalRate float,
	QID varchar(20),
	um varchar(10),
	class varchar(10),
	quantity float,
	PLF float,
	PSQF float
)
GO

--##########################################################################################
--##################  TABLA DE PRODUCT COMING ##############################################
--##########################################################################################

create table productComing(
	idProductInComing varchar(36) primary key not null,
	ticketNum varchar(15),
	idProduct int,
	quantity float
)
GO

--##########################################################################################
--##################  TABLA DE PRODUCT DISMANTLE ###########################################
--##########################################################################################

create table productDismantle(
	idPDS varchar(36) primary key,
	quantity float,
	idProduct int,
	tag varchar(20),
	idDismantle varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE PRODUCT MODIFICATION ########################################
--##########################################################################################
CREATE TABLE [dbo].[productJob](
	[idProduct] [int] NOT NULL,
	[jobNo] [bigint] NOT NULL,
	[qty] [float] NULL
)
GO

ALTER TABLE productJob WITH CHECK ADD CONSTRAINT pk_idProduct_jobNo
PRIMARY KEY(idProduct,jobNo)
GO
--##########################################################################################
--##################  TABLA DE PRODUCT MODIFICATION ########################################
--##########################################################################################

create table productModification(
	idProductModification varchar(36) primary key not null,
	idModAux varchar(36),
	idProduct int,
	quantity float,
	tag varchar(20)
)
GO

--##########################################################################################
--##################  TABLA DE PRODUCT OUTGOING ############################################
--##########################################################################################

create table productOutGOing(
	idProductOutGOing varchar(36) primary key not null,
	ticketNum varchar(15),
	idProduct int,
	quantity float
)
GO

--##########################################################################################
--##################  TABLA DE PRODUCT TOTAL SCAFFOLD ######################################
--##########################################################################################

create table productTotalScaffold(
	idPTS varchar(36) primary key not null,
	quantity float,
	idProduct int,
	tag varchar(20),
	status char(1)
)
GO
--##########################################################################################
--##################  TABLA DE PROYECT CLIENTS EST #########################################
--##########################################################################################

create table projectClientEst(
	projectId varchar(30) primary key not null,
	[description] varchar(150),
	unit varchar(50),
	releaseDate date,
	idClientEst varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE PROYECT ORDER ###############################################
--##########################################################################################

create table projectOrder(
	idPO bigint not null ,
	jobNo bigint not null ,
	Line varchar (10),
	WBS varchar(10)
)
GO
ALTER TABLE projectOrder
ADD CONSTRAINT pk_idPOjobNum PRIMARY KEY (idPO,jobNo)
GO

--##########################################################################################
--##################  TABLA DE PROYECT PRODUCT SCAFFOLD ####################################
--##########################################################################################

create table productScaffold(
	idProductScafold varchar(36) primary key not null,
	tag varchar(20),
	idProduct int,
	quantity float
)
GO

--##########################################################################################
--##################  TABLA DE IMAGE REELS #################################################
--##########################################################################################

create table imgReels(
	idImgReel integer identity (1,1) not null primary key,
	imgIndex  integer ,
	name varchar(100),
	img image
)
GO

--##########################################################################################
--##################  TABLA DE RENTAL ######################################################
--##########################################################################################

create table rental(
	type varchar(15)primary key not null,
	leg money,
	plk float,
	deck money,
	ladder money,
	truckLoad float,
	truck money
)
GO

--##########################################################################################
--##################  TABLA DE REPORT EMAIL ################################################
--##########################################################################################

create table ReportEmail(
	reportName varchar(50) not null primary key,
	subject text ,
	body text 
)
GO


--##########################################################################################
--##################  TABLA DE RFI DIFF EQUIPMENT ##########################################
--##########################################################################################
create table RFIDiffEq(
	idRFIEq varchar(35) not null,
	tag int not null,
	idDrawingNum varchar(45) not null,
	oIRESQF float,
	oEIRHRS float,
	oEIRCOSTL float,
	oEIRCOSTM float,
	oEIRCOSTE float,
	oEIRTCOST float,	
	oIIESQF float,
	oEIIHRS float,
	oEIICOSTL float,
	oEIICOSTM float,
	oEIICOSTE float,
	oEIITCOST float,	
	oEPHRS float,
	oEPCOSTL float,
	oEPCOSTM  float,
	oEPCOSTE  float,
	oEPTCOST  float,	
	nIRESQF float,
	nEIRHRS float,
	nEIRCOSTL float,
	nEIRCOSTM float,
	nEIRCOSTE float,
	nEIRTCOST float,	
	nIIESQF float,
	nEIIHRS float, 
	nEIICOSTL float,
	nEIICOSTM float,
	nEIICOSTE float,
	nEIITCOST float,	
	nEPHRS float,
	nEPCOSTL float,
	nEPCOSTM float,
	nEPCOSTE float,
	nEPTCOST float
)
GO

ALTER TABLE RFIDiffEq WITH CHECK ADD CONSTRAINT pk_idRFIEq_tag_idDrawingNum
PRIMARY KEY(idRFIEq,tag,idDrawingNum)
GO

--##########################################################################################
--##################  TABLA DE RFI DIFF SCF ################################################
--##########################################################################################
create table RFIDiffPp(
	idRFIPp varchar(35) not null,
	tag int not null,
	idDrawingNum varchar(45) not null,
	--REMOVE OLD
	 oPIRHRS  float,  
	 oPIRCOSTL  float, 
	 oPIRCOSTM  float, 
	 oPIRCOSTE  float, 
	 oPIRTCOST  float,  
	--INSULATION OLD
	 oIIELF  float,
	 oPIIHRS  float, 
	 oPIICOSTL  float, 
	 oPIICOSTM  float, 
	 oPIICOSTE  float, 
	 oPIITCOST  float, 
	--PAINT OLD
	 oPESQF  float, 
	 oPPHRS  float,  
	 oPPCOSTL  float, 
	 oPPCOSTM  float, 
	 oPPCOSTE  float, 
	 oPPTCOST  float, 
	--REMOVE NEW 
	 nPIRHRS  float, 
	 nPIRCOSTL  float, 
	 nPIRCOSTM  float, 
	 nPIRCOSTE  float, 
	 nPIRTCOST  float, 
	--INSTALATION NEW
	 nIIELF  float, 
	 nPIIHRS  float, 
	 nPIICOSTL  float, 
	 nPIICOSTM  float, 
	 nPIICOSTE  float, 
	 nPIITCOST  float, 
	--PAINT NEW 
	 nPESQF  float, 
	 nPPHRS  float, 
	 nPPCOSTL  float,
	 nPPCOSTM  float,  
	 nPPCOSTE  float, 
	 nPPTCOST  float
)
GO
ALTER TABLE RFIDiffPp WITH CHECK ADD CONSTRAINT fk_idRFIPp_tag_idDrawingNum
PRIMARY KEY (idRFIPp,tag,idDrawingNum) 
GO
--##########################################################################################
--##################  TABLA DE RFI DIFF SCF ################################################
--##########################################################################################
create table RFIDiffScf(
	idRFI varchar(35) not null,
	tag varchar(20) not null,
	idDrawingNum varchar(45) not null,
	oSCM float,
	oSHR float,
	oSBHR float,
	oSDHR float,
	oSBCOSTL float,
	oSDCOSTL float,
	oSCOSTL float,
	oSBCOSTM float,
	oSDCOSTM float,
	oSCOSTM float,
	oSBCOSTE float,
	oSDCOSTE float,
	oSCOSTE float,
	oSBTCOST float,
	oSDTCOST float,
	oSTCOST float,
	nSCM float,
	nSHR float,
	nSBHR float,
	nSDHR float,
	nSBCOSTL float,
	nSDCOSTL float,
	nSCOSTL float,
	nSBCOSTM float,
	nSDCOSTM float,
	nSCOSTM float,
	nSBCOSTE float,
	nSDCOSTE float,
	nSCOSTE float,
	nSBTCOST float,
	nSDTCOST float,
	nSTCOST float
)
GO

ALTER TABLE RFIDiffScf WITH CHECK ADD CONSTRAINT pk_idRFI_tag_idDrawingNum
PRIMARY KEY(idRFI,tag,idDrawingNum)
GO
--##########################################################################################
--##################  TABLA DE RFI EQUIPMENT ###############################################
--##########################################################################################
create table RFIEquipment(
	idRFIEq varchar(35)not null,
	tag int not null,
	idDrawingNum varchar(45) not null,
	newElevation int,
	newWwPaint varchar(40), 
	newSystem varchar(10), 
	newOption varchar(25), 
	newSqrFtPnt float, 
	newWwRemove varchar(40), 
	newRemove bit, 
	newSqrFtRmv float, 
	newWwInstall varchar(40), 
	newType varchar(25), 
	newThick float, 
	newJacket varchar(25), 
	newSqrFtII float, 
	newBevel float, 
	newCutOut float,
	oldElevation int,
	oldWwPaint varchar(40), 
	oldSystem varchar(10), 
	oldOption varchar(25), 
	oldSqrFtPnt float, 
	oldWwRemove varchar(40), 
	oldRemove bit, 
	oldSqrFtRmv float, 
	oldWwInstall varchar(40), 
	oldType varchar(25), 
	oldThick float, 
	oldJacket varchar(25), 
	oldSqrFtII float, 
	oldBevel float, 
	oldCutOut float,
	reqEmployee varchar(80),
	reqTitleEmployee varchar(40),
	reqDate date,
	reqCompany varchar(50),
	chUpEmployee varchar(80),
	chUpTitleEmployee varchar(40),
	chUpDate date,
	basicFCR int, 
	weDate date,
	note text	
)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT pk_idRFIEq_tag
PRIMARY KEY (idRFIEq,tag)
GO
--##########################################################################################
--##################  TABLA DE RFI PIPING ##################################################
--##########################################################################################
create table RFIPiping (
	idRFIPp varchar(35) not null,
	tag int not null,
	idDrawingNum varchar(45) not null,
	oldSize float, --
	oldElevation int, --
	oldSystem varchar(10),-- 
	oldOption varchar(25), --
	oldType varchar(25), --
	oldThick float, --
	oldIdJacket varchar(25), --
    oldIdLaborRatePnt varchar(40), 
	oldLFtPnt float, 
	oldP90Pnt int, 
	oldP45Pnt int, 
	oldPTeePnt int, 
	oldPPairPnt int, 
	oldPVlvPnt int, 
	oldPControlPnt int,
	oldPWeldPnt int,
    oldIdLaborRateRmv varchar(40), 
	oldLFtRmv float, 
    oldIdLaborRateII varchar(40), 
	oldLFtII float,
	oldP90II int, 
	oldP45II int, 
	oldPBendII int, 
	oldPTeeII int, 
	oldPReducII int, 
	oldPCapsII int, 
	oldPPairII int, 
	oldPVlvII int, 
	oldPControlII int, 
	oldPWeldII int, 
	oldPCutOutII int, 
	oldPsupportII int, 
	newSize float, 
	newElevation int, 
	newSystem varchar(10), 
	newOption varchar(25), 
	newType varchar(25), 
	newThick float, 
	newIdJacket varchar(25),
    newIdLaborRatePnt varchar(40), 
	newLFtPnt float, 
	newP90Pnt int, 
	newP45Pnt int, 
	newPTeePnt int, 
	newPPairPnt int, 
	newPVlvPnt int,
	newPControlPnt int, 
	newPWeldPnt int,
	newIdLaborRateRmv varchar(40), 
	newLFtRmv float, 
    newIdLaborRateII varchar(40), 
	newLFtII float,
	newP90II int, 
	newP45II int, 
	newPBendII int, 
	newPTeeII int, 
	newPReducII int, 
	newPCapsII int, 
	newPPairII int, 
	newPVlvII int, 
	newPControlII int, 
	newPWeldII int, 
	newPCutOutII int, 
	newPsupportII int,
	reqEmployee varchar(80),
	reqTitleEmployee varchar(40),
	reqDate date,
	reqCompany varchar(50),
	chUpEmployee varchar(80),
	chUpTitleEmployee varchar(40),
	chUpDate date,
	basicFCR int, 
	weDate date,
	note text
)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT pk_idRFIPp_idTagPp_idDrawingNum
PRIMARY KEY (idRFIPp,tag,idDrawingNum)
GO
--##########################################################################################
--##################  TABLA DE RFI SCAFFOLD ################################################
--##########################################################################################
create table RFIScaffoldEst(
	idRFI varchar(35) not null,
	tag varchar(20) not null,
	idDrawingNum varchar(45) not null,
	[newDays] int,
	[newWith] float,
	[newLength] float ,
	[newHeigth] float,
	newBuild int,
	newDecks int,
	newIdLaborRate varchar(40),
	newIdSCFUR varchar(35),
	[lastDays] int,
	[lastWith] float,
	[lastLength] float ,
	[lastHeigth] float,
	lastBuild int,
	lastDecks int,
	lastIdLaborRate varchar(40),
	lastIdSCFUR varchar(35),
	reqEmployee varchar(80),
	reqTitleEmployee varchar(40),
	reqDate date,
	reqCompany varchar(50),
	chUpEmployee varchar(80),
	chUpTitleEmployee varchar(40),
	chUpDate date,
	basicFCR int, 
	weDate date,
	note text	
)
GO
ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT pk_idRFI_Tag
PRIMARY KEY (idRFI,Tag)
GO
--##########################################################################################
--##################  TABLA DE SCAFESTCOST #################################################
--##########################################################################################

CREATE TABLE ScafEstCost(
	idEstCost int IDENTITY(1,1) NOT NULL primary key,
	SCEC varchar(15) NULL,
	M3EDCHARGES money NULL,
	M2EDCHARGES money NULL,
	MA3EDCHARGES money NULL,
	MA2EDCHARGES money NULL,
	M3LABORBP money NULL,
	M3MATBP money NULL,
	M3EQBP money NULL,
	M3LABORDP money NULL,
	M3MATDP money NULL,
	M3EQDP money NULL,
	M2LABORBP money NULL,
	M2MATBP money NULL,
	M2EQBP money NULL,
	M2LABORDP money NULL,
	M2MATDP money NULL,
	M2EQDP money NULL,
	MA3LABORBP money NULL,
	MA3MATBP money NULL,
	MA3EQBP money NULL,
	MA3LABORDP money NULL,
	MA3MATDP money NULL,
	MA3EQDP money NULL,
	MA2LABORBP money NULL,
	MA2MATBP money NULL,
	MA2EQBP money NULL,
	MA2LABORDP money NULL,
	MA2MATDP money NULL,
	MA2EQDP money NULL,
	BillingDays int NULL,
	EDDAYS money NULL
)
GO
--##########################################################################################
--##################  TABLA DE SCAFFOLDEST #################################################
--##########################################################################################

create table scaffoldEst(
	tag varchar(20) primary key not null,
	location varchar(150),
	[days] int,
	width float,
	[length] float,
	heigth float,
	decks int,
	build int,
	idLaborRate varchar(40) not null,
	idSCFUR varchar(35) not null,
	idEnviroment varchar(40) not null,
	idDrawingNum varchar(45) not null
)
GO

--##########################################################################################
--##################  TABLA DE SCAFFOLD INFORMATION ########################################
--##########################################################################################

create table scaffoldInformation(
	idScaffoldInformation varchar(36) primary key not null,
	type varchar(15),
	width float,
	length float,
	heigth float,
	descks float,
	ko float,
	base float,
	extraDeck float,
	tag varchar(20),
	idModAux varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE SCAFFOLD PROGRESS ###########################################
--##########################################################################################

create table ScaffoldProgress(
	tag varchar(20) not null,
	weekending date not null,
	buildPercent int,
	demoPercent int
)
GO

ALTER TABLE ScaffoldProgress WITH CHECK ADD CONSTRAINT pk_idTag_Weekending
PRIMARY KEY (tag,weekending)
GO

--##########################################################################################
--##################  TABLA DE SCAFFOLD TRAKING ############################################
--##########################################################################################

create table scaffoldTraking(
	tag varchar(20) primary key not null,
	buildDate date,
	location text,
	purpose text,
	comments text,
	reqComp date,
	contact varchar(30),
	foreman varchar(30),
	erector varchar(30),
	idAux varchar(36),
	idJobCat varchar(25),
	idArea int,
	idSubJob int,
	status char(1),
	days int,
	longitude float,
	latitude float
)
GO

--##########################################################################################
--##################  TABLA DE SCFACTOR ####################################################
--##########################################################################################

create table scfFactor(
	tpid int not null,
	heigth float not null,
	hFactor float not null,
	constraint id primary key (tpid,heigth)
)
GO

declare @i int
set @i = 0
while @i<301
begin 
	insert into scfFactor values(@i,@i,iif(@i>30,20,0.0))
	set @i = @i+1
end

--##########################################################################################
--##################  TABLA DE SCFiNFO #####################################################
--##########################################################################################

create table scfInfo(
	idScfInfo varchar(36) primary key not null,
	csap char(1),
	rolling char(1),
	internal char(1),
	hanging char(1),
	tag varchar(20)
)
GO

--##########################################################################################
--##################  TABLA DE SCFESTIMATION ###############################################
--##########################################################################################

CREATE TABLE scfEstimation(
	EstNumber varchar(36) NOT NULL primary key,
	idAux varchar(36) NULL,
	daysActive float NULL,
	unit varchar(30) NULL,
	location text NULL,
	width float NULL,
	heigth float NULL,
	length float NULL,
	descks int NULL,
	groundHeigth int NULL,
	elevation int NULL,
	M3 float NULL,
	M2 float NULL,
	MA3 float NULL,
	MA2 float NULL,
	ACHT float NULL,
	idEstCost int NULL,
	scfTypeId int NULL,
	ccnum varchar(30) NULL,
	idClient varchar(36) NULL
)
GO

--##########################################################################################
--##################  TABLA DE SCFESTPROYECT #################################################
--##########################################################################################


CREATE TABLE scfEstProyect(
	ccnum varchar(30) NOT NULL primary key,
	unit varchar(30) NOT NULL
)
GO

--##########################################################################################
--##################  TABLA DE SCFTYPECOST #################################################
--##########################################################################################

CREATE TABLE scfTypeCost(
	scfTypeId int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	SCTP varchar(20) NULL,
	M3LBI money NULL,
	M3MBI money NULL,
	M3EBI money NULL,
	M3LDI money NULL,
	M3MDI money NULL,
	M3EDI money NULL,
	M2LBI money NULL,
	M2MBI money NULL,
	M2EBI money NULL,
	M2LDI money NULL,
	M2MDI money NULL,
	M2EDI money NULL,
	MA3LBI money NULL,
	MA3MBI money NULL,
	MA3EBI money NULL,
	MA3LDI money NULL,
	MA3MDI money NULL,
	MA3EDI money NULL,
	MA2LBI money NULL,
	MA2MBI money NULL,
	MA2EBI money NULL,
	MA2LDI money NULL,
	MA2MDI money NULL,
	MA2EDI money NULL,
	SCSN float NULL,
	BDRATE float NULL
)
GO

--##########################################################################################
--##################  TABLA DE SUBJOBS #####################################################
--##########################################################################################

create table subJobs(
	idSubJob int primary key not null,
	description varchar(30),
	idClient varchar(36)
)
GO

--##########################################################################################
--##################  TABLA DE SCFUNITRATE #################################################
--##########################################################################################
CREATE TABLE scfUnitsRates(
	[idSCFUR] [varchar](35) primary key NOT NULL,
	[buildPercent] [int] NULL,
	[laborB] [float] NULL,
	[materialB] [float] NULL,
	[equipmentB] [float] NULL,
	[dismantlePercent] [int] NULL,
	[laborD] [float] NULL,
	[materialD] [float] NULL,
	[equipmentD] [float] NULL,
) 
GO
--##########################################################################################
--##################  TABLA DE TASK ########################################################
--##########################################################################################

create table task (
	idAux varchar(36) primary key not null,
	task varchar(7),
	idAuxWO varchar(36),
	totalSpend float,
	equipament varchar(30),
	manager varchar(50),
	description varchar(100),
	estTotalBilling float,
	beginDate date,
	endDate date,
	expCode varchar(20),
	accountNum varchar(12) ,
	estimateHours float,
	status char(1),
	percentComplete int
)
GO

--##########################################################################################
--##################  TABLA DE TAXESPT #####################################################
--##########################################################################################

create TABLE taxesPT(
	idTaxesPT varchar(36) NOT NULL PRIMARY KEY,
	FICA float ,
	FUI float ,
	SUI float ,
	WC float ,
	GenLiab float ,
	Umbr float ,
	Pollution float ,
	Healt float ,
	Fringe float ,
	Small float ,
	PPE float ,
	Consumable float ,
	Scaffold float ,
	Yoyo float ,
	Mesh float ,
	Miselaneos float ,
	Overhead float ,
	Profit float ,
	BWForeman money ,
	BWJourneyman money ,
	BWCraftsman money ,
	BWApprentice money ,
	BWHelper money ,
	QtyForeman int ,
	QtyJourneyman int ,
	QtyCraftsman int ,
	QtyApprentice int ,
	QtyHelper int ,
	jobNo bigint 
)
GO

--##########################################################################################
--##################  TABLA DE TAXESST #####################################################
--##########################################################################################

create table taxesST(
	idTaxesST varchar(36) NOT NULL PRIMARY KEY,
	FICA float ,
	FUI float ,
	SUI float ,
	WC float ,
	GenLiab float ,
	Umbr float ,
	Pollution float ,
	Healt float ,
	Fringe float ,
	Small float ,
	PPE float ,
	Consumable float ,
	Scaffold float ,
	YoYo float ,
	Mesh float ,
	Miselaneos float ,
	Overhead float ,
	Profit float ,
	BWForeman money ,
	BWJourneyman money ,
	BWCraftsman money ,
	BWApprentice money ,
	BWHelper money ,
	QtyForeman int ,
	QtyJourneyman int ,
	QtyCraftsman int ,
	QtyApprentice int ,
	QtyHelper int ,
	jobNo bigint 
)
GO

--##########################################################################################
--##################  TABLA DE TEMPINVOICE #################################################
--##########################################################################################

create table tempInvoice(
	invoice varchar(20)not null,
	idPO bigint not null,
	idClient varchar(36)not null,
	startDate date,
	FinalDate date
)
GO

alter table tempInvoice add constraint pk_invoice_TempInvoice
primary key (invoice, idPO)
GO

--##########################################################################################
--##################  TABLA DE TRACKDEFAULTELEMENTS ########################################
--##########################################################################################
create table TrackDefaultElements(
idTDe varchar(36) primary key not null,
idClient varchar(36),
[Force or Reject] varchar(15),	
[Source] varchar(15),
[Order Type] varchar(15),
[Location ID] varchar(15),
[Company Code] varchar(15),
[Area] varchar(15),
[Group Name] varchar(15),
[Agreement] varchar(15),
[Level 3 ID] varchar(15),
[Level 4 ID] varchar(15),
[Hours Total] varchar(15),
[Hours Total Activity Code] varchar(15),
[Extra Charges $ Activity Code] varchar(15),
[Extra] varchar(15),
[Extra 1] varchar(15),
[Extra 2] varchar(15),
[Add Time] varchar(15),
[Pay Type] varchar(15),
[R4 (Hrs)] varchar(15),
[R5 (Hrs)] varchar(15),
[R6 (Hrs)] varchar(15),
[GL Account] varchar(15),
[ST Adders] varchar(15),
[OT Adders] varchar(15),
[DT Adders] varchar(15),
[R4 Adders] varchar(15),
[R5 Adders] varchar(15),
[R6 Adders] varchar(15),
[Level 2 ID] varchar(15)
)
GO
--##########################################################################################
--##################  TABLA DE TRACKFORMATELEMENTS #########################################
--##########################################################################################
create table TrackFormatColums(
	idTFE varchar(36) primary key not null,
	idClient varchar(36),
	[Record ID]varchar(51),
	[Force or Reject]varchar(51),
	[Source]varchar(51),
	[Date]varchar(51),
	[Order Type]varchar(51),
	[Location ID]varchar(51),
	[Company Code]varchar(51),
	[Resource ID]varchar(51),
	[Resource Name]varchar(51),
	[Area]varchar(51),
	[Group Name]varchar(51),
	[Agreement]varchar(51),
	[Skill Type]varchar(51),
	[Shift]varchar(51),
	[Level 1 ID]varchar(51),
	[Level 2 ID]varchar(51),
	[Level 3 ID]varchar(51),
	[Level 4 ID]varchar(51),
	[Hours Total]varchar(51),
	[Hours Total Activity Code]varchar(51),
	[S/T (Hrs)]varchar(51),
	[S/T Hrs Activity Code]varchar(51),
	[O/T (Hrs)]varchar(51),
	[O/T Hrs Activity Code]varchar(51),
	[D/T (Hrs)]varchar(51),
	[D/T Hrs Activity Code]varchar(51),
	[Extra Charges $]varchar(51),
	[Extra Charges $ Activity Code]varchar(51),
	[Extra]varchar(51),
	[Extra 1]varchar(51),
	[Extra 2]varchar(51),
	[Add Time]varchar(51),
	[Pay Type]varchar(51),
	[R4 (Hrs)]varchar(51),
	[R5 (Hrs)]varchar(51),
	[R6 (Hrs)]varchar(51),
	[GL Account]varchar(51),
	[ST Adders]varchar(51),
	[OT Adders]varchar(51),
	[DT Adders]varchar(51),
	[R4 Adders]varchar(51),
	[R5 Adders]varchar(51),
	[R6 Adders]varchar(51)
)
GO
--##########################################################################################
--##################  TABLA DE UNITMEASSUREMENTS ###########################################
--##########################################################################################

create table unitMeassurements(
	um varchar(10) primary key not null,
	name varchar(40) 
)
GO

--##########################################################################################
--##################  TABLA DE WORKCODE ####################################################
--##########################################################################################

create table weeks(
	dateWeek date primary key not null,
	weekN int
)
GO

--##########################################################################################
--##################  TABLA DE WORKCODE ####################################################
--##########################################################################################

create table workCode (
	idWorkCode int not null,
	jobNo bigint not null,
	name varchar(30),
	[description] varchar(50),
	billingRate1 float,
	billingRateOT float,
	billingRate3 float,
	EQExp1 varchar(50),
	EQExp2 varchar(50),
	Category varchar(12),
	PayItemType varchar(30), 
	WorkType varchar(30),
	CostCode varchar(30),
	CustomerPositionID varchar(30), 
	CustomerJobPositionDescription varchar(30),
	CBSFullNumber varchar(30),
	skillType varchar(100)
)
go

ALTER TABLE workCode WITH CHECK ADD CONSTRAINT PK_idWorkCode_jobNo_WorkCode
PRIMARY KEY (idWorkCode, jobNo)
go

--INSERT INTO workCode values
--(95,'LMP','LMP',0,0,0,'',''),
--(96,'LMI','LMI',0,0,0,'',''),
--(97,'LMS','LMS',0,0,0,'',''),
--(98,'LMA','LMA',0,0,0,'',''),
--(99,'LML','LML',0,0,0,'','')
--GO

--##########################################################################################
--##################  TABLA DE WORKORDER ###################################################
--##########################################################################################

create table workOrder(
	idAuxWO varchar(36) primary key not null,
	idWO varchar(14)  not null,
	idPO bigint not null,
	jobNo bigint not null
)
GO

--####################################################################################################################################
--##################  FOREIGN KEYS DE TODAS LAS TABLAS ###############################################################################
--####################################################################################################################################

--##########################################################################################
--##################  FOREIG KEYS ABSENTS ##################################################
--##########################################################################################

ALTER TABLE [dbo].[absents] WITH CHECK ADD CONSTRAINT [fk_idEmployee_Absent] FOREIGN KEY ([idEmployee]) 
REFERENCES [dbo].[employees]([idEmployee]) 
GO

--##########################################################################################
--##################  FOREIG KEYS ACTIVITY HOURS ###########################################
--##########################################################################################

ALTER TABLE activityHours WITH CHECK ADD CONSTRAINT fk_tag_activityHours
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
GO

ALTER TABLE activityHours WITH CHECK ADD CONSTRAINT fk_idModAux_activityHours
FOREIGN KEY (idModAux) REFERENCES modification(idModAux)
GO

ALTER TABLE activityHours WITH CHECK ADD CONSTRAINT fk_idDismantle_ActivityHours 
FOREIGN KEY(idDismantle) REFERENCES dismantle(idDismantle)
GO

--##########################################################################################
--##################  FOREIG KEYS AREAS ####################################################
--##########################################################################################

ALTER TABLE areas WITH CHECK ADD CONSTRAINT fk_idClient_areas
FOREIGN KEY (idClient) REFERENCES clients(idClient)
GO

--##########################################################################################
--##################  FOREIG KEYS CLIENTES #################################################
--##########################################################################################

ALTER TABLE [dbo].[clients]  WITH CHECK ADD  CONSTRAINT [fk_idContact_CL] FOREIGN KEY([idContact])
REFERENCES [dbo].[contact] ([idContact])
GO

ALTER TABLE [dbo].[clients]  WITH CHECK ADD  CONSTRAINT [fk_idHomeAddres_CL] FOREIGN KEY([idHomeAddress])
REFERENCES [dbo].[HomeAddress] ([idHomeAdress])
GO

--##########################################################################################
--##################  FOREIG KEYS CLIENTES ESTIMATION ######################################
--##########################################################################################

ALTER TABLE clientsEst WITH CHECK ADD CONSTRAINT fk_idContact_clientsEst
FOREIGN KEY (idContact) REFERENCES contact(idContact)
on update cascade
on delete cascade
GO

ALTER TABLE clientsEst WITH CHECK ADD CONSTRAINT fk_idContact_HomeAddress
FOREIGN KEY (idHomeAdress) REFERENCES HomeAddress(idHomeAdress)
on update cascade
on delete cascade
GO

--##########################################################################################
--##################  FOREIG KEYS COMPANY ##################################################
--##########################################################################################

ALTER TABLE [dbo].[company] WITH CHECK ADD CONSTRAINT [fk_idHomeAddress] FOREIGN KEY ([idHomeAddress])
REFERENCES [dbo].[homeAddress] ([idHomeAdress])
GO

ALTER  TABLE [dbo].[company] WITH CHECK ADD CONSTRAINT [fk_idContact] FOREIGN KEY  ([idContact])
REFERENCES [dbo].[contact]([idContact])
GO

--##########################################################################################
--##################  FOREIG KEYS COST PROJECT EST #########################################
--##########################################################################################

ALTER TABLE [dbo].[costProjectEst]  WITH CHECK ADD  CONSTRAINT [fk_projectId_costProjectEst] FOREIGN KEY([projectId])
REFERENCES [dbo].[projectClientEst] ([projectId])
GO

--##########################################################################################
--##################  FOREIG KEYS DETALLE MATERIAL #########################################
--##########################################################################################

ALTER TABLE [dbo].[detalleMaterial]  WITH CHECK ADD  CONSTRAINT [fk_idMaterial_DM] FOREIGN KEY([idMaterial])
REFERENCES [dbo].[material] ([idMaterial])
GO

ALTER TABLE [dbo].[detalleMaterial]  WITH CHECK ADD  CONSTRAINT [fk_idVendor_Dm] FOREIGN KEY([idVendor])
REFERENCES [dbo].[vendor] ([idVendor])
GO

--##########################################################################################
--##################  FOREIG KEYS DISMANTLE ################################################
--##########################################################################################

ALTER TABLE dismantle WITH CHECK ADD CONSTRAINT fk_tag_dismantle
FOREIGN KEY (tag) REFERENCES scaffoldTraking (tag)	
GO

--##########################################################################################
--##################  FOREIG KEYS DISMANTLE ################################################
--##########################################################################################

ALTER TABLE drawing WITH CHECK ADD CONSTRAINT fk_projectId_drawing
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS EQIRHC ###################################################
--##########################################################################################

ALTER TABLE EqIRHC WITH CHECK ADD CONSTRAINT fk_type_EqIRHC
FOREIGN KEY ([type]) REFERENCES insFitting([type])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS ESTCOSTBUILD #############################################
--##########################################################################################

ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_tag_EstCostBuild
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
	
GO

ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostBuild
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_projectId_EstCostBuild
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
GO
--##########################################################################################
--##################  FOREIG KEYS ESTCOSTDISM ##############################################
--##########################################################################################

ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_tag_EstCostDism
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
GO

ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostDism
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_projectId_EstCostDism
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
GO

--##########################################################################################
--##################  FOREIG KEYS ESTCOSTEQ ################################################
--##########################################################################################

--ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idEquipmentEst_EstCosteq
--FOREIGN KEY (tag) REFERENCES equipmentEst(idEquipmentEst)
--GO 

ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCosteq
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
GO 

ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idEquipmentEst_EstCosteq
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
GO 

--##########################################################################################
--##################  FOREIG KEYS ESTCOSTSCF ###############################################
--##########################################################################################

ALTER TABLE EstCostPp ADD CONSTRAINT fk_idDrawingNum_EstCostPp
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
on update cascade
GO

ALTER TABLE EstCostPp ADD CONSTRAINT fk_projectId_EstCostPp
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
GO
--##########################################################################################
--##################  FOREIG KEYS ESTCOSTSCF ###############################################
--##########################################################################################

ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_tag_EstCosScf
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
GO

ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostScf
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
GO

ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_projectId_EstCostScf
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
GO

--##########################################################################################
--##################  FOREIG KEYS EMPLOYEES ################################################
--##########################################################################################

ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [fk_idContact_EM] FOREIGN KEY([idContact])
REFERENCES [dbo].[contact] ([idContact])
GO

ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [fk_idHomeAdress_employees] FOREIGN KEY([idHomeAdress])
REFERENCES [dbo].[HomeAddress] ([idHomeAdress])
GO

--##########################################################################################
--##################  FOREIG KEYS ESTMETERS ################################################
--##########################################################################################

ALTER TABLE EstMeters  WITH CHECK ADD  CONSTRAINT fk_EstNumber_EstMeters FOREIGN KEY(EstNumber)
REFERENCES scfEstimation (EstNumber)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS EQPAINTUNITRATE ##########################################
--##########################################################################################

ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idDrawing_equipmentEst
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_elevation_equipmentEst
FOREIGN KEY (elevation) REFERENCES factorElevationScf(elevation)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_systemPntEq_pntOption_equipmentEst
FOREIGN KEY (systemPntEq,pntOption) REFERENCES eqPaintUnitRate(systemPntEq,pntOption)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_type_thick_equipmentEst
FOREIGN KEY ([type],thick) REFERENCES EqIRHC([type],thickness)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idJacket_equipmentEst
FOREIGN KEY (idJacket) REFERENCES eqJktUnitRate(idJacket)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idLaborRateRmv_equipmentEst
FOREIGN KEY (idLaborRateRmv) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idLaborRatePnt_equipmentEst
FOREIGN KEY (idLaborRatePnt) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idLaborII_equipmentEst
FOREIGN KEY (idLaborRateII) REFERENCES laborRate(idLaborRate)
GO

--##########################################################################################
--##################  FOREIG KEYS EQPAINTUNITRATE ##########################################
--##########################################################################################

ALTER TABLE eqInsUnitRate WITH CHECK ADD CONSTRAINT fk_type_eqInsUnitRate
FOREIGN KEY([TYPE]) REFERENCES insFitting([type])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS EQPAINTUNITRATE ##########################################
--##########################################################################################

ALTER TABLE eqPaintUnitRate WITH CHECK ADD CONSTRAINT fk_pntFitting_eqPaintUnitRate
FOREIGN KEY (pntOption) REFERENCES pntFitting(pntOption)
on update cascade
on delete cascade
GO

--##########################################################################################
--##################  FOREIG KEYS EQUIPMENT MATERIAL #######################################
--##########################################################################################

ALTER TABLE equipmentMaterial  WITH CHECK ADD  CONSTRAINT fk_type_EquipmentMaterial 
FOREIGN KEY([type]) REFERENCES insFitting ([type])
GO

--##########################################################################################
--##################  FOREIG KEYS EQUIPMENT PROGRESS #######################################
--##########################################################################################

ALTER TABLE equipmentProgress WITH CHECK ADD CONSTRAINT fk_idTag_EquipmentProgress
FOREIGN KEY (tag) REFERENCES equipmentEst(idEquimentEst)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS EXISTENCES ###############################################
--##########################################################################################

ALTER TABLE [dbo].[existences]  WITH CHECK ADD  CONSTRAINT [fk_idDM_existenece] FOREIGN KEY([idDM])
REFERENCES [dbo].[detalleMaterial] ([idDM])
GO

--##########################################################################################
--##################  FOREIG KEYS EXPENSES USED ############################################
--##########################################################################################

ALTER TABLE expensesJobs WITH CHECK ADD CONSTRAINT PK_idExpenses_jobNo_expensesJObs
PRIMARY KEY (idExpenses,jobNo)
go

ALTER TABLE expensesJobs WITH CHECK ADD CONSTRAINT fk_idExpenses_jobNo_expenesesJobs
FOREIGN KEY (idExpenses,jobNo) REFERENCES expensesJobs(idExpenses,jobNo)
go

--##########################################################################################
--##################  FOREIG KEYS EXPENSES USED ############################################
--##########################################################################################

ALTER TABLE    expensesUsed   WITH CHECK ADD  CONSTRAINT  fk_idExpence_EU  FOREIGN KEY( idExpense )
REFERENCES    expenses  ( idExpenses )
GO
ALTER TABLE	  expensesUsed  WITH CHECK ADD  CONSTRAINT fk_idAux_EU FOREIGN KEY(idAux)
REFERENCES task (idAux)
GO
ALTER TABLE    expensesUsed   WITH CHECK ADD  CONSTRAINT  fk_idEmployee_EU  FOREIGN KEY( idEmployee  )
REFERENCES    employees ( idEmployee )
GO
ALTER TABLE expensesUsed WITH CHECK ADD CONSTRAINT fk_idHoursWorked_EU FOREIGN KEY (idHorsWorked) 
REFERENCES  hoursWorked (idHorsWorked)
GO
--##########################################################################################
--##################  FOREIG KEYS HOURS PROJECT EST ########################################
--##########################################################################################

ALTER TABLE hoursProjectEst  WITH CHECK ADD  CONSTRAINT fk_projectId_HoursProjectEst FOREIGN KEY(projectId)
REFERENCES projectClientEst (projectId)
GO

--##########################################################################################
--##################  FOREIG KEYS HOURS WORKED #############################################
--##########################################################################################

ALTER TABLE    hoursWorked   WITH CHECK ADD  CONSTRAINT  fk_idEmployee_hoursWorked  FOREIGN KEY( idEmployee )
REFERENCES    employees  ( idEmployee )
GO
ALTER TABLE hoursWorked WITH CHECK ADD CONSTRAINT fk_idWorkCode_jobNo_hoursWorked  FOREIGN KEY (idWorkCode,jobNo) 
REFERENCES workCode (idWorkCode,jobNo)
go
ALTER TABLE    hoursWorked   WITH CHECK ADD  CONSTRAINT  fk_idTask_hoursWork FOREIGN KEY ( idAux )
REFERENCES    task  ( idAux )
GO

--##########################################################################################
--##################  FOREIG KEYS INCOMING #################################################
--##########################################################################################

ALTER TABLE incoming WITH CHECK ADD CONSTRAINT fk_jobNum_inComing FOREIGN KEY (jobNo) 
REFERENCES job (jobNo)
GO

--##########################################################################################
--##################  FOREIG KEYS INCOMING Y TEMINVOCE #####################################
--##########################################################################################

ALTER TABLE tempInvoice WITH CHECK ADD CONSTRAINT pk_idClient_Tempinvoice
FOREIGN KEY (idClient) REFERENCES clients(idClient)
GO

ALTER TABLE invoice WITH CHECK ADD CONSTRAINT pk_idClient_invoice
FOREIGN KEY (idClient) REFERENCES clients(idClient)
GO

--##########################################################################################
--##################  FOREIG KEYS JOB ######################################################
--##########################################################################################

ALTER TABLE    job   WITH CHECK ADD  CONSTRAINT  fk_idClient_job  FOREIGN KEY( idClient )
REFERENCES    clients  ( idClient )
GO

--##########################################################################################
--##################  FOREIG KEYS JOBCAT ###################################################
--##########################################################################################

ALTER TABLE jobCat WITH CHECK ADD CONSTRAINT fk_idClient_jobCat 
FOREIGN KEY (idClient) REFERENCES clients(idClient)
GO

--##########################################################################################
--##################  FOREIG KEYS JOBCAT ###################################################
--##########################################################################################

ALTER TABLE KPI WITH CHECK ADD CONSTRAINT fk_idAux_KPI
FOREIGN KEY (idAux) REFERENCES task(idAux)
GO

ALTER TABLE KPI WITH CHECK ADD CONSTRAINT fk_jobNo_KPI
FOREIGN KEY (jobNo) REFERENCES job(jobNo)
GO

--##########################################################################################
--##################  FOREIG KEYS LEG ######################################################
--##########################################################################################

ALTER TABLE leg WITH CHECK ADD CONSTRAINT fk_tag_leg
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
GO

--##########################################################################################
--##################  FOREIG KEYS LIST EMAIL REPORT ########################################
--##########################################################################################

ALTER TABLE listEmailReport  WITH CHECK ADD  CONSTRAINT fk_email_listEmailReport 
FOREIGN KEY(email) REFERENCES emails (email)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE listEmailReport  WITH CHECK ADD  CONSTRAINT fk_reportName_listEmailReport 
FOREIGN KEY(reportName) REFERENCES ReportEmail (reportName)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS MATERIAL #################################################
--##########################################################################################

ALTER TABLE material WITH CHECK ADD CONSTRAINT fk_code_material
FOREIGN KEY (code)  REFERENCES materialClass (code)
ON UPDATE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS MATERIAL HANDELING #######################################
--##########################################################################################

ALTER TABLE materialHandeling WITH CHECK ADD CONSTRAINT fk_tag_materialHandeling
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
GO

ALTER TABLE materialHandeling WITH CHECK ADD CONSTRAINT fk_modification_materialHandeling
FOREIGN KEY (idModAux) REFERENCES modification(idModAux)
GO

ALTER TABLE materialHandeling WITH CHECK ADD CONSTRAINT fk_idDismantle_materialHandeling 
FOREIGN KEY (idDismantle) REFERENCES dismantle(idDismantle)
GO

--##########################################################################################
--##################  FOREIG KEYS MATERIAL OREDER ##########################################
--##########################################################################################

ALTER TABLE    materialOrder   WITH CHECK ADD  CONSTRAINT  fk_idMaterial_MaterialOrder  
FOREIGN KEY( idMaterial ) REFERENCES    material  ( idMaterial )
GO

--##########################################################################################
--##################  FOREIG KEYS MATERIAL USED ############################################
--##########################################################################################

ALTER TABLE    materialUsed   WITH CHECK ADD  CONSTRAINT  fk_idMaterial_materialUsed  FOREIGN KEY( idMaterial )
REFERENCES    material  ( idMaterial )
GO

ALTER TABLE    materialUsed   WITH CHECK ADD  CONSTRAINT  fk_idTask_materialUsed  FOREIGN KEY( idAux )
REFERENCES    task  ( idAux )
GO

--##########################################################################################
--##################  FOREIG KEYS MODIFICATION SCAFFOLD ####################################
--##########################################################################################

ALTER TABLE modification WITH CHECK ADD CONSTRAINT fk_tag_modification
FOREIGN KEY (tag) REFERENCES scaffoldTraking (tag)
GO

--##########################################################################################
--##################  FOREIG KEYS OUTGOING #################################################
--##########################################################################################

ALTER TABLE outGOing ADD CONSTRAINT fk_jobNum_outGOing
FOREIGN KEY (jobNo) REFERENCES job (jobNo)
GO

--##########################################################################################
--##################  FOREIG KEYS PAYRATE ##################################################
--##########################################################################################

ALTER TABLE payRate WITH CHECK ADD CONSTRAINT fk_idEmployee_payRate 
FOREIGN KEY(idEmployee) REFERENCES employees (idEmployee)
GO

--##########################################################################################
--##################  FOREIG KEYS PIPINGEST ################################################
--##########################################################################################

ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_elevation_pipingEst
FOREIGN KEY (elevation) REFERENCES factorElevationPaint(elevation)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idJacket_pipingEst
FOREIGN KEY (idJacket) REFERENCES ppJktUnitRate(idJacket)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idLaborRateRmv_pipingEst
FOREIGN KEY (idLaborRateRmv) REFERENCES laborRate(idLaborRate)
GO

ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idLaborRatePnt_pipingEst
FOREIGN KEY (idLaborRatePnt) REFERENCES laborRate(idLaborRate)

GO

ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idLaborRateII_pipingEst
FOREIGN KEY (idLaborRateII) REFERENCES laborRate(idLaborRate)
GO

ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idDrawingNum_pipingEst
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS PIPINGMATERIAL ###########################################
--##########################################################################################

ALTER TABLE pipingMaterial WITH CHECK ADD CONSTRAINT pk_size_type_thick
PRIMARY KEY (size, [type], thick)
GO

ALTER TABLE pipingMaterial WITH CHECK ADD CONSTRAINT fk_type_pipingmaterial
FOREIGN KEY ([type]) REFERENCES insFitting([type])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
--##########################################################################################
--##################  FOREIG KEYS PIPING PROGRESS ##########################################
--##########################################################################################

ALTER TABLE pipingProgress WITH CHECK ADD CONSTRAINT fk_Tag_pipingProgress
FOREIGN KEY (tag) REFERENCES pipingEst(idPipingEst)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS PP FITTING MATERIAL ######################################
--##########################################################################################

ALTER TABLE [dbo].[ppFittingMaterial]  WITH CHECK ADD  CONSTRAINT [fk_type_ppFittingMaterial] FOREIGN KEY([type])
REFERENCES [dbo].[insFitting] ([type])
GO
--##########################################################################################
--##################  FOREIG KEYS PPINSUNITRATE ############################################
--##########################################################################################

ALTER TABLE [dbo].[ppInsUnitRate]  WITH CHECK ADD  CONSTRAINT [fk_type_PPInsUnitRate] FOREIGN KEY([type])
REFERENCES [dbo].[insFitting] ([type])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS PPIRHC ###################################################
--##########################################################################################

ALTER TABLE PpIRHC WITH CHECK ADD CONSTRAINT fk_type_PpIRHC
FOREIGN KEY ([type]) REFERENCES insFitting([type])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS PPPAINTUNITRATE ##########################################
--##########################################################################################

ALTER TABLE ppPaintUnitRate WITH CHECK ADD CONSTRAINT pk_systemPntPP_pntOption_size
PRIMARY KEY (systemPntPP,pntOption,size) 
GO

ALTER TABLE ppPaintUnitRate WITH CHECK ADD CONSTRAINT Fk_pntOption_pntFitting
FOREIGN KEY (pntOption) REFERENCES pntFitting(pntOption) 
on update cascade
on delete cascade
GO

--##########################################################################################
--##################  FOREIG KEYS PRODUCT ##################################################
--##########################################################################################

ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [fk_um_product] FOREIGN KEY([um])
REFERENCES [dbo].[unitMeassurements] ([um])
GO

ALTER TABLE [product] WITH CHECK ADD CONSTRAINT [fk_class_product]
FOREIGN KEY ([class]) REFERENCES dbo.classification([class])  
GO

--##########################################################################################
--##################  FOREIG KEYS PRODUCT COMING ###########################################
--##########################################################################################

ALTER TABLE productComing WITH CHECK ADD CONSTRAINT fk_ticketNum_inComing
FOREIGN KEY (ticketNum) REFERENCES incoming(ticketNum)
GO

ALTER TABLE productComing WITH CHECK ADD CONSTRAINT fk_idProduct_inComing
FOREIGN KEY (idProduct) REFERENCES product(idProduct)
GO

--##########################################################################################
--##################  FOREIG KEYS PRODUCT DISMANTLE ########################################
--##########################################################################################

ALTER TABLE productDismantle WITH CHECK ADD CONSTRAINT fk_idDismantle_productDismantle 
FOREIGN KEY(idDismantle) REFERENCES dismantle(idDismantle)
GO

ALTER TABLE productDismantle WITH CHECK ADD CONSTRAINT fk_idPorduct_productDismantle 
FOREIGN KEY(idProduct)REFERENCES product(idProduct)
GO

ALTER TABLE productDismantle WITH CHECK ADD CONSTRAINT fk_tag_productDismantle 
FOREIGN KEY(tag) REFERENCES scaffoldTraking(tag)
GO

--##########################################################################################
--##################  FOREIG KEYS PRODUCT JOB ##############################################
--##########################################################################################

ALTER TABLE productJob  WITH CHECK ADD CONSTRAINT fk_idProduct_productJob FOREIGN KEY(idProduct)
REFERENCES product (idProduct)
GO

ALTER TABLE productJob  WITH CHECK ADD  CONSTRAINT fk_jobNo_productJob FOREIGN KEY(jobNo)
REFERENCES job (jobNo)
GO

--##########################################################################################
--##################  FOREIG KEYS PRODUCT MODIFICATION #####################################
--##########################################################################################

ALTER TABLE productModification  WITH CHECK ADD  CONSTRAINT fk_idModification_productModification
FOREIGN KEY(idModAux) REFERENCES modification (idModAux)
GO

ALTER TABLE productModification WITH CHECK ADD CONSTRAINT fk_idProduct_productModification
FOREIGN KEY (idProduct) REFERENCES product(idProduct)
GO

ALTER TABLE productModification WITH CHECK ADD CONSTRAINT fk_tag_scaffoldTraking
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
GO

--##########################################################################################
--##################  FOREIG KEYS PRODUCT OUTGOING #########################################
--##########################################################################################

ALTER TABLE productOutGOing ADD CONSTRAINT fk_ticketNum_productOutGOing
FOREIGN KEY (ticketNum) REFERENCES outGOing(ticketNum)
GO

ALTER TABLE productOutGOing ADD CONSTRAINT fk_idProduct_productOutGOing
FOREIGN KEY (idProduct) REFERENCES product(idProduct)
GO

--##########################################################################################
--##################  FOREIG KEYS PRODUCT SCAFFOLD #########################################
--##########################################################################################

ALTER TABLE productScaffold WITH CHECK ADD CONSTRAINT fk_tag_productScaffold
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
GO

ALTER TABLE productScaffold WITH CHECK ADD CONSTRAINT fk_idSubJob_productScaffold
FOREIGN KEY (idProduct) REFERENCES product(idProduct)
GO

--##########################################################################################
--##################  FOREIG KEYS PRODUCT TOTAL SCAFFOLD ###################################
--##########################################################################################

ALTER TABLE productTotalScaffold WITH CHECK ADD CONSTRAINT fk_idProduct_productTotalScaffold
FOREIGN KEY (idProduct) REFERENCES product(idProduct)
GO

ALTER TABLE productTotalScaffold WITH CHECK ADD CONSTRAINT fk_tag_productTotalScaffold
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
GO

--##########################################################################################
--##################  FOREIG KEYS PROJECT CLIENTS EST ######################################
--##########################################################################################

ALTER TABLE projectClientEst WITH CHECK ADD CONSTRAINT fk_idClintEst_projectClientEst
FOREIGN KEY (idClientEst) REFERENCES clientsEst(idClientEst)
on update cascade
on delete cascade
GO

--##########################################################################################
--##################  FOREIG KEYS PROJECT OREDER ###########################################
--##########################################################################################

ALTER TABLE    projectOrder   WITH CHECK ADD  CONSTRAINT  fk_jobNo_PO  FOREIGN KEY( jobNo )
REFERENCES    job  ( jobNo )
on update cascade
on delete cascade
GO

--##########################################################################################
--##################  FOREIG KEYS RFI EQUIPMENT ############################################
--##########################################################################################
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_elevation_RFIEquipment 
FOREIGN KEY(newElevation)REFERENCES factorElevationSCF (elevation)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_idDrawingNum_RFIEquipment
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_newElevation_RFIEquipment
FOREIGN KEY (newElevation) REFERENCES factorElevationScf(elevation)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_oldElevation_RFIEquipment
FOREIGN KEY (oldElevation) REFERENCES factorElevationScf(elevation)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_new_systemPntEq_pntOption_RFIEquipment
FOREIGN KEY (newSystem,newOption) REFERENCES eqPaintUnitRate(systemPntEq,pntOption)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_old_systemPntEq_pntOption_RFIEquipment
FOREIGN KEY (oldSystem,oldOption) REFERENCES eqPaintUnitRate(systemPntEq,pntOption)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_new_type_thick_RFIEquipment
FOREIGN KEY (newType,newThick) REFERENCES EqIRHC([type],thickness)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_old_type_thick_RFIEquipment
FOREIGN KEY (oldType,oldThick) REFERENCES EqIRHC([type],thickness)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_new_idJacket_RFIEquipment
FOREIGN KEY (newJacket) REFERENCES eqJktUnitRate(idJacket)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_old_idJacket_RFIEquipment
FOREIGN KEY (oldJacket) REFERENCES eqJktUnitRate(idJacket)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_new_idLaborRateRmv_RFIEquipment
FOREIGN KEY (newWwRemove) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_old_idLaborRateRmv_RFIEquipment
FOREIGN KEY (oldWwRemove) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_new_idLaborRatePnt_RFIEquipment
FOREIGN KEY (newWwInstall) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_old_idLaborRatePnt_RFIEquipment
FOREIGN KEY (oldWwInstall) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_new_idLaborII_RFIEquipment
FOREIGN KEY (newWwPaint) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_old_idLaborII_RFIEquipment
FOREIGN KEY (oldWwPaint) REFERENCES laborRate(idLaborRate)
GO

--##########################################################################################
--##################  FOREIG KEYS RFI SCAFFOLD #############################################
--##########################################################################################

ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_old_Elevation_RFIPiping
FOREIGN KEY (oldElevation) REFERENCES factorElevationScf(elevation)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_new_Elevation_RFIPiping
FOREIGN KEY (newElevation) REFERENCES factorElevationScf(elevation)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_old_idJacket_RFIPiping
FOREIGN KEY (oldIdJacket) REFERENCES ppJktUnitRate(idJacket)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_new_idJacket_RFIPiping
FOREIGN KEY (newIdJacket) REFERENCES ppJktUnitRate(idJacket)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_new_idLaborII_RFIPiping
FOREIGN KEY (newIdLaborRateII) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_old_idLaborII_RFIPiping
FOREIGN KEY (oldidLaborRateII) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_new_idLaborPnt_RFIPiping
FOREIGN KEY (newIdLaborRatePnt) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_old_idLaborPnt_RFIPiping
FOREIGN KEY (oldidLaborRatePnt) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_new_idLaborRmv_RFIPiping
FOREIGN KEY (newIdLaborRateRmv) REFERENCES laborRate(idLaborRate)
GO
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT fk_old_idLaborRmv_RFIPiping
FOREIGN KEY (oldidLaborRateRmv) REFERENCES laborRate(idLaborRate)
GO

--##########################################################################################
--##################  FOREIG KEYS RFI SCAFFOLD #############################################
--##########################################################################################
ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_idDrawing_RFIScaffoldEst
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
GO

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_tag_RFIScaffoldEst
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
on update cascade
on delete cascade
GO

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_newIdLaborRate_RFIScaffoldEst
FOREIGN KEY (newIdLaborRate) REFERENCES laborRate(idLaborRate)
GO

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_lastdLaborRate_RFIScaffoldEst
FOREIGN KEY (lastIdLaborRate) REFERENCES laborRate(idLaborRate)
GO

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_newIdSCFUR_RFIScaffoldEst
FOREIGN KEY (newIdSCFUR) REFERENCES scfUnitsRates(IdSCFUR)
GO

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_lastIdSCFUR_RFIScaffoldEst
FOREIGN KEY (lastIdSCFUR) REFERENCES scfUnitsRates(IdSCFUR)
GO
--##########################################################################################
--##################  FOREIG KEYS SCAFFOLD INFORMATION #####################################
--##########################################################################################

ALTER TABLE scaffoldInformation WITH CHECK ADD CONSTRAINT fk_type_scaffoldInformation
FOREIGN KEY (type) REFERENCES rental(type)
GO

ALTER TABLE scaffoldInformation WITH CHECK ADD CONSTRAINT fk_tag_scaffoldInformation
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE scaffoldInformation  WITH CHECK ADD  CONSTRAINT fk_idModification_scaffoldInformation
FOREIGN KEY(idModAux) REFERENCES modification (idModAux)
GO

--##########################################################################################
--##################  FOREIG KEYS SCAFFOLD PROGRESS ########################################
--##########################################################################################

ALTER TABLE ScaffoldProgress WITH CHECK ADD CONSTRAINT fk_idTag_ScaffoldProgress
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS SCAFFOLD TRAKING #########################################
--##########################################################################################

ALTER TABLE scaffoldTraking WITH CHECK ADD CONSTRAINT fk_idAux_scaffoldTraking
FOREIGN KEY (idAux) REFERENCES task(idAux)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE scaffoldTraking WITH CHECK ADD CONSTRAINT fk_idJobCat_scaffoldTraking
FOREIGN KEY (idJobCat) REFERENCES jobCat(idJobCat)
GO
ALTER TABLE scaffoldTraking WITH CHECK ADD CONSTRAINT fk_idArea_scaffoldTraking
FOREIGN KEY (idArea) REFERENCES areas(idArea)
GO
ALTER TABLE scaffoldTraking WITH CHECK ADD CONSTRAINT fk_idSubJob_scaffoldTraking
FOREIGN KEY (idSubJob) REFERENCES subJobs(idSubJob)
GO

--##########################################################################################
--##################  FOREIG KEYS SCFESTIMATION ############################################
--##########################################################################################

ALTER TABLE [dbo].[scfEstimation]  WITH CHECK ADD  CONSTRAINT [fk_idAux_scfEstimation] FOREIGN KEY([idAux])
REFERENCES [dbo].[task] ([idAux])
GO

ALTER TABLE [dbo].[scfEstimation]  WITH CHECK ADD  CONSTRAINT [fk_idEstCost_scfEstimation] FOREIGN KEY([idEstCost])
REFERENCES [dbo].[ScafEstCost] ([idEstCost])
GO

ALTER TABLE [dbo].[scfEstimation]  WITH CHECK ADD  CONSTRAINT [fk_scfTypeId_scfEstimation] FOREIGN KEY([scfTypeId])
REFERENCES [dbo].[scfTypeCost] ([scfTypeId])
GO

ALTER TABLE [dbo].[scfEstimation]  WITH CHECK ADD  CONSTRAINT [fk_ccnum_scfEstimation] FOREIGN KEY([ccnum])
REFERENCES [dbo].[scfEstProyect] ([ccnum])
GO

ALTER TABLE [dbo].[scfEstimation] WITH CHECK ADD CONSTRAINT [fk_idClient_scfEstimation] FOREIGN KEY ([idClient]) 
REFERENCES [dbo].[clients]([idClient])
GO
--##########################################################################################
--##################  FOREIG KEYS SCFFOLDEST ###############################################
--##########################################################################################

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idLaborRate_scaffoldEst
FOREIGN KEY (idLaborRate) REFERENCES laborRate(idLaborRate)
GO

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idEnviroment_scaffoldEst
FOREIGN KEY (idEnviroment) REFERENCES enviroment(idEnviroment)
GO

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idSCFUR_scaffoldEst
FOREIGN KEY (idSCFUR) REFERENCES scfUnitsRates(idSCFUR)
GO

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idDrawingNum_scaffoldEst
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
--##########################################################################################
--##################  FOREIG KEYS SCFINFO ##################################################
--##########################################################################################

ALTER TABLE scfInfo WITH CHECK ADD CONSTRAINT fk_tag_scfInfo
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
GO

--##########################################################################################
--##################  FOREIG KEYS SUBJOB ###################################################
--##########################################################################################

ALTER TABLE subJobs WITH CHECK ADD CONSTRAINT fk_idClient_subJobs 
FOREIGN KEY (idClient) REFERENCES clients(idClient)
GO

--##########################################################################################
--##################  FOREIG KEYS TASK #####################################################
--##########################################################################################

ALTER TABLE task WITH CHECK ADD CONSTRAINT fk_idWorkOrder_task FOREIGN KEY (idAuxWO)
REFERENCES workOrder (idAuxWO)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS TAXESST ##################################################
--##########################################################################################

ALTER TABLE taxesST WITH CHECK ADD CONSTRAINT fk_jobNo_taxesST 
FOREIGN KEY (jobNo) REFERENCES job(jobNo)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS TAXESPT ##################################################
--##########################################################################################

ALTER TABLE taxesPT WITH CHECK ADD CONSTRAINT fk_jobNo_taxesPT 
FOREIGN KEY (jobNo) REFERENCES job(jobNo)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS TRAKDEFAULTELEMENTS ######################################
--##########################################################################################

ALTER TABLE TrackDefaultElements WITH CHECK ADD CONSTRAINT fk_idClient_TrackDefaultElements
FOREIGN KEY (idClient) REFERENCES clients(idClient)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS TRAKFORMATCOLUMS #########################################
--##########################################################################################

ALTER TABLE TrackFormatColums WITH CHECK ADD CONSTRAINT fk_idClient_TrackFormatColums
FOREIGN KEY (idClient) REFERENCES clients(idClient)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS WORKCODE #################################################
--##########################################################################################
ALTER TABLE workCode WITH CHECK ADD CONSTRAINT fk_jobNo_WorkCode
FOREIGN KEY (jobNo) REFERENCES job (jobNo)
ON UPDATE CASCADE
ON DELETE CASCADE
go
--##########################################################################################
--##################  FOREIG KEYS WORKORDER ################################################
--##########################################################################################

ALTER TABLE    workOrder   WITH CHECK ADD  CONSTRAINT  fk_idPO_workOrder  FOREIGN KEY( idPO , jobNo)
REFERENCES    projectOrder  ( idPO , jobNo)
on update cascade
on delete cascade
GO

--[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
--[[[[[[[[[[[[[[[ FUNCTIONS DE LA BASE DE DATOS [[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[
--[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[

CREATE FUNCTION addCaracter(@text AS NVARCHAR(100), @caracters AS NVARCHAR(1) ,@qty AS INT,@side AS INT)
RETURNS NVARCHAR(100)
AS 
BEGIN
	DECLARE @var NVARCHAR(100)
	DECLARE @count int
	SET @count =0
	SET @var = @text
	WHILE @count < @qty
	BEGIN
		SET @var = iif(@side=0,concat(@caracters,@var) ,concat(@var,@caracters))
		SET @count = @count + 1
	END
	RETURN @var
END
GO
--##############################################################################################
--################## ACTUALIZACION DEL NOMBRE DE ALGUNOS BOTONES ###############################
--##############################################################################################
--update userAccess set access = 'Scaffold Tracking' where access = 'Scaffold Traking'
--go
--update userAccess set access = 'Client Projects' where access = 'Work Codes'
--go
----##############################################################################################
----################## ACTUALIZACION DE METODO PARA SELECCIONAR LOS ##############################
----################## DATOS DE LA COMPANIA EN LOS REPORTES         ##############################
----##############################################################################################
--ALTER proc [dbo].[sp_select_MyComapny_Info]
--@CompanyName varchar(30)
--as
--begin
--select cmp.name,
--	ha.city,
--	ha.providence,
--	CONCAT(ha.avenue , ' ',ha.number) as 'Address',
--	ha.postalCode,
--	cmp.idContact,
--	cmp.invoiceDescr,
--	ct.email,
--	ct.phoneNumber1 as 'PhoneNumber1',
--	ct.phoneNumber2 as 'PhoneNumber2',
--	cmp.img
--from company as cmp 
--left join HomeAddress as ha on ha.idHomeAdress	= cmp.idHomeAddress
--left join contact as ct on ct.idContact = cmp.idContact
--end

--##############################################################################################
--################## CAMBIOS PARA WORKCODE CON JOB NO ##########################################
--##############################################################################################

--alter table expensesUsed drop constraint fk_idHoursWorked_expensesUsed
--go
--delete from expensesUsed
--go
--drop table hoursWorked 
--go
----la tabla hoursWorkedTMP puede que no este creada creo que la cree hace tiempo para hacer unos cambios 
--drop table hoursWorkedTMP
--go
--drop table workCode 
--go

--create table workCode (
--	idWorkCode int not null,
--	jobNo bigint not null,
--	name varchar(30),
--	[description] varchar(50),
--	billingRate1 float,
--	billingRateOT float,
--	billingRate3 float,
--	EQExp1 varchar(50),
--	EQExp2 varchar(50) 
--)
--go

--ALTER TABLE workCode WITH CHECK ADD CONSTRAINT PK_idWorkCode_jobNo_WorkCode
--PRIMARY KEY (idWorkCode, jobNo)
--go

--ALTER TABLE workCode WITH CHECK ADD CONSTRAINT fk_jobNo_WorkCode
--FOREIGN KEY (jobNo) REFERENCES job (jobNo)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--go
--create TABLE hoursWorked(
--	idHorsWorked varchar(36) not null primary key,
--	hoursST float,
--	hoursOT float,
--	hours3 float,
--	dateWorked date,
--	idEmployee varchar(36), 
--	idWorkCode int,
--	idAux varchar(36),
--	jobNo bigint
--)
--go

--ALTER TABLE hoursWorked WITH CHECK ADD CONSTRAINT fk_idEmployee_hoursWorked
--FOREIGN KEY (idEmployee) REFERENCES employees (idEmployee)
--go

--ALTER TABLE hoursWorked WITH CHECK ADD CONSTRAINT fk_idTask_hoursWorked
--FOREIGN KEY (idAux) REFERENCES task (idAux)
--go

--ALTER TABLE hoursWorked WITH CHECK ADD CONSTRAINT fk_idWorkCode_jobNo_hoursWorked
--FOREIGN KEY (idWorkCode,jobNo) REFERENCES workCode (idWorkCode,jobNo)
--go

--ALTER TABLE expensesUsed WITH CHECK ADD CONSTRAINT fk_idHoursWorked_EU 
--FOREIGN KEY (idHorsWorked) REFERENCES  hoursWorked (idHorsWorked)
--go
----##############################################################################################
----################## SP DELETE SCAFFOLD ########################################################
----##############################################################################################
--ALTER proc sp_deleteScaffold
--@tag as varchar(20)
--as 
--declare @countProduct as int = (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't' )	
--declare @qty as float = 0.0
--declare @idProduct as int
--begin
--while (@countProduct > 0) 
--begin
--	select  @qty = quantity ,@idProduct = idProduct from (select top 1  quantity,idProduct from productTotalScaffold where tag = @tag and status = 't') as t1
--	select quantity from product where idProduct = @idProduct
--	update product set quantity = quantity + @qty where idProduct = @idProduct
--	delete from productTotalScaffold where idProduct = @idProduct and tag = @tag
--	set @countProduct = (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't')
--end
--if (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't')=0
--begin
--	delete from leg where tag	= @tag
--	select *from materialHandeling where tag = @tag
--	delete from materialHandeling where tag = @tag
--	select * from activityHours where tag = @tag
--	delete from activityHours where tag = @tag
--	select * from scaffoldInformation where tag = @tag
--	delete from scaffoldInformation	where tag = @tag
--	select * from scfInfo where tag = @tag
--	delete from scfInfo where tag = @tag
--	select * from productDismantle where tag = @tag
--	delete from productDismantle where tag = @tag
--	select * from dismantle where tag = @tag
--	delete from dismantle where tag = @tag 
--	select * from productDismantle where tag = @tag
--	delete from productModification where tag = @tag
--	select * from modification where tag = @tag
--	delete from modification where tag= @tag
--	select * from productScaffold where tag = @tag
--	delete from productScaffold where tag =@tag
--    select * from productTotalScaffold where tag = @tag
--	delete from productTotalScaffold where tag = @tag
--	select * from scaffoldTraking where tag = @tag
--	delete from scaffoldTraking where tag = @tag
--end
--end
--go
----##############################################################################################
----################## PROCEDIMIENTOS PARA ELIMINAR PROJECTOS ####################################
----##############################################################################################
--alter proc sp_delete_project
--@idAux varchar(36),
--@idAuxWO varchar(36)
--as
--declare @error as bit = 0
--declare @taskAux as varchar(20)
--declare @countScaff as int
--begin 
--	begin tran
--		begin try	
--		if @idAux <> '' 
--		begin 
--			if (select COUNT(*) from expensesUsed where idAux = @idAux)>0
--			begin 
--				delete from expensesUsed where idAux = @idAux 
--			end
--			if (select COUNT(*) from materialUsed where idAux = @idAux)>0
--			begin
--				delete from materialUsed where idAux = @idAux
--			end
--			if (select COUNT(*) from hoursWorked where idAux = @idAux)>0
--			begin
--				delete from hoursWorked where idAux = @idAux
--			end
--			if (select COUNT(*) from scaffoldTraking where idAux = @idAux)>0
--			begin
--				set @countScaff =( select COUNT(*) from scaffoldTraking where idAux = @idAux)
--				while (@countScaff>0)
--				begin
--					set @taskAux = (select top 1 tag from scaffoldTraking where idAux = @idAux)
--					exec sp_deleteScaffold @taskAux
--					set @countScaff =( select COUNT(*) from scaffoldTraking where idAux = @idAux)
--				end
--			end
--			if (select COUNT(*) from scfEstimation where idAux = @idAux)>0
--			begin
--				delete EstMeters from EstMeters as estM inner join scfEstimation as scfest on estM.EstNumber = scfest.EstNumber 
--				 where scfest.idAux = @idAux
--				delete from scfEstimation where idAux = @idAux
--			end
--			delete from task where idAux = @idAux
--		end
--		else if @idAuxWO <> '' 
--		begin 
--			delete from workOrder where idAuxWO = @idAuxWO
--		end
--	end try
--		begin catch
--			set @error = 1
--			goto solveProblem
--		end catch
--	commit tran
--	solveProblem:
--	if @error <> 0 
--	begin 
--		rollback tran
--	end  
--end
--go
--###############################################################################################
--########### CAMBIOS PARA REPORTES DE TIMESHEETPO, TIMESHEET E INVOICE DETAILS #################
--###############################################################################################
--alter proc [dbo].[select_Time_Sheet_PO]
--	@IntialDate date,
--	@FinalDate date,
--	@clientnum as int,
--	@job as bigint,
--	@all as bit
--as 
--begin
--	set @IntialDate = ISNULL(@IntialDate,GETDATE())
--	set @FinalDate = ISNULL(@FinalDate,GETDATE())
--	select * from (
--	select
--	distinct
--		cl.numberClient,
--		jb.jobNo,
--		po.idPO,
--		(select sum(hw1.hoursST) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and po1.jobNo = wo1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient where cl1.idClient = cl.idClient and po1.idPO=po.idPO and jb.jobNo = jb1.jobNo and hw1.idEmployee = em.idEmployee and SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))=SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1)))and wc.jobNo = wc1.jobNo and hw1.dateWorked between @IntialDate and @FinalDate) as 'hoursST',
--		(select sum(hw2.hoursOT) from hoursWorked as hw2 inner join workCode as wc2 on wc2.idWorkCode = hw2.idWorkCode and wc2.jobNo = hw2.jobNo inner join task as tk2 on tk2.idAux = hw2.idAux inner join workOrder as wo2 on wo2.idAuxWO = tk2.idAuxWO inner join projectOrder as po2 on po2.idPO = wo2.idPO and po2.jobNo = wo2.jobNo inner join job as jb2 on jb2.jobNo = po2.jobNo inner join clients as cl2 on cl2.idClient = jb2.idClient where cl2.idClient = cl.idClient and po2.idPO=po.idPO and jb.jobNo = jb2.jobNo and hw2.idEmployee = em.idEmployee and SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))=SUBSTRING( wc2.name,1,iif(CHARINDEX('-',wc2.name)=0, len(wc2.name) ,(CHARINDEX('-',wc2.name)-1)))and wc.jobNo = wc2.jobNo and hw2.dateWorked between @IntialDate and @FinalDate) as 'hoursOT',
--		SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
--		hw.schedule as 'Shift',
--		CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee',
--		em.numberEmploye as 'Emp: Number',
--		em.typeEmployee as 'class'
--		from hoursWorked as hw 
--					inner join employees as em on hw.idEmployee = em.idEmployee
--					inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--					inner join task as tk on tk.idAux = hw.idAux 
--					inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
--					inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--					inner join job as jb on jb.jobNo = po.jobNo
--					inner join clients  as cl on cl.idClient = jb.idClient
--		where hw.dateWorked between @IntialDate and @FinalDate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%',convert(nvarchar,@job))
--		) as T1 where T1.hoursST > 0 or T1.hoursOT>0 order by T1.idPO 
--end
--go

--alter proc [dbo].[sp_Invoice_PO]
--@numberClient  int,
--@startDate date, 
--@FinalDate date, 
--@idPO bigint,
--@all bit 
--as 
--begin 
--select 
--	cl.numberClient,
--	cl.companyName,
--	cl.payTerms,
--	jb.jobNo,
--	po.idPO, 
--	SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) 'Class',
--	hw.hoursST,
--	(hw.hoursST*wc.billingRate1) as 'CostST',
--	hw.hoursOT,
--	(hw.hoursOT*wc.billingRateOT) as 'CostOT',
--	isnull((select sum(amount) from expensesUsed as exu where exu.idHorsWorked = hw.idHorsWorked and exu.dateExpense between @startDate and @FinalDate),0)as 'Perdiem'
--	into #TablaHorasClassPerdiem
--	from hoursWorked as hw 
--		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--		inner join task as tk on tk.idAux = hw.idAux 
--		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--		inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
--		inner join job as jb on po.jobNo = jb.jobNo
--		inner join clients as cl on cl.idClient = jb.idClient
--		where cl.numberClient = @numberClient and hw.dateWorked between @startDate and @FinalDate and po.idPO like iif(@all = 1 ,'%%%',convert(nvarchar, @idPO))

--select
--	distinct
--	t1.numberClient,
--	t1.companyName,
--	t1.payTerms,
--	t1.jobNo,
--	t1.idPO,
--	t1.Class,
--	(select
--	sum(hoursST)
--	from #TablaHorasClassPerdiem as t2 
--	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'ST',
--	(select
--	sum(CostST)
--	from #TablaHorasClassPerdiem as t2 
--	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'CostST',
--	(select
--	sum(hoursOT)
--	from #TablaHorasClassPerdiem as t2 
--	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'OT',
--	(select
--	sum(CostOT)
--	from #TablaHorasClassPerdiem as t2 
--	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'CostOT',
--	(select
--	sum(perdiem)
--	from #TablaHorasClassPerdiem as t2 
--	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'Perdiem'
--from #TablaHorasClassPerdiem as t1 
--drop table #TablaHorasClassPerdiem
--end
--go

--alter proc [dbo].[select_TimeSheet_Report]
--	@IntialDate date,
--	@FinalDate date,
--	@numclient int,
--	@job bigint,
--	@all bit
--as 
--begin
--	if @IntialDate is not null and @FinalDate is not null
--	begin 
--		select distinct
--			T1.[jobNo],T1.[idPO],T1.[task],T1.[equipment], 
--			T1.[description],
--			T1.[accountNum],
--			SUM(T1.[hoursST]) OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[task],T1.[Code],T1.[Shift],T1.[Emp: Number]) as 'hoursST',
--			SUM(T1.[hoursOT]) OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[task],T1.[Code],T1.[Shift],T1.[Emp: Number])as 'hoursOT',
--			SUM(T1.[hours3]) OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[task],T1.[Code],T1.[Shift],T1.[Emp: Number]) as 'hours3',
--			T1.[Code],
--			T1.[Shift],
--			T1.[expCode],
--			T1.[Complete],
--			T1.[hrEst],
--			T1.[Employee],
--			T1.[Emp: Number],
--			T1.[class],
--			T1.[companyName]
--			from 
--			(select
--			jb.jobNo,
--			po.idPO,
--			CONCAT(wo.idWO,'-',tk.task)AS 'task' ,
--			tk.equipament as 'equipment',
--			tk.[description],
--			tk.accountNum,
--			hw.hoursST,
--			hw.hoursOT,
--			hw.hours3,
--			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
--			hw.schedule as 'Shift', 
--			tk.expCode,
--			concat(tk.percentComplete,'%')  as 'Complete',
--			tk.estimateHours as 'hrEst',
--			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
--			em.numberEmploye as 'Emp: Number' ,
--			em.typeEmployee as 'class',
--			cl.companyName
--			from hoursWorked as hw 
--			inner join workCode as wc on wc.idWorkCode = hw.idworkCode and wc.jobNo = hw.jobNo
--			inner join employees em on hw.idEmployee  = em.idEmployee
--			inner join task as tk on tk.idAux = hw.idAux
--			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
--			inner join job as jb on jb.jobNo = po.jobNo
--			inner join clients as cl on cl.idClient = jb.idClient
--			where
--			hw.dateWorked between @IntialDate and @FinalDate and  wc.name not like '%6.4%' and not wc.name like '%COVID%'
--			) as T1
--	end
--end
--GO

--###############################################################################################
--########### CAMBIOS PARA REPORTES DE ACTIVE AV ################################################
--###############################################################################################
--ALTER proc [dbo].[sp_Active_Employee_Average]
--as
--begin
--	select em.lastName as 'Last Name' , 
--		CONCAT(em.firstName,' ',substring( em.middleName,1,1)) as 'First Name',
--		CONCAT('$',(select pr1.payRate1 from payRate as pr1 where idEmployee = em.idEmployee and datePayRate = (select MAX(datePayRate) from payRate as pr2 where idEmployee = em.idEmployee))) AS 'Pay Rate' , 
--		em.socialNumber as 'SS Number',em.numberEmploye as 'Brock Emp.',
--		IIF(em.estatus = 'E','Yes','NO') as 'Active',
--		em.SAPNumber as 'Citigo Emp.'
--		from employees as em 
--		where estatus = 'E'	
--end 
--go
--###############################################################################################
--########### CAMBIO PARA EL EXCEL DE WORKING ###################################################
--###############################################################################################

--ALTER proc [dbo].[sp_selectJobTaxesExcel] 
--@StartDate as date, 
--@EndDate as date 
--as
--begin
--select T1.jobNo ,T1.[ST Hours] ,T1.[OT Hours],T1.[Total Hours] ,T1.[Labor Cost] ,T1.[Scaffold-ADD] ,
--	T1.[3rd Party Cost],T1.[In House Vehicles],T1.[Scaffold],T1.[Company Equipment] ,T1.[Material Cost],T1.[Subcontract Cost] ,
--	T1.[Tools] ,T1.[Consumables] ,T1.[Other Cost] , T1.[Other Revanue],
--	ISNULL(txs.FICA,0) as 'FICA',
--	ISNULL(txs.FUI,0) as 'FUI',
--	ISNULL(txs.SUI,0) as 'SUI',
--	ISNULL(txs.WC,0) as 'WC',
--	ISNULL(txs.GenLiab,0) as 'Gen Liab',
--	ISNULL(txs.Umbr,0) as 'Umbr',
--	ISNULL(txs.Pollution,0) as 'Pollution',
--	ISNULL(txs.Healt,0) as 'Healt',
--	ISNULL(txs.Fringe,0) as 'Fringe',
--	ISNULL(txs.Small,0) as 'Small',
--	ISNULL(txs.PPE,0) as 'PPE',
--	ISNULL(txs.Consumable,0) as 'Consumable',
--	ISNULL(txs.Overhead,0) as 'Overhead',
--	ISNULL(txs.Profit,0) as 'Profit',
--	ISNULL(txP.FICA,0) as 'FICA P',
--	ISNULL(txP.FUI,0) as 'FUI P',
--	ISNULL(txP.SUI,0) as 'SUI P',
--	ISNULL(txP.WC,0) as 'WC P',
--	ISNULL(txP.GenLiab,0) as 'Gen Liab P',
--	ISNULL(txP.Umbr,0) as 'Umbr P',
--	ISNULL(txP.Pollution,0) as 'Pollution P',
--	ISNULL(txP.Healt,0) as 'Healt P',
--	ISNULL(txP.Fringe,0) as 'Fringe P',
--	ISNULL(txP.Small,0) as 'Small P',
--	ISNULL(txP.PPE,0) as 'PPE P',
--	ISNULL(txP.Consumable,0) as 'Consumable P',
--	ISNULL(txP.Overhead,0) as 'Overhead P',
--	ISNULL(txP.Profit,0) as 'Profit P'
--from(
--select distinct jb.jobNo,
--	ISNULL((select SUM(hw1.hoursST) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'ST Hours',
--	ISNULL((select SUM(hw1.hoursOT+hw1.hours3 ) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'OT Hours',
--	ISNULL((select SUM(hw1.hoursST+hw1.hoursOT+hw1.hours3) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'Total Hours',
--	ISNULL((select ROUND(SUM((hw1.hoursST*wc1.billingRate1)+(hw1.hoursOT*wc1.billingRateOT)+(hw1.hours3*wc1.billingRate3)),2) from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode= hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'Labor Cost',
--	ISNULL((select Scaffold from taxesST where jobNo = jb.jobNo),0) as 'Scaffold-ADD',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='D' and not mc1.[description] like '%scaf%')),0) AS '3rd Party Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='E' and not mc1.[description] like '%scaf%')),0) AS 'In House Vehicles',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and mc1.[description] like '%scaf%'),0) AS 'Scaffold',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='F' and not mc1.[description] like '%scaf%')),0) AS 'Company Equipment',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='M' and not mc1.[description] like '%scaf%')),0) AS 'Material Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='S' and not mc1.[description] like '%scaf%')),0) AS 'Subcontract Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='T' and not mc1.[description] like '%scaf%')),0) AS 'Tools',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='V' and not mc1.[description] like '%scaf%')),0) AS 'Consumables',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='Y' and not mc1.[description] like '%scaf%')),0) AS 'Other Cost',
--	(select ROUND(ISNULL(SUM(amount),0),2) 
--		from expensesUsed as exu1 
--		inner join task as tk1 on tk1.idAux = exu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and po1.jobNo = wo1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and exu1.dateExpense between @StartDate and @EndDate ) as 'Other Revanue'
--from job as jb
--left join projectOrder as po on po.jobNo = jb.jobNo
--left join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.idPO
--left join task as tk on tk.idAuxWO = wo.idAuxWO 
--left join hoursWorked as hw on hw.idAux = tk.idAux
--) as T1 
--left join taxesST as txs on txs.jobNo = T1.jobNo
--left join taxesPT as txp on txp.jobNo = T1.jobNo
--end
--go

----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V
----###############################################################################################
----########### CAMBIO PARA PODER ELIMINAR LOS PROJECTOS ##########################################
----###############################################################################################
--ALTER proc [dbo].[sp_delete_project]
--@idAux varchar(36),
--@idAuxWO varchar(36)	
--as
--declare @error as bit = 0
--declare @taskAux as varchar(20)
--declare @countScaff as int
--begin 
--	begin tran
--		begin try	
--		if @idAux <> '' 
--		begin 
--			if (select COUNT(*) from expensesUsed where idAux = @idAux)>0
--			begin 
--				delete from expensesUsed where idAux = @idAux 
--			end
--			if (select COUNT(*) from materialUsed where idAux = @idAux)>0
--			begin
--				delete from materialUsed where idAux = @idAux
--			end
--			if (select COUNT(*) from hoursWorked where idAux = @idAux)>0
--			begin
--				delete from hoursWorked where idAux = @idAux
--			end
--			if (select COUNT(*) from scaffoldTraking where idAux = @idAux)>0
--			begin
--				set @countScaff =( select COUNT(*) from scaffoldTraking where idAux = @idAux)
--				while (@countScaff>0)
--				begin
--					set @taskAux = (select top 1 tag from scaffoldTraking where idAux = @idAux)
--					exec sp_deleteScaffold @taskAux
--					set @countScaff =( select COUNT(*) from scaffoldTraking where idAux = @idAux)
--				end
--			end
--			if (select COUNT(*) from scfEstimation where idAux = @idAux)>0
--			begin
--				delete EstMeters from EstMeters as estM inner join scfEstimation as scfest on estM.EstNumber = scfest.EstNumber 
--				 where scfest.idAux = @idAux
--				delete from scfEstimation where idAux = @idAux
--			end
--			delete from task where idAux = @idAux
--			if (select COUNT(*) from KPI where idAux = @idAux) >0
--			begin 
--				delete from KPI where idAux = @idAux
--			end
--		end
--		else if @idAuxWO <> '' 
--		begin 
--			delete from workOrder where idAuxWO = @idAuxWO
--		end
--	end try
--		begin catch
--			set @error = 1
--			goto solveProblem
--		end catch
--	commit tran
--	solveProblem:
--	if @error <> 0 
--	begin 
--		rollback tran
--	end  
--end
--go
--ALTER proc [dbo].[sp_selectJobTaxesExcel] 
--@StartDate as date, 
--@EndDate as date 
--as
--begin
--select T1.jobNo ,T1.[ST Hours] ,T1.[OT Hours],T1.[Total Hours] ,T1.[Labor Cost] ,T1.[Scaffold-ADD] ,
--	T1.[3rd Party Cost],T1.[In House Vehicles],T1.[Scaffold],T1.[Company Equipment] ,T1.[Material Cost],T1.[Subcontract Cost] ,
--	T1.[Tools] ,T1.[Consumables] ,T1.[Other Cost] , T1.[Other Revanue],
--	ISNULL(txs.FICA,0) as 'FICA',
--	ISNULL(txs.FUI,0) as 'FUI',
--	ISNULL(txs.SUI,0) as 'SUI',
--	ISNULL(txs.WC,0) as 'WC',
--	ISNULL(txs.GenLiab,0) as 'Gen Liab',
--	ISNULL(txs.Umbr,0) as 'Umbr',
--	ISNULL(txs.Pollution,0) as 'Pollution',
--	ISNULL(txs.Healt,0) as 'Healt',
--	ISNULL(txs.Fringe,0) as 'Fringe',
--	ISNULL(txs.Small,0) as 'Small',
--	ISNULL(txs.PPE,0) as 'PPE',
--	ISNULL(txs.Consumable,0) as 'Consumable',
--	ISNULL(txs.Overhead,0) as 'Overhead',
--	ISNULL(txs.Profit,0) as 'Profit',
--	ISNULL(txP.FICA,0) as 'FICA P',
--	ISNULL(txP.FUI,0) as 'FUI P',
--	ISNULL(txP.SUI,0) as 'SUI P',
--	ISNULL(txP.WC,0) as 'WC P',
--	ISNULL(txP.GenLiab,0) as 'Gen Liab P',
--	ISNULL(txP.Umbr,0) as 'Umbr P',
--	ISNULL(txP.Pollution,0) as 'Pollution P',
--	ISNULL(txP.Healt,0) as 'Healt P',
--	ISNULL(txP.Fringe,0) as 'Fringe P',
--	ISNULL(txP.Small,0) as 'Small P',
--	ISNULL(txP.PPE,0) as 'PPE P',
--	ISNULL(txP.Consumable,0) as 'Consumable P',
--	ISNULL(txP.Overhead,0) as 'Overhead P',
--	ISNULL(txP.Profit,0) as 'Profit P'
--from(
--select distinct jb.jobNo,
--	ISNULL((select SUM(hw1.hoursST) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'ST Hours',
--	ISNULL((select SUM(hw1.hoursOT+hw1.hours3 ) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'OT Hours',
--	ISNULL((select SUM(hw1.hoursST+hw1.hoursOT+hw1.hours3) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'Total Hours',
--	ISNULL((select ROUND(SUM((hw1.hoursST*wc1.billingRate1)+(hw1.hoursOT*wc1.billingRateOT)+(hw1.hours3*wc1.billingRate3)),2) from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode= hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'Labor Cost',
--	ISNULL((select Scaffold from taxesST where jobNo = jb.jobNo),0) as 'Scaffold-ADD',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='D' and not mc1.[description] like '%scaf%')),0) AS '3rd Party Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='E' and not mc1.[description] like '%scaf%')),0) AS 'In House Vehicles',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and mc1.[description] like '%scaf%'),0) AS 'Scaffold',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='F' and not mc1.[description] like '%scaf%')),0) AS 'Company Equipment',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='M' and not mc1.[description] like '%scaf%')),0) AS 'Material Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='S' and not mc1.[description] like '%scaf%')),0) AS 'Subcontract Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='T' and not mc1.[description] like '%scaf%')),0) AS 'Tools',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='V' and not mc1.[description] like '%scaf%')),0) AS 'Consumables',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and (SUBSTRING(mc1.code ,LEN(mc1.code),1)='Y' and not mc1.[description] like '%scaf%')),0) AS 'Other Cost',
--	(select ROUND(ISNULL(SUM(amount),0),2) 
--		from expensesUsed as exu1 
--		inner join task as tk1 on tk1.idAux = exu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and po1.jobNo = wo1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and exu1.dateExpense between @StartDate and @EndDate ) as 'Other Revanue'
--from job as jb
--left join projectOrder as po on po.jobNo = jb.jobNo
--left join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.idPO
--left join task as tk on tk.idAuxWO = wo.idAuxWO 
--left join hoursWorked as hw on hw.idAux = tk.idAux
--) as T1 
--left join taxesST as txs on txs.jobNo = T1.jobNo
--left join taxesPT as txp on txp.jobNo = T1.jobNo
--end
--go
--ALTER proc [dbo].[sp_select_MyComapny_Info]
--@CompanyName varchar(30)
--as
--begin
--select cmp.name,
--	ha.city,
--	ha.providence,
--	CONCAT(ha.avenue , ' ',ha.number) as 'Address',
--	ha.postalCode,
--	cmp.idContact,
--	cmp.invoiceDescr,
--	ct.email,
--	ct.phoneNumber1 as 'PhoneNumber1',
--	ct.phoneNumber2 as 'PhoneNumber2',
--	cmp.img
--from company as cmp 
--left join HomeAddress as ha on ha.idHomeAdress	= cmp.idHomeAddress
--left join contact as ct on ct.idContact = cmp.idContact
--end
--go
----###############################################################################################
----########### CAMBIO PARA LOS REPORTES DE TIENEN PERDIEM ########################################
----###############################################################################################
--ALTER proc [dbo].[sp_Invoice_PO_Resume]
--@numberClient  int,
--@startDate date,
--@FinalDate date,
--@idPO bigint,
--@all bit
--as
--begin
--select T1.companyName,T1.payTerms,T1.city,T1.providence,T1.[Address],T1.postalCode,T1.jobNo,T1.custumerNo,T1.contractNo,T1.idPO,
--T1.[Total Hours PO],T1.[Total Hours],T1.[Total Labor],
--T1.[Total Expenses],T1.[Total PerDiem],T1.[3rdParty],T1.[ScRent],T1.[CoEQ],T1.[Material],T1.[Subcontractors],T1.[Other],T1.[ExtraCostMaterial]
--,T1.[Total Material]
--,T1.[Total Cost]
-- from (
--select 
--	cl.companyName,
--	cl.payTerms,
--	ha.city,
--	ha.providence,
--	CONCAT(ha.number,' ',ha.avenue) as 'Address',
--	ha.postalCode,
--	jb.jobNo,
--	jb.custumerNo,
--	isnull(jb.contractNo,'') as 'contractNo',
--	po.idPO,
	
--	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Hours PO',

--	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Hours',

--	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Labor',

--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate and ex1.expenseCode like '%travel%'),0)
--	as 'Total Expenses',

--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0)
--	as 'Total PerDiem',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.201-D' or mtc1.code = '2.255-D' or mtc1.code = '2.256-D' or mtc1.code = '2.202-D'or mtc1.code = '2.203-D'or mtc1.code = '2.303-F'or mtc1.code = '2.304-F' )),0) 
--	as '3rdParty',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.204-D' or mtc1.code = '2.207-D' or mtc1.code = '2.254-E' or mtc1.code = '2.257-E')),0) 
--	as 'ScRent',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.251-E' or mtc1.code = '2.252-D' or mtc1.code = '2.253-E' or mtc1.code = '2.301-F' or mtc1.code = '2.302-F'or mtc1.code = '2.907-Y')),0) 
--	as 'CoEQ',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.500-M' or mtc1.code = '2.515-M')),0) 
--	as 'Material',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.600-S')),0) 
--	as 'Subcontractors',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.900-Y' or mtc1.code = '2.911-Y')),0) 
--	as 'Other',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and not (
--		   mtc1.code = '2.201-D' or mtc1.code = '2.202-D' or mtc1.code = '2.203-D' or mtc1.code = '2.255-D' or mtc1.code = '2.256-D' or mtc1.code = '2.303-F' or mtc1.code = '2.304-F'
--		or mtc1.code = '2.204-D' or mtc1.code = '2.207-D' or mtc1.code = '2.254-E' or mtc1.code = '2.257-E' 
--		or mtc1.code = '2.252-D' or mtc1.code = '2.253-E' or mtc1.code = '2.301-F' or mtc1.code = '2.302-F' or mtc1.code = '2.251-E' or mtc1.code = '2.907-Y'
--		or mtc1.code = '2.500-M' or mtc1.code = '2.515-M' 
--		or mtc1.code = '2.600-S' 
--		or mtc1.code = '2.900-Y' or mtc1.code = '2.911-Y')),0) 
--	as 'ExtraCostMaterial',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate),0) 
--	as 'Total Material'
	
--	,
--	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0)
--	+
--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate),0)
--	+
--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate),0 )
--	as 'Total Cost'
--from job as jb 
--inner join clients as cl on cl.idClient = jb.idClient 
--left join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAddress
--inner join projectOrder as po on po.jobNo = jb.jobNo
--where cl.idClient = (select idClient from clients where numberClient = @numberClient)  and  po.idPO like iif(@all = 1 ,'%%',convert(nvarchar, @idPO)) 
--) as T1 where T1.[Total Labor]>0 or
--T1.[Total Expenses]>0 or T1.[Total PerDiem]>0 or T1.[3rdParty]>0 or T1.[ScRent]>0 or T1.[CoEQ]>0 or T1.[Material]>0 or T1.[Subcontractors]
-->0 or T1.[Other]>0 or t1.[ExtraCostMaterial]
-->0 or T1.[Total Material] >0
--end
--go
--ALTER proc [dbo].[Sp_All_Jobs]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int
--as
--begin
--select distinct
--T1.[jobNo],
--T1.[idPO],
--T1.[idWO],
--T1.[task],
--T1.[SAPNumber],
--T1.[numberEmploye],
--T1.[DAY],
--T1.[Employee Name],
--T1.[dateWorked],
--T1.[Code],
--SUM(T1.[Hours ST])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Hours ST',
--T1.[billingRate1],
--SUM(T1.[Hours OT])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Hours OT',
--T1.[billingRateOT],
--SUM(T1.[PerDiem])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'PerDiem',
--SUM(T1.[Travel])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Travel'
--from(
--select
--	jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',

--	hw.hoursST as 'Hours ST',
	
--	ISNULL(wc.billingRate1,0)AS 'billingRate1',

--	hw.hoursOT as 'Hours OT',
	
--	ISNULL(wc.billingRateOT,0)as 'billingRateOT',


--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem' ,
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
	
--	from hoursWorked as hw 
--		left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--		inner join employees as em on em.idEmployee = hw.idEmployee
--		inner join task as tk on tk.idAux = hw.idAux 
--		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--		inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--		inner join job as jb on jb.jobNo = po.jobNo 
--		inner join clients as cl on cl.idClient = jb.idClient
--		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and not wc.name like '%6.4%' 
--)as T1
--end
--go
--ALTER proc [dbo].[Sp_By_JobNumber]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigint,
--@all as bit
--as
--begin
--select distinct
--T1.[jobNo],
--T1.[idPO],
--T1.[idWO],
--T1.[task],
--T1.[SAPNumber],
--T1.[numberEmploye],
--T1.[DAY],
--T1.[Employee Name],
--T1.[dateWorked],
--T1.[Code],
--SUM(T1.[Hours ST])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours ST',
--T1.[billingRate1],
--SUM(T1.[Hours OT])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours OT',
--T1.[billingRateOT],
--SUM(T1.[PerDiem])      OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'PerDiem',
--SUM(T1.[Travel])       OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Travel'
--from(
--select jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
--	hw.hoursST
--	as 'Hours ST',
		
--	ISNULL(wc.billingRate1,0)as 'billingRate1',

--	hw.hoursOT
--	as 'Hours OT',

--	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate 
--			and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux	and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
--from hoursWorked as hw 
--left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--inner join employees as em on em.idEmployee = hw.idEmployee
--inner join task as tk on tk.idAux = hw.idAux 
--inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--inner join job as jb on jb.jobNo = po.jobNo 
--inner join clients as cl on cl.idClient = jb.idClient
--where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and not wc.name like '%6.4%' 
--)as T1
--end
--go
--ALTER proc [dbo].[Sp_Employee_Per_Diem_Sheets]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigInt,
--@all as bit
--as
--begin
--	select 
--	CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, xp.dateExpense)) ,xp.dateExpense)) as 'Weekending',
--			po.jobNo as 'Job Num',
--			po.idPO as 'PO',
--			CONCAT(wo.idWO,' ', tk.task) as 'Project Name',
--			ex.expenseCode as 'Project Description' ,
--			cl.companyName as 'Company Name',  
--			CONCAT(em.lastName,',',em.firstName,' ',em.middleName) as 'Employee Name',
--			em.numberEmploye as 'Emp: Number',
--			em.typeEmployee as 'Class', 
--			sum(xp.amount) as 'Amount'
--			from expensesUsed as xp 
--			inner join expenses as ex on xp.idExpense = ex.idExpenses
--			inner join employees as em on em.idEmployee = xp.idEmployee 
--			inner join task as tk on tk.idAux = xp.idAux
--			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--			inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
--			inner join job as jb on jb.jobNo = wo.jobNo 
--			inner join clients as cl on cl.idClient = jb.idClient
--			where xp.dateExpense  between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
--			group by CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, xp.dateExpense)) ,xp.dateExpense)),po.jobNo,po.idPO, wo.idWO, tk.task,cl.companyName, ex.expenseCode,
--			CONCAT(em.lastName,',',em.firstName,' ',em.middleName),em.numberEmploye,em.typeEmployee
--end
--go
----###############################################################################################
----########### CREACION DE METODO PARA ELIMINAR EMPLOYEES ########################################
----###############################################################################################
--create proc sp_delete_Employee
--@idEmployee varchar(36)
--as
--declare @Error as int
--begin 
--		begin try 
--			if (select count(*) from hoursWorked where idEmployee = @idEmployee)=0
--			begin
--				delete from payRate where idEmployee = @idEmployee
--				delete from employees where idEmployee = @idEmployee
--				delete from HomeAddress where idHomeAdress = (select top 1 idHomeAdress from employees where idEmployee = @idEmployee)
--				delete from contact where idContact = (select top 1 idContact from employees where idEmployee = @idEmployee)
--				if (select count(*) from employees where idEmployee = @idEmployee)=0
--				begin 
--					set @Error = 0
--				end
--				else
--				begin
--					set @Error = 1
--				end
--			end
--		end try	
--		begin catch
--			print 'Error'
--		end catch
--end
--go

----###############################################################################################
----########### CAMBIOS PARA AGREGAR FECHAS EN HOURSWORKED Y EXPENSESUSED #########################
----###############################################################################################

--alter table hoursWorked 
--add dayInserted  date
--go

--update hoursWorked set dayInserted = DATEADD (dd,iif(DATEPART (dw, dateWorked)=1,0,8-(DATEPART (dw, dateWorked))),dateWorked)
--go

  
--alter table expensesUsed 
--add dayInserted Date
--go

--update expensesUsed set dayInserted = DATEADD (dd,iif(DATEPART (dw, dateExpense)=1,0,8-(DATEPART (dw, dateExpense))),dateExpense) 
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V
----###############################################################################################
----########### CAMBIOS PARA AGREGAR LA TABLA DE EXPENSES CON JOBS ################################
----###############################################################################################

create table expensesJobs (
	idExpenses varchar(36) not null,
	jobNo  bigint not null,
	Category varchar(12),
	PayItemType varchar(30),
	WorkType varchar(30),
	CostCode varchar(30),
	CustomerPositionID varchar(30),
	CustomerJobPositionDescription varchar(30),
	CBSFullNumber varchar(30),
	skillType varchar(100)
 )
go

ALTER TABLE expensesJobs WITH CHECK ADD CONSTRAINT PK_idExpenses_jobNo_expensesJObs
PRIMARY KEY (idExpenses,jobNo)
go

ALTER TABLE expensesJobs WITH CHECK ADD CONSTRAINT fk_idExpenses_jobNo_expenesesJobs
FOREIGN KEY (idExpenses,jobNo) REFERENCES expensesJobs(idExpenses,jobNo)
go