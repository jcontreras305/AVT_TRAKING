use master
Go
DROP database VRT_TRAKING_2
GO
create database VRT_TRAKING_2
GO

use VRT_TRAKING_2
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

create table typeEmployee(
	idTypeEmploye int identity (20000,1) primary key not null,
	name varchar(20)
)
GO

insert into typeEmployee values ('Manager'),('Normal')
GO

create table workTMLumpSum (
	idWorkTmLumoSum int identity (30000,1) primary key not null,
	name varchar(30)
)
GO

insert into workTMLumpSum values('Lump-Sum'),('T&M'),('Unire Rate')
GO



create table costDistribution(
	idCostDistribution bigint primary key not null ,
	name varchar(30)
)
GO

insert into costDistribution values (190100000000000,'First'),(290100000000000,'Secund')
GO

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
	cordinator varchar(50)
)
GO

--##########################################################################################
--##################  TABLA DE CLASSIFICATION ##############################################
--##########################################################################################

create table classification(
	class varchar(10) primary key not null,
	name varchar(50)
)

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
--##################  TABLA DE COMPANY #####################################################
--##########################################################################################

create table company(
	idCompany varchar(36) primary key not null ,
	name varchar(30),
	country varchar(58),
	payTerms varchar(30),
	invoiceDescr text,
	idHomeAddress varchar(36),
	idContact varchar(36)  
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
	idEmployee varchar(36)
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
	days int
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
--##################  TABLA DE MATERIAL ####################################################
--##########################################################################################

create table material(
	idMaterial varchar(36) primary key not null,
	number int not null,
	name varchar(50), 
	estatus char (1) 
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

CREATE TABLE [dbo].[scfEstimation](
	[EstNumber] [varchar](36) NOT NULL primary key,
	[idAux] [varchar](36) NULL,
	[daysActive] [float] NULL,
	[unit] [varchar](30) NULL,
	[location] [text] NULL,
	[width] [float] NULL,
	[heigth] [float] NULL,
	[length] [float] NULL,
	[descks] [int] NULL,
	[groundHeigth] [int] NULL,
	[elevation] [int] NULL,
	[M3] [float] NULL,
	[M2] [float] NULL,
	[MA3] [float] NULL,
	[MA2] [float] NULL,
	[ACHT] [float] NULL,
	[idEstCost] [int] NULL,
	[scfTypeId] [int] NULL,
	[ccnum] [varchar](30) NULL
)
go

--##########################################################################################
--##################  TABLA DE SCFESTPROYECT #################################################
--##########################################################################################


CREATE TABLE [dbo].[scfEstProyect](
	[ccnum] [varchar](30) NOT NULL primary key
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
	description varchar(30)
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
	idAux varchar(36),
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
	QtyHelper int
)
GO

--##########################################################################################
--##################  TABLA DE TAXESST #####################################################
--##########################################################################################

create table taxesST(
	idTaxesST varchar(36)primary key not null,
	idAux varchar(36),
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
	QtyHelper int
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
--##################  FOREIG KEYS COMPANY ##################################################
--##########################################################################################

ALTER TABLE [dbo].[company] WITH CHECK ADD CONSTRAINT [fk_idHomeAddress] FOREIGN KEY ([idHomeAddress])
REFERENCES [dbo].[homeAddress] ([idHomeAdress])
GO

ALTER  TABLE [dbo].[company] WITH CHECK ADD CONSTRAINT [fk_idContact] FOREIGN KEY  ([idContact])
REFERENCES [dbo].[contact]([idContact])
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
--##################  FOREIG KEYS EMPLOYEES ################################################
--##########################################################################################

ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [fk_idContact_EM] FOREIGN KEY([idContact])
REFERENCES [dbo].[contact] ([idContact])
GO

ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [fk_idHomeAdress_employees] FOREIGN KEY([idHomeAdress])
REFERENCES [dbo].[HomeAddress] ([idHomeAdress])
GO

--##########################################################################################
--##################  FOREIG KEYS ESTMETERS ###############################################
--##########################################################################################

ALTER TABLE EstMeters  WITH CHECK ADD  CONSTRAINT fk_EstNumber_EstMeters FOREIGN KEY(EstNumber)
REFERENCES scfEstimation (EstNumber)
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

ALTER TABLE    expensesUsed   WITH CHECK ADD  CONSTRAINT  fk_idExpence_EU  FOREIGN KEY( idExpense )
REFERENCES    expenses  ( idExpenses )
GO
ALTER TABLE	  expensesUsed  WITH CHECK ADD  CONSTRAINT fk_idAux_EU FOREIGN KEY(idAux)
REFERENCES task (idAux)
GO
ALTER TABLE    expensesUsed   WITH CHECK ADD  CONSTRAINT  fk_idEmployee_EU  FOREIGN KEY( idEmployee  )
REFERENCES    employees ( idEmployee )
GO

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
--##################  FOREIG KEYS HOURS WORKED #############################################
--##########################################################################################

ALTER TABLE incoming WITH CHECK ADD CONSTRAINT fk_jobNum_inComing FOREIGN KEY (jobNo) 
REFERENCES job (jobNo)
GO

--##########################################################################################
--##################  FOREIG KEYS JOB ######################################################
--##########################################################################################

ALTER TABLE    job   WITH CHECK ADD  CONSTRAINT  fk_idClient_job  FOREIGN KEY( idClient )
REFERENCES    clients  ( idClient )
GO

--##########################################################################################
--##################  FOREIG KEYS LEG ######################################################
--##########################################################################################

ALTER TABLE leg WITH CHECK ADD CONSTRAINT fk_tag_leg
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
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
--##################  FOREIG KEYS PAYRATE #################################################
--##########################################################################################

ALTER TABLE payRate WITH CHECK ADD CONSTRAINT fk_idEmployee_payRate 
FOREIGN KEY(idEmployee) REFERENCES employees (idEmployee)
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
--##################  FOREIG KEYS SCFINFO ##################################################
--##########################################################################################

ALTER TABLE scfInfo WITH CHECK ADD CONSTRAINT fk_tag_scfInfo
FOREIGN KEY (tag) REFERENCES scaffoldTraking(tag)
GO

--##########################################################################################
--##################  FOREIG KEYS SCFESTIMATION ############################################
--##########################################################################################

ALTER TABLE [dbo].[scfEstimation]  WITH CHECK ADD  CONSTRAINT [fk_ccnum_scfEstimation] FOREIGN KEY([ccnum])
REFERENCES [dbo].[scfEstProyect] ([ccnum])
GO

ALTER TABLE [dbo].[scfEstimation]  WITH CHECK ADD  CONSTRAINT [fk_idAux_scfEstimation] FOREIGN KEY([idAux])
REFERENCES [dbo].[task] ([idAux])
GO

ALTER TABLE [dbo].[scfEstimation]  WITH CHECK ADD  CONSTRAINT [fk_idEstCost_scfEstimation] FOREIGN KEY([idEstCost])
REFERENCES [dbo].[ScafEstCost] ([idEstCost])
GO

ALTER TABLE [dbo].[scfEstimation]  WITH CHECK ADD  CONSTRAINT [fk_scfTypeId_scfEstimation] FOREIGN KEY([scfTypeId])
REFERENCES [dbo].[scfTypeCost] ([scfTypeId])
GO

--##########################################################################################
--##################  FOREIG KEYS SCAFOLD INFORMATION ######################################
--##########################################################################################

ALTER TABLE scaffoldInformation  WITH CHECK ADD  CONSTRAINT fk_tag_SCFInformation
FOREIGN KEY(tag) REFERENCES scaffoldTraking (tag)
GO

ALTER TABLE scaffoldInformation  WITH CHECK ADD  CONSTRAINT fk_idModification_SCFInformation
FOREIGN KEY(idModAux) REFERENCES modification (idModAux)
GO

ALTER TABLE scaffoldInformation  WITH CHECK ADD  CONSTRAINT fk_type_SCFInformation
FOREIGN KEY(type) REFERENCES rental (type)
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
--##################  FOREIG KEYS TAXESPT ##################################################
--##########################################################################################

ALTER TABLE taxesPT WITH CHECK ADD CONSTRAINT fk_idAux_TaxesPT
FOREIGN KEY (idAux) REFERENCES task(idAux)
GO

--##########################################################################################
--##################  FOREIG KEYS TAXESST ##################################################
--##########################################################################################

ALTER TABLE taxesST WITH CHECK ADD CONSTRAINT fk_idAux_TaxesST
FOREIGN KEY (idAux) REFERENCES task(idAux)
GO

--##########################################################################################
--##################  FOREIG KEYS WORKORDER ################################################
--##########################################################################################

ALTER TABLE    workOrder   WITH CHECK ADD  CONSTRAINT  fk_idPO_workOrder  FOREIGN KEY( idPO , jobNo)
REFERENCES    projectOrder  ( idPO , jobNo)
on update cascade
on delete cascade
GO

--========================================================================================================
--===================  PROCEDIMIENTOS ALMACENDADOS =======================================================
--========================================================================================================
create proc sp_actualizaMaterial
@idMaterial varchar(36),
@nombreN varchar(50),
@numeroN int,
@idVendorN varchar(36),
@statusN char(1),
--datos viejos
@idVendorV varchar(36),
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
				update material set name = @nombreN , estatus = @statusN where idMaterial = @idMaterial 
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
				update detalleMaterial set idVendor = @idVendorN where idMaterial = @idMaterial and idVendor = @idVendorV
				update material set name = @nombreN , estatus = @statusN where idMaterial = @idMaterial 
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
	@img image
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
				insert into clients values (@idClient , @ClientID, @FirstName, @MiddleName, @LastName , @CompanyName, @idContact , @idHomeAdress ,@Status,@img)
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

create proc sp_DeleteModAux
@tag varchar(20),
@modID varchar(36),
@msg varchar(120) 
as
declare @error as int = 0
declare @flag as int
declare @idProduct as int
declare @qty as float
begin 
	if (select COUNT(*) from modification where idModification=@modID and tag = @tag) >0 
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
					select  @qty = quantity ,@idProduct = idProduct from (select top 1  quantity,idProduct from productModification where tag = '9999' and idModAux = @modID) as t1
					set	@msg = CONCAT('Error trying to delete Product Modification Record from Modification: ', @modID,', with the idProduct: ',CONVERT(varchar(12), @idProduct))
					select quantity from product where idProduct = @idProduct
					update product set quantity = quantity + @qty where idProduct = @idProduct
					select quantity from productTotalScaffold where idProduct = @idProduct and tag = @tag
					update productTotalScaffold set quantity = quantity + IIF(@qty>0,@qty*-1,@qty*-1) where idProduct = @idProduct and tag = @tag
					delete from productModification where idProduct = @idProduct and tag = @tag and idModAux = @modID
					delete from productTotalScaffold where quantity = 0 and tag = @tag
					select @flag = COUNT(*) from productModification where tag = @tag and idModAux = @modID
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
			print @msg
		end
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
				insert into material values (@idMaterial,@numero,@nombre,@status)
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
	@img image
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
				update  clients set firstName= @FirstName,middleName= @MiddleName,lastName= @LastName ,companyName=@CompanyName,estatus = @Status, photo = @img  where idClient = @idCL
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
CREATE proc [dbo].[Client_Billings_Re_Cap_By_Project]
@startdate as date, 
@finaldate as date,
@clientnum as int
as 
begin
if @startDate is not null and @FinalDate is not null and @clientnum is not null
	begin
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
	else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end
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
else
begin 
set @startdate = GETDATE()
set @finaldate = GETDATE()
set @clientnum = (select top 1 numberClient from clients)
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
	else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end
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
CREATE proc [dbo].[sp_Active_Employee_Average]
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
--################## SP REPORT ###################################################
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
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament, ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '1' and (endDate between @startdate and @finaldate) and cl.numberClient = @clientnum
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
		CONCAT(cl.lastName,' ',cl.firstName,' ',cl.middleName) as 'Client Name', 
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
		group by po.jobNo, wo.idWO, tk.task,CONCAT(cl.lastName,' ',cl.firstName,' ',cl.middleName), ex.expenseCode,
		CONCAT(em.lastName,',',em.firstName,' ',em.middleName),em.numberEmploye,em.typeEmployee
end
else 
begin
	select CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, GETDATE())) ,GETDATE())) as 'Weekending',
		po.jobNo as 'Job Num',
		CONCAT(wo.idWO,' ', tk.task) as 'Project Name',
		ex.expenseCode as 'Project Description' ,
		CONCAT(cl.lastName,' ',cl.firstName,' ',cl.middleName) as 'Client Name', 
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
		group by po.jobNo, wo.idWO, tk.task,CONCAT(cl.lastName,' ',cl.firstName,' ',cl.middleName), ex.expenseCode,
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
--################## SP REPORT SCAFFOLD ESTIMATE ###################################################
--##############################################################################################
CREATE proc [dbo].[sp_scfEstimation]
@EstNumber as varchar(30)
as 
begin
  if @Estnumber <> '%'
  begin
    select scfe.EstNumber, scfe.unit , scfe.location , scfe.width ,scfe.length ,scfe.heigth,scfe.descks,scfe.daysActive,emt.DA,
		scfe.M3 , scfe.M2, typ.SCTP , (select hFactor from scfFactor where heigth = scfe.heigth+scfe.groundHeigth) as 'Factor' , typ.BDRATE , emt.PMANHRS,
		emt.BPRICE,emt.DECKBP,emt.DPRICE,emt.DECKDP,
		emt.EDM3C,emt.EDM2C,emt.EDM3C,emt.EDM2C,
		emt.M3LBP,emt.M3LDP,emt.M2LBP,emt.M2LDP,
		emt.M3MBP,emt.M3MDP,emt.M2MBP,emt.M2MDP,
		emt.M3EBP,emt.M3EDP,emt.M2EBP,emt.M2EDP
		from scfEstimation as scfe 
		inner join EstMeters as emt on scfe.EstNumber = emt.EstNumber
		inner join scfTypeCost as typ on typ.scfTypeId = scfe.scfTypeId 
		inner join ScafEstCost as cost on cost.idEstCost = scfe.idEstCost
		where scfe.EstNumber like @EstNumber
