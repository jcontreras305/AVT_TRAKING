use master
Go

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
insert into users values (NEWID(), 'admin' , 'admin')
GO

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
go
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
	go

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
go

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
go

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
go

ALTER TABLE EqIRHC ADD CONSTRAINT pk_type_thickness_EqIRHC
PRIMARY KEY ([type],thickness)
go

--##########################################################################################
--##################  TABLA DE EMPLOYEES ###################################################
--##########################################################################################

create table emails(
	email varchar(70) not null primary key,
	name varchar(50) ,
	status bit
)
go

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
go

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
go

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
go

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
go

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
go

ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT pk_idTag_idDrawingnum_projectId
PRIMARY KEY (tag,idDrawingNum,projectId)
go
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
go

ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT pk_idTag_idDrawingnum_projectId_Dism
PRIMARY KEY (tag,idDrawingNum,projectId)
go
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
go

ALTER TABLE EstCostEq ADD CONSTRAINT pk_tag_idDrawingnum_projectId_EstCostEq
PRIMARY KEY (tag,idDrawingNum,projectId)
go

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
go

ALTER TABLE EstCostPp ADD CONSTRAINT pk_tag_idDrawingNum_projecId
PRIMARY KEY (tag,idDrawingNum,projectId)
go

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
go

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
	idHorsWorked varchar(36)
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
go
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
	schedule varchar(10)
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
go

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
go

--##########################################################################################
--##################  TABLA DE INVOICE #####################################################
--##########################################################################################

create table invoice(
	invoice varchar(20)not null,
	idPO bigint not null,
	idClient varchar(36)not null,
	startDate date,
	FinalDate date,
)
go

alter table invoice add constraint pk_idClient_idPO_invoice
primary key (invoice,idPO)
go

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
	idClient varchar(36)
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
go

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
go

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
go
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
go

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

