 
vD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Applications\IServices\IApplicantService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Applications$ 0
.0 1
	IServices1 :
{		 
public

 

	interface

 
IApplicantService

 &
{ 
Task 
< 
Result 
> 
GetListMyApplicants (
(( )
FilterApplicants) 9
filters: A
)A B
;B C
Task 
< 
Result 
> 
GetStateApplicants '
(' (
int( +
IdUser, 2
)2 3
;3 4
Task 
< 
Result 
> 

GetListJob 
(  
int  #
IdUser$ *
)* +
;+ ,
} 
} ⁄ 
tD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Applications\Services\ApplicantService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Applications$ 0
.0 1
Services1 9
{ 
public 

class 
ApplicantService !
:" #
IApplicantService$ 5
{ 
private 
readonly  
IApplicantRepository - 
_applicantRepository. B
;B C
private 
readonly 
IMapper  
mapper! '
;' (
public 
ApplicantService 
(   
IApplicantRepository  4
applicantRepository5 H
,H I
IMapper( /
mapper0 6
)6 7
{ 	
this 
.  
_applicantRepository %
=& '
applicantRepository( ;
;; <
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
>  !

GetListJob" ,
(, -
int- 0
IdUser1 7
)7 8
{ 	
var 
dto 
= 
await  
_applicantRepository 0
.0 1

GetListJob1 ;
(; <
IdUser< B
)B C
;C D
return   
new   
Result   
{!! 
Data"" 
="" 
dto"" 
,"" 
	StateCode## 
=## 
	Constants## %
.##% &
StateCodeResult##& 5
.##5 6
STATE_CODE_OK##6 C
}$$ 
;$$ 
}%% 	
public'' 
async'' 
Task'' 
<'' 
Result''  
>''  !
GetListMyApplicants''" 5
(''5 6
FilterApplicants''6 F
filters''G N
)''N O
{(( 	
var)) 
dto)) 
=)) 
await))  
_applicantRepository)) 0
.))0 1
GetListMyApplicants))1 D
())D E
filters))E L
)))L M
;))M N
int** 
ntotalrecord** 
=** 
dto** "
.**" #
Count**# (
(**( )
)**) *
;*** +
dto++ 
=++ 
dto++ 
.++ 
Skip++ 
(++ 
(++ 
filters++ #
.++# $
CurrentPage++$ /
-++0 1
$num++2 3
)++3 4
*++5 6
$num++7 8
)++8 9
.++9 :
Take++: >
(++> ?
$num++? @
)++@ A
.++A B
ToList++B H
(++H I
)++I J
;++J K
return,, 
new,, 
Result,, 
{-- 
Data.. 
=.. 
new.. 
{.. 
lista// 
=// 
dto// 
,//  
totalrecords00  
=00! "
ntotalrecord00# /
}11 
,11 
	StateCode22 
=22 
	Constants22 %
.22% &
StateCodeResult22& 5
.225 6
STATE_CODE_OK226 C
}33 
;33 
}44 	
public66 
async66 
Task66 
<66 
Result66  
>66  !
GetStateApplicants66" 4
(664 5
int665 8
IdUser669 ?
)66? @
{77 	
var88 
dto88 
=88 
await88  
_applicantRepository88 0
.880 1
GetStateApplicants881 C
(88C D
IdUser88D J
)88J K
;88K L
return:: 
new:: 
Result:: 
{;; 
Data<< 
=<< 
dto<< 
,<< 
	StateCode== 
=== 
	Constants== %
.==% &
StateCodeResult==& 5
.==5 6
STATE_CODE_OK==6 C
}>> 
;>> 
}?? 	
}@@ 
}AA ú
nD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Country\IService\ICountryService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Country$ +
.+ ,
IService, 4
{ 
public		 

	interface		 
ICountryService		 $
{

 
Task 
< 
Result 
> 
GetCountryes !
(! "
)" #
;# $
} 
} Ñ
lD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Country\Service\CountryService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Country$ +
.+ ,
Service, 3
{ 
public 

class 
CountryService 
:  
ICountryService! 0
{ 
private 
readonly 
IBaseRepository (
<( )
CountryModel) 5
>5 6
baseRepository7 E
;E F
public 
CountryService 
( 
IBaseRepository -
<- .
CountryModel. :
>: ;
baseRepository< J
)J K
{ 	
this 
. 
baseRepository 
=  !
baseRepository" 0
;0 1
} 	
public 
async 
Task 
< 
Result  
>  !
GetCountryes" .
(. /
)/ 0
{ 	
var 
entity 
= 
await 
baseRepository -
.- .
GetAll. 4
(4 5
)5 6
;6 7
entity 
= 
entity 
. 
OrderBy #
(# $
x$ %
=>& (
x) *
.* +
Description+ 6
)6 7
.7 8
ToList8 >
(> ?
)? @
;@ A
return 
new 
Result 
{ 
Data 
= 
entity 
, 
	StateCode 
= 
	Constants %
.% &
StateCodeResult& 5
.5 6
STATE_CODE_OK6 C
} 
; 
}   	
}!! 
}"" Ó
tD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Disability\IService\IDisabilityService.cs
	namespace

 	
SitePostulant


 
.

 
Application

 #
.

# $

Disability

$ .
.

. /
IService

/ 7
{ 
public 

	interface 
IDisabilityService '
{ 
Task 
< 
Result 
> 
GetDisability "
(" #
int# &
IdPerson' /
)/ 0
;0 1
Task 
< 
Result 
> 
Add 
( 
DisabilityDto &
dto' *
,* +
	IFormFile, 5
certificado6 A
)A B
;B C
Task 
< 
Result 
> 
Update 
( 
DisabilityDto )
dto* -
)- .
;. /
} 
} @
rD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Disability\Service\DisabilityService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $

