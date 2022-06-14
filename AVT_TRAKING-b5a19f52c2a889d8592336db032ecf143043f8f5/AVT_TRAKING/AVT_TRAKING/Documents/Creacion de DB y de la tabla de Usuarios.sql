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

create table clients (
idClient varchar (36) not null primary key,
numberClient int not null,
firstName varchar(30), 
middleName Varchar(30),
lastName varchar(30),  
companyName varchar (50),
idContact varchar(36),
idHomeAddress varchar(36),
estatus char(1),
photo image
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
	idDrawingNum varchar(45) not null
)
go

ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idDrawing_equipmentEst
FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_elevation_equipmentEst
FOREIGN KEY (elevation) REFERENCES factorElevationScf(elevation)
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_systemPntEq_pntOption_equipmentEst
FOREIGN KEY (systemPntEq,pntOption) REFERENCES eqPaintUnitRate(systemPntEq,pntOption)
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_type_thick_equipmentEst
FOREIGN KEY ([type],thick) REFERENCES eqInsUnitRate([type],thick)
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idJacket_equipmentEst
FOREIGN KEY (idJacket) REFERENCES eqJktUnitRate(idJacket)
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
ALTER TABLE ppInsUnitRate WITH CHECK ADD CONSTRAINT PK_size_type_thick_PPInsUnitRate
PRIMARY KEY (size,[type],thick)
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
	idMaterial varchar(36)
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
	prize money,
	[description] varchar(50)
)
go

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

create table taxesPT(
	idTaxesPT varchar(36)primary key not null,
	totalHours float,
	FICA float,
	FUI float,  
	SUI float,
	BWForeman money,
	BWJourneyman money,
	BWCraftsman money,
	BWApprentice money,
	BWHelper money,
	QtyForeman int,
	QtyJourneyman int,
	QtyCraftsman int,
	QtyApprentice int,
	QtyHelper int,
	jobNo bigint
)
GO

--##########################################################################################
--##################  TABLA DE TAXESST #####################################################
--##########################################################################################

create table taxesST(
	idTaxesST varchar(36)primary key not null,
	totalHours float,
	FICA float,
	FUI float,  
	SUI float,
	WC float,
	GenLiab float,
	Umbr float,
	Pollution float,
	Healt float,
	Fringe float,
	Small float,
	PPE float,
	Consumable float,
	Scaffold float,
	YoYo float,
	Mesh float,
	Miselaneos float,
	Overhead float,
	Profit float,
	BWForeman money,
	BWJourneyman money,
	BWCraftsman money,
	BWApprentice money,
	BWHelper money,
	QtyForeman int,
	QtyJourneyman int,
	QtyCraftsman int,
	QtyApprentice int,
	QtyHelper int,
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

ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idEquipmentEst_EstCosteq
FOREIGN KEY (tag) REFERENCES equipmentEst(idEquipmentEst)
go 

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
FOREIGN KEY ([type],thick) REFERENCES eqInsUnitRate([type],thick)
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
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idLaborRatePnt_equipmentEst
FOREIGN KEY (idLaborRatePnt) REFERENCES laborRate(idLaborRate)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idLaborII_equipmentEst
FOREIGN KEY (idLaborRateII) REFERENCES laborRate(idLaborRate)
ON UPDATE CASCADE
ON DELETE CASCADE
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
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idLaborRatePnt_pipingEst
FOREIGN KEY (idLaborRatePnt) REFERENCES laborRate(idLaborRate)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idLaborRateII_pipingEst
FOREIGN KEY (idLaborRateII) REFERENCES laborRate(idLaborRate)
ON UPDATE CASCADE
ON DELETE CASCADE
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
--##################  FOREIG KEYS PPPAINTUNITRATE ##########################################
--##########################################################################################

ALTER TABLE ppInsUnitRate WITH CHECK ADD CONSTRAINT PK_size_type_thick_PPInsUnitRate
PRIMARY KEY (size,[type],thick)
GO

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
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idEnviroment_scaffoldEst
FOREIGN KEY (idEnviroment) REFERENCES enviroment(idEnviroment)
ON UPDATE CASCADE
ON DELETE CASCADE
go

ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idSCFUR_scaffoldEst
FOREIGN KEY (idSCFUR) REFERENCES scfUnitsRates(idSCFUR)
ON UPDATE CASCADE
ON DELETE CASCADE
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
				insert into material values (@idMaterial,@numero,@nombre,@status,iif(@class='',Null,@class))
				insert into detalleMaterial values (@idDM,'','','',0.0,'',0.0,@idMaterial,@idVendor,'')
				insert into existences values (@idDM , 0.0)
				set @msg= 'Successful'
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
				insert into material values (@idMaterial,@numero,@nombre,@status)
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
				update HomeAddress set avenue= @avenue, number = number , city=@city , providence =@providence, postalCode = @postalcode where idHomeAdress = @idAddres
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
ALTER proc [dbo].[sp_Active_Employee_Average]
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
CREATE proc [dbo].[Sp_All_Jobs]
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
if @startDate is not null and @FinalDate is not null
begin
select T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
		T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
		T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend] from(
	select cl.companyName, jb.jobNo, po.idPO,concat(wo.idWO,' ',ts.task) as 'Work Order',
		ts.description as 'Project Desription',

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
		concat('$', case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end) as 'Total Expenses',
		CONCAT('$', case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end) as 'Total Material',
	
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

		case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end +
	
		case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate ) end
		)) as 'Total Spend'

		from Clients as cl
		inner join job as jb on jb.idClient= cl.idClient
		inner join projectOrder as po on po.jobNo= jb.jobNo
		inner join workOrder as wo on wo.idPO=po.idPO
		inner join task as ts on ts.idAuxWO=wo.idAuxWO
	 
		where cl.numberClient=@clientnum 
		)as T2 
		where T2.[Billings ST]<>'$0' OR T2.[Billings OT]<>'$0' OR T2.[Total Expenses]<>'$0' OR T2.[Total Material]<>'$0'
		group by T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
		T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
		T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend]
end
else
begin 
set @startdate = GETDATE() 
set @finaldate = GETDATE()
select T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
		T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
		T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend] from(
	select cl.companyName, jb.jobNo, po.idPO,concat(wo.idWO,' ',ts.task) as 'Work Order',
		ts.description as 'Project Desription',

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
		concat('$', case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end) as 'Total Expenses',
		CONCAT('$', case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end) as 'Total Material',
	
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

		case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end +
	
		case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate ) end
		)) as 'Total Spend'

		from Clients as cl
		inner join job as jb on jb.idClient= cl.idClient
		inner join projectOrder as po on po.jobNo= jb.jobNo
		inner join workOrder as wo on wo.idPO=po.idPO
		inner join task as ts on ts.idAuxWO=wo.idAuxWO
	 
		where cl.numberClient=@clientnum 
		)as T2 
		where T2.[Billings ST]<>'$0' OR T2.[Billings OT]<>'$0' OR T2.[Total Expenses]<>'$0' OR T2.[Total Material]<>'$0'
		group by T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
		T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
		T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend]
end
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

----============================================================================================================================================
----========== ESTE CODIGO ES PARA AGREGAR LA TABLA DE CLIENTES Y PROYECTOS DE ESTIMACION ======================================================
----============================================================================================================================================

----##########################################################################################################################
----############# TABLA DE CLIENTEST #########################################################################################
----##########################################################################################################################
----1
--create table clientsEst(
--	idClientEst varchar(36) primary key not null,
--	numberClient int,
--	contactName varchar(30),
--	companyName varchar(50),
--	plant varchar(50),
--	idContact varchar(36),
--	idHomeAdress varchar(36)
--)
--go

--ALTER TABLE clientsEst WITH CHECK ADD CONSTRAINT fk_idContact_clientsEst
--FOREIGN KEY (idContact) REFERENCES contact(idContact)
--GO

--ALTER TABLE clientsEst WITH CHECK ADD CONSTRAINT fk_idContact_HomeAddress
--FOREIGN KEY (idHomeAdress) REFERENCES HomeAddress(idHomeAdress)
--GO

----##########################################################################################################################
----############## TABLA DE PROJECTCLIENTEST #################################################################################
----##########################################################################################################################
----2
--create table projectClientEst(
--	projectId varchar(30) primary key not null,
--	[description] varchar(150),
--	unit varchar(50),
--	releaseDate date,
--	idClientEst varchar(36)
--)
--go

--ALTER TABLE projectClientEst WITH CHECK ADD CONSTRAINT fk_idClintEst_projectClientEst
--FOREIGN KEY (idClientEst) REFERENCES clientsEst(idClientEst)
--go
----##########################################################################################################################
----############## TABLA DE ELEVACION DE SCAFFOLD ############################################################################
----##########################################################################################################################
----3
--create table factorElevationSCF(
--	elevation int primary key not null,
--	[percent] int 
--)
--go
----##########################################################################################################################
----############## TABLA DE ELEVACION PAINT INSULATION #######################################################################
----##########################################################################################################################
----4
--create table factorElevationPaint(
--	elevation int primary key not null,
--	[percent] int
--)
--go

----##########################################################################################################################
----############## TABLA DE LABORRATE ########################################################################################
----##########################################################################################################################
----5
--create table laborRate(
--	idLaborRate varchar(40) primary key not null,
--	insRate money,
--	abatRate money,
--	paintRate money,
--	scafRate money
--)
--go
----##########################################################################################################################
----############## TABLA DE SCFUNITRATES #####################################################################################
----##########################################################################################################################
----6
--create table scfUnitsRates(
--	idSCFUR varchar(35) primary key not null,
--	buildPercent int,
--	laborB float,
--	materialB float,
--	equipmentB float,
--	dismantlePercent int,
--	laborD float,
--	materialD float,
--	equipmentD float
--)
--go
----##########################################################################################################################
----############## TABLA DE ENVIROMENT #######################################################################################
----##########################################################################################################################
----7
--create table enviroment(
--	idEnviroment varchar(40) primary Key not null,
--	dueDays int 
--)
--go

----##########################################################################################################################
----############## TABLA DE DRAWING ##########################################################################################
----##########################################################################################################################
----8
--create table drawing(
--	idDrawingNum varchar(45) primary key not null,
--	[description] varchar(150),
--	projectId varchar(30)
--)
--go

--ALTER TABLE drawing WITH CHECK ADD CONSTRAINT fk_projectId_drawing
--FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--go

----##########################################################################################################################
----############## TABLA DE DRAWING ##########################################################################################
----##########################################################################################################################
----9
--create table scaffoldEst(
--	tag varchar(20) primary key not null,
--	location varchar(150),
--	[days] int,
--	width float,
--	[length] float,
--	heigth float,
--	decks int,
--	build int,
--	idLaborRate varchar(40) not null,
--	idSCFUR varchar(35) not null,
--	idEnviroment varchar(40) not null,
--	idDrawingNum varchar(45) not null
--)
--go

--ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idLaborRate_scaffoldEst
--FOREIGN KEY (idLaborRate) REFERENCES laborRate(idLaborRate)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--go

--ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idEnviroment_scaffoldEst
--FOREIGN KEY (idEnviroment) REFERENCES enviroment(idEnviroment)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--go

--ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idSCFUR_scaffoldEst
--FOREIGN KEY (idSCFUR) REFERENCES scfUnitsRates(idSCFUR)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--go

--ALTER TABLE scaffoldEst WITH CHECK ADD CONSTRAINT fk_idDrawingNum_scaffoldEst
--FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--go

----##########################################################################################################################
----############## TABLA DE INSFITTING #######################################################################################
----##########################################################################################################################
----10
--create table insFitting(
--	[type] varchar(25) primary key not null,
--	support float,
--	p90 float,
--	p45 float,
--	bend float,
--	tee float,
--	red float,
--	cap float,
--	flangePair float,
--	flangeVlv float,
--	controlVlv float,
--	weldedVlv  float,
--	bebel float,
--	cutOut float
--)
--go

----##########################################################################################################################
----############## TABLA DE PNTFITTING #######################################################################################
----##########################################################################################################################
----11
--create table pntFitting(
--	pntOption varchar(25) primary key not null,
--	p90 float,
--	p45 float,
--	tee float,
--	flangePair float,
--	flangeVlv float,
--	controlVlv float,
--	weldedVlv float
--)
--go