end
else 
begin
    select scfe.EstNumber, scfe.unit , scfe.location , scfe.width ,scfe.length ,scfe.heigth,scfe.descks,scfe.daysActive,emt.DA,
		scfe.M3 , scfe.M2, typ.SCTP , (select hFactor from scfFactor where heigth = scfe.heigth+scfe.groundHeigth) as 'Factor' , typ.BDRATE , emt.PMANHRS,
		emt.BPRICE,emt.DECKBP,emt.DPRICE,emt.DECKDP,
		emt.EDM3C,emt.EDM2C,emt.EDM3C,emt.EDM2C,
		emt.M3LBP,emt.M3LDP,emt.M2LBP,emt.M2LDP,
		emt.M3MBP,emt.M3MDP,emt.M2MBP,emt.M2MDP,
		emt.M3EBP,emt.M3EDP,emt.M2EBP,emt.M2EDP
		from scfEstimation as scfe 
		inner join EstMeters as emt on scfe.EstNumber = emt.EstNumber
		inner join scfTypeCost as typ on typ.scfTypeId = scfe.scfTypeId 
		inner join ScafEstCost as cost on cost.idEstCost = scfe.idEstCost
		where scfe.EstNumber like '%'
  end
end
go
----use master
----drop database VRT_TRAKING

