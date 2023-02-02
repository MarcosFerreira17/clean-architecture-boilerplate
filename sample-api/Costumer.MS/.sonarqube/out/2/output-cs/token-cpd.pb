≠	
óc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Common\IBaseService.cs
	namespace 	
Costumer
 
. 
Domain 
. 
Common  
;  !
public 
	interface 
IBaseService 
< 
T 
,  
Tid! $
>$ %
{ 
Task 
< 	
IEnumerable	 
< 
T 
> 
> 
GetAll 
(  
)  !
;! "
Task 
< 	
T	 

>
 
GetById 
( 
Tid 
id 
) 
; 
Task 
Create	 
( 
T 
entity 
) 
; 
Task 
Update	 
( 
Tid 
id 
, 
T 
entity  
)  !
;! "
Task		 
Delete			 
(		 
Tid		 
id		 
)		 
;		 
}

 Î
¢c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Exceptions\BadRequestException.cs
	namespace 	
Costumer
 
. 
Application 
. 

Exceptions )
;) *
[ 
Serializable 
] 
public		 
class		 
BadRequestException		  
:		! "
	Exception		# ,
{

 
public 

BadRequestException 
( 
)  
: 	
base
 
( 
) 
{ 
} 
public 

BadRequestException 
( 
string %
message& -
)- .
: 	
base
 
( 
message 
) 
{ 
} 
public 

BadRequestException 
( 
string %
message& -
,- .
	Exception/ 8
innerException9 G
)G H
: 	
base
 
( 
message 
, 
innerException &
)& '
{ 
} 
public 

BadRequestException 
( 
string %
name& *
,* +
object, 2
key3 6
)6 7
: 	
base
 
( 
$" 
{ 
name 
} 
$str 
{ 
key 
}  
$str  E
"E F
)F G
{ 
} 
	protected 
BadRequestException !
(! "
SerializationInfo" 3
info4 8
,8 9
StreamingContext: J
contextK R
)R S
:   	
base  
 
(   
info   
,   
context   
)   
{!! 
}"" 
}## ›
ßc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Exceptions\ForbiddenAccessException.cs
	namespace 	
Costumer
 
. 
Application 
. 

Exceptions )
;) *
[ 
Serializable 
] 
public 
class $
ForbiddenAccessException %
:& '
	Exception( 1
{		 
public

 
$
ForbiddenAccessException

 #
(

# $
)

$ %
:

& '
base

( ,
(

, -
)

- .
{

/ 0
}

1 2
public 
$
ForbiddenAccessException #
(# $
string$ *
message+ 2
)2 3
:4 5
base6 :
(: ;
message; B
)B C
{D E
}F G
public 
$
ForbiddenAccessException #
(# $
string$ *
message+ 2
,2 3
	Exception4 =
innerException> L
)L M
:N O
baseP T
(T U
messageU \
,\ ]
innerException^ l
)l m
{n o
}p q
	protected $
ForbiddenAccessException &
(& '
SerializationInfo' 8
info9 =
,= >
StreamingContext? O
contextP W
)W X
: 
base 

(
 
info 
, 
context 
) 
{ 
} 
} —
üc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Exceptions\GenericException.cs
	namespace 	
Costumer
 
. 
Application 
. 

Exceptions )
;) *
[ 
Serializable 
] 
public

 
class

 
GenericException

 
:

 
	Exception

  )
{ 
public 

GenericException 
( 
) 
: 
base  $
($ %
)% &
{' (
}) *
public 

GenericException 
( 
string "
message# *
)* +
:, -
base. 2
(2 3
message3 :
): ;
{< =
}> ?
public 

GenericException 
( 
string "
message# *
,* +
params, 2
object3 9
[9 :
]: ;
args< @
)@ A
:B C
baseD H
(H I
stringI O
.O P
FormatP V
(V W
CultureInfoW b
.b c
CurrentCulturec q
,q r
messages z
,z {
args	| Ä
)
Ä Å
)
Å Ç
{
É Ñ
}
Ö Ü
public 

GenericException 
( 
string "
message# *
,* +
	Exception, 5
innerException6 D
)D E
:F G
baseH L
(L M
messageM T
,T U
innerExceptionV d
)d e
{f g
}h i
	protected 
GenericException 
( 
SerializationInfo 0
info1 5
,5 6
StreamingContext7 G
contextH O
)O P
: 
base 

(
 
info 
, 
context 
) 
{ 
} 
} ∂
¢c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Exceptions\Model\ErrorResponse.cs
	namespace 	