----##########################################################################################################################
----############## TABLA DE EQPAINTUNITRATE ##################################################################################
----##########################################################################################################################
----12
--create table eqPaintUnitRate(
--	systemPntEq varchar(10)not null,
--	pntOption varchar(25)not null,
--	laborProd float,
--	matRate float,
--	eqRate float
--)
--go

--ALTER TABLE eqPaintUnitRate WITH CHECK ADD CONSTRAINT pk_systemPntEq_pntFitting
--PRIMARY KEY (systemPntEq,pntOption)
--go

--ALTER TABLE eqPaintUnitRate WITH CHECK ADD CONSTRAINT fk_pntFitting_eqPaintUnitRate
--FOREIGN KEY (pntOption) REFERENCES pntFitting(pntOption)
--go

----##########################################################################################################################
----############## TABLA DE ppPAINTUNITRATE ##################################################################################
----##########################################################################################################################
----13
--create table ppPaintUnitRate(
--	systemPntPP varchar(10)not null,
--	pntOption varchar(25)not null,
--	size float not null,
--	laborProd float,
--	matRate float,
--	eqRate float
--)
--go

--ALTER TABLE ppPaintUnitRate WITH CHECK ADD CONSTRAINT pk_systemPntPP_pntOption_size
--PRIMARY KEY (systemPntPP,pntOption,size) 
--go

--ALTER TABLE ppPaintUnitRate WITH CHECK ADD CONSTRAINT Fk_pntOption_pntFitting
--FOREIGN KEY (pntOption) REFERENCES pntFitting(pntOption) 
--go
----##########################################################################################################################
----############## TABLA DE eqJktUnitrate ####################################################################################
----##########################################################################################################################
----14
--create table eqJktUnitRate(
--	idJacket varchar(25) primary key not null,
--	name varchar(60) not null,
--	laborProd float,
--	matFactor float,
--	eqFactor float
--)
--go

----##########################################################################################################################
----############## TABLA DE ppJktUnitRate ####################################################################################
----##########################################################################################################################
----15
--create table ppJktUnitRate(
--	idJacket varchar(25) primary key not null,
--	name varchar(60) not null,
--	laborProd float,
--	matFactor float,
--	eqFactor float 
--)
--go

----##########################################################################################################################
----############## TABLA DE ppPAINTUNITRATE ##################################################################################
----##########################################################################################################################
----16
--create table eqInsUnitRate(
--	[type] varchar(25)not null,
--	thick float not null,
--	laborProd float,
--	matRate float,
--	eqRate float
--)
--go

--ALTER TABLE eqInsUnitRate WITH CHECK ADD CONSTRAINT PK_type_think_eqinsUnitRate
--PRIMARY KEY([type],thick)
--go

--ALTER TABLE eqInsunitRate WITH CHECK ADD CONSTRAINT fk_type_eqInsUnitRate
--FOREIGN KEY([TYPE]) REFERENCES insFitting([type])
--go

----##########################################################################################################################
----############## TABLA DE ppInsUnitRate ####################################################################################
----##########################################################################################################################
----17
--create table ppInsUnitRate(
--	size float not null, 
--	[type] varchar(25) not null,
--	thick float not null,
--	laborProd float,
--	matRate float,
--	eqRate float
--)
--go

--ALTER TABLE ppInsUnitRate WITH CHECK ADD CONSTRAINT PK_size_type_thick_PPInsUnitRate
--PRIMARY KEY (size,[type],thick)
--go

----##########################################################################################################################
----############## TABLA DE equipmentEst #####################################################################################
----##########################################################################################################################
----18
--create table equipmentEst(
--	idEquimentEst int primary key not null,
--	[description] varchar(45)not null,
--	elevation int,
--	systemPntEq varchar(10),
--	pntOption varchar(25),
--	[type] varchar(25),
--	thick float,
--	idJacket varchar(25),
--	remIns bit,
--	idLaborRateRmv varchar(40),
--	sqrFtRmv float,
--	idLaborRatePnt varchar(40),
--	sqrFtPnt float,
--	idLaborRateII varchar(40),
--	sqrFtII float,
--	bevel float,
--	cutout float,
--	idDrawingNum varchar(45) not null
--)
--go

--ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idDrawing_equipmentEst
--FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
--GO
--ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_elevation_equipmentEst
--FOREIGN KEY (elevation) REFERENCES factorElevationScf(elevation)
--GO
--ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_systemPntEq_pntOption_equipmentEst
--FOREIGN KEY (systemPntEq,pntOption) REFERENCES eqPaintUnitRate(systemPntEq,pntOption)
--GO
--ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_type_thick_equipmentEst
--FOREIGN KEY ([type],thick) REFERENCES eqInsUnitRate([type],thick)
--GO
--ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idJacket_equipmentEst
--FOREIGN KEY (idJacket) REFERENCES eqJktUnitRate(idJacket)
--GO
--ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idLaborRateRmv_equipmentEst
--FOREIGN KEY (idLaborRateRmv) REFERENCES laborRate(idLaborRate)
--GO
--ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idLaborRatePnt_equipmentEst
--FOREIGN KEY (idLaborRatePnt) REFERENCES laborRate(idLaborRate)
--GO
--ALTER TABLE equipmentEst WITH CHECK ADD CONSTRAINT fk_idLaborII_equipmentEst
--FOREIGN KEY (idLaborRateII) REFERENCES laborRate(idLaborRate)
--GO
----##########################################################################################################################
----############## TABLA DE pipingEst ########################################################################################
----##########################################################################################################################
----19
--create table pipingEst(
--	idPipingEst int primary key not null,
--	line varchar(20)not null,
--	size float,
--	[type]varchar(25),
--	thick float,
--	systemPntPP varchar(10),
--	pntOption varchar(25),
--	idJacket varchar(25),
--	elevation int,
--	idLaborRateRmv varchar(40),
--	lFtRmv float,
--	idLaborRatePnt varchar(40),
--	lFtPnt float,
--	p90Pnt int,
--	p45Pnt int,
--	pTeePnt int,
--	pPairPnt int,
--	pVlvPnt int,
--	pControlPnt int,
--	pWeldPnt int,
--	idLaborRateII varchar(40),
--	lFtII float,
--	p90II int,
--	p45II int,
--	pBendII int,
--	pTeeII int,
--	pReducII int,
--	pCapsII int,
--	pPairII int,
--	pVlvII int,
--	pControlII int,
--	pWeldII int,
--	pCutOutII int,
--	psupportII int,
--	acm bit,
--	st bit,
--	idDrawingNum varchar(45)
--)
--go

--ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_elevation_pipingEst
--FOREIGN KEY (elevation) REFERENCES factorElevationPaint(elevation)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO

--ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idJacket_pipingEst
--FOREIGN KEY (idJacket) REFERENCES ppJktUnitRate(idJacket)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO

--ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idLaborRateRmv_pipingEst
--FOREIGN KEY (idLaborRateRmv) REFERENCES laborRate(idLaborRate)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO

--ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idLaborRatePnt_pipingEst
--FOREIGN KEY (idLaborRatePnt) REFERENCES laborRate(idLaborRate)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO

--ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idLaborRateII_pipingEst
--FOREIGN KEY (idLaborRateII) REFERENCES laborRate(idLaborRate)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO

--ALTER TABLE pipingEst WITH CHECK ADD CONSTRAINT fk_idDrawingNum_pipingEst
--FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO

------##########################################################################################################################
------############## TABLA DE pipingMaterial ###################################################################################
------##########################################################################################################################
------20
--create table pipingMaterial(
--	size float not null,
--	[type] varchar(25)not null,
--	thick float not null, 
--	prize money,
--	[description] varchar(50)
--)
--go

--ALTER TABLE pipingMaterial WITH CHECK ADD CONSTRAINT pk_size_type_thick
--PRIMARY KEY (size, [type], thick)
--GO
--ALTER TABLE pipingMaterial WITH CHECK ADD CONSTRAINT fk_type_pipingmaterial
--FOREIGN KEY ([type]) REFERENCES insFitting([type])
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO
--| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
--| | | | | | | | ESTO ES LO NUEVO  | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
--V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V 
------##########################################################################################################################
------############## ESTAS SON LAS TABLAS PARA LA CALCULACION DE LA ESTIMACION #################################################
------##########################################################################################################################

------##########################################################################################################################
------#### TABLA DE ESTCOSTBUILD SE LE AGREGO UN PROCEDIMIENTO SOLO PARA CUANDO SE EJECUTE EL SP O EL TRIGER DE ESTCOSTSCF #####
------##########################################################################################################################
--create table EstCostBuild(
--	tag varchar(20) not null,
--	idDrawingNum varchar(45)not null,
--	projectId varchar(30) not null,
--	M2 float,
--	SHR float,
--	SBHR float,
--	SDHR float,
--	SCOSTL float,
--	SCOSTLB float,
--	SCOSTLD float,
--	SCOSTM float,
--	SCOSTMB float,
--	SCOSTMD float,
--	SCOSTE float,
--	SCOSTEB float,
--	SCOSTED float,
--	STCOST float
--)
--go

--ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT pk_idTag_idDrawingnum_projectId
--PRIMARY KEY (tag,idDrawingNum,projectId)
--go

--ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_tag_EstCostBuild
--FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
--go

--ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostBuild
--FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--go

--ALTER TABLE EstCostBuild WITH CHECK ADD CONSTRAINT fk_projectId_EstCostBuild
--FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
--go

--create proc sp_insertUpdateEstCostBuild
--@tag as varchar(20),
--@idDrawingNum as varchar(45),
--@width as float,
--@length as float,
--@decks as int,
--@idSUFR as varchar(35),
--@idLaborRate as varchar(40)
--as 
--declare @projectId varchar(30)
--declare @M2 float = 0 
--declare @SHR float = 0
--declare @BUILDPERCENT float = 0
--declare @SBHR float = 0
--declare @SDHR float = 0
--declare @SCOSTL float = 0
--declare @SCOSTLB float = 0
--declare @SCOSTLD float = 0
--declare @SCOSTM float = 0
--declare @SCOSTMB float = 0
--declare @SCOSTMD float = 0
--declare @SCOSTE float = 0
--declare @SCOSTEB float = 0
--declare @SCOSTED float = 0
--declare @STCOST float = 0
--declare @STCOSTB float = 0
--declare @STCOSTD float = 0
--begin
--	set @projectId=  (select projectId from drawing where idDrawingNum = @idDrawingNum)
--	set @M2 = FORMAT(((ISNULL( @width,0)*ISNULL(@length,0)*ISNULL(@decks,0))/10.76391),'###.00')
--	set @SHR = ROUND(@M2/(select laborB from scfUnitsRates where idSCFUR =@idSUFR),1)
--	set @BUILDPERCENT = (select buildPercent from scfUnitsRates where idSCFUR =@idSUFR)/100
--	set @SBHR = ROUND(@SHR * @BUILDPERCENT,1)
--	set @SDHR = @SHR- @SBHR

--	set @SCOSTL = ROUND(@SBHR*(select scafRate from laborRate where idLaborRate = @idLaborRate),2)+ROUND(@SDHR * (select scafRate from laborRate where idLaborRate = @idLaborRate),2)
--	set @SCOSTLB = ROUND(@SBHR * (select scafRate from laborRate where idLaborRate = @idLaborRate),2)
--	set @SCOSTLD = @SCOSTL - @SCOSTLB

--	set @SCOSTM = ROUND(@SHR * (select materialB from scfUnitsRates where idSCFUR = @idSUFR) ,2)
--	set @SCOSTMB = ROUND(@SBHR * (select materialB from scfUnitsRates where idSCFUR = @idSUFR) ,2)
--	set @SCOSTMD = @SCOSTM - @SCOSTMB

--	set @SCOSTE = ROUND(@SHR * (select equipmentB from scfUnitsRates where idSCFUR = @idSUFR) ,2)
--	set @SCOSTEB = ROUND(@SBHR * (select equipmentB from scfUnitsRates where idSCFUR = @idSUFR) ,2)
--	set @SCOSTED = @SCOSTE - @SCOSTEB