--==============================================================================================================================
--===== ESTE CODIGO ES PARA AGREGAR EL CAMPO DE PERDIEM EN LA VENTA DE EMPLOYEES ===============================================
--==============================================================================================================================

---- PARA DESCOMENTAR USAR LAS TECLAS (CTRL+K)(CTRL+U) Y PARA COMENTAR (CTRL+K)(CTRL+C)

--alter table employees 
--add perdiem bit
--go

--update employees set perdiem = 0 
--go

--ALTER proc [dbo].[sp_insert_Employee]
--	--general
--	@numberEmploye int, 
--	@firstName varchar(30),
--	@lastName varchar(25),
--	@middleName varchar(25),
--	@socialNumber varchar(14),
--	@SAPNumber int,
--	@photo image,
--	@estatus char(1),
--	--contact
--	@phoneNumber1 varchar(13),
--	@phoneNumber2 varchar(13),
--	@email varchar(50),
--	--address
--	@avenue varchar(80),
--	@number int,
--	@city varchar(20), 
--	@providence varchar(20),
--	@postalCode int,
--	--pay
--	@payRate1 float,
--	@payRate2 float, 
--	@payRate3 float,
--	--type 
--	@type varchar(20),
--	--perdiem
--	@perdiem bit
--as 
--declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
--declare @idEmployee varchar(36) 
--declare @idContact varchar(36)
--declare @idHomeAdress varchar(36)
--declare @idPayRate varchar(36)
--begin
--	begin tran --inicio tran
--		begin try --inicio try
--			--if @phoneNumber1 <> '' or @email<> '' begin -- si existe un telefono o un correo entra 
--				set @idContact = NEWID() 
--				insert into contact values(@idContact,@phoneNumber1,@phoneNumber2,@email)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end  -- si existe un error en al insertar solo vamos a solveproblem y nos evitamos lo demas
--			--end
--			--if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
--				set @idHomeAdress = NEWID()
--				insert into HomeAddress values (@idHomeAdress , @avenue , @number , @city , @providence , @postalCode)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				
--			--end
--			--if @firstName <> '' or @numberEmploye > 0 begin	
--				set @idEmployee = NEWID()
--				insert into employees values (@idEmployee , @numberEmploye , @firstName , @lastName , @middleName, @socialNumber , @SAPNumber, @photo , @idHomeAdress , @idContact ,@estatus,@type,@perdiem)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--			--if @payRate1 <> '' begin
--				set @idPayRate = NEWID()
--				insert into payRate values (@idPayRate,@payRate1,@payRate2 ,@payRate3,@idEmployee,GETDATE())
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--		end try	
--		begin catch
--			goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
--		end catch
--	commit tran 
--	solveproblem:
--	if @error <> 0
--	begin 
--		rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
--	end
--end
--go