create table outgoing(
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
go

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
go

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
go

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
go

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
go

ALTER TABLE PpIRHC ADD CONSTRAINT pk_size_type_thickness_PpIRHC
PRIMARY KEY (size,[type],thickness)
go

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
go

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
go

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
go
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

create table productOutGoing(
	idProductOutGoing varchar(36) primary key not null,
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
go

--##########################################################################################
--##################  TABLA DE PROYECT ORDER ###############################################
--##########################################################################################

create table projectOrder(
	idPO bigint not null ,
	jobNo bigint not null 
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
go


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
go

ALTER TABLE RFIDiffEq WITH CHECK ADD CONSTRAINT pk_idRFIEq_tag_idDrawingNum
PRIMARY KEY(idRFIEq,tag,idDrawingNum)
go

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
go
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
go

ALTER TABLE RFIDiffScf WITH CHECK ADD CONSTRAINT pk_idRFI_tag_idDrawingNum
PRIMARY KEY(idRFI,tag,idDrawingNum)
go
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
go
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT pk_idRFIEq_tag
PRIMARY KEY (idRFIEq,tag)
go
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
go
ALTER TABLE RFIPiping WITH CHECK ADD CONSTRAINT pk_idRFIPp_idTagPp_idDrawingNum
PRIMARY KEY (idRFIPp,tag,idDrawingNum)
go
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
go
ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT pk_idRFI_Tag
PRIMARY KEY (idRFI,Tag)
go
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
go
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
go

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
	days int
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
go

--##########################################################################################
--##################  TABLA DE SCFESTPROYECT #################################################
--##########################################################################################


CREATE TABLE scfEstProyect(
	ccnum varchar(30) NOT NULL primary key,
	unit varchar(30) NOT NULL
)
go

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
go

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
go

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
go

alter table tempInvoice add constraint pk_invoice_TempInvoice
primary key (invoice, idPO)
go

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
[R6 Adders] varchar(15)
)
GO
--##########################################################################################
--##################  TABLA DE TRACKFORMATELEMENTS #########################################
--##########################################################################################
create table TrackFormatColums(
	idTFE varchar(36) primary key not null,
	idClient varchar(36),
	[Record ID]varchar(31),
	[Force or Reject]varchar(31),
	[Source]varchar(31),
	[Date]varchar(31),
	[Order Type]varchar(31),
	[Location ID]varchar(31),
	[Company Code]varchar(31),
	[Resource ID]varchar(31),
	[Resource Name]varchar(31),
	[Area]varchar(31),
	[Group Name]varchar(31),
	[Agreement]varchar(31),
	[Skill Type]varchar(31),
	[Shift]varchar(31),
	[Level 1 ID]varchar(31),
	[Level 2 ID]varchar(31),
	[Level 3 ID]varchar(31),
	[Level 4 ID]varchar(31),
	[Hours Total]varchar(31),
	[Hours Total Activity Code]varchar(31),
	[S/T (Hrs)]varchar(31),
	[S/T Hrs Activity Code]varchar(31),
	[O/T (Hrs)]varchar(31),
	[O/T Hrs Activity Code]varchar(31),
	[D/T (Hrs)]varchar(31),
	[D/T Hrs Activity Code]varchar(31),
	[Extra Charges $]varchar(31),
	[Extra Charges $ Activity Code]varchar(31),
	[Extra]varchar(31),
	[Extra 1]varchar(31),
	[Extra 2]varchar(31),
	[Add Time]varchar(31),
	[Pay Type]varchar(31),
	[R4 (Hrs)]varchar(31),
	[R5 (Hrs)]varchar(31),
	[R6 (Hrs)]varchar(31),
	[GL Account]varchar(31),
	[ST Adders]varchar(31),
	[OT Adders]varchar(31),
	[DT Adders]varchar(31),
	[R4 Adders]varchar(31),
	[R5 Adders]varchar(31),
	[R6 Adders]varchar(31)
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

create table workCode(
	idWorkCode int primary key not null,
	name varchar(50),
	description varchar(50),
	billingRate1 float,
	billingRateOT float,
	billingRate3 float,
	EQExp1 varchar(50),
	EQExp2 varchar(50) 
)
GO

INSERT INTO workCode values
(95,'LMP','LMP',0,0,0,'',''),
(96,'LMI','LMI',0,0,0,'',''),
(97,'LMS','LMS',0,0,0,'',''),
(98,'LMA','LMA',0,0,0,'',''),
(99,'LML','LML',0,0,0,'','')
GO

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
go

--##########################################################################################
--##################  FOREIG KEYS EQIRHC ###################################################
--##########################################################################################

ALTER TABLE EqIRHC WITH CHECK ADD CONSTRAINT fk_type_EqIRHC
FOREIGN KEY ([type]) REFERENCES insFitting([type])
ON UPDATE CASCADE
ON DELETE CASCADE
go

--##########################################################################################
--##################  FOREIG KEYS ESTCOSTBUILD #############################################
--##########################################################################################

ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_tag_EstCostBuild
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
	
go

ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostBuild
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_projectId_EstCostBuild
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
go
--##########################################################################################
--##################  FOREIG KEYS ESTCOSTDISM ##############################################
--##########################################################################################

ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_tag_EstCostDism
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
go

ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostDism
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_projectId_EstCostDism
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
go

--##########################################################################################
--##################  FOREIG KEYS ESTCOSTEQ ################################################
--##########################################################################################

--ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idEquipmentEst_EstCosteq
--FOREIGN KEY (tag) REFERENCES equipmentEst(idEquipmentEst)
--go 

ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCosteq
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
go 

ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idEquipmentEst_EstCosteq
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
go 

--##########################################################################################
--##################  FOREIG KEYS ESTCOSTSCF ###############################################
--##########################################################################################

ALTER TABLE EstCostPp ADD CONSTRAINT fk_idDrawingNum_EstCostPp
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
on update cascade
go

ALTER TABLE EstCostPp ADD CONSTRAINT fk_projectId_EstCostPp
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
go
--##########################################################################################
--##################  FOREIG KEYS ESTCOSTSCF ###############################################
--##########################################################################################

ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_tag_EstCosScf
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)

go

ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostScf
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
go

ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_projectId_EstCostScf
FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
go

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

ALTER TABLE eqInsUnitRate WITH CHECK ADD CONSTRAINT PK_type_think_eqinsUnitRate
PRIMARY KEY([type],thick)
GO

ALTER TABLE eqInsUnitRate WITH CHECK ADD CONSTRAINT fk_type_eqInsUnitRate
FOREIGN KEY([TYPE]) REFERENCES insFitting([type])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS EQPAINTUNITRATE ##########################################
--##########################################################################################

ALTER TABLE eqPaintUnitRate WITH CHECK ADD CONSTRAINT pk_systemPntEq_pntFitting
PRIMARY KEY (systemPntEq,pntOption)
go

ALTER TABLE eqPaintUnitRate WITH CHECK ADD CONSTRAINT fk_pntFitting_eqPaintUnitRate
FOREIGN KEY (pntOption) REFERENCES pntFitting(pntOption)
on update cascade
on delete cascade
go

--##########################################################################################
--##################  FOREIG KEYS EQUIPMENT PROGRESS #######################################
--##########################################################################################

ALTER TABLE equipmentProgress WITH CHECK ADD CONSTRAINT fk_idTag_EquipmentProgress
FOREIGN KEY (tag) REFERENCES equipmentEst(idEquimentEst)
ON UPDATE CASCADE
ON DELETE CASCADE
go

--##########################################################################################
--##################  FOREIG KEYS EXISTENCES ###############################################
--##########################################################################################

ALTER TABLE [dbo].[existences]  WITH CHECK ADD  CONSTRAINT [fk_idDM_existenece] FOREIGN KEY([idDM])
REFERENCES [dbo].[detalleMaterial] ([idDM])
GO

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

ALTER TABLE expensesUsed WITH CHECK ADD CONSTRAINT fk_idHoursWorked_expensesUsed FOREIGN KEY (idHorsWorked) 
REFERENCES  hoursWorked (idHorsWorked)
go

--##########################################################################################
--##################  FOREIG KEYS HOURS WORKED #############################################
--##########################################################################################

ALTER TABLE    hoursWorked   WITH CHECK ADD  CONSTRAINT  fk_idEmployee_hoursWorked  FOREIGN KEY( idEmployee )
REFERENCES    employees  ( idEmployee )
GO
ALTER TABLE hoursWorked  WITH CHECK ADD  CONSTRAINT fk_idWorkCode_hoursWorked FOREIGN KEY(idWorkCode)
REFERENCES workCode (idWorkCode)
GO
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
go

ALTER TABLE KPI WITH CHECK ADD CONSTRAINT fk_jobNo_KPI
FOREIGN KEY (jobNo) REFERENCES job(jobNo)
go

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

ALTER TABLE outgoing ADD CONSTRAINT fk_jobNum_outgoing
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
go

ALTER TABLE pipingMaterial WITH CHECK ADD CONSTRAINT fk_type_pipingmaterial
FOREIGN KEY ([type]) REFERENCES insFitting([type])
ON UPDATE CASCADE
ON DELETE CASCADE
go
--##########################################################################################
--##################  FOREIG KEYS PIPING PROGRESS ##########################################
--##########################################################################################

ALTER TABLE pipingProgress WITH CHECK ADD CONSTRAINT fk_Tag_pipingProgress
FOREIGN KEY (tag) REFERENCES pipingEst(idPipingEst)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--##########################################################################################
--##################  FOREIG KEYS PPINSUNITRATE ############################################
--##########################################################################################

ALTER TABLE ppInsUnitRate WITH CHECK ADD CONSTRAINT PK_size_type_thick_PPInsUnitRate
PRIMARY KEY (size,[type],thick)
GO

--##########################################################################################
--##################  FOREIG KEYS PPIRHC ###################################################
--##########################################################################################

ALTER TABLE PpIRHC WITH CHECK ADD CONSTRAINT fk_type_PpIRHC
FOREIGN KEY ([type]) REFERENCES insFitting([type])
ON UPDATE CASCADE
ON DELETE CASCADE
go

--##########################################################################################
--##################  FOREIG KEYS PPPAINTUNITRATE ##########################################
--##########################################################################################

ALTER TABLE ppPaintUnitRate WITH CHECK ADD CONSTRAINT pk_systemPntPP_pntOption_size
PRIMARY KEY (systemPntPP,pntOption,size) 
go

ALTER TABLE ppPaintUnitRate WITH CHECK ADD CONSTRAINT Fk_pntOption_pntFitting
FOREIGN KEY (pntOption) REFERENCES pntFitting(pntOption) 
on update cascade
on delete cascade
go

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

ALTER TABLE productOutGoing ADD CONSTRAINT fk_ticketNum_productOutGoing
FOREIGN KEY (ticketNum) REFERENCES outgoing(ticketNum)
GO

ALTER TABLE productOutGoing ADD CONSTRAINT fk_idProduct_productOutGoing
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
go

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
ALTER TABLE RFIEquipment WITH CHECK ADD CONSTRAINT fk_idDrawingNum_RFIEquipment
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
go
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
go

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_tag_RFIScaffoldEst
FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
on update cascade
on delete cascade
go

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_newIdLaborRate_RFIScaffoldEst
FOREIGN KEY (newIdLaborRate) REFERENCES laborRate(idLaborRate)
go

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_lastdLaborRate_RFIScaffoldEst
FOREIGN KEY (lastIdLaborRate) REFERENCES laborRate(idLaborRate)
go

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_newIdSCFUR_RFIScaffoldEst
FOREIGN KEY (newIdSCFUR) REFERENCES scfUnitsRates(IdSCFUR)
go

ALTER TABLE RFIScaffoldEst WITH CHECK ADD CONSTRAINT fk_lastIdSCFUR_RFIScaffoldEst
FOREIGN KEY (lastIdSCFUR) REFERENCES scfUnitsRates(IdSCFUR)
go
--##########################################################################################
--##################  FOREIG KEYS SCAFFOLD INFORMATION #####################################
--##########################################################################################

ALTER TABLE scaffoldInformation WITH CHECK ADD CONSTRAINT fk_type_scaffoldInformation
FOREIGN KEY (type) REFERENCES rental(type)
GO

ALTER TABLE scaffoldInformation WITH CHECK ADD CONSTRAINT fk_tag_scaffoldInformation
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
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
go

--##########################################################################################
--##################  FOREIG KEYS SCAFFOLD TRAKING #########################################
--##########################################################################################

ALTER TABLE scaffoldTraking WITH CHECK ADD CONSTRAINT fk_idAux_scaffoldTraking
FOREIGN KEY (idAux) REFERENCES task(idAux)
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
go
--##########################################################################################
--##################  FOREIG KEYS SCFFOLDEST ###############################################
--##########################################################################################

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idLaborRate_scaffoldEst
FOREIGN KEY (idLaborRate) REFERENCES laborRate(idLaborRate)
go

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idEnviroment_scaffoldEst
FOREIGN KEY (idEnviroment) REFERENCES enviroment(idEnviroment)
go

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idSCFUR_scaffoldEst
FOREIGN KEY (idSCFUR) REFERENCES scfUnitsRates(idSCFUR)
go

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idDrawingNum_scaffoldEst
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
ON UPDATE CASCADE
ON DELETE CASCADE
go
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
go

--##########################################################################################
--##################  FOREIG KEYS TRAKFORMATCOLUMS #########################################
--##########################################################################################

ALTER TABLE TrackFormatColums WITH CHECK ADD CONSTRAINT fk_idClient_TrackFormatColums
FOREIGN KEY (idClient) REFERENCES clients(idClient)
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

--========================================================================================================
--===================  PROCEDIMIENTOS ALMACENDADOS =======================================================
--========================================================================================================
create proc [dbo].[sp_actualizaMaterial]
@idMaterial varchar(36),
@nombreN varchar(50),
@numeroN int,
@idVendorN varchar(36),
@statusN char(1),
--datos viejos
@idVendorV varchar(36),
@class varchar(20),
@msg varchar(100) out
as 
declare @vendor1 varchar(36)
declare @vendor2 varchar(36)
declare @error int
begin
	begin tran 
		begin try 
			set @error = 0
			if @idVendorN = @idVendorV
			begin --solo cambian los datos de material 
				update material set name = @nombreN , estatus = @statusN,code = iif(@class = '',NUll,@class) where idMaterial = @idMaterial 
				set @msg = 'Successful.'
			end
			else --Cambio de Vendedor
			begin
				set @Vendor2 = (select  top 1 dm.idVendor from material as ma right join detalleMaterial as dm  on ma.idMaterial = dm.idMaterial where ma.name = @nombreN) 
				if @vendor2 = @idVendorN begin
					set @msg = 'Rigth now exists a material whit the same Vendor.'
					set @error = 1
				end
				else begin
				if (select  COUNT(*) from material as ma right join detalleMaterial as dm  on ma.idMaterial = dm.idMaterial where ma.name = @nombreN)=0
				begin 
					insert into detalleMaterial values (NEWID(),'','','',0.0,'',0.0,@idMaterial,@idVendorN,'')
				end
				else
				begin
					update detalleMaterial set idVendor = @idVendorN where idMaterial = @idMaterial and idVendor = @idVendorV
				end
				update material set name = @nombreN , estatus = @statusN,code = iif(@class = '',NUll,@class) where idMaterial = @idMaterial 
				set @msg = 'Successful.'
				end
			end
		end try
		begin catch
			goto solveproblem
		end catch
	commit tran 
	solveproblem:
	if @error <> 0 
	begin 
		rollback tran
	end 
end
GO

create proc [dbo].[Sp_All_Jobs]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
select distinct
	jb.jobNo,
	po.idPO,
	wo.idWO,
	tk.task,
	em.SAPNumber,
	em.numberEmploye, 
	datename(dw,hw.dateWorked) as 'DAY',
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
	hw.dateWorked,
	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',

	case when ((select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked between @startdate and @finaldate and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked between @startdate and @finaldate and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours ST',
	
	ISNULL(wc.billingRate1,0)AS 'billingRate1',

	case when ((select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked between @startdate and @finaldate and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked between @startdate and @finaldate and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours OT',

	ISNULL(wc.billingRateOT,0)as 'billingRateOT',
	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Per-Diem') ,0) as 'PerDiem' ,

	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') ,0) as 'Travel' 
	 
	from employees as em 
		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
		left join workCode as wc on wc.idWorkCode = hw.idWorkCode
		inner join task as tk on tk.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum
	order by 
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
	hw.dateWorked
end
GO

create proc [dbo].[sp_DeleteModAux]
@tag varchar(20),
@modID varchar(36),
@msg varchar(120) output
as
declare @error as int = 0
declare @flag as int
declare @idProduct as int
declare @qty as float
begin 
	if (select COUNT(*) from modification where idModAux = @modID and tag = @tag) >0 
	begin 
		begin tran	
			begin try
				set	@msg = CONCAT('Error trying to delete Activity Hours from Modification ',@modID)
				delete from activityHours where tag = @tag and idModAux = @modID
				set	@msg = CONCAT('Error trying to delete Material Handeling from Modification ',@modID)
				delete from materialHandeling where tag = @tag and idModAux = @modID
				set	@msg = CONCAT('Error trying to delete Scaffold Information from Modification ',@modID)
				delete from scaffoldInformation where tag = @tag and idModAux=@modID
				set @flag = (select COUNT(*) from productModification where tag = @tag and idModAux = @modID)
				while (@flag > 0)
				begin
					select  @qty = quantity ,@idProduct = idProduct from (select top 1  quantity,idProduct from productModification where tag = @tag and idModAux = @modID) as t1
					set	@msg = CONCAT('Error trying to delete Product Modification Record from Modification: ', @modID,', with the idProduct: ',CONVERT(varchar(12), @idProduct))
					select quantity from product where idProduct = @idProduct
					update product set quantity = quantity + @qty where idProduct = @idProduct
					select quantity from productTotalScaffold where idProduct = @idProduct and tag = @tag
					update productTotalScaffold set quantity = quantity + IIF(@qty>0,@qty*-1,@qty*-1) where idProduct = @idProduct and tag = @tag
					delete from productModification where idProduct = @idProduct and tag = @tag and idModAux = @modID
					delete from productTotalScaffold where quantity = 0 and tag = @tag
					set @flag = ( select COUNT(*) from productModification where tag = @tag and idModAux = @modID)
				end
				delete from modification where idModification = @modID and tag = @tag	
				set @msg = 'Successful'	 
			end try
			begin catch
				set @error = 1
				goto solveProblem
			end catch
		commit tran 
		print @msg	
		solveProblem:
		if @error <> 0
		begin 
			rollback tran 
		end
	end
end
go

create proc [dbo].[sp_Insert_Cient] 
	@ClientID int,
	@FirstName varchar (30),
	@MiddleName varchar (30),
	@LastName varchar (30),
	@CompanyName varchar (50),
	@Status char(1),
	--Contact
	@phoneNumer1 varchar(13),
	@phoneNumer2 varchar(13),
	@email varchar(50),
	--Addres
	@avenue varchar(80),
	@number int,
	@city varchar (20),
	@providence varchar (20),
	@postalcode int,
	--Photo
	@img image,
	@payTerms varchar(30)
as
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
declare @idClient varchar(36) 
declare @idContact varchar(36)
declare @idHomeAdress varchar(36)
begin 
	begin tran 
		begin try
			--se inserta un contacto
			
				set @idContact = NEWID() 
				insert into contact values(@idContact,@phoneNumer1,@phoneNumer2,@email)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			
				set @idHomeAdress = NEWID()
				insert into HomeAddress values (@idHomeAdress , @avenue , @number , @city , @providence , @postalCode)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			
				set @idClient = NEWID()
				insert into clients values (@idClient , @ClientID, @FirstName, @MiddleName, @LastName , @CompanyName, @idContact , @idHomeAdress ,@Status,@img,@payTerms)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 

				insert into TrackDefaultElements values(NEWID(),@idClient,'','','','','','','','','','','','','','','','','','','','','','','','','','','','')
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
				
				insert into TrackFormatColums values(NEWID(),@idClient,'Record ID1','Force or Reject1','Source1','Date1','Order Type1','Location ID1','Company Code1','Resource ID1','Resource Name1','Area1','Group Name1','Agreement1','Skill Type1','Shift1','Level 1 ID1','Level 2 ID1','Level 3 ID1','Level 4 ID1','Hours Total1','Hours Total Activity Code1','S/T (Hrs)1','S/T Hrs Activity Code1','O/T (Hrs)1','O/T Hrs Activity Code1','D/T (Hrs)1','D/T Hrs Activity Code1','Extra Charges $1','Extra Charges $ Activity Code1','Extra1','Extra 11','Extra 21','Add Time1','Pay Type1','R4 (Hrs)1','R5 (Hrs)1','R6 (Hrs)1','GL Account1','ST Adders1','OT Adders1','DT Adders1','R4 Adders1','R5 Adders1','R6 Adders1')
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
		end try
		begin catch
			goto solveproblem
		end catch
	commit tran
	solveproblem:
	if @error <> 0
	begin 
		rollback tran 
	end
end
go

create proc [dbo].[sp_insert_Employee]
	--general
	@numberEmploye int, 
	@firstName varchar(30),
	@lastName varchar(25),
	@middleName varchar(25),
	@socialNumber varchar(14),
	@SAPNumber int,
	@photo image,
	@estatus char(1),
	--contact
	@phoneNumber1 varchar(13),
	@phoneNumber2 varchar(13),
	@email varchar(50),
	--address
	@avenue varchar(80),
	@number int,
	@city varchar(20), 
	@providence varchar(20),
	@postalCode int,
	--pay
	@payRate1 float,
	@payRate2 float, 
	@payRate3 float,
	--type 
	@type varchar(20),
	--perdiem
	@perdiem bit
as 
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
declare @idEmployee varchar(36) 
declare @idContact varchar(36)
declare @idHomeAdress varchar(36)
declare @idPayRate varchar(36)
begin
	begin tran --inicio tran
		begin try --inicio try
			--if @phoneNumber1 <> '' or @email<> '' begin -- si existe un telefono o un correo entra 
				set @idContact = NEWID() 
				insert into contact values(@idContact,@phoneNumber1,@phoneNumber2,@email)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end  -- si existe un error en al insertar solo vamos a solveproblem y nos evitamos lo demas
			--end
			--if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
				set @idHomeAdress = NEWID()
				insert into HomeAddress values (@idHomeAdress , @avenue , @number , @city , @providence , @postalCode)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				
			--end
			--if @firstName <> '' or @numberEmploye > 0 begin	
				set @idEmployee = NEWID()
				insert into employees values (@idEmployee , @numberEmploye , @firstName , @lastName , @middleName, @socialNumber , @SAPNumber, @photo , @idHomeAdress , @idContact ,@estatus,@type,@perdiem)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			--end
			--if @payRate1 <> '' begin
				set @idPayRate = NEWID()
				insert into payRate values (@idPayRate,@payRate1,@payRate2 ,@payRate3,@idEmployee,GETDATE())
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			--end
		end try	
		begin catch
			goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
		end catch
	commit tran 
	solveproblem:
	if @error <> 0
	begin 
		rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
	end
end
go


CREATE proc  [dbo].[sp_insert_Material]
@nombre varchar(50),
@numero int,
@idVendor varchar(36),
@status char(1),
@class varchar(20),
@msg varchar(100) out
as
declare @idMaterial varchar(36)
declare @idDM varchar(36)
declare @error int
begin
	begin tran
		begin try	 
			set @idMaterial = NEWID()
			set @idDM = NEWID()
			if not @nombre = '' and not @idVendor = ''
			begin 
				if (select count(*) from material where number = @numero or name = @nombre)=0
				begin
					insert into material values (@idMaterial,@numero,@nombre,@status,iif(@class='',Null,@class))
					insert into detalleMaterial values (@idDM,'','','',0.0,'',0.0,@idMaterial,@idVendor,'')
					insert into existences values (@idDM , 0.0)
					set @msg= 'Successful'
				end
				else
				begin
					set @msg = CONCAT('The Material ',@numero,' was inserted.')
				end
			end
			else 
			begin 
				set @error = 1
				goto solveProblem
			end
		end try
		begin catch
			goto solveProblem
		end catch
	commit tran
	solveProblem:
	if @error <> 0 
	begin 
		rollback tran
		set @msg = concat('Is problably that the Material ',@nombre,' have been inserted, or try to changue the Vendor')
	end  
end
GO 

CREATE procedure [dbo].[sp_insert_Material_Excel]
@nombre varchar(50),
@numero int,
@idVendor int,
@status char(1),
@resourceMaterial varchar(50),
@unitMesurement varchar(20),
@type varchar(30),
@price float,
@description varchar(100),
@size float,
@partNum varchar(15)
as
declare @idMaterial varchar(36)
declare @idDM varchar(36)
declare @error int
begin
	begin tran
		begin try	 
			set @idMaterial = NEWID()
			set @idDM = NEWID()
			if not @nombre = '' and not @idVendor = '' and (select count(*) from material where number =@numero) =0
			begin 
				insert into material values (@idMaterial,@numero,@nombre,@status,NULL)
				insert into detalleMaterial values (@idDM,@resourceMaterial,@unitMesurement,@type,@price,@description,@size,@idMaterial, (select idVendor from vendor where numberVendor = @idVendor),@partNum)
				insert into existences values (@idDM , 0.0)
			end
			else 
			begin 
				set @error = 1
				goto solveProblem
			end
		end try
		begin catch
			goto solveProblem
		end catch
	commit tran
	solveProblem:
	if @error <> 0 
	begin 
		rollback tran
	end  
end
GO

create procedure sp_insert_Vendor
@nombre varchar(50),
@numero int,
@description varchar(80),
@status char(1),
@msg varchar(100) output
as
declare @idVendor varchar(36)
declare @error int
begin
	begin tran
		begin try	 
			set @idVendor = NEWID()
			if (select COUNT(*) from vendor where exists (select name from vendor where name like @nombre or numberVendor = @numero))=0
			begin
				insert into vendor values (@idVendor,@numero,@nombre,@description,@status)
				set @msg = 'Successful'
			end 
			else 
			begin 
				set @error = 1
				goto solveProblem
			end
		end try
		begin catch
			goto solveProblem
		end catch
	commit tran
	solveProblem:
	if @error <> 0 
	begin 
		rollback tran
		set @msg = CONCAT('Is probably that the Vendor ',@nombre,' have been registrated.')
	end  
end

GO

create proc [dbo].[sp_Update_Client]
	@idCL varchar(36),
	@ClientID int,
	@FirstName varchar (30),
	@MiddleName varchar (30),
	@LastName varchar (30),
	@CompanyName varchar (50),
	@Status char(1),
	--Contact
	@idContact varchar(36),
	@phoneNumer1 varchar(13),
	@phoneNumer2 varchar(13),
	@email varchar(50),
	--Addres
	@idAddres varchar(36),
	@avenue varchar(80),
	@number int,
	@city varchar (20),
	@providence varchar (20),
	@postalcode int,
	@img image,
	@payTerms varchar(30)
as
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
begin 
	begin tran 
		begin try
			--se inserta un contacto

				update contact set phoneNumber1= @phoneNumer1 , phoneNumber2=@phoneNumer2 ,email = @email where idContact = @idContact
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
				update HomeAddress set avenue= @avenue, number = @number , city=@city , providence =@providence, postalCode = @postalcode where idHomeAdress = @idAddres
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
				update  clients set firstName= @FirstName,middleName= @MiddleName,lastName= @LastName ,companyName=@CompanyName,estatus = @Status, photo = @img ,payTerms = @payTerms where idClient = @idCL
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
		end try
		begin catch
			goto solveproblem
		end catch
	commit tran
	solveproblem:
	if @error <> 0
	begin 
		rollback tran 
	end
end
GO

create proc sp_UpdateTotalSpendTask
 @idAux varchar(36)
as
declare @total as float
declare @horasST as float
declare @horasOT as float
declare @horasO3 as float
declare @expenses as float
declare @material as float
begin

	--Total de gastos de horas St
	set @horasST = 		
		(select top 1 
		(select SUM(T2.Amount) as 'Total Amount ST' from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
		from (select idHorsWorked,hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=tk.idAux)as T1    
		group by T1.idWorkCode) as T2
		) as 'ST'
	from 
	task as tk 
	where tk.idAux = @idAux
	)
	--Total de gastos de horas OT
	set @horasOT =		
		(select top 1 
		(select SUM(T2.Amount) as 'Total Amount OT' from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
		from (select idHorsWorked,hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=tk.idAux)as T1    
		group by T1.idWorkCode) as T2
		) as 'OT'
	from
	task as tk
	where tk.idAux = @idAux
	)
	--Total gastos horas 3
	set @horasO3 =
		(select top 1 
		(select SUM(T2.Amount) as 'Total Amount OT' from 
		(select SUM(T1.hours3*T1.billingRate3) AS 'Amount'
		from (select idHorsWorked,hours3, hw.idWorkCode , billingRate3  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=tk.idAux)as T1    
		group by T1.idWorkCode) as T2
		) as 'OT3'
	from 
	task AS tk 
	where tk.idAux = @idAux
	)

	--'Total Expenses Spend'
	set @expenses = (select top 1 (select SUM( amount) from expensesUsed where idAux = @idAux))

	--Total Material Spend
	set @material = (select top 1 (select sum (amount) from materialUsed where idAux = @idAux))
	
	if (@horasST IS Null) 
	begin 
		set @horasST =0.0
	end
	if (@horasOT IS NUll)
	begin 
		set @horasOT =0.0
	end
	if (@horasO3  IS NULL)
	begin 
		set @horasO3 =0.0
	end
	if (@expenses IS NULL)
	begin 
		set	@expenses=0.0 
	end
	if (@material IS NULL)
	begin 
		set	@material =0.0
	end

	set @total = @horasST + @horasOT + @horasO3 + @expenses + @material

	update task set totalSpend = @total where idAux = @idAux
end
go


CREATE proc [dbo].[sp_update_Employee]
	@idEmployee varchar(36),
	@idAddress varchar(36),
	@idContact varchar(36),
	--general
	@numberEmploye int, 
	@firstName varchar(30),
	@lastName varchar(25),
	@middleName varchar(25),
	@socialNumber varchar(14),
	@SAPNumber int,
	@photo image,
	@estatus char(1),
	--contact
	@phoneNumber1 varchar(13),
	@phoneNumber2 varchar(13),
	@email varchar(50),
	--address
	@avenue varchar(80),
	@number int,
	@city varchar(20), 
	@providence varchar(20),
	@postalCode int,
	----pay
	--@payRate1 float,
	--@payRate2 float, 
	--@payRate3 float,
	--type 
	@type varchar(20),
	@perdiem bit,
	@msg varchar(50) output
as 
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
begin
	begin tran --inicio tran
		begin try --inicio try
			--if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
				set @msg = 'Error at moment to save Address data'
				update HomeAddress set avenue = @avenue ,number =@number ,city =@city ,providence =@providence ,postalcode = @postalCode where idHomeAdress = @idAddress
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				
				set @msg = 'Error at moment to save Contact data'
				update contact set phoneNumber1 =@phoneNumber1 , phoneNumber2 =@phoneNumber2 , email = @email where idContact = @idContact
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			--end
			----if @payRate1 <> '' begin
			--	set @msg = 'Error at moment to save Pay Rate data'
			--	update payRate set payRate1 = @payRate1,payRate2= @payRate2 , payRate3 = @payRate3 where idPayRate = @idPay and idEmployee = @idEmployee
			--	if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			----end
			--if @firstName <> '' or @numberEmploye > 0 begin
				set @msg = 'Error at moment to save Employee data'	
				update employees set  numberEmploye = @numberEmploye ,firstName = @firstName , lastName = @lastName ,middleName = @middleName,socialNumber = @socialNumber ,SAPNumber = @SAPNumber,photo = @photo , estatus = @estatus,typeEmployee = @type, perdiem = @perdiem where idEmployee = @idEmployee
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			--end
			set @msg = 'Succesfull'
		end try	
		begin catch
			goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
		end catch
	commit tran 
	solveproblem:
	if @error <> 0
	begin 
		rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
		return @msg
	end
end
go
--##############################################################################################
--################## SP REPORT Client Billings Re Cap By Project ###############################
--##############################################################################################

CREATE proc Client_Billings_Re_Cap_By_Project
@startdate as date, 
@finaldate as date,
@clientnum as int
as 
begin

set @startdate = ISNULL(@startDate,GETDATE())
set @finaldate = ISNULL(@finaldate,GETDATE())
set @clientnum = ISNULL(@clientnum,(select top 1 numberClient from clients)) 

select T2.companyName,T2.[Work Order],T2.jobNo,T2.PO,T2.[Project Desription],
T2.[Hours Ext],T2.[Total Hours],T2.[Hours ST],T2.[Billings ST],T2.[Hours OT],T2.[Billings OT],
T2.Complete,T2.[Es-Hrs],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend],T2.Estimate from
(
	select cl.companyName,concat(wo.idWO,' ',ts.task) as 'Work Order', jb.jobNo,po.idPO as 'PO',ts.description as 'Project Desription',
    	case when (select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end as 'Hours Ext',

	(case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end +
	case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end) as 'Total Hours',

	case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end as 'Hours ST',
	
	(select CONCAT('$' , case when  SUM(T2.Amount) is null then '0'
	else SUM(T2.Amount) end
	) as 'Billings ST' from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) as 'Billings ST',

	case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end as 'Hours OT',
	
	(select CONCAT('$' , case when SUM(T2.Amount) is null then '0'
	else SUM(T2.Amount) end ) as 'Billings OT' from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) as 'Billings OT',

	concat(ts.percentComplete,'%') as 'Complete',

	ts.estimateHours as 'Es-Hrs',

	concat('$', case when (select sum(amount) from expensesUsed as exu
inner join task as tk on exu.idAux=tk.idAux
inner join workOrder as wo1 on wo1.idAuxWO=tk.idAuxWO
inner join projectOrder as po1 on po1.idPO=wo1.idPO and po1.jobNo=wo1.jobNo
inner join job as jb1 on jb1.jobNo=po1.jobNo
 where  tk.idAux=ts.idAux and wo1.idAuxWO=wo.idAuxWo and po1.idPO=po.idPo and jb1.jobNo=jb.jobNo and po1.idPO = po.idPO and dateExpense between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from expensesUsed as exu
inner join task as tk on exu.idAux=tk.idAux
inner join workOrder as wo1 on wo1.idAuxWO=tk.idAuxWO
inner join projectOrder as po1 on po1.idPO=wo1.idPO and po1.jobNo=wo1.jobNo
inner join job as jb1 on jb1.jobNo=po1.jobNo
 where  tk.idAux=ts.idAux and wo1.idAuxWO=wo.idAuxWo and po1.idPO=po.idPo and jb1.jobNo=jb.jobNo and po1.idPO = po.idPO and dateExpense between @startdate and @finaldate) end) as 'Total Expenses',
	
	CONCAT('$', case when (select sum(amount) from materialUsed as mau
inner join task as tk on mau.idAux=tk.idAux
inner join workOrder as wo1 on wo1.idAuxWO=tk.idAuxWO
inner join projectOrder as po1 on po1.idPO=wo1.idPO and po1.jobNo=wo1.jobNo
inner join job as jb1 on jb1.jobNo=po1.jobNo
where  tk.idAux=ts.idAux and wo1.idAuxWO=wo.idAuxWo and po1.idPO=po.idPo and jb1.jobNo=jb.jobNo and po1.idPO = po.idPO and dateMaterial between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from materialUsed as mau
inner join task as tk on mau.idAux=tk.idAux
inner join workOrder as wo1 on wo1.idAuxWO=tk.idAuxWO
inner join projectOrder as po1 on po1.idPO=wo1.idPO and po1.jobNo=wo1.jobNo
inner join job as jb1 on jb1.jobNo=po1.jobNo
where  tk.idAux=ts.idAux and wo1.idAuxWO=wo.idAuxWo and po1.idPO=po.idPo and jb1.jobNo=jb.jobNo and po1.idPO = po.idPO and dateMaterial between @startdate and @finaldate) end) as 'Total Material',
	
	concat('$', (case when  (select SUM(T2.Amount)from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount)from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) end  +

	case when (select SUM(T2.Amount) from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount) from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) end +

	case when (select sum(amount) from expensesUsed as exu
	inner join task as tk on exu.idAux=tk.idAux
	inner join workOrder as wo1 on wo1.idAuxWO=tk.idAuxWO
	inner join projectOrder as po1 on po1.idPO=wo1.idPO and po1.jobNo=wo1.jobNo
	inner join job as jb1 on jb1.jobNo=po1.jobNo
	where  tk.idAux=ts.idAux and wo1.idAuxWO=wo.idAuxWo and po1.idPO=po.idPo and jb1.jobNo=jb.jobNo and po1.idPO = po.idPO and dateExpense between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from expensesUsed as exu
	inner join task as tk on exu.idAux=tk.idAux
	inner join workOrder as wo1 on wo1.idAuxWO=tk.idAuxWO
	inner join projectOrder as po1 on po1.idPO=wo1.idPO and po1.jobNo=wo1.jobNo
	inner join job as jb1 on jb1.jobNo=po1.jobNo
	where  tk.idAux=ts.idAux and wo1.idAuxWO=wo.idAuxWo and po1.idPO=po.idPo and jb1.jobNo=jb.jobNo and po1.idPO = po.idPO and dateExpense between @startdate and @finaldate) end +
	
	case when (select sum(amount) from materialUsed as mau
	inner join task as tk on mau.idAux=tk.idAux
	inner join workOrder as wo1 on wo1.idAuxWO=tk.idAuxWO
	inner join projectOrder as po1 on po1.idPO=wo1.idPO and po1.jobNo=wo1.jobNo
	inner join job as jb1 on jb1.jobNo=po1.jobNo
	where  tk.idAux=ts.idAux and wo1.idAuxWO=wo.idAuxWo and po1.idPO=po.idPo and jb1.jobNo=jb.jobNo and po1.idPO = po.idPO and dateMaterial between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from materialUsed as mau
	inner join task as tk on mau.idAux=tk.idAux
	inner join workOrder as wo1 on wo1.idAuxWO=tk.idAuxWO
	inner join projectOrder as po1 on po1.idPO=wo1.idPO and po1.jobNo=wo1.jobNo
	inner join job as jb1 on jb1.jobNo=po1.jobNo
	where  tk.idAux=ts.idAux and wo1.idAuxWO=wo.idAuxWo and po1.idPO=po.idPo and jb1.jobNo=jb.jobNo and po1.idPO = po.idPO and dateMaterial between @startdate and @finaldate) end
	)) as 'Total Spend',

	ts.estTotalBilling as 'Estimate'
	from task as ts
	inner join workOrder as wo on wo.idAuxWO=ts.idAuxWO
	inner join projectOrder as po on po.idPO=wo.idPO
	inner join job as jb on jb.jobNo=po.jobNo
	inner join clients cl on cl.idClient=jb.idClient
	where cl.numberClient=@clientnum and
		((select sum(hoursST)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(hoursOT)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(hours3)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(amount) from expensesUsed where idAux=ts.idAux)> 0 or
		(select sum(amount) from materialUsed where idAux=ts.idAux)>0)
		)as T2
		where T2.[Billings ST]<>'$0' OR T2.[Billings OT]<>'$0' OR T2.[Total Expenses]<>'$0' OR T2.[Total Material]<>'$0'
		order by t2.jobNo asc
end
go

--##############################################################################################
--################## SP REPORT TIME SHEETS PO ##################################################
--##############################################################################################

CREATE proc select_Time_Sheet_PO
	@IntialDate date,
	@FinalDate date
as 
begin
	select  
		
		t1.idPO,
		t1.jobNo,
		t1.idWO,
		SUM(t1.hoursST) AS 'hoursST',
		SUM(t1.hoursOT)AS 'hoursOT',
		t1.Code,t1.Shift,
		t1.Employee,t1.[Emp: Number],t1.class
		from (
			select distinct
			
			po.idPO,
			jb.jobNo,
			wo.idWO,
			hw.schedule as 'Shift',
			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
			(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and not wc1.name like '%6.4%') as 'hoursST',
			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and not wc1.name like '%6.4%') as 'hoursOT',
			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
			em.numberEmploye as 'Emp: Number' ,
			em.typeEmployee as 'class'
			from hoursWorked as hw 
			inner join employees as em on hw.idEmployee = em.idEmployee
			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
			inner join task as tk on tk.idAux = hw.idAux 
			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
			inner join job as jb on jb.jobNo = po.jobNo
			where hw.dateWorked between @IntialDate   and @FinalDate and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) and not wc.name like '%vacation%' --and em.numberEmploye = 16874
		
		) as T1
		group by t1.idPO,t1.jobNo,t1.idWO,t1.hoursST,t1.hoursOT,t1.Code,t1.Shift,
		t1.Employee,t1.[Emp: Number],t1.class
		order by T1.[Emp: Number]
