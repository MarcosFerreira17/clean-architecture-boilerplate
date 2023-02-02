ƒ
üc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Host\Configurations\DependencyInjection.cs
	namespace 	
Costumer
 
. 
Host 
. 
Configurations &
;& '
public 
static 
class 
DependencyInjection '
{ 
public 

static 
void 
AddInfrastructure (
(( )
this) -
IServiceCollection. @
servicesA I
,I J
IConfigurationK Y
configurationZ g
)g h
{ 
string 
connectionString 
=  !
configuration" /
./ 0
GetConnectionString0 C
(C D
$strD W
)W X
;X Y
services 
. 
AddDbContext 
< 
CostumerDbContext /
>/ 0
(0 1
options1 8
=>9 ;
options 
. 
UseMySql 
( 
connectionString )
,) *
ServerVersion+ 8
.8 9

AutoDetect9 C
(C D
connectionStringD T
)T U
)U V
)V W
;W X
} 
public 

static 
void 
AddServices "
(" #
this# '
IServiceCollection( :
services; C
)C D
{ 
services 
. 
	AddScoped 
< 
ICostumerRepository .
,. /
CostumerRepository0 B
>B C
(C D
)D E
;E F
services 
. 
	AddScoped 
< 
ICostumerService +
,+ ,
CostumerService- <
>< =
(= >
)> ?
;? @
services 
. 
AddAutoMapper 
( 
	AppDomain (
.( )
CurrentDomain) 6
.6 7
GetAssemblies7 D
(D E
)E F
)F G
;G H
services 
. -
!AddFluentValidationAutoValidation 2
(2 3
)3 4
.4 51
%AddFluentValidationClientsideAdapters5 Z
(Z [
)[ \
;\ ]
} 
public 

static 
void 
ConfigureCors $
($ %
this% )
IServiceCollection* <
services= E
)E F
=>G I
services   
.   
AddCors   
(   
options   
=>   
{!! 
options"" 
."" 
	AddPolicy"" 
("" 
$str"" &
,""& '
builder""( /
=>""0 2
builder## 
.## 
AllowAnyOrigin## 
(## 
)##  
.$$ 	
AllowAnyMethod$$	 
($$ 
)$$ 
.%% 	
AllowAnyHeader%%	 
(%% 
)%% 
)%% 
;%% 
}&& 
)&& 
;&& 
}'' Æ
¶c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Host\Configurations\ElasticSearchConfiguration.cs
	namespace 	
Costumer
 
. 
Host 
. 
Configurations &
;& '
public 
static 
class &
ElasticSearchConfiguration .
{		 
public

 

static

 $
ElasticsearchSinkOptions

 *
ConfigureELS

+ 7
(

7 8
IConfigurationRoot

8 J
configuration

K X
,

X Y
string

Z `
env

a d
)

d e
{ 
return 
new $
ElasticsearchSinkOptions +
(+ ,
new, /
Uri0 3
(3 4
configuration4 A
[A B
$strB X
]X Y
)Y Z
)Z [
{ 	 
AutoRegisterTemplate  
=! "
true# '
,' (
IndexFormat 
= 
$" 
{ 
Assembly %
.% & 
GetExecutingAssembly& :
(: ;
); <
.< =
GetName= D
(D E
)E F
.F G
NameG K
.K L
ToLowerL S
(S T
)T U
}U V
$strV W
{W X
envX [
.[ \
ToLower\ c
(c d
)d e
.e f
Replacef m
(m n
$strn q
,q r
$strs v
)v w
}w x
$strx y
{y z
DateTime	z Ç
.
Ç É
UtcNow
É â
:
â ä
$str
ä ë
}
ë í
"
í ì
} 	
;	 

} 
} ¡'
•c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Host\Configurations\Extensions\HostExtensions.cs
	namespace

 	
Costumer


 
.

 
Host

 
.

 
Configurations

 &
.

& '

Extensions

' 1
;

1 2
public 
static 
class 
HostExtensions "
{ 
public 

static 
IHost 
MigrateDatabase '
<' (
TContext( 0
>0 1
(1 2
this2 6
IHost7 <
host= A
)A B
whereC H
TContextI Q
:R S
CostumerDbContextT e
{ 
using 
( 
var 
scope 
= 
host 
.  
Services  (
.( )
CreateScope) 4
(4 5
)5 6
)6 7
{ 	
var 
services 
= 
scope  
.  !
ServiceProvider! 0
;0 1
var 
logger 
= 
services !
.! "
GetRequiredService" 4
<4 5
ILogger5 <
<< =
TContext= E
>E F
>F G
(G H
)H I
;I J
var 
context 
= 
services "
." #

GetService# -
<- .
TContext. 6
>6 7
(7 8
)8 9
;9 :
try 
{ 
logger 
. 
LogInformation %
(% &
$str& b
,b c
typeofd j
(j k
TContextk s
)s t
.t u
Nameu y
)y z
;z {
var 
retry 
= 
Policy "
." #
Handle# )
<) *
	Exception* 3
>3 4
(4 5
)5 6
. 
WaitAndRetry %
(% &

retryCount &
:& '
$num( )
,) *!
sleepDurationProvider 1
:1 2
retryAttempt3 ?
=>@ B
TimeSpanC K
.K L
FromSecondsL W
(W X
MathX \
.\ ]
Pow] `
(` a
$numa b
,b c
retryAttemptd p
)p q
)q r
,r s
onRetry #
:# $
(% &
	exception& /
,/ 0

retryCount1 ;
,; <
context= D
)D E
=>F H
loggerI O
.O P
LogErrorP X
(X Y
$"Y [
$str[ a
{a b

retryCountb l
}l m
$strm q
{q r
contextr y
.y z
	PolicyKey	z É
}
É Ñ
$str
Ñ à
{
à â
context
â ê
.
ê ë
OperationKey
ë ù
}
ù û
$str
û ®
{
® ©
	exception
© ≤
}
≤ ≥
$str
≥ ¥
"
¥ µ
)
µ ∂
)
∂ ∑
;
∑ ∏
retry   
.   
Execute   
(   
(   
)    
=>  ! #
InvokeSeeder  $ 0
(  0 1
context  1 8
)  8 9
)  9 :
;  : ;
logger"" 
."" 
LogInformation"" %
(""% &
$str""& a
,""a b
typeof""c i
(""i j
TContext""j r
)""r s
.""s t
Name""t x
)""x y
;""y z
}## 
catch$$ 
($$ 
	Exception$$ 
ex$$ 
)$$  
{%% 
logger&& 
.&& 
LogError&& 
(&&  
ex&&  "
,&&" #
$str&&$ t
,&&t u
typeof&&v |
(&&| }
TContext	&&} Ö
)
&&Ö Ü
.
&&Ü á
Name
&&á ã
)
&&ã å
;
&&å ç
throw'' 
new'' 
GenericException'' *
(''* +
ex''+ -
.''- .
Message''. 5
+''6 7
$str	''8 à
,
''à â
typeof
''ä ê
(
''ê ë
TContext
''ë ô
)
''ô ö
.
''ö õ
Name
''õ ü
)
''ü †
;
''† °
}(( 
})) 	
return** 
host** 
;** 
}++ 
private,, 
static,, 
void,, 
InvokeSeeder,, $
<,,$ %
TContext,,% -
>,,- .
(,,. /
TContext,,/ 7
context,,8 ?
),,? @
where-- 
TContext-- 
:-- 
CostumerDbContext-- *
=>--+ -
context--. 5
.--5 6
Database--6 >
.--> ?
Migrate--? F
(--F G
)--G H
;--H I
}.. √
†c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Host\Configurations\SerilogConfiguration.cs
	namespace 	
Costumer
 
. 
Host 
. 
Configurations &
;& '
public 
static 
class  
SerilogConfiguration (
{		 
public

 

static

 
void

 
AddSerilogApi

 $
(

$ %
)

% &
{ 
var 
env 
= 
Environment 
. "
GetEnvironmentVariable 4
(4 5
$str5 M
)M N
;N O
var 
configuration 
= 
new  
ConfigurationBuilder  4
(4 5
)5 6
. 
AddJsonFile 
( 
$str /
,/ 0
optional1 9
:9 :
false; @
,@ A
reloadOnChangeB P
:P Q
trueR V
)V W
. 
AddJsonFile 
( 
$str ;
,; <
optional= E
:E F
falseG L
,L M
reloadOnChangeN \
:\ ]
true^ b
)b c
. 
Build 
( 
) 
; 
Log 
. 
Logger 
= 
new 
LoggerConfiguration ,
(, -
)- .
. 
Enrich 
. 
FromLogContext "
(" #
)# $
. 
Enrich 
.  
WithExceptionDetails (
(( )
)) *
. 
WriteTo 
. 
Debug 
( 
) 
. 
WriteTo 
. 
Console 
( 
) 
. 
WriteTo 
. 
Elasticsearch "
(" #&
ElasticSearchConfiguration# =
.= >
ConfigureELS> J
(J K
configurationK X
,X Y
envZ ]
)] ^
)^ _
. 
CreateLogger 
( 
) 
; 
} 
} Ï
†c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Host\Configurations\SwaggerConfiguration.cs
	namespace 	
Costumer
 
. 
Host 
. 
Configurations &
;& '
public 
static 
class  
SwaggerConfiguration (
{ 
public		 

static		 
void		 #
AddSwaggerConfiguration		 .
(		. /
this		/ 3
IServiceCollection		4 F
services		G O
)		O P
{

 
services 
. 
AddSwaggerGen 
( 
c  
=>! #
{ 	
c 
. 

SwaggerDoc 
( 
$str 
, 
new "
OpenApiInfo# .
(. /
)/ 0
{ 
Title 
= 
$str &
,& '
Description 
= 
$str 6
,6 7
Contact 
= 
new 
OpenApiContact ,
(, -
)- .
{/ 0
Name1 5
=6 7
$str8 ?
,? @
EmailA F
=G H
$strI P
}Q R
,R S
} 
) 
; 
c 
. !
AddSecurityDefinition #
(# $
$str$ ,
,, -
new. 1!
OpenApiSecurityScheme2 G
{ 
Description 
= 
$str A
,A B
Name 
= 
$str &
,& '
Scheme 
= 
$str !
,! "
BearerFormat 
= 
$str $
,$ %
In 
= 
ParameterLocation &
.& '
Header' -
,- .
Type 
= 
SecuritySchemeType )
.) *
ApiKey* 0
} 
) 
; 
c 
. "
AddSecurityRequirement $
($ %
new% (&
OpenApiSecurityRequirement) C
{   
{!! 
new"" !
OpenApiSecurityScheme"" 1
{## 
	Reference$$ %
=$$& '
new$$( +
OpenApiReference$$, <
{%% 
Type&&  $
=&&% &
ReferenceType&&' 4
.&&4 5
SecurityScheme&&5 C
,&&C D
Id''  "
=''# $
$str''% -
}(( 
})) 
,)) 
new** 
string** "
[**" #
]**# $
{**% &
}**& '
}++ 
},, 
),, 
;,, 
}-- 	
)--	 

;--
 
}.. 
public00 

static00 
void00 #
UseSwaggerConfiguration00 .
(00. /
this00/ 3
IApplicationBuilder004 G
app00H K
)00K L
{11 
app22 
.22 

UseSwagger22 
(22 
)22 
;22 
app33 
.33 
UseSwaggerUI33 
(33 
)33 
;33 
}44 
}55 ∏B
õc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Host\Controllers\CostumerController.cs
	namespace 	
Costumer
 
. 
Host 
. 
Controllers #
;# $
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class 
CostumerController 
:  !
ControllerBase" 0
{ 
	protected 
readonly 
ICostumerService '
_service( 0
;0 1
public 

CostumerController 
( 
ICostumerService .
service/ 6
)6 7
{ 
_service 
= 
service 
; 
} 
[ 
HttpGet 
] 
[ 
Produces 
( 
$str  
)  !
]! "
[  
ProducesResponseType 
( 
typeof  
(  !
	PagedList! *
<* +
	PersonDto+ 4
>4 5
)5 6
,6 7
(8 9
int9 <
)< =
HttpStatusCode= K
.K L
OKL N
)N O
]O P
[  
ProducesResponseType 
( 
StatusCodes %
.% &
Status404NotFound& 7
,7 8
Type9 =
=> ?
typeof@ F
(F G
stringG M
)M N
)N O
]O P
public 

async 
Task 
< 
IActionResult #
># $
GetAll% +
(+ ,
[, -
	FromQuery- 6
]6 7
CostumerParameters8 J
costumerParametersK ]
)] ^
{ 
var 
entitiesFromDb 
= 
await "
_service# +
.+ ,
PagedGetAll, 7
(7 8
costumerParameters8 J
)J K
;K L
Response 
. 
Headers 
. 
Add 
( 
$str +
,+ ,
JsonConvert   
.   
SerializeObject   '
(  ' (
entitiesFromDb  ( 6
.  6 7
MetaData  7 ?
)  ? @
)  @ A
;  A B
return"" 
Ok"" 
("" 
entitiesFromDb""  
)""  !
;""! "
}## 
[%% 
HttpGet%% 
(%% 
$str%% 
)%% 
]%% 
[&& 
Produces&& 
(&& 
$str&&  
)&&  !
]&&! "
[''  
ProducesResponseType'' 
('' 
StatusCodes'' %
.''% &
Status200OK''& 1
,''1 2
Type''3 7
=''8 9
typeof'': @
(''@ A
string''A G
)''G H
)''H I
]''I J
[((  
ProducesResponseType(( 
((( 
StatusCodes(( %
.((% &
Status404NotFound((& 7
,((7 8
Type((9 =
=((> ?
typeof((@ F
(((F G
string((G M
)((M N
)((N O
]((O P
public)) 

async)) 
Task)) 
<)) 
IActionResult)) #
>))# $
GetById))% ,
()), -
long))- 1
id))2 4
)))4 5
{** 
var++ 
entityFromDb++ 
=++ 
await++  
_service++! )
.++) *
GetById++* 1
(++1 2
id++2 4
)++4 5
;++5 6
return,, 
Ok,, 
(,, 
entityFromDb,, 
),, 
;,,  
}-- 
[// 
HttpPost// 
]// 
[00 
Produces00 
(00 
$str00  
)00  !
]00! "
[11  
ProducesResponseType11 
(11 
(11 
int11 
)11 
HttpStatusCode11 -
.11- .
OK11. 0
)110 1
]111 2
[22  
ProducesResponseType22 
(22 
StatusCodes22 %
.22% &
Status400BadRequest22& 9
,229 :
Type22; ?
=22@ A
typeof22B H
(22H I
string22I O
)22O P
)22P Q
]22Q R
[33  
ProducesResponseType33 
(33 
StatusCodes33 %
.33% &
Status404NotFound33& 7
,337 8
Type339 =
=33> ?
typeof33@ F
(33F G
string33G M
)33M N
)33N O
]33O P
public44 

async44 
Task44 
<44 
IActionResult44 #
>44# $
Create44% +
(44+ ,
[44, -
FromBody44- 5
]445 6
	PersonDto447 @
addDto44A G
)44G H
{55 
if66 

(66 
!66 

ModelState66 
.66 
IsValid66 
)66  
return77 

BadRequest77 
(77 

ModelState77 (
)77( )
;77) *
await88 
_service88 
.88 
Create88 
(88 
addDto88 $
)88$ %
;88% &
return99 
Ok99 
(99 
)99 
;99 
}:: 
[<< 
HttpPut<< 
(<< 
$str<< 
)<< 
]<< 
[== 
Produces== 
(== 
$str==  
)==  !
]==! "
[>>  
ProducesResponseType>> 
(>> 
StatusCodes>> %
.>>% &
Status204NoContent>>& 8
)>>8 9
]>>9 :
[??  
ProducesResponseType?? 
(?? 
StatusCodes?? %
.??% &
Status400BadRequest??& 9
,??9 :
Type??; ?
=??@ A
typeof??B H
(??H I
string??I O
)??O P
)??P Q
]??Q R
[@@  
ProducesResponseType@@ 
(@@ 
StatusCodes@@ %
.@@% &
Status404NotFound@@& 7
,@@7 8
Type@@9 =
=@@> ?
typeof@@@ F
(@@F G
string@@G M
)@@M N
)@@N O
]@@O P
publicAA 

asyncAA 
TaskAA 
<AA 
IActionResultAA #
>AA# $
UpdateAsyncAA% 0
(AA0 1
longAA1 5
idAA6 8
,AA8 9
[AA: ;
FromBodyAA; C
]AAC D
	PersonDtoAAE N
	updateDtoAAO X
)AAX Y
{BB 
ifCC 

(CC 
!CC 

ModelStateCC 
.CC 
IsValidCC 
)CC  
returnDD 

BadRequestDD 
(DD 

ModelStateDD (
)DD( )
;DD) *
awaitEE 
_serviceEE 
.EE 
UpdateEE 
(EE 
idEE  
,EE  !
	updateDtoEE" +
)EE+ ,
;EE, -
returnFF 
OkFF 
(FF 
)FF 
;FF 
}GG 
[II 

HttpDeleteII 
(II 
$strII 
)II 
]II 
[JJ 
ProducesJJ 
(JJ 
$strJJ  
)JJ  !
]JJ! "
[KK  
ProducesResponseTypeKK 
(KK 
StatusCodesKK %
.KK% &
Status204NoContentKK& 8
)KK8 9
]KK9 :
[LL  
ProducesResponseTypeLL 
(LL 
StatusCodesLL %
.LL% &
Status404NotFoundLL& 7
,LL7 8
TypeLL9 =
=LL> ?
typeofLL@ F
(LLF G
stringLLG M
)LLM N
)LLN O
]LLO P
publicMM 

asyncMM 
TaskMM 
<MM 
IActionResultMM #
>MM# $
RemoveAsyncMM% 0
(MM0 1
longMM1 5
idMM6 8
)MM8 9
{NN 
awaitOO 
_serviceOO 
.OO 
DeleteOO 
(OO 
idOO  
)OO  !
;OO! "
returnPP 
	NoContentPP 
(PP 
)PP 
;PP 
}QQ 
}RR «
üc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Host\Middlewares\ErrorHandlerMiddleware.cs
	namespace 	
Costumer
 
. 
Host 
. 
Middlewares #
;# $
public 
class "
ErrorHandlerMiddleware #
{ 
private 
readonly 
RequestDelegate $
_next% *
;* +
public 
"
ErrorHandlerMiddleware !
(! "
RequestDelegate" 1
next2 6
)6 7
{ 
_next 
= 
next 
; 
} 
public 

async 
Task 
Invoke 
( 
HttpContext (
context) 0
)0 1
{ 
try 
{ 	
await 
_next 
( 
context 
)  
;  !
} 	
catch 
( 
	Exception 
error 
) 
{ 	
var 
response 
= 
context "
." #
Response# +
;+ ,
response 
. 
ContentType  
=! "
$str# 5
;5 6
var 
responseModel 
= 
ErrorResponse  -
<- .
string. 4
>4 5
.5 6
Fail6 :
(: ;
error; @
.@ A
MessageA H
)H I
;I J
response 
. 

StatusCode 
=  !
error" '
switch( .
{   
ValidationException!! #
=>!!$ &
(!!' (
int!!( +
)!!+ ,
HttpStatusCode!!, :
.!!: ;

BadRequest!!; E
,!!E F
NotFoundException"" !
=>""" $
(""% &
int""& )
)"") *
HttpStatusCode""* 8
.""8 9
NotFound""9 A
,""A B$
ForbiddenAccessException## (
=>##) +
(##, -
int##- 0
)##0 1
HttpStatusCode##1 ?
.##? @
	Forbidden##@ I
,##I J
_$$ 
=>$$ 
($$ 
int$$ 
)$$ 
HttpStatusCode$$ (
.$$( )
InternalServerError$$) <
,$$< =
}%% 
;%% 
var&& 
result&& 
=&& 
JsonSerializer&& '
.&&' (
	Serialize&&( 1
(&&1 2
responseModel&&2 ?
)&&? @
;&&@ A
await'' 
response'' 
.'' 

WriteAsync'' %
(''% &
result''& ,
)'', -
;''- .
}(( 	
})) 
}** ˚
Ñc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Host\Program.cs
var

 
builder

 
=

 
WebApplication

 
.

 
CreateBuilder

 *
(

* +
args

+ /
)

/ 0
;

0 1
SerilogConfiguration 
. 
AddSerilogApi "
(" #
)# $
;$ %
builder 
. 
Host 
. 

UseSerilog 
( 
) 
; 
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. 
AddInfrastructure "
(" #
builder# *
.* +
Configuration+ 8
)8 9
;9 :
builder 
. 
Services 
. 
AddServices 
( 
) 
; 
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. #
AddSwaggerConfiguration (
(( )
)) *
;* +
builder 
. 
Services 
. 
ConfigureCors 
( 
)  
;  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. #
UseSwaggerConfiguration 
(  
)  !
;! "
} 
app 
. 
UseHttpsRedirection 
( 
) 
; 
app   
.   
UseCors   
(   
$str   
)   
;   
app"" 
."" 
UseMiddleware"" 
<"" "
ErrorHandlerMiddleware"" (
>""( )
("") *
)""* +
;""+ ,
app$$ 
.$$ 
MigrateDatabase$$ 
<$$ 
CostumerDbContext$$ %
>$$% &
($$& '
)$$' (
;$$( )
app&& 
.&& 
UseAuthentication&& 
(&& 
)&& 
;&& 
app(( 
.(( 
UseAuthorization(( 
((( 
)(( 
;(( 
app** 
.** 
MapControllers** 
(** 
)** 
;** 
app,, 
.,, 
Run,, 
(,, 
),, 	
;,,	 