--	set @STCOST = ISNULL(@SCOSTL,0)+ISNULL(@SCOSTM,0)+ISNULL(@SCOSTE,0)
--	set @STCOSTB = ISNULL(@SCOSTLB,0)+ISNULL(@SCOSTMB,0)+ISNULL(@SCOSTEB,0)
--	set @STCOSTD = @STCOST - @STCOSTB

--	if (select COUNT(*) from EstCostBuild where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId)=0
--	begin 
--		insert into EstCostBuild values (@tag,@idDrawingNum,@projectId,@M2,@SHR,@SBHR,@SDHR,@SCOSTL,@SCOSTLB,@SCOSTLD,@SCOSTM,@SCOSTMB,@SCOSTMD,@SCOSTE,@SCOSTEB,@SCOSTED,@STCOST)
--	end 
--	else if (select COUNT(*) from EstCostBuild where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId)>0
--	begin 
--		update EstCostBuild set M2= @M2,SHR=@SHR,SBHR=@SBHR,SDHR=@SDHR,SCOSTL=@SCOSTL,SCOSTLB=@SCOSTLB,SCOSTLD=@SCOSTLD,SCOSTM=@SCOSTM,SCOSTMB=@SCOSTMB,SCOSTMD=@SCOSTMD,SCOSTE=@SCOSTE,SCOSTEB=@SCOSTEB,SCOSTED=@SCOSTED,STCOST=@STCOST where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId
--	end
--end
--go
--------##########################################################################################################################
--------#### TABLA DE ESTCOSTDISM SE LE AGREGO UN PROCEDIMIENTO SOLO PARA CUANDO SE EJECUTE EL SP O EL TRIGER DE ESTCOSTSCF ######
--------##########################################################################################################################
--create table EstCostDism(
--	tag varchar(20) not null,
--	idDrawingNum varchar(45)not null,
--	projectId varchar(30) not null,
--	M2 float,
--	SHRD float,
--	SBHRD float,
--	SDHRD float,
--	DSCOSTL float,
--	DSCOSTM float,
--	SCOSTMBD float,
--	DSCOSTMD float,
--	SCOSTEBD float,
--	BSCOSTEB float,
--	SCOSTEDD float
--)
--go
--ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT pk_idTag_idDrawingnum_projectId_Dism
--PRIMARY KEY (tag,idDrawingNum,projectId)
--go

--ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_tag_EstCostDism
--FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
--go

--ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostDism
--FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
--ON UPDATE CASCADE
--ON DELETE CASCADE
--go

--ALTER TABLE EstCostDism WITH CHECK ADD CONSTRAINT fk_projectId_EstCostDism
--FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
--go

--create proc sp_insertUpdateEstCostDism
--@tag as varchar(20),
--@idDrawingNum as varchar(45),
--@width as float,
--@length as float,
--@decks as int,
--@idSCFUnitRate as varchar (35),
--@idLaborRate as varchar (40)
--as
--declare @projectId varchar(30) = NULL
--declare @M2 float = 0
--declare @SHRD float = 0
--declare @SBHRD float = 0
--declare @BUILDPERCENT float = 0
--declare @SDHRD float = 0
--declare @DSCOSTL float = 0
--declare @DSCOSTM float = 0
--declare @SCOSTMBD float = 0
--declare @DSCOSTMD float = 0
--declare @SCOSTEBD float = 0
--declare @BSCOSTEB float = 0
--declare @SCOSTEDD float = 0
--begin
--	set @projectId = (select projectId from drawing where idDrawingNum = @idDrawingNum)
--	set @M2 =  FORMAT(((ISNULL( @width,0)*ISNULL(@length,0)*ISNULL(@decks,0))/10.76391),'###.00')
--	set @SHRD = ROUND(@M2 /(select laborB from scfUnitsRates where idSCFUR = @idSCFUnitRate ),1)
--	set @BUILDPERCENT = (select buildPercent from scfUnitsRates where idSCFUR = @idSCFUnitRate)
--	set @SBHRD = ROUND(@SHRD * (@BUILDPERCENT/100),1)
--	set @SDHRD = ISNULL(@SHRD,0) - ISNULL(@SBHRD,0)

--	set @DSCOSTL = ROUND(@SDHRD * (select scafRate from laborRate where idLaborRate = @idLaborRate),2)
--	set @DSCOSTM = ROUND(@SHRD * (select materialB from scfUnitsRates where idSCFUR = @idSCFUnitRate),2)
--	set @SCOSTMBD = ROUND(@SBHRD *(select materialB from scfUnitsRates where idSCFUR = @idSCFUnitRate),2)
--	set @DSCOSTMD = @DSCOSTM - @SCOSTMBD
--	set @SCOSTEBD = ROUND(@SHRD * (select equipmentB from scfUnitsRates where idSCFUR = @idSCFUnitRate),2)
--	set @BSCOSTEB = ROUND(@SBHRD* (select equipmentB from scfUnitsRates where idSCFUR = @idSCFUnitRate),2)
--	set @SCOSTEDD = @SCOSTEBD - @BSCOSTEB

--	if (select COUNT(*) FROM EstCostDism where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId) = 0
--	begin 
--		insert into EstCostDism values (@tag,@idDrawingNum,@projectId,@M2,@SHRD,@SBHRD,@SDHRD,@DSCOSTL,@DSCOSTM,@SCOSTMBD,@DSCOSTMD,@SCOSTEBD,@BSCOSTEB,@SCOSTEDD)
--	end
--	else if (select COUNT(*) FROM EstCostDism where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId) <0
--	begin 
--		update EstCostDism set M2 =@M2,SHRD = @SHRD,SBHRD = @SBHRD,SDHRD = @SDHRD,DSCOSTL = @DSCOSTL,DSCOSTM = @DSCOSTM,SCOSTMBD = @SCOSTMBD,DSCOSTMD = @DSCOSTMD,SCOSTEBD = @SCOSTEBD,BSCOSTEB = @BSCOSTEB,SCOSTEDD = @SCOSTEDD
--	end
--end
--go
--------##########################################################################################################################
--------########## TABLA DE ESTCOSTSCF SE LE AGREGO UN PROCEDIMIENTO Y UN TRIGGER PARA ACTUALIZAR LA TABLA DE ESTCOSTSCF##########
--------##########################################################################################################################
--create table EstCostScf(
--	tag varchar(20) not null,
--	idDrawingNum varchar(45)not null,
--	projectId varchar(30) not null,
--	M2 float,
--	SHRD float,
--	SBHRD float,
--	DSCOSTL float,
--	DSCOSTM float,
--	SCOSTMBD float,
--	DSCOSTMD float,
--	SCOSTEBD float,
--	BSCOSTEB float,
--	SCOSTEDD float,
--	SCM float,
--	SHR float,
--	SBHR float,
--	SDHR float, 
--	SCOSTL float,
--	SCOSTLB float,
--	SCOSTLD float,
--	SCOSTM float,
--	SCOSTMB float, 
--	SCOSTMD float,
--	SCOSTE float,
--	SCOSTEB float,
--	SCOSTED float,
--	STCOST float,
--	STCOSTB float,
--	STCOSTD float
--)
--go

--ALTER TABLE EstCostScf ADD CONSTRAINT pk_tag_idDrawingNum_projectId
--PRIMARY KEY (tag,idDrawingNum,projectId)
--GO

--ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_tag_EstCosScf
--FOREIGN KEY (tag) REFERENCES scaffoldEst(tag)
--go

--ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCostScf
--FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
--ON UPDATE CASCADE
--go

--ALTER TABLE EstCostScf WITH CHECK ADD CONSTRAINT fk_projectId_EstCostScf
--FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
--go
-------###########################################################################################################################
-------############# PROCEDIMIENTO ALMACENADO PARA ESTCOSTSCF ####################################################################
-------###########################################################################################################################
--create proc sp_insertUpdateEstCostScf
--@tagEst as varchar(20),
--@days as int,
--@width as float,
--@length as float,
--@heigth as float,
--@decks as int,
--@build as int,
--@idLabor as varchar(40),
--@idSCFUR as varchar(35),
--@idDrawingNum as varchar(45)
--as
--declare @idProjectEst as varchar(30) = Null
--declare @M2 as float = 0
--declare @SHRD as float = 0
--declare @SBHRD as float = 0
--declare @SDHRD as float = 0
--declare @DSCOSTL as float = 0
--declare @DSCOSTM as float = 0
--declare @SCOSTMBD as float = 0
--declare @DSCOSTMD as float = 0
--declare @SCOSTEBD as float = 0
--declare @BSCOSTEB as float = 0
--declare @SCOSTEDD  as float = 0
--declare @SCM as float = 0
--declare @SHR as float = 0
--declare @SBHR as float = 0
--declare @SDHR as float = 0
--declare @SCOSTL as float = 0
--declare @SCOSTLB as float = 0
--declare @SCOSTLD as float = 0
--declare @SCOSTM as float = 0
--declare @SCOSTMB as float = 0
--declare @SCOSTMD as float = 0
--declare @SCOSTE as float = 0
--declare @SCOSTEB as float = 0
--declare @SCOSTED as float = 0
--declare @STCOST as float = 0
--declare @STCOSTB as float = 0
--declare @STCOSTD as float = 0
--declare @buildPercent as float = 0
--declare @dismantlePercent as float = 0
--begin
--	set @idProjectEst = (select projectId from drawing where idDrawingNum = @idDrawingNum)
--	set @M2 = FORMAT(((ISNULL( @width,0)*ISNULL(@length,0)*ISNULL(@decks,0))/10.76391),'###.00')
--	set @SHRD = ROUND((@M2/(select laborB from scfUnitsRates where idSCFUR = @idSCFUR)),1)
--	set @buildPercent = (select buildPercent from scfUnitsRates where idSCFUR = @idSCFUR)
--	set @SBHRD = ROUND(( @SHRD * (@buildPercent/100)),1)
--	set @SDHRD = @SHRD - @SBHRD

--	set @DSCOSTL = ROUND((@SBHRD * (select scafRate from laborRate where idLaborRate = @idLabor)),2) + ROUND((@SDHRD * (select scafRate from laborRate where idLaborRate = @idLabor)),2)
--	set @DSCOSTM = ROUND((@SHRD * (select materialB from scfUnitsRates where idSCFUR = @idSCFUR)),2)
--	set @SCOSTMBD = ROUND((@SBHRD * (select materialB from scfUnitsRates where idSCFUR = @idSCFUR)),2)
--	set @DSCOSTMD = @DSCOSTM - @SCOSTMBD
				
--	set @SCOSTEBD = ROUND((@SHRD * (select equipmentB from scfUnitsRates where idSCFUR = @idSCFUR)),2)
--	set @BSCOSTEB = ROUND((@SBHRD * (select equipmentB from scfUnitsRates where idSCFUR = @idSCFUR)),2)
--	set @SCOSTEDD = (@SCOSTEBD - @BSCOSTEB)

--	set @SCM = ROUND(((@width * @heigth * @length)/35.3),2)
--	set @SHR = ROUND((@SCM / (select top 1 laborD from scfUnitsRates where idSCFUR = @idSCFUR)),1)
--	set @dismantlePercent = (select top 1 dismantlePercent from scfUnitsRates where idSCFUR = @idSCFUR)
--	set @SBHR = ROUND((@SHR * (@dismantlePercent/100)),1)
--	set @SDHR = @SHR - @SBHR

--	set @SCOSTL = (ROUND((@SBHR * (select top 1 scafRate from laborRate where idLaborRate = @idLabor)),2) + ROUND((@SDHR * (select top 1 scafRate from laborRate where idLaborRate = @idLabor)),2))
--	set @SCOSTLB = ROUND((@SBHR * (select top 1 scafRate from laborRate where idLaborRate = @idLabor)),2)
--	set @SCOSTLD = @SCOSTL - @SCOSTLB		
--	set @SCOSTM = ROUND((@SHR * (select top 1 materialD from scfUnitsRates where idSCFUR = @idSCFUR)),2)
--	set @SCOSTMB = ROUND((@SBHR * (select top 1 materialD from scfUnitsRates where idSCFUR = @idSCFUR)),2)
--	set @SCOSTMD = @SCOSTM - @SCOSTMB
				