end
go
--##############################################################################################
--################## SP REPORT REPORTE BY JOB NUMBER ###########################################
--##############################################################################################

CREATE proc [dbo].[select_TimeSheet_Report]
	@IntialDate date,
	@FinalDate date
as 
begin
	if @IntialDate is not null and @FinalDate is not null
	begin 
			select  
		T1.jobNo,t1.idPO,t1.task,t1.equipament,t1.description,
		SUM(t1.hoursST) AS 'hoursST',SUM(t1.hoursOT)AS 'hoursOT',SUM(t1.hours3) AS 'hours3',t1.Code,t1.Shift,t1.expCode,t1.Complete,
		t1.hrEst,t1.Employee,t1.[Emp: Number],t1.class
		from (
			select distinct
			jb.jobNo,
			po.idPO,
			CONCAT(wo.idWO,'-',tk.task)AS 'task' ,
			tk.equipament,
			tk.description,
			(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hoursST',
			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hoursOT',
			(select iif(SUM(hw1.hours3 )is null,0,SUM(hw1.hours3 )) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hours3',
			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
			hw.schedule as 'Shift', 
			tk.expCode,
			concat(tk.percentComplete,'%')  as 'Complete',
			tk.estimateHours as 'hrEst',
			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
			em.numberEmploye as 'Emp: Number' ,
			em.typeEmployee as 'class'
			from hoursWorked as hw 
			inner join employees as em on hw.idEmployee = em.idEmployee
			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
			inner join task as tk on tk.idAux = hw.idAux 
			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
			inner join job as jb on jb.jobNo = po.jobNo
			where hw.dateWorked between @IntialDate and @FinalDate and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) --and em.numberEmploye = 16874
		) as T1
		group by T1.jobNo,t1.idPO,t1.Task,t1.equipament,t1.description,t1.hoursST,t1.hoursOT,t1.hours3,t1.Code,t1.Shift,t1.expCode,t1.Complete,
		t1.hrEst,t1.Employee,t1.[Emp: Number],t1.class
		order by t1.Task,t1.[Emp: Number]
end
end
go

--##############################################################################################
--################## SP REPORT ACTIVE EMPLOYEE AVERAGE #########################################
--##############################################################################################
create proc [dbo].[sp_Active_Employee_Average]
as
begin
	select em.lastName as 'Last Name' , CONCAT(em.firstName,' ',substring( em.middleName,1,1)) as 'First Name',CONCAT( '$',pr.payRate1)as 'Pay Rate' , 
		em.socialNumber as 'SS Number',em.numberEmploye as 'Brock Emp.',
		case when em.estatus = 'E' then 'Yes'
		else 'No' end as 'Active',
		em.SAPNumber as 'Citigo Emp.'
		from employees as em left join payRate as pr on pr.idEmployee = em.idEmployee  
		where estatus = 'E'	
end
go

--##############################################################################################
--################## SP REPORT ALL JOBS ########################################################
--##############################################################################################
create proc [dbo].[Sp_All_Jobs]
@startdate as date, 
@finaldate as date
as
begin
select distinct
	jb.jobNo,
	po.idPO,
	wo.idWO,
	tk.task,
	em.SAPNumber,
	em.numberEmploye, 
	datename(dw,hw.dateWorked) as 'DAY',
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
	hw.dateWorked,
	SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
	case when ((select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours ST',
	wc.billingRate1,

	case when ((select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours OT',

	wc.billingRateOT,
	case when (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'PerDiem') is NULL then 0
	 else (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'PerDiem') end as 'PerDiem' ,

	case when (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') is NULL then ''
	 else concat('',(select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel')) end as 'Travel' 
	from employees as em 
		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
		inner join task as tk on tk.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate 
	order by 
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
	hw.dateWorked
end
go

--##############################################################################################
--################## SP REPORT #################################################################
--##############################################################################################
CREATE proc [dbo].[Sp_By_JobNumber]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
select distinct
	jb.jobNo,
	po.idPO,
	wo.idWO,
	tk.task,
	em.SAPNumber,
	em.numberEmploye, 
	datename(dw,hw.dateWorked) as 'DAY',
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
	hw.dateWorked,
	SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
	case when ((select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours ST',
	wc.billingRate1,

	case when ((select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours OT',

	wc.billingRateOT,
	case when (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'PerDiem') is NULL then 0
	 else (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'PerDiem') end as 'PerDiem' ,

	case when (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') is NULL then ''
	 else concat('',(select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel')) end as 'Travel' 
	from employees as em 
		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
		inner join task as tk on tk.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum
	order by 
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
	hw.dateWorked
end
go

--##############################################################################################
--################## SP REPORT CATS EMPLOYEE BY PROJECT ########################################
--##############################################################################################
CREATE proc [dbo].[sp_Cats_Employee_by_Porject]
@startdate as date,
@finaldate as date,
@employeenumber int,
@all as bit
as
begin
if @all = 0 begin
	select concat(wo.idWO, ' ',ts.task) as 'W/PO Number',
		em.numberEmploye as 'Emp: Number',
		concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
		wc.description,
		sum(hw.hoursST) as 'ST Hours', 
		sum(hw.hoursOT) as 'OT Hours', 
		hw.dateWorked as 'Date Worked'
		from hoursWorked as hw
		inner join employees as em on em.idEmployee= hw.idEmployee
		inner join workCode as wc on wc.idWorkCode= hw.idWorkCode
		inner join task as ts on ts.idAux= hw.idAux
		inner join workOrder wo on wo.idAuxWO=ts.idAuxWO
		where hw.dateWorked between @startdate and @finaldate and em.numberEmploye=@employeenumber
		group by concat(wo.idWO, ' ',ts.task),em.numberEmploye, concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
		 wc.description,hw.dateWorked
end
else
begin
	select concat(wo.idWO, ' ',ts.task) as 'W/PO Number',
		em.numberEmploye as 'Emp: Number',
		concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
		wc.description,
		sum(hw.hoursST) as 'ST Hours', 
		sum(hw.hoursOT) as 'OT Hours', 
		hw.dateWorked as 'Date Worked'
		from hoursWorked as hw
		inner join employees as em on em.idEmployee= hw.idEmployee
		inner join workCode as wc on wc.idWorkCode= hw.idWorkCode
		inner join task as ts on ts.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=ts.idAuxWO
		where hw.dateWorked between @startdate and @finaldate
		group by concat(wo.idWO, ' ',ts.task),em.numberEmploye, concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
		wc.description,hw.dateWorked
end
end
go

--##############################################################################################
--################## SP REPORT CLIENT BILLINGS PROJECT #########################################
--##############################################################################################
CREATE proc [dbo].[sp_Client_billings_Project]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
	set @startdate = ISNULL(@startdate,GETDATE())
	set @finaldate = ISNULL(@FinalDate,GETDATE())
	select T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
			T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
			T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend] from(
		select cl.companyName, jb.jobNo, po.idPO,concat(wo.idWO,' ',ts.task) as 'Work Order',
			ts.description as 'Project Desription',

			(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)+
			(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Total Hours',
		
		
			(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours ST',
		
		
			(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2) as 'Billings ST',

			(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours OT',
	
		
			(select  ISNULL( SUM(T2.Amount),0) as 'Billings OT' from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2) as 'Billings OT',


			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0) as 'Total Expenses',
			
			
			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0) as 'Total Material',
	
			((select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2)
			+
			(select  ISNULL( SUM(T2.Amount),0) from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2)
			+
			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0)
			+
			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0)
			) as 'Total Spend'

			from Clients as cl
			inner join job as jb on jb.idClient= cl.idClient
			inner join projectOrder as po on po.jobNo= jb.jobNo 
			inner join workOrder as wo on wo.idPO=po.idPO and po.jobNo = wo.jobNo
			inner join task as ts on ts.idAuxWO=wo.idAuxWO
	 
			where cl.numberClient=@clientnum 
			)as T2 
			where
			T2.[Billings ST]>0 OR T2.[Billings OT]>0 OR T2.[Total Expenses]>0 OR T2.[Total Material]>0 or T2.[Total Expenses] > 0
			group by T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
			T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
			T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend]
end
go

--##############################################################################################
--################## SP REPORT COMPLETE BY DATE RANGE ##########################################
--##############################################################################################
CREATE proc [dbo].[Sp_Complete_By_Date_Range]
@clientnum as int,
@jobNum as bigint,
@all as bit
as
begin
if @all=1
begin
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament, ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '1' and cl.numberClient = @clientnum
		end
else 
begin
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament, ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '1' and cl.numberClient = @clientnum and jb.jobNo=@jobNum
		end
end
go

--##############################################################################################
--################## SP REPORT EMPLOYEE PER DIEM ###############################################
--##############################################################################################
CREATE proc [dbo].[Sp_Employee_Per_Diem_Sheets]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
if @startDate is not null and @FinalDate is not null
begin
	select CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, GETDATE())) ,GETDATE())) as 'Weekending',
		po.jobNo as 'Job Num',
		CONCAT(wo.idWO,' ', tk.task) as 'Project Name',
		ex.expenseCode as 'Project Description' ,
		cl.companyName as 'Company Name', 
		CONCAT(em.lastName,',',em.firstName,' ',em.middleName) as 'Employee Name',
		em.numberEmploye as 'Emp: Number',
		em.typeEmployee as 'Class', 
		sum(xp.amount) as 'Amount' 
		from expensesUsed as xp 
		inner join expenses as ex on xp.idExpense = ex.idExpenses
		inner join employees as em on em.idEmployee = xp.idEmployee 
		inner join task as tk on tk.idAux = xp.idAux
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where xp.dateExpense  between @startdate and @finaldate and cl.numberClient = @clientnum 
		group by po.jobNo, wo.idWO, tk.task,cl.companyName, ex.expenseCode,
		CONCAT(em.lastName,',',em.firstName,' ',em.middleName),em.numberEmploye,em.typeEmployee
end
else 
begin
	select CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, GETDATE())) ,GETDATE())) as 'Weekending',
		po.jobNo as 'Job Num',
		CONCAT(wo.idWO,' ', tk.task) as 'Project Name',
		ex.expenseCode as 'Project Description' ,
		cl.companyName as 'Company Name',  
		CONCAT(em.lastName,',',em.firstName,' ',em.middleName) as 'Employee Name',
		em.numberEmploye as 'Emp: Number',
		em.typeEmployee as 'Class', 
		sum(xp.amount) as 'Amount' 
		from expensesUsed as xp 
		inner join expenses as ex on xp.idExpense = ex.idExpenses
		inner join employees as em on em.idEmployee = xp.idEmployee 
		inner join task as tk on tk.idAux = xp.idAux
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where xp.dateExpense  between @startdate and @finaldate and cl.numberClient = @clientnum
		group by po.jobNo, wo.idWO, tk.task,cl.companyName, ex.expenseCode,
		CONCAT(em.lastName,',',em.firstName,' ',em.middleName),em.numberEmploye,em.typeEmployee
end 
end
go

--##############################################################################################
--################## SP REPORT EMPLOYEE TIME ###################################################
--##############################################################################################
CREATE proc [dbo].[sp_Employee_Time]
@initialDate as date,
@finalDate as date,
@jobNum as bigint,
@numClient as int,
@all as bit
as
begin
if @all = 0 
begin 
	select numberEmploye,em.SAPNumber,concat(em.lastName,',',em.firstName,' ',em.middleName) as 'EmpName',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayOT',
	 (select pr1.payRate1 from payRate as pr1 where pr1.idEmployee = em.idEmployee and pr1.datePayRate = (select max(pr2.datePayRate) from payRate as pr2 where pr2.idEmployee = em.idEmployee)) as 'RateST',
	 (select pr1.payRate2 from payRate as pr1 where pr1.idEmployee = em.idEmployee and pr1.datePayRate = (select max(pr2.datePayRate) from payRate as pr2 where pr2.idEmployee = em.idEmployee)) as 'RateoT',
	 case when (select sum (amount) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') is NULL then ''  else (select sum (amount) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') end as 'TotalAmount',
	 (select count (*) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') as 'NO.Days'
	from employees as em
	 where em.estatus = 'E'
end 
else if @all = 1
begin 
	select numberEmploye,em.SAPNumber,concat(em.lastName,',',em.firstName,' ',em.middleName) as 'EmpName',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayOT',
	 (select pr1.payRate1 from payRate as pr1 where pr1.idEmployee = em.idEmployee and pr1.datePayRate = (select max(pr2.datePayRate) from payRate as pr2 where pr2.idEmployee = em.idEmployee)) as 'RateST',
	 (select pr1.payRate2 from payRate as pr1 where pr1.idEmployee = em.idEmployee and pr1.datePayRate = (select max(pr2.datePayRate) from payRate as pr2 where pr2.idEmployee = em.idEmployee)) as 'RateoT',
	 case when (select sum (amount) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') is NULL then ''  else (select sum (amount) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') end as 'TotalAmount',
	 (select count (*) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') as 'NO.Days'
	from employees as em
	 where em.estatus = 'E'
end
end
go

--##############################################################################################
--################## SP HOURS PER WEEK #########################################################
--##############################################################################################
CREATE proc [dbo].[sp_Hours_Per_Week]
@date as date
as
declare @initialDate as date
declare @finalDate as date
begin 
	set @date = ISNULL(@date, GETDATE())
	set @initialDate = DATEADD (DAY, iif(DATEPART(DW,@date) = 1,-6,iif(DATEPART(DW,@date)=2,0,-(DATEPART(DW,@date)-2)) ),@date)
	set @finalDate = DATEADD(day, 6 , @initialDate)
	select @finalDate as 'Weekending' ,concat(em.lastName,',',em.firstName,' ',em.middleName) as 'EmpName',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	    is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	    is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayOT'
	from employees as em
	 where em.estatus = 'E'
end
go

--##############################################################################################
--################## SP REPORT NOT COMPLETE ####################################################
--##############################################################################################
CREATE proc [dbo].[Sp_Not_Complete]
@clientnum as int,
@jobNum as bigint,
@all as bit
as
begin
if @all=1
begin
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament,ts.estimateHours as 'Est:', ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Not Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '0' and cl.numberClient = @clientnum
end
else
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament,ts.estimateHours as 'Est:', ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Not Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '0' and cl.numberClient = @clientnum and jb.jobNo=@jobNum
end
go
--##############################################################################################
--################## SP REPORT SCAFFOLD ESTIMATE ###################################################
--##############################################################################################
CREATE proc [dbo].[sp_scfEstimation]
@ccnum as varchar(30),
@all as bit 
as 
begin
	if @all = 0 
	begin
		select 
			scfE.EstNumber,scfp.unit,scfE.location,scfE.width,scfE.length,scfE.heigth,scfE.descks,scfE.daysActive,estM.DA,
			scfE.M3,scfE.M2,scfT.SCTP,(select hFactor from scfFactor where heigth = scfE.heigth) as 'Factor', scfT.BDRATE , scfT.BDRATE, estm.PMANHRS,
			estM.BPRICE,estM.DECKBP,estM.DPRICE,estM.DECKDP,
			estM.EDM3C,estM.EDM2C,estM.EDM3,estM.EDM2,
			estM.M3LBP,estM.M3LDP,estM.M2LBP,estM.M2LDP,
			estM.M3MBP,estM.M3MDP,estM.M2MBP,estM.M2MDP,
			estM.M3EBP,estM.M3EDP,estM.M2EBP,estM.M2EDP
		from scfEstProyect as scfP
			inner join scfEstimation as scfE on scfP.ccnum = scfE.ccnum
			inner join EstMeters as estM on estM.EstNumber = scfE.EstNumber
			inner join ScafEstCost as scfC on scfC.idEstCost = scfE.idEstCost
			inner join scfTypeCost as scfT on scfT.scfTypeId = scfE.scfTypeId 
		where scfP.ccnum like @ccnum
		order by scfP.ccnum
	end
	else 
	begin
		select 
			scfE.EstNumber,scfp.unit,scfE.location,scfE.width,scfE.length,scfE.heigth,scfE.descks,scfE.daysActive,estM.DA,
			scfE.M3,scfE.M2,scfT.SCTP,(select hFactor from scfFactor where heigth = scfE.heigth) as 'Factor', scfT.BDRATE , scfT.BDRATE, estm.PMANHRS,
			estM.BPRICE,estM.DECKBP,estM.DPRICE,estM.DECKDP,
			estM.EDM3C,estM.EDM2C,estM.EDM3,estM.EDM2,
			estM.M3LBP,estM.M3LDP,estM.M2LBP,estM.M2LDP,
			estM.M3MBP,estM.M3MDP,estM.M2MBP,estM.M2MDP,
			estM.M3EBP,estM.M3EDP,estM.M2EBP,estM.M2EDP
		from scfEstProyect as scfP
			inner join scfEstimation as scfE on scfP.ccnum = scfE.ccnum
			inner join EstMeters as estM on estM.EstNumber = scfE.EstNumber
			inner join ScafEstCost as scfC on scfC.idEstCost = scfE.idEstCost
			inner join scfTypeCost as scfT on scfT.scfTypeId = scfE.scfTypeId 
			where scfP.ccnum like '%'
			order by scfP.ccnum
	end
end
go

--##############################################################################################
--################## SP YEAR FINAL HOURS #######################################################
--##############################################################################################
CREATE proc [dbo].[sp_Year_Final_Hours]
@year nVarchar(4)
as
begin
    set @year = isnull(@year, DATENAME(YEAR,GETDATE()))
	
	select *, T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember as 'Total' 
	from (
	select 
		wc.name,
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'January') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'January') end as 'January',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'February') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'February') end as 'February',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'March') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'March') end as 'March',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'April') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'April') end as 'April',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'May') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'May') end as 'May',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'June') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'June') end as 'June',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'July') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'July') end as 'July',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'August') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'August') end as 'August',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'September') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'September') end as 'September',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'October') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'October') end as 'October',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'November') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'November') end as 'Nomvember',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'Dicember') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'Dicember') end as 'Dicember'
	from workCode as wc ) as T1
	where (T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember) > 0