Costumer
 
. 
Application 
. 

Exceptions )
.) *
Model* /
;/ 0
public 
class 
ErrorResponse 
< 
T 
> 
{ 
public 

string 
Message 
{ 
get 
;  
set! $
;$ %
}& '
public 

static 
ErrorResponse 
<  
T  !
>! "
Fail# '
(' (
string( .
errorMessage/ ;
); <
{ 
return 
new 
ErrorResponse  
<  !
T! "
>" #
{$ %
Message& -
=. /
errorMessage0 <
}= >
;> ?
}		 
}

 Ô
†c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Exceptions\NotFoundException.cs
	namespace 	
Costumer
 
. 
Application 
. 

Exceptions )
;) *
[ 
Serializable 
] 
public		 
class		 
NotFoundException		 
:		  
	Exception		! *
{

 
public 

NotFoundException 
( 
) 
: 	
base
 
( 
) 
{ 
} 
public 

NotFoundException 
( 
string #
message$ +
)+ ,
: 	
base
 
( 
message 
) 
{ 
} 
public 

NotFoundException 
( 
string #
message$ +
,+ ,
	Exception- 6
innerException7 E
)E F
: 	
base
 
( 
message 
, 
innerException &
)& '
{ 
} 
public 

NotFoundException 
( 
string #
name$ (
,( )
object* 0
key1 4
)4 5
: 	
base
 
( 
$" 
$str 
{ 
name 
}  
$str  $
{$ %
key% (
}( )
$str) 9
"9 :
): ;
{ 
} 
	protected 
NotFoundException 
(  
SerializationInfo  1
info2 6
,6 7
StreamingContext8 H
contextI P
)P Q
:   	
base  
 
(   
info   
,   
context   
)   
{!! 
}"" 
}## “
¢c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Exceptions\ValidationException.cs
	namespace 	
Costumer
 
. 
Application 
. 

Exceptions )
;) *
[ 
Serializable 
] 
public

 
class

 
ValidationException

  
:

! "
	Exception

# ,
{ 
public 

ValidationException 
( 
)  
: 	
base
 
( 
$str ?
)? @
{ 
Errors 
= 
new 

Dictionary 
<  
string  &
,& '
string( .
[. /
]/ 0
>0 1
(1 2
)2 3
;3 4
} 
public 

ValidationException 
( 
IEnumerable *
<* +
ValidationFailure+ <
>< =
failures> F
)F G
: 	
this
 
( 
) 
{ 
Errors 
= 
failures 
. 
GroupBy 
( 
e 
=> 
e 
. 
PropertyName (
,( )
e* +
=>, .
e/ 0
.0 1
ErrorMessage1 =
)= >
. 
ToDictionary 
( 
failureGroup &
=>' )
failureGroup* 6
.6 7
Key7 :
,: ;
failureGroup< H
=>I K
failureGroupL X
.X Y
ToArrayY `
(` a
)a b
)b c
;c d
} 
public 

ValidationException 
( 
string %
message& -
)- .
:/ 0
base1 5
(5 6
message6 =
)= >
{? @
}A B
public 

ValidationException 
( 
string %
message& -
,- .
	Exception/ 8
innerException9 G
)G H
:I J
baseK O
(O P
messageP W
,W X
innerExceptionY g
)g h
{i j
}k l
public 

IDictionary 
< 
string 
, 
string %
[% &
]& '
>' (
Errors) /
{0 1
get2 5
;5 6
}7 8
	protected 
ValidationException !
(! "
SerializationInfo" 3
info4 8
,8 9
StreamingContext: J
contextK R
)R S
: 	
base
 
( 
info 
, 
context 
) 
{ 
}  !
} à
üc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Interfaces\ICostumerService.cs
	namespace 	
Costumer
 
. 
Domain 
. 

Interfaces $
;$ %
public 
	interface 
ICostumerService !
:" #
IBaseService$ 0
<0 1
	PersonDto1 :