--	set @SCOSTE = ROUND((@SHR * (select top 1 equipmentD from scfUnitsRates where idSCFUR = @idSCFUR)),2) 
--	set @SCOSTEB = ROUND((@SBHR * (select top 1 equipmentD from scfUnitsRates where idSCFUR = @idSCFUR)),2)
--	set @SCOSTED = @SCOSTE - @SCOSTEB	

--	set @STCOST = ISNULL(@SCOSTL,0) + ISNULL(@SCOSTM,0) + ISNULL(@SCOSTE,0)
--	set @STCOSTB = ISNULL(@SCOSTLB,0) + ISNULL(@SCOSTMB,0) + ISNULL(@SCOSTEB,0)
--	set @STCOSTD = ISNULL(@SCOSTLD,0) + ISNULL(@SCOSTMD,0) + ISNULL(@SCOSTED,0)
				 
--	if (select count(*) from EstCostScf where tag=@tagEst and idDrawingNum=@idDrawingNum and projectId = @idProjectEst)= 0 
--	begin  
--		insert into EstCostScf values (@tagEst,@idDrawingNum,@idProjectEst,@M2, @SHRD ,@SBHRD ,@DSCOSTL ,@DSCOSTM ,@SCOSTMBD ,@DSCOSTMD ,@SCOSTEBD ,@BSCOSTEB ,@SCOSTEDD ,@SCM ,@SHR ,@SBHR ,@SDHR ,@SCOSTL ,@SCOSTLB ,@SCOSTLD ,@SCOSTM ,@SCOSTMB ,@SCOSTMD ,@SCOSTE ,@SCOSTEB ,@SCOSTEBD ,@STCOST ,@STCOSTB ,@STCOSTD)
--		exec sp_insertUpdateEstCostBuild @tagEst,@idDrawingNum,@width,@length,@decks,@idSCFUR,@idLabor
--		exec sp_insertUpdateEstCostDism @tagEst,@idDrawingNum,@width,@length,@decks,@idSCFUR,@idLabor
--	end 
--	else if(select count(*) from EstCostScf where tag=@tagEst and idDrawingNum=@idDrawingNum and projectId = @idProjectEst)>0 
--	begin
--		update EstCostScf set M2 = @M2, SHRD = @SHRD , DSCOSTL = @DSCOSTL, DSCOSTM = @DSCOSTM, SCOSTMBD = @SCOSTMBD,DSCOSTMD = @DSCOSTMD,SCOSTEBD = @SCOSTEBD,BSCOSTEB = @BSCOSTEB, SCOSTEDD = @SCOSTEDD, SCM = @SCM,SHR = @SHR,SBHR = @SBHR,SDHR =@SDHR,SCOSTL = @SCOSTL,SCOSTLB = @SCOSTLB, SCOSTLD = @SCOSTLD,SCOSTM = @SCOSTM,SCOSTMB = @SCOSTMB,SCOSTMD = @SCOSTMD,SCOSTE = @SCOSTE,SCOSTEB = @SCOSTEB,SCOSTED = @SCOSTED,STCOST = @STCOST,STCOSTB = @STCOSTB,STCOSTD = @STCOSTD where tag = @tagEst and idDrawingNum = @idDrawingNum and projectId = @idProjectEst
--		exec sp_insertUpdateEstCostBuild @tagEst,@idDrawingNum,@width,@length,@decks,@idSCFUR,@idLabor
--		exec sp_insertUpdateEstCostDism @tagEst,@idDrawingNum,@width,@length,@decks,@idSCFUR,@idLabor
--	end
--end
--go
-------###########################################################################################################################
-------############# TRIGGER PARA ESTCOSTSCF #####################################################################################
-------###########################################################################################################################
--create trigger addCostScfEsDr
--on scaffoldEst 
--after insert , Update
--as
--begin
--	declare @idProjectEst as varchar(30) = Null
--	declare @M2 as float = 0
--	declare @SHRD as float = 0
--	declare @SBHRD as float = 0
--	declare @SDHRD as float = 0
--	declare @DSCOSTL as float = 0
--	declare @DSCOSTM as float = 0
--	declare @SCOSTMBD as float = 0
--	declare @DSCOSTMD as float = 0
--	declare @SCOSTEBD as float = 0
--	declare @BSCOSTEB as float = 0
--	declare @SCOSTEDD  as float = 0
--	declare @SCM as float = 0
--	declare @SHR as float = 0
--	declare @SBHR as float = 0
--	declare @SDHR as float = 0
--	declare @SCOSTL as float = 0
--	declare @SCOSTLB as float = 0
--	declare @SCOSTLD as float = 0
--	declare @SCOSTM as float = 0
--	declare @SCOSTMB as float = 0
--	declare @SCOSTMD as float = 0
--	declare @SCOSTE as float = 0
--	declare @SCOSTEB as float = 0
--	declare @SCOSTED as float = 0
--	declare @STCOST as float = 0
--	declare @STCOSTB as float = 0
--	declare @STCOSTD as float = 0
--	declare @buildPercent as float = 0
--	declare @dismantlePercent as float = 0
--	set @idProjectEst = (select projectId from drawing where idDrawingNum = (select idDrawingNum from inserted))
--	set @M2 = FORMAT((ISNULL((select width from inserted),0)*ISNULL((select length from inserted),0)*ISNULL((select decks from inserted),0))/10.76391,'###.00')
--	set @SHRD = ROUND((@M2/(select laborB from scfUnitsRates where idSCFUR =(select idSCFUR from inserted))),1)
--	set @buildPercent = (select buildPercent from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))
--	set @SBHRD = ROUND(( @SHRD * (@buildPercent/100)),1)
--	set @SDHRD = @SHRD - @SBHRD 