Disability$ .
.. /
Service/ 6
{ 
public 

class 
DisabilityService "
:" #
IDisabilityService$ 6
{ 
private 
readonly 
IBaseRepository (
<( )
DisabilityModel) 8
>8 9
baseRepository: H
;H I
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
AppSettings $
_appSettings% 1
;1 2
public 
DisabilityService  
(  !
IBaseRepository! 0
<0 1
DisabilityModel1 @
>@ A
baseRepositoryB P
,P Q
IMapperR Y
mapperZ `
,` a
IOptionsb j
<j k
AppSettingsk v
>v w
appSettings	x É
)
É Ñ
{ 	
this 
. 
baseRepository 
=  !
baseRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
this 
. 
_appSettings 
= 
appSettings  +
.+ ,
Value, 1
;1 2
} 	
public 
async 
Task 
< 
Result  
>  !
Add" %
(% &
DisabilityDto& 3
dto4 7
,7 8
	IFormFile9 B
fileC G
)G H
{ 	
var   
folder   
=   
_appSettings   %
.  % &
PathSaveFile  & 2
;  2 3
var!! 
filenamefolder!! 
=!!  
folder!!! '
+!!( )
$str!!* :
;!!: ;
dto"" 
."" 
CertificateFileName"" #
=""$ %
file""& *
.""* +
FileName""+ 3
;""3 4
dto## 
.## 
CertificateFolder## !
=##" #
filenamefolder##$ 2
;##2 3
if%% 
(%% 
!%% 
	Directory%% 
.%% 
Exists%% !
(%%! "
filenamefolder%%" 0
)%%0 1
)%%1 2
{&& 
	Directory'' 
.'' 
CreateDirectory'' )
('') *
filenamefolder''* 8
)''8 9
;''9 :
}(( 
var** 
entity** 
=** 
mapper** 
.**  
Map**  #
<**# $
DisabilityModel**$ 3
>**3 4
(**4 5
dto**5 8
)**8 9
;**9 :
await++ 
baseRepository++  
.++  !
Add++! $
(++$ %
entity++% +
)+++ ,
;++, -
dto,, 
.,, 
Id,, 
=,, 
entity,, 
.,, 
Id,, 
;,, 
var-- 
newfilename-- 
=-- 
dto-- !
.--! "
Id--" $
+--% &
$str--' *
+--+ ,
file--- 1
.--1 2
FileName--2 :
;--: ;
var.. 
pathDocument.. 
=.. 
filenamefolder.. -
+... /
newfilename..0 ;
;..; <
using// 
(// 
var// 
stream// 
=// 
new//  #

FileStream//$ .
(//. /
pathDocument/// ;
,//; <
FileMode//= E
.//E F
Create//F L
)//L M
)//M N
{00 
file11 
.11 
CopyTo11 
(11 
stream11 "
)11" #
;11# $
}22 
dto44 
.44 
CertificateFileName44 #
=44$ %
newfilename44& 1
;441 2
var66 
	entityupd66 
=66 
mapper66 "
.66" #
Map66# &
<66& '
DisabilityModel66' 6
>666 7
(667 8
dto668 ;
)66; <
;66< =
await77 
baseRepository77  
.77  !
Update77! '
(77' (
	entityupd77( 1
)771 2
;772 3
return99 
new99 
Result99 
{:: 
Data;; 
=;; 
dto;; 
,;; 
	StateCode<< 
=<< 
	Constants<< %
.<<% &
StateCodeResult<<& 5
.<<5 6
STATE_CODE_OK<<6 C
}== 
;== 
}>> 	
public@@ 
async@@ 
Task@@ 
<@@ 
Result@@  
>@@  !
GetDisability@@" /
(@@/ 0
int@@0 3
IdPerson@@4 <
)@@< =
{AA 	
varBB 
entitesBB 
=BB 
awaitBB 
baseRepositoryBB  .
.BB. /
FindPredicateBB/ <
(BB< =
xBB= >
=>BB? A
xBBB C
.BBC D
IdPersonBBD L
==BBM O
IdPersonBBP X
&&BBY [
xBB\ ]
.BB] ^
ActiveBB^ d
==BBe g
trueBBh l
)BBl m
;BBm n
varCC 
dtoCC 
=CC 
newCC 
DisabilityDtoCC '
(CC' (
)CC( )
;CC) *
ifDD 
(DD 
entitesDD 
!=DD 
nullDD 
)DD  
{DD! "
dtoEE 
=EE 
mapperEE 
.EE 
MapEE !
<EE! "
DisabilityDtoEE" /
>EE/ 0
(EE0 1
entitesEE1 8
)EE8 9
;EE9 :
ifFF 
(FF 
dtoFF 
.FF 
CertificateFolderFF )
!=FF* ,
nullFF- 1
)FF1 2
{GG 
varHH 
fileHH 
=HH 
dtoHH "
.HH" #
CertificateFolderHH# 4
+HH5 6
dtoHH7 :
.HH: ;
CertificateFileNameHH; N
;HHN O
ifII 
(II 
FileII 
.II 
ExistsII #
(II# $
fileII$ (
)II( )
)II) *
{JJ 
varKK 
bufferKK "
=KK# $
FileKK% )
.KK) *
ReadAllBytesKK* 6
(KK6 7
fileKK7 ;
)KK; <
;KK< =
dtoLL 
.LL !
CertificateFileBufferLL 1
=LL2 3
bufferLL4 :
;LL: ;
dtoMM 
.MM 
FileTypeMM $
=MM% &
PathMM' +
.MM+ ,
GetExtensionMM, 8
(MM8 9
dtoMM9 <
.MM< =
CertificateFileNameMM= P
)MMP Q
;MMQ R
}NN 
}OO 
}PP 
returnRR 
newRR 
ResultRR 
{SS 
	StateCodeTT 
=TT 
	ConstantsTT %
.TT% &
StateCodeResultTT& 5
.TT5 6
STATE_CODE_OKTT6 C
,TTC D
DataUU 
=UU 
dtoUU 
}VV 
;VV 
}WW 	
publicYY 
asyncYY 
TaskYY 
<YY 
ResultYY  
>YY  !
UpdateYY" (
(YY( )
DisabilityDtoYY) 6
dtoYY7 :
)YY: ;
{ZZ 	
var[[ 
	entityupd[[ 
=[[ 
mapper[[ "
.[[" #
Map[[# &
<[[& '
DisabilityModel[[' 6
>[[6 7
([[7 8
dto[[8 ;
)[[; <
;[[< =
await\\ 
baseRepository\\  
.\\  !
Update\\! '
(\\' (
	entityupd\\( 1
)\\1 2
;\\2 3
return^^ 
new^^ 
Result^^ 
{__ 
Data`` 
=`` 
dto`` 
,`` 
	StateCodeaa 
=aa 
	Constantsaa %
.aa% &
StateCodeResultaa& 5
.aa5 6
STATE_CODE_OKaa6 C
}bb 
;bb 
}cc 	
}dd 
}ee Í
ÖD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\EducationPostulant\IServices\IEducationPostulantService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
EducationPostulant$ 6
.6 7
	IServices7 @
{		 
public

 

	interface

 &
IEducationPostulantService

 /
{ 
Task 
< 
Result 
> !
GetEducationPostulant *
(* +
int+ .
IdPerson/ 7
)7 8
;8 9
Task 
< 
Result 
> 
Add 
( !
EducationPostulantDto .
dto/ 2
)2 3
;3 4
Task 
< 
Result 
> 
Update 
( !
EducationPostulantDto 1
dto2 5
)5 6
;6 7
} 
} ˜%
ÉD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\EducationPostulant\Services\EducationPostulantService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
EducationPostulant$ 6
.6 7
Services7 ?
{ 
public 

class %
EducationPostulantService *
:* +&
IEducationPostulantService, F
{ 
private 
readonly )
IEducationPostulantRepository 6(
educationPostulantRepository7 S
;S T
private 
readonly 
IBaseRepository (
<( )#
EducationPostulantModel) @
>@ A#
educationBaseRepositoryB Y
;Y Z
private 
readonly 
IMapper  
mapper! '
;' (
public %
EducationPostulantService (
(( ))
IEducationPostulantRepository) F(
educationPostulantRepositoryG c
,c d
IBaseRepositorye t
<t u
HumanManagement	u Ñ
.
Ñ Ö
Domain
Ö ã
.
ã å
	Postulant
å ï
.
ï ñ
	Education
ñ ü
.
ü †
Models
† ¶
.
¶ ß 
EducationPostulant
ß π
>
π ∫%
educationBaseRepository
ª “
,
“ ”
IMapper 
mapper 
) 
{ 	
this 
. (
educationPostulantRepository -
=. /(
educationPostulantRepository0 L
;L M
this 
. #
educationBaseRepository (
=) *#
educationBaseRepository+ B
;B C
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
>  !
Add" %
(% &!
EducationPostulantDto& ;
dto< ?
)? @
{ 	
var   
entity   
=   
mapper   
.   
Map   "
<  " ##
EducationPostulantModel  # :
>  : ;
(  ; <
dto  < ?
)  ? @
;  @ A
await!! #
educationBaseRepository!! (
.!!( )
Add!!) ,
(!!, -
entity!!- 3
)!!3 4
;!!4 5
dto"" 
."" 
Id"" 
="" 
entity"" 
."" 
Id""  
;""  !
return$$ 
new$$ 
Result$$ 
{%% 
Data&& 
=&& 
dto&& 
,&& 
	StateCode'' 
='' 
	Constants'' %
.''% &
StateCodeResult''& 5
.''5 6
STATE_CODE_OK''6 C
}(( 
;(( 
})) 	
public++ 
async++ 
Task++ 
<++ 
Result++  
>++  !!
GetEducationPostulant++" 7
(++7 8
int++8 ;
IdPerson++< D
)++D E
{,, 	
var-- 
dto-- 
=-- 
await-- (
educationPostulantRepository-- 8
.--8 9#
GetEducationByPostulant--9 P
(--P Q
IdPerson--Q Y
)--Y Z
;--Z [
return// 
new// 
Result// 
{00 
	StateCode11 
=11 
	Constants11 %
.11% &
StateCodeResult11& 5
.115 6
STATE_CODE_OK116 C
,11C D
Data22 
=22 
dto22 
}33 
;33 
}44 	
public66 
async66 
Task66 
<66 
Result66  
>66  !
Update66" (
(66( )!
EducationPostulantDto66) >
dto66? B
)66B C
{77 	
var88 
entity88 
=88 
mapper88 
.88  
Map88  #
<88# $#
EducationPostulantModel88$ ;
>88; <
(88< =
dto88= @
)88@ A
;88A B
await99 #
educationBaseRepository99 )
.99) *
Update99* 0
(990 1
entity991 7
)997 8
;998 9
dto:: 
.:: 
Id:: 
=:: 
entity:: 
.:: 
Id:: 
;:: 
return<< 
new<< 
Result<< 
{== 
Data>> 
=>> 
dto>> 
,>> 
	StateCode?? 
=?? 
	Constants?? %
.??% &
StateCodeResult??& 5
.??5 6
STATE_CODE_OK??6 C
}@@ 
;@@ 
}AA 	
}BB 
}CC Ô
eD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Exceptions\ApiException.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $

Exceptions$ .
{ 
public 

class 
ApiException 
: 
	Exception  )
{ 
public 
string 
ValidationError %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public		 
ApiException		 
(		 
)		 
:		 
base		  $
(		$ %
)		% &
{

 	
} 	
public 
ApiException 
( 
string "
message# *
)* +
:, -
base. 2
(2 3
message3 :
): ;
{ 	
ValidationError 
= 
message %
;% &
} 	
public 
ApiException 
( 
string "
message# *
,* +
params, 2
object3 9
[9 :
]: ;
args< @
)@ A
: 
base 
( 
String 
. 
Format  
(  !
CultureInfo! ,
., -
CurrentCulture- ;
,; <
message= D
,D E
argsF J
)J K
)K L
{ 	
ValidationError 
= 
message %
;% &
} 	
} 
} ›
nD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Exceptions\UnauthorizedException.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $

Exceptions$ .
{ 
class 	!
UnauthorizedException
 
{ 
}		 
}

 ƒ
lD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Exceptions\ValidationException.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $

Exceptions$ .
{ 
public 

class 
ValidationException $
:% &
	Exception' 0
{		 
public

 
List

 
<

 
string

 
>

 
ValidationError

 +
{

, -
get

. 1
;

1 2
set

3 6
;

6 7
}

8 9
public 
ValidationException "
(" #
)# $
{ 	
} 	
public 
ValidationException "
(" #
string# )
message* 1
)1 2
: 
base 
( 
message 
) 
{ 	
ValidationError 
[ 
$num 
] 
=  
message! (
;( )
} 	
public 
ValidationException "
(" #
string# )
message* 1
,1 2
	Exception3 <
innerException= K
)K L
: 
base 
( 
message 
, 
innerException *
)* +
{ 	
ValidationError 
[ 
$num 
] 
=  
innerException! /
./ 0
InnerException0 >
.> ?
Message? F
;F G
} 	
public 
ValidationException "
(" #
IList# (
<( )
ValidationFailure) :
>: ;
validationError< K
)K L
: 
base 
( 
) 
{ 	
ValidationError 
= 
validationError -
.- .
Select. 4
(4 5
x5 6
=>7 9
x: ;
.; <
ErrorMessage< H
)H I
.I J
ToListJ P
(P Q
)Q R
;R S
}   	
}!! 
}"" Â@
kD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Filters\CustomExceptionFilter.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Filters$ +
{ 
public 

class !
CustomExceptionFilter &
:' (
IExceptionFilter) 9
{ 
private 
readonly 
ILogger  
<  !!
CustomExceptionFilter! 6
>6 7
logger8 >
;> ?
public !
CustomExceptionFilter $
($ %
ILogger% ,
<, -!
CustomExceptionFilter- B
>B C
loggerD J
)J K
{ 	
this 
. 
logger 
= 
logger  
;  !
} 	
public 
void 
OnException 
(  
ExceptionContext  0
context1 8
)8 9
{ 	
var 

stackTrace 
= 
new  

StackTrace! +
(+ ,
context, 3
.3 4
	Exception4 =
)= >
;> ?
var 
frame 
= 

stackTrace "
." #
GetFrame# +
(+ ,
$num, -
)- .
;. /
logger 
. 
LogError 
( 
context #
.# $
	Exception$ -
,- .
GetMethodName )
() *
frame* /
./ 0
	GetMethod0 9
(9 :
): ;
); <
,< =
GetClassName (
(( )
frame) .
.. /
	GetMethod/ 8
(8 9
)9 :
): ;
); <
;< =
Result 
result 
= 
null  
;  !
if 
( 
context 
. 
	Exception !
is" $
ValidationException% 8
)8 9
{ 
result   
=   "
SetValidationException   /
(  / 0
context  0 7
)  7 8
;  8 9
}!! 
else"" 
if"" 
("" 
context"" 
."" 
	Exception"" &
is""' )
ApiException""* 6
)""6 7
{## 
var$$ 
ex$$ 
=$$ 
context$$  
.$$  !
	Exception$$! *
as$$+ -
ApiException$$. :
;$$: ;
result%% 
=%% 
new%% 
Result%% #
{&& 
	StateCode'' 
='' 
	Constants''  )
.'') *
StateCodeResult''* 9
.''9 :
ERROR_EXCEPTION'': I
,''I J
MessageError((  
=((! "
new((# &
List((' +
<((+ ,
string((, 2
>((2 3
(((3 4
)((4 5
{)) 
ex** 
.** 
Message** "
}++ 
},, 
;,, 
}-- 
else.. 
if.. 
(.. 
context.. 
... 
	Exception.. &
is..' )'
UnauthorizedAccessException..* E
)..E F
{// 
var00 
ex00 
=00 
context00  
.00  !
	Exception00! *
as00+ -'
UnauthorizedAccessException00. I
;00I J
result22 
=22 
new22 
Result22 #
{33 
	StateCode44 
=44 
	Constants44  )
.44) *
StateCodeResult44* 9
.449 :
UNAUTHORIZED_ACCESS44: M
,44M N
MessageError55  
=55! "
new55# &
List55' +
<55+ ,
string55, 2
>552 3
(553 4
)554 5
{66 
ex77 
.77 
Message77 "
}88 
}99 
;99 
}:: 
else;; 
{;; 
var<< 
ex<< 
=<< 
context<<  
.<<  !
	Exception<<! *
as<<+ -
	Exception<<. 7
;<<7 8
result== 
=== 
new== 
Result== #
{>> 
	StateCode?? 
=?? 
	Constants??  )
.??) *
StateCodeResult??* 9
.??9 :
ERROR_EXCEPTION??: I
,??I J
MessageError@@  
=@@! "
new@@# &
List@@' +
<@@+ ,
string@@, 2
>@@2 3
(@@3 4
)@@4 5
{AA 
exBB 
.BB 
MessageBB "
}CC 
}DD 
;DD 
}EE 
contextGG 
.GG 
ResultGG 
=GG 
newGG  

JsonResultGG! +
(GG+ ,
resultGG, 2
)GG2 3
;GG3 4
}HH 	
privateJJ 
ResultJJ "
SetValidationExceptionJJ -
(JJ- .
ExceptionContextJJ. >
contextJJ? F
)JJF G
{KK 	
varLL 
exLL 
=LL 
contextLL 
.LL 
	ExceptionLL &
asLL' )
ValidationExceptionLL* =
;LL= >
returnMM 
newMM 
ResultMM 
{NN 
	StateCodeOO 
=OO 
	ConstantsOO %
.OO% &
StateCodeResultOO& 5
.OO5 6
BAD_REQUESTOO6 A
,OOA B
MessageErrorPP 
=PP 
exPP !
.PP! "
ValidationErrorPP" 1
}QQ 
;QQ 
}RR 	
privateTT 
stringTT 
GetMethodNameTT $
(TT$ %
SystemTT% +
.TT+ ,

ReflectionTT, 6
.TT6 7

MethodBaseTT7 A
methodTTB H
)TTH I
{UU 	
stringVV 
_methodNameVV 
=VV  
methodVV! '
.VV' (
DeclaringTypeVV( 5
!=VV6 8
nullVV9 =
?VV> ?
methodVV@ F
.VVF G
DeclaringTypeVVG T
.VVT U
FullNameVVU ]
:VV^ _
stringVV` f
.VVf g
EmptyVVg l
;VVl m
ifXX 
(XX 
_methodNameXX 
.XX 
ContainsXX $
(XX$ %
$strXX% (
)XX( )
||XX* ,
_methodNameXX- 8
.XX8 9
ContainsXX9 A
(XXA B
$strXXB E
)XXE F
)XXF G
{YY 
_methodNameZZ 
=ZZ 
_methodNameZZ )
.ZZ) *
SplitZZ* /
(ZZ/ 0
$charZZ0 3
,ZZ3 4
$charZZ5 8
)ZZ8 9
[ZZ9 :
$numZZ: ;
]ZZ; <
;ZZ< =
}[[ 
else\\ 
{]] 
_methodName^^ 
=^^ 
method^^ $
.^^$ %
Name^^% )
;^^) *
}__ 
returnaa 
_methodNameaa 
;aa 
}bb 	
privatedd 
stringdd 
GetClassNamedd #
(dd# $
Systemdd$ *
.dd* +

Reflectiondd+ 5
.dd5 6

MethodBasedd6 @
methodddA G
)ddG H
{ee 	
stringff 
	classNameff 
=ff 
methodff %
.ff% &
DeclaringTypeff& 3
!=ff4 6
nullff7 ;
?ff< =
methodff> D
.ffD E
DeclaringTypeffE R
.ffR S
FullNameffS [
:ff\ ]
stringff^ d
.ffd e
Emptyffe j
;ffj k
ifhh 
(hh 
	classNamehh 
.hh 
Containshh "
(hh" #
$strhh# &
)hh& '
||hh( *
	classNamehh+ 4
.hh4 5
Containshh5 =
(hh= >
$strhh> A
)hhA B
)hhB C
{ii 
	classNamejj 
=jj 
	classNamejj %
.jj% &
Splitjj& +
(jj+ ,
$charjj, /
)jj/ 0
[jj0 1
$numjj1 2
]jj2 3
;jj3 4
}kk 
returnll 
	classNamell 
;ll 
}mm 	
}nn 
}oo «
kD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Filters\ValidationFilterAsync.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Filters$ +
{ 
public		 

class		 !
ValidationFilterAsync		 &
:		' (
IAsyncActionFilter		) ;
{

 
public 
async 
Task "
OnActionExecutionAsync 0
(0 1"
ActionExecutingContext1 G
contextH O
,O P#
ActionExecutionDelegateQ h
nexti m
)m n
{ 	
if 
( 
! 
context 
. 

ModelState #
.# $
IsValid$ +
)+ ,
{ 
var 
errors 
= 
context $
.$ %

ModelState% /
./ 0
Values0 6
.6 7
Where7 <
(< =
v= >
=>? A
vB C
.C D
ErrorsD J
.J K
CountK P
>Q R
$numS T
)T U
. 

SelectMany 
(  
v  !
=>" $
v% &
.& '
Errors' -
)- .
. 
Select 
( 
v 
=>  
v! "
." #
ErrorMessage# /
)/ 0
. 
ToList 
( 
) 
; 
Result 
result 
= 
new  #
Result$ *
{ 
	StateCode 
= 
$num  #
,# $
MessageError  
=! "
errors# )
,) *
Data 
= 
null 
} 
; 
context 
. 
Result 
=  
new! $

JsonResult% /
(/ 0
result0 6
)6 7
;7 8
return 
; 
}   
await"" 
next"" 
("" 
)"" 
;"" 
}## 	
}$$ 
}%% ”!
aD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Helpers\AutoMapping.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Helpers$ +
{ 
public 

class 
AutoMapping 
: 
Profile &
{ 
public 
AutoMapping 
( 
) 
{ 	
	CreateMap 
< 
UserDto 
, 
UserPostulant ,
>, -
(- .
). /
;/ 0
	CreateMap 
< 
ResetPasswordDto &
,& '
UserPostulant( 5
>5 6
(6 7
)7 8
;8 9
	CreateMap 
< 
UserDto 
,  
ProfileUserPostulant 3
>3 4
(4 5
)5 6
;6 7
	CreateMap 
< 
UserDto 
,  
PersonModelPostulant 3
>3 4
(4 5
)5 6
;6 7
	CreateMap 
< !
EducationPostulantDto +
,+ ,
HumanManagement- <
.< =
Domain= C
.C D
	PostulantD M
.M N
	EducationN W
.W X
ModelsX ^
.^ _
EducationPostulant_ q
>q r
(r s
)s t
;t u
	CreateMap 
<  
LanguagePostulantDto *
,* +
HumanManagement, ;
.; <
Domain< B
.B C
	PostulantC L
.L M
	LanguagesM V
.V W
ModelsW ]
.] ^
LanguagePostulant^ o
>o p
(p q
)q r
;r s
	CreateMap   
<   
SkillsPostulantDto   (
,  ( )
HumanManagement  * 9
.  9 :
Domain  : @
.  @ A
	Postulant  A J
.  J K
Skills  K Q
.  Q R
Models  R X
.  X Y
SkillsPostulant  Y h
>  h i
(  i j
)  j k
;  k l
	CreateMap!! 
<!! 
WorkExperienceDto!! '
,!!' (
WorkExperienceModel!!) <
>!!< =
(!!= >
)!!> ?
;!!? @
	CreateMap"" 
<"" 
RecruitmentAreaDto"" (
,""( )
HumanManagement""* 9
.""9 :
Domain"": @
.""@ A
RecruitmentArea""A P
.""P Q
Models""Q W
.""W X
RecruitmentArea""X g
>""g h
(""h i
)""i j
;""j k
	CreateMap## 
<## 
HumanManagement## %
.##% &
Domain##& ,
.##, -
RecruitmentArea##- <
.##< =
Models##= C
.##C D
RecruitmentArea##D S
,##S T
RecruitmentAreaDto##U g
>##g h
(##h i
)##i j
;##j k
	CreateMap$$ 
<$$ 
JobObjectiveDto$$ %
,$$% &
JobObjectiveModel$$' 8
>$$8 9
($$9 :
)$$: ;
;$$; <
	CreateMap%% 
<%% 
SalaryPreferenceDto%% )
,%%) *!
SalaryPreferenceModel%%+ @
>%%@ A
(%%A B
)%%B C
;%%C D
	CreateMap&& 
<&& 
DisabilityDto&& #
,&&# $
DisabilityModel&&% 4
>&&4 5
(&&5 6
)&&6 7
;&&7 8
	CreateMap'' 
<'' 
JobObjectiveModel'' '
,''' (
JobObjectiveDto'') 8
>''8 9
(''9 :
)'': ;
;''; <
	CreateMap(( 
<(( !
SalaryPreferenceModel(( +
,((+ ,
SalaryPreferenceDto((- @
>((@ A
(((A B
)((B C
;((C D
	CreateMap)) 
<)) 
DisabilityModel)) %
,))% &
DisabilityDto))' 4
>))4 5
())5 6
)))6 7
;))7 8
	CreateMap** 
<** 
	PersonDto** 
,**   
PersonModelPostulant**! 5
>**5 6
(**6 7
)**7 8
;**8 9
}++ 	
},, 
}-- ¬
dD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Helpers\SessionManager.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Helpers$ +
{ 
public 

class 
SessionManager 
{ 
private		 
readonly		 
ISession		 !
session		" )
;		) *
private

 
const

 
string

 
USER_KEY

 %
=

& '
$str

( .
;

. /
public 
SessionManager 
(  
IHttpContextAccessor 2
httpContextAccessor3 F
)F G
{ 	
session 
= 
httpContextAccessor )
.) *
HttpContext* 5
==6 8
null9 =
?> ?
null@ D
:E F
httpContextAccessorG Z
.Z [
HttpContext[ f
.f g
Sessiong n
;n o
} 	
public 
UserSessionDto 
User "
{ 	
get 
{ 
var 
value 
= 
session #
==$ &
null' +
?, -
null. 2
:3 4
session5 <
.< =
	GetString= F
(F G
USER_KEYG O
)O P
;P Q
if 
( 
value 
!= 
null  
)  !
{ 
return 
JsonConvert &
.& '
DeserializeObject' 8
<8 9
UserSessionDto9 G
>G H
(H I
valueI N
)N O
;O P
} 
else 
{ 
return 
null 
;  
} 
} 
set 
{ 
session   
.   
	SetString   !
(  ! "
USER_KEY  " *
,  * +
JsonConvert  , 7
.  7 8
SerializeObject  8 G
(  G H
value  H M
)  M N
)  N O
;  O P
}!! 
}"" 	
}## 
}$$ ∆
xD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\JobObjective\IService\IJobObjectiveService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
JobObjective$ 0
.0 1
IService1 9
{		 
public

 

	interface

  
IJobObjectiveService

 )
{ 
Task 
< 
Result 
> $
GetObjectivesByPostulant -
(- .
int. 1
IdPerson2 :
): ;
;; <
Task 
< 
Result 
> 
Add 
( 
JobObjectiveDto (
dto) ,
), -
;- .
Task 
< 
Result 
> 
Update 
( 
JobObjectiveDto +
dto, /
)/ 0
;0 1
} 
} Á#
vD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\JobObjective\Service\JobObjectiveService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
JobObjective$ 0
.0 1
Service1 8
{ 
public 

class 
JobObjectiveService $
:$ % 
IJobObjectiveService& :
{ 
private 
readonly 
IBaseRepository (
<( )
JobObjectiveModel) :
>: ;
baseRepository< J
;J K
private 
readonly 
IMapper  
mapper! '
;' (
public 
JobObjectiveService "
(" #
IBaseRepository# 2
<2 3
JobObjectiveModel3 D
>D E
baseRepositoryF T
,T U
IMapperV ]
mapper^ d
)d e
{ 	
this 
. 
baseRepository 
=  !
baseRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
>  !
Add" %
(% &
JobObjectiveDto& 5
dto6 9
)9 :
{ 	
var 
entity 
= 
mapper 
.  
Map  #
<# $
JobObjectiveModel$ 5
>5 6
(6 7
dto7 :
): ;
;; <
await 
baseRepository  
.  !
Add! $
($ %
entity% +
)+ ,
;, -
dto 
. 
Id 
= 
entity 
. 
Id 
; 
return 
new 
Result 
{   
Data!! 
=!! 
dto!! 
,!! 
	StateCode"" 
="" 
	Constants"" %
.""% &
StateCodeResult""& 5
.""5 6
STATE_CODE_OK""6 C
}## 
;## 
}$$ 	
public&& 
async&& 
Task&& 
<&& 
Result&&  
>&&  !$
GetObjectivesByPostulant&&" :
(&&: ;
int&&; >
IdPerson&&? G
)&&G H
{'' 	
var(( 
entites(( 
=(( 
await(( 
baseRepository((  .
.((. /
FindAllPredicate((/ ?
(((? @
x((@ A
=>((B D
x((E F
.((F G
IdPerson((G O
==((P R
IdPerson((S [
&&((\ ^
x((_ `
.((` a
Active((a g
==((h j
true((k o
)((o p
;((p q
var)) 
dto)) 
=)) 
mapper)) 
.)) 
Map))  
<))  !
List))! %
<))% &
JobObjectiveDto))& 5
>))5 6
>))6 7
())7 8
entites))8 ?
)))? @
;))@ A
return** 
new** 
Result** 
{++ 
	StateCode,, 
=,, 
	Constants,, %
.,,% &
StateCodeResult,,& 5
.,,5 6
STATE_CODE_OK,,6 C
,,,C D
Data-- 
=-- 
dto-- 
}.. 
;.. 
}// 	
public11 
async11 
Task11 
<11 
Result11  
>11  !
Update11" (
(11( )
JobObjectiveDto11) 8
dto119 <
)11< =
{22 	
var33 
entity33 
=33 
mapper33 
.33  
Map33  #
<33# $
JobObjectiveModel33$ 5
>335 6
(336 7
dto337 :
)33: ;
;33; <
await44 
baseRepository44  
.44  !
Update44! '
(44' (
entity44( .
)44. /
;44/ 0
dto55 
.55 
Id55 
=55 
entity55 
.55 
Id55 
;55 
return77 
new77 
Result77 
{88 
Data99 
=99 
dto99 
,99 
	StateCode:: 
=:: 
	Constants:: %
.::% &
StateCodeResult::& 5
.::5 6
STATE_CODE_OK::6 C
};; 
;;; 
}<< 	
}== 
}>> ¯
gD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Job\IServices\IJobService.cs
	namespace		 	
SitePostulant		
 
.		 
Application		 #
.		# $
Job		$ '
.		' (
	IServices		( 1
{

 
public 

	interface 
IJobService  
{ 
Task 
< 
Result 
> 
GetById 
( 
int  
Id! #
)# $
;$ %
Task 
< 
Result 
> 
IsJobPostulated $
($ %
int% (
nIdJob) /
,/ 0
int1 4
nIdPostulant5 A
)A B
;B C
Task 
< 
Result 
> 
AddJobPostulant $
($ %
int% (
nIdJob) /
,/ 0
int1 4
nIdPostulant5 A
)A B
;B C
Task 
< 
Result 
> 
GetRelatedJobs #
(# $
int$ '
nIdJob( .
). /
;/ 0
Task 
< 
Result 
> 
GetOtherJobs !
(! "
)" #
;# $
Task 
< 
Result 
> 

GetAllJobs 
(  
JobFilterDto  ,
filter- 3
)3 4
;4 5
} 
} •¬
eD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Job\Services\JobService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Job$ '
.' (
Services( 0
{ 
public 

class 

JobService 
: 
IJobService )
{ 
private 
readonly 
IJobRepository '
_jobRepository( 6
;6 7
private 
readonly #
IJobPostulantRepository 0#
_jobPostulantRepository1 H
;H I
private 
readonly 
IBaseRepository (
<( )
JobPostulant) 5
>5 6'
_baseRepositoryJobPostulant7 R
;R S
private 
readonly %
IWorkExperienceRepository 2%
_workExperienceRepository3 L
;L M
private 
readonly )
IEducationPostulantRepository 6)
_educationPostulantRepository7 T
;T U
private!! 
readonly!! 
IUnitOfWork!! $
_unitOfWork!!% 0
;!!0 1
private"" 
readonly"" 
ILogger""  
<""  !

JobService""! +
>""+ ,
_logger""- 4
;""4 5
private## 
readonly## 
IPersonRepository## *
personRepository##+ ;
;##; <
public%% 

JobService%% 
(%% 
IJobRepository%% (
jobRepository%%) 6
,%%6 7#
IJobPostulantRepository%%8 O"
jobPostulantRepository%%P f
,%%f g
IBaseRepository%%h w
<%%w x
JobPostulant	%%x Ñ
>
%%Ñ Ö(
baseRepositoryJobPostulant
%%Ü †
,
%%† °
IUnitOfWork&& 

unitOfWork&& "
,&&" #%
IWorkExperienceRepository&&$ =$
workExperienceRepository&&> V
,&&V W)
IEducationPostulantRepository&&X u)
educationPostulantRepository	&&v í
,
&&í ì
ILogger'' 
<'' 

JobService'' 
>'' 
logger''  &
,''& '
IPersonRepository''( 9
personRepository'': J
)''J K
{(( 	
this)) 
.)) 
_jobRepository)) 
=))  !
jobRepository))" /
;))/ 0
this** 
.** #
_jobPostulantRepository** (
=**) *"
jobPostulantRepository**+ A
;**A B
this++ 
.++ '
_baseRepositoryJobPostulant++ ,
=++- .&
baseRepositoryJobPostulant++/ I
;++I J
this,, 
.,, 
_unitOfWork,, 
=,, 

unitOfWork,, )
;,,) *%
_workExperienceRepository-- %
=--& '$
workExperienceRepository--( @
;--@ A)
_educationPostulantRepository.. )
=..* +(
educationPostulantRepository.., H
;..H I
this// 
.// 
_logger// 
=// 
logger// !
;//! "
this00 
.00 
personRepository00 !
=00" #
personRepository00$ 4
;004 5
}11 	
public44 
async44 
Task44 
<44 
Result44  
>44  !
GetById44" )
(44) *
int44* -
Id44. 0
)440 1
{55 	
var66 
oJob66 
=66 
await66 
_jobRepository66 +
.66+ ,
GetById66, 3
(663 4
Id664 6
)666 7
;667 8
oJob77 
.77 
srelativetime77 
=77  
RelativeTime77! -
(77- .
oJob77. 2
.772 3
dcreationdate773 @
)77@ A
;77A B
oJob88 
.88 
screationdate88 
=88  
oJob88! %
.88% &
dcreationdate88& 3
.883 4
ToShortDateString884 E
(88E F
)88F G
;88G H
return:: 
new:: 
Result:: 
{;; 
	StateCode<< 
=<< 
	Constants<< %
.<<% &
StateCodeResult<<& 5
.<<5 6
STATE_CODE_OK<<6 C
,<<C D
Data== 
=== 
oJob== 
}>> 
;>> 
}?? 	
public@@ 
async@@ 
Task@@ 
<@@ 
Result@@  
>@@  !
IsJobPostulated@@" 1
(@@1 2
int@@2 5
nIdJob@@6 <
,@@< =
int@@> A
nIdPostulant@@B N
)@@N O
{AA 	
boolBB 
resultBB 
=BB 
falseBB 
;BB  
varCC 
oJobCC 
=CC 
awaitCC #
_jobPostulantRepositoryCC 4
.CC4 5
GetByIdCC5 <
(CC< =
nIdJobCC= C
,CCC D
nIdPostulantCCD P
)CCP Q
;CCQ R
ifEE 
(EE 
oJobEE 
!=EE 
nullEE 
)EE 
{FF 
resultGG 
=GG 
trueGG 
;GG 
}HH 
returnJJ 
newJJ 
ResultJJ 
{KK 
	StateCodeLL 
=LL 
	ConstantsLL %
.LL% &
StateCodeResultLL& 5
.LL5 6
STATE_CODE_OKLL6 C
,LLC D
DataMM 
=MM 
newMM 
{MM 
IsPostulatedNN  
=NN! "
resultNN# )
,NN) *
DatePostulatedOO "
=OO" #
oJobOO% )
==OO* ,
nullOO- 1
?OO2 3
stringOO4 :
.OO: ;
EmptyOO; @
:OOA B
oJobOOD H
.OOH I
DateRegisterOOI U
}PP 
}QQ 
;QQ 
}RR 	
publicSS 
asyncSS 
TaskSS 
<SS 
ResultSS  
>SS  !
AddJobPostulantSS" 1
(SS1 2
intSS2 5
nIdJobSS6 <
,SS< =
intSS> A
nIdPostulantSSB N
)SSN O
{TT 	
ResultUU 
responseUU 
=UU 
newUU !
ResultUU" (
(UU( )
)UU) *
;UU* +
JobPostulantVV 
newjobPostulantVV (
=VV) *
newVV+ .
JobPostulantVV/ ;
(VV; <
)VV< =
;VV= >
newjobPostulantYY 
.YY 
Id_JobYY "
=YY# $
nIdJobYY% +
;YY+ ,
newjobPostulantZZ 
.ZZ 
Id_PostulantZZ (
=ZZ) *
nIdPostulantZZ+ 7
;ZZ7 8
newjobPostulant[[ 
.[[ 
IdState[[ #
=[[$ %
$num[[& )
;[[) *
newjobPostulant]] 
.]] 
Active]] "
=]]# $
true]]% )
;]]) *
newjobPostulant^^ 
.^^ 
DateRegister^^ (
=^^) *
DateTime^^+ 3
.^^3 4
Now^^4 7
;^^7 8
newjobPostulant__ 
.__ 
IdUserRegister__ *
=__+ ,
nIdPostulant__- 9
;__9 :
newjobPostulant`` 
.`` 

DateUpdate`` &
=``' (
DateTime``) 1
.``1 2
Now``2 5
;``5 6
newjobPostulantaa 
.aa 
IdUserUpdateaa (
=aa) *
nIdPostulantaa+ 7
;aa7 8
newjobPostulantbb 
.bb 
ApplicationSourcebb -
=bb. /
$numbb0 3
;bb3 4
newjobPostulantcc 
.cc 
DateApplicantcc )
=cc* +
DateTimecc, 4
.cc4 5
Nowcc5 8
;cc8 9
varff 
personff 
=ff 
awaitff 
personRepositoryff /
.ff/ 0
	GetPersonff0 9
(ff9 :
nIdPostulantff: F
)ffF G
;ffG H
boolgg 
_validatePersongg  
=gg! "
truegg# '
;gg' (
ifjj 
(jj 
Stringjj 
.jj 
IsNullOrEmptyjj $
(jj$ %
personjj% +
.jj+ ,
	FirstNamejj, 5
)jj5 6
)jj6 7
_validatePersonjj8 G
=jjH I
falsejjJ O
;jjO P
ifkk 
(kk 
Stringkk 
.kk 
IsNullOrEmptykk $
(kk$ %
personkk% +
.kk+ ,
LastNamekk, 4
)kk4 5
)kk5 6
_validatePersonkk7 F
=kkG H
falsekkI N
;kkN O
ifll 
(ll 
Stringll 
.ll 
IsNullOrEmptyll $
(ll$ %
personll% +
.ll+ ,
SecondlastNamell, :
)ll: ;
)ll; <
_validatePersonll= L
=llM N
falsellO T
;llT U
ifmm 
(mm 
personmm 
.mm 
IdNationalitymm $
==mm% '
$nummm( )
)mm) *
_validatePersonmm+ :
=mm; <
falsemm= B
;mmB C
ifnn 
(nn 
personnn 
.nn 
IdCivilStatusnn $
==nn% '
$numnn( )
)nn) *
_validatePersonnn+ :
=nn; <
falsenn= B
;nnB C
ifoo 
(oo 
Stringoo 
.oo 
IsNullOrEmptyoo $
(oo$ %
personoo% +
.oo+ ,
Sexoo, /
)oo/ 0
)oo0 1
_validatePersonoo2 A
=ooB C
falseooD I
;ooI J
ifpp 
(pp 
Stringpp 
.pp 
IsNullOrEmptypp $
(pp$ %
personpp% +
.pp+ ,
	BirthDatepp, 5
)pp5 6
)pp6 7
_validatePersonpp8 G
=ppH I
falseppJ O
;ppO P
ifqq 
(qq 
Stringqq 
.qq 
IsNullOrEmptyqq $
(qq$ %
personqq% +
.qq+ ,
DocumentNumberqq, :
)qq: ;
)qq; <
_validatePersonqq= L
=qqM N
falseqqO T
;qqT U
ifrr 
(rr 
Stringrr 
.rr 
IsNullOrEmptyrr $
(rr$ %
personrr% +
.rr+ ,
DocumentTyperr, 8
)rr8 9
)rr9 :
_validatePersonrr; J
=rrK L
falserrM R
;rrR S
iftt 
(tt 
Stringtt 
.tt 
IsNullOrEmptytt $
(tt$ %
persontt% +
.tt+ ,
	CellPhonett, 5
)tt5 6
)tt6 7
_validatePersontt8 G
=ttH I
falsettJ O
;ttO P
ifuu 
(uu 
personuu 
.uu  
IdDepartmentLocationuu +
==uu, .
$numuu/ 0
)uu0 1
_validatePersonuu2 A
=uuB C
falseuuD I
;uuI J
ifvv 
(vv 
personvv 
.vv 
IdProvinceLocationvv )
==vv* ,
$numvv- .
)vv. /
_validatePersonvv0 ?
=vv@ A
falsevvB G
;vvG H
ifww 
(ww 
personww 
.ww 
IdDistrictLocationww )
==ww* ,
$numww- .
)ww. /
_validatePersonww0 ?
=ww@ A
falsewwB G
;wwG H
ifxx 
(xx 
Stringxx 
.xx 
IsNullOrEmptyxx $
(xx$ %
personxx% +
.xx+ ,
Addressxx, 3
)xx3 4
)xx4 5
_validatePersonxx6 E
=xxF G
falsexxH M
;xxM N
ifyy 
(yy 
Stringyy 
.yy 
IsNullOrEmptyyy $
(yy$ %
personyy% +
.yy+ ,
Emailyy, 1
)yy1 2
)yy2 3
_validatePersonyy4 C
=yyD E
falseyyF K
;yyK L
if{{ 
({{ 
!{{ 
_validatePerson{{  
){{  !
{|| 
response}} 
.}} 
	StateCode}} "
=}}# $
	Constants}}% .
.}}. /
StateCodeResult}}/ >
.}}> ?

VALIDATION}}? I
;}}I J
response~~ 
.~~ 
MessageError~~ %
.~~% &
Add~~& )
(~~) *
$str~~* T
)~~T U
;~~U V
return 
response 
;  
}
ÄÄ 
var
ÇÇ 
experiences
ÇÇ 
=
ÇÇ 
await
ÇÇ #'
_workExperienceRepository
ÇÇ$ =
.
ÇÇ= >
GetWorkExperience
ÇÇ> O
(
ÇÇO P
nIdPostulant
ÇÇP \
)
ÇÇ\ ]
;
ÇÇ] ^
var
ÉÉ 
	education
ÉÉ 
=
ÉÉ 
await
ÉÉ !+
_educationPostulantRepository
ÉÉ" ?
.
ÉÉ? @%
GetEducationByPostulant
ÉÉ@ W
(
ÉÉW X
nIdPostulant
ÉÉX d
)
ÉÉd e
;
ÉÉe f
_logger
ÑÑ 
.
ÑÑ 
LogInformation
ÑÑ "
(
ÑÑ" #
$str
ÑÑ# 8
,
ÑÑ8 9
nIdPostulant
ÑÑ: F
)
ÑÑF G
;
ÑÑG H
_logger
ÖÖ 
.
ÖÖ 
LogInformation
ÖÖ "
(
ÖÖ" #
$str
ÖÖ# 7
,
ÖÖ7 8
experiences
ÖÖ9 D
.
ÖÖD E
Count
ÖÖE J
(
ÖÖJ K
)
ÖÖK L
)
ÖÖL M
;
ÖÖM N
_logger
ÜÜ 
.
ÜÜ 
LogInformation
ÜÜ "
(
ÜÜ" #
$str
ÜÜ# 5
,
ÜÜ5 6
	education
ÜÜ7 @
.
ÜÜ@ A
Count
ÜÜA F
(
ÜÜF G
)
ÜÜG H
)
ÜÜH I
;
ÜÜI J
if
áá 
(
áá 
experiences
áá 
.
áá 
Count
áá !
>
áá" #
$num
áá$ %
&&
áá& (
	education
áá) 2
.
áá2 3
Count
áá3 8
>
áá9 :
$num
áá; <
)
áá< =
{
àà 
await
ââ )
_baseRepositoryJobPostulant
ââ 1
.
ââ1 2
Add
ââ2 5
(
ââ5 6
newjobPostulant
ââ6 E
)
ââE F
;
ââF G
await
ää 
_unitOfWork
ää !
.
ää! "
Commit
ää" (
(
ää( )
)
ää) *
;
ää* +
response
ãã 
.
ãã 
	StateCode
ãã "
=
ãã# $
	Constants
ãã% .
.
ãã. /
StateCodeResult
ãã/ >
.
ãã> ?
STATE_CODE_OK
ãã? L
;
ããL M
response
åå 
.
åå 
MessageError
åå %
=
åå& '
new
åå( +
List
åå, 0
<
åå0 1
string
åå1 7
>
åå7 8
(
åå8 9
)
åå9 :
{
åå; <
$str
åå= j
}
ååk l
;
åål m
}
çç 
else
éé 
{
èè 
response
êê 
.
êê 
	StateCode
êê "
=
êê# $
	Constants
êê% .
.
êê. /
StateCodeResult
êê/ >
.
êê> ?

VALIDATION
êê? I
;
êêI J
if
ëë 
(
ëë 
experiences
ëë 
.
ëë 
Count
ëë $
==
ëë% '
$num
ëë( )
&&
ëë* ,
	education
ëë- 6
.
ëë6 7
Count
ëë7 <
==
ëë= ?
$num
ëë@ A
)
ëëA B
{
íí 
response
ìì 
.
ìì 
MessageError
ìì )
.
ìì) *
Add
ìì* -
(
ìì- .
$str
ìì. n
)
ììn o
;
ììo p
}
îî 
else
ïï 
{
ññ 
if
óó 
(
óó 
	education
óó !
.
óó! "
Count
óó" '
==
óó( *
$num
óó+ ,
)
óó, -
{
òò 
response
ôô  
.
ôô  !
MessageError
ôô! -
.
ôô- .
Add
ôô. 1
(
ôô1 2
$str
ôô2 R
)
ôôR S
;
ôôS T
}
öö 
else
õõ 
if
õõ 
(
õõ 
experiences
õõ (
.
õõ( )
Count
õõ) .
==
õõ/ 1
$num
õõ2 3
)
õõ3 4
{
úú 
response
ùù  
.
ùù  !
MessageError
ùù! -
.
ùù- .
Add
ùù. 1
(
ùù1 2
$str
ùù2 R
)
ùùR S
;
ùùS T
}
ûû 
}
üü 
}
†† 
return
°° 
response
°° 
;
°° 
}
§§ 	
public
¶¶ 
async
¶¶ 
Task
¶¶ 
<
¶¶ 
Result
¶¶  
>
¶¶  !
GetRelatedJobs
¶¶" 0
(
¶¶0 1
int
¶¶1 4
nIdJob
¶¶5 ;
)
¶¶; <
{
ßß 	
var
®® 
lstJobs
®® 
=
®® 
await
®® 
_jobRepository
®®  .
.
®®. /
GetRelatedJobs
®®/ =
(
®®= >
nIdJob
®®> D
)
®®D E
;
®®E F
return
™™ 
new
™™ 
Result
™™ 
{
´´ 
	StateCode
¨¨ 
=
¨¨ 
	Constants
¨¨ %
.
¨¨% &
StateCodeResult
¨¨& 5
.
¨¨5 6
STATE_CODE_OK
¨¨6 C
,
¨¨C D
Data
≠≠ 
=
≠≠ 
lstJobs
≠≠ 
}
ÆÆ 
;
ÆÆ 
}
ØØ 	
public
∞∞ 
async
∞∞ 
Task
∞∞ 
<
∞∞ 
Result
∞∞  
>
∞∞  !
GetOtherJobs
∞∞" .
(
∞∞. /
)
∞∞/ 0
{
±± 	
var
≤≤ 
lstJobs
≤≤ 
=
≤≤ 
await
≤≤ 
_jobRepository
≤≤  .
.
≤≤. /
GetOtherJobs
≤≤/ ;
(
≤≤; <
)
≤≤< =
;
≤≤= >
return
¥¥ 
new
¥¥ 
Result
¥¥ 
{
µµ 
	StateCode
∂∂ 
=
∂∂ 
	Constants
∂∂ %
.
∂∂% &
StateCodeResult
∂∂& 5
.
∂∂5 6
STATE_CODE_OK
∂∂6 C
,
∂∂C D
Data
∑∑ 
=
∑∑ 
lstJobs
∑∑ 
}
∏∏ 
;
∏∏ 
}
ππ 	
public
∫∫ 
async
∫∫ 
Task
∫∫ 
<
∫∫ 
Result
∫∫  
>
∫∫  !

GetAllJobs
∫∫" ,
(
∫∫, -
JobFilterDto
∫∫- 9
filter
∫∫: @
)
∫∫@ A
{
ªª 	
var
ºº 
lstJobs
ºº 
=
ºº 
await
ºº 
_jobRepository
ºº  .
.
ºº. /

GetAllJobs
ºº/ 9
(
ºº9 :
filter
ºº: @
)
ºº@ A
;
ººA B
int
ΩΩ 
ntotalrecords
ΩΩ 
=
ΩΩ 
lstJobs
ΩΩ  '
.
ΩΩ' (
Count
ΩΩ( -
(
ΩΩ- .
)
ΩΩ. /
;
ΩΩ/ 0
lstJobs
ææ 
=
ææ 
lstJobs
ææ 
.
ææ 
Skip
ææ "
(
ææ" #
(
ææ# $
filter
ææ$ *
.
ææ* +
CurrentPage
ææ+ 6
-
ææ7 8
$num
ææ9 :
)
ææ: ;
*
ææ< =
$num
ææ> ?
)
ææ? @
.
ææ@ A
Take
ææA E
(
ææE F
$num
ææF G
)
ææG H
.
ææH I
ToList
ææI O
(
ææO P
)
ææP Q
;
ææQ R
return
¿¿ 
new
¿¿ 
Result
¿¿ 
{
¡¡ 
	StateCode
¬¬ 
=
¬¬ 
	Constants
¬¬ %
.
¬¬% &
StateCodeResult
¬¬& 5
.
¬¬5 6
STATE_CODE_OK
¬¬6 C
,
¬¬C D
Data
√√ 
=
√√ 
new
√√ 
{
√√ 
lista
ƒƒ 
=
ƒƒ 
lstJobs
ƒƒ #
,
ƒƒ# $
totalrecords
≈≈  
=
≈≈  !
ntotalrecords
≈≈" /
}
∆∆ 
}
»» 
;
»» 
}
…… 	
private
ÃÃ 
string
ÃÃ 
RelativeTime
ÃÃ #
(
ÃÃ# $
DateTime
ÃÃ$ ,
date
ÃÃ. 2
)
ÃÃ2 3
{
ÕÕ 	
const
œœ 
int
œœ 
SECOND
œœ 
=
œœ 
$num
œœ  
;
œœ  !
const
–– 
int
–– 
MINUTE
–– 
=
–– 
$num
–– !
*
––" #
SECOND
––$ *
;
––* +
const
—— 
int
—— 
HOUR
—— 
=
—— 
$num
—— 
*
——  !
MINUTE
——" (
;
——( )
const
““ 
int
““ 
DAY
““ 
=
““ 
$num
““ 
*
““  
HOUR
““! %
;
““% &
const
”” 
int
”” 
MONTH
”” 
=
”” 
$num
””  
*
””! "
DAY
””# &
;
””& '
var
’’ 
ts
’’ 
=
’’ 
new
’’ 
TimeSpan
’’ !
(
’’! "
DateTime
’’" *
.
’’* +
UtcNow
’’+ 1
.
’’1 2
Ticks
’’2 7
-
’’8 9
date
’’: >
.
’’> ?
Ticks
’’? D
)
’’D E
;
’’E F
double
÷÷ 
delta
÷÷ 
=
÷÷ 
Math
÷÷ 
.
÷÷  
Abs
÷÷  #
(
÷÷# $
ts
÷÷$ &
.
÷÷& '
TotalSeconds
÷÷' 3
)
÷÷3 4
;
÷÷4 5
if
ÿÿ 
(
ÿÿ 
delta
ÿÿ 
<
ÿÿ 
$num
ÿÿ 
*
ÿÿ 
MINUTE
ÿÿ "
)
ÿÿ" #
return
ŸŸ 
ts
ŸŸ 
.
ŸŸ 
Seconds
ŸŸ !
==
ŸŸ" $
$num
ŸŸ% &
?
ŸŸ' (
$str
ŸŸ) :
:
ŸŸ; <
$str
ŸŸ= D
+
ŸŸE F
ts
ŸŸF H
.
ŸŸH I
Seconds
ŸŸI P
+
ŸŸQ R
$str
ŸŸS ^
;
ŸŸ^ _
if
€€ 
(
€€ 
delta
€€ 
<
€€ 
$num
€€ 
*
€€ 
MINUTE
€€ "
)
€€" #
return
‹‹ 
$str
‹‹ '
;
‹‹' (
if
ﬁﬁ 
(
ﬁﬁ 
delta
ﬁﬁ 
<
ﬁﬁ 
$num
ﬁﬁ 
*
ﬁﬁ 
MINUTE
ﬁﬁ #
)
ﬁﬁ# $
return
ﬂﬂ 
$str
ﬂﬂ 
+
ﬂﬂ  
ts
ﬂﬂ! #
.
ﬂﬂ# $
Minutes
ﬂﬂ$ +
+
ﬂﬂ, -
$str
ﬂﬂ. 8
;
ﬂﬂ8 9
if
·· 
(
·· 
delta
·· 
<
·· 
$num
·· 
*
·· 
MINUTE
·· #
)
··# $
return
‚‚ 
$str
‚‚ &
;
‚‚& '
if
‰‰ 
(
‰‰ 
delta
‰‰ 
<
‰‰ 
$num
‰‰ 
*
‰‰ 
HOUR
‰‰ !
)
‰‰! "
return
ÂÂ 
$str
ÂÂ 
+
ÂÂ  !
ts
ÂÂ" $
.
ÂÂ$ %
Hours
ÂÂ% *
+
ÂÂ+ ,
$str
ÂÂ- 5
;
ÂÂ5 6
if
ÁÁ 
(
ÁÁ 
delta
ÁÁ 
<
ÁÁ 
$num
ÁÁ 
*
ÁÁ 
HOUR
ÁÁ !
)
ÁÁ! "
return
ËË 
$str
ËË 
;
ËË 
if
ÍÍ 
(
ÍÍ 
delta
ÍÍ 
<
ÍÍ 
$num
ÍÍ 
*
ÍÍ 
DAY
ÍÍ  
)
ÍÍ  !
return
ÎÎ 
$str
ÎÎ 
+
ÎÎ  
ts
ÎÎ! #
.
ÎÎ# $
Days
ÎÎ$ (
+
ÎÎ) *
$str
ÎÎ+ 2
;
ÎÎ2 3
if
ÌÌ 
(
ÌÌ 
delta
ÌÌ 
<
ÌÌ 
$num
ÌÌ 
*
ÌÌ 
MONTH
ÌÌ "
)
ÌÌ" #
{
ÓÓ 
int
ÔÔ 
months
ÔÔ 
=
ÔÔ 
Convert
ÔÔ $
.
ÔÔ$ %
ToInt32
ÔÔ% ,
(
ÔÔ, -
Math
ÔÔ- 1
.
ÔÔ1 2
Floor
ÔÔ2 7
(
ÔÔ7 8
(
ÔÔ8 9
double
ÔÔ9 ?
)
ÔÔ? @
ts
ÔÔ@ B
.
ÔÔB C
Days
ÔÔC G
/
ÔÔH I
$num
ÔÔJ L
)
ÔÔL M
)
ÔÔM N
;
ÔÔN O
return
 
months
 
<=
  
$num
! "
?
# $
$str
% 2
:
3 4
$str
5 <
+
= >
months
? E
+
F G
$str
H P
;
P Q
}
ÒÒ 
else
ÚÚ 
{
ÛÛ 
int
ÙÙ 
years
ÙÙ 
=
ÙÙ 
Convert
ÙÙ #
.
ÙÙ# $
ToInt32
ÙÙ$ +
(
ÙÙ+ ,
Math
ÙÙ, 0
.
ÙÙ0 1
Floor
ÙÙ1 6
(
ÙÙ6 7
(
ÙÙ7 8
double
ÙÙ8 >
)
ÙÙ> ?
ts
ÙÙ? A
.
ÙÙA B
Days
ÙÙB F
/
ÙÙG H
$num
ÙÙI L
)
ÙÙL M
)
ÙÙM N
;
ÙÙN O
return
ıı 
years
ıı 
<=
ıı 
$num
ıı  !
?
ıı" #
$str
ıı$ 1
:
ıı2 3
$str
ıı4 ;
+
ıı< =
years
ıı> C
+
ııD E
$str
ııF M
;
ııM N
}
ˆˆ 
}
˜˜ 	
}
˙˙ 
}˚˚ „
ÉD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\LanguagePostulant\IServices\ILanguagePostulantService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
LanguagePostulant$ 5
.5 6
	IServices6 ?
{		 
public

 

	interface

 %
ILanguagePostulantService

 .
{ 
Task 
< 
Result 
>  
GetLanguagePostulant )
() *
int* -
IdPerson. 6
)6 7
;7 8
Task 
< 
Result 
> 
Add 
(  
LanguagePostulantDto -
dto. 1
)1 2
;2 3
Task 
< 
Result 
> 
Update 
(  
LanguagePostulantDto 0
dto1 4
)4 5
;5 6
} 
} ÿ#
ÅD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\LanguagePostulant\Services\LanguagePostulantService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
LanguagePostulant$ 5
.5 6
Services6 >
{ 
public 

class $
LanguagePostulantService )
:* +%
ILanguagePostulantService, E
{ 
private 
readonly )
ILanguagesPostulantRepository 6'
languagePostulantRepository7 R
;R S
private 
readonly 
IBaseRepository (
<( )"
LanguagePostulantModel) ?
>? @
baseRepositoryA O
;O P
private 
readonly 
IMapper  
mapper! '
;' (
public $
LanguagePostulantService '
(' ()
ILanguagesPostulantRepository( E'
languagePostulantRepositoryF a
,a b
IBaseRepository( 7
<7 8"
LanguagePostulantModel8 N
>N O
baseRepositoryP ^
,^ _
IMapper( /
mapper0 6
)6 7
{ 	
this 
. '
languagePostulantRepository ,
=- .'
languagePostulantRepository/ J
;J K
this 
. 
baseRepository 
=  !
baseRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
>  !
Add" %
(% & 
LanguagePostulantDto& :
dto; >
)> ?
{ 	
var 
entity 
= 
mapper 
.  
Map  #
<# $"
LanguagePostulantModel$ :
>: ;
(; <
dto< ?
)? @
;@ A
await   
baseRepository    
.    !
Add  ! $
(  $ %
entity  % +
)  + ,
;  , -
dto!! 
.!! 
Id!! 
=!! 
entity!! 
.!! 
Id!! 
;!! 
return## 
new## 
Result## 
{$$ 
Data%% 
=%% 
dto%% 
,%% 
	StateCode&& 
=&& 
	Constants&& %
.&&% &
StateCodeResult&&& 5
.&&5 6
STATE_CODE_OK&&6 C
}'' 
;'' 
}(( 	
public** 
async** 
Task** 
<** 
Result**  
>**  ! 
GetLanguagePostulant**" 6
(**6 7
int**7 :
IdPerson**; C
)**C D
{++ 	
var,, 
dto,, 
=,, 
await,, '
languagePostulantRepository,, 7
.,,7 8 
GetLanguagePostulant,,8 L
(,,L M
IdPerson,,M U
),,U V
;,,V W
return.. 
new.. 
Result.. 
{// 
	StateCode00 
=00 
	Constants00 %
.00% &
StateCodeResult00& 5
.005 6
STATE_CODE_OK006 C
,00C D
Data11 
=11 
dto11 
}22 
;22 
}33 	
public55 
async55 
Task55 
<55 
Result55  
>55  !
Update55" (
(55( ) 
LanguagePostulantDto55) =
dto55> A
)55A B
{66 	
var77 
entity77 
=77 
mapper77 
.77  
Map77  #
<77# $"
LanguagePostulantModel77$ :
>77: ;
(77; <
dto77< ?
)77? @
;77@ A
await88 
baseRepository88  
.88  !
Update88! '
(88' (
entity88( .
)88. /
;88/ 0
dto99 
.99 
Id99 
=99 
entity99 
.99 
Id99 
;99 
return;; 
new;; 
Result;; 
{<< 
Data== 
=== 
dto== 
,== 
	StateCode>> 
=>> 
	Constants>> %
.>>% &
StateCodeResult>>& 5
.>>5 6
STATE_CODE_OK>>6 C
}?? 
;?? 
}@@ 	
}AA 
}BB ‰
wD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\MasterTable\IServices\IMasterTableService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
MasterTable$ /
./ 0
	IServices0 9
{ 
public		 

	interface		 
IMasterTableService		 (
{

 
Task 
< 
Result 
> 
GetByIdFather "
(" #
int# &
id' )
)) *
;* +
Task 
< 
Result 
> !
GetCategoryEmployment *
(* +
)+ ,
;, -
} 
} ˛
uD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\MasterTable\Services\MasterTableService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
MasterTable$ /
./ 0
Services0 8
{ 
public 

class 
MasterTableService #
:# $
IMasterTableService% 8
{ 
private 
readonly "
IMasterTableRepository /!
masterTableRepository0 E
;E F
private 
readonly 
IUtilRepository (
utilRepository) 7
;7 8
public 
MasterTableService !
(! ""
IMasterTableRepository" 8!
masterTableRepository9 N
,N O
IUtilRepositoryP _
utilRepository` n
)n o
{ 	
this 
. !
masterTableRepository &
=' (!
masterTableRepository) >
;> ?
this 
. 
utilRepository 
=  !
utilRepository" 0
;0 1
} 	
public 
async 
Task 
< 
Result  
>  !
GetByIdFather" /
(/ 0
int0 3
id4 6
)6 7
{ 	
var 
dto 
= 
await !
masterTableRepository 1
.1 2
GetByIdFather2 ?
(? @
id@ B
)B C
;C D
return 
new 
Result 
{ 
Data 
= 
dto 
, 
	StateCode 
= 
	Constants %
.% &
StateCodeResult& 5
.5 6
STATE_CODE_OK6 C
} 
; 
} 	
public!! 
async!! 
Task!! 
<!! 
Result!!  
>!!  !!
GetCategoryEmployment!!" 7
(!!7 8
)!!8 9
{"" 	
var## 
listdistrict## 
=## 
await## $
utilRepository##% 3
.##3 4%
GetListCategoryEmployment##4 M
(##M N
)##N O
;##O P
return$$ 
new$$ 
Result$$ 
{%% 
Data&& 
=&& 
listdistrict&& #
,&&# $
	StateCode'' 
='' 
	Constants'' %
.''% &
StateCodeResult''& 5
.''5 6
STATE_CODE_OK''6 C
}(( 
;(( 
})) 	
}** 
}++ ∆
mD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Person\IServices\IPersonService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Person$ *
.* +
	IServices+ 4
{ 
public 

	interface 
IPersonService #
{		 
Task

 
<

 
Result

 
>

 
GetById

 
(

 
int

  
id

! #
)

# $
;

$ %
Task 
< 
Result 
> %
UpdatePersonalInformation .
(. /
	PersonDto/ 8
	personDto9 B
)B C
;C D
Task 
< 
Result 
> $
UpdateContactInformation -
(- .
	PersonDto. 7
	personDto8 A
)A B
;B C
Task 
< 
Result 
> 
SaveImg 
( 
PersonCvDto (
dto) ,
,, -
	IFormFile. 7
formFile8 @
)@ A
;A B
Task 
< 
Result 
> 
SaveCv 
( 
PersonCvDto '
dto( +
,+ ,
	IFormFile- 6
formFile7 ?
)? @
;@ A
Task 
< 
Result 
> 
DeleteCv 
( 
int !
IdPerson" *
)* +
;+ ,
} 
} Äù
kD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Person\Services\PersonService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Person$ *
.* +
Services+ 3
{ 
public 

class 
PersonService 
:  
IPersonService! /
{ 
private 
readonly 
IBaseRepository (
<( ) 
PersonModelPostulant) =
>= > 
basePersonRepository? S
;S T
private 
readonly 
IPersonRepository *
personRepository+ ;
;; <
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
AppSettings $
_appSettings% 1
;1 2
private 
readonly 
ILogger  
<  !
PersonService! .
>. /
_logger0 7
;7 8
public 
PersonService 
( 
IBaseRepository ,
<, - 
PersonModelPostulant- A
>A B 
basePersonRepositoryC W
,W X
IPersonRepository .
personRepository/ ?
,? @
IMapper $
mapper% +
,+ ,
IOptions %
<% &
AppSettings& 1
>1 2
appSettings3 >
,> ?
ILogger $
<$ %
PersonService% 2
>2 3
logger4 :
): ;
{   	
this!! 
.!!  
basePersonRepository!! %
=!!& ' 
basePersonRepository!!( <
;!!< =
this"" 
."" 
personRepository"" !
=""" #
personRepository""$ 4
;""4 5
this## 
.## 
mapper## 
=## 
mapper##  
;##  !
this$$ 
.$$ 
_appSettings$$ 
=$$ 
appSettings$$  +
.$$+ ,
Value$$, 1
;$$1 2
this%% 
.%% 
_logger%% 
=%% 
logger%% !
;%%! "
}&& 	
public(( 
async(( 
Task(( 
<(( 
Result((  
>((  !
DeleteCv((" *
(((* +
int((+ .
IdPerson((/ 7
)((7 8
{)) 	
var** 
res** 
=** 
await** 
personRepository** ,
.**, -
DeleteCv**- 5
(**5 6
IdPerson**6 >
)**> ?
;**? @
return,, 
new,, 
Result,, 
{-- 
Data.. 
=.. 
res.. 
,.. 
	StateCode// 
=// 
	Constants// %
.//% &
StateCodeResult//& 5
.//5 6
STATE_CODE_OK//6 C
}00 
;00 
}11 	
public33 
async33 
Task33 
<33 
Result33  
>33  !
GetById33" )
(33) *
int33* -
id33. 0
)330 1
{44 	
var55 
person55 
=55 
await55 
personRepository55 /
.55/ 0
	GetPerson550 9
(559 :
id55: <
)55< =
;55= >
_logger66 
.66 
LogInformation66 "
(66" #
string66# )
.66) *
Format66* 0
(660 1
$str661 N
,66N O
person66P V
.66V W
Id66W Y
,66Y Z
person66[ a
.66a b
Img66b e
)66e f
)66f g
;66g h
if77 
(77 
person77 
.77 
Img77 
!=77 
null77 "
)77" #
{88 
var99 
file99 
=99 
person99 !
.99! "
Img99" %
;99% &
if:: 
(:: 
File:: 
.:: 
Exists:: 
(::  
file::  $
)::$ %
)::% &
{;; 
var<< 
buffer<< 
=<<  
File<<! %
.<<% &
ReadAllBytes<<& 2
(<<2 3
file<<3 7
)<<7 8
;<<8 9
person== 
.== 
Img== 
===  
$"==! #
$str==# :
{==: ;
Convert==; B
.==B C
ToBase64String==C Q
(==Q R
buffer==R X
)==X Y
}==Y Z
"==Z [
;==[ \
}>> 
}?? 
ifAA 
(AA 
personAA 
.AA 
CvFolderAA 
!=AA  "
nullAA# '
)AA' (
{BB 
varCC 
fileCC 
=CC 
personCC !
.CC! "
CvFolderCC" *
;CC* +
ifDD 
(DD 
FileDD 
.DD 
ExistsDD 
(DD  
fileDD  $
)DD$ %
)DD% &
{EE 
varFF 
bufferFF 
=FF  
FileFF! %
.FF% &
ReadAllBytesFF& 2
(FF2 3
fileFF3 7
)FF7 8
;FF8 9
personGG 
.GG 
CvFileGG !
=GG" #
bufferGG$ *
;GG* +
personHH 
.HH 
ContentTypeHH &
=HH' (
PathHH) -
.HH- .
GetExtensionHH. :
(HH: ;
personHH; A
.HHA B
CvNameHHB H
)HHH I
;HHI J
}II 
}JJ 
returnNN 
newNN 
ResultNN 
{OO 
	StateCodePP 
=PP 
	ConstantsPP %
.PP% &
StateCodeResultPP& 5
.PP5 6
STATE_CODE_OKPP6 C
,PPC D
DataQQ 
=QQ 
personQQ 
}RR 
;RR 
}SS 	
publicUU 
asyncUU 
TaskUU 
<UU 
ResultUU  
>UU  !
SaveCvUU" (
(UU( )
PersonCvDtoUU) 4
dtoUU5 8
,UU8 9
	IFormFileUU: C
formFileUUD L
)UUL M
{VV 	
varWW 
folderWW 
=WW 
_appSettingsWW %
.WW% &
PathSaveFileWW& 2
;WW2 3
varXX 
filenamefolderXX 
=XX  
folderXX! '
+XX( )
$strXX* 8
;XX8 9
dtoYY 
.YY 
NameYY 
=YY 
formFileYY 
.YY  
FileNameYY  (
;YY( )
dtoZZ 
.ZZ 
FolderZZ 
=ZZ 
filenamefolderZZ '
+ZZ( )
dtoZZ* -
.ZZ- .
NameZZ. 2
;ZZ2 3
if\\ 
(\\ 
!\\ 
	Directory\\ 
.\\ 
Exists\\ !
(\\! "
filenamefolder\\" 0
)\\0 1
)\\1 2
{]] 
	Directory^^ 
.^^ 
CreateDirectory^^ )
(^^) *
filenamefolder^^* 8
)^^8 9
;^^9 :
}__ 
usingaa 
(aa 
varaa 
streamaa 
=aa 
newaa  #

FileStreamaa$ .
(aa. /
dtoaa/ 2
.aa2 3
Folderaa3 9
,aa9 :
FileModeaa; C
.aaC D
CreateaaD J
)aaJ K
)aaK L
{bb 
formFilecc 
.cc 
CopyTocc 
(cc  
streamcc  &
)cc& '
;cc' (
}dd 
vargg 
resultgg 
=gg 
awaitgg 
personRepositorygg /
.gg/ 0
SaveCvgg0 6
(gg6 7
dtogg7 :
)gg: ;
;gg; <
varhh 
personhh 
=hh 
awaithh 
personRepositoryhh /
.hh/ 0
	GetPersonhh0 9
(hh9 :
dtohh: =
.hh= >
IdPersonhh> F
)hhF G
;hhG H
ifjj 
(jj 
personjj 
.jj 
CvFolderjj 
!=jj  "
nulljj# '
)jj' (
{kk 
varll 
filell 
=ll 
personll !
.ll! "
CvFolderll" *
;ll* +
ifmm 
(mm 
Filemm 
.mm 
Existsmm 
(mm  
filemm  $
)mm$ %
)mm% &
{nn 
varoo 
bufferoo 
=oo  
Fileoo! %
.oo% &
ReadAllBytesoo& 2
(oo2 3
fileoo3 7
)oo7 8
;oo8 9
dtopp 
.pp 
Archivopp 
=pp  !
bufferpp" (
;pp( )
dtoqq 
.qq 
ContentTypeqq #
=qq$ %
Pathqq& *
.qq* +
GetExtensionqq+ 7
(qq7 8
personqq8 >
.qq> ?
CvNameqq? E
)qqE F
;qqF G
}rr 
}ss 
returnuu 
newuu 
Resultuu 
{vv 
Dataww 
=ww 
dtoww 
,ww 
	StateCodexx 
=xx 
	Constantsxx %
.xx% &
StateCodeResultxx& 5
.xx5 6
STATE_CODE_OKxx6 C
}yy 
;yy 
}zz 	
public|| 
async|| 
Task|| 
<|| 
Result||  
>||  !
SaveImg||" )
(||) *
PersonCvDto||* 5
dto||6 9
,||9 :
	IFormFile||; D
formFile||E M
)||M N
{}} 	
try~~ 
{ 
var
ÄÄ 
folder
ÄÄ 
=
ÄÄ 
_appSettings
ÄÄ )
.
ÄÄ) *
PathSaveFile
ÄÄ* 6
;
ÄÄ6 7
var
ÅÅ 
filenamefolder
ÅÅ "
=
ÅÅ# $
folder
ÅÅ% +
+
ÅÅ, -
$str
ÅÅ. 7
;
ÅÅ7 8
var
ÇÇ "
_nombreFileAleatorio
ÇÇ (
=
ÇÇ) *
string
ÇÇ+ 1
.
ÇÇ1 2
Format
ÇÇ2 8
(
ÇÇ8 9
$str
ÇÇ9 A
,
ÇÇA B
Guid
ÇÇC G
.
ÇÇG H
NewGuid
ÇÇH O
(
ÇÇO P
)
ÇÇP Q
,
ÇÇQ R
Path
ÇÇS W
.
ÇÇW X
GetExtension
ÇÇX d
(
ÇÇd e
formFile
ÇÇe m
.
ÇÇm n
FileName
ÇÇn v
)
ÇÇv w
)
ÇÇw x
;
ÇÇx y
dto
ÉÉ 
.
ÉÉ 
Name
ÉÉ 
=
ÉÉ "
_nombreFileAleatorio
ÉÉ /
;
ÉÉ/ 0
dto
ÑÑ 
.
ÑÑ 
Folder
ÑÑ 
=
ÑÑ 
filenamefolder
ÑÑ +
+
ÑÑ, -"
_nombreFileAleatorio
ÑÑ. B
;
ÑÑB C
if
ÜÜ 
(
ÜÜ 
!
ÜÜ 
	Directory
ÜÜ 
.
ÜÜ 
Exists
ÜÜ %
(
ÜÜ% &
filenamefolder
ÜÜ& 4
)
ÜÜ4 5
)
ÜÜ5 6
{
áá 
	Directory
àà 
.
àà 
CreateDirectory
àà -
(
àà- .
filenamefolder
àà. <
)
àà< =
;
àà= >
}
ââ 
using
ãã 
(
ãã 
var
ãã 
stream
ãã !
=
ãã" #
new
ãã$ '

FileStream
ãã( 2
(
ãã2 3
dto
ãã3 6
.
ãã6 7
Folder
ãã7 =
,
ãã= >
FileMode
ãã? G
.
ããG H
Create
ããH N
)
ããN O
)
ããO P
{
åå 
formFile
çç 
.
çç 
CopyTo
çç #
(
çç# $
stream
çç$ *
)
çç* +
;
çç+ ,
}
éé 
var
ëë 
result
ëë 
=
ëë 
await
ëë "
personRepository
ëë# 3
.
ëë3 4
SaveImg
ëë4 ;
(
ëë; <
dto
ëë< ?
)
ëë? @
;
ëë@ A
var
íí 
person
íí 
=
íí 
await
íí "
personRepository
íí# 3
.
íí3 4
	GetPerson
íí4 =
(
íí= >
dto
íí> A
.
ííA B
IdPerson
ííB J
)
ííJ K
;
ííK L
if
îî 
(
îî 
person
îî 
.
îî 
Img
îî 
!=
îî !
null
îî" &
)
îî& '
{
ïï 
var
ññ 
file
ññ 
=
ññ 
person
ññ %
.
ññ% &
Img
ññ& )
;
ññ) *
if
óó 
(
óó 
File
óó 
.
óó 
Exists
óó #
(
óó# $
file
óó$ (
)
óó( )
)
óó) *
{
òò 
var
ôô 
buffer
ôô "
=
ôô# $
File
ôô% )
.
ôô) *
ReadAllBytes
ôô* 6
(
ôô6 7
file
ôô7 ;
)
ôô; <
;
ôô< =
dto
öö 
.
öö 
Img
öö 
=
öö  !
$"
öö" $
$str
öö$ ;
{
öö; <
Convert
öö< C
.
ööC D
ToBase64String
ööD R
(
ööR S
buffer
ööS Y
)
ööY Z
}
ööZ [
"
öö[ \
;
öö\ ]
}
õõ 
}
úú 
}
ùù 
catch
ûû 
(
ûû 
	Exception
ûû 
ex
ûû 
)
ûû  
{
üü 
_logger
†† 
.
†† 
LogError
††  
(
††  !
string
††! '
.
††' (
Format
††( .
(
††. /
$str
††/ Z
,
††Z [
ex
††\ ^
.
††^ _
Message
††_ f
,
††f g
ex
††h j
.
††j k

StackTrace
††k u
)
††u v
)
††v w
;
††w x
}
°° 
return
££ 
new
££ 
Result
££ 
{
§§ 
Data
•• 
=
•• 
dto
•• 
,
•• 
	StateCode
¶¶ 
=
¶¶ 
	Constants
¶¶ %
.
¶¶% &
StateCodeResult
¶¶& 5
.
¶¶5 6
STATE_CODE_OK
¶¶6 C
}
ßß 
;
ßß 
}
®® 	
public
™™ 
async
™™ 
Task
™™ 
<
™™ 
Result
™™  
>
™™  !&
UpdateContactInformation
™™" :
(
™™: ;
	PersonDto
™™; D
	personDto
™™E N
)
™™N O
{
´´ 	
var
¨¨ 
person
¨¨ 
=
¨¨ 
mapper
¨¨ 
.
¨¨  
Map
¨¨  #
<
¨¨# $"
PersonModelPostulant
¨¨$ 8
>
¨¨8 9
(
¨¨9 :
	personDto
¨¨: C
)
¨¨C D
;
¨¨D E
await
ÆÆ "
basePersonRepository
ÆÆ &
.
ÆÆ& '
UpdatePartial
ÆÆ' 4
(
ÆÆ4 5
person
ÆÆ5 ;
,
ÆÆ; <
x
ÆÆ= >
=>
ÆÆ? A
x
ÆÆB C
.
ÆÆC D
	CellPhone
ÆÆD M
,
ÆÆM N
x
ØØ< =
=>
ØØ> @
x
ØØA B
.
ØØB C
AnotherPhone
ØØC O
,
ØØO P
x
∞∞< =
=>
∞∞> @
x
∞∞A B
.
∞∞B C 
IdDistrictLocation
∞∞C U
,
∞∞U V
x
±±< =
=>
±±> @
x
±±A B
.
±±B C 
IdProvinceLocation
±±C U
,
±±U V
x
≤≤< =
=>
≤≤> @
x
≤≤A B
.
≤≤B C"
IdDepartmentLocation
≤≤C W
,
≤≤W X
x
≥≥< =
=>
≥≥> @
x
≥≥A B
.
≥≥B C
Address
≥≥C J
,
≥≥J K
x
¥¥< =
=>
¥¥> @
x
¥¥A B
.
¥¥B C
Email
¥¥C H
,
¥¥H I
x
µµ< =
=>
µµ> @
x
µµA B
.
µµB C
UrlProfesional
µµC Q
)
µµQ R
;
µµR S
return
∑∑ 
new
∑∑ 
Result
∑∑ 
{
∏∏ 
	StateCode
ππ 
=
ππ 
	Constants
ππ %
.
ππ% &
StateCodeResult
ππ& 5
.
ππ5 6
STATE_CODE_OK
ππ6 C
}
∫∫ 
;
∫∫ 
}
ªª 	
public
ΩΩ 
async
ΩΩ 
Task
ΩΩ 
<
ΩΩ 
Result
ΩΩ  
>
ΩΩ  !'
UpdatePersonalInformation
ΩΩ" ;
(
ΩΩ; <
	PersonDto
ΩΩ< E
	personDto
ΩΩF O
)
ΩΩO P
{
ææ 	
var
øø 
	birthDate
øø 
=
øø 
	personDto
øø %
.
øø% &
	BirthDate
øø& /
;
øø/ 0
var
¿¿ 
date
¿¿ 
=
¿¿ 
new
¿¿ 
DateTime
¿¿ #
(
¿¿# $
)
¿¿$ %
;
¿¿% &
var
¡¡ 
dat
¡¡ 
=
¡¡ 
	personDto
¡¡ 
.
¡¡  
	BirthDate
¡¡  )
.
¡¡) *
Split
¡¡* /
(
¡¡/ 0
$char
¡¡0 3
)
¡¡3 4
;
¡¡4 5
if
¬¬ 
(
¬¬ 
dat
¬¬ 
?
¬¬ 
.
¬¬ 
Length
¬¬ 
>
¬¬ 
$num
¬¬ 
)
¬¬  
{
√√ 
date
ƒƒ 
=
ƒƒ 
new
ƒƒ 
DateTime
ƒƒ #
(
ƒƒ# $
Convert
ƒƒ$ +
.
ƒƒ+ ,
ToInt32
ƒƒ, 3
(
ƒƒ3 4
dat
ƒƒ4 7
[
ƒƒ7 8
$num
ƒƒ8 9
]
ƒƒ9 :
)
ƒƒ: ;
,
ƒƒ; <
Convert
ƒƒ= D
.
ƒƒD E
ToInt32
ƒƒE L
(
ƒƒL M
dat
ƒƒM P
[
ƒƒP Q
$num
ƒƒQ R
]
ƒƒR S
)
ƒƒS T
,
ƒƒT U
Convert
ƒƒV ]
.
ƒƒ] ^
ToInt32
ƒƒ^ e
(
ƒƒe f
dat
ƒƒf i
[
ƒƒi j
$num
ƒƒj k
]
ƒƒk l
)
ƒƒl m
)
ƒƒm n
;
ƒƒn o
}
≈≈ 
	personDto
«« 
.
«« 
	BirthDate
«« 
=
««  !
null
««" &
;
««& '
var
»» 
person
»» 
=
»» 
mapper
»» 
.
»»  
Map
»»  #
<
»»# $"
PersonModelPostulant
»»$ 8
>
»»8 9
(
»»9 :
	personDto
»»: C
)
»»C D
;
»»D E
person
ÃÃ 
.
ÃÃ 
	BirthDate
ÃÃ 
=
ÃÃ 
date
ÃÃ #
;
ÃÃ# $
await
ŒŒ "
basePersonRepository
ŒŒ &
.
ŒŒ& '
UpdatePartial
ŒŒ' 4
(
ŒŒ4 5
person
ŒŒ5 ;
,
ŒŒ; <
x
ŒŒ= >
=>
ŒŒ? A
x
ŒŒB C
.
ŒŒC D
	FirstName
ŒŒD M
,
ŒŒM N
x
œœ< =
=>
œœ> @
x
œœA B
.
œœB C

SecondName
œœC M
,
œœM N
x
––< =
=>
––> @
x
––A B
.
––B C
LastName
––C K
,
––K L
x
——< =
=>
——> @
x
——A B
.
——B C
MotherLastName
——C Q
,
——Q R
x
““< =
=>
““> @
x
““A B
.
““B C
	BirthDate
““C L
,
““L M
x
””< =
=>
””> @
x
””A B
.
””B C
IdNationality
””C P
,
””P Q
x
‘‘< =
=>
‘‘> @
x
‘‘A B
.
‘‘B C
IdCivilStatus
‘‘C P
,
‘‘P Q
x
’’< =
=>
’’> @
x
’’A B
.
’’B C
IdTypeDocument
’’C Q
,
’’Q R
x
÷÷< =
=>
÷÷> @
x
÷÷A B
.
÷÷B C
DocumentNumber
÷÷C Q
,
÷÷Q R
x
◊◊< =
=>
◊◊> @
x
◊◊A B
.
◊◊B C
HaveDriverLicense
◊◊C T
,
◊◊T U
x
ÿÿ< =
=>
ÿÿ> @
x
ÿÿA B
.
ÿÿB C
LicenceDrive
ÿÿC O
,
ÿÿO P
x
ŸŸ< =
=>
ŸŸ> @
x
ŸŸA B
.
ŸŸB C
HaveOwnMobility
ŸŸC R
,
ŸŸR S
x
⁄⁄< =
=>
⁄⁄> @
x
⁄⁄A B
.
⁄⁄B C
IdSex
⁄⁄C H
)
⁄⁄H I
;
⁄⁄I J
return
‹‹ 
new
‹‹ 
Result
‹‹ 
{
›› 
	StateCode
ﬁﬁ 
=
ﬁﬁ 
	Constants
ﬁﬁ %
.
ﬁﬁ% &
StateCodeResult
ﬁﬁ& 5
.
ﬁﬁ5 6
STATE_CODE_OK
ﬁﬁ6 C
}
ﬂﬂ 
;
ﬂﬂ 
}
‡‡ 	
}
·· 
}‚‚ ‡
D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\RecruitmentArea\IServices\IRecruitmentAreaService.cs
	namespace		 	
SitePostulant		
 
.		 
Application		 #
.		# $
RecruitmentArea		$ 3
.		3 4
	IServices		4 =
{

 
public 

	interface #
IRecruitmentAreaService ,
{ 
Task 
< 
Result 
> 
GetAll 
( 
int 
	idEmpresa  )
)) *
;* +
} 
} Î
}D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\RecruitmentArea\Services\RecruitmentAreaService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
RecruitmentArea$ 3
.3 4
Services4 <
{ 
public 

class "
RecruitmentAreaService '
:( )#
IRecruitmentAreaService* A
{ 
private 
readonly 
IBaseRepository (
<( )
HumanManagement) 8
.8 9
Domain9 ?
.? @
RecruitmentArea@ O
.O P
ModelsP V
.V W
RecruitmentAreaW f
>f g
_baseRepositoryh w
;w x
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
IMapper 
_mapper 
;  
private 
readonly 
IAreaRepository (
areaRepository) 7
;7 8
public "
RecruitmentAreaService %
(% &
IBaseRepository& 5
<5 6
HumanManagement6 E
.E F
DomainF L
.L M
RecruitmentAreaM \
.\ ]
Models] c
.c d
RecruitmentAread s
>s t
baseRepository	u É
,
É Ñ
IUnitOfWork
Ö ê

unitOfWork
ë õ
,
õ ú
IMapper
ù §
mapper
• ´
,
´ ¨
IAreaRepository
≠ º
areaRepository
Ω À
)
À Ã
{ 	
this 
. 
_baseRepository  
=! "
baseRepository# 1
;1 2
this 
. 
_unitOfWork 
= 

unitOfWork )
;) *
this 
. 
_mapper 
= 
mapper !
;! "
this 
. 
areaRepository 
=  !
areaRepository" 0
;0 1
} 	
public   
async   
Task   
<   
Result    
>    !
GetAll  " (
(  ( )
int  ) ,
	idEmpresa  - 6
)  6 7
{!! 	
var%% 
result%% 
=%% 
await%% 
areaRepository%% -
.%%- .
GetByEmpresa%%. :
(%%: ;
	idEmpresa%%; D
)%%D E
;%%E F
return'' 
new'' 
Result'' 
{(( 
	StateCode)) 
=)) 
	Constants)) %
.))% &
StateCodeResult))& 5
.))5 6
STATE_CODE_OK))6 C
,))C D
Data** 
=** 
result** 
}++ 
;++ 
}.. 	
}00 
}11 ‡
]D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Response\Result.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Response$ ,
{ 
public 

class 
Result 
{ 
public 
int 
	StateCode 
{ 
get "
;" #
set$ '
;' (
}) *
public		 
List		 
<		 
string		 
>		 
MessageError		 (
{		) *
get		+ .
;		. /
set		0 3
;		3 4
}		5 6
public

 
Object

 
Data

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
Result 
( 
) 
{ 	
MessageError 
= 
new 
List #
<# $
string$ *
>* +
(+ ,
), -
;- .
} 	
} 
} €
ÄD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\SalaryPreference\IService\ISalaryPreferenceService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
SalaryPreference$ 4
.4 5
IService5 =
{		 
public

 

	interface

 $
ISalaryPreferenceService

 -
{ 
Task 
< 
Result 
>  
GetSalaryByPostulant )
() *
int* -
IdPerson. 6
)6 7
;7 8
Task 
< 
Result 
> 
Add 
( 
SalaryPreferenceDto ,
dto- 0
)0 1
;1 2
Task 
< 
Result 
> 
Update 
( 
SalaryPreferenceDto /
dto0 3
)3 4
;4 5
} 
} —(
~D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\SalaryPreference\Service\SalaryPreferenceService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
SalaryPreference$ 4
.4 5
Service5 <
{ 
public 

class #
SalaryPreferenceService (
:( )$
ISalaryPreferenceService* B
{ 
private 
readonly 
IBaseRepository (
<( )!
SalaryPreferenceModel) >
>> ?
baseRepository@ N
;N O
private 
readonly 
IMapper  
mapper! '
;' (
public #
SalaryPreferenceService &
(& '
IBaseRepository' 6
<6 7!
SalaryPreferenceModel7 L
>L M
baseRepositoryN \
,\ ]
IMapper^ e
mapperf l
)l m
{ 	
this 
. 
baseRepository 
=  !
baseRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
>  !
Add" %
(% &
SalaryPreferenceDto& 9
dto: =
)= >
{ 	
dto 
. 
Monto 
= 
dto 
. 
Monto !
.! "
Replace" )
() *
$str* .
,. /
string0 6
.6 7
Empty7 <
)< =
;= >
var 
entity 
= 
mapper 
.  
Map  #
<# $!
SalaryPreferenceModel$ 9
>9 :
(: ;
dto; >
)> ?
;? @
await 
baseRepository  
.  !
Add! $
($ %
entity% +
)+ ,
;, -
dto 
. 
Id 
= 
entity 
. 
Id 
; 
return   
new   
Result   
{!! 
Data"" 
="" 
dto"" 
,"" 
	StateCode## 
=## 
	Constants## %
.##% &
StateCodeResult##& 5
.##5 6
STATE_CODE_OK##6 C
}$$ 
;$$ 
}%% 	
public'' 
async'' 
Task'' 
<'' 
Result''  
>''  ! 
GetSalaryByPostulant''" 6
(''6 7
int''7 :
IdPerson''; C
)''C D
{(( 	
var)) 
entites)) 
=)) 
await)) 
baseRepository))  .
.)). /
FindAllPredicate))/ ?
())? @
x))@ A
=>))B D
x))E F
.))F G
IdPerson))G O
==))P R
IdPerson))S [
&&))\ ^
x))_ `
.))` a
Active))a g
==))h j
true))k o
)))o p
;))p q
var++ 
dto++ 
=++ 
mapper++ 
.++ 
Map++  
<++  !
List++! %
<++% &
SalaryPreferenceDto++& 9
>++9 :
>++: ;
(++; <
entites++< C
)++C D
;++D E
return-- 
new-- 
Result-- 
{.. 
	StateCode// 
=// 
	Constants// %
.//% &
StateCodeResult//& 5
.//5 6
STATE_CODE_OK//6 C
,//C D
Data00 
=00 
dto00 
}11 
;11 
}22 	
public44 
async44 
Task44 
<44 
Result44  
>44  !
Update44" (
(44( )
SalaryPreferenceDto44) <
dto44= @
)44@ A
{55 	
dto66 
.66 
Monto66 
=66 
dto66 
.66 
Monto66 !
.66! "
Replace66" )
(66) *
$str66* .
,66. /
string660 6
.666 7
Empty667 <
)66< =
;66= >
var77 
entity77 
=77 
mapper77 
.77  
Map77  #
<77# $!
SalaryPreferenceModel77$ 9
>779 :
(77: ;
dto77; >
)77> ?
;77? @
await88 
baseRepository88  
.88  !
Update88! '
(88' (
entity88( .
)88. /
;88/ 0
dto99 
.99 
Id99 
=99 
entity99 
.99 
Id99 
;99 
return;; 
new;; 
Result;; 
{<< 
Data== 
=== 
dto== 
,== 
	StateCode>> 
=>> 
	Constants>> %
.>>% &
StateCodeResult>>& 5
.>>5 6
STATE_CODE_OK>>6 C
}?? 
;?? 
}@@ 	
}AA 
}BB Õ
nD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Security\IServices\ILoginService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Security$ ,
., -
	IServices- 6
{		 
public

 

	interface

 
ILoginService

 "
{ 
Task 
< 
Result 
> 
GetLoginUserQuery &
(& '
LoginDto' /
loginDto0 8
)8 9
;9 :
} 
} î
nD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Security\IServices\ITokenService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Security$ ,
., -
	IServices- 6
{ 
public		 

	interface		 
ITokenService		 "
{

 
Task 
< 
UserSessionDto 
> 
GetUserByToken +
(+ ,
string, 2
token3 8
)8 9
;9 :
Task 
< 
bool 
> 
IsValidToken 
(  
TokenUserQueryDto  1
tokenUserQueryDto2 C
)C D
;D E
} 
} ≈
mD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Security\IServices\IUserService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Security$ ,
., -
	IServices- 6
{		 
public

 

	interface

 
IUserService

 !
{ 
Task 
< 
Result 
> 

CreateUser 
(  
UserDto  '
userDto( /
)/ 0
;0 1
Task 
< 
Result 
> 
ChangePassword #
(# $
ResetPasswordDto$ 4
resetPasswordDto5 E
)E F
;F G
Task 
< 
Result 
> 
ForgotPassword #
(# $
ForgotPasswordDto$ 5
forgotPasswordDto6 G
)G H
;H I
Task 
< 
Result 
> "
ValidResetPasswordCode +
(+ ,
int, /
IdUser0 6
,6 7
Byte8 <
[< =
]= >
providedCode? K
)K L
;L M
Task 
< 
Result 
> 
ActiveAccount "
(" #
int# &
id' )
)) *
;* +
Task 
< 
Result 
> 
SendMailActivation '
(' (
string( .
email/ 4
)4 5
;5 6
Task 
< 
Result 
> '
ChangePasswordConfiguration 0
(0 1
ChangePasswordDto1 B
dtoC F
)F G
;G H
Task 
< 
Result 
> 

DeleteUser 
(  
DeleteUserDto  -
dto. 1
)1 2
;2 3
Task 
< 
Result 
> *
SendEmailPostulantConfirmation 3
(3 4
string4 :
email; @
,@ A
stringA G
jobH K
)K L
;L M
} 
} æC
lD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Security\Services\LoginService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Security$ ,
., -
Services- 5
{ 
public 

class 
LoginService 
: 
ILoginService  -
{ 
private 
readonly 
HumanManagement (
.( )
Domain) /
./ 0
	Postulant0 9
.9 :
Security: B
.B C
	ContractsC L
.L M
IUserRepositoryM \
userRepository] k
;k l
private 
readonly 
HumanManagement (
.( )
Domain) /
./ 0
	Postulant0 9
.9 :
Security: B
.B C
	ContractsC L
.L M"
IProfileUserRepositoryM c!
profileUserRepositoryd y
;y z
private 
readonly 
HumanManagement (
.( )
Domain) /
./ 0
	Postulant0 9
.9 :
Security: B
.B C
	ContractsC L
.L M&
IProfileResourceRepositoryM g&
profileResourceRepository	h Å
;
Å Ç
private 
readonly 
ICryptography &
cryptography' 3
;3 4
private 
readonly 
HumanManagement (
.( )
Domain) /
./ 0
	Postulant0 9
.9 :
Security: B
.B C
	ContractsC L
.L M
ITokenUserServiceM ^
tokenUserService_ o
;o p
private 
readonly 
AppSettings $
appSettings% 0
;0 1
private 
readonly 
ITokenGenerator (
tokenGenerator) 7
;7 8
public 
LoginService 
( 
HumanManagement +
.+ ,
Domain, 2
.2 3
	Postulant3 <
.< =
Security= E
.E F
	ContractsF O
.O P
IUserRepositoryP _
userRepository` n
,n o
ICryptography, 9
cryptography: F
,F G
HumanManagement, ;
.; <
Domain< B
.B C
	PostulantC L
.L M
SecurityM U
.U V
	ContractsV _
._ `"
IProfileUserRepository` v"
profileUserRepository	w å
,
å ç
HumanManagement  , ;
.  ; <
Domain  < B
.  B C
	Postulant  C L
.  L M
Security  M U
.  U V
	Contracts  V _
.  _ `
ITokenUserService  ` q
tokenUserService	  r Ç
,
  Ç É
IOptions!!, 4
<!!4 5
AppSettings!!5 @
>!!@ A
appSettings!!B M
,!!M N
ITokenGenerator"", ;
tokenGenerator""< J
)""J K
{## 	
this$$ 
.$$ 
userRepository$$ 
=$$  !
userRepository$$" 0
;$$0 1
this%% 
.%% 
cryptography%% 
=%% 
cryptography%%  ,
;%%, -
this&& 
.&& !
profileUserRepository&& &
=&&' (!
profileUserRepository&&) >
;&&> ?
this(( 
.(( 
appSettings(( 
=(( 
appSettings(( *
.((* +
Value((+ 0
;((0 1
this)) 
.)) 
tokenGenerator)) 
=))  !
tokenGenerator))" 0
;))0 1
this** 
.** 
tokenUserService** !
=**" #
tokenUserService**$ 4
;**4 5
}++ 	
public,, 
async,, 
Task,, 
<,, 
Result,,  
>,,  !
GetLoginUserQuery,," 3
(,,3 4
LoginDto,,4 <
loginDto,,= E
),,E F
{-- 	
loginDto.. 
... 
SetPassword..  
(..  !
cryptography..! -
)..- .
;... /
var// 

userLogged// 
=// 
await// "
userRepository//# 1
.//1 2
Authenticate//2 >
(//> ?
loginDto//? G
)//G H
;//H I
if00 
(00 

userLogged00 
==00 
null00 "
)00" #
{11 
throw22 
new22 
ValidationException22 -
(22- .
$str22. K
)22K L
;22L M
}33 
if55 
(55 

userLogged55 
.55 
ActiveAccount55 (
==55) +
false55, 1
)551 2
{66 
throw77 
new77 
ValidationException77 -
(77- .
$str77. R
)77R S
;77S T
}88 

userLogged99 
.99 
Img99 
=99 
	GetAvatar99 &
(99& '

userLogged99' 1
.991 2
Img992 5
)995 6
;996 7
int:: 
	idprofile:: 
=:: 
await:: !!
profileUserRepository::" 7
.::7 8
GetProfileByUser::8 H
(::H I

userLogged::I S
.::S T
Id::T V
)::V W
;::W X

userLogged<< 
.<< 
SetPhotoUserDefault<< *
(<<* +
appSettings<<+ 6
.<<6 7"
URL_PHOTO_USER_DEFAULT<<7 M
)<<M N
;<<N O

userLogged== 
.== "
SetPhotoCompanyDefault== -
(==- .
appSettings==. 9
.==9 :%
URL_PHOTO_COMPANY_DEFAULT==: S
)==S T
;==T U
ProfileGenerator>> 
profileGenerator>> -
=>>. /
new>>0 3
ProfileGenerator>>4 D
(>>D E

userLogged>>E O
,>>O P
null>>Q U
)>>U V
;>>V W
var@@ 
profileUser@@ 
=@@ 
profileGenerator@@ .
.@@. /
GetUserProfile@@/ =
(@@= >
tokenGenerator@@> L
)@@L M
;@@M N
TokenUserPostulantAA 
	tokenUserAA (
=AA) *
newAA+ .
TokenUserPostulantAA/ A
{BB 
IdUserCC 
=CC 

userLoggedCC #
.CC# $
IdCC$ &
,CC& '
TokenDD 
=DD 
profileUserDD #
.DD# $
TokenDD$ )
,DD) *
	TokenLifeEE 
=EE 
profileUserEE '
.EE' (
	TokenLifeEE( 1
,EE1 2
ActiveFF 
=FF 
trueFF 
,FF 
DateRegisterGG 
=GG 
DateTimeGG '
.GG' (
NowGG( +
,GG+ ,

DateUpdateHH 
=HH 
DateTimeHH %
.HH% &
NowHH& )
}II 
;II 
awaitJJ 
tokenUserServiceJJ "
.JJ" #
AddOrUpdateJJ# .
(JJ. /
	tokenUserJJ/ 8
)JJ8 9
;JJ9 :
returnKK 
newKK 
ResultKK 
{LL 
	StateCodeMM 
=MM 
$numMM 
,MM  
DataNN 
=NN 
profileUserNN "
}OO 
;OO 
}PP 	
publicSS 
stringSS 
	GetAvatarSS 
(SS  
stringSS  &
urlSS' *
)SS* +
{TT 	
stringUU 
imgUU 
=UU 
$strUU 
;UU 
ifVV 
(VV 
urlVV 
!=VV 
nullVV 
)VV 
{WW 
varXX 
fileXX 
=XX 
urlXX 
;XX 
ifYY 
(YY 
FileYY 
.YY 
ExistsYY 
(YY  
fileYY  $
)YY$ %
)YY% &
{ZZ 
var[[ 
buffer[[ 
=[[  
File[[! %
.[[% &
ReadAllBytes[[& 2
([[2 3
file[[3 7
)[[7 8
;[[8 9
img\\ 
=\\ 
$"\\ 
$str\\ 3
{\\3 4
Convert\\4 ;
.\\; <
ToBase64String\\< J
(\\J K
buffer\\K Q
)\\Q R
}\\R S
"\\S T
;\\T U
}]] 
}^^ 
return`` 
img`` 
;`` 
}aa 	
}bb 
}cc •
lD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Security\Services\TokenService.cs
	namespace		 	
SitePostulant		
 
.		 
Application		 #
.		# $
Security		$ ,
.		, -
Services		- 5
{

 
public 

class 
TokenService 
: 
ITokenService  -
{ 
private 
readonly  
ITokenUserRepository -
tokenRepository. =
;= >
public 
TokenService 
(  
ITokenUserRepository 0
tokenRepository1 @
)@ A
{ 	
this 
. 
tokenRepository  
=! "
tokenRepository# 2
;2 3
} 	
public 
async 
Task 
< 
UserSessionDto (
>( )
GetUserByToken* 8
(8 9
string9 ?
token@ E
)E F
{ 	
return 
await 
tokenRepository (
.( )
GetUserByToken) 7
(7 8
token8 =
)= >
;> ?
} 	
public 
async 
Task 
< 
bool 
> 
IsValidToken  ,
(, -
TokenUserQueryDto- >
tokenUserQueryDto? P
)P Q
{ 	
return 
await 
tokenRepository (
.( )
IsValidToken) 5
(5 6
tokenUserQueryDto6 G
)G H
;H I
} 	
} 
} ç∂
kD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Security\Services\UserService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Security$ ,
., -
Services- 5
{ 
public 

class 
UserService 
: 
IUserService +
{ 
private   
readonly   
IUserRepository   (
_userRepository  ) 8
;  8 9
private!! 
readonly!! 
IPersonRepository!! *
_personRepository!!+ <
;!!< =
private"" 
readonly"" 
IBaseRepository"" (
<""( )
UserPostulant"") 6
>""6 7
baseUserRepository""8 J
;""J K
private## 
readonly## 
IBaseRepository## (
<##( ) 
ProfileUserPostulant##) =
>##= >%
baseProfileUserRepository##? X
;##X Y
private$$ 
readonly$$ 
IBaseRepository$$ (
<$$( ) 
PersonModelPostulant$$) =
>$$= >
personRepository$$? O
;$$O P
private%% 
readonly%% 
IMapper%%  
mapper%%! '
;%%' (
private&& 
readonly&& 
IUnitOfWork&& $

unitOfWork&&% /
;&&/ 0
private'' 
readonly'' 
ICryptography'' &
cryptography''' 3
;''3 4
private(( 
readonly(( 
AppSettings(( $
_appSettings((% 1
;((1 2
private)) 
readonly)) 
IMailRepository)) (
_mailRepository))) 8
;))8 9
private** 
readonly** 
IHtmlReader** $

htmlReader**% /
;**/ 0
public++ 
UserService++ 
(++ 
IBaseRepository++ *
<++* +
UserPostulant+++ 8
>++8 9
baseUserRepository++: L
,++L M
IBaseRepository,,( 7
<,,7 8 
PersonModelPostulant,,8 L
>,,L M
personRepository,,N ^
,,,^ _
IBaseRepository--( 7
<--7 8 
ProfileUserPostulant--8 L
>--L M%
baseProfileUserRepository--N g
,--g h
IMapper..( /
mapper..0 6
,..6 7
IUnitOfWork//( 3

unitOfWork//4 >
,//> ?
ICryptography00( 5
cryptography006 B
,00B C
IUserRepository11( 7
_userRepository118 G
,11G H
IPersonRepository22( 9
_personRepository22: K
,22K L
IOptions33( 0
<330 1
AppSettings331 <
>33< =
appSettings33> I
,33I J
IMailRepository44( 7
_mailRepository448 G
,44G H
IHtmlReader55( 3

htmlReader554 >
)55> ?
{66 	
this77 
.77 
baseUserRepository77 #
=77$ %
baseUserRepository77& 8
;778 9
this88 
.88 
mapper88 
=88 
mapper88  
;88  !
this99 
.99 

unitOfWork99 
=99 

unitOfWork99 (
;99( )
this:: 
.:: 
cryptography:: 
=:: 
cryptography::  ,
;::, -
this;; 
.;; 
personRepository;; !
=;;" #
personRepository;;$ 4
;;;4 5
this<< 
.<< %
baseProfileUserRepository<< *
=<<+ ,%
baseProfileUserRepository<<- F
;<<F G
this== 
.== 
_userRepository==  
===! "
_userRepository==# 2
;==2 3
this>> 
.>> 
_personRepository>> "
=>># $
_personRepository>>% 6
;>>6 7
this?? 
.?? 
_appSettings?? 
=?? 
appSettings??  +
.??+ ,
Value??, 1
;??1 2
this@@ 
.@@ 
_mailRepository@@  
=@@! "
_mailRepository@@# 2
;@@2 3
thisAA 
.AA 

htmlReaderAA 
=AA 

htmlReaderAA (
;AA( )
}BB 	
publicDD 
asyncDD 
TaskDD 
<DD 
ResultDD  
>DD  !
ActiveAccountDD" /
(DD/ 0
intDD0 3
idDD4 6
)DD6 7
{EE 	
varFF 
resultFF 
=FF 
awaitFF 
_userRepositoryFF .
.FF. /
ActiveAccountFF/ <
(FF< =
idFF= ?
)FF? @
;FF@ A
returnGG 
newGG 
ResultGG 
{HH 
	StateCodeII 
=II 
	ConstantsII %
.II% &
StateCodeResultII& 5
.II5 6
STATE_CODE_OKII6 C
}JJ 
;JJ 
}KK 	
publicMM 
asyncMM 
TaskMM 
<MM 
ResultMM  
>MM  !
ChangePasswordMM" 0
(MM0 1
ResetPasswordDtoMM1 A
resetPasswordDtoMMB R
)MMR S
{NN 	
ResultOO 
resultOO 
=OO 
newOO 
ResultOO  &
(OO& '
)OO' (
;OO( )
resetPasswordDtoPP 
.PP 
SetPasswordPP (
(PP( )
cryptographyPP) 5
)PP5 6
;PP6 7
varQQ 
userQQ 
=QQ 
mapperQQ 
.QQ 
MapQQ !
<QQ! "
UserPostulantQQ" /
>QQ/ 0
(QQ0 1
resetPasswordDtoQQ1 A
)QQA B
;QQB C
varTT 
	usermodelTT 
=TT 
awaitTT !
baseUserRepositoryTT" 4
.TT4 5
FindTT5 9
(TT9 :
resetPasswordDtoTT: J
.TTJ K
IdTTK M
)TTM N
;TTN O
	usermodelUU 
.UU 
PasswordUU 
=UU  
resetPasswordDtoUU! 1
.UU1 2
PasswordUU2 :
;UU: ;
	usermodelVV 
.VV 

DateUpdateVV  
=VV! "
DateTimeVV# +
.VV+ ,
NowVV, /
;VV/ 0
	usermodelWW 
.WW 
ChangedPasswordWW %
=WW& '
trueWW( ,
;WW, -
awaitZZ 
baseUserRepositoryZZ $
.ZZ$ %
UpdatePartialZZ% 2
(ZZ2 3
	usermodelZZ3 <
,ZZ< =
xZZ> ?
=>ZZ@ B
xZZC D
.ZZD E
PasswordZZE M
,ZZM N
x[[6 7
=>[[8 :
x[[; <
.[[< =

DateUpdate[[= G
,[[G H
x\\6 7
=>\\8 :
x\\; <
.\\< =
ChangedPassword\\= L
)]]6 7
;]]7 8
await__ 

unitOfWork__ 
.__ 
Commit__ #
(__# $
)__$ %
;__% &
resultaa 
.aa 
	StateCodeaa 
=aa 
	Constantsaa (
.aa( )
StateCodeResultaa) 8
.aa8 9
STATE_CODE_OKaa9 F
;aaF G
resultbb 
.bb 
MessageErrorbb 
=bb  !
newbb" %
Listbb& *
<bb* +
stringbb+ 1
>bb1 2
(bb2 3
)bb3 4
{bb4 5
$strcc A
}dd 
;dd 
returnff 
resultff 
;ff 
}gg 	
publicii 
asyncii 
Taskii 
<ii 
Resultii  
>ii  !'
ChangePasswordConfigurationii" =
(ii= >
ChangePasswordDtoii> O
dtoiiP S
)iiS T
{jj 	
dtokk 
.kk 
SetPasswordkk 
(kk 
cryptographykk (
)kk( )
;kk) *
varll 
existll 
=ll 
awaitll 
baseUserRepositoryll 0
.ll0 1
Existll1 6
(ll6 7
xll7 8
=>ll9 ;
xll< =
.ll= >
Passwordll> F
==llG I
dtollJ M
.llM N
PasswordActualllN \
)ll\ ]
;ll] ^
ifmm 
(mm 
!mm 
existmm 
)mm 
{nn 
throwoo 
newoo 
ValidationExceptionoo -
(oo- .
$stroo. f
)oof g
;oog h
}pp 
varrr 
resrr 
=rr 
awaitrr 
_userRepositoryrr +
.rr+ ,
ChangePasswordrr, :
(rr: ;
dtorr; >
)rr> ?
;rr? @
returnss 
newss 
Resultss 
{tt 
Datauu 
=uu 
resuu 
,uu 
	StateCodevv 
=vv 
	Constantsvv %
.vv% &
StateCodeResultvv& 5
.vv5 6
STATE_CODE_OKvv6 C
}ww 
;ww 
}xx 	
publiczz 
asynczz 
Taskzz 
<zz 
Resultzz  
>zz  !

CreateUserzz" ,
(zz, -
UserDtozz- 4
userDtozz5 <
)zz< =
{{{ 	
var|| 
exist|| 
=|| 
await|| 
personRepository|| .
.||. /
Exist||/ 4
(||4 5
x||5 6
=>||7 9
x||: ;
.||; <
Email||< A
==||B D
userDto||E L
.||L M
Email||M R
)||R S
;||S T
if}} 
(}} 
exist}} 
==}} 
true}} 
)}} 
throw~~ 
new~~ 
ValidationException~~ -
(~~- .
$str~~. X
)~~X Y
;~~Y Z
userDto 
. 
SetEncryptPassword &
(& '
cryptography' 3
)3 4
;4 5
var
ÄÄ 
user
ÄÄ 
=
ÄÄ 
mapper
ÄÄ 
.
ÄÄ 
Map
ÄÄ !
<
ÄÄ! "
UserPostulant
ÄÄ" /
>
ÄÄ/ 0
(
ÄÄ0 1
userDto
ÄÄ1 8
)
ÄÄ8 9
;
ÄÄ9 :
var
ÅÅ 
person
ÅÅ 
=
ÅÅ 
mapper
ÅÅ 
.
ÅÅ  
Map
ÅÅ  #
<
ÅÅ# $"
PersonModelPostulant
ÅÅ$ 8
>
ÅÅ8 9
(
ÅÅ9 :
userDto
ÅÅ: A
)
ÅÅA B
;
ÅÅB C
person
ÇÇ 
.
ÇÇ 
DateRegister
ÇÇ 
=
ÇÇ  !
DateTime
ÇÇ" *
.
ÇÇ* +
Now
ÇÇ+ .
;
ÇÇ. /
person
ÉÉ 
.
ÉÉ 

DateUpdate
ÉÉ 
=
ÉÉ 
DateTime
ÉÉ  (
.
ÉÉ( )
Now
ÉÉ) ,
;
ÉÉ, -
person
ÑÑ 
.
ÑÑ 
DocumentNumber
ÑÑ !
=
ÑÑ" #
$str
ÑÑ$ &
;
ÑÑ& '
person
ÖÖ 
.
ÖÖ 
IdSex
ÖÖ 
=
ÖÖ 
$num
ÖÖ 
;
ÖÖ 
person
ÜÜ 
.
ÜÜ 
IdActive
ÜÜ 
=
ÜÜ 
$num
ÜÜ  
;
ÜÜ  !
await
àà 
personRepository
àà "
.
àà" #
Add
àà# &
(
àà& '
person
àà' -
)
àà- .
;
àà. /
user
ää 
.
ää 
IdPerson
ää 
=
ää 
person
ää "
.
ää" #
Id
ää# %
;
ää% &
user
ãã 
.
ãã 
UserName
ãã 
=
ãã 
person
ãã "
.
ãã" #
GetUserName
ãã# .
(
ãã. /
)
ãã/ 0
;
ãã0 1
await
åå  
baseUserRepository
åå $
.
åå$ %
Add
åå% (
(
åå( )
user
åå) -
)
åå- .
;
åå. /
var
çç 
profileUser
çç 
=
çç 
mapper
çç $
.
çç$ %
Map
çç% (
<
çç( )"
ProfileUserPostulant
çç) =
>
çç= >
(
çç> ?
userDto
çç? F
)
ççF G
;
ççG H
profileUser
éé 
.
éé 
	IdProfile
éé !
=
éé" #
$num
éé$ %
;
éé% &
profileUser
èè 
.
èè 
IdUser
èè 
=
èè  
user
èè! %
.
èè% &
Id
èè& (
;
èè( )
await
êê '
baseProfileUserRepository
êê +
.
êê+ ,
Add
êê, /
(
êê/ 0
profileUser
êê0 ;
)
êê; <
;
êê< =
await
ëë 

unitOfWork
ëë 
.
ëë 
Commit
ëë #
(
ëë# $
)
ëë$ %
;
ëë% &
UserMailDto
ìì 
userMailDto
ìì #
=
ìì$ %
new
ìì& )
UserMailDto
ìì* 5
{
îî 
Id
ïï 
=
ïï 
user
ïï 
.
ïï 
Id
ïï 
,
ïï 
UserName
ññ 
=
ññ 
user
ññ 
.
ññ  
UserName
ññ  (
,
ññ( )
Password
óó 
=
óó 
userDto
óó "
.
óó" #'
PasswordWithoutEncryption
óó# <
,
óó< =
FullName
òò 
=
òò 
$"
òò 
{
òò 
person
òò $
.
òò$ %
	FirstName
òò% .
}
òò. /
$str
òò/ 0
{
òò0 1
person
òò1 7
.
òò7 8

SecondName
òò8 B
}
òòB C
$str
òòC D
{
òòD E
person
òòE K
.
òòK L
LastName
òòL T
}
òòT U
$str
òòU V
{
òòV W
person
òòW ]
.
òò] ^
MotherLastName
òò^ l
}
òòl m
"
òòm n
,
òòn o
Email
ôô 
=
ôô 
person
ôô 
.
ôô 
Email
ôô $
}
öö 
;
öö 
var
õõ 
userRegistered
õõ 
=
õõ  
new
õõ! $
UserRegistered
õõ% 3
(
õõ3 4
userMailDto
õõ4 ?
)
õõ? @
;
õõ@ A
MailSenderUser
ùù 
mailSenderUser
ùù )
=
ùù* +
new
ùù, /
MailSenderUser
ùù0 >
(
ùù> ?

htmlReader
ùù? I
,
ùùI J
userRegistered
ùùK Y
.
ùùY Z
UserMail
ùùZ b
,
ùùb c
_appSettings
ùùd p
.
ùùp q*
ActivateAccountTemplateHtmlùùq å
,ùùå ç
_appSettingsùùé ö
.ùùö õ
HomeUrlùùõ ¢
)ùù¢ £
;ùù£ §
await
ûû 
_mailRepository
ûû !
.
ûû! "
SendMail
ûû" *
(
ûû* +
mailSenderUser
ûû+ 9
.
ûû9 :
GetMail
ûû: A
(
ûûA B
)
ûûB C
)
ûûC D
;
ûûD E
userDto
üü 
.
üü 
Id
üü 
=
üü 
user
üü 
.
üü 
Id
üü  
;
üü  !
userDto
†† 
.
†† 
IdPerson
†† 
=
†† 
person
†† %
.
††% &
Id
††& (
;
††( )
return
°° 
new
°° 
Result
°° 
{
¢¢ 
Data
££ 
=
££ 
userDto
££ 
,
££ 
	StateCode
§§ 
=
§§ 
	Constants
§§ %
.
§§% &
StateCodeResult
§§& 5
.
§§5 6
STATE_CODE_OK
§§6 C
}
•• 
;
•• 
}
¶¶ 	
public
®® 
async
®® 
Task
®® 
<
®® 
Result
®®  
>
®®  !

DeleteUser
®®" ,
(
®®, -
DeleteUserDto
®®- :
dto
®®; >
)
®®> ?
{
©© 	
dto
™™ 
.
™™ 
SetPassword
™™ 
(
™™ 
cryptography
™™ (
)
™™( )
;
™™) *
var
´´ 
exist
´´ 
=
´´ 
await
´´  
baseUserRepository
´´ 0
.
´´0 1
Exist
´´1 6
(
´´6 7
x
´´7 8
=>
´´9 ;
x
´´< =
.
´´= >
Password
´´> F
==
´´G I
dto
´´J M
.
´´M N
PasswordActual
´´N \
)
´´\ ]
;
´´] ^
if
¨¨ 
(
¨¨ 
!
¨¨ 
exist
¨¨ 
)
¨¨ 
{
≠≠ 
throw
ÆÆ 
new
ÆÆ !
ValidationException
ÆÆ -
(
ÆÆ- .
$str
ÆÆ. f
)
ÆÆf g
;
ÆÆg h
}
ØØ 
var
±± 
res
±± 
=
±± 
await
±± 
_userRepository
±± +
.
±±+ ,

DeleteUser
±±, 6
(
±±6 7
dto
±±7 :
)
±±: ;
;
±±; <
return
≤≤ 
new
≤≤ 
Result
≤≤ 
{
≥≥ 
Data
¥¥ 
=
¥¥ 
res
¥¥ 
,
¥¥ 
	StateCode
µµ 
=
µµ 
	Constants
µµ %
.
µµ% &
StateCodeResult
µµ& 5
.
µµ5 6
STATE_CODE_OK
µµ6 C
}
∂∂ 
;
∂∂ 
}
∑∑ 	
public
ππ 
async
ππ 
Task
ππ 
<
ππ 
Result
ππ  
>
ππ  !
ForgotPassword
ππ" 0
(
ππ0 1
ForgotPasswordDto
ππ1 B
forgotPasswordDto
ππC T
)
ππT U
{
∫∫ 	
Result
ªª 
result
ªª 
=
ªª 
new
ªª 
Result
ªª  &
(
ªª& '
)
ªª' (
;
ªª( )
var
ææ 
validateuser
ææ 
=
ææ 
await
ææ $
_userRepository
ææ% 4
.
ææ4 5

GetByEmail
ææ5 ?
(
ææ? @
forgotPasswordDto
ææ@ Q
.
ææQ R
Email
ææR W
)
ææW X
;
ææX Y
if
¿¿ 
(
¿¿ 
validateuser
¿¿ 
==
¿¿ 
null
¿¿  $
)
¿¿$ %
{
¡¡ 
result
¬¬ 
.
¬¬ 
	StateCode
¬¬  
=
¬¬! "
	Constants
¬¬# ,
.
¬¬, -
StateCodeResult
¬¬- <
.
¬¬< =
ERROR_EXCEPTION
¬¬= L
;
¬¬L M
result
√√ 
.
√√ 
MessageError
√√ #
=
√√$ %
new
√√& )
List
√√* .
<
√√. /
string
√√/ 5
>
√√5 6
(
√√6 7
)
√√7 8
{
√√8 9
$str
ƒƒ F
}
≈≈ 
;
≈≈ 
return
∆∆ 
result
∆∆ 
;
∆∆ 
}
«« 
forgotPasswordDto
»» 
.
»» 
Id
»»  
=
»»! "
validateuser
»»# /
.
»»/ 0
Id
»»0 2
;
»»2 3
var
ÀÀ 
	usermodel
ÀÀ 
=
ÀÀ 
await
ÀÀ ! 
baseUserRepository
ÀÀ" 4
.
ÀÀ4 5
Find
ÀÀ5 9
(
ÀÀ9 :
forgotPasswordDto
ÀÀ: K
.
ÀÀK L
Id
ÀÀL N
)
ÀÀN O
;
ÀÀO P
if
ÃÃ 
(
ÃÃ 
	usermodel
ÃÃ 
==
ÃÃ 
null
ÃÃ !
)
ÃÃ! "
{
ÕÕ 
result
ŒŒ 
.
ŒŒ 
	StateCode
ŒŒ  
=
ŒŒ! "
	Constants
ŒŒ# ,
.
ŒŒ, -
StateCodeResult
ŒŒ- <
.
ŒŒ< =
ERROR_EXCEPTION
ŒŒ= L
;
ŒŒL M
result
œœ 
.
œœ 
MessageError
œœ #
=
œœ$ %
new
œœ& )
List
œœ* .
<
œœ. /
string
œœ/ 5
>
œœ5 6
(
œœ6 7
)
œœ7 8
{
œœ8 9
$str
–– *
}
—— 
;
—— 
return
““ 
result
““ 
;
““ 
}
”” 
var
÷÷ 
personmodel
÷÷ 
=
÷÷ 
await
÷÷ #
_personRepository
÷÷$ 5
.
÷÷5 6
	GetPerson
÷÷6 ?
(
÷÷? @
	usermodel
÷÷@ I
.
÷÷I J
IdPerson
÷÷J R
)
÷÷R S
;
÷÷S T
if
ÿÿ 
(
ÿÿ 
personmodel
ÿÿ 
==
ÿÿ 
null
ÿÿ #
)
ÿÿ# $
{
ŸŸ 
result
⁄⁄ 
.
⁄⁄ 
	StateCode
⁄⁄  
=
⁄⁄! "
	Constants
⁄⁄# ,
.
⁄⁄, -
StateCodeResult
⁄⁄- <
.
⁄⁄< =
ERROR_EXCEPTION
⁄⁄= L
;
⁄⁄L M
result
€€ 
.
€€ 
MessageError
€€ #
=
€€$ %
new
€€& )
List
€€* .
<
€€. /
string
€€/ 5
>
€€5 6
(
€€6 7
)
€€7 8
{
€€8 9
$str
‹‹ *
}
›› 
;
›› 
return
ﬁﬁ 
result
ﬁﬁ 
;
ﬁﬁ 
}
ﬂﬂ 
Byte
‰‰ 
[
‰‰ 
]
‰‰ 
bytes
‰‰ 
;
‰‰ 
String
ÂÂ 
bytesBase64Url
ÂÂ !
;
ÂÂ! "
using
ÈÈ 
(
ÈÈ #
RandomNumberGenerator
ÈÈ (
rng
ÈÈ) ,
=
ÈÈ- .#
RandomNumberGenerator
ÈÈ/ D
.
ÈÈD E
Create
ÈÈE K
(
ÈÈK L
)
ÈÈL M
)
ÈÈM N
{
ÍÍ 
bytes
ÏÏ 
=
ÏÏ 
new
ÏÏ 
Byte
ÏÏ  
[
ÏÏ  !
$num
ÏÏ! #
]
ÏÏ# $
;
ÏÏ$ %
rng
ÌÌ 
.
ÌÌ 
GetBytes
ÌÌ 
(
ÌÌ 
bytes
ÌÌ "
)
ÌÌ" #
;
ÌÌ# $
bytesBase64Url
 
=
  
Convert
! (
.
( )
ToBase64String
) 7
(
7 8
bytes
8 =
)
= >
.
> ?
Replace
? F
(
F G
$char
G J
,
J K
$char
L O
)
O P
.
P Q
Replace
Q X
(
X Y
$char
Y \
,
\ ]
$char
^ a
)
a b
;
b c
}
ÒÒ 
	usermodel
ÛÛ 
.
ÛÛ 
PasswordResetCode
ÛÛ '
=
ÛÛ( )
bytes
ÛÛ* /
;
ÛÛ/ 0
	usermodel
ÙÙ 
.
ÙÙ  
PasswordResetStart
ÙÙ (
=
ÙÙ) *
DateTime
ÙÙ+ 3
.
ÙÙ3 4
Now
ÙÙ4 7
;
ÙÙ7 8
await
¯¯  
baseUserRepository
¯¯ $
.
¯¯$ %
UpdatePartial
¯¯% 2
(
¯¯2 3
	usermodel
¯¯3 <
,
¯¯< =
x
¯¯> ?
=>
¯¯@ B
x
¯¯C D
.
¯¯D E
PasswordResetCode
¯¯E V
,
¯¯V W
x
˘˘5 6
=>
˘˘7 9
x
˘˘: ;
.
˘˘; < 
PasswordResetStart
˘˘< N
)
˙˙5 6
;
˙˙6 7
await
˚˚ 

unitOfWork
˚˚ 
.
˚˚ 
Commit
˚˚ #
(
˚˚# $
)
˚˚$ %
;
˚˚% &
string
ÇÇ 
fmt
ÇÇ 
=
ÇÇ 
File
ÇÇ 
.
ÇÇ 
ReadAllText
ÇÇ )
(
ÇÇ) *
_appSettings
ÇÇ* 6
.
ÇÇ6 7*
PasswordRecoveryTemplateHtml
ÇÇ7 S
)
ÇÇS T
;
ÇÇT U
fmt
ÑÑ 
=
ÑÑ 
fmt
ÑÑ 
.
ÑÑ 
Replace
ÑÑ 
(
ÑÑ 
$str
ÑÑ -
,
ÑÑ- .
_appSettings
ÑÑ/ ;
.
ÑÑ; <!
PasswordRecoveryUrl
ÑÑ< O
+
ÑÑP Q
$str
ÑÑR Z
+
ÑÑ[ \
	usermodel
ÑÑ] f
.
ÑÑf g
Id
ÑÑg i
+
ÑÑj k
$strÑÑl Ç
+ÑÑÉ Ñ
bytesBase64UrlÑÑÖ ì
)ÑÑì î
;ÑÑî ï
MailRequestDto
ÜÜ 
reqMail
ÜÜ "
=
ÜÜ# $
new
ÜÜ% (
MailRequestDto
ÜÜ) 7
(
ÜÜ7 8
)
ÜÜ8 9
;
ÜÜ9 :
bool
ää 
respuestamail
ää 
=
ää  
await
ää! &"
SendMailPasswordCode
ää' ;
(
ää; <
personmodel
ää< G
.
ääG H
Email
ääH M
,
ääM N
fmt
ääO R
)
ääR S
;
ääS T
if
åå 
(
åå 
!
åå 
respuestamail
åå 
)
åå 
{
çç 
result
éé 
.
éé 
	StateCode
éé  
=
éé! "
	Constants
éé# ,
.
éé, -
StateCodeResult
éé- <
.
éé< =
ERROR_EXCEPTION
éé= L
;
ééL M
result
èè 
.
èè 
MessageError
èè #
=
èè$ %
new
èè& )
List
èè* .
<
èè. /
string
èè/ 5
>
èè5 6
(
èè6 7
)
èè7 8
{
èè8 9
$str
êê ;
}
ëë 
;
ëë 
return
íí 
result
íí 
;
íí 
}
ìì 
result
ññ 
.
ññ 
	StateCode
ññ 
=
ññ 
	Constants
ññ (
.
ññ( )
StateCodeResult
ññ) 8
.
ññ8 9
STATE_CODE_OK
ññ9 F
;
ññF G
result
óó 
.
óó 
MessageError
óó 
=
óó  !
new
óó" %
List
óó& *
<
óó* +
string
óó+ 1
>
óó1 2
(
óó2 3
)
óó3 4
{
óó4 5
$str
òò ?
}
ôô 
;
ôô 
return
õõ 
result
õõ 
;
õõ 
}
úú 	
public
ûû 
async
ûû 
Task
ûû 
<
ûû 
Result
ûû  
>
ûû  ! 
SendMailActivation
ûû" 4
(
ûû4 5
string
ûû5 ;
email
ûû< A
)
ûûA B
{
üü 	
var
°° 
person
°° 
=
°° 
await
°° 
personRepository
°° /
.
°°/ 0
FindPredicate
°°0 =
(
°°= >
x
°°> ?
=>
°°@ B
x
°°C D
.
°°D E
Email
°°E J
==
°°K M
email
°°N S
)
°°S T
;
°°T U
var
¢¢ 
user
¢¢ 
=
¢¢ 
await
¢¢  
baseUserRepository
¢¢ /
.
¢¢/ 0
FindPredicate
¢¢0 =
(
¢¢= >
x
¢¢> ?
=>
¢¢@ B
x
¢¢C D
.
¢¢D E
IdPerson
¢¢E M
==
¢¢N P
person
¢¢Q W
.
¢¢W X
Id
¢¢X Z
)
¢¢Z [
;
¢¢[ \
UserMailDto
§§ 
userMailDto
§§ #
=
§§$ %
new
§§& )
UserMailDto
§§* 5
{
•• 
Id
¶¶ 
=
¶¶ 
user
¶¶ 
.
¶¶ 
Id
¶¶ 
,
¶¶ 
UserName
ßß 
=
ßß 
user
ßß 
.
ßß  
UserName
ßß  (
,
ßß( )
Password
®® 
=
®® 
null
®® 
,
®®  
FullName
©© 
=
©© 
$"
©© 
{
©© 
person
©© $
.
©©$ %
	FirstName
©©% .
}
©©. /
$str
©©/ 0
{
©©0 1
person
©©1 7
.
©©7 8

SecondName
©©8 B
}
©©B C
$str
©©C D
{
©©D E
person
©©E K
.
©©K L
LastName
©©L T
}
©©T U
$str
©©U V
{
©©V W
person
©©W ]
.
©©] ^
MotherLastName
©©^ l
}
©©l m
"
©©m n
,
©©n o
Email
™™ 
=
™™ 
person
™™ 
.
™™ 
Email
™™ $
}
´´ 
;
´´ 
var
¨¨ 
userRegistered
¨¨ 
=
¨¨  
new
¨¨! $
UserRegistered
¨¨% 3
(
¨¨3 4
userMailDto
¨¨4 ?
)
¨¨? @
;
¨¨@ A
MailSenderUser
ÆÆ 
mailSenderUser
ÆÆ )
=
ÆÆ* +
new
ÆÆ, /
MailSenderUser
ÆÆ0 >
(
ÆÆ> ?

htmlReader
ÆÆ? I
,
ÆÆI J
userRegistered
ÆÆK Y
.
ÆÆY Z
UserMail
ÆÆZ b
,
ÆÆb c
_appSettings
ÆÆd p
.
ÆÆp q*
ActivateAccountTemplateHtmlÆÆq å
,ÆÆå ç
_appSettingsÆÆé ö
.ÆÆö õ
HomeUrlÆÆõ ¢
)ÆÆ¢ £
;ÆÆ£ §
bool
ØØ 
success
ØØ 
=
ØØ 
await
ØØ  
_mailRepository
ØØ! 0
.
ØØ0 1
SendMail
ØØ1 9
(
ØØ9 :
mailSenderUser
ØØ: H
.
ØØH I
GetMail
ØØI P
(
ØØP Q
)
ØØQ R
)
ØØR S
;
ØØS T
return
∞∞ 
new
∞∞ 
Result
∞∞ 
{
±± 
Data
≤≤ 
=
≤≤ 
success
≤≤ 
,
≤≤ 
	StateCode
≥≥ 
=
≥≥ 
	Constants
≥≥ %
.
≥≥% &
StateCodeResult
≥≥& 5
.
≥≥5 6
STATE_CODE_OK
≥≥6 C
}
¥¥ 
;
¥¥ 
}
∂∂ 	
public
∏∏ 
async
∏∏ 
Task
∏∏ 
<
∏∏ 
Result
∏∏  
>
∏∏  !,
SendEmailPostulantConfirmation
∏∏" @
(
∏∏@ A
string
∏∏A G
email
∏∏H M
,
∏∏M N
string
∏∏N T
job
∏∏U X
)
∏∏X Y
{
ππ 	
var
ªª 
person
ªª 
=
ªª 
await
ªª 
personRepository
ªª /
.
ªª/ 0
FindPredicate
ªª0 =
(
ªª= >
x
ªª> ?
=>
ªª@ B
x
ªªC D
.
ªªD E
Email
ªªE J
==
ªªK M
email
ªªN S
)
ªªS T
;
ªªT U
var
ºº 
user
ºº 
=
ºº 
await
ºº  
baseUserRepository
ºº /
.
ºº/ 0
FindPredicate
ºº0 =
(
ºº= >
x
ºº> ?
=>
ºº@ B
x
ººC D
.
ººD E
IdPerson
ººE M
==
ººN P
person
ººQ W
.
ººW X
Id
ººX Z
)
ººZ [
;
ºº[ \
UserMailDto
ææ 
userMailDto
ææ #
=
ææ$ %
new
ææ& )
UserMailDto
ææ* 5
{
øø 
Id
¿¿ 
=
¿¿ 
user
¿¿ 
.
¿¿ 
Id
¿¿ 
,
¿¿ 
UserName
¡¡ 
=
¡¡ 
user
¡¡ 
.
¡¡  
UserName
¡¡  (
,
¡¡( )
Password
¬¬ 
=
¬¬ 
null
¬¬ 
,
¬¬  
FullName
√√ 
=
√√ 
$"
√√ 
{
√√ 
person
√√ $
.
√√$ %
	FirstName
√√% .
}
√√. /
$str
√√/ 0
{
√√0 1
person
√√1 7
.
√√7 8

SecondName
√√8 B
}
√√B C
$str
√√C D
{
√√D E
person
√√E K
.
√√K L
LastName
√√L T
}
√√T U
$str
√√U V
{
√√V W
person
√√W ]
.
√√] ^
MotherLastName
√√^ l
}
√√l m
"
√√m n
,
√√n o
Email
ƒƒ 
=
ƒƒ 
person
ƒƒ 
.
ƒƒ 
Email
ƒƒ $
}
≈≈ 
;
≈≈ 
var
∆∆ 
userRegistered
∆∆ 
=
∆∆  
new
∆∆! $
UserRegistered
∆∆% 3
(
∆∆3 4
userMailDto
∆∆4 ?
)
∆∆? @
;
∆∆@ A
MailSenderUser
…… 
mailSenderUser
…… )
=
……* +
new
……, /
MailSenderUser
……0 >
(
……> ?

htmlReader
……? I
,
……I J
userRegistered
……K Y
.
……Y Z
UserMail
……Z b
,
……b c
_appSettings
……d p
.
……p q$
ConfirmationPostulant……q Ü
,……Ü á
_appSettings……à î
.……î ï
HomeUrl……ï ú
)……ú ù
;……ù û
bool
   
success
   
=
   
await
    
_mailRepository
  ! 0
.
  0 1
SendMail
  1 9
(
  9 :
mailSenderUser
  : H
.
  H I*
GetMailPostulantConfirmation
  I e
(
  e f
job
  f i
)
  i j
)
  j k
;
  k l
return
ÀÀ 
new
ÀÀ 
Result
ÀÀ 
{
ÃÃ 
Data
ÕÕ 
=
ÕÕ 
success
ÕÕ 
,
ÕÕ 
	StateCode
ŒŒ 
=
ŒŒ 
	Constants
ŒŒ %
.
ŒŒ% &
StateCodeResult
ŒŒ& 5
.
ŒŒ5 6
STATE_CODE_OK
ŒŒ6 C
}
œœ 
;
œœ 
}
—— 	
public
‘‘ 
async
‘‘ 
Task
‘‘ 
<
‘‘ 
Result
‘‘  
>
‘‘  !$
ValidResetPasswordCode
‘‘" 8
(
‘‘8 9
int
‘‘9 <
IdUser
‘‘= C
,
‘‘C D
byte
‘‘E I
[
‘‘I J
]
‘‘J K
providedCode
‘‘L X
)
‘‘X Y
{
’’ 	
Result
÷÷ 
result
÷÷ 
=
÷÷ 
new
÷÷ 
Result
÷÷  &
(
÷÷& '
)
÷÷' (
;
÷÷( )
TimeSpan
◊◊ "
_passwordResetExpiry
◊◊ )
=
◊◊* +
TimeSpan
◊◊, 4
.
◊◊4 5
FromMinutes
◊◊5 @
(
◊◊@ A
_appSettings
◊◊A M
.
◊◊M N!
PasswordResetExpiry
◊◊N a
)
◊◊a b
;
◊◊b c
var
ÿÿ 
userDto
ÿÿ 
=
ÿÿ 
await
ÿÿ 
_userRepository
ÿÿ  /
.
ÿÿ/ 0
GetById
ÿÿ0 7
(
ÿÿ7 8
IdUser
ÿÿ8 >
)
ÿÿ> ?
;
ÿÿ? @
if
€€ 
(
€€ 
userDto
€€ 
==
€€ 
null
€€ 
)
€€  
{
‹‹ 
result
›› 
.
›› 
	StateCode
››  
=
››! "
	Constants
››# ,
.
››, -
StateCodeResult
››- <
.
››< =
ERROR_EXCEPTION
››= L
;
››L M
result
ﬁﬁ 
.
ﬁﬁ 
MessageError
ﬁﬁ #
=
ﬁﬁ$ %
new
ﬁﬁ& )
List
ﬁﬁ* .
<
ﬁﬁ. /
string
ﬁﬁ/ 5
>
ﬁﬁ5 6
(
ﬁﬁ6 7
)
ﬁﬁ7 8
{
ﬁﬁ8 9
$str
ﬂﬂ *
}
ﬂﬂ* +
;
ﬂﬂ+ ,
return
‡‡ 
result
‡‡ 
;
‡‡ 
}
·· 
if
„„ 
(
„„ 
userDto
„„ 
.
„„  
PasswordResetStart
„„ *
==
„„+ -
null
„„. 2
||
„„3 5
userDto
„„6 =
.
„„= >
PasswordResetCode
„„> O
==
„„P R
null
„„S W
)
„„W X
{
‰‰ 
result
ÂÂ 
.
ÂÂ 
	StateCode
ÂÂ  
=
ÂÂ! "
	Constants
ÂÂ# ,
.
ÂÂ, -
StateCodeResult
ÂÂ- <
.
ÂÂ< =
ERROR_EXCEPTION
ÂÂ= L
;
ÂÂL M
result
ÊÊ 
.
ÊÊ 
MessageError
ÊÊ #
=
ÊÊ$ %
new
ÊÊ& )
List
ÊÊ* .
<
ÊÊ. /
string
ÊÊ/ 5
>
ÊÊ5 6
(
ÊÊ6 7
)
ÊÊ7 8
{
ÊÊ8 9
$str
ÁÁ F
}
ÁÁF G
;
ÁÁG H
return
ËË 
result
ËË 
;
ËË 
}
ÈÈ 
Byte
ÎÎ 
[
ÎÎ 
]
ÎÎ 
expectedCode
ÎÎ 
=
ÎÎ  !
userDto
ÎÎ" )
.
ÎÎ) *
PasswordResetCode
ÎÎ* ;
;
ÎÎ; <
DateTime
ÏÏ 
?
ÏÏ 
start
ÏÏ 
=
ÏÏ 
userDto
ÏÏ %
.
ÏÏ% & 
PasswordResetStart
ÏÏ& 8
;
ÏÏ8 9
if
ÓÓ 
(
ÓÓ 
!
ÓÓ 

Enumerable
ÓÓ 
.
ÓÓ 
SequenceEqual
ÓÓ )
(
ÓÓ) *
providedCode
ÓÓ* 6
,
ÓÓ6 7
expectedCode
ÓÓ8 D
)
ÓÓD E
)
ÓÓE F
{
ÔÔ 
result
 
.
 
	StateCode
  
=
! "
	Constants
# ,
.
, -
StateCodeResult
- <
.
< =
ERROR_EXCEPTION
= L
;
L M
result
ÒÒ 
.
ÒÒ 
MessageError
ÒÒ #
=
ÒÒ$ %
new
ÒÒ& )
List
ÒÒ* .
<
ÒÒ. /
string
ÒÒ/ 5
>
ÒÒ5 6
(
ÒÒ6 7
)
ÒÒ7 8
{
ÒÒ8 9
$str
ÚÚ (
}
ÚÚ( )
;
ÚÚ) *
return
ÛÛ 
result
ÛÛ 
;
ÛÛ 
}
ÙÙ 
DateTime
ıı 
dDateExpiry
ıı  
=
ıı! "
userDto
ıı# *
.
ıı* + 
PasswordResetStart
ıı+ =
.
ıı= >
Value
ıı> C
.
ııC D

AddMinutes
ııD N
(
ııN O
_appSettings
ııO [
.
ıı[ \!
PasswordResetExpiry
ıı\ o
)
ııo p
;
ııp q
if
ˆˆ 
(
ˆˆ 
DateTime
ˆˆ 
.
ˆˆ 
Now
ˆˆ 
>
ˆˆ 
dDateExpiry
ˆˆ *
)
ˆˆ* +
{
˜˜ 
result
¯¯ 
.
¯¯ 
	StateCode
¯¯  
=
¯¯! "
	Constants
¯¯# ,
.
¯¯, -
StateCodeResult
¯¯- <
.
¯¯< =
ERROR_EXCEPTION
¯¯= L
;
¯¯L M
result
˘˘ 
.
˘˘ 
MessageError
˘˘ #
=
˘˘$ %
new
˘˘& )
List
˘˘* .
<
˘˘. /
string
˘˘/ 5
>
˘˘5 6
(
˘˘6 7
)
˘˘7 8
{
˘˘8 9
$str
˙˙ ?
}
˙˙? @
;
˙˙@ A
return
˚˚ 
result
˚˚ 
;
˚˚ 
}
¸¸ 
return
ˇˇ 
new
ˇˇ 
Result
ˇˇ 
{
ÄÄ 
	StateCode
ÅÅ 
=
ÅÅ 
	Constants
ÅÅ %
.
ÅÅ% &
StateCodeResult
ÅÅ& 5
.
ÅÅ5 6
STATE_CODE_OK
ÅÅ6 C
,
ÅÅC D
Data
ÇÇ 
=
ÇÇ 
userDto
ÇÇ 
}
ÉÉ 
;
ÉÉ 
}
ÑÑ 	
private
ÜÜ 
async
ÜÜ 
Task
ÜÜ 
<
ÜÜ 
bool
ÜÜ 
>
ÜÜ  "
SendMailPasswordCode
ÜÜ! 5
(
ÜÜ5 6
string
ÜÜ6 <
mailuser
ÜÜ= E
,
ÜÜE F
string
ÜÜG M
bodyhtml
ÜÜN V
)
ÜÜV W
{
áá 	
MailRequestDto
àà 
newMailRequest
àà )
=
àà* +
new
àà, /
MailRequestDto
àà0 >
(
àà> ?
)
àà? @
;
àà@ A
newMailRequest
ââ 
.
ââ 
From
ââ 
=
ââ  !
_appSettings
ââ" .
.
ââ. /"
FromMailNotification
ââ/ C
;
ââC D
newMailRequest
ää 
.
ää 
FromName
ää #
=
ää$ %
_appSettings
ää& 2
.
ää2 3"
FromNameNotification
ää3 G
;
ääG H
newMailRequest
ãã 
.
ãã 
To
ãã 
=
ãã 
new
ãã  #
List
ãã$ (
<
ãã( )
string
ãã) /
>
ãã/ 0
(
ãã0 1
)
ãã1 2
;
ãã2 3
newMailRequest
åå 
.
åå 
To
åå 
.
åå 
Add
åå !
(
åå! "
mailuser
åå" *
)
åå* +
;
åå+ ,
newMailRequest
éé 
.
éé 
Message
éé "
=
éé# $
new
éé% (

MessageDto
éé) 3
(
éé3 4
)
éé4 5
;
éé5 6
newMailRequest
êê 
.
êê 
Message
êê "
.
êê" #
Subject
êê# *
=
êê+ ,
$str
êê- E
;
êêE F
newMailRequest
íí 
.
íí 
Message
íí "
.
íí" #
Body
íí# '
=
íí( )
new
íí* -
BodyDto
íí. 5
(
íí5 6
)
íí6 7
{
íí8 9
Format
íí: @
=
ííA B
EnumBodyMail
ííC O
.
ííO P
Html
ííP T
,
ííT U
Value
ííV [
=
íí\ ]
bodyhtml
íí^ f
}
ííg h
;
ííh i
var
îî 
bmail
îî 
=
îî 
await
îî 
_mailRepository
îî -
.
îî- .
SendMail
îî. 6
(
îî6 7
newMailRequest
îî7 E
)
îîE F
;
îîF G
return
ïï 
bmail
ïï 
;
ïï 
}
óó 	
}
òò 
}ôô Ñ
D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\SkillsPostulant\IServices\ISkillsPostulantService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
SkillsPostulant$ 3
.3 4
	IServices4 =
{		 
public

 

	interface

 #
ISkillsPostulantService

 ,
{ 
Task 
< 
Result 
> 
GetSkilssPostulant '
(' (
int( +
IdPerson, 4
)4 5
;5 6
Task 
< 
Result 
> 
Add 
( 
List 
< 
SkillsPostulantDto 0
>0 1
dto2 5
)5 6
;6 7
Task 
< 
Result 
> 
Delete 
( 
SkillsPostulantDto .
dto/ 2
)2 3
;3 4
} 
} √&
}D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\SkillsPostulant\Services\SkillsPostulantService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
SkillsPostulant$ 3
.3 4
Services4 <
{ 
public 

class "
SkillsPostulantService '
:( )#
ISkillsPostulantService* A
{ 
private 
readonly &
ISkillsPostulantRepository 3%
skillsPostulantRepository4 M
;M N
private 
readonly 
IBaseRepository (
<( ) 
SkillsPostulantModel) =
>= >
baseRepository? M
;M N
private 
readonly 
IMapper  
mapper! '
;' (
public "
SkillsPostulantService %
(% &&
ISkillsPostulantRepository& @%
skillsPostulantRepositoryA Z
,Z [
IBaseRepository% 4
<4 5 
SkillsPostulantModel5 I
>I J
baseRepositoryK Y
,Y Z
IMapper% ,
mapper- 3
)% &
{ 	
this 
. %
skillsPostulantRepository *
=+ ,%
skillsPostulantRepository- F
;F G
this 
. 
baseRepository 
=  !
baseRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
>  !
Add" %
(% &
List& *
<* +
SkillsPostulantDto+ =
>= >
dto? B
)B C
{ 	
foreach   
(   
var   
item   
in    
dto  ! $
)  $ %
{!! 
var"" 
entity"" 
="" 
mapper"" #
.""# $
Map""$ '
<""' ( 
SkillsPostulantModel""( <
>""< =
(""= >
item""> B
)""B C
;""C D
entity## 
.## 
Active## 
=## 
true##  $
;##$ %
await$$ 
baseRepository$$ $
.$$$ %
Add$$% (
($$( )
entity$$) /
)$$/ 0
;$$0 1
item%% 
.%% 
Id%% 
=%% 
entity%%  
.%%  !
Id%%! #
;%%# $
}&& 
return(( 
new(( 
Result(( 
{)) 
Data** 
=** 
dto** 
,** 
	StateCode++ 
=++ 
	Constants++ %
.++% &
StateCodeResult++& 5
.++5 6
STATE_CODE_OK++6 C
},, 
;,, 
}-- 	
public// 
async// 
Task// 
<// 
Result//  
>//  !
Delete//" (
(//( )
SkillsPostulantDto//) ;
dto//< ?
)//? @
{00 	
var11 
entity11 
=11 
mapper11 
.11  
Map11  #
<11# $ 
SkillsPostulantModel11$ 8
>118 9
(119 :
dto11: =
)11= >
;11> ?
entity22 
.22 
Active22 
=22 
false22 !
;22! "
await33 
baseRepository33  
.33  !
Update33! '
(33' (
entity33( .
)33. /
;33/ 0
dto55 
.55 
Id55 
=55 
entity55 
.55 
Id55 
;55 
return66 
new66 
Result66 
{77 
Data88 
=88 
dto88 
,88 
	StateCode99 
=99 
	Constants99 %
.99% &
StateCodeResult99& 5
.995 6
STATE_CODE_OK996 C
}:: 
;:: 
}<< 	
public>> 
async>> 
Task>> 
<>> 
Result>>  
>>>  !
GetSkilssPostulant>>" 4
(>>4 5
int>>5 8
IdPerson>>9 A
)>>A B
{?? 	
var@@ 
dto@@ 
=@@ 
await@@ %
skillsPostulantRepository@@ 5
.@@5 6 
GetSkillsByPostulant@@6 J
(@@J K
IdPerson@@K S
)@@S T
;@@T U
returnBB 
newBB 
ResultBB 
{CC 
	StateCodeDD 
=DD 
	ConstantsDD %
.DD% &
StateCodeResultDD& 5
.DD5 6
STATE_CODE_OKDD6 C
,DDC D
DataEE 
=EE 
dtoEE 
}FF 
;FF 
}GG 	
}HH 
}II —
mD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Skills\IServices\ISkillsService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Skills$ *
.* +
	IServices+ 4
{ 
public		 

	interface		 
ISkillsService		 #
{

 
Task 
< 
Result 
> "
GetSkillsByDescription +
(+ ,
string, 2
description3 >
)> ?
;? @
} 
} –
jD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Skills\Service\SkillsService.cs
	namespace

 	
SitePostulant


 
.

 
Application

 #
.

# $
Skills

$ *
.

* +
Service

+ 2
{ 
public 

class 
SkillsService 
:  
ISkillsService! /
{ 
private 
readonly 
ISkillsRepository *
skillsRepository+ ;
;; <
public 
SkillsService 
( 
ISkillsRepository .
skillsRepository/ ?
)? @
{ 	
this 
. 
skillsRepository !
=" #
skillsRepository$ 4
;4 5
} 	
public 
async 
Task 
< 
Result  
>  !"
GetSkillsByDescription" 8
(8 9
string9 ?
description@ K
)K L
{ 	
var 
dto 
= 
await 
skillsRepository ,
., -
GetSkillsSearch- <
(< =
description= H
)H I
;I J
return 
new 
Result 
{ 
	StateCode 
= 
	Constants %
.% &
StateCodeResult& 5
.5 6
STATE_CODE_OK6 C
,C D
Data 
= 
dto 
} 
; 
} 	
} 
} Í
iD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Util\IServices\IUtilService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
Util$ (
.( )
	IServices) 2
{ 
public		 

	interface		 
IUtilService		 !
{

 
Task 
< 
Result 
> 
GetDepartament #
(# $
)$ %
;% &
Task 
< 
Result 
> 
GetProvince  
(  !
int! $
id% '
)' (
;( )
Task 
< 
Result 
> 
GetDistrict  
(  !
int! $
id% '
)' (
;( )
} 
} ∂
gD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\Util\Services\UtilService.cs
	namespace

 	
SitePostulant


 
.

 
Application

 #
.

# $
Util

$ (
.

( )
Services

) 1
{ 
public 

class 
UtilService 
: 
IUtilService *
{ 
private 
readonly 
IUtilRepository (
utilRepository) 7
;7 8
public 
UtilService 
( 
IUtilRepository *
utilRepository+ 9
)9 :
{ 	
this 
. 
utilRepository 
=  !
utilRepository" 0
;0 1
} 	
public 
async 
Task 
< 
Result  
>  !
GetDepartament" 0
(0 1
)1 2
{ 	
return 
new 
Result 
{ 
	StateCode 
= 
	Constants %
.% &
StateCodeResult& 5
.5 6
STATE_CODE_OK6 C
,C D
Data 
= 
await 
utilRepository +
.+ ,
GetDepartament, :
(: ;
); <
} 
; 
} 	
public 
async 
Task 
< 
Result  
>  !
GetDistrict" -
(- .
int. 1
id2 4
)4 5
{ 	
return 
new 
Result 
{   
	StateCode!! 
=!! 
	Constants!! %
.!!% &
StateCodeResult!!& 5
.!!5 6
STATE_CODE_OK!!6 C
,!!C D
Data"" 
="" 
await"" 
utilRepository"" +
.""+ ,
GetDistrict"", 7
(""7 8
id""8 :
)"": ;
}## 
;## 
}$$ 	
public&& 
async&& 
Task&& 
<&& 
Result&&  
>&&  !
GetProvince&&" -
(&&- .
int&&. 1
id&&2 4
)&&4 5
{'' 	
return(( 
new(( 
Result(( 
{)) 
	StateCode** 
=** 
	Constants** %
.**% &
StateCodeResult**& 5
.**5 6
STATE_CODE_OK**6 C
,**C D
Data++ 
=++ 
await++ 
utilRepository++ +
.+++ ,
GetProvince++, 7
(++7 8
id++8 :
)++: ;
},, 
;,, 
}-- 	
}.. 
}// À
|D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\WorkExperience\IService\IWorkExperienceService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
WorkExperience$ 2
.2 3
IService3 ;
{		 
public

 

	interface

 "
IWorkExperienceService

 +
{ 
Task 
< 
Result 
> 
GetWorkExperience &
(& '
int' *
IdPerson+ 3
)3 4
;4 5
Task 
< 
Result 
> 
Add 
( 
WorkExperienceDto *
dto+ .
). /
;/ 0
Task 
< 
Result 
> 
Update 
( 
WorkExperienceDto -
dto. 1
)1 2
;2 3
} 
} ú+
zD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\SitePostulant.Application\WorkExperience\Service\WorkExperienceService.cs
	namespace 	
SitePostulant
 
. 
Application #
.# $
WorkExperience$ 2
.2 3
Service3 :
{ 
public 

class !
WorkExperienceService &
:' ("
IWorkExperienceService) ?
{ 
private 
readonly %
IWorkExperienceRepository 2$
workExperienceRepository3 K
;K L
private 
readonly 
IBaseRepository (
<( )
WorkExperienceModel) <
>< =
baseRepository> L
;L M
private 
readonly 
IMapper  
mapper! '
;' (
public !
WorkExperienceService $
($ %%
IWorkExperienceRepository% >$
workExperienceRepository? W
,W X
IBaseRepository% 4
<4 5
WorkExperienceModel5 H
>H I
baseRepositoryJ X
,X Y
IMapper% ,
mapper- 3
)3 4
{ 	
this 
. $
workExperienceRepository )
=* +$
workExperienceRepository, D
;D E
this 
. 
baseRepository 
=  !
baseRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
>  !
Add" %
(% &
WorkExperienceDto& 7
dto8 ;
); <
{ 	
dto   
.   
Salary   
=   
dto   
.   
Salary   #
.  # $
Replace  $ +
(  + ,
$str  , 0
,  0 1
string  2 8
.  8 9
Empty  9 >
)  > ?
;  ? @
var!! 
entity!! 
=!! 
mapper!! 
.!!  
Map!!  #
<!!# $
WorkExperienceModel!!$ 7
>!!7 8
(!!8 9
dto!!9 <
)!!< =
;!!= >
entity"" 
."" 
Salary"" 
="" 
Convert"" #
.""# $
	ToDecimal""$ -
(""- .
entity"". 4
.""4 5
Salary""5 ;
)""; <
;""< =
await## 
baseRepository##  
.##  !
Add##! $
(##$ %
entity##% +
)##+ ,
;##, -
dto$$ 
.$$ 
Id$$ 
=$$ 
entity$$ 
.$$ 
Id$$ 
;$$ 
return&& 
new&& 
Result&& 
{'' 
Data(( 
=(( 
dto(( 
,(( 
	StateCode)) 
=)) 
	Constants)) %
.))% &
StateCodeResult))& 5
.))5 6
STATE_CODE_OK))6 C
}** 
;** 
}++ 	
public-- 
async-- 
Task-- 
<-- 
Result--  
>--  !
GetWorkExperience--" 3
(--3 4
int--4 7
IdPerson--8 @
)--@ A
{.. 	
var// 
dto// 
=// 
await// $
workExperienceRepository// 4
.//4 5
GetWorkExperience//5 F
(//F G
IdPerson//G O
)//O P
;//P Q
return11 
new11 
Result11 
{22 
Data33 
=33 
dto33 
,33 
	StateCode44 
=44 
	Constants44 %
.44% &
StateCodeResult44& 5
.445 6
STATE_CODE_OK446 C
}55 
;55 
}66 	
public88 
async88 
Task88 
<88 
Result88  
>88  !
Update88" (
(88( )
WorkExperienceDto88) :
dto88; >
)88> ?
{99 	
dto;; 
.;; 
Salary;; 
=;; 
dto;; 
.;; 
Salary;; #
.;;# $
Replace;;$ +
(;;+ ,
$str;;, 0
,;;0 1
string;;2 8
.;;8 9
Empty;;9 >
);;> ?
;;;? @
var<< 
entity<< 
=<< 
mapper<< 
.<<  
Map<<  #
<<<# $
WorkExperienceModel<<$ 7
><<7 8
(<<8 9
dto<<9 <
)<<< =
;<<= >
entity== 
.== 
Salary== 
=== 
Convert== "
.==" #
	ToDecimal==# ,
(==, -
entity==- 3
.==3 4
Salary==4 :
)==: ;
;==; <
await>> 
baseRepository>>  
.>>  !
Update>>! '
(>>' (
entity>>( .
)>>. /
;>>/ 0
dto?? 
.?? 
Id?? 
=?? 
entity?? 
.?? 
Id?? 
;?? 
returnAA 
newAA 
ResultAA 
{BB 
DataCC 
=CC 
dtoCC 
,CC 
	StateCodeDD 
=DD 
	ConstantsDD %
.DD% &
StateCodeResultDD& 5
.DD5 6
STATE_CODE_OKDD6 C
}EE 
;EE 
}FF 	
}GG 
}HH 