,: ;
long< @
>@ A
{ 
Task		 
<		 	
	PagedList			 
<		 
	PersonDto		 
>		 
>		 
PagedGetAll		 *
(		* +
CostumerParameters		+ =
CostumerParameters		> P
)		P Q
;		Q R
}

 ¯
¶c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\RequestFeatures\CostumerParameters.cs
	namespace 	
Costumer
 
. 
Application 
. 
RequestFeatures .
;. /
public 
class 
CostumerParameters 
:  !
RequestParameters" 3
{ 
public 

uint 
MinId 
{ 
get 
; 
set  
;  !
}" #
public		 

uint		 
MaxId		 
{		 
get		 
;		 
set		  
;		  !
}		" #
=		$ %
int		& )
.		) *
MaxValue		* 2
;		2 3
public

 

bool

 
ValidIdRange

 
=>

 
MaxId

  %
>

& '
MinId

( -
;

- .
public 

string 

SearchTerm 
{ 
get "
;" #
set$ '
;' (
}) *
} ü

úc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\RequestFeatures\MetaData.cs
	namespace 	
Costumer
 
. 
Application 
. 
RequestFeatures .
;. /
public 
class 
MetaData 
{ 
public 

int 
CurrentPage 
{ 
get  
;  !
set" %
;% &
}' (
public 

int 

TotalPages 
{ 
get 
;  
set! $
;$ %
}& '
public 

int 
PageSize 
{ 
get 
; 
set "
;" #
}$ %
public 

int 

TotalCount 
{ 
get 
;  
set! $
;$ %
}& '
public		 

bool		 
HasPrevious		 
=>		 
CurrentPage		 *
>		+ ,
$num		- .
;		. /
public

 

bool

 
HasNext

 
=>

 
CurrentPage

 &
<

' (

TotalPages

) 3
;

3 4
} ô
ùc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\RequestFeatures\PagedList.cs
	namespace 	
Costumer
 
. 
Application 
. 
RequestFeatures .
;. /
public 
class 
	PagedList 
< 
T 
> 
: 
List  
<  !
T! "
>" #
{ 
public 

MetaData 
MetaData 
{ 
get "
;" #
set$ '
;' (
}) *
public 

	PagedList 
( 
List 
< 
T 
> 
items "
," #
int$ '
count( -
,- .
int/ 2

pageNumber3 =
,= >
int? B
pageSizeC K
)K L
{ 
MetaData		 
=		 
new		 
MetaData		 
{

 	

TotalCount 
= 
count 
, 
PageSize 
= 
pageSize 
,  
CurrentPage 
= 

pageNumber $
,$ %

TotalPages 
= 
( 
int 
) 
Math "
." #
Ceiling# *
(* +
count+ 0
/1 2
(3 4
double4 :
): ;
pageSize; C
)C D
} 	
;	 

AddRange 
( 
items 
) 
; 
} 
public 

static 
	PagedList 
< 
T 
> 
ToPagedList *
(* +
IEnumerable+ 6
<6 7
T7 8
>8 9
source: @
,@ A
intB E

pageNumberF P
,P Q
intR U
pageSize 
) 
{ 
var 
count 
= 
source 
. 
Count  
(  !
)! "
;" #
var 
items 
= 
source 
. 	
Skip	 
( 
( 

pageNumber 
- 
$num 
) 
*  
pageSize! )
)) *
. 	
Take	 
( 
pageSize 
) 
. 
ToList 
( 
)  
;  !
return 
new 
	PagedList 
< 
T 
> 
(  
items  %
,% &
count' ,
,, -

pageNumber. 8
,8 9
pageSize: B
)B C
;C D
} 
} ò

•c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\RequestFeatures\RequestParameters.cs
	namespace 	
Costumer
 
. 
Application 
. 
RequestFeatures .
;. /
public 
abstract 
class 
RequestParameters '
{ 
const 	
int
 
maxPageSize 
= 
$num 
; 
public 

int 

PageNumber 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$num* +
;+ ,
private 
int 
	_pageSize 
= 
$num 
; 
public 

int 
PageSize 
{		 
get

 
{ 	
return 
	_pageSize 
; 
} 	
set 
{ 	
	_pageSize 
= 
( 
value 
>  
maxPageSize! ,
), -
?. /
maxPageSize0 ;
:< =
value> C
;C D
} 	
} 
} ‡E
úc:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Services\CostumerService.cs
	namespace 	