--	set @DSCOSTL = ROUND((@SBHRD * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))) + (@SDHRD * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))),2)
--	set @DSCOSTM = ROUND((@SHRD * (select materialB from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
--	set @SCOSTMBD = ROUND((@SBHRD * (select materialB from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
--	set @DSCOSTMD = @DSCOSTM - @SCOSTMBD

--	set @SCOSTEBD = ROUND((@SHRD * (select equipmentB from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
--	set @BSCOSTEB = ROUND((@SBHRD * (select equipmentB from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
--	set @SCOSTEDD = (@SCOSTEBD - @BSCOSTEB)

--	set @SCM = ROUND((((select width from inserted) * (select [length] from inserted) * (select heigth from inserted))/35.3),2)
--	set @SHR = ROUND((@SCM / (select laborD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),1)
--	set @dismantlePercent = (select dismantlePercent from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))
--	set @SBHR = ROUND((@SHR * (@dismantlePercent/100)),1)
--	set @SDHR = @SHR - @SBHR

--	set @SCOSTL = (ROUND((@SBHR * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))),2) + ROUND((@SDHR * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))),2))
--	set @SCOSTLB = ROUND((@SBHR * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))),2)
--	set @SCOSTLD = @SCOSTL - @SCOSTLB 
				
--	set @SCOSTM = ROUND((@SHR * (select materialD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
--	set @SCOSTMB = ROUND((@SBHR * (select materialD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
--	set @SCOSTMD = @SCOSTM - @SCOSTMB
				
--	set @SCOSTE = ROUND((@SHR * (select equipmentD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2) 
--	set @SCOSTEB = ROUND((@SBHR * (select equipmentD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
--	set @SCOSTED = @SCOSTE - @SCOSTEB

--	set @STCOST = ISNULL(@SCOSTL,0) + ISNULL(@SCOSTM,0) + ISNULL(@SCOSTE,0)
--	set @STCOSTB = ISNULL(@SCOSTLB,0) + ISNULL(@SCOSTMB,0) + ISNULL(@SCOSTEB,0)
--	set @STCOSTD = ISNULL(@SCOSTLD,0) + ISNULL(@SCOSTMD,0) + ISNULL(@SCOSTED,0)
				 
--	if (select count(*) from EstCostScf where tag=(select tag from inserted) and idDrawingNum=(select idDrawingNum from inserted) and projectId = @idProjectEst)= 0 
--	begin  
--		insert into EstCostScf values ((select tag from inserted),(select idDrawingNum from inserted),@idProjectEst,@M2, @SHRD ,@SBHRD ,@DSCOSTL ,@DSCOSTM ,@SCOSTMBD ,@DSCOSTMD ,@SCOSTEBD ,@BSCOSTEB ,@SCOSTEDD ,@SCM ,@SHR ,@SBHR ,@SDHR ,@SCOSTL ,@SCOSTLB ,@SCOSTLD ,@SCOSTM ,@SCOSTMB ,@SCOSTMD ,@SCOSTE ,@SCOSTEB ,@SCOSTEBD ,@STCOST ,@STCOSTB ,@STCOSTD)
--	end 
--	else if(select count(*) from EstCostScf where tag=(select tag from inserted) and idDrawingNum=(select idDrawingNum from inserted) and projectId = @idProjectEst)>0 
--	begin
--		update EstCostScf set M2 = @M2, SHRD = @SHRD , DSCOSTL = @DSCOSTL, DSCOSTM = @DSCOSTM, SCOSTMBD = @SCOSTMBD,DSCOSTMD = @DSCOSTMD,SCOSTEBD = @SCOSTEBD,BSCOSTEB = @BSCOSTEB, SCOSTEDD = @SCOSTEDD, SCM = @SCM,SHR = @SHR,SBHR = @SBHR,SDHR =@SDHR,SCOSTL = @SCOSTL,SCOSTLB = @SCOSTLB, SCOSTLD = @SCOSTLD,SCOSTM = @SCOSTM,SCOSTMB = @SCOSTMB,SCOSTMD = @SCOSTMD,SCOSTE = @SCOSTE,SCOSTEB = @SCOSTEB,SCOSTED = @SCOSTED,STCOST = @STCOST,STCOSTB = @STCOSTB,STCOSTD = @STCOSTD where tag = (select tag from inserted) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @idProjectEst
--	end
--end
--go

--------##########################################################################################################################
--------########## TABLA DE ESTCOSTEQ SE LE AGREGO UN PROCEDIMIENTO Y UN TRIGGER PARA ACTUALIZAR LA TABLA DE ESTCOSTEQ ###########
--------##########################################################################################################################
--CREATE TABLE EstCostEq(
--	tag varchar(20) not null,
--	idDrawingNum varchar(45)not null,
--	projectId varchar(30) not null,
----SCF
--	IRESQF float,
--	ACMH float ,
--	EIRHRS float,
--	EIRCOSTL float,
--	EIRCOSTM float,
--	EIRCOSTE float,
--	EIRTCOST float,
----INSTALATION INSULATION
--	IIESQF float,
--	EIIHRS float,
--	EIICOSTL float,
--	EIICOSTM float,
--	EIICOSTE float,
--	EIITCOST float,
----PAINT 
--	PESQF float,
--	EPHRS float,
--	EPCOSTL float,
--	EPCOSTM float,
--	EPCOSTE float,
--	EPTCOST float
--)
--go

--ALTER TABLE EstCostEq ADD CONSTRAINT pk_tag_idDrawingnum_projectId_EstCostEq
--PRIMARY KEY (tag,idDrawingNum,projectId)
--go

--ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idEquipmentEst_EstCosteq
--FOREIGN KEY (tag) REFERENCES equipmentEst(idEquipmentEst)
--go 

--ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idDrawingNum_EstCosteq
--FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
--ON UPDATE CASCADE
--go 

--ALTER TABLE EstCostEq WITH CHECK ADD CONSTRAINT fk_idEquipmentEst_EstCosteq
--FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
--go 
-------###########################################################################################################################
-------############# PROCEDIMENTO ALAMACENDO PARA ACTUALIZAR LA TABLA DE ESTCOSTEQ ###############################################
-------###########################################################################################################################
--create proc sp_insertUpdateEstCostEq 
--@idEquipmentEst as int,
--@elevation as int,
--@systemPntEq as varchar(10),
--@pntOption as varchar(25),
--@type as varchar(25),
--@thick as float,
--@idJacket as varchar(25),
--@remIns as bit,
--@idLaborRmv as varchar(40),
--@sqrFtRmv as float ,
--@idLaborPnt as varchar(40),
--@sqrFtPnt as float,
--@idLaborII as varchar(40),
--@sqrFtII as float,
--@bevel as float,
--@cutout as float,
--@acm as bit,
--@idDrawingNum as varchar(45)
--as
--declare @IPEFFACTOR as float = 0
--declare @projectId as varchar(30) = NULL
----REMOVAL
--declare @IRESQF  as float = 0
--declare @ACMH as float = 0
--declare @EIRHRS as float = 0
--declare @EIRCOSTL  as float = 0
--declare @EIRCOSTM as float = 0
--declare @EIRCOSTE as float = 0
--declare @EIRTCOST as float = 0
----INSTALATION INSULATION
--declare @IIESQF as float = 0
--declare @EIIHRS as float = 0
--declare @EIICOSTL as float = 0
--declare @EIICOSTM as float = 0
--declare @EIICOSTE as float = 0
--declare @EIITCOST as float = 0
----PAINT 
--declare @PESQF as float = 0
--declare @EPHRS as float = 0
--declare @EPCOSTL as float = 0
--declare @EPCOSTM as float = 0
--declare @EPCOSTE as float = 0
--declare @EPTCOST as float = 0
--declare @error as int  = 0
--begin 
--	set @projectId = (select projectId from drawing where idDrawingNum = @idDrawingNum)
--	--REMOVAL
--	set @IPEFFACTOR = (select top 1 [percent] from factorElevationPaint where elevation = @elevation)
--	set @IRESQF = @sqrFtRmv * iif(@idLaborRmv is not NULL,1,0) 
--	set @ACMH = iif(@acm = 1 , (@IRESQF * (select top 1 isnull(laborProd,0) from eqInsUnitRate where [type] = @type and thick = @thick )* @IPEFFACTOR * (select top 1 laborProd from eqJktUnitRate where idJacket = @idJacket)),1)*3.5
--	set @EIRHRS = ROUND((@IRESQF * (select top 1 isnull(laborProd,0) from eqInsUnitRate where [type] = @type and thick = @thick) * @IPEFFACTOR * (select top 1 laborProd from eqJktUnitRate where idJacket = @idJacket)),1) + ISNULL(@ACMH,0)
--	set @EIRCOSTL = ROUND((@EIRHRS * (select top 1 insRate from laborRate where idLaborRate = @idLaborRmv)) ,2)
--	set @EIRCOSTM = ROUND((@IRESQF * (select top 1 isnull(matRate,0) from eqInsUnitRate where [type] = @type and thick = @thick) * (select top 1 isnull(matFactor,1) from eqJktUnitRate where idJacket = @idJacket)),2)
--	set @EIRCOSTE = ROUND((@IRESQF * (select top 1 isnull(eqRate,0) from eqInsUnitRate where [type] = @type and thick = @thick) * (select top 1 isnull(eqFactor,1) from eqJktUnitRate where idJacket = @idJacket)),2) 
--	set @EIRTCOST = ISNULL(@EIRCOSTL,0)+ISNULL(@EIRCOSTM,0)+ISNULL(@EIRCOSTE,0)
--	--INTALATION INSULATION
--	set @IIESQF = @sqrFtII + (@bevel * (select top 1 bebel from insfitting where [type] = @type)) + (@cutout * (select cutOut from insfitting where [type]=@type)) 
--	set @EIIHRS = ROUND((@IIESQF * (select top 1 isnull(laborProd,0) from eqPaintUnitRate where systemPntEq = @systemPntEq and pntOption = @pntOption) * @IPEFFACTOR * (select top 1 isnull(laborProd,1) from eqJktUnitRate where idJacket = @idJacket)),2)
--	set @EIICOSTL = ROUND((@EIIHRS * (select top 1 insRate from laborRate where idLaborRate = @idLaborII)),2) 
--	set @EIICOSTM = ROUND((@IIESQF * (select top 1 isnull(matRate,0) from eqInsUnitRate where [type] = @type and thick = @thick) * (select top 1 isnull(matFactor,1) from eqJktUnitRate where idJacket = @idJacket)),2) 
--	set @EIICOSTE = ROUND((@IIESQF * (select top 1 isnull(eqRate,0) from eqInsUnitRate where [type] = @type and thick = @thick) * (select top 1 isnull(eqFactor,1) from eqJktUnitRate where idJacket = @idJacket)),2) --------------------------------|<-| | |
--	set @EIITCOST = ISNULL(@EIICOSTL,0)+ISNULL(@EIICOSTM,0)+ISNULL(@EIICOSTE,0)
--	--PAINT
--	set @EPHRS = ROUND((@sqrFtPnt * (select top 1 isnull(laborProd,0) from eqPaintUnitRate where systemPntEq = @systemPntEq and pntOption = @pntOption)  * @IPEFFACTOR),1)
--	set @EPCOSTL = ROUND((@EPHRS *(select top 1 paintRate from laborRate where idLaborRate = @idLaborPnt)),2)
--	set @EPCOSTM = ROUND((@sqrFtPnt * (select top 1 isnull(matRate,0) from eqInsUnitRate where [type] = @type and thick = @thick)),2) ------------------|  |<-------------------| |
--	set @EPCOSTE = ROUND((@sqrFtPnt * (select top 1 isnull(eqRate,0) from eqInsUnitRate where [type] = @type and thick = @thick)),2) ---------------------|<-----------------| | |
--	set @EPTCOST = ISNULL(@EPCOSTL,0) + ISNULL(@EPCOSTM,0) + ISNULL(@EPCOSTE,0)
			
--	if (select count(*) from EstCostEq where tag=@idEquipmentEst and idDrawingNum=@idDrawingNum and projectId = @projectId)= 0 
--	begin  
--		insert into EstCostEq values (@idEquipmentEst,@idDrawingNum,@projectId,@IRESQF,@ACMH,@EIRHRS,@EIRCOSTL,@EIRCOSTM,@EIRCOSTE,@EIRTCOST,@IIESQF,@EIIHRS,@EIICOSTL,@EIICOSTM,@EIICOSTE,@EIITCOST,@PESQF,@EPHRS,@EPCOSTL,@EPCOSTM,@EPCOSTE,@EPTCOST)
--	end 
--	else if(select count(*) from EstCostEq where tag=@idEquipmentest and idDrawingNum=@idDrawingNum and projectId = @projectId)>0 
--	begin
--		update EstCostEq set @IRESQF = @IRESQF,ACMH=@ACMH,EIRHRS= @EIRHRS,EIRCOSTL=@EIRCOSTL,EIRCOSTM=@EIRCOSTM,EIRCOSTE=@EIRCOSTE,EIRTCOST=@EIRTCOST,IIESQF=@IIESQF,EIIHRS=@EIIHRS,EIICOSTL=@EIICOSTL,EIICOSTM=@EIICOSTM,EIICOSTE=@EIICOSTE,EIITCOST=@EIITCOST,PESQF=@PESQF,EPHRS=@EPHRS,EPCOSTL=@EPCOSTL,EPCOSTM=@EPCOSTM,EPCOSTE=@EPCOSTE,EPTCOST=@EPTCOST where tag = @idEquipmentEst and idDrawingNum = @idDrawingNum and projectId = @projectId
--	end
--end
--go
-------###########################################################################################################################
-------############# TRIGGER PARA ESTCOSTEQ ######################################################################################
-------###########################################################################################################################
--create trigger addCostEqEsDr
--on equipmentEst 
--after insert , Update
--as
--begin
--	declare @IPEFFACTOR as float = 0
--	declare @projectId as varchar(30) = NULL
--	--REMOVAL
--	declare @IRESQF  as float = 0
--	declare @ACMH as float = 0
--	declare @EIRHRS as float = 0
--	declare @EIRCOSTL  as float = 0
--	declare @EIRCOSTM as float = 0
--	declare @EIRCOSTE as float = 0
--	declare @EIRTCOST as float = 0
--	--INSTALATION INSULATION
--	declare @IIESQF as float = 0
--	declare @EIIHRS as float = 0
--	declare @EIICOSTL as float = 0
--	declare @EIICOSTM as float = 0
--	declare @EIICOSTE as float = 0
--	declare @EIITCOST as float = 0
--	--PAINT 
--	declare @PESQF as float = 0
--	declare @EPHRS as float = 0
--	declare @EPCOSTL as float = 0
--	declare @EPCOSTM as float = 0
--	declare @EPCOSTE as float = 0
--	declare @EPTCOST as float = 0
	
--	set @projectId = (select projectId from drawing where idDrawingNum = (select idDrawingNum from inserted))
--	--REMOVAL
--	set @IPEFFACTOR = (select top 1 [percent] from factorElevationPaint where elevation = (select elevation from inserted))
--	set @IRESQF = (select sqrFtRmv from inserted)* iif((select idLaborRateRmv from inserted) is not NULL,1,0) 
--	set @ACMH = iif((select acm from inserted) = 1 , (@IRESQF * (select isnull(laborProd,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted))* @IPEFFACTOR * (select laborProd from eqJktUnitRate where idJacket = (select idJacket from inserted))),1)*3.5
--	set @EIRHRS = ROUND((@IRESQF * (select isnull(laborProd,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted)) * @IPEFFACTOR * (select laborProd from eqJktUnitRate where idJacket = (select idJacket from inserted))),1) + ISNULL(@ACMH,0)
--	set @EIRCOSTL = ROUND((@EIRHRS * (select insRate from laborRate where idLaborRate = (select idLaborRateRmv from inserted))) ,2)
--	set @EIRCOSTM = ROUND((@IRESQF * (select isnull(matRate,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select isnull(matFactor,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2)
--	set @EIRCOSTE = ROUND((@IRESQF * (select isnull(eqRate,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select isnull(eqFactor,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2) 
--	set @EIRTCOST = ISNULL(@EIRCOSTL,0)+ISNULL(@EIRCOSTM,0)+ISNULL(@EIRCOSTE,0)
--	--INTALATION INSULATION
--	set @IIESQF = (select sqrFtII from inserted) + ((select bevel from inserted) * (select bebel from insfitting where [type] = (select [type] from inserted))) + ((select cutOut from inserted) * (select cutOut from insfitting where [type]=(select [type] from inserted))) 
--	set @EIIHRS = ROUND((@IIESQF * (select isnull(laborProd,0) from eqPaintUnitRate where systemPntEq = (select systemPntEq from inserted) and pntOption = (select pntOption from inserted)) * @IPEFFACTOR * (select isnull(laborProd,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2)
--	set @EIICOSTL = ROUND((@EIIHRS * (select insRate from laborRate where idLaborRate = (select idLaborRateII from inserted))),2) 
--	set @EIICOSTM = ROUND((@IIESQF * (select isnull(matRate,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select isnull(matFactor,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2) 
--	set @EIICOSTE = ROUND((@IIESQF * (select isnull(eqRate,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select isnull(eqFactor,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2)
--	set @EIITCOST = ISNULL(@EIICOSTL,0)+ISNULL(@EIICOSTM,0)+ISNULL(@EIICOSTE,0)
--	--PAINT
--	set @EPHRS = ROUND(((select sqrFtPnt from inserted) * (select isnull(laborProd,0) from eqPaintUnitRate where systemPntEq = (select systemPntEq from inserted) and pntOption = (select pntOption from inserted))  * @IPEFFACTOR),1)
--	set @EPCOSTL = ROUND((@EPHRS *(select paintRate from laborRate where idLaborRate = (select idLaborRatePnt from inserted))),2)
--	set @EPCOSTM = ROUND(((select sqrFtPnt from inserted) * (select isnull(matRate,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted))),2) ------------------|  |<-------------------| |
--	set @EPCOSTE = ROUND(((select sqrFtPnt from inserted) * (select isnull(eqRate,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted))),2) ---------------------|<-----------------| | |
--	set @EPTCOST = ISNULL(@EPCOSTL,0) + ISNULL(@EPCOSTM,0) + ISNULL(@EPCOSTE,0)
			
--	if (select count(*) from EstCostEq where tag= (select idEquimentEst from inserted) and idDrawingNum=(select idDrawingNum from inserted) and projectId = @projectId)= 0 
--	begin  
--		insert into EstCostEq values ((select idEquimentEst from inserted),(select idDrawingNum from inserted),@projectId,@IRESQF,@ACMH,@EIRHRS,@EIRCOSTL,@EIRCOSTM,@EIRCOSTE,@EIRTCOST,@IIESQF,@EIIHRS,@EIICOSTL,@EIICOSTM,@EIICOSTE,@EIITCOST,@PESQF,@EPHRS,@EPCOSTL,@EPCOSTM,@EPCOSTE,@EPTCOST)
--	end 
--	else if(select count(*) from EstCostEq where tag=(select idEquimentEst from inserted) and idDrawingNum=(select idDrawingNum from inserted) and projectId = @projectId)>0 
--	begin
--		update EstCostEq set @IRESQF = @IRESQF,ACMH=@ACMH,EIRHRS= @EIRHRS,EIRCOSTL=@EIRCOSTL,EIRCOSTM=@EIRCOSTM,EIRCOSTE=@EIRCOSTE,EIRTCOST=@EIRTCOST,IIESQF=@IIESQF,EIIHRS=@EIIHRS,EIICOSTL=@EIICOSTL,EIICOSTM=@EIICOSTM,EIICOSTE=@EIICOSTE,EIITCOST=@EIITCOST,PESQF=@PESQF,EPHRS=@EPHRS,EPCOSTL=@EPCOSTL,EPCOSTM=@EPCOSTM,EPCOSTE=@EPCOSTE,EPTCOST=@EPTCOST where tag = (select idEquimentEst from inserted) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @projectId
--	end
--end
--go
--------##########################################################################################################################
--------########## TABLA DE ESTCOSTPP SE LE AGREGO UN PROCEDIMIENTO Y UN TRIGGER PARA ACTUALIZAR LA TABLA DE ESTCOSTPP ###########
--------##########################################################################################################################
--create table EstCostPp(
--	tag varchar(20) not null,
--	idDrawingNum varchar(45)not null,
--	projectId varchar(30) not null,
--	IRELF float ,
--	--ROMOVAL
--	ACMH float ,
--	PIRHRS float ,
--	PIRCOSTL float ,
--	PIRCOSTM float ,
--	PIRCOSTE float ,
--	PIRTCOST float ,
--	--INSTALATION INSULATION
--	IIELF float ,
--	PIIHRS float ,
--	PIICOSTL float ,
--	PIICOSTM float ,
--	PIICOSTE float ,
--	PIITCOST float ,
--	--PAINT
--	PESQF float ,
--	PPHRS float ,
--	PPCOSTL float ,
--	PPCOSTM float ,
--	PPCOSTE float ,
--	PPTCOST float
--)
--go

--ALTER TABLE EstCostPp ADD CONSTRAINT pk_tag_idDrawingNum_projecId
--PRIMARY KEY (tag,idDrawingNum,projectId)
--go

--ALTER TABLE EstCostPp ADD CONSTRAINT fk_idDrawingNum_EstCostPp
--FOREIGN KEY (idDrawingNum) REFERENCES drawing(idDrawingNum)
--on update cascade
--go

--ALTER TABLE EstCostPp ADD CONSTRAINT fk_projectId_EstCostPp
--FOREIGN KEY (projectId) REFERENCES projectClientEst(projectId)
--go
-------###########################################################################################################################
-------############# PROCEDIMENTO ALAMACENDO PARA ACTUALIZAR LA TABLA DE ESTCOSTPP ###############################################
-------###########################################################################################################################
--create proc sp_InsertUpdateEstCostPp
--@idPipingEst as int, 	
--@size as float,
--@type as varchar(25),
--@thick as float,
--@systemPntPP as varchar(10), 	
--@pntOption as varchar(25), 
--@idJacket as varchar(25),
--@elevation as int,
--@idLaborRateRmv	as varchar(40),
--@lFtRmv	as float,
--@idLaborRatePnt	as varchar(40),
--@lFtPnt	as float,
--@p90Pnt	as float,
--@p45Pnt	as int,
--@pTeePnt as int,	
--@pPairPnt as int,
--@pVlvPnt as int,
--@pControlPnt as int,
--@pWeldPnt as int,
--@idLaborRateII as varchar(40),
--@lFtII as float,
--@p90II as int,
--@p45II as int,
--@pBendII as int,
--@pTeeII as int,
--@pReducII as int,	
--@pCapsII as int,
--@pPairII as int,
--@pVlvII	as int,
--@pControlII	as int,
--@pWeldII as int,
--@pCutOutII as int,
--@psupportII	as int,
--@acm as bit,
--@idDrawingNum as varchar(45)
--as
--declare @projectId as varchar(45) = NULL
--declare @error as bit = 0
--declare @IPPEFFACTOR as float = 0
----REMOVAL
--declare @IRELF as float =0
--declare @ACMH as float =0
--declare @PIRHRS as float =0
--declare @PIRCOSTL as float =0
--declare @PIRCOSTM as float =0
--declare @PIRCOSTE as float =0
--declare @PIRTCOST as float =0
----INSTALATION INSULATION
--declare @IIELF as float =0
--declare @PIIHRS as float =0
--declare @PIICOSTL as float =0
--declare @PIICOSTM as float =0
--declare @PIICOSTE as float =0
--declare @PIITCOST as float =0
----PAINT
--declare @PESQF as float =0
--declare @PPHRS as float =0
--declare @PPCOSTL as float =0
--declare @PPCOSTM as float =0
--declare @PPCOSTE as float =0
--declare @PPTCOST as float =0 
--begin 
--	set @projectId = (select projectId from drawing where idDrawingNum = @idDrawingNum)
--	--REMOVAl
--	set @IPPEFFACTOR = (select ISNULL([percent],0) from factorElevationPaint where elevation = @elevation)/100
--	set @IRELF=  @lFtRmv * IIF(@idLaborRateRmv is not NULL,1,0)
--	set @ACMH= IIF(@ACM = 1,ROUND(( @IRELF * (select laborProd from ppInsUnitRate where size =@size and [type]= @type and thick = @thick) * @IPPEFFACTOR * (select top 1 laborProd from ppJktUnitRate where idJacket = @idJacket)),1),1)*3
--	set @PIRHRS= ROUND((@IRELF * (select top 1 laborProd from ppInsUnitRate where size =@size and [type]= @type and thick = @thick) * @IPPEFFACTOR * (select top 1 laborProd from ppJktUnitRate where idJacket = @idJacket) + ISNULL(@ACMH,0)),1)
--	set @PIRCOSTL= ROUND(@PIRHRS * (select top 1 insRate from laborRate where idLaborRate = @idLaborRateRmv),2) 
--	set @PIRCOSTM= ROUND(@IRELF * (select top 1 matRate from ppInsUnitRate where size =@size and [type]= @type and thick = @thick) * (select top 1 matFactor from ppJktUnitRate where idJacket = @idJacket),2)
--	set @PIRCOSTE= ROUND(@IRELF * (select top 1 eqRate from ppInsUnitRate where size =@size and [type]= @type and thick = @thick) * (select top 1 eqFactor from ppJktUnitRate where idJacket = @idJacket) ,2) 
--	set @PIRTCOST= ISNULL(@PIRCOSTL,0)+ISNULL(@PIRCOSTM ,0)+ISNULL(@PIRCOSTE ,0) 
--	--INSTALATION INSULATION
--	set @IIELF= (@lFtII + (@p90II * (select top 1 p90 from insFitting where [type] = @type)) + (@p45II * (select top 1 p45 from insFitting where [type] = @type) ) + ( @pBendII * (select top 1 bend from insFitting where [type] = @type) ) + ( @pTeeII * (select top 1 tee from insFitting where [type] = @type) ) + ( @pReducII * (select top 1 red from insFitting where [type] = @type) ) + ( @pCapsII * (select top 1 cap from insFitting where [type] = @type) ) + ( @pPairII * (select top 1 flangePair from insFitting where [type] = @type) ) + ( @pVlvII * (select top 1 flangeVlv from insFitting where [type] = @type) ) + ( @pControlII * (select top 1 controlVlv from insFitting where [type] = @type) ) + ( @pWeldII * (select top 1 weldedVlv from insFitting where [type] = @type) ) + ( @pCutOutII * (select top 1 cutOut from insFitting where [type] = @type)) + ( @psupportII * (select top 1 support from insFitting where [type] = @type)))
--	set @PIIHRS= ROUND(@IIELF * (select top 1 laborProd from ppPaintUnitRate where systemPntPP = @systemPntPP and pntOption = @pntOption and size = @size) * @IPPEFFACTOR * (select top 1 laborProd from ppJktUnitRate where idJacket = @idJacket),1)
--	set @PIICOSTL= ROUND(@PIIHRS * (select top 1 insRate from laborRate where idLaborRate = @idLaborRateII),2)
--	set @PIICOSTM= ROUND(@IIELF * (select top 1 matRate from ppInsUnitRate where size = @size and thick = @thick and [type] = @type) * (select top 1 matFactor from ppJktUnitRate where idJacket = @idJacket),2)
--	set @PIICOSTE= ROUND(@IIELF * (select top 1 eqRate from ppInsUnitRate where size = @size and thick = @thick and [type] = @type) * (select top 1 eqFactor from ppJktUnitRate where idJacket = @idJacket) ,2) 
--	set @PIITCOST= ISNULL( @PIICOSTL ,0)+ISNULL( @PIICOSTM ,0)+ISNULL( @PIICOSTE ,0)
--	--PAINT
--	set @PESQF= IIF(@size<=3, 1, @size / 3.82 )*( @lFtPnt + (@p90Pnt * (select top 1 p90 from insFitting where [type] = @type)) + ( @p45Pnt * (select top 1 p45 from insFitting where [type] = @type) ) + ( @pTeePnt * (select top 1 tee from insFitting where [type] = @type) ) + ( @pPairPnt * (select flangePair from insFitting where [type] = @type) ) + ( @pVlvPnt * (select flangeVlv from insFitting where [type] = @type) ) + ( @pControlPnt * (select controlVlv from insFitting where [type] = @type) ) + ( @pWeldPnt * (select weldedVlv from insFitting where [type] = @type))) 
--	set @PPHRS= ROUND(@PESQF * (select top 1 laborProd from ppPaintUnitRate where systemPntPP = @systemPntPP and pntOption = @pntOption and size = @size) * @IPPEFFACTOR ,1)
--	set @PPCOSTL= ROUND(@PPHRS * (select top 1 paintRate from laborRate where idLaborRate = @idLaborRatePnt),2)
--	set @PPCOSTM= ROUND(@PESQF * (select top 1 matRate from ppPaintUnitRate where size = @size and pntOption = @pntOption and systemPntPP = @systemPntPP),2) 
--	set @PPCOSTE= ROUND(@PESQF * (select top 1 eqRate from ppPaintUnitRate where size = @size and pntOption = @pntOption and systemPntPP = @systemPntPP),2) 
--	set @PPTCOST= ISNULL(@PPCOSTL ,0)+ISNULL(@PPCOSTM ,0)+ISNULL(@PPCOSTE ,0)
--	if(select COUNT(*) from EstCostPp where tag = @idPipingEst and idDrawingNum = @idDrawingNum and projectId = @projectId)=0
--	begin
--		insert into EstCostPp values(@idPipingEst ,CONVERT(NVARCHAR, @idDrawingNum),@projectId,@IRELF,@ACMH,@PIRHRS,@PIRCOSTL,@PIRCOSTM,@PIRCOSTE,@PIRTCOST,@IIELF,@PIIHRS,@PIICOSTL,@PIICOSTM,@PIICOSTE,@PIITCOST,@PESQF,@PPHRS,@PPCOSTL,@PPCOSTM,@PPCOSTE,@PPTCOST)
--	end
--	else if(select COUNT(*) from EstCostPp where tag = @idPipingEst and idDrawingNum = @idDrawingNum and projectId = @projectId)>0
--	begin
--		update EstCostPp set IRELF = @IRELF ,ACMH = @ACMH,PIRHRS = @PIRHRS,PIRCOSTL = @PIRCOSTL,PIRCOSTM = @PIRCOSTM,PIRCOSTE = @PIRCOSTE,PIRTCOST = @PIRTCOST,IIELF = @IIELF,PIIHRS = @PIIHRS,PIICOSTL = @PIICOSTL,PIICOSTM = @PIICOSTM,PIICOSTE = @PIICOSTE,PIITCOST = @PIITCOST,PESQF = @PESQF,PPHRS = @PPHRS,PPCOSTL = @PPCOSTL,PPCOSTM = @PPCOSTM,PPCOSTE = @PPCOSTE,PPTCOST = @PPTCOST where tag = @idPipingEst and idDrawingNum = @idDrawingNum and projectId = @projectId
--	end
		
--end
--go
-------###########################################################################################################################
-------############# TRIGGER PARA ESTCOSTEQ ######################################################################################
-------###########################################################################################################################
--create TRIGGER addCostPpEst
--ON pipingEst
--after insert, update
--as 
--begin
--	declare @projectId as varchar(45) = NULL
--	declare @IPPEFFACTOR as float = 0
--	--REMOVAL
--	declare @IRELF as float =0
--	declare @ACMH as float =0
--	declare @PIRHRS as float =0
--	declare @PIRCOSTL as float =0
--	declare @PIRCOSTM as float =0
--	declare @PIRCOSTE as float =0
--	declare @PIRTCOST as float =0
--	--INSTALATION INSULATION
--	declare @IIELF as float =0
--	declare @PIIHRS as float =0
--	declare @PIICOSTL as float =0
--	declare @PIICOSTM as float =0
--	declare @PIICOSTE as float =0
--	declare @PIITCOST as float =0
--	--PAINT
--	declare @PESQF as float =0
--	declare @PPHRS as float =0
--	declare @PPCOSTL as float =0
--	declare @PPCOSTM as float =0
--	declare @PPCOSTE as float =0
--	declare @PPTCOST as float =0 
--	declare @type as varchar(25) = NULL
--	set @projectId = (select projectId from drawing where idDrawingNum = (select idDrawingNum from inserted))
--	set @type = (select [type] from inserted)
--	--REMOVAl
--	set @IPPEFFACTOR = (select ISNULL([percent],0) from factorElevationPaint where elevation = (select elevation from inserted))/100
--	set @IRELF=  (select lFtRmv from inserted) * IIF((select idLaborRateRmv from inserted) is not NULL,1,0)
--	set @ACMH= IIF((select acm from inserted) = 1,ROUND( @IRELF * (select laborProd from ppInsUnitRate where size =(select size from inserted) and [type]= (select [type] from inserted) and thick = (select thick from inserted)) * @IPPEFFACTOR * (select laborProd from ppJktUnitRate where idJacket = (select idJacket from inserted)),1),1)*3
--	set @PIRHRS= ROUND((@IRELF * (select laborProd from ppInsUnitRate where size =(select size from inserted) and [type]= (select [type] from inserted) and thick = (select thick from inserted)) * @IPPEFFACTOR * (select laborProd from ppJktUnitRate where idJacket = (select idJacket from inserted)) + ISNULL(@ACMH,0)),1)
--	set @PIRCOSTL= ROUND(@PIRHRS * (select top 1 insRate from laborRate where idLaborRate = (select idLaborRateRmv from inserted)),2) 
--	set @PIRCOSTM= ROUND(@IRELF * (select top 1 matRate from ppInsUnitRate where size =(select size from inserted) and [type]= (select [type] from inserted) and thick = (select thick from inserted)) * (select matFactor from ppJktUnitRate where idJacket = (select idJacket from inserted)),2)
--	set @PIRCOSTE= ROUND(@IRELF * (select top 1 eqRate from ppInsUnitRate where size =(select size from inserted) and [type]= (select [type] from inserted) and thick = (select thick from inserted)) * (select eqFactor from ppJktUnitRate where idJacket = (select idJacket from inserted)) ,2) 
--	set @PIRTCOST= ISNULL(@PIRCOSTL,0)+ISNULL(@PIRCOSTM ,0)+ISNULL(@PIRCOSTE ,0) 
--	--INSTALATION INSULATION
--	set @IIELF= ((select lFtII from inserted)+ ((select p90II from inserted) * (select p90 from insFitting where [type] = @type)) + ((select p45II from inserted) * (select p45 from insFitting where [type] = @type) ) + ( (select pBendII from inserted) * (select bend from insFitting where [type] = @type) ) + ( (select pTeeII from inserted) * (select tee from insFitting where [type] = @type) ) + ((select pReducII from inserted) * (select red from insFitting where [type] = @type) ) + ( (select pCapsII from inserted) * (select cap from insFitting where [type] = @type) ) + ( (select pPairII from inserted) * (select flangePair from insFitting where [type] = @type) ) + ( (select pVlvII from inserted) * (select flangeVlv from insFitting where [type] = @type) ) + ((select pControlII from inserted) * (select controlVlv from insFitting where [type] = @type) ) + ((select pWeldII from inserted) * (select weldedVlv from insFitting where [type] = @type) ) + ((select pCutOutII from inserted) * (select cutOut from insFitting where [type] = @type)) + ((select psupportII from inserted) * (select support from insFitting where [type] = @type)))
--	set @PIIHRS= ROUND(@IIELF * (select laborProd from ppPaintUnitRate where systemPntPP = (select systemPntPP from inserted) and pntOption = (select pntOption from inserted) and size = (select size from inserted)) * @IPPEFFACTOR * (select laborProd from ppJktUnitRate where idJacket = (select idJacket from inserted)),1)
--	set @PIICOSTL= ROUND(@PIIHRS * (select top 1 insRate from laborRate where idLaborRate = (select idLaborRateII from inserted)),2)
--	set @PIICOSTM= ROUND(@IIELF * (select top 1 matRate from ppInsUnitRate where size = (select size from inserted) and [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select matFactor from ppJktUnitRate where idJacket = (select idJacket from inserted)),2)
--	set @PIICOSTE= ROUND(@IIELF * (select top 1 eqRate from ppInsUnitRate where size = (select size from inserted) and [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select eqFactor from ppJktUnitRate where idJacket = (select idJacket from inserted)) ,2) 
--	set @PIITCOST= ISNULL( @PIICOSTL ,0)+ISNULL( @PIICOSTM ,0)+ISNULL( @PIICOSTE ,0)
--	--PAINT
--	set @PESQF= IIF((select size from inserted)<=3, 1, (select size from inserted) / 3.82 )*((select lFtPnt from inserted) + ((select p90Pnt from inserted) * (select p90 from insFitting where [type] = @type)) + ((select p45Pnt from inserted) * (select p45 from insFitting where [type] = @type) ) + ( (select pTeePnt from inserted) * (select tee from insFitting where [type]=@type)) + ((select pPairPnt from inserted) * (select flangePair from insFitting where [type] = @type) ) + ((select pVlvPnt from inserted) * (select flangeVlv from insFitting where [type] = @type)) + ((select pControlPnt from inserted) * (select controlVlv from insFitting where [type] = @type)) + ((select pWeldPnt from inserted) * (select weldedVlv from insFitting where [type] = @type))) 
--	set @PPHRS= ROUND(@PESQF * (select laborProd from ppPaintUnitRate where systemPntPP = (select systemPntPP from inserted) and pntOption = (select pntOption from inserted) and size = (select size from inserted)) * @IPPEFFACTOR ,1)
--	set @PPCOSTL= ROUND(@PPHRS * (select top 1 paintRate from laborRate where idLaborRate = (select idLaborRatePnt from inserted)),2)
--	set @PPCOSTM= ROUND(@PESQF * (select top 1 matRate from ppPaintUnitRate where size = (select size from inserted) and pntOption = (select pntOption from inserted) and systemPntPP = (select systemPntPP from inserted)),2) 
--	set @PPCOSTE= ROUND(@PESQF * (select top 1 eqRate from ppPaintUnitRate where size = (select size from inserted) and pntOption = (select pntOption from inserted) and systemPntPP = (select systemPntPP from inserted)),2)
--	set @PPTCOST= ISNULL(@PPCOSTL ,0)+ISNULL(@PPCOSTM ,0)+ISNULL(@PPCOSTE ,0)
--	if(select COUNT(*) from EstCostPp where tag = CONVERT(NVARCHAR, (select idPipingEst from inserted)) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @projectId)=0
--	begin
--		insert into EstCostPp values(CONVERT(NVARCHAR,(select idPipingEst from inserted)) , (select idDrawingNum from inserted),@projectId,@IRELF,@ACMH,@PIRHRS,@PIRCOSTL,@PIRCOSTM,@PIRCOSTE,@PIRTCOST,@IIELF,@PIIHRS,@PIICOSTL,@PIICOSTM,@PIICOSTE,@PIITCOST,@PESQF,@PPHRS,@PPCOSTL,@PPCOSTM,@PPCOSTE,@PPTCOST)
--	end
--	else if(select COUNT(*) from EstCostPp where tag = CONVERT(NVARCHAR,(select idPipingEst from inserted)) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @projectId)>0
--	begin
--		update EstCostPp set IRELF = @IRELF ,ACMH = @ACMH,PIRHRS = @PIRHRS,PIRCOSTL = @PIRCOSTL,PIRCOSTM = @PIRCOSTM,PIRCOSTE = @PIRCOSTE,PIRTCOST = @PIRTCOST,IIELF = @IIELF,PIIHRS = @PIIHRS,PIICOSTL = @PIICOSTL,PIICOSTM = @PIICOSTM,PIICOSTE = @PIICOSTE,PIITCOST = @PIITCOST,PESQF = @PESQF,PPHRS = @PPHRS,PPCOSTL = @PPCOSTL,PPCOSTM = @PPCOSTM,PPCOSTE = @PPCOSTE,PPTCOST = @PPTCOST where tag = CONVERT(NVARCHAR, (select idPipingEst from inserted)) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @projectId
--	end
--end
--go

--| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | 
--| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | 
--v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v v 
--------##########################################################################################################################
--------########## ESTE ES EL PROCEDIMIENTO PARA EL REPORTE DE COSTO DE ESTIMACION ############################################### VOLVER A EJECUTAR
--------##########################################################################################################################
--ALTER proc [dbo].[sp_SelectEstCostByProject]
--@projectId as varchar(40)
--as 
--begin

---- scaffold
----decks dismantle scf
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR, scfD.tag)as 'Tag' ,'SCF Deck DISM' as 'TASK',scfD.SHRD as 'HRS',scfD.DSCOSTL as 'COSTL',scfD.DSCOSTM as 'COSTM',scfD.SCOSTEDD as 'COSTE',scfD.DSCOSTL + scfD.DSCOSTMD + scfD.SCOSTEDD  as 'TCOST' 
--from EstCostDism as scfD
--inner join drawing as dr on dr.idDrawingNum = scfD.idDrawingNum
--inner join projectClientEst as po on po.projectId = scfD.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
----decks build scf
--UNION ALL
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR, scfB.tag)as 'Tag' ,'SCF Deck Build' as 'TASK',scfB.SBHR as 'HRS',scfB.SCOSTLB as 'COSTL',scfB.SCOSTMB as 'COSTM',scfB.SCOSTEB as 'COSTE', scfB.STCOST as 'TCOST' 
--from EstCostBuild as scfB
--inner join drawing as dr on dr.idDrawingNum = scfB.idDrawingNum
--inner join projectClientEst as po on po.projectId = scfB.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
----Build Scaffold
--UNION ALL
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR, scf.tag)as 'Tag' , 'Scf Build' as 'TASK', scf.SHR as 'HRS',scf.SCOSTL as 'COSTL',scf.SCOSTM as 'COSTM',scf.SCOSTE as 'COSTE',scf.STCOST as 'TCOST' 
--from EstCostScf as scf
--inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
--inner join projectClientEst as po on po.projectId = scf.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
----Dimantle Scaffold
--UNION ALL
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR, scf.tag)as 'Tag' , 'SCF Demo' as 'TASK', scf.SDHR as 'HRS',scf.SCOSTLD as 'COSTL',scf.SCOSTMD as 'COSTM',scf.SCOSTED as 'COSTE',scf.STCOSTD as 'TCOST' 
--from EstCostScf as scf
--inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
--inner join projectClientEst as po on po.projectId = scf.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
---- EQUIPMENT 
----REMOVE
--UNION ALL
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR, eq.tag) as 'Tag', 'Remove' as 'TASK',eq.EIRHRS as 'HRS',eq.EIRCOSTL as 'COSTL',eq.EIRCOSTM as 'COSTM',eq.EIRCOSTE as 'COSTE', eq.EIRTCOST as 'TCOST'   from EstCostEq as eq
--inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
--inner join projectClientEst as po on po.projectId = eq.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
----INSTALATION
--UNION ALL 
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR, eq.tag) as 'Tag', 'Install' as 'TASK', eq.EIIHRS as 'HRS',eq.EIICOSTL as 'COSTL',eq.EIICOSTM as 'COSTM',eq.EIICOSTE as 'COSTE', eq.EIITCOST as 'TCOST'   from EstCostEq as eq
--inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
--inner join projectClientEst as po on po.projectId = eq.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
----PAINT
--UNION ALL
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR, eq.tag) as 'Tag','Paint' as 'TASK',eq.EPHRS as 'HRS',eq.EPCOSTL as 'COSTL',eq.EPCOSTM as 'COSTM',eq.EPCOSTE as 'COSTE', eq.EPTCOST as 'TCOST'   from EstCostEq as eq
--inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
--inner join projectClientEst as po on po.projectId = eq.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
----PIPING
----REMOVE
--UNION ALL
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR , pp.tag) as 'TAG',  'Remove'as 'TASK', pp.PIRHRS as 'HRS', pp.PIRCOSTL as 'COSTL',pp.PIRCOSTM as 'COSTM',pp.PIRCOSTE as 'COSTE', pp.PIRTCOST as 'TCOST'  from EstCostPp as pp
--inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
--inner join projectClientEst as po on po.projectId = pp.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
----INSTALATION
--UNION ALL
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR , pp.tag) as 'TAG', 'Install' as 'TASK', pp.PIIHRS as 'HRS', pp.PIICOSTL as 'COSTL',pp.PIICOSTM as 'COSTM',pp.PIICOSTE as 'COSTE', pp.PIITCOST as 'TCOST'  from EstCostPp as pp
--inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
--inner join projectClientEst as po on po.projectId = pp.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
----PAINT
--UNION ALL
--select po.ProjectId, po.[description],po.unit,
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--dr.idDrawingNum,dr.[description],
--CONVERT(NVARCHAR , pp.tag) as 'TAG','Paint' as 'TASK' , pp.PPHRS as 'HRS', pp.PPCOSTL as 'COSTL',pp.PPCOSTM as 'COSTM',pp.PPCOSTE as 'COSTE', pp.PPTCOST as 'TCOST'  from EstCostPp as pp
--inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
--inner join projectClientEst as po on po.projectId = pp.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
--where po.ProjectId = @projectId
--end
--go

------##########################################################################################################################################################################################################################
------########## PROCEDIMENTO PARA REPORTE DE SCAFFOLD BUDGET ESTIMATION #######################################################################################################################################################
------##########################################################################################################################################################################################################################

--create proc [dbo].[sp_SelectScaffoldBudgetEstimate]
--	@projectId as varchar(30)
--as
--begin
--select 
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--po.projectId as 'Project' ,po.[description] as 'Description',estCScf.tag , dr.idDrawingNum , scf.location as 'Location', CONCAT(scf.width,'x',scf.[length],'x',scf.heigth) as 'Dimention',scf.build as 'Elevation',
--scf.[days] as 'Days Active',scf.idSCFUR as 'Scaf.Type', FORMAT ((((scf.width)*(scf.[length])*(scf.heigth))/35.31),'###.00') as 'M3',estCScf.M2 as 'M2', scf.idLaborRate as 'Work Week' ,
----MAN HRS 
--estCScf.SBHR as 'Man Hrs B' ,estCScf.SDHR as 'Man Hrs D',
----MAN HRS DECKS
--ISNULL((select top 1 estB.SBHR from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'Man Hrs Deck B',
--ISNULL((select top 1 estB.SDHR from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'Man Hrs Deck D',
--scf.decks as 'Decks',
----DESCKS LABOR
--ISNULL((select estB.SCOSTLB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'Decks Labor B',
--ISNULL((select estD.DSCOSTL from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'Decks Labor D',
----SCAF LABOR 
--ISNULL((select estB.SCOSTLB from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Labor B',
--ISNULL((select estB.SCOSTLD from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Labor D',
----MATERIAL
--ISNULL((select estB.SCOSTMB from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Material B',
--ISNULL((select estD.SCOSTMD from EstCostScf as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'SCF Material D',
--ISNULL((select estB.SCOSTMB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'DECK Material B',
--ISNULL((select estD.DSCOSTMD from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'DECK Material D',
----EQUIPMENT
--ISNULL((select estB.SCOSTEB from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Equipment B',
--ISNULL((select estD.SCOSTED from EstCostScf as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'SCF Equipment D',
--ISNULL((select estB.SCOSTEB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'DECK Equipment B',
--ISNULL((select estD.SCOSTEDD from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'DECK Equipment D'

--from EstCostScf as estCScf
--inner join scaffoldEst as scf on scf.idDrawingNum = estCScf.idDrawingNum and scf.tag = estCScf.tag
--inner join drawing as dr on dr.idDrawingNum = estCScf.idDrawingNum
--inner join projectClientEst as po on po.projectId = estCScf.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress
--where estCScf.projectId  = @projectId
--end
--go

------##########################################################################################################################################################################################################################
------########## PROCEDIMENTO PARA REPORTE DE EQUIPMENT BUDGET ESTIMATION ######################################################################################################################################################
------##########################################################################################################################################################################################################################

--create proc sp_SelectEquipmentBudgetEstimate
--	@projectId as varchar(30)
--as
--begin 
--	select 
--	cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--	estCEq.tag as 'ID',
--	estCEq.idDrawingNum as 'Drawing',
--	po.projectId as 'Project',
--	po.[description] as 'Description',
--	eq.idEquimentEst as 'Equipment', 
--	eq.elevation as 'Height',
--	eq.systemPntEq as 'System',
--	eq.pntOption as 'Paint Option',
--	eq.[type] as 'Ins Type',
--	eq.thick as 'Ins Thick',
--	eq.idJacket as 'JKT',
--	'Insul Removal' as 'TaskRmv',
--	eq.sqrFtRmv as 'SqrFtRmv',
--	'Insul Install' as 'TaskII',
--	eq.sqrFtII as 'SqrFtII',
--	eq.bevel as 'Bevel',
--	eq.cutout as 'Cut Out',
--	'Paint' as 'TaskPnt',
--	eq.sqrFtPnt as 'SqrFtPnt',
--	eq.acm as 'ACM',	
--	--remove
--	ISNULL(eq.idLaborRateRmv,'') as 'WW Rmv',
--	ISNULL(estCEq.EIRHRS,0) as 'Horas Rmv',
--	ISNULL(estCEq.EIRCOSTL,0) as 'Labor Rmv',
--	ISNULL(estCEq.EIRCOSTM,0) as 'Materal Rmv',
--	ISNULL(estCeq.EIRCOSTE,0) as 'Equipment Rmv',
--	--instalation
--	ISNULL(eq.idLaborRateII,'') as 'WW II',
--	ISNULL(estceq.EIIHRS,0) as 'Horas II', 
--	ISNULL(estCEq.EIICOSTL,0) as 'Labor II' ,
--	ISNULL(estCEq.EIICOSTM,0) as 'Material II',
--	ISNULL(estCEq.EIICOSTE,0) as 'Equipment II',
--	--paint
--	ISNULL(eq.idLaborRatePnt,'') as 'WW Pnt',
--	ISNULL(estCEq.EPHRS,0) as 'Horas Pnt',
--	ISNULL(estCEq.EPCOSTL,0) as 'Labor Pnt',
--	ISNULL(estCEq.EPCOSTM,0) as 'Material Pnt',
--	ISNULL(estCEq.EPCOSTE,0) as 'Equipment Pnt'
--	from EstCostEq as estCEq
--	inner join equipmentEst as eq on eq.idEquimentEst = estCEq.tag and eq.idDrawingNum = estCEq.idDrawingNum 
--	inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum and dr.idDrawingNum = estCEq.idDrawingNum  
--	inner join projectClientEst as po on po.projectId = dr.projectId and estCEq.projectId = po.projectId
--	inner join clientsEst as cl on cl.idClientEst =po.idClientEst
--	inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress
--	where po.projectId =@projectId
--end
--go

------##########################################################################################################################################################################################################################
------########## PROCEDIMENTO PARA REPORTE DE PIPING BUDGET ESTIMATION #########################################################################################################################################################
------##########################################################################################################################################################################################################################

--create proc sp_SelectPipingBudgetEstimate
--	@projectId as varchar(30)
--as
--begin
--	select 
--	cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--	estCPp.tag as 'ID',
--	pp.acm as 'ACM',
--	pp.st as 'ST',
--	estCPp.idDrawingNum as 'Drawing',
--	po.projectId as 'Project',
--	po.[description] as 'Description',
--	pp.line as 'PipingDescription',
--	pp.size as 'PZ',
--	pp.elevation as 'Elevation',
--	pp.systemPntPP as 'System',
--	pp.pntOption as 'Paint Option',
--	pp.[type] as 'InsType',
--	pp.thick as 'InsThick',
--	pp.idJacket as 'JKT',
--	pp.lFtRmv as 'LnFtRmv',
--	ISNULL(pp.idLaborRateRmv,'') as 'LaborRateRmv',
--	ISNULL(pp.lFtII,0) as 'LnFtII',
--	ISNULL(pp.p90II,0) as '90II',
--	ISNULL(pp.p45II,0) as '45II',
--	ISNULL(pp.pBendII,0) as 'BendII',
--	ISNULL(pp.pTeeII,0) as 'TEEII',
--	ISNULL(pp.pReducII,0) as 'REDII',
--	ISNULL(pp.pCapsII,0) as 'CapII',
--	ISNULL(pp.pPairII,0) as 'PairII',
--	ISNULL(pp.pVlvII,0) as 'VlvII',
--	ISNULL(pp.pControlII,0) as 'CtrlII',
--	ISNULL(pp.pWeldII,0) as 'WldII',
--	ISNULL(pp.pCutOutII,0) as 'CutOut',
--	ISNULL(pp.psupportII,0) as 'SpptII',
--	ISNULL(pp.idLaborRateII,'') as 'LaborRateII',
--	ISNULL(pp.lFtPnt,0) as 'LnFtPnt',
--	ISNULL(pp.p90Pnt,0) as '90Pnt',
--	ISNULL(pp.p45Pnt,0) as '45Pnt',
--	ISNULL(pp.pTeePnt,0) as 'TEEPnt',
--	ISNULL(pp.pPairPnt,0) as 'PairPnt',
--	ISNULL(pp.pVlvPnt,0) as 'VlvPnt',
--	ISNULL(pp.pControlPnt,0) as 'CtrlPnt',
--	ISNULL(pp.pWeldPnt,0) as 'WldPnt',
--	ISNULL(pp.idLaborRatePnt,'') as 'LaborRatePnt',
--	ISNULL(estCPp.PIRHRS,0) as 'ManHrsRmv',
--	ISNULL(estCPp.PIIHRS,0) as 'ManHrsII',
--	ISNULL(estCPp.PPHRS,0) as 'ManHrsPnt',
--	ISNULL(estCPp.PIRCOSTL,0) as 'LaborRmv',
--	ISNULL(estCPp.PIICOSTL,0) as 'LaborII',
--	ISNULL(estCPp.PPCOSTL,0) as 'LaborPnt',
--	ISNULL(estCPp.PIRCOSTM,0) as 'MaterialRmv',
--	ISNULL(estCPp.PIICOSTM,0) as 'MaterialII',
--	ISNULL(estCPp.PPCOSTM,0)  as 'MaterialPnt',
--	ISNULL(estCPp.PIRCOSTE,0) as 'EquipmentRmv',
--	ISNULL(estCPp.PIICOSTE,0) as 'EquipmentII',
--	ISNULL(estCPp.PPCOSTE,0)  as 'EquipmentPnt' 
--from EstCostPp as estCPp 
--inner join pipingEst as pp on pp.idPipingEst = estCPp.tag and pp.idDrawingNum = estCPp.idDrawingNum
--inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum and dr.idDrawingNum = estCPp.idDrawingNum
--inner join projectClientEst as po on po.projectId = dr.projectId and po.projectId = estCPp.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress
--where po.projectId = @projectId
--end
--go