end
go
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V
----#########################################################################################################################################################################################
----############## CAMBIOS EN LA TABLA DE PIPING MATERIAL Y CREACION DE LA TABLA EQUIPMENT MATERIAL #########################################################################################
----#########################################################################################################################################################################################
EXEC sp_rename 'dbo.pipingMaterial.prize','price','COLUMN'
go

create table equipmentMaterial(
	[type] varchar(25) not null,
	thick float not null,
	price money,
	[description] varchar(50)
)
go
ALTER TABLE equipmentMaterial ADD CONSTRAINT pk_type_thick_EquipmentMaterial
PRIMARY KEY([type],[thick])
go

ALTER TABLE equipmentMaterial ADD CONSTRAINT fk_type_EquipmentMaterial
FOREIGN KEY ([type]) REFERENCES insFitting ([type])
GO


create proc sp_MaterialEstimationProject
@ProjectId as varchar(30)
as
begin
	select
	distinct
	T1.idDrawingNum ,
	(select TOP 1 SUM(T2.[SQF/LF]) from 
					(select TA.[SQF/LF] from
						(select dr.idDrawingNum, ppE.lFtII  as 'SQF/LF', ppE.size , ppE.thick , ppM.price , ppM.description , (ppE.lFtII * ppM.price) as 'PMCost' from pipingEst as ppE
							inner join pipingMaterial ppM on ppE.size = ppM.size and ppE.thick = ppM.thick and ppe.[type]= ppM.[type]
							inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
							inner join projectClientEst as po on po.projectId  = dr.projectId
							where po.projectId = @ProjectId and (ppE.lFtII > 0 and not ppE.lFtII is null )
							union all
							select dr.idDrawingNum ,eqE.sqrFtII as 'SQF/LF', 0 as 'Size' , eqE.thick , eqM.price , eqM.description , (eqE.sqrFtII * eqM.price) as 'PMCost' from equipmentEst as eqE
							inner join equipmentMaterial as eqM on  eqM.[type] = eqE.[type] and eqM.[thick] = eqE.[thick]
							inner join drawing as dr on dr.idDrawingNum = eqE.idDrawingNum 
							inner join projectClientEst as po on po.projectId  = dr.projectId
							where po.projectId = @ProjectId and (eqE.sqrFtII > 0 and not eqE.sqrFtII is null)) as TA 
						where TA.[description] = T1.[description] and TA.[thick] = T1.[thick] and TA.[price] = T1.[price] and TA.[idDrawingNum] = T1.[idDrawingNum] ) as T2) AS 'SQF/LF',
	T1.size , 
	T1.thick,
	T1.price,
	T1.[description],
	(select TOP 1 SUM(T2.[SQF/LF]) from 
					(select TA.[SQF/LF] from
						(select dr.idDrawingNum, ppE.lFtII  as 'SQF/LF', ppE.size , ppE.thick , ppM.price , ppM.description , (ppE.lFtII * ppM.price) as 'PMCost' from pipingEst as ppE
							inner join pipingMaterial ppM on ppE.size = ppM.size and ppE.thick = ppM.thick and ppe.[type]= ppM.[type]
							inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
							inner join projectClientEst as po on po.projectId  = dr.projectId
							where po.projectId = @ProjectId and (ppE.lFtII > 0 and not ppE.lFtII is null )
							union all
							select dr.idDrawingNum ,eqE.sqrFtII as 'SQF/LF', 0 as 'Size' , eqE.thick , eqM.price , eqM.description , (eqE.sqrFtII * eqM.price) as 'PMCost' from equipmentEst as eqE
							inner join equipmentMaterial as eqM on  eqM.[type] = eqE.[type] and eqM.[thick] = eqE.[thick]
							inner join drawing as dr on dr.idDrawingNum = eqE.idDrawingNum 
							inner join projectClientEst as po on po.projectId  = dr.projectId
							where po.projectId = @ProjectId and (eqE.sqrFtII > 0 and not eqE.sqrFtII is null)) as TA 
						where TA.[description] = T1.[description] and TA.[thick] = T1.[thick] and TA.[price] = T1.[price] and TA.[idDrawingNum] = T1.[idDrawingNum] ) as T2) AS 'PMCost'
	from(
	select dr.idDrawingNum, ppE.lFtII  as 'SQF/LF', ppE.size , ppE.thick , ppM.price , ppM.description , (ppE.lFtII * ppM.price) as 'PMCost' from pipingEst as ppE
	inner join pipingMaterial ppM on ppE.size = ppM.size and ppE.thick = ppM.thick and ppe.[type]= ppM.[type]
	inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
	inner join projectClientEst as po on po.projectId  = dr.projectId
	where po.projectId = @ProjectId and (ppE.lFtII > 0 and not ppE.lFtII is null )
	union all
	select dr.idDrawingNum ,eqE.sqrFtII as 'SQF/LF', 0 as 'Size' , eqE.thick , eqM.price , eqM.description , (eqE.sqrFtII * eqM.price) as 'PMCost' from equipmentEst as eqE
	inner join equipmentMaterial as eqM on  eqM.[type] = eqE.[type] and eqM.[thick] = eqE.[thick]
	inner join drawing as dr on dr.idDrawingNum = eqE.idDrawingNum 
	inner join projectClientEst as po on po.projectId  = dr.projectId
	where po.projectId = @ProjectId and (eqE.sqrFtII > 0 and not eqE.sqrFtII is null)) as T1
end
go