Costumer
 
. 
Domain 
. 
Services "
;" #
public 
class 
CostumerService 
: 
ICostumerService /
{ 
	protected 
readonly 
ICostumerRepository *
_repo+ 0
;0 1
	protected 
readonly 
IMapper 
_mapper &
;& '
	protected 
readonly 
ILogger 
< 
CostumerService .
>. /
_logger0 7
;7 8
public 

CostumerService 
( 
ICostumerRepository .
repo/ 3
,3 4
IMapper5 <
mapper= C
,C D
ILoggerE L
<L M
CostumerServiceM \
>\ ]
logger^ d
)d e
{ 
_repo 
= 
repo 
; 
_mapper 
= 
mapper 
; 
_logger 
= 
logger 
; 
} 
public 

async 
Task 
Create 
( 
	PersonDto &
costumerDto' 2
)2 3
{ 
var 
entityfromdb 
= 
_mapper "
." #
Map# &
<& '
Person' -
>- .
(. /
costumerDto/ :
): ;
;; <
await 
_repo 
. 
Create 
( 
entityfromdb '
)' (
;( )
} 
public   

async   
Task   
Update   
(   
long   !
id  " $
,  $ %
	PersonDto  & /
costumerDto  0 ;
)  ; <
{!! 
await"" 
SearchForExistingId"" !
(""! "
id""" $
)""$ %
;""% &
if## 

(## 
id## 
!=## 
costumerDto## 
.## 
Id##  
)##  !
{$$ 	
_logger%% 
.%% 
LogError%% 
(%% 
$str%% B
)%%B C
;%%C D
throw&& 
new&& 
NotFoundException&& '
(&&' (
$str&&( N
)&&N O
;&&O P
}'' 	
var(( 
updateEntity(( 
=(( 
_mapper(( "
.((" #
Map((# &
<((& '
Person((' -
>((- .
(((. /
costumerDto((/ :
)((: ;
;((; <
await)) 
_repo)) 
.)) 
Update)) 
()) 
updateEntity)) '
)))' (
;))( )
}** 
public,, 

async,, 
Task,, 
Delete,, 
(,, 
long,, !
id,," $
),,$ %
{-- 
var.. 
entity.. 
=.. 
await.. 
SearchForExistingId.. .
(... /
id../ 1
)..1 2
;..2 3
await// 
_repo// 
.// 
Delete// 
(// 
entity// !
)//! "
;//" #
}00 
public22 

async22 
Task22 
<22 
	PagedList22 
<22  
	PersonDto22  )
>22) *
>22* +
PagedGetAll22, 7
(227 8
CostumerParameters228 J
costumerParameters22K ]
)22] ^
{33 
if44 

(44 
!44 
costumerParameters44 
.44  
ValidIdRange44  ,
)44, -
throw44. 3
new444 7
BadRequestException448 K
(44K L
$str44L p
)44p q
;44q r
var66 
entities66 
=66 
await66 
_repo66 "
.66" #
FindByCondition66# 2
(662 3
x663 4
=>665 7
x668 9
.669 :
Id66: <
>=66= ?
$num66@ A
)66A B
.77 
FilterCostumer77 +
(77+ ,
costumerParameters77, >
.77> ?
MinId77? D
,77D E
costumerParameters77F X
.77X Y
MaxId77Y ^
)77^ _
.88 
Search88 #
(88# $
costumerParameters88$ 6
.886 7

SearchTerm887 A
)88A B
.99 
OrderBy99 $
(99$ %
t99% &
=>99' )
t99* +
.99+ ,
Id99, .
)99. /
.:: 
ToListAsync:: (
(::( )
)::) *
;::* +
var<< 
pagedEntities<< 
=<< 
_mapper<< #
.<<# $
Map<<$ '
<<<' (
List<<( ,
<<<, -
	PersonDto<<- 6
><<6 7
><<7 8
(<<8 9
entities<<9 A
)<<A B
;<<B C
return== 
	PagedList== 
<== 
	PersonDto== "
>==" #
.==# $
ToPagedList==$ /
(==/ 0
pagedEntities==0 =
,=== >
costumerParameters==? Q
.==Q R

PageNumber==R \
,==\ ]
costumerParameters==^ p
.==p q
PageSize==q y
)==y z
;==z {
}>> 
public@@ 

async@@ 
Task@@ 
<@@ 
IEnumerable@@ !
<@@! "
	PersonDto@@" +
>@@+ ,
>@@, -
GetAll@@. 4
(@@4 5
)@@5 6
{AA 
varBB 
entitiesBB 
=BB 
awaitBB 
_repoBB "
.BB" #
FindAllBB# *
(BB* +
)BB+ ,
;BB, -
varCC 
mappedEntityCC 
=CC 
_mapperCC "
.CC" #
MapCC# &
<CC& '
IEnumerableCC' 2
<CC2 3
	PersonDtoCC3 <
>CC< =
>CC= >
(CC> ?
entitiesCC? G
)CCG H
;CCH I
ifDD 

(DD 
entitiesDD 
==DD 
nullDD 
)DD 
{EE 	
_loggerFF 
.FF 
LogInformationFF "
(FF" #
$strFF# 3
)FF3 4
;FF4 5
throwGG 
newGG 
NotFoundExceptionGG '
(GG' (
$strGG( 8
)GG8 9
;GG9 :
}HH 	
returnII 
mappedEntityII 
;II 
}JJ 
publicLL 

asyncLL 
TaskLL 
<LL 
	PersonDtoLL 
>LL  
GetByIdLL! (
(LL( )
longLL) -
idLL. 0
)LL0 1
{MM 
varNN 
entityFromDbNN 
=NN 
awaitNN  
SearchForExistingIdNN! 4
(NN4 5
idNN5 7
)NN7 8
;NN8 9
returnPP 
_mapperPP 
.PP 
MapPP 
<PP 
	PersonDtoPP $
>PP$ %
(PP% &
entityFromDbPP& 2
)PP2 3
;PP3 4
}QQ 
	protectedSS 
asyncSS 
TaskSS 
<SS 
PersonSS 
>SS  
SearchForExistingIdSS! 4
(SS4 5
longSS5 9
idSS: <
)SS< =
{TT 
ifUU 

(UU 
idUU 
<UU 
$numUU 
)UU 
{VV 	
_loggerWW 
.WW 
LogErrorWW 
(WW 
$strWW 7
)WW7 8
;WW8 9
throwXX 
newXX 
NotFoundExceptionXX '
(XX' (
$strXX( _
)XX_ `
;XX` a
}YY 	
var[[ 
entityFromDb[[ 
=[[ 
await[[  
_repo[[! &
.[[& '
FindByCondition[[' 6
([[6 7
x[[7 8
=>[[9 ;
x[[< =
.[[= >
Id[[> @
==[[A C
id[[D F
)[[F G
.[[G H
FirstOrDefaultAsync[[H [
([[[ \
)[[\ ]
;[[] ^
if\\ 

(\\ 
entityFromDb\\ 
is\\ 
null\\  
)\\  !
{]] 	
_logger^^ 
.^^ 
LogInformation^^ "
(^^" #
$str^^# 1
)^^1 2
;^^2 3
throw__ 
new__ 
NotFoundException__ '
(__' (
$str__( m
)__m n
;__n o
}`` 	
returnbb 
_mapperbb 
.bb 
Mapbb 
<bb 
Personbb !
>bb! "
(bb" #
entityFromDbbb# /
)bb/ 0
;bb0 1
}cc 
}dd È
°c:\dev\gft_projects\atena_dotnet\dotnet-sample\sample-component-v2\src\Projects\Core\Gft.Sample\Costumer.MS\Costumer.Application\Validations\CostumerValidator.cs
	namespace 	
Costumer
 
. 
Application 
. 
Validations *
;* +
public 
class 
CostumerValidator 
:  
AbstractValidator! 2
<2 3
Person3 9
>9 :
{ 
public 

CostumerValidator 
( 
) 
{		 
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
Id

 
==

 
$num

 
)

 
. 
NotEmpty 
( 
) 
. 
NotNull 
( 
) 
. 
WithMessage 
( 
$str 3
)3 4
;4 5
} 
} 