--ALTER proc [dbo].[sp_update_Employee]
--	@idEmployee varchar(36),
--	@idAddress varchar(36),
--	@idContact varchar(36),
--	--general
--	@numberEmploye int, 
--	@firstName varchar(30),
--	@lastName varchar(25),
--	@middleName varchar(25),
--	@socialNumber varchar(14),
--	@SAPNumber int,
--	@photo image,
--	@estatus char(1),
--	--contact
--	@phoneNumber1 varchar(13),
--	@phoneNumber2 varchar(13),
--	@email varchar(50),
--	--address
--	@avenue varchar(80),
--	@number int,
--	@city varchar(20), 
--	@providence varchar(20),
--	@postalCode int,
--	----pay
--	--@payRate1 float,
--	--@payRate2 float, 
--	--@payRate3 float,
--	--type 
--	@type varchar(20),
--	@perdiem bit,
--	@msg varchar(50) output
--as 
--declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
--begin
--	begin tran --inicio tran
--		begin try --inicio try
--			--if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
--				set @msg = 'Error at moment to save Address data'
--				update HomeAddress set avenue = @avenue ,number =@number ,city =@city ,providence =@providence ,postalcode = @postalCode where idHomeAdress = @idAddress
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				
--				set @msg = 'Error at moment to save Contact data'
--				update contact set phoneNumber1 =@phoneNumber1 , phoneNumber2 =@phoneNumber2 , email = @email where idContact = @idContact
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--			----if @payRate1 <> '' begin
--			--	set @msg = 'Error at moment to save Pay Rate data'
--			--	update payRate set payRate1 = @payRate1,payRate2= @payRate2 , payRate3 = @payRate3 where idPayRate = @idPay and idEmployee = @idEmployee
--			--	if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			----end
--			--if @firstName <> '' or @numberEmploye > 0 begin
--				set @msg = 'Error at moment to save Employee data'	
--				update employees set  numberEmploye = @numberEmploye ,firstName = @firstName , lastName = @lastName ,middleName = @middleName,socialNumber = @socialNumber ,SAPNumber = @SAPNumber,photo = @photo , estatus = @estatus,typeEmployee = @type, perdiem = @perdiem where idEmployee = @idEmployee
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--			set @msg = 'Succesfull'
--		end try	
--		begin catch
--			goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
--		end catch
--	commit tran 
--	solveproblem:
--	if @error <> 0
--	begin 
--		rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
--		return @msg
--	end
--end
--go
