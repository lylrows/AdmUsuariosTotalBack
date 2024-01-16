ã
äD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Departamento\IServices\IExactusDepartamentoLogic.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Departamento0 <
.< =
	IServices= F
{ 
public		 

	interface		 %
IExactusDepartamentoLogic		 .
{

 
void 
Import 
( 
) 
; 
void 
Start 
( 
) 
; 
} 
} Ö
åD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Departamento\IServices\IExactusDepartamentoService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Departamento0 <
.< =
	IServices= F
{		 
public

 

	interface

 '
IExactusDepartamentoService

 0
{ 
Task 
< 
Result 
> (
SyncExactusToHumanManagement 1
(1 2
)2 3
;3 4
} 
} Ûï
àD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Departamento\Services\ExactusDepartamentoLogic.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Departamento0 <
.< =
Services= E
{ 
public 

class $
ExactusDepartamentoLogic )
:* +%
IExactusDepartamentoLogic, E
{ 
private
 
readonly 
IEmpresaRepository -
empresaRepository. ?
;? @
private 
readonly *
IExactusDepartamentoRepository 7)
exactusDepartamentoRepository8 U
;U V
private 
readonly 
IBaseRepository (
<( )
Areas) .
>. /
baseAreaRepository0 B
;B C
private 
readonly 
ILogger  
<  !$
ExactusDepartamentoLogic! 9
>9 :
_logger; B
;B C
private 
Timer 
feqProcessVh "
;" #
private   
Timer   
feqProcessDay   #
;  # $
private!! 
TimeSpan!! 
	StartTime!! "
;!!" #
private"" 
TimeSpan"" 
EndTime""  
;""  !
private## 
bool## 
	InProcess## 
;## 
public%% 
ParameterFilterDto%% !
ParameterFilter%%" 1
{%%2 3
get%%4 7
;%%7 8
set%%9 <
;%%< =
}%%> ?
private&& 
readonly&& $
ICoreParameterRepository&& 1#
coreParameterRepository&&2 I
;&&I J
public'' $
ExactusDepartamentoLogic'' '
(''' (
IEmpresaRepository''( :
empresaRepository''; L
,''L M*
IExactusDepartamentoRepository(($ B)
exactusDepartamentoRepository((C `
,((` a
IAreaRepository))$ 3
areaRepository))4 B
,))B C
IBaseRepository**$ 3
<**3 4
Areas**4 9
>**9 :
baseAreaRepository**; M
,**M N$
ICoreParameterRepository++$ <#
coreParameterRepository++= T
,++T U
ILogger,,$ +
<,,+ ,$
ExactusDepartamentoLogic,,, D
>,,D E
_logger,,F M
)-- 
{.. 	
this// 
.// )
exactusDepartamentoRepository// .
=/// 0)
exactusDepartamentoRepository//1 N
;//N O
this00 
.00 
empresaRepository00 "
=00# $
empresaRepository00% 6
;006 7
this11 
.11 
baseAreaRepository11 #
=11$ %
baseAreaRepository11& 8
;118 9
this33 
.33 
_logger33 
=33 
_logger33 "
;33" #
this55 
.55 #
coreParameterRepository55 (
=55) *#
coreParameterRepository55+ B
;55B C
}77 	
public99 
void99 
Import99 
(99 
)99 
{:: 	
_logger;; 
.;; 
LogInformation;; "
(;;" #
$str;;# <
);;< =
;;;= >
var<< 
CompaniesList<< 
=<< 
empresaRepository<<  1
.<<1 2
GetAll<<2 8
(<<8 9
)<<9 :
.<<: ;
Result<<; A
;<<A B
_logger== 
.== 
LogInformation== "
(==" #
string==# )
.==) *
Format==* 0
(==0 1
$str==1 P
,==P Q
CompaniesList==Q ^
.==^ _
Count==_ d
(==d e
)==e f
)==f g
)==g h
;==h i&
ExactusDepartmentFilterDto>> &
filterDepartment>>' 7
=>>8 9
new>>: =&
ExactusDepartmentFilterDto>>> X
(>>X Y
)>>Y Z
;>>Z [
varAA 
	areaslistAA 
=AA 
baseAreaRepositoryAA .
.AA. /
GetAllAA/ 5
(AA5 6
)AA6 7
.AA7 8
ResultAA8 >
;AA> ?
_loggerBB 
.BB 
LogInformationBB "
(BB" #
stringBB# )
.BB) *
FormatBB* 0
(BB0 1
$strBB1 ^
,BB^ _
	areaslistBB` i
.BBi j
CountBBj o
(BBo p
)BBp q
)BBq r
)BBr s
;BBs t
_loggerDD 
.DD 
LogInformationDD "
(DD" #
$strDD# @
)DD@ A
;DDA B
foreachEE 
(EE 
varEE 
compEE 
inEE  
CompaniesListEE! .
)EE. /
{FF 
tryGG 
{HH 
ifII 
(II 
!II 
stringII 
.II  
IsNullOrEmptyII  -
(II- .
compII. 2
.II2 3
SchemaII3 9
)II9 :
)II: ;
{JJ 
filterDepartmentKK (
.KK( )
SchemeKK) /
=KK0 1
compKK2 6
.KK6 7
SchemaKK7 =
;KK= >
varMM 
departmentListMM *
=MM+ ,)
exactusDepartamentoRepositoryMM- J
.MMJ K
GetAllMMK Q
(MMQ R
filterDepartmentMMR b
)MMb c
.MMc d
ResultMMd j
;MMj k
_loggerOO 
.OO  
LogInformationOO  .
(OO. /
stringOO/ 5
.OO5 6
FormatOO6 <
(OO< =
$strOO= u
,OOu v
departmentList	OOw Ö
.
OOÖ Ü
Count
OOÜ ã
(
OOã å
)
OOå ç
,
OOç é
comp
OOè ì
.
OOì î
Descripcion
OOî ü
)
OOü †
)
OO† °
;
OO° ¢
foreachQQ 
(QQ  !
varQQ! $
depaQQ% )
inQQ* ,
departmentListQQ- ;
)QQ; <
{RR 
varTT 
existTT  %
=TT& '
	areaslistTT( 1
.TT1 2
WhereTT2 7
(TT7 8
iTT8 9
=>TT: <
iTT= >
.TT> ?
	IdEmpresaTT? H
==TTI K
compTTL P
.TTP Q
IdTTQ S
&&TTT V
iTTW X
.TTX Y

CodExactusTTY c
==TTd f
depaTTg k
.TTk l
DEPARTAMENTOTTl x
)TTx y
.TTy z
FirstOrDefault	TTz à
(
TTà â
)
TTâ ä
;
TTä ã
ifWW 
(WW  
existWW  %
==WW& (
nullWW) -
)WW- .
{XX 
HumanManagementYY  /
.YY/ 0
DomainYY0 6
.YY6 7
AreasYY7 <
.YY< =
ModelsYY= C
.YYC D
AreasYYD I
	newAreaBdYYJ S
=YYT U
newYYV Y
HumanManagementYYZ i
.YYi j
DomainYYj p
.YYp q
AreasYYq v
.YYv w
ModelsYYw }
.YY} ~
Areas	YY~ É
(
YYÉ Ñ
)
YYÑ Ö
;
YYÖ Ü
	newAreaBd[[  )
.[[) *
	IdEmpresa[[* 3
=[[4 5
comp[[6 :
.[[: ;
Id[[; =
;[[= >
	newAreaBd\\  )
.\\) *
NameArea\\* 2
=\\3 4
depa\\5 9
.\\9 :
DESCRIPCION\\: E
;\\E F
	newAreaBd]]  )
.]]) *

CodExactus]]* 4
=]]5 6
depa]]7 ;
.]]; <
DEPARTAMENTO]]< H
;]]H I
	newAreaBd^^  )
.^^) *
IdUpperArea^^* 5
=^^6 7
$num^^8 9
;^^9 :
	newAreaBd__  )
.__) *
Boss__* .
=__/ 0
depa__1 5
.__5 6
JEFE__6 :
;__: ;
	newAreaBdaa  )
.aa) *
Activeaa* 0
=aa1 2
trueaa3 7
;aa7 8
	newAreaBdbb  )
.bb) *
IdUserRegisterbb* 8
=bb9 :
$numbb; <
;bb< =
	newAreaBdcc  )
.cc) *
DateRegistercc* 6
=cc7 8
DateTimecc9 A
.ccA B
NowccB E
;ccE F
	newAreaBddd  )
.dd) *
IdUserUpdatedd* 6
=dd7 8
$numdd9 :
;dd: ;
	newAreaBdee  )
.ee) *

DateUpdateee* 4
=ee5 6
DateTimeee7 ?
.ee? @
Nowee@ C
;eeC D
_loggergg  '
.gg' (
LogInformationgg( 6
(gg6 7
stringgg7 =
.gg= >
Formatgg> D
(ggD E
$strggE w
,ggw x
depaggy }
.gg} ~
DESCRIPCION	gg~ â
,
ggâ ä
comp
ggã è
.
ggè ê
Descripcion
ggê õ
)
ggõ ú
)
ggú ù
;
ggù û
baseAreaRepositoryhh  2
.hh2 3
Addhh3 6
(hh6 7
	newAreaBdhh7 @
)hh@ A
.hhA B
WaithhB F
(hhF G
)hhG H
;hhH I
}ii 
}kk 
}nn 
}pp 
catchqq 
(qq 
	Exceptionqq  
exqq! #
)qq$ %
{rr 
_loggertt 
.tt 
LogErrortt $
(tt$ %
$strtt% O
+ttP Q
exttR T
.ttT U
MessagettU \
)tt\ ]
;tt] ^
_loggeruu 
.uu 
LogErroruu $
(uu$ %
$struu% O
+uuP Q
exuuR T
.uuT U

StackTraceuuU _
)uu_ `
;uu` a
}vv 
}xx 
_loggeryy 
.yy 
LogInformationyy "
(yy" #
$stryy# 9
)yy9 :
;yy: ;
}zz 	
private}} 
void}} 
SetParameter}} !
(}}! "
)}}" #
{~~ 	
SetParameterBase 
( 
) 
; 
}
ÄÄ 	
private
ÅÅ 
void
ÅÅ 
SetParameterBase
ÅÅ &
(
ÅÅ& '
)
ÅÅ' (
{
ÇÇ 	
ParameterFilter
ÑÑ 
.
ÑÑ 
ApplicationName
ÑÑ +
=
ÑÑ, -
	Constants
ÑÑ. 7
.
ÑÑ7 8
HumanManagemen
ÑÑ8 F
.
ÑÑF G
ApplicationName
ÑÑG V
;
ÑÑV W
ParameterFilter
ÖÖ 
.
ÖÖ 
Module
ÖÖ "
=
ÖÖ# $
	Constants
ÖÖ% .
.
ÖÖ. /
HumanManagemen
ÖÖ/ =
.
ÖÖ= >
ModuleCommon
ÖÖ> J
;
ÖÖJ K
}
áá 	
public
ââ 
void
ââ 
Start
ââ 
(
ââ 
)
ââ 
{
ää 	
try
åå 
{
çç 
ParameterFilter
éé 
=
éé  !
new
éé" % 
ParameterFilterDto
éé& 8
(
éé8 9
)
éé9 :
;
éé: ;
SetParameter
èè 
(
èè 
)
èè 
;
èè 
ParameterFilter
íí 
.
íí  
Key
íí  #
=
íí$ %
	Constants
íí& /
.
íí/ 0
HumanManagemen
íí0 >
.
íí> ?
Keys
íí? C
.
ííC D
FrequencyProcVH
ííD S
;
ííS T 
ParameterResultDto
ìì "
result
ìì# )
=
ìì* +%
coreParameterRepository
ìì, C
.
ììC D
GetValue
ììD L
(
ììL M
ParameterFilter
ììM \
)
ìì\ ]
.
ìì] ^
Result
ìì^ d
;
ììd e
feqProcessVh
îî 
=
îî 
new
îî "
Timer
îî# (
(
îî( )
result
îî) /
.
îî/ 0
ValueNumeric
îî0 <
.
îî< =
Value
îî= B
)
îîB C
;
îîC D
feqProcessVh
ïï 
.
ïï 
Elapsed
ïï $
+=
ïï% '"
feqProcessVh_Elapsed
ïï( <
;
ïï< =
ParameterFilter
ññ 
.
ññ  
Key
ññ  #
=
ññ$ %
	Constants
ññ& /
.
ññ/ 0
HumanManagemen
ññ0 >
.
ññ> ?
Keys
ññ? C
.
ññC D

HoraInicio
ññD N
;
ññN O 
ParameterResultDto
óó "
resultStartTime
óó# 2
=
óó3 4%
coreParameterRepository
óó5 L
.
óóL M
GetValue
óóM U
(
óóU V
ParameterFilter
óóV e
)
óóe f
.
óóf g
Result
óóg m
;
óóm n
	StartTime
òò 
=
òò 
DateTime
òò $
.
òò$ %
Parse
òò% *
(
òò* +
resultStartTime
òò+ :
.
òò: ;
ValueString
òò; F
)
òòF G
.
òòG H
	TimeOfDay
òòH Q
;
òòQ R
ParameterFilter
ôô 
.
ôô  
Key
ôô  #
=
ôô$ %
	Constants
ôô& /
.
ôô/ 0
HumanManagemen
ôô0 >
.
ôô> ?
Keys
ôô? C
.
ôôC D
HoraFin
ôôD K
;
ôôK L 
ParameterResultDto
öö "
resultEndTime
öö# 0
=
öö1 2%
coreParameterRepository
öö3 J
.
ööJ K
GetValue
ööK S
(
ööS T
ParameterFilter
ööT c
)
ööc d
.
ööd e
Result
ööe k
;
öök l
EndTime
õõ 
=
õõ 
DateTime
õõ "
.
õõ" #
Parse
õõ# (
(
õõ( )
resultEndTime
õõ) 6
.
õõ6 7
ValueString
õõ7 B
)
õõB C
.
õõC D
	TimeOfDay
õõD M
;
õõM N
feqProcessVh
úú 
.
úú 
Start
úú "
(
úú" #
)
úú# $
;
úú$ %
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
††  !
$str
††! K
+
††L M
ex
††N P
.
††P Q
Message
††Q X
)
††X Y
;
††Y Z
_logger
°° 
.
°° 
LogError
°°  
(
°°  !
$str
°°! K
+
°°L M
ex
°°N P
.
°°P Q

StackTrace
°°Q [
)
°°[ \
;
°°\ ]
}
¢¢ 
}
££ 	
void
§§ "
feqProcessVh_Elapsed
§§ !
(
§§! "
object
§§" (
sender
§§) /
,
§§/ 0
ElapsedEventArgs
§§1 A
e
§§B C
)
§§C D
{
•• 	
_logger
ßß 
.
ßß 
LogInformation
ßß "
(
ßß" #
string
ßß# )
.
ßß) *
Format
ßß* 0
(
ßß0 1
$str
ßß1 G
)
ßßG H
)
ßßH I
;
ßßI J
var
®® 

horaActual
®® 
=
®® 
DateTime
®® %
.
®®% &
Now
®®& )
.
®®) *
	TimeOfDay
®®* 3
;
®®3 4
_logger
©© 
.
©© 
LogInformation
©© "
(
©©" #
string
©©# )
.
©©) *
Format
©©* 0
(
©©0 1
$str
©©1 F
,
©©F G

horaActual
©©H R
.
©©R S
ToString
©©S [
(
©©[ \
)
©©\ ]
)
©©] ^
)
©©^ _
;
©©_ `
_logger
™™ 
.
™™ 
LogInformation
™™ "
(
™™" #
string
™™# )
.
™™) *
Format
™™* 0
(
™™0 1
$str
™™1 F
,
™™F G
	StartTime
™™H Q
.
™™Q R
ToString
™™R Z
(
™™Z [
)
™™[ \
)
™™\ ]
)
™™] ^
;
™™^ _
_logger
´´ 
.
´´ 
LogInformation
´´ "
(
´´" #
string
´´# )
.
´´) *
Format
´´* 0
(
´´0 1
$str
´´1 F
,
´´F G
EndTime
´´H O
.
´´O P
ToString
´´P X
(
´´X Y
)
´´Y Z
)
´´Z [
)
´´[ \
;
´´\ ]
if
¨¨ 
(
¨¨ 

horaActual
¨¨ 
>=
¨¨ 
	StartTime
¨¨ '
&&
¨¨( *

horaActual
¨¨+ 5
<=
¨¨6 8
EndTime
¨¨9 @
)
¨¨@ A
{
≠≠ 
if
ÆÆ 
(
ÆÆ 
feqProcessDay
ÆÆ !
==
ÆÆ" $
null
ÆÆ% )
)
ÆÆ) *
{
ØØ 
ParameterFilter
∞∞ #
.
∞∞# $
Key
∞∞$ '
=
∞∞( )
	Constants
∞∞* 3
.
∞∞3 4
HumanManagemen
∞∞4 B
.
∞∞B C
Keys
∞∞C G
.
∞∞G H
FrequencyProcDay
∞∞H X
;
∞∞X Y 
ParameterResultDto
±± &
resultProcessDay
±±' 7
=
±±8 9%
coreParameterRepository
±±: Q
.
±±Q R
GetValue
±±R Z
(
±±Z [
ParameterFilter
±±[ j
)
±±j k
.
±±k l
Result
±±l r
;
±±r s
feqProcessDay
≤≤ !
=
≤≤" #
new
≤≤$ '
Timer
≤≤( -
(
≤≤- .
resultProcessDay
≤≤. >
.
≤≤> ?
ValueNumeric
≤≤? K
.
≤≤K L
Value
≤≤L Q
)
≤≤Q R
;
≤≤R S
feqProcessDay
≥≥ !
.
≥≥! "
Elapsed
≥≥" )
+=
≥≥* ,#
feqProcessDay_Elapsed
≥≥- B
;
≥≥B C
}
¥¥ 
if
µµ 
(
µµ 
!
µµ 
feqProcessDay
µµ "
.
µµ" #
Enabled
µµ# *
&&
µµ+ -
!
µµ. /
	InProcess
µµ/ 8
)
µµ8 9
{
∂∂ 
	InProcess
∑∑ 
=
∑∑ 
true
∑∑  $
;
∑∑$ %
Run
ππ 
(
ππ 
)
ππ 
;
ππ 
feqProcessDay
∫∫ !
.
∫∫! "
Start
∫∫" '
(
∫∫' (
)
∫∫( )
;
∫∫) *
}
ªª 
}
ºº 
else
ΩΩ 
{
ææ 
if
øø 
(
øø 
feqProcessDay
øø !
!=
øø" $
null
øø% )
&&
øø* ,
feqProcessDay
øø- :
.
øø: ;
Enabled
øø; B
)
øøB C
{
¿¿ 
	InProcess
¡¡ 
=
¡¡ 
false
¡¡  %
;
¡¡% &
feqProcessDay
¬¬ !
.
¬¬! "
Stop
¬¬" &
(
¬¬& '
)
¬¬' (
;
¬¬( )
}
√√ 
}
ƒƒ 
}
≈≈ 	
void
∆∆ #
feqProcessDay_Elapsed
∆∆ "
(
∆∆" #
object
∆∆# )
sender
∆∆* 0
,
∆∆0 1
ElapsedEventArgs
∆∆2 B
e
∆∆C D
)
∆∆D E
{
«« 	
_logger
»» 
.
»» 
LogInformation
»» "
(
»»" #
string
»»# )
.
»») *
Format
»»* 0
(
»»0 1
$str
»»1 H
)
»»H I
)
»»I J
;
»»J K
Run
…… 
(
…… 
)
…… 
;
…… 
}
   	
void
ÀÀ 
Run
ÀÀ 
(
ÀÀ 
)
ÀÀ 
{
ÃÃ 	
_logger
ÕÕ 
.
ÕÕ 
LogInformation
ÕÕ "
(
ÕÕ" #
string
ÕÕ# )
.
ÕÕ) *
Format
ÕÕ* 0
(
ÕÕ0 1
$str
ÕÕ1 6
)
ÕÕ6 7
)
ÕÕ7 8
;
ÕÕ8 9
Import
ŒŒ 
(
ŒŒ 
)
ŒŒ 
;
ŒŒ 
}
œœ 	
}
–– 
}—— Î
äD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Departamento\Services\ExactusDepartamentoService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Departamento0 <
.< =
Services= E
{ 
public 

class &
ExactusDepartamentoService +
:, - 
CustomWindowsService. B
{ 
private 
readonly $
ICoreParameterRepository 1#
coreParameterRepository2 I
;I J
private 
readonly %
IExactusDepartamentoLogic 2$
exactusDepartamentoLogic3 K
;K L
public &
ExactusDepartamentoService )
() *$
ICoreParameterRepository* B#
coreParameterRepositoryC Z
,Z [%
IExactusDepartamentoLogic\ u%
exactusDepartamentoLogic	v é
)
é è
: 
base 
( #
coreParameterRepository *
)* +
{ 	
this 
. $
exactusDepartamentoLogic )
=) *$
exactusDepartamentoLogic+ C
;C D
} 	
public 
override 
void 
Run  
(  !
)! "
{ 	
} 	
public   
override   
void   
SetParameterBase   -
(  - .
)  . /
{!! 	
ParameterFilter"" 
."" 
ApplicationName"" +
="", -
	Constants"". 7
.""7 8
HumanManagemen""8 F
.""F G
ApplicationName""G V
;""V W
ParameterFilter## 
.## 
Module## "
=### $
	Constants##% .
.##. /
NotifyImportedUser##/ A
.##A B
Module##B H
;##H I
}$$ 	
}%% 
}&& Ä
ÑD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Empleado\IServices\IExactusEmpleadoService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Empleado0 8
.8 9
	IServices9 B
{ 
public		 

	interface		 #
IExactusEmpleadoService		 ,
{

 
void 
Import 
( 
) 
; 
void 
Export 
( 
) 
; 
} 
} ÷Ú
ÇD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Empleado\Services\ExactusEmpleadoService.cs
	namespace   	
WSHumanManagement  
 
.   
Application   '
.  ' (
Exactus  ( /
.  / 0
Empleado  0 8
.  8 9
Services  9 A
{!! 
public## 

class## "
ExactusEmpleadoService## '
:##( )#
IExactusEmpleadoService##* A
{$$ 
private%% 
readonly%% 
IEmpresaRepository%% +
empresaRepository%%, =
;%%= >
private&& 
readonly&& &
IExactusEmpleadoRepository&& 3%
exactusEmpleadoRepository&&4 M
;&&M N
private'' 
readonly'' 
IBaseRepository'' (
<''( )
Cargo'') .
>''. /
baseCargoRepository''0 C
;''C D
private(( 
readonly(( 
IBaseRepository(( (
<((( )
Areas(() .
>((. /
baseAreaRepository((0 B
;((B C
private)) 
readonly)) 
IBaseRepository)) (
<))( )
EmployeeModel))) 6
>))6 7"
baseEmployeeRepository))8 N
;))N O
private** 
readonly** 
IBaseRepository** (
<**( )
Bank**) -
>**- .
baseBankRepository**/ A
;**A B
private++ 
readonly++ 
IMapper++  
mapper++! '
;++' (
private,, 
readonly,, 
ICryptography,, &
cryptography,,' 3
;,,3 4
private-- 
readonly-- 
IBaseRepository-- (
<--( )
PersonModel--) 4
>--4 5 
basePersonRepository--6 J
;--J K
private.. 
readonly.. 
IBaseRepository.. (
<..( )
EmployeeFile..) 5
>..5 6&
baseEmployeeFileRepository..7 Q
;..Q R
private// 
readonly// 
IBaseRepository// (
<//( )
User//) -
>//- .
baseUserRepository/// A
;//A B
private00 
List00 
<00 
UserMailDto00  
>00  !
userMailDtoList00" 1
;001 2
private11 
readonly11 
IMailRepository11 (
mailRepository11) 7
;117 8
private22 
readonly22 
IHtmlReader22 $

htmlReader22% /
;22/ 0
public33 
IConfiguration33 
Configuration33 +
{33, -
get33. 1
;331 2
}333 4
private44 
readonly44 
IEmployeeRepository44 ,
employeeRepository44- ?
;44? @
private55 
readonly55 "
IExactusBaseRepository55 /
<55/ 0
ExactusEALLEmpleado550 C
>55C D&
baseEAllEmpleadoRepository55E _
;55_ `
private66 
readonly66 
ILogger66  
<66  !"
ExactusEmpleadoService66! 7
>667 8
_logger669 @
;66@ A
private77 
readonly77 "
IMasterTableRepository77 /!
masterTableRepository770 E
;77E F
private88 
readonly88 
IBaseRepository88 (
<88( )
Address88) 0
>880 1!
baseAddressRepository882 G
;88G H
private99 
readonly99 
IPersonRepository99 *
personRepository99+ ;
;99; <
private:: 
readonly:: 
IBaseRepository:: (
<::( )
Phone::) .
>::. /
basePhoneRepository::0 C
;::C D
public>> "
ExactusEmpleadoService>> %
(>>% &
IEmpresaRepository>>& 8
empresaRepository>>9 J
,>>J K&
IExactusEmpleadoRepository??$ >%
exactusEmpleadoRepository??? X
,??X Y
IBaseRepository@@$ 3
<@@3 4
Cargo@@4 9
>@@9 :
baseCargoRepository@@; N
,@@N O
IBaseRepositoryAA$ 3
<AA3 4
AreasAA4 9
>AA9 :
baseAreaRepositoryAA; M
,AAM N
IBaseRepositoryBB$ 3
<BB3 4
EmployeeModelBB4 A
>BBA B"
baseEmployeeRepositoryBBC Y
,BBY Z
IBaseRepositoryCC$ 3
<CC3 4
BankCC4 8
>CC8 9
baseBankRepositoryCC: L
,CCL M
IMapperDD$ +
mapperDD, 2
,DD2 3
ICryptographyEE$ 1
cryptographyEE2 >
,EE> ?
IBaseRepositoryFF$ 3
<FF3 4
PersonModelFF4 ?
>FF? @ 
basePersonRepositoryFFA U
,FFU V
IBaseRepositoryGG$ 3
<GG3 4
EmployeeFileGG4 @
>GG@ A&
baseEmployeeFileRepositoryGGB \
,GG\ ]
IBaseRepositoryHH$ 3
<HH3 4
UserHH4 8
>HH8 9
baseUserRepositoryHH: L
,HHL M
IMailRepositoryII$ 3
mailRepositoryII4 B
,IIB C
IHtmlReaderJJ$ /

htmlReaderJJ0 :
,JJ: ;
IConfigurationKK$ 2
configurationKK3 @
,KK@ A
IEmployeeRepositoryLL$ 7
employeeRepositoryLL8 J
,LLJ K"
IExactusBaseRepositoryMM$ :
<MM: ;
ExactusEALLEmpleadoMM; N
>MMN O&
baseEAllEmpleadoRepositoryMMP j
,MMj k
ILoggerNN$ +
<NN+ ,"
ExactusEmpleadoServiceNN, B
>NNB C
_loggerNND K
,NNK L"
IMasterTableRepositoryOO$ :!
masterTableRepositoryOO; P
,OOP Q
IBaseRepositoryPP$ 3
<PP3 4
AddressPP4 ;
>PP; <!
baseAddressRepositoryPP= R
,PPR S
IPersonRepositoryQQ$ 5
personRepositoryQQ6 F
,QQF G
IBaseRepositoryRR$ 3
<RR3 4
PhoneRR4 9
>RR9 :
basePhoneRepositoryRR; N
)SS 
{TT 	
thisUU 
.UU %
exactusEmpleadoRepositoryUU *
=UU+ ,%
exactusEmpleadoRepositoryUU- F
;UUF G
thisVV 
.VV 
empresaRepositoryVV "
=VV# $
empresaRepositoryVV% 6
;VV6 7
thisWW 
.WW 
baseCargoRepositoryWW $
=WW% &
baseCargoRepositoryWW' :
;WW: ;
thisXX 
.XX 
baseAreaRepositoryXX #
=XX$ %
baseAreaRepositoryXX& 8
;XX8 9
thisYY 
.YY "
baseEmployeeRepositoryYY '
=YY( )"
baseEmployeeRepositoryYY* @
;YY@ A
thisZZ 
.ZZ 
baseBankRepositoryZZ #
=ZZ$ %
baseBankRepositoryZZ& 8
;ZZ8 9
this[[ 
.[[ 
cryptography[[ 
=[[ 
cryptography[[  ,
;[[, -
this\\ 
.\\  
basePersonRepository\\ %
=\\& ' 
basePersonRepository\\( <
;\\< =
this]] 
.]] &
baseEmployeeFileRepository]] +
=]], -&
baseEmployeeFileRepository]]. H
;]]H I
this^^ 
.^^ 
baseUserRepository^^ #
=^^$ %
baseUserRepository^^& 8
;^^8 9
this__ 
.__ 
mapper__ 
=__ 
mapper__  
;__  !
userMailDtoList`` 
=`` 
new`` !
List``" &
<``& '
UserMailDto``' 2
>``2 3
(``3 4
)``4 5
;``5 6
thisaa 
.aa 
mailRepositoryaa 
=aa  !
mailRepositoryaa" 0
;aa0 1
thisbb 
.bb 

htmlReaderbb 
=bb 

htmlReaderbb (
;bb( )
Configurationcc 
=cc 
configurationcc )
;cc) *
thisdd 
.dd 
employeeRepositorydd #
=dd$ %
employeeRepositorydd& 8
;dd8 9
thisee 
.ee &
baseEAllEmpleadoRepositoryee +
=ee, -&
baseEAllEmpleadoRepositoryee. H
;eeH I
thisff 
.ff 
_loggerff 
=ff 
_loggerff "
;ff" #
thisgg 
.gg !
masterTableRepositorygg &
=gg' (!
masterTableRepositorygg) >
;gg> ?
thishh 
.hh !
baseAddressRepositoryhh &
=hh' (!
baseAddressRepositoryhh) >
;hh> ?
thisii 
.ii 
personRepositoryii !
=ii" #
personRepositoryii$ 4
;ii4 5
thisjj 
.jj 
basePhoneRepositoryjj $
=jj% &
basePhoneRepositoryjj' :
;jj: ;
}kk 	
publicmm 
voidmm 
Importmm 
(mm 
)mm 
{nn 	
_loggeroo 
.oo 
LogInformationoo "
(oo" #
$stroo# <
)oo< =
;oo= >
varpp 
CompaniesListpp 
=pp 
empresaRepositorypp  1
.pp1 2
GetAllpp2 8
(pp8 9
)pp9 :
.pp: ;
Resultpp; A
;ppA B
_loggerqq 
.qq 
LogInformationqq "
(qq" #
stringqq# )
.qq) *
Formatqq* 0
(qq0 1
$strqq1 P
,qqP Q
CompaniesListqqR _
.qq_ `
Countqq` e
(qqe f
)qqf g
)qqg h
)qqh i
;qqi j$
ExactusEmpleadoFilterDtorr $
filterEmpleadorr% 3
=rr4 5
newrr6 9$
ExactusEmpleadoFilterDtorr: R
(rrR S
)rrS T
;rrT U
vartt 
EmpleadosBDtt 
=tt "
baseEmployeeRepositorytt 4
.tt4 5
GetAlltt5 ;
(tt; <
)tt< =
.tt= >
Resulttt> D
;ttD E
_loggervv 
.vv 
LogInformationvv "
(vv" #
stringvv# )
.vv) *
Formatvv* 0
(vv0 1
$strvv1 b
,vvb c
EmpleadosBDvvd o
.vvo p
Countvvp u
(vvu v
)vvv w
)vvw x
)vvx y
;vvy z
varxx 

Cargoslistxx 
=xx 
baseCargoRepositoryxx 0
.xx0 1
GetAllxx1 7
(xx7 8
)xx8 9
.xx9 :
Resultxx: @
;xx@ A
varzz 
	areaslistzz 
=zz 
baseAreaRepositoryzz .
.zz. /
GetAllzz/ 5
(zz5 6
)zz6 7
.zz7 8
Resultzz8 >
;zz> ?
var{{ 
bankList{{ 
={{ 
baseBankRepository{{ -
.{{- .
GetAll{{. 4
({{4 5
){{5 6
.{{6 7
Result{{7 =
;{{= >
var|| 
civilStatusList|| 
=||  !!
masterTableRepository||" 7
.||7 8
GetByIdFather||8 E
(||E F
$num||F G
)||G H
.||H I
Result||I O
;||O P
var}} 
nationalityList}} 
=}}  !!
masterTableRepository}}" 7
.}}7 8
GetByIdFather}}8 E
(}}E F
$num}}F G
)}}G H
.}}H I
Result}}I O
;}}O P
_logger 
. 
LogInformation "
(" #
$str# @
)@ A
;A B
foreach
ÄÄ 
(
ÄÄ 
var
ÄÄ 
comp
ÄÄ 
in
ÄÄ  
CompaniesList
ÄÄ! .
)
ÄÄ. /
{
ÅÅ 
try
ÉÉ 
{
ÑÑ 
if
ÖÖ 
(
ÖÖ 
!
ÖÖ 
string
ÖÖ 
.
ÖÖ  
IsNullOrEmpty
ÖÖ  -
(
ÖÖ- .
comp
ÖÖ. 2
.
ÖÖ2 3
Schema
ÖÖ3 9
)
ÖÖ9 :
)
ÖÖ: ;
{
ÜÜ 
filterEmpleado
áá &
.
áá& '
Scheme
áá' -
=
áá. /
comp
áá0 4
.
áá4 5
Schema
áá5 ;
;
áá; <
var
ää 
fullempleado
ää (
=
ää) *'
exactusEmpleadoRepository
ää+ D
.
ääD E
GetAll
ääE K
(
ääK L
filterEmpleado
ääL Z
)
ääZ [
.
ää[ \
Result
ää\ b
;
ääb c
_logger
çç 
.
çç  
LogInformation
çç  .
(
çç. /
string
çç/ 5
.
çç5 6
Format
çç6 <
(
çç< =
$str
çç= y
,
ççy z
fullempleadoçç{ á
.ççá à
	Empleadosççà ë
.ççë í
Countççí ó
(ççó ò
)ççò ô
,ççô ö
compççõ ü
.ççü †
Descripcionçç† ´
)çç´ ¨
)çç¨ ≠
;çç≠ Æ
int
êê 
nIdAreaDefault
êê *
=
êê+ ,
	areaslist
êê- 6
.
êê6 7
Where
êê7 <
(
êê< =
i
êê= >
=>
êê? A
i
êêB C
.
êêC D
	IdEmpresa
êêD M
==
êêN P
comp
êêQ U
.
êêU V
Id
êêV X
&&
êêY [
i
êê\ ]
.
êê] ^

CodExactus
êê^ h
==
êêi k
$str
êêl p
)
êêp q
.
êêq r
Select
êêr x
(
êêx y
i
êêy z
=>
êê{ }
i
êê~ 
.êê Ä
IdêêÄ Ç
)êêÇ É
.êêÉ Ñ
FirstOrDefaultêêÑ í
(êêí ì
)êêì î
;êêî ï
int
ëë 
nIdCargoDefault
ëë +
=
ëë, -

Cargoslist
ëë. 8
.
ëë8 9
Where
ëë9 >
(
ëë> ?
i
ëë? @
=>
ëëA C
i
ëëD E
.
ëëE F
	IdEmpresa
ëëF O
==
ëëP R
comp
ëëS W
.
ëëW X
Id
ëëX Z
&&
ëë[ ]
i
ëë^ _
.
ëë_ `

CodExactus
ëë` j
==
ëëk m
$str
ëën r
)
ëër s
.
ëës t
Select
ëët z
(
ëëz {
i
ëë{ |
=>
ëë} 
iëëÄ Å
.ëëÅ Ç
IdëëÇ Ñ
)ëëÑ Ö
.ëëÖ Ü
FirstOrDefaultëëÜ î
(ëëî ï
)ëëï ñ
;ëëñ ó
List
ìì 
<
ìì  
ExactusEmpleadoDto
ìì /
>
ìì/ 0"
importedEmployeeList
ìì1 E
=
ììF G
new
ììH K
List
ììL P
<
ììP Q 
ExactusEmpleadoDto
ììQ c
>
ììc d
(
ììd e
)
ììe f
;
ììf g
foreach
ïï 
(
ïï  !
var
ïï! $
emp
ïï% (
in
ïï) +
fullempleado
ïï, 8
.
ïï8 9
	Empleados
ïï9 B
)
ïïB C
{
ññ 
var
ôô 
exist
ôô  %
=
ôô& '
EmpleadosBD
ôô( 3
.
ôô3 4
Where
ôô4 9
(
ôô9 :
i
ôô: ;
=>
ôô< >
i
ôô? @
.
ôô@ A
	IdCompany
ôôA J
==
ôôK M
comp
ôôN R
.
ôôR S
Id
ôôS U
&&
ôôV X
i
ôôY Z
.
ôôZ [
CodEmployee
ôô[ f
==
ôôg i
emp
ôôj m
.
ôôm n
EMPLEADO
ôôn v
)
ôôv w
.
ôôw x
FirstOrDefaultôôx Ü
(ôôÜ á
)ôôá à
;ôôà â
if
öö 
(
öö  
exist
öö  %
==
öö& (
null
öö) -
)
öö- .
{
õõ 
if
ùù  "
(
ùù# $
emp
ùù$ '
.
ùù' (
ESTADO_EMPLEADO
ùù( 7
==
ùù8 :
$str
ùù; A
)
ùùA B
{
ûû  !
continue
üü$ ,
;
üü, -
}
††  !
string
¢¢  &
	FirstName
¢¢' 0
=
¢¢1 2
string
¢¢3 9
.
¢¢9 :
Empty
¢¢: ?
;
¢¢? @
string
££  &

SecondName
££' 1
=
££2 3
string
££4 :
.
££: ;
Empty
££; @
;
££@ A
emp
••  #
.
••# $
NOMBRE_PILA
••$ /
=
••0 1
emp
••2 5
.
••5 6
NOMBRE_PILA
••6 A
==
••B D
null
••E I
?
••J K
string
••L R
.
••R S
Empty
••S X
:
••Y Z
emp
••[ ^
.
••^ _
NOMBRE_PILA
••_ j
;
••j k
var
®®  #
arNombre
®®$ ,
=
®®- .
emp
®®/ 2
.
®®2 3
NOMBRE_PILA
®®3 >
.
®®> ?
Trim
®®? C
(
®®C D
)
®®D E
.
®®E F
Split
®®F K
(
®®K L
$str
®®L O
)
®®O P
;
®®P Q
if
´´  "
(
´´# $
arNombre
´´$ ,
.
´´, -
Length
´´- 3
==
´´4 6
$num
´´7 8
)
´´8 9
{
¨¨  !
	FirstName
≠≠$ -
=
≠≠. /
arNombre
≠≠0 8
[
≠≠8 9
$num
≠≠9 :
]
≠≠: ;
;
≠≠; <
}
ÆÆ  !
else
ØØ  $
if
ØØ% '
(
ØØ( )
arNombre
ØØ) 1
.
ØØ1 2
Length
ØØ2 8
==
ØØ9 ;
$num
ØØ< =
)
ØØ= >
{
∞∞  !
	FirstName
±±$ -
=
±±. /
arNombre
±±0 8
[
±±8 9
$num
±±9 :
]
±±: ;
;
±±; <

SecondName
≤≤$ .
=
≤≤/ 0
arNombre
≤≤1 9
[
≤≤9 :
$num
≤≤: ;
]
≤≤; <
;
≤≤< =
}
≥≥  !
else
¥¥  $
if
¥¥% '
(
¥¥( )
arNombre
¥¥) 1
.
¥¥1 2
Length
¥¥2 8
>
¥¥9 :
$num
¥¥; <
)
¥¥< =
{
µµ  !
for
∑∑$ '
(
∑∑( )
int
∑∑) ,
i
∑∑- .
=
∑∑/ 0
$num
∑∑1 2
;
∑∑2 3
i
∑∑4 5
<
∑∑6 7
arNombre
∑∑8 @
.
∑∑@ A
Length
∑∑A G
;
∑∑G H
i
∑∑I J
++
∑∑J L
)
∑∑L M
{
∏∏$ %
if
∫∫( *
(
∫∫+ ,
i
∫∫, -
==
∫∫. 0
$num
∫∫1 2
)
∫∫2 3
{
ªª( )
	FirstName
ºº, 5
=
ºº6 7
arNombre
ºº8 @
[
ºº@ A
i
ººA B
]
ººB C
;
ººC D
}
ΩΩ( )
else
ææ( ,
if
ææ- /
(
ææ0 1
i
ææ1 2
==
ææ3 5
$num
ææ6 7
)
ææ7 8
{
øø( )

SecondName
¿¿, 6
=
¿¿7 8
arNombre
¿¿9 A
[
¿¿A B
i
¿¿B C
]
¿¿C D
;
¿¿D E
}
¡¡( )
else
¬¬( ,
{
√√( )

SecondName
ƒƒ, 6
+=
ƒƒ7 9
$str
ƒƒ: =
+
ƒƒ> ?
arNombre
ƒƒ@ H
[
ƒƒH I
i
ƒƒI J
]
ƒƒJ K
;
ƒƒK L
}
≈≈( )
}
∆∆$ %
}
»»  !"
importedEmployeeList
ÀÀ  4
.
ÀÀ4 5
Add
ÀÀ5 8
(
ÀÀ8 9
new
ÀÀ9 < 
ExactusEmpleadoDto
ÀÀ= O
{
ÃÃ  !
	CodPerson
ÕÕ$ -
=
ÕÕ. /
emp
ÕÕ0 3
.
ÕÕ3 4
EMPLEADO
ÕÕ4 <
,
ÕÕ< =
	FirstName
ŒŒ$ -
=
ŒŒ. /
	FirstName
ŒŒ0 9
,
ŒŒ9 :

SecondName
œœ$ .
=
œœ/ 0

SecondName
œœ1 ;
,
œœ; <
LastName
––$ ,
=
––- .
emp
––/ 2
.
––2 3
PRIMER_APELLIDO
––3 B
==
––C E
null
––F J
?
––K L
string
––M S
.
––S T
Empty
––T Y
:
––Z [
emp
––\ _
.
––_ `
PRIMER_APELLIDO
––` o
,
––o p
MotherLastName
——$ 2
=
——3 4
emp
——5 8
.
——8 9
SEGUNDO_APELLIDO
——9 I
==
——J L
null
——M Q
?
——R S
string
——T Z
.
——Z [
Empty
——[ `
:
——a b
emp
——c f
.
——f g
SEGUNDO_APELLIDO
——g w
,
——w x
plaza
““$ )
=
““* +
emp
““, /
.
““/ 0
PLAZA
““0 5
,
““5 6
IdSex
””$ )
=
””* +
emp
””, /
.
””/ 0
SEXO
””0 4
==
””5 7
$str
””8 ;
?
””< =
$num
””> @
:
””A B
$num
””C E
,
””E F
	BirthDate
‘‘$ -
=
‘‘. /
emp
‘‘0 3
.
‘‘3 4
FECHA_NACIMIENTO
‘‘4 D
,
‘‘D E
Identification
’’$ 2
=
’’3 4
emp
’’5 8
.
’’8 9
IDENTIFICACION
’’9 G
,
’’G H
IsNoDomiciled
÷÷$ 1
=
÷÷2 3
true
÷÷4 8
,
÷÷8 9
CodEmployee
◊◊$ /
=
◊◊0 1
emp
◊◊2 5
.
◊◊5 6
EMPLEADO
◊◊6 >
,
◊◊> ?
Email
ÿÿ$ )
=
ÿÿ* +
emp
ÿÿ, /
.
ÿÿ/ 0
E_MAIL
ÿÿ0 6
,
ÿÿ6 7
AdmissionDate
ŸŸ$ 1
=
ŸŸ2 3
emp
ŸŸ4 7
.
ŸŸ7 8
FECHA_INGRESO
ŸŸ8 E
,
ŸŸE F
IsDependents
€€$ 0
=
€€1 2
true
€€3 7
,
€€7 8"
DateOffirstAdmission
››$ 8
=
››9 :
DateTime
››; C
.
››C D
Now
››D G
,
››G H&
UniversityGraduationDate
ﬁﬁ$ <
=
ﬁﬁ= >
null
ﬁﬁ? C
,
ﬁﬁC D
CountryentryDate
ﬂﬂ$ 4
=
ﬂﬂ5 6
null
ﬂﬂ7 ;
,
ﬂﬂ; <
IdState
··$ +
=
··, -
emp
··. 1
.
··1 2
ESTADO_EMPLEADO
··2 A
==
··B D
$str
··E K
?
··L M
$num
··N P
:
··Q R
$num
··S U
,
··U V

CodeCharge
‚‚$ .
=
‚‚/ 0
emp
‚‚1 4
.
‚‚4 5
PUESTO
‚‚5 ;
,
‚‚; <
	IdCompany
„„$ -
=
„„. /
comp
„„0 4
.
„„4 5
Id
„„5 7
,
„„7 8
IdActive
‰‰$ ,
=
‰‰- .
emp
‰‰/ 2
.
‰‰2 3
ACTIVO
‰‰3 9
==
‰‰: <
$str
‰‰= @
?
‰‰A B
$num
‰‰C E
:
‰‰F G
$num
‰‰H J
,
‰‰J K
IdCivilStatus
ÊÊ$ 1
=
ÊÊ2 3
civilStatusList
ÊÊ4 C
.
ÊÊC D
Where
ÊÊD I
(
ÊÊI J
i
ÊÊJ K
=>
ÊÊL N
i
ÊÊO P
.
ÊÊP Q

ShortValue
ÊÊQ [
==
ÊÊ\ ^
emp
ÊÊ_ b
.
ÊÊb c
ESTADO_CIVIL
ÊÊc o
)
ÊÊo p
.
ÊÊp q
Select
ÊÊq w
(
ÊÊw x
i
ÊÊx y
=>
ÊÊz |
i
ÊÊ} ~
.
ÊÊ~ 
IdÊÊ Å
)ÊÊÅ Ç
.ÊÊÇ É
FirstOrDefaultÊÊÉ ë
(ÊÊë í
)ÊÊí ì
,ÊÊì î
	BloodType
ÁÁ$ -
=
ÁÁ. /
emp
ÁÁ0 3
.
ÁÁ3 4
TIPO_SANGRE
ÁÁ4 ?
,
ÁÁ? @
Passport
ËË$ ,
=
ËË- .
emp
ËË/ 2
.
ËË2 3
	PASAPORTE
ËË3 <
,
ËË< =
IdNationality
ÍÍ$ 1
=
ÍÍ2 3
nationalityList
ÍÍ4 C
.
ÍÍC D
Where
ÍÍD I
(
ÍÍI J
i
ÍÍJ K
=>
ÍÍL N
i
ÍÍO P
.
ÍÍP Q

ShortValue
ÍÍQ [
==
ÍÍ\ ^
emp
ÍÍ_ b
.
ÍÍb c
PAIS
ÍÍc g
)
ÍÍg h
.
ÍÍh i
Select
ÍÍi o
(
ÍÍo p
i
ÍÍp q
=>
ÍÍr t
i
ÍÍu v
.
ÍÍv w
Id
ÍÍw y
)
ÍÍy z
.
ÍÍz {
FirstOrDefaultÍÍ{ â
(ÍÍâ ä
)ÍÍä ã
,ÍÍã å
Sede
ÎÎ$ (
=
ÎÎ) *
emp
ÎÎ+ .
.
ÎÎ. /
	UBICACION
ÎÎ/ 8
,
ÎÎ8 9

CenterCost
ÏÏ$ .
=
ÏÏ/ 0
emp
ÏÏ1 4
.
ÏÏ4 5
CENTRO_COSTO
ÏÏ5 A
,
ÏÏA B
CodeBank
ÌÌ$ ,
=
ÌÌ- .
emp
ÌÌ/ 2
.
ÌÌ2 3 
ENTIDAD_FINANCIERA
ÌÌ3 E
,
ÌÌE F
AccountBank
ÓÓ$ /
=
ÓÓ0 1
emp
ÓÓ1 4
.
ÓÓ4 5
CUENTA_ENTIDAD
ÓÓ5 C
,
ÓÓC D
Cciaccount_bank
ÔÔ$ 3
=
ÔÔ4 5
string
ÔÔ6 <
.
ÔÔ< =
Empty
ÔÔ= B
,
ÔÔB C!
CurrencyAccountBank
$ 7
=
8 9
emp
: =
.
= >
RUBRO7
> D
,
D E
CodeBankCts
ÚÚ$ /
=
ÚÚ/ 0
emp
ÚÚ1 4
.
ÚÚ4 5
RUBRO10
ÚÚ5 <
,
ÚÚ< =

AccountCts
ÛÛ$ .
=
ÛÛ. /
emp
ÛÛ0 3
.
ÛÛ3 4
RUBRO9
ÛÛ4 :
,
ÛÛ: ;
CurrencyCts
ÙÙ$ /
=
ÙÙ/ 0
emp
ÙÙ1 4
.
ÙÙ4 5
RUBRO8
ÙÙ5 ;
,
ÙÙ; <
AfpCode
ıı$ +
=
ıı+ ,
emp
ıı- 0
.
ıı0 1
RUBRO6
ıı1 7
,
ıı7 8
DEPARTAMENTO_DIR
˜˜$ 4
=
˜˜5 6
emp
˜˜6 9
.
˜˜9 :
DEPARTAMENTO_DIR
˜˜: J
,
˜˜J K
	PROVINCIA
¯¯$ -
=
¯¯. /
emp
¯¯0 3
.
¯¯3 4
	PROVINCIA
¯¯4 =
,
¯¯= >
DISTRITO
˘˘$ ,
=
˘˘. /
emp
˘˘0 3
.
˘˘3 4
DISTRITO
˘˘4 <
,
˘˘= >
DIRECCIONEMP
˙˙$ 0
=
˙˙1 2
emp
˙˙3 6
.
˙˙6 7
DIRECCIONEMP
˙˙7 C
,
˙˙C D
	TELEFONO1
˚˚$ -
=
˚˚. /
emp
˚˚0 3
.
˚˚3 4
	TELEFONO1
˚˚4 =
,
˚˚= >
	TELEFONO2
¸¸$ -
=
¸¸. /
emp
¸¸0 3
.
¸¸3 4
	TELEFONO2
¸¸4 =
,
¸¸= >
	TELEFONO3
˝˝$ -
=
˝˝- .
emp
˝˝/ 2
.
˝˝2 3
	TELEFONO3
˝˝3 <
,
˝˝< ="
DIVISION_GEOGRAFICA2
˛˛$ 8
=
˛˛9 :
emp
˛˛; >
.
˛˛> ?"
DIVISION_GEOGRAFICA2
˛˛? S
}
ÅÅ  !
)
ÅÅ! "
;
ÅÅ" #
}
ÇÇ 
else
ÉÉ  
{
ÉÉ! "
if
áá  "
(
áá# $
emp
áá$ '
.
áá' (
EMPLEADO
áá( 0
==
áá1 3
$str
áá4 >
)
áá> ?
{
àà  !
var
ââ$ '
ddd
ââ( +
=
ââ, -
$str
ââ. 0
;
ââ0 1
}
ää  !
int
åå  # 
nIdStateExactusEmp
åå$ 6
=
åå7 8
emp
åå9 <
.
åå< =
ESTADO_EMPLEADO
åå= L
==
ååM O
$str
ååP V
?
ååW X
$num
ååY [
:
åå\ ]
$num
åå^ `
;
åå` a
if
éé  "
(
éé# $
exist
éé$ )
.
éé) *
IdState
éé* 1
!=
éé2 4 
nIdStateExactusEmp
éé5 G
)
ééG H
{
èè  !
_logger
ëë$ +
.
ëë+ ,
LogInformation
ëë, :
(
ëë: ;
$str
ëë; v
,
ëëv w
emp
ëëx {
.
ëë{ |
NOMBRE_PILAëë| á
,ëëá à
empëëâ å
.ëëå ç
ESTADO_EMPLEADOëëç ú
)ëëú ù
;ëëù û
exist
íí$ )
.
íí) *
IdState
íí* 1
=
íí2 3 
nIdStateExactusEmp
íí4 F
;
ííF G
}
ôô  !
if
ùù  "
(
ùù# $
emp
ùù$ '
.
ùù' (
ESTADO_EMPLEADO
ùù( 7
!=
ùù8 :
$str
ùù; A
)
ùùA B
{
ûû  !
var
üü$ '
personaupdate
üü( 5
=
üü6 7"
basePersonRepository
üü8 L
.
üüL M
Find
üüM Q
(
üüQ R
exist
üüR W
.
üüW X
IdPerson
üüX `
)
üü` a
.
üüa b
Result
üüb h
;
üüh i
string
¶¶$ *
	FirstName
¶¶+ 4
=
¶¶5 6
string
¶¶7 =
.
¶¶= >
Empty
¶¶> C
;
¶¶C D
string
ßß$ *

SecondName
ßß+ 5
=
ßß6 7
string
ßß8 >
.
ßß> ?
Empty
ßß? D
;
ßßD E
emp
©©$ '
.
©©' (
NOMBRE_PILA
©©( 3
=
©©4 5
emp
©©6 9
.
©©9 :
NOMBRE_PILA
©©: E
==
©©F H
null
©©I M
?
©©N O
string
©©P V
.
©©V W
Empty
©©W \
:
©©] ^
emp
©©_ b
.
©©b c
NOMBRE_PILA
©©c n
;
©©n o
var
¨¨$ '
arNombre
¨¨( 0
=
¨¨1 2
emp
¨¨3 6
.
¨¨6 7
NOMBRE_PILA
¨¨7 B
.
¨¨B C
Trim
¨¨C G
(
¨¨G H
)
¨¨H I
.
¨¨I J
Split
¨¨J O
(
¨¨O P
$str
¨¨P S
)
¨¨S T
;
¨¨T U
if
ØØ$ &
(
ØØ' (
arNombre
ØØ( 0
.
ØØ0 1
Length
ØØ1 7
==
ØØ8 :
$num
ØØ; <
)
ØØ< =
{
∞∞$ %
	FirstName
±±( 1
=
±±2 3
arNombre
±±4 <
[
±±< =
$num
±±= >
]
±±> ?
;
±±? @
}
≤≤$ %
else
≥≥$ (
if
≥≥) +
(
≥≥, -
arNombre
≥≥- 5
.
≥≥5 6
Length
≥≥6 <
==
≥≥= ?
$num
≥≥@ A
)
≥≥A B
{
¥¥$ %
	FirstName
µµ( 1
=
µµ2 3
arNombre
µµ4 <
[
µµ< =
$num
µµ= >
]
µµ> ?
;
µµ? @

SecondName
∂∂( 2
=
∂∂3 4
arNombre
∂∂5 =
[
∂∂= >
$num
∂∂> ?
]
∂∂? @
;
∂∂@ A
}
∑∑$ %
else
∏∏$ (
if
∏∏) +
(
∏∏, -
arNombre
∏∏- 5
.
∏∏5 6
Length
∏∏6 <
>
∏∏= >
$num
∏∏? @
)
∏∏@ A
{
ππ$ %
for
ªª( +
(
ªª, -
int
ªª- 0
i
ªª1 2
=
ªª3 4
$num
ªª5 6
;
ªª6 7
i
ªª8 9
<
ªª: ;
arNombre
ªª< D
.
ªªD E
Length
ªªE K
;
ªªK L
i
ªªM N
++
ªªN P
)
ªªP Q
{
ºº( )
if
ææ, .
(
ææ/ 0
i
ææ0 1
==
ææ2 4
$num
ææ5 6
)
ææ6 7
{
øø, -
	FirstName
¿¿0 9
=
¿¿: ;
arNombre
¿¿< D
[
¿¿D E
i
¿¿E F
]
¿¿F G
;
¿¿G H
}
¡¡, -
else
¬¬, 0
if
¬¬1 3
(
¬¬4 5
i
¬¬5 6
==
¬¬7 9
$num
¬¬: ;
)
¬¬; <
{
√√, -

SecondName
ƒƒ0 :
=
ƒƒ; <
arNombre
ƒƒ= E
[
ƒƒE F
i
ƒƒF G
]
ƒƒG H
;
ƒƒH I
}
≈≈, -
else
∆∆, 0
{
««, -

SecondName
»»0 :
+=
»»; =
$str
»»> A
+
»»B C
arNombre
»»D L
[
»»L M
i
»»M N
]
»»N O
;
»»O P
}
……, -
}
  ( )
}
ÃÃ$ %
personaupdate
ŒŒ$ 1
.
ŒŒ1 2
	FirstName
ŒŒ2 ;
=
ŒŒ< =
	FirstName
ŒŒ> G
;
ŒŒG H
personaupdate
œœ$ 1
.
œœ1 2

SecondName
œœ2 <
=
œœ= >

SecondName
œœ? I
;
œœI J
personaupdate
––$ 1
.
––1 2
LastName
––2 :
=
––; <
emp
––= @
.
––@ A
PRIMER_APELLIDO
––A P
==
––Q S
null
––T X
?
––Y Z
string
––[ a
.
––a b
Empty
––b g
:
––h i
emp
––j m
.
––m n
PRIMER_APELLIDO
––n }
;
––} ~
personaupdate
——$ 1
.
——1 2
MotherLastName
——2 @
=
——A B
emp
——C F
.
——F G
SEGUNDO_APELLIDO
——G W
==
——X Z
null
——[ _
?
——` a
string
——b h
.
——h i
Empty
——i n
:
——o p
emp
——q t
.
——t u
SEGUNDO_APELLIDO——u Ö
;——Ö Ü
personaupdate
““$ 1
.
““1 2
IdSex
““2 7
=
““8 9
emp
““: =
.
““= >
SEXO
““> B
==
““C E
$str
““F I
?
““J K
$num
““L N
:
““O P
$num
““Q S
;
““S T
personaupdate
””$ 1
.
””1 2
	BirthDate
””2 ;
=
””< =
emp
””> A
.
””A B
FECHA_NACIMIENTO
””B R
;
””R S
exist
’’$ )
.
’’) *
plaza
’’* /
=
’’0 1
emp
’’2 5
.
’’5 6
PLAZA
’’6 ;
;
’’; <
personaupdate
◊◊$ 1
.
◊◊1 2
Email
◊◊2 7
=
◊◊8 9
emp
◊◊: =
.
◊◊= >
E_MAIL
◊◊> D
;
◊◊D E
exist
⁄⁄$ )
.
⁄⁄) *
AdmissionDate
⁄⁄* 7
=
⁄⁄8 9
emp
⁄⁄: =
.
⁄⁄= >
FECHA_INGRESO
⁄⁄> K
;
⁄⁄K L
personaupdate
ﬁﬁ$ 1
.
ﬁﬁ1 2
IdCivilStatus
ﬁﬁ2 ?
=
ﬁﬁ@ A
civilStatusList
ﬁﬁB Q
.
ﬁﬁQ R
Where
ﬁﬁR W
(
ﬁﬁW X
i
ﬁﬁX Y
=>
ﬁﬁZ \
i
ﬁﬁ] ^
.
ﬁﬁ^ _

ShortValue
ﬁﬁ_ i
==
ﬁﬁj l
emp
ﬁﬁm p
.
ﬁﬁp q
ESTADO_CIVIL
ﬁﬁq }
)
ﬁﬁ} ~
.
ﬁﬁ~ 
Selectﬁﬁ Ö
(ﬁﬁÖ Ü
iﬁﬁÜ á
=>ﬁﬁà ä
iﬁﬁã å
.ﬁﬁå ç
Idﬁﬁç è
)ﬁﬁè ê
.ﬁﬁê ë
FirstOrDefaultﬁﬁë ü
(ﬁﬁü †
)ﬁﬁ† °
;ﬁﬁ° ¢
personaupdate
ﬂﬂ$ 1
.
ﬂﬂ1 2
	BloodType
ﬂﬂ2 ;
=
ﬂﬂ< =
emp
ﬂﬂ> A
.
ﬂﬂA B
TIPO_SANGRE
ﬂﬂB M
;
ﬂﬂM N
personaupdate
‡‡$ 1
.
‡‡1 2
Passport
‡‡2 :
=
‡‡; <
emp
‡‡= @
.
‡‡@ A
	PASAPORTE
‡‡A J
;
‡‡J K
personaupdate
··$ 1
.
··1 2
IdNationality
··2 ?
=
··@ A
nationalityList
··B Q
.
··Q R
Where
··R W
(
··W X
i
··X Y
=>
··Z \
i
··] ^
.
··^ _

ShortValue
··_ i
==
··j l
emp
··m p
.
··p q
PAIS
··q u
)
··u v
.
··v w
Select
··w }
(
··} ~
i
··~ 
=>··Ä Ç
i··É Ñ
.··Ñ Ö
Id··Ö á
)··á à
.··à â
FirstOrDefault··â ó
(··ó ò
)··ò ô
;··ô ö
exist
ÊÊ$ )
.
ÊÊ) *
Sede
ÊÊ* .
=
ÊÊ/ 0
emp
ÊÊ1 4
.
ÊÊ4 5
	UBICACION
ÊÊ5 >
;
ÊÊ> ?
exist
ÁÁ$ )
.
ÁÁ) *

CenterCost
ÁÁ* 4
=
ÁÁ5 6
emp
ÁÁ7 :
.
ÁÁ: ;
CENTRO_COSTO
ÁÁ; G
;
ÁÁG H
exist
ËË$ )
.
ËË) *
CodeBank
ËË* 2
=
ËË3 4
emp
ËË5 8
.
ËË8 9 
ENTIDAD_FINANCIERA
ËË9 K
;
ËËK L
exist
ÈÈ$ )
.
ÈÈ) *
AccountBank
ÈÈ* 5
=
ÈÈ6 7
emp
ÈÈ8 ;
.
ÈÈ; <
CUENTA_ENTIDAD
ÈÈ< J
;
ÈÈJ K
exist
ÍÍ$ )
.
ÍÍ) *
Cciaccount_bank
ÍÍ* 9
=
ÍÍ: ;
string
ÍÍ< B
.
ÍÍB C
Empty
ÍÍC H
;
ÍÍH I
exist
ÎÎ$ )
.
ÎÎ) *!
CurrencyAccountBank
ÎÎ* =
=
ÎÎ> ?
emp
ÎÎ@ C
.
ÎÎC D
RUBRO7
ÎÎD J
;
ÎÎJ K
exist
ÌÌ$ )
.
ÌÌ) *
CodeBankCts
ÌÌ* 5
=
ÌÌ6 7
emp
ÌÌ8 ;
.
ÌÌ; <
RUBRO10
ÌÌ< C
;
ÌÌC D
exist
ÓÓ$ )
.
ÓÓ) *

AccountCts
ÓÓ* 4
=
ÓÓ5 6
emp
ÓÓ7 :
.
ÓÓ: ;
RUBRO9
ÓÓ; A
;
ÓÓA B
exist
ÔÔ$ )
.
ÔÔ) *
CurrencyCts
ÔÔ* 5
=
ÔÔ6 7
emp
ÔÔ8 ;
.
ÔÔ; <
RUBRO8
ÔÔ< B
;
ÔÔB C
exist
$ )
.
) *
AfpCode
* 1
=
2 3
emp
4 7
.
7 8
RUBRO6
8 >
;
> ?
int
˜˜$ '
?
˜˜' (
su_entsegvida
˜˜) 6
=
˜˜7 8
null
˜˜9 =
;
˜˜= >
if
¯¯$ &
(
¯¯' (
!
¯¯( )
string
¯¯) /
.
¯¯/ 0
IsNullOrEmpty
¯¯0 =
(
¯¯= >
emp
¯¯> A
.
¯¯A B
U_ENTSEGVIDA
¯¯B N
)
¯¯N O
)
¯¯O P
{
˘˘$ %
su_entsegvida
˙˙( 5
=
˙˙6 7
int
˙˙8 ;
.
˙˙; <
Parse
˙˙< A
(
˙˙A B
emp
˙˙B E
.
˙˙E F
U_ENTSEGVIDA
˙˙F R
)
˙˙R S
;
˙˙S T
}
˚˚$ %
exist
˝˝$ )
.
˝˝) *
su_entsegvida
˝˝* 7
=
˝˝8 9
su_entsegvida
˝˝: G
;
˝˝G H
int
ˇˇ$ '
?
ˇˇ' (

su_planeps
ˇˇ) 3
=
ˇˇ4 5
null
ˇˇ6 :
;
ˇˇ: ;
if
ÄÄ$ &
(
ÄÄ' (
!
ÄÄ( )
string
ÄÄ) /
.
ÄÄ/ 0
IsNullOrEmpty
ÄÄ0 =
(
ÄÄ= >
emp
ÄÄ> A
.
ÄÄA B
	U_PLANEPS
ÄÄB K
)
ÄÄK L
)
ÄÄL M
{
ÅÅ$ %

su_planeps
ÇÇ( 2
=
ÇÇ3 4
int
ÇÇ5 8
.
ÇÇ8 9
Parse
ÇÇ9 >
(
ÇÇ> ?
emp
ÇÇ? B
.
ÇÇB C
	U_PLANEPS
ÇÇC L
)
ÇÇL M
;
ÇÇM N
}
ÉÉ$ %
exist
ÜÜ$ )
.
ÜÜ) *

su_planeps
ÜÜ* 4
=
ÜÜ5 6

su_planeps
ÜÜ7 A
;
ÜÜA B
int
ää$ '
?
ää' (
su_plansegpri
ää) 6
=
ää7 8
null
ää9 =
;
ää= >
if
ãã$ &
(
ãã' (
!
ãã( )
string
ãã) /
.
ãã/ 0
IsNullOrEmpty
ãã0 =
(
ãã= >
emp
ãã> A
.
ããA B
U_PLANSEGPRI
ããB N
)
ããN O
)
ããO P
{
åå$ %
su_plansegpri
çç( 5
=
çç6 7
int
çç8 ;
.
çç; <
Parse
çç< A
(
ççA B
emp
ççB E
.
ççE F
U_PLANSEGPRI
ççF R
)
ççR S
;
ççS T
}
éé$ %
exist
ëë$ )
.
ëë) *
su_plansegpri
ëë* 7
=
ëë8 9
su_plansegpri
ëë: G
;
ëëG H
int
îî$ '
?
îî' (
su_sctrsalud
îî) 5
=
îî6 7
null
îî8 <
;
îî< =
if
ïï$ &
(
ïï' (
emp
ïï( +
.
ïï+ ,
U_SCTRSALUD
ïï, 7
!=
ïï8 :
null
ïï; ?
)
ïï? @
{
ññ$ %
su_sctrsalud
óó( 4
=
óó5 6
int
óó7 :
.
óó: ;
Parse
óó; @
(
óó@ A
emp
óóA D
.
óóD E
U_SCTRSALUD
óóE P
.
óóP Q
ToString
óóQ Y
(
óóY Z
)
óóZ [
)
óó[ \
;
óó\ ]
}
òò$ %
exist
öö$ )
.
öö) *
su_sctrsalud
öö* 6
=
öö7 8
su_sctrsalud
öö9 E
;
ööE F
int
ùù$ '
?
ùù' (
su_entsegpract
ùù) 7
=
ùù8 9
null
ùù: >
;
ùù> ?
if
ûû$ &
(
ûû' (
!
ûû( )
string
ûû) /
.
ûû/ 0
IsNullOrEmpty
ûû0 =
(
ûû= >
emp
ûû> A
.
ûûA B
U_ENTSEGPRACT
ûûB O
)
ûûO P
)
ûûP Q
{
üü$ %
su_entsegpract
††( 6
=
††7 8
int
††9 <
.
††< =
Parse
††= B
(
††B C
emp
††C F
.
††F G
U_ENTSEGPRACT
††G T
)
††T U
;
††U V
}
°°$ %
exist
££$ )
.
££) *
su_entsegpract
££* 8
=
££9 :
su_entsegpract
££; I
;
££I J
var
¥¥$ '!
inserbackupempleado
¥¥( ;
=
¥¥< =
personRepository
¥¥> N
.
¥¥N O$
RegisterBackupEmpleado
¥¥O e
(
¥¥e f
personaupdate
¥¥f s
.
¥¥s t
	CodPerson
¥¥t }
)
¥¥} ~
.
¥¥~ 
Result¥¥ Ö
;¥¥Ö Ü"
basePersonRepository
∑∑$ 8
.
∑∑8 9
Update
∑∑9 ?
(
∑∑? @
personaupdate
∑∑@ M
)
∑∑M N
.
∑∑N O
Wait
∑∑O S
(
∑∑S T
)
∑∑T U
;
∑∑U V$
baseEmployeeRepository
ππ$ :
.
ππ: ;
Update
ππ; A
(
ππA B
exist
ππB G
)
ππG H
.
ππH I
Wait
ππI M
(
ππM N
)
ππN O
;
ππO P
}
ªª  !
}
¡¡ 
}
√√ "
importedEmployeeList
∆∆ ,
.
∆∆, -
ForEach
∆∆- 4
(
∆∆4 5
x
∆∆5 6
=>
∆∆7 9
{
«« 
int
»» 

idPosition
»»  *
=
»»+ ,

Cargoslist
»»- 7
.
»»7 8
Where
»»8 =
(
»»= >
i
»»> ?
=>
»»@ B
i
»»C D
.
»»D E
	IdEmpresa
»»E N
==
»»O Q
x
»»R S
.
»»S T
	IdCompany
»»T ]
&&
»»^ `
i
»»a b
.
»»b c

CodExactus
»»c m
==
»»n p
x
»»q r
.
»»r s

CodeCharge
»»s }
)
»»} ~
.
»»~ 
Select»» Ö
(»»Ö Ü
i»»Ü á
=>»»à ä
i»»ã å
.»»å ç
Id»»ç è
)»»è ê
.»»ê ë
FirstOrDefault»»ë ü
(»»ü †
)»»† °
;»»° ¢
if
   
(
    

idPosition
    *
==
  + -
$num
  . /
)
  / 0
{
  1 2

idPosition
ÀÀ  *
=
ÀÀ+ ,
nIdCargoDefault
ÀÀ- <
;
ÀÀ< =
}
ÃÃ 
x
ÕÕ 
.
ÕÕ 

IdPosition
ÕÕ (
=
ÕÕ) *

idPosition
ÕÕ+ 5
;
ÕÕ5 6
int
ŒŒ 
idCtsOriginBank
ŒŒ  /
=
ŒŒ0 1
bankList
ŒŒ2 :
.
ŒŒ: ;
Where
ŒŒ; @
(
ŒŒ@ A
i
ŒŒA B
=>
ŒŒC E
i
ŒŒF G
.
ŒŒG H
CodeBank
ŒŒH P
==
ŒŒQ S
x
ŒŒT U
.
ŒŒU V
CtsOriginBank
ŒŒV c
)
ŒŒc d
.
ŒŒd e
Select
ŒŒe k
(
ŒŒk l
i
ŒŒl m
=>
ŒŒn p
i
ŒŒq r
.
ŒŒr s
Id
ŒŒs u
)
ŒŒu v
.
ŒŒv w
FirstOrDefaultŒŒw Ö
(ŒŒÖ Ü
)ŒŒÜ á
;ŒŒá à
if
œœ 
(
œœ  
idCtsOriginBank
œœ  /
>
œœ0 1
$num
œœ2 3
)
œœ3 4
{
–– 
x
——  !
.
——! "
IdCtsOriginBank
——" 1
=
——2 3
idCtsOriginBank
——4 C
;
——C D
}
““ 
int
”” 
idOriginBank
””  ,
=
””- .
bankList
””/ 7
.
””7 8
Where
””8 =
(
””= >
i
””> ?
=>
””@ B
i
””C D
.
””D E
CodeBank
””E M
==
””N P
x
””Q R
.
””R S$
OriginBankRemuneration
””S i
)
””i j
.
””j k
Select
””k q
(
””q r
i
””r s
=>
””t v
i
””w x
.
””x y
Id
””y {
)
””{ |
.
””| }
FirstOrDefault””} ã
(””ã å
)””å ç
;””ç é
if
‘‘ 
(
‘‘  
idOriginBank
‘‘  ,
>
‘‘- .
$num
‘‘/ 0
)
‘‘0 1
{
’’ 
x
÷÷  !
.
÷÷! "
IdOriginBank
÷÷" .
=
÷÷/ 0
idOriginBank
÷÷1 =
;
÷÷= >
}
◊◊ 
int
ÿÿ 
idFinancialEntity
ÿÿ  1
=
ÿÿ2 3
bankList
ÿÿ4 <
.
ÿÿ< =
Where
ÿÿ= B
(
ÿÿB C
i
ÿÿC D
=>
ÿÿE G
i
ÿÿH I
.
ÿÿI J
CodeBank
ÿÿJ R
==
ÿÿS U
x
ÿÿV W
.
ÿÿW X
FinancialEntity
ÿÿX g
)
ÿÿg h
.
ÿÿh i
Select
ÿÿi o
(
ÿÿo p
i
ÿÿp q
=>
ÿÿr t
i
ÿÿu v
.
ÿÿv w
Id
ÿÿw y
)
ÿÿy z
.
ÿÿz {
FirstOrDefaultÿÿ{ â
(ÿÿâ ä
)ÿÿä ã
;ÿÿã å
if
ŸŸ 
(
ŸŸ  
idFinancialEntity
ŸŸ  1
>
ŸŸ2 3
$num
ŸŸ4 5
)
ŸŸ5 6
{
⁄⁄ 
x
€€  !
.
€€! "
IdFinancialEntity
€€" 3
=
€€4 5
idFinancialEntity
€€6 G
;
€€G H
}
‹‹ 
}
›› 
)
›› 
;
›› "
importedEmployeeList
·· ,
.
··, -
ForEach
··- 4
(
··4 5
x
··5 6
=>
··7 9
{
‚‚ 
var
„„ 
person
„„  &
=
„„' (
mapper
„„) /
.
„„/ 0
Map
„„0 3
<
„„3 4
PersonModel
„„4 ?
>
„„? @
(
„„@ A
x
„„A B
)
„„B C
;
„„C D
var
‰‰ 
employee
‰‰  (
=
‰‰) *
mapper
‰‰+ 1
.
‰‰1 2
Map
‰‰2 5
<
‰‰5 6
EmployeeModel
‰‰6 C
>
‰‰C D
(
‰‰D E
x
‰‰E F
)
‰‰F G
;
‰‰G H
var
ÊÊ 
employeeFile
ÊÊ  ,
=
ÊÊ- .
mapper
ÊÊ/ 5
.
ÊÊ5 6
Map
ÊÊ6 9
<
ÊÊ9 :
EmployeeFile
ÊÊ: F
>
ÊÊF G
(
ÊÊG H
x
ÊÊH I
)
ÊÊI J
;
ÊÊJ K
employee
ÁÁ $
.
ÁÁ$ %
DateRegister
ÁÁ% 1
=
ÁÁ2 3
DateTime
ÁÁ4 <
.
ÁÁ< =
Now
ÁÁ= @
;
ÁÁ@ A
employee
ËË $
.
ËË$ %

DateUpdate
ËË% /
=
ËË0 1
DateTime
ËË2 :
.
ËË: ;
Now
ËË; >
;
ËË> ?
employee
ÈÈ $
.
ÈÈ$ %
IdUserRegister
ÈÈ% 3
=
ÈÈ4 5
$num
ÈÈ6 7
;
ÈÈ7 8
employee
ÍÍ $
.
ÍÍ$ %
IdUserUpdate
ÍÍ% 1
=
ÍÍ2 3
$num
ÍÍ4 5
;
ÍÍ5 6
employeeFile
ÎÎ (
.
ÎÎ( )
DateRegister
ÎÎ) 5
=
ÎÎ6 7
DateTime
ÎÎ8 @
.
ÎÎ@ A
Now
ÎÎA D
;
ÎÎD E
employeeFile
ÏÏ (
.
ÏÏ( )

DateUpdate
ÏÏ) 3
=
ÏÏ4 5
DateTime
ÏÏ6 >
.
ÏÏ> ?
Now
ÏÏ? B
;
ÏÏB C
employeeFile
ÌÌ (
.
ÌÌ( )
IdUserRegister
ÌÌ) 7
=
ÌÌ8 9
$num
ÌÌ: ;
;
ÌÌ; <
employeeFile
ÓÓ (
.
ÓÓ( )
IdUserUpdate
ÓÓ) 5
=
ÓÓ6 7
$num
ÓÓ8 9
;
ÓÓ9 :
person
 "
.
" #
Active
# )
=
* +
employee
, 4
.
4 5
IdState
5 <
==
= ?
$num
@ B
?
C D
true
E I
:
J K
false
L Q
;
Q R
bool
ÚÚ  
exist
ÚÚ! &
=
ÚÚ' ("
basePersonRepository
ÚÚ) =
.
ÚÚ= >
Exist
ÚÚ> C
(
ÚÚC D
x
ÚÚD E
=>
ÚÚF H
x
ÚÚI J
.
ÚÚJ K
	CodPerson
ÚÚK T
.
ÚÚT U
Equals
ÚÚU [
(
ÚÚ[ \
person
ÚÚ\ b
.
ÚÚb c
	CodPerson
ÚÚc l
)
ÚÚl m
)
ÚÚm n
.
ÚÚn o
Result
ÚÚo u
;
ÚÚu v
if
ÛÛ 
(
ÛÛ  
!
ÛÛ  !
exist
ÛÛ! &
)
ÛÛ& '
{
ÙÙ 
_logger
ıı  '
.
ıı' (
LogInformation
ıı( 6
(
ıı6 7
string
ıı7 =
.
ıı= >
Format
ıı> D
(
ııD E
$str
ııE y
,
ııy z
$"
ıı{ }
{
ıı} ~
personıı~ Ñ
.ııÑ Ö
	FirstNameııÖ é
}ııé è
$strııè ê
{ııê ë
personııë ó
.ııó ò

SecondNameııò ¢
}ıı¢ £
$strıı£ •
{ıı• ¶
personıı¶ ¨
.ıı¨ ≠
LastNameıı≠ µ
}ııµ ∂
$strıı∂ ∑
{ıı∑ ∏
personıı∏ æ
.ııæ ø
MotherLastNameııø Õ
}ııÕ Œ
"ııŒ œ
,ııœ –
compıı— ’
.ıı’ ÷
Descripcionıı÷ ·
)ıı· ‚
)ıı‚ „
;ıı„ ‰
try
ˆˆ  #
{
˜˜  !
_logger
¯¯$ +
.
¯¯+ ,
LogInformation
¯¯, :
(
¯¯: ;
$str
¯¯; [
)
¯¯[ \
;
¯¯\ ]"
basePersonRepository
˘˘$ 8
.
˘˘8 9
Add
˘˘9 <
(
˘˘< =
person
˘˘= C
)
˘˘C D
.
˘˘D E
Wait
˘˘E I
(
˘˘I J
)
˘˘J K
;
˘˘K L
}
˙˙  !
catch
˚˚  %
(
˚˚& '
	Exception
˚˚' 0
ex
˚˚1 3
)
˚˚3 4
{
¸¸  !
_logger
˝˝$ +
.
˝˝+ ,
LogError
˝˝, 4
(
˝˝4 5
$str
˝˝5 X
+
˝˝Y Z
ex
˝˝[ ]
.
˝˝] ^
Message
˝˝^ e
)
˝˝e f
;
˝˝f g
_logger
˛˛$ +
.
˛˛+ ,
LogError
˛˛, 4
(
˛˛4 5
$str
˛˛5 X
+
˛˛Y Z
ex
˛˛[ ]
.
˛˛] ^

StackTrace
˛˛^ h
)
˛˛h i
;
˛˛i j
}
ˇˇ  !
employee
ÅÅ  (
.
ÅÅ( )
IdPerson
ÅÅ) 1
=
ÅÅ2 3
person
ÅÅ4 :
.
ÅÅ: ;
Id
ÅÅ; =
;
ÅÅ= >
try
ÇÇ  #
{
ÉÉ  !
_logger
ÑÑ$ +
.
ÑÑ+ ,
LogInformation
ÑÑ, :
(
ÑÑ: ;
$str
ÑÑ; ]
)
ÑÑ] ^
;
ÑÑ^ _
employee
ÖÖ$ ,
.
ÖÖ, -
ExistsInExactus
ÖÖ- <
=
ÖÖ= >
true
ÖÖ? C
;
ÖÖC D
employee
ÜÜ$ ,
.
ÜÜ, -
IdCostcenter
ÜÜ- 9
=
ÜÜ: ;
$num
ÜÜ< =
;
ÜÜ= >
employee
áá$ ,
.
áá, -
	IdPayroll
áá- 6
=
áá7 8
$num
áá9 :
;
áá: ;$
baseEmployeeRepository
àà$ :
.
àà: ;
Add
àà; >
(
àà> ?
employee
àà? G
)
ààG H
.
ààH I
Wait
ààI M
(
ààM N
)
ààN O
;
ààO P
}
ââ  !
catch
ää  %
(
ää& '
	Exception
ää' 0
ex
ää1 3
)
ää3 4
{
ãã  !
_logger
åå$ +
.
åå+ ,
LogError
åå, 4
(
åå4 5
$str
åå5 Z
+
åå[ \
ex
åå] _
.
åå_ `
Message
åå` g
)
ååg h
;
ååh i
_logger
çç$ +
.
çç+ ,
LogError
çç, 4
(
çç4 5
$str
çç5 Z
+
çç[ \
ex
çç] _
.
çç_ `

StackTrace
çç` j
)
ççj k
;
ççk l
}
éé  !
employeeFile
ëë  ,
.
ëë, -

IdEmployee
ëë- 7
=
ëë8 9
employee
ëë: B
.
ëëB C
Id
ëëC E
;
ëëE F
try
îî  #
{
ïï  !
var
óó$ '
inseraddres
óó( 3
=
óó4 5
personRepository
óó6 F
.
óóF G)
InsertAddressPersonByUbigeo
óóG b
(
óób c
x
óód e
.
óóe f"
DIVISION_GEOGRAFICA2
óóf z
,
óóz {
x
óó| }
.
óó} ~
DIRECCIONEMPóó~ ä
,óóä ã
employeeóóå î
.óóî ï
IdPersonóóï ù
)óóù û
.óóû ü
Resultóóü •
;óó• ¶
}
òò  !
catch
ôô  %
(
ôô& '
	Exception
ôô' 0
ex
ôô1 3
)
ôô3 4
{
öö  !
_logger
õõ$ +
.
õõ+ ,
LogError
õõ, 4
(
õõ4 5
$str
õõ5 Z
+
õõ[ \
ex
õõ] _
.
õõ_ `
Message
õõ` g
)
õõg h
;
õõh i
_logger
úú$ +
.
úú+ ,
LogError
úú, 4
(
úú4 5
$str
úú5 Z
+
úú[ \
ex
úú] _
.
úú_ `

StackTrace
úú` j
)
úúj k
;
úúk l
}
ùù  !
try
üü  #
{
††  !
var
¢¢$ '
estudios
¢¢( 0
=
¢¢1 2
fullempleado
¢¢3 ?
.
¢¢? @

Academicos
¢¢@ J
.
¢¢J K
Where
¢¢K P
(
¢¢P Q
i
¢¢Q R
=>
¢¢S U
i
¢¢V W
.
¢¢W X
EMPLEADO
¢¢X `
==
¢¢a c
x
¢¢d e
.
¢¢e f
	CodPerson
¢¢f o
)
¢¢p q
.
¢¢q r
ToList
¢¢r x
(
¢¢x y
)
¢¢y z
;
¢¢z {
_logger
§§$ +
.
§§+ ,
LogInformation
§§, :
(
§§: ;
$"
§§; =
$str
§§= L
{
§§L M
estudios
§§M U
.
§§U V
Count
§§V [
(
§§[ \
)
§§\ ]
}
§§] ^
$str
§§^ n
{
§§n o
x
§§o p
.
§§p q
	CodPerson
§§q z
}
§§z {
$str
§§{ |
"
§§| }
)
§§} ~
;
§§~ 
foreach
ßß$ +
(
ßß, -
var
ßß- 0
est
ßß1 4
in
ßß5 7
estudios
ßß8 @
)
ßß@ A
{
®®$ %
var
™™( +
ins_estudio
™™, 7
=
™™8 9
personRepository
™™: J
.
™™J K"
InsertAcademicPerson
™™K _
(
™™_ `
est
™™` c
.
™™c d
TIPO_ACADEMICO
™™d r
,
™™r s
est
™™s v
.
™™v w
INSTITUCION™™w Ç
,™™Ç É
est™™É Ü
.™™Ü á
	CONCLUIDO™™á ê
,™™ê ë
est
´´, /
.
´´/ 0
FECHA_OBTENCION
´´0 ?
,
´´? @
est
´´@ C
.
´´C D
FECHA_VENCIMIENTO
´´D U
,
´´U V
est
´´V Y
.
´´Y Z
U_PROFESION
´´Z e
,
´´e f
est
´´f i
.
´´i j
TITULO
´´j p
,
´´p q
x
´´q r
.
´´r s
	CodPerson
´´s |
)
´´| }
.
´´} ~
Result´´~ Ñ
;´´Ñ Ö
}
¨¨$ %
}
ÆÆ  !
catch
ØØ  %
(
ØØ& '
	Exception
ØØ' 0
ex
ØØ1 3
)
ØØ3 4
{
∞∞  !
_logger
±±$ +
.
±±+ ,
LogError
±±, 4
(
±±4 5
$str
±±5 Z
+
±±[ \
ex
±±] _
.
±±_ `
Message
±±` g
)
±±g h
;
±±h i
_logger
≤≤$ +
.
≤≤+ ,
LogError
≤≤, 4
(
≤≤4 5
$str
≤≤5 Z
+
≤≤[ \
ex
≤≤] _
.
≤≤_ `

StackTrace
≤≤` j
)
≤≤j k
;
≤≤k l
}
≥≥  !
try
µµ  #
{
∂∂  !
List
∏∏$ (
<
∏∏( )
string
∏∏) /
>
∏∏/ 0
lstTelefonos
∏∏1 =
=
∏∏> ?
new
∏∏@ C
List
∏∏D H
<
∏∏H I
string
∏∏I O
>
∏∏O P
(
∏∏P Q
)
∏∏Q R
;
∏∏R S
if
ππ$ &
(
ππ' (
!
ππ( )
string
ππ) /
.
ππ/ 0
IsNullOrEmpty
ππ0 =
(
ππ= >
x
ππ> ?
.
ππ? @
	TELEFONO1
ππ@ I
)
ππI J
&&
ππK M
x
ππN O
.
ππO P
	TELEFONO1
ππP Y
!=
ππY [
$str
ππ\ _
)
ππ_ `
{
∫∫$ %
lstTelefonos
ªª( 4
.
ªª4 5
Add
ªª5 8
(
ªª8 9
x
ªª9 :
.
ªª: ;
	TELEFONO1
ªª; D
)
ªªD E
;
ªªE F
}
ºº$ %
if
ΩΩ$ &
(
ΩΩ' (
!
ΩΩ( )
string
ΩΩ) /
.
ΩΩ/ 0
IsNullOrEmpty
ΩΩ0 =
(
ΩΩ= >
x
ΩΩ> ?
.
ΩΩ? @
	TELEFONO2
ΩΩ@ I
)
ΩΩI J
&&
ΩΩK M
x
ΩΩN O
.
ΩΩO P
	TELEFONO2
ΩΩP Y
!=
ΩΩZ \
$str
ΩΩ] `
)
ΩΩ` a
{
ææ$ %
lstTelefonos
øø( 4
.
øø4 5
Add
øø5 8
(
øø8 9
x
øø9 :
.
øø: ;
	TELEFONO2
øø; D
)
øøD E
;
øøE F
}
¿¿$ %
if
¡¡$ &
(
¡¡' (
!
¡¡( )
string
¡¡) /
.
¡¡/ 0
IsNullOrEmpty
¡¡0 =
(
¡¡= >
x
¡¡> ?
.
¡¡? @
	TELEFONO3
¡¡@ I
)
¡¡I J
&&
¡¡K M
x
¡¡N O
.
¡¡O P
	TELEFONO3
¡¡P Y
!=
¡¡Z \
$str
¡¡] `
)
¡¡` a
{
¬¬$ %
lstTelefonos
√√( 4
.
√√4 5
Add
√√5 8
(
√√8 9
x
√√9 :
.
√√: ;
	TELEFONO3
√√; D
)
√√D E
;
√√E F
}
ƒƒ$ %
if
∆∆$ &
(
∆∆' (
lstTelefonos
∆∆( 4
.
∆∆4 5
Any
∆∆5 8
(
∆∆8 9
)
∆∆9 :
)
∆∆: ;
{
««$ %
foreach
……( /
(
……0 1
var
……1 4
phonestring
……5 @
in
……A C
lstTelefonos
……D P
)
……P Q
{
  ( )
Phone
ÀÀ, 1

phoneModel
ÀÀ2 <
=
ÀÀ= >
new
ÀÀ? B
Phone
ÀÀC H
(
ÀÀH I
)
ÀÀI J
;
ÀÀJ K

phoneModel
ÃÃ, 6
.
ÃÃ6 7
IdPerson
ÃÃ7 ?
=
ÃÃ@ A
person
ÃÃB H
.
ÃÃH I
Id
ÃÃI K
;
ÃÃK L

phoneModel
ÕÕ, 6
.
ÕÕ6 7
DateRegister
ÕÕ7 C
=
ÕÕD E
DateTime
ÕÕF N
.
ÕÕN O
Now
ÕÕO R
;
ÕÕR S

phoneModel
ŒŒ, 6
.
ŒŒ6 7
UserRegister
ŒŒ7 C
=
ŒŒD E
$num
ŒŒF G
;
ŒŒG H

phoneModel
œœ, 6
.
œœ6 7
phone
œœ7 <
=
œœ= >
phonestring
œœ? J
;
œœJ K!
basePhoneRepository
––, ?
.
––? @
Add
––@ C
(
––C D

phoneModel
––D N
)
––N O
.
––O P
Wait
––P T
(
––T U
)
––U V
;
––V W
}
““( )
}
””$ %
}
’’  !
catch
÷÷  %
(
÷÷& '
	Exception
÷÷' 0
ex
÷÷1 3
)
÷÷3 4
{
◊◊  !
_logger
ÿÿ$ +
.
ÿÿ+ ,
LogError
ÿÿ, 4
(
ÿÿ4 5
$str
ÿÿ5 _
+
ÿÿ` a
ex
ÿÿb d
.
ÿÿd e
Message
ÿÿe l
)
ÿÿl m
;
ÿÿm n
_logger
ŸŸ$ +
.
ŸŸ+ ,
LogError
ŸŸ, 4
(
ŸŸ4 5
$str
ŸŸ5 _
+
ŸŸ` a
ex
ŸŸb d
.
ŸŸd e

StackTrace
ŸŸe o
)
ŸŸo p
;
ŸŸp q
}
⁄⁄  !
try
››  #
{
ﬁﬁ  !
var
‡‡$ '
experiencias
‡‡( 4
=
‡‡5 6
fullempleado
‡‡7 C
.
‡‡C D
Experiencias
‡‡D P
.
‡‡P Q
Where
‡‡Q V
(
‡‡V W
i
‡‡W X
=>
‡‡Y [
i
‡‡\ ]
.
‡‡] ^
EMPLEADO
‡‡^ f
==
‡‡g i
x
‡‡j k
.
‡‡k l
	CodPerson
‡‡l u
)
‡‡u v
.
‡‡v w
ToList
‡‡w }
(
‡‡} ~
)
‡‡~ 
;‡‡ Ä
foreach
‚‚$ +
(
‚‚, -
var
‚‚- 0
exp
‚‚1 4
in
‚‚5 7
experiencias
‚‚8 D
)
‚‚D E
{
„„$ %
var
‰‰( +
dtojob
‰‰, 2
=
‰‰3 4
new
‰‰5 8
HumanManagement
‰‰9 H
.
‰‰H I
Domain
‰‰I O
.
‰‰O P
Employee
‰‰P X
.
‰‰X Y
Dto
‰‰Y \
.
‰‰\ ]
InsertJobDto
‰‰] i
(
‰‰i j
)
‰‰j k
;
‰‰k l
dtojob
ÊÊ( .
.
ÊÊ. /
namejob
ÊÊ/ 6
=
ÊÊ7 8
exp
ÊÊ9 <
.
ÊÊ< =
EMPRESA
ÊÊ= D
;
ÊÊD E
dtojob
ÁÁ( .
.
ÁÁ. /
nid_employee
ÁÁ/ ;
=
ÁÁ< =
employee
ÁÁ> F
.
ÁÁF G
Id
ÁÁG I
;
ÁÁI J
dtojob
ËË( .
.
ËË. /
positionjob
ËË/ :
=
ËË; <
exp
ËË= @
.
ËË@ A
PUESTO
ËËA G
;
ËËG H
dtojob
ÈÈ( .
.
ÈÈ. /
	sfunction
ÈÈ/ 8
=
ÈÈ9 :
exp
ÈÈ; >
.
ÈÈ> ?
	FUNCIONES
ÈÈ? H
;
ÈÈH I
dtojob
ÍÍ( .
.
ÍÍ. /
timejob
ÍÍ/ 6
=
ÍÍ7 8
string
ÍÍ9 ?
.
ÍÍ? @
Empty
ÍÍ@ E
;
ÍÍE F 
employeeRepository
ÏÏ( :
.
ÏÏ: ;
	InsertJob
ÏÏ; D
(
ÏÏD E
dtojob
ÏÏE K
)
ÏÏK L
.
ÏÏL M
Wait
ÏÏM Q
(
ÏÏQ R
)
ÏÏR S
;
ÏÏS T
}
ÌÌ$ %
}
ÔÔ  !
catch
  %
(
& '
	Exception
' 0
ex
1 3
)
3 4
{
ÒÒ  !
_logger
ÚÚ$ +
.
ÚÚ+ ,
LogError
ÚÚ, 4
(
ÚÚ4 5
$str
ÚÚ5 _
+
ÚÚ` a
ex
ÚÚb d
.
ÚÚd e
Message
ÚÚe l
)
ÚÚl m
;
ÚÚm n
_logger
ÛÛ$ +
.
ÛÛ+ ,
LogError
ÛÛ, 4
(
ÛÛ4 5
$str
ÛÛ5 _
+
ÛÛ` a
ex
ÛÛb d
.
ÛÛd e

StackTrace
ÛÛe o
)
ÛÛo p
;
ÛÛp q
}
ÙÙ  !
try
˜˜  #
{
¯¯  !
var
˙˙$ '
familialist
˙˙( 3
=
˙˙4 5
fullempleado
˙˙6 B
.
˙˙B C
Familia
˙˙C J
.
˙˙J K
Where
˙˙K P
(
˙˙P Q
i
˙˙Q R
=>
˙˙S U
i
˙˙V W
.
˙˙W X
EMPLEADO
˙˙X `
==
˙˙a c
x
˙˙d e
.
˙˙e f
	CodPerson
˙˙f o
)
˙˙o p
.
˙˙p q
ToList
˙˙q w
(
˙˙w x
)
˙˙x y
;
˙˙y z
foreach
˝˝$ +
(
˝˝, -
var
˝˝- 0
familia
˝˝1 8
in
˝˝9 ;
familialist
˝˝< G
)
˝˝G H
{
˛˛$ % 
employeeRepository
ÄÄ( :
.
ÄÄ: ;
	InsertSon
ÄÄ; D
(
ÄÄD E
new
ÄÄE H
HumanManagement
ÄÄI X
.
ÄÄX Y
Domain
ÄÄY _
.
ÄÄ_ `
Employee
ÄÄ` h
.
ÄÄh i
Dto
ÄÄi l
.
ÄÄl m
InsertSonDto
ÄÄm y
(
ÄÄy z
)
ÄÄz {
{
ÅÅ( )
ddateofbirth
ÇÇ, 8
=
ÇÇ9 :
familia
ÇÇ; B
.
ÇÇB C
FECHA_NACIMIENTO
ÇÇC S
==
ÇÇT V
null
ÇÇW [
?
ÇÇ\ ]
DateTime
ÇÇ^ f
.
ÇÇf g
Now
ÇÇg j
:
ÇÇk l
familia
ÇÇm t
.
ÇÇt u
FECHA_NACIMIENTOÇÇu Ö
.ÇÇÖ Ü
ValueÇÇÜ ã
,ÇÇã å
sfamilytype
ÉÉ, 7
=
ÉÉ7 8
familia
ÉÉ9 @
.
ÉÉ@ A
VINCULO
ÉÉA H
,
ÉÉH I
	sfullname
ÑÑ, 5
=
ÑÑ6 7
familia
ÑÑ8 ?
.
ÑÑ? @
NOMBRE
ÑÑ@ F
,
ÑÑF G
	slastname
ÖÖ, 5
=
ÖÖ6 7
familia
ÖÖ8 ?
.
ÖÖ? @
PATERNO
ÖÖ@ G
,
ÖÖG H
smotherslastname
ÜÜ, <
=
ÜÜ= >
familia
ÜÜ? F
.
ÜÜF G
MATERNO
ÜÜG N
,
ÜÜN O
nid_employee
áá, 8
=
áá9 :
employee
áá; C
.
ááC D
Id
ááD F
}
ââ( )
)
ââ) *
.
ââ* +
Wait
ââ+ /
(
ââ/ 0
)
ââ0 1
;
ââ1 2
}
ää$ %
}
ãã  !
catch
åå  %
(
åå& '
	Exception
åå' 0
ex
åå1 3
)
åå3 4
{
çç  !
_logger
éé$ +
.
éé+ ,
LogError
éé, 4
(
éé4 5
$str
éé5 _
+
éé` a
ex
ééb d
.
ééd e
Message
éée l
)
éél m
;
éém n
_logger
èè$ +
.
èè+ ,
LogError
èè, 4
(
èè4 5
$str
èè5 _
+
èè` a
ex
èèb d
.
èèd e

StackTrace
èèe o
)
èèo p
;
èèp q
}
êê  !
try
ïï  #
{
ññ  !
_logger
óó$ +
.
óó+ ,
LogInformation
óó, :
(
óó: ;
$str
óó; a
)
óóa b
;
óób c(
baseEmployeeFileRepository
òò$ >
.
òò> ?
Add
òò? B
(
òòB C
employeeFile
òòC O
)
òòO P
.
òòP Q
Wait
òòQ U
(
òòU V
)
òòV W
;
òòW X
}
ôô  !
catch
öö  %
(
öö& '
	Exception
öö' 0
ex
öö1 3
)
öö3 4
{
õõ  !
_logger
úú$ +
.
úú+ ,
LogError
úú, 4
(
úú4 5
$str
úú5 _
+
úú` a
ex
úúb d
.
úúd e
Message
úúe l
)
úúl m
;
úúm n
_logger
ùù$ +
.
ùù+ ,
LogError
ùù, 4
(
ùù4 5
$str
ùù5 _
+
ùù` a
ex
ùùb d
.
ùùd e

StackTrace
ùùe o
)
ùùo p
;
ùùp q
}
ûû  !
User
¢¢  $
user
¢¢% )
=
¢¢* +
new
¢¢, /
User
¢¢0 4
{
££  !
UserName
§§$ ,
=
§§- .
person
§§/ 5
.
§§5 6
	CodPerson
§§6 ?
,
§§? @
Password
••$ ,
=
••- .
person
••/ 5
.
••5 6
	CodPerson
••6 ?
,
••? @
IdPerson
¶¶$ ,
=
¶¶- .
person
¶¶/ 5
.
¶¶5 6
Id
¶¶6 8
,
¶¶8 9
Active
ßß$ *
=
ßß+ ,
person
ßß- 3
.
ßß3 4
Active
ßß4 :
,
ßß: ;
State
®®$ )
=
®®* +
$num
®®, -
}
©©  !
;
©©! "
try
´´  #
{
¨¨  !
user
ÆÆ$ (
.
ÆÆ( ) 
SetEncryptPassword
ÆÆ) ;
(
ÆÆ; <
cryptography
ÆÆ< H
)
ÆÆH I
;
ÆÆI J
_logger
∞∞$ +
.
∞∞+ ,
LogInformation
∞∞, :
(
∞∞: ;
$str
∞∞; Y
)
∞∞Y Z
;
∞∞Z [ 
baseUserRepository
±±$ 6
.
±±6 7
Add
±±7 :
(
±±: ;
user
±±; ?
)
±±? @
.
±±@ A
Wait
±±A E
(
±±E F
)
±±F G
;
±±G H
}
≤≤  !
catch
≥≥  %
(
≥≥& '
	Exception
≥≥' 0
ex
≥≥1 3
)
≥≥3 4
{
¥¥  !
_logger
µµ$ +
.
µµ+ ,
LogError
µµ, 4
(
µµ4 5
$str
µµ5 V
+
µµW X
ex
µµY [
.
µµ[ \
Message
µµ\ c
)
µµc d
;
µµd e
_logger
∂∂$ +
.
∂∂+ ,
LogError
∂∂, 4
(
∂∂4 5
$str
∂∂5 V
+
∂∂W X
ex
∂∂Y [
.
∂∂[ \

StackTrace
∂∂\ f
)
∂∂f g
;
∂∂g h
}
∑∑  !
UserMailDto
ππ  +
userMailDto
ππ, 7
=
ππ8 9
new
ππ: =
UserMailDto
ππ> I
{
∫∫  !
UserName
ªª$ ,
=
ªª- .
user
ªª/ 3
.
ªª3 4
UserName
ªª4 <
,
ªª< =
Password
ºº$ ,
=
ºº- .
person
ºº/ 5
.
ºº5 6
	CodPerson
ºº6 ?
,
ºº? @
Email
ΩΩ$ )
=
ΩΩ* +
person
ΩΩ, 2
.
ΩΩ2 3
Email
ΩΩ3 8
,
ΩΩ8 9
FullName
ææ$ ,
=
ææ- .
$"
ææ/ 1
{
ææ1 2
person
ææ2 8
.
ææ8 9
	FirstName
ææ9 B
}
ææB C
$str
ææC D
{
ææD E
person
ææE K
.
ææK L

SecondName
ææL V
}
ææV W
$str
ææW Y
{
ææY Z
person
ææZ `
.
ææ` a
LastName
ææa i
}
ææi j
$str
ææj k
{
ææk l
person
ææl r
.
æær s
MotherLastNameææs Å
}ææÅ Ç
"ææÇ É
}
øø  !
;
øø! "
userMailDtoList
¿¿  /
.
¿¿/ 0
Add
¿¿0 3
(
¿¿3 4
userMailDto
¿¿4 ?
)
¿¿? @
;
¿¿@ A
}
¡¡ 
else
¬¬  
{
¬¬! "
_logger
√√  '
.
√√' (
LogInformation
√√( 6
(
√√6 7
$str
√√7 X
+
√√Y Z
person
√√[ a
.
√√a b
	CodPerson
√√b k
)
√√k l
;
√√l m
}
ƒƒ 
}
∆∆ 
)
∆∆ 
;
∆∆ 
}
»» 
}
…… 
catch
   
(
   
	Exception
    
ex
  ! #
)
  # $
{
ÀÀ 
_logger
ÕÕ 
.
ÕÕ 
LogError
ÕÕ $
(
ÕÕ$ %
$str
ÕÕ% 8
+
ÕÕ9 :
ex
ÕÕ; =
.
ÕÕ= >
Message
ÕÕ> E
)
ÕÕE F
;
ÕÕF G
_logger
ŒŒ 
.
ŒŒ 
LogError
ŒŒ $
(
ŒŒ$ %
$str
ŒŒ% 8
+
ŒŒ9 :
ex
ŒŒ; =
.
ŒŒ= >

StackTrace
ŒŒ> H
)
ŒŒH I
;
ŒŒI J
}
œœ 
}
—— 
_logger
‘‘ 
.
‘‘ 
LogInformation
‘‘ "
(
‘‘" #
$str
‘‘# 9
)
‘‘9 :
;
‘‘: ;
}
’’ 	
private
◊◊ 
void
◊◊ 
SendMail
◊◊ 
(
◊◊ 
)
◊◊ 
{
ÿÿ 	
_logger
ŸŸ 
.
ŸŸ 
LogInformation
ŸŸ "
(
ŸŸ" #
$str
ŸŸ# >
)
ŸŸ> ?
;
ŸŸ? @
userMailDtoList
⁄⁄ 
.
⁄⁄ 
ForEach
⁄⁄ #
(
⁄⁄# $
x
⁄⁄$ %
=>
⁄⁄& (
{
€€ 
try
‹‹ 
{
›› 
var
ﬁﬁ 
userRegistered
ﬁﬁ &
=
ﬁﬁ' (
new
ﬁﬁ) ,
UserRegistered
ﬁﬁ- ;
(
ﬁﬁ; <
x
ﬁﬁ< =
)
ﬁﬁ= >
;
ﬁﬁ> ?
MailSenderUser
·· "
mailSenderUser
··# 1
=
··2 3
new
··4 7
MailSenderUser
··8 F
(
··F G

htmlReader
··G Q
,
··Q R
userRegistered
··S a
.
··a b
UserMail
··b j
)
··j k
;
··k l
var
‚‚ 
objMail
‚‚ 
=
‚‚  !
mailSenderUser
‚‚" 0
.
‚‚0 1
GetMail
‚‚1 8
(
‚‚8 9
)
‚‚9 :
;
‚‚: ;
objMail
„„ 
.
„„ 
From
„„  
=
„„! "
Configuration
„„# 0
[
„„0 1
$str
„„1 S
]
„„S T
.
„„T U
ToString
„„U ]
(
„„] ^
)
„„^ _
;
„„_ `
objMail
‰‰ 
.
‰‰ 
FromName
‰‰ $
=
‰‰% &
Configuration
‰‰' 4
[
‰‰4 5
$str
‰‰5 W
]
‰‰W X
.
‰‰X Y
ToString
‰‰Y a
(
‰‰a b
)
‰‰b c
;
‰‰c d
_logger
ÊÊ 
.
ÊÊ 
LogInformation
ÊÊ *
(
ÊÊ* +
string
ÊÊ+ 1
.
ÊÊ1 2
Format
ÊÊ2 8
(
ÊÊ8 9
$str
ÊÊ9 P
,
ÊÊP Q
objMail
ÊÊR Y
.
ÊÊY Z
To
ÊÊZ \
[
ÊÊ\ ]
$num
ÊÊ] ^
]
ÊÊ^ _
.
ÊÊ_ `
ToString
ÊÊ` h
(
ÊÊh i
)
ÊÊi j
)
ÊÊj k
)
ÊÊk l
;
ÊÊl m
mailRepository
ÁÁ "
.
ÁÁ" #
SendMail
ÁÁ# +
(
ÁÁ+ ,
objMail
ÁÁ, 3
)
ÁÁ3 4
;
ÁÁ4 5
_logger
ËË 
.
ËË 
LogInformation
ËË *
(
ËË* +
$str
ËË+ M
)
ËËM N
;
ËËN O
}
ÈÈ 
catch
ÍÍ 
(
ÍÍ 
	Exception
ÍÍ  
ex
ÍÍ! #
)
ÍÍ$ %
{
ÎÎ 
_logger
ÏÏ 
.
ÏÏ 
LogError
ÏÏ $
(
ÏÏ$ %
$str
ÏÏ% :
+
ÏÏ; <
ex
ÏÏ= ?
.
ÏÏ? @
Message
ÏÏ@ G
)
ÏÏG H
;
ÏÏH I
_logger
ÌÌ 
.
ÌÌ 
LogError
ÌÌ $
(
ÌÌ$ %
$str
ÌÌ% :
+
ÌÌ; <
ex
ÌÌ= ?
.
ÌÌ? @

StackTrace
ÌÌ@ J
)
ÌÌJ K
;
ÌÌK L
}
ÓÓ 
}
 
)
 
;
 
_logger
ÒÒ 
.
ÒÒ 
LogInformation
ÒÒ "
(
ÒÒ" #
$str
ÒÒ# ;
)
ÒÒ; <
;
ÒÒ< =
}
ÚÚ 	
public
˜˜ 
void
˜˜ 
Export
˜˜ 
(
˜˜ 
)
˜˜ 
{
¯¯ 	
var
˙˙ 
CompaniesList
˙˙ 
=
˙˙ 
empresaRepository
˙˙  1
.
˙˙1 2
GetAll
˙˙2 8
(
˙˙8 9
)
˙˙9 :
.
˙˙: ;
Result
˙˙; A
;
˙˙A B
var
¸¸ "
empleadosporexportar
¸¸ $
=
¸¸% & 
employeeRepository
¸¸' 9
.
¸¸9 :&
EmployeeForSendToExactus
¸¸: R
(
¸¸R S
)
¸¸S T
.
¸¸T U
Result
¸¸U [
;
¸¸[ \
foreach
ÅÅ 
(
ÅÅ 
var
ÅÅ 
emp
ÅÅ 
in
ÅÅ "
empleadosporexportar
ÅÅ  4
)
ÅÅ4 5
{
ÇÇ 
var
ÑÑ 
person
ÑÑ 
=
ÑÑ "
basePersonRepository
ÑÑ 1
.
ÑÑ1 2
Find
ÑÑ2 6
(
ÑÑ6 7
emp
ÑÑ7 :
.
ÑÑ: ;
IdPerson
ÑÑ; C
)
ÑÑC D
.
ÑÑD E
Result
ÑÑE K
;
ÑÑK L
if
ÖÖ 
(
ÖÖ 
string
ÖÖ 
.
ÖÖ 
IsNullOrEmpty
ÖÖ (
(
ÖÖ( )
person
ÖÖ) /
.
ÖÖ/ 0
	CodPerson
ÖÖ0 9
)
ÖÖ9 :
)
ÖÖ: ;
{
ÜÜ 
continue
áá 
;
áá 
}
àà &
ExactusEmpleadoInsertDto
ää (
	dtoinsert
ää) 2
=
ää3 4
new
ää5 8&
ExactusEmpleadoInsertDto
ää9 Q
(
ääQ R
)
ääR S
;
ääS T!
ExactusEALLEmpleado
åå #
modelEmpleado
åå$ 1
=
åå2 3
new
åå4 7!
ExactusEALLEmpleado
åå8 K
(
ååK L
)
ååL M
;
ååM N
var
èè 
cargo
èè 
=
èè !
baseCargoRepository
èè /
.
èè/ 0
Find
èè0 4
(
èè4 5
emp
èè5 8
.
èè8 9

IdPosition
èè9 C
)
èèC D
.
èèD E
Result
èèE K
;
èèK L
var
êê 
area
êê 
=
êê  
baseAreaRepository
êê -
.
êê- .
Find
êê. 2
(
êê2 3
cargo
êê3 8
.
êê8 9
IdArea
êê9 ?
)
êê? @
.
êê@ A
Result
êêA G
;
êêG H
	dtoinsert
ìì 
.
ìì 
Scheme
ìì  
=
ìì! "
CompaniesList
ìì# 0
.
ìì0 1
Where
ìì1 6
(
ìì6 7
i
ìì7 8
=>
ìì9 ;
i
ìì< =
.
ìì= >
Id
ìì> @
==
ììA C
emp
ììD G
.
ììG H
	IdCompany
ììH Q
)
ììQ R
.
ììR S
Select
ììS Y
(
ììY Z
i
ììZ [
=>
ìì\ ^
i
ìì_ `
.
ìì` a
Schema
ììa g
)
ììg h
.
ììh i
FirstOrDefault
ììi w
(
ììw x
)
ììx y
;
ììy z
	dtoinsert
îî 
.
îî 
EMPLEADO
îî "
=
îî# $
emp
îî% (
.
îî( )
CodEmployee
îî) 4
;
îî4 5
	dtoinsert
ïï 
.
ïï 
NOMBRE
ïï  
=
ïï! "
person
ïï# )
.
ïï) *
	FirstName
ïï* 3
+
ïï4 5
$str
ïï6 9
+
ïï: ;
person
ïï< B
.
ïïB C

SecondName
ïïC M
??
ïïN P
$str
ïïQ S
+
ïïT U
$str
ïïV Y
+
ïïZ [
person
ïï\ b
.
ïïb c
LastName
ïïc k
+
ïïl m
$str
ïïn q
+
ïïr s
person
ïït z
.
ïïz {
MotherLastNameïï{ â
;ïïâ ä
	dtoinsert
ññ 
.
ññ 
SEXO
ññ 
=
ññ  
person
ññ! '
.
ññ' (
IdSex
ññ( -
==
ññ. 0
$num
ññ1 3
?
ññ4 5
$str
ññ6 9
:
ññ: ;
$str
ññ< ?
;
ññ? @
	dtoinsert
óó 
.
óó 
ESTADO_EMPLEADO
óó )
=
óó* +
$str
óó, 2
;
óó2 3
	dtoinsert
òò 
.
òò 
ACTIVO
òò  
=
òò! "
$str
òò# &
;
òò& '
	dtoinsert
ôô 
.
ôô 
FECHA_INGRESO
ôô '
=
ôô( )
emp
ôô* -
.
ôô- .
AdmissionDate
ôô. ;
;
ôô; <
	dtoinsert
öö 
.
öö 
DEPARTAMENTO
öö &
=
öö' (
area
öö) -
.
öö- .

CodExactus
öö. 8
==
öö9 ;
null
öö< @
?
ööA B
$str
ööC G
:
ööH I
area
ööJ N
.
ööN O

CodExactus
ööO Y
;
ööY Z
	dtoinsert
õõ 
.
õõ 
PUESTO
õõ  
=
õõ! "
cargo
õõ# (
.
õõ( )

CodExactus
õõ) 3
==
õõ4 6
null
õõ7 ;
?
õõ< =
$str
õõ> B
:
õõC D
cargo
õõE J
.
õõJ K

CodExactus
õõK U
;
õõU V
	dtoinsert
úú 
.
úú 
PLAZA
úú 
=
úú  !
$str
úú" &
;
úú& '
	dtoinsert
ùù 
.
ùù 
NOMINA
ùù  
=
ùù! "
$str
ùù# '
;
ùù' (
	dtoinsert
ûû 
.
ûû 
CENTRO_COSTO
ûû &
=
ûû' (
$str
ûû) -
;
ûû- .
	dtoinsert
üü 
.
üü 
FECHA_NACIMIENTO
üü *
=
üü+ ,
person
üü- 3
.
üü3 4
	BirthDate
üü4 =
==
üü= ?
null
üü@ D
?
üüE F
DateTime
üüH P
.
üüP Q
Now
üüQ T
:
üüV W
person
üüX ^
.
üü^ _
	BirthDate
üü_ h
.
üüh i
Value
üüi n
;
üün o
	dtoinsert
°° 
.
°° 
DIRECCION_HAB
°° (
=
°°) *
$str°°+ œ
;°°œ –
	dtoinsert
¢¢ 
.
¢¢ 
	UBICACION
¢¢ #
=
¢¢$ %
$str
¢¢& -
;
¢¢- .
	dtoinsert
§§ 
.
§§ 
PAIS
§§ 
=
§§  
$str
§§! &
;
§§& '
	dtoinsert
•• 
.
•• 
ESTADO_CIVIL
•• &
=
••' (
$str
••) ,
;
••, -
	dtoinsert
¶¶ 
.
¶¶ 
VACS_PENDIENTES
¶¶ )
=
¶¶* +
$num
¶¶, -
;
¶¶- .
	dtoinsert
ßß 
.
ßß 
VACS_ULT_CALCULO
ßß *
=
ßß+ ,
DateTime
ßß- 5
.
ßß5 6
Now
ßß6 9
;
ßß9 :
	dtoinsert
®® 
.
®®  
SALARIO_REFERENCIA
®® ,
=
®®- .
$num
®®/ 0
;
®®0 1
	dtoinsert
©© 
.
©© 

FORMA_PAGO
©© $
=
©©% &
$str
©©' *
;
©©* +
	dtoinsert
™™ 
.
™™ 
HORARIO
™™ !
=
™™" #
$str
™™$ *
;
™™* +
	dtoinsert
´´ 
.
´´ 
FECHA_NO_PAGO
´´ '
=
´´( )
DateTime
´´* 2
.
´´2 3
Now
´´3 6
;
´´6 7
	dtoinsert
¨¨ 
.
¨¨  
TIPO_SALARIO_AUMEN
¨¨ ,
=
¨¨- .
$str
¨¨/ 2
;
¨¨2 3
	dtoinsert
≠≠ 
.
≠≠ 
VACS_ADICIONALES
≠≠ *
=
≠≠+ ,
$num
≠≠- .
;
≠≠. /
	dtoinsert
ÆÆ 
.
ÆÆ 
NoteExistsFlag
ÆÆ (
=
ÆÆ) *
$num
ÆÆ+ ,
;
ÆÆ, -
	dtoinsert
ØØ 
.
ØØ 

RecordDate
ØØ $
=
ØØ% &
DateTime
ØØ' /
.
ØØ/ 0
Now
ØØ0 3
;
ØØ3 4
	dtoinsert
∞∞ 
.
∞∞ 

RowPointer
∞∞ $
=
∞∞% &
Guid
∞∞' +
.
∞∞+ ,
NewGuid
∞∞, 3
(
∞∞3 4
)
∞∞4 5
;
∞∞5 6
	dtoinsert
±± 
.
±± 
	CreatedBy
±± #
=
±±$ %
$str
±±& *
;
±±* +
	dtoinsert
≤≤ 
.
≤≤ 
	UpdatedBy
≤≤ #
=
≤≤$ %
$str
≤≤& *
;
≤≤* +
	dtoinsert
≥≥ 
.
≥≥ 

CreateDate
≥≥ $
=
≥≥% &
DateTime
≥≥' /
.
≥≥/ 0
Now
≥≥0 3
;
≥≥3 4
try
ﬁﬁ 
{
ﬂﬂ 
var
‚‚ 
ninsert
‚‚ !
=
‚‚" #'
exactusEmpleadoRepository
‚‚$ =
.
‚‚= >
InsertEmpleado
‚‚> L
(
‚‚L M
	dtoinsert
‚‚M V
)
‚‚V W
.
‚‚W X
Result
‚‚X ^
;
‚‚^ _
}
‰‰ 
catch
ÂÂ 
(
ÂÂ 
	Exception
ÂÂ  
ex
ÂÂ! #
)
ÂÂ# $
{
ÊÊ 
throw
ËË 
;
ËË 
}
ÈÈ 
}
ÌÌ 
}
ÔÔ 	
}
 
}ÒÒ É
ÄD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Nomina\IServices\IExactusNominaService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Nomina0 6
.6 7
	IServices7 @
{ 
public		 

	interface		 !
IExactusNominaService		 *
{

 
void 
Import 
( 
) 
; 
void 
ImportLiquidacion 
( 
)  
;  !
} 
} ﬂ◊
~D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Nomina\Services\ExactusNominaService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Nomina0 6
.6 7
Services7 ?
{ 
public 

class  
ExactusNominaService %
:& '!
IExactusNominaService( =
{ 
private 
readonly 
IEmpresaRepository +
empresaRepository, =
;= >
private 
readonly $
IExactusNominaRepository 1#
exactusNominaRepository2 I
;I J
private 
readonly 
IBaseRepository (
<( )
SalaryConcept) 6
>6 7'
baseSalaryConceptRepository8 S
;S T
private 
readonly 
IBaseRepository (
<( )
SalaryPayrollDet) 9
>9 :*
baseSalaryPayrollDetRepository; Y
;Y Z
private 
readonly '
IExactusNominaCabRepository 4&
exactusNominaCabRepository5 O
;O P
private 
readonly 
IBaseRepository (
<( )
SalaryPayrollCab) 9
>9 :*
baseSalaryPayrollCabRepository; Y
;Y Z
private 
readonly 
ILogger  
<  ! 
ExactusNominaService! 5
>5 6
_logger7 >
;> ?
private   
readonly   !
ISalaryBandRepository   . 
salaryBandRepository  / C
;  C D
public##  
ExactusNominaService## #
(### $
IEmpresaRepository##$ 6
empresaRepository##7 H
,##H I
IBaseRepository$$ 
<$$ 
SalaryConcept$$ )
>$$) *'
baseSalaryConceptRepository$$+ F
,$$F G$
IExactusNominaRepository%% $#
exactusNominaRepository%%% <
,%%< =
IBaseRepository&& 
<&& 
SalaryPayrollDet&& ,
>&&, -*
baseSalaryPayrollDetRepository&&. L
,&&L M'
IExactusNominaCabRepository'' '&
exactusNominaCabRepository''( B
,''B C
IBaseRepository(( 
<(( 
SalaryPayrollCab(( ,
>((, -*
baseSalaryPayrollCabRepository((. L
,((L M
ILogger)) 
<))  
ExactusNominaService)) (
>))( )
_logger))* 1
,))1 2!
ISalaryBandRepository** ! 
salaryBandRepository**" 6
)++ 
{,, 	
this-- 
.-- 
empresaRepository-- "
=--# $
empresaRepository--% 6
;--6 7
this.. 
... '
baseSalaryConceptRepository.. ,
=..- .'
baseSalaryConceptRepository../ J
;..J K
this// 
.// #
exactusNominaRepository// (
=//) *#
exactusNominaRepository//+ B
;//B C
this00 
.00 *
baseSalaryPayrollDetRepository00 /
=000 1*
baseSalaryPayrollDetRepository002 P
;00P Q
this11 
.11 &
exactusNominaCabRepository11 +
=11, -&
exactusNominaCabRepository11. H
;11H I
this22 
.22 *
baseSalaryPayrollCabRepository22 /
=220 1*
baseSalaryPayrollCabRepository222 P
;22P Q
this33 
.33 
_logger33 
=33 
_logger33 "
;33" #
this44 
.44  
salaryBandRepository44 %
=44& ' 
salaryBandRepository44( <
;44< =
}55 	
public77 
void77 
Import77 
(77 
)77 
{88 	
var:: 
CompaniesList:: 
=:: 
empresaRepository::  1
.::1 2
GetAll::2 8
(::8 9
)::9 :
.::: ;
Result::; A
;::A B
var== 
oConceptsList== 
=== '
baseSalaryConceptRepository==  ;
.==; <
GetAll==< B
(==B C
)==C D
.==D E
Result==E K
;==K L
string?? 
arCodConcepts??  
=??! "
$str??# &
+??' (
string??) /
.??/ 0
Join??0 4
(??4 5
$str??5 :
,??: ;
oConceptsList??< I
.??I J
Select??J P
(??P Q
i??Q R
=>??S U
i??V W
.??W X

CodConcept??X b
)??b c
)??c d
+??e f
$str??g j
;??j k"
ExactusNominaFilterDtoAA "
filterNominaAA# /
=AA0 1
newAA2 5"
ExactusNominaFilterDtoAA6 L
(AAL M
)AAM N
;AAN O
filterNominaCC 
.CC 
arCodConceptsCC &
=CC' (
arCodConceptsCC) 6
;CC6 7
varEE 
currentpayrollsEE 
=EE  !*
baseSalaryPayrollDetRepositoryEE" @
.EE@ A
GetAllEEA G
(EEG H
)EEH I
.EEI J
ResultEEJ P
;EEP Q
varGG 
lstNominaCabGG 
=GG *
baseSalaryPayrollCabRepositoryGG =
.GG= >
GetAllGG> D
(GGD E
)GGE F
.GGF G
ResultGGG M
;GGM N
foreachII 
(II 
varII 
compII 
inII  
CompaniesListII! .
)II. /
{JJ 
_loggerLL 
.LL 
LogInformationLL &
(LL& '
$"LL' )
$strLL) 2
{LL2 3
compLL3 7
.LL7 8
IdLL8 :
}LL: ;
"LL; <
)LL< =
;LL= >
_loggerMM 
.MM 
LogInformationMM &
(MM& '
$"MM' )
$strMM) 1
{MM1 2
compMM2 6
.MM6 7
SchemaMM7 =
}MM= >
"MM> ?
)MM? @
;MM@ A
_loggerNN 
.NN 
LogInformationNN &
(NN& '
$"NN' )
$strNN) >
{NN> ?
compNN? C
.NNC D
DescripcionNND O
}NNO P
"NNP Q
)NNQ R
;NNR S
ifUU 
(UU 
!UU 
stringUU 
.UU 
IsNullOrEmptyUU )
(UU) *
compUU* .
.UU. /
SchemaUU/ 5
)UU5 6
)UU6 7
{VV 
tryYY 
{ZZ 
filterNomina[[ $
.[[$ %
Scheme[[% +
=[[, -
comp[[. 2
.[[2 3
Schema[[3 9
;[[9 :%
ExactusNominaCabFilterDto]] 1
	filtercab]]2 ;
=]]< =
new]]> A%
ExactusNominaCabFilterDto]]B [
(]][ \
)]]\ ]
;]]] ^
	filtercab^^ !
.^^! "
Scheme^^" (
=^^) *
comp^^+ /
.^^/ 0
Schema^^0 6
;^^6 7
var__ 
nominasExactus__ *
=__+ ,&
exactusNominaCabRepository__- G
.__G H
GetAll__H N
(__N O
	filtercab__O X
)__X Y
.__Y Z
Result__Z `
;__` a
intcc 
nFilas_nominacc )
=cc* +
nominasExactuscc, :
.cc: ;
Countcc; @
(cc@ A
)ccA B
;ccB C
_loggeree 
.ee  
LogInformationee  .
(ee. /
$"ee/ 1
$stree1 :
{ee: ;
	filtercabee; D
.eeD E
SchemeeeE K
}eeK L
$streeL O
{eeO P
nFilas_nominaeeP ]
}ee] ^
$stree^ |
"ee| }
)ee} ~
;ee~ 
nominasExactusgg &
=gg' (
nominasExactusgg) 7
.gg7 8
Wheregg8 =
(gg= >
igg> ?
=>gg@ B
iggC D
.ggD E
FECHA_APLICACIONggE U
!=ggV X
nullggY ]
)gg] ^
.gg^ _
ToListgg_ e
(gge f
)ggf g
;ggg h
nominasExactushh &
=hh' (
nominasExactushh) 7
.hh7 8
Wherehh8 =
(hh= >
ihh> ?
=>hh@ B
ihhC D
.hhD E
PERIODOhhE L
.hhL M
YearhhM Q
>=hhR T
$numhhU Y
)hhY Z
.hhZ [
ToListhh[ a
(hha b
)hhb c
;hhc d
foreachjj 
(jj  !
varjj! $
nominaexactuscabjj% 5
injj6 8
nominasExactusjj9 G
)jjG H
{kk 
intll 
nYeadNominall  +
=ll, -
nominaexactuscabll. >
.ll> ?
PERIODOll? F
.llF G
YearllG K
;llK L
intmm 
nMonthNominamm  ,
=mm- .
nominaexactuscabmm/ ?
.mm? @
PERIODOmm@ G
.mmG H
MonthmmH M
;mmM N
_loggeroo #
.oo# $
LogInformationoo$ 2
(oo2 3
$stroo3 R
)ooR S
;ooS T
_loggerpp #
.pp# $
LogInformationpp$ 2
(pp2 3
$"pp3 5
$strpp5 ?
{pp? @
nYeadNominappA L
}ppL M
$strppM l
"ppl m
)ppm n
;ppn o
_loggerqq #
.qq# $
LogInformationqq$ 2
(qq2 3
$"qq3 5
$strqq5 ?
{qq? @
nMonthNominaqqA M
}qqM N
$strqqN l
"qql m
)qqm n
;qqn o
_loggerrr #
.rr# $
LogInformationrr$ 2
(rr2 3
$"rr3 5
$strrr5 ?
{rr? @
nominaexactuscabrrB R
.rrR S
NOMINArrS Y
}rrY Z
$strrrZ l
"rrl m
)rrm n
;rrn o
_loggerss #
.ss# $
LogInformationss$ 2
(ss2 3
$"ss3 5
$strss5 F
{ssF G
nominaexactuscabssH X
.ssX Y
NUMERO_NOMINAssY f
}ssf g
$strssg l
"ssl m
)ssm n
;ssn o
_loggertt #
.tt# $
LogInformationtt$ 2
(tt2 3
$strtt3 R
)ttR S
;ttS T
varww "
currentNominaCabPortalww  6
=ww7 8
lstNominaCabww9 E
.wwE F
WherewwF K
(wwK L
iwwL M
=>wwN P
iwwQ R
.wwR S
	IdCompanywwS \
==ww] _
compww` d
.wwd e
Idwwe g
&&zzN P
izzQ R
.zzR S

NominaCodezzS ]
==zz^ `
nominaexactuscabzza q
.zzq r
NOMINAzzr x
&&{{N P
i{{Q R
.{{R S
NominaNumber{{S _
=={{` b
nominaexactuscab{{c s
.{{s t
NUMERO_NOMINA	{{t Å
)||L M
.||M N
FirstOrDefault||N \
(||\ ]
)||] ^
;||^ _
if 
(  "
currentNominaCabPortal  6
==7 9
null: >
)> ?
{
ÄÄ 
_logger
ÅÅ  '
.
ÅÅ' (
LogInformation
ÅÅ( 6
(
ÅÅ6 7
$str
ÅÅ7 z
)
ÅÅz {
;
ÅÅ{ |
SalaryPayrollCab
ÉÉ  0#
newsalaryPayrollCabBD
ÉÉ1 F
=
ÉÉG H
new
ÉÉI L
SalaryPayrollCab
ÉÉM ]
(
ÉÉ] ^
)
ÉÉ^ _
;
ÉÉ_ `#
newsalaryPayrollCabBD
ÑÑ  5
.
ÑÑ5 6
	IdCompany
ÑÑ6 ?
=
ÑÑ@ A
comp
ÑÑB F
.
ÑÑF G
Id
ÑÑG I
;
ÑÑI J#
newsalaryPayrollCabBD
ÖÖ  5
.
ÖÖ5 6
Year
ÖÖ6 :
=
ÖÖ; <
nYeadNomina
ÖÖ= H
;
ÖÖH I#
newsalaryPayrollCabBD
ÜÜ  5
.
ÜÜ5 6
Month
ÜÜ6 ;
=
ÜÜ< =
nMonthNomina
ÜÜ> J
;
ÜÜJ K#
newsalaryPayrollCabBD
áá  5
.
áá5 6

NominaCode
áá6 @
=
ááA B
nominaexactuscab
ááC S
.
ááS T
NOMINA
ááT Z
;
ááZ [#
newsalaryPayrollCabBD
àà  5
.
àà5 6
NominaNumber
àà6 B
=
ààC D
nominaexactuscab
ààE U
.
ààU V
NUMERO_NOMINA
ààV c
;
ààc d#
newsalaryPayrollCabBD
ââ  5
.
ââ5 6
PERIODO
ââ6 =
=
ââ> ?
nominaexactuscab
ââ@ P
.
ââP Q
PERIODO
ââQ X
;
ââX Y#
newsalaryPayrollCabBD
ää  5
.
ää5 6
FECHA_APROBACION
ää6 F
=
ääG H
nominaexactuscab
ääI Y
.
ääY Z
FECHA_APROBACION
ääZ j
;
ääj k#
newsalaryPayrollCabBD
ãã  5
.
ãã5 6

FECHA_PAGO
ãã6 @
=
ããA B
nominaexactuscab
ããC S
.
ããS T

FECHA_PAGO
ããT ^
;
ãã^ _#
newsalaryPayrollCabBD
åå  5
.
åå5 6
APROBADA_POR
åå6 B
=
ååC D
nominaexactuscab
ååE U
.
ååU V
APROBADA_POR
ååV b
;
ååb c
var
óó  #
nRegisterCabecera
óó$ 5
=
óó6 7"
salaryBandRepository
óó8 L
.
óóL M
RegisterNominaCab
óóM ^
(
óó^ _#
newsalaryPayrollCabBD
óó_ t
)
óót u
.
óóu v
Result
óóv |
;
óó| }
if
öö  "
(
öö# $
nRegisterCabecera
öö$ 5
>
öö6 7
$num
öö8 9
)
öö9 :
{
õõ  !
_logger
úú$ +
.
úú+ ,
LogInformation
úú, :
(
úú: ;
$"
úú; =
$str
úú= a
{
úúa b
nominaexactuscab
úúb r
.
úúr s
NOMINA
úús y
}
úúy z
$str
úúz {
{
úú{ |
nominaexactuscabúú} ç
.úúç é
NUMERO_NOMINAúúé õ
}úúõ ú
"úúú ù
)úúù û
;úúû ü
filterNomina
ûû$ 0
.
ûû0 1

NominaCode
ûû1 ;
=
ûû< =#
newsalaryPayrollCabBD
ûû> S
.
ûûS T

NominaCode
ûûT ^
;
ûû^ _
filterNomina
üü$ 0
.
üü0 1
NominaNumber
üü1 =
=
üü> ?#
newsalaryPayrollCabBD
üü@ U
.
üüU V
NominaNumber
üüV b
;
üüb c
var
¢¢$ '
nominalistexactus
¢¢( 9
=
¢¢: ;%
exactusNominaRepository
¢¢< S
.
¢¢S T
GetAll
¢¢T Z
(
¢¢Z [
filterNomina
¢¢[ g
)
¢¢g h
.
¢¢h i
Result
¢¢i o
;
¢¢o p
int
§§$ '!
nTotalDetalleNomina
§§( ;
=
§§< =
nominalistexactus
§§> O
.
§§O P
Count
§§P U
(
§§U V
)
§§V W
;
§§W X
_logger
¶¶$ +
.
¶¶+ ,
LogInformation
¶¶, :
(
¶¶: ;
$"
¶¶; =
$str
¶¶= I
{
¶¶I J!
nTotalDetalleNomina
¶¶K ^
}
¶¶^ _
$str¶¶_ É
{¶¶É Ñ 
nominaexactuscab¶¶Ñ î
.¶¶î ï
NOMINA¶¶ï õ
}¶¶õ ú
$str¶¶ú ù
{¶¶ù û 
nominaexactuscab¶¶ü Ø
.¶¶Ø ∞
NUMERO_NOMINA¶¶∞ Ω
}¶¶Ω æ
"¶¶æ ø
)¶¶ø ¿
;¶¶¿ ¡
foreach
©©$ +
(
©©, -
var
©©- 0
nominaexactusdet
©©1 A
in
©©B D
nominalistexactus
©©E V
)
©©V W
{
™™$ %
SalaryPayrollDet
¨¨( 8
newPayrollDet
¨¨9 F
=
¨¨G H
new
¨¨I L
SalaryPayrollDet
¨¨M ]
(
¨¨] ^
)
¨¨^ _
;
¨¨_ `
newPayrollDet
ØØ( 5
.
ØØ5 6
	IdCompany
ØØ6 ?
=
ØØ@ A
comp
ØØB F
.
ØØF G
Id
ØØG I
;
ØØI J
newPayrollDet
∞∞( 5
.
∞∞5 6
Consecutive
∞∞6 A
=
∞∞B C
nominaexactusdet
∞∞D T
.
∞∞T U
CONSECUTIVO
∞∞U `
;
∞∞` a
newPayrollDet
±±( 5
.
±±5 6
CodEmployee
±±6 A
=
±±B C
nominaexactusdet
±±D T
.
±±T U
EMPLEADO
±±U ]
;
±±] ^
newPayrollDet
≤≤( 5
.
≤≤5 6
Concept
≤≤6 =
=
≤≤> ?
nominaexactusdet
≤≤@ P
.
≤≤P Q
CONCEPTO
≤≤Q Y
;
≤≤Y Z
newPayrollDet
≥≥( 5
.
≥≥5 6
Payroll
≥≥6 =
=
≥≥> ?
nominaexactusdet
≥≥@ P
.
≥≥P Q
NOMINA
≥≥Q W
;
≥≥W X
newPayrollDet
¥¥( 5
.
¥¥5 6
PayRollNumber
¥¥6 C
=
¥¥D E
nominaexactusdet
¥¥F V
.
¥¥V W
NUMERO_NOMINA
¥¥W d
;
¥¥d e
newPayrollDet
µµ( 5
.
µµ5 6

CostCenter
µµ6 @
=
µµA B
nominaexactusdet
µµC S
.
µµS T
CENTRO_COSTO
µµT `
;
µµ` a
newPayrollDet
∂∂( 5
.
∂∂5 6
Amount
∂∂6 <
=
∂∂= >
nominaexactusdet
∂∂? O
.
∂∂O P
MONTO
∂∂P U
;
∂∂U V
newPayrollDet
∑∑( 5
.
∑∑5 6
Total
∑∑6 ;
=
∑∑< =
nominaexactusdet
∑∑> N
.
∑∑N O
TOTAL
∑∑O T
;
∑∑T U
newPayrollDet
∏∏( 5
.
∏∏5 6
RegisterType
∏∏6 B
=
∏∏C D
nominaexactusdet
∏∏E U
.
∏∏U V
TIPO_REGISTRO
∏∏V c
;
∏∏c d
newPayrollDet
ªª( 5
.
ªª5 6
Active
ªª6 <
=
ªª= >
true
ªª? C
;
ªªC D
newPayrollDet
ºº( 5
.
ºº5 6
IdUserRegister
ºº6 D
=
ººE F
$num
ººG H
;
ººH I
newPayrollDet
ΩΩ( 5
.
ΩΩ5 6
DateRegister
ΩΩ6 B
=
ΩΩC D
DateTime
ΩΩE M
.
ΩΩM N
Now
ΩΩN Q
;
ΩΩQ R
newPayrollDet
ææ( 5
.
ææ5 6
IdUserUpdate
ææ6 B
=
ææC D
$num
ææE F
;
ææF G
newPayrollDet
øø( 5
.
øø5 6

DateUpdate
øø6 @
=
øøA B
DateTime
øøC K
.
øøK L
Now
øøL O
;
øøO P
int
ƒƒ( +
nresuldetail
ƒƒ, 8
=
ƒƒ9 :"
salaryBandRepository
ƒƒ; O
.
ƒƒO P"
RegisterNominaDetail
ƒƒP d
(
ƒƒd e
newPayrollDet
ƒƒe r
)
ƒƒr s
.
ƒƒs t
Result
ƒƒt z
;
ƒƒz {
_logger
»»( /
.
»»/ 0
LogInformation
»»0 >
(
»»> ?
$"
»»? A
$str
»»A j
{
»»j k
nominaexactusdet
»»k {
.
»»{ |
CONSECUTIVO»»| á
}»»á à
$str»»à õ
{»»õ ú 
nominaexactuscab»»ú ¨
.»»¨ ≠
NOMINA»»≠ ≥
}»»≥ ¥
$str»»¥ µ
{»»µ ∂ 
nominaexactuscab»»∑ «
.»»« »
NUMERO_NOMINA»»» ’
}»»’ ÷
"»»÷ ◊
)»»◊ ÿ
;»»ÿ Ÿ!
nTotalDetalleNomina
  ( ;
--
  ; =
;
  = >
_logger
ÀÀ( /
.
ÀÀ/ 0
LogInformation
ÀÀ0 >
(
ÀÀ> ?
$"
ÀÀ? A
{
ÀÀA B!
nTotalDetalleNomina
ÀÀB U
}
ÀÀU V
$str
ÀÀV k
"
ÀÀk l
)
ÀÀl m
;
ÀÀm n
}
ÃÃ$ %
_logger
ÕÕ$ +
.
ÕÕ+ ,
LogInformation
ÕÕ, :
(
ÕÕ: ;
$"
ÕÕ; =
$str
ÕÕ= |
{
ÕÕ| }
nominaexactuscabÕÕ} ç
.ÕÕç é
NOMINAÕÕé î
}ÕÕî ï
$strÕÕï ñ
{ÕÕñ ó 
nominaexactuscabÕÕò ®
.ÕÕ® ©
NUMERO_NOMINAÕÕ© ∂
}ÕÕ∂ ∑
"ÕÕ∑ ∏
)ÕÕ∏ π
;ÕÕπ ∫
_logger
ŒŒ$ +
.
ŒŒ+ ,
LogInformation
ŒŒ, :
(
ŒŒ: ;
$"
ŒŒ; =
$strŒŒ= ã
"ŒŒã å
)ŒŒå ç
;ŒŒç é
}
––  !
else
——  $
{
““  !
_logger
””$ +
.
””+ ,
LogError
””, 4
(
””4 5
$"
””5 7
$str
””7 d
{
””d e
nominaexactuscab
””e u
.
””u v
NOMINA
””v |
}
””| }
$str
””} ~
{
””~  
nominaexactuscab””Ä ê
.””ê ë
NUMERO_NOMINA””ë û
}””û ü
"””ü †
)””† °
;””° ¢
}
‘‘  !
}
÷÷ 
else
◊◊  
{
ÿÿ 
_logger
ŸŸ  '
.
ŸŸ' (
LogInformation
ŸŸ( 6
(
ŸŸ6 7
$str
ŸŸ7 |
)
ŸŸ| }
;
ŸŸ} ~
_logger
››  '
.
››' (
LogInformation
››( 6
(
››6 7
$"
››7 9
$str
››9 a
{
››a b
nominaexactuscab
››b r
.
››r s
NOMINA
››s y
}
››y z
$str
››z {
{
››{ |
nominaexactuscab››} ç
.››ç é
NUMERO_NOMINA››é õ
}››õ ú
"››ú ù
)››ù û
;››û ü
_logger
ﬂﬂ  '
.
ﬂﬂ' (
LogInformation
ﬂﬂ( 6
(
ﬂﬂ6 7
$"
ﬂﬂ7 9
$str
ﬂﬂ9 \
{
ﬂﬂ\ ]$
currentNominaCabPortal
ﬂﬂ] s
.
ﬂﬂs t

NominaCode
ﬂﬂt ~
}
ﬂﬂ~ 
"ﬂﬂ Ä
)ﬂﬂÄ Å
;ﬂﬂÅ Ç
_logger
‡‡  '
.
‡‡' (
LogInformation
‡‡( 6
(
‡‡6 7
$"
‡‡7 9
$str
‡‡9 ^
{
‡‡^ _$
currentNominaCabPortal
‡‡_ u
.
‡‡u v
NominaNumber‡‡v Ç
}‡‡Ç É
"‡‡É Ñ
)‡‡Ñ Ö
;‡‡Ö Ü
_logger
··  '
.
··' (
LogInformation
··( 6
(
··6 7
$"
··7 9
$str
··9 [
{
··[ \$
currentNominaCabPortal
··\ r
.
··r s
	IdCompany
··s |
}
··| }
"
··} ~
)
··~ 
;·· Ä
var
‰‰  #!
detallenominaportal
‰‰$ 7
=
‰‰8 9"
salaryBandRepository
‰‰: N
.
‰‰N O"
GetSalaryPayrollDets
‰‰O c
(
‰‰c d$
currentNominaCabPortal
‰‰d z
.
‰‰z {

NominaCode‰‰{ Ö
,‰‰Ö Ü&
currentNominaCabPortal‰‰á ù
.‰‰ù û
NominaNumber‰‰û ™
,‰‰™ ´&
currentNominaCabPortal‰‰¨ ¬
.‰‰¬ √
	IdCompany‰‰√ Ã
)‰‰Ã Õ
.‰‰Õ Œ
Result‰‰Œ ‘
;‰‰‘ ’
filterNomina
ÊÊ  ,
.
ÊÊ, -

NominaCode
ÊÊ- 7
=
ÊÊ8 9$
currentNominaCabPortal
ÊÊ: P
.
ÊÊP Q

NominaCode
ÊÊQ [
;
ÊÊ[ \
filterNomina
ÁÁ  ,
.
ÁÁ, -
NominaNumber
ÁÁ- 9
=
ÁÁ: ;$
currentNominaCabPortal
ÁÁ< R
.
ÁÁR S
NominaNumber
ÁÁS _
;
ÁÁ_ `
var
ÍÍ  #
nominalistexactus
ÍÍ$ 5
=
ÍÍ6 7%
exactusNominaRepository
ÍÍ8 O
.
ÍÍO P
GetAll
ÍÍP V
(
ÍÍV W
filterNomina
ÍÍW c
)
ÍÍc d
.
ÍÍd e
Result
ÍÍe k
;
ÍÍk l
int
ÎÎ  #
nRegistrosExactus
ÎÎ$ 5
=
ÎÎ6 7
nominalistexactus
ÎÎ8 I
.
ÎÎI J
Count
ÎÎJ O
(
ÎÎO P
)
ÎÎP Q
;
ÎÎQ R
int
ÏÏ  #
nRegistrosPortal
ÏÏ$ 4
=
ÏÏ5 6!
detallenominaportal
ÏÏ7 J
.
ÏÏJ K
Count
ÏÏK P
(
ÏÏP Q
)
ÏÏQ R
;
ÏÏR S
int
ÌÌ  #"
nRegistrosDiferentes
ÌÌ$ 8
=
ÌÌ9 :
nRegistrosExactus
ÌÌ; L
-
ÌÌM N
nRegistrosPortal
ÌÌO _
;
ÌÌ_ `
_logger
ÚÚ  '
.
ÚÚ' (
LogInformation
ÚÚ( 6
(
ÚÚ6 7
$"
ÚÚ7 9
$str
ÚÚ9 T
{
ÚÚT U
nRegistrosExactus
ÚÚV g
}
ÚÚg h
"
ÚÚh i
)
ÚÚi j
;
ÚÚj k
_logger
ÛÛ  '
.
ÛÛ' (
LogInformation
ÛÛ( 6
(
ÛÛ6 7
$"
ÛÛ7 9
$str
ÛÛ9 S
{
ÛÛS T
nRegistrosPortal
ÛÛU e
}
ÛÛe f
"
ÛÛf g
)
ÛÛg h
;
ÛÛh i
_logger
ıı  '
.
ıı' (
LogInformation
ıı( 6
(
ıı6 7
$"
ıı7 9
$str
ıı9 Q
{
ııQ R
nRegistrosExactus
ııT e
-
ııf g
nRegistrosPortal
ııh x
}
ııx y
"
ııy z
)
ıız {
;
ıı{ |
foreach
˜˜  '
(
˜˜( )
var
˜˜) ,
nominaexactusdet
˜˜- =
in
˜˜> @
nominalistexactus
˜˜A R
)
˜˜R S
{
¯¯  !
var
˘˘$ '
nominadetportal
˘˘( 7
=
˘˘8 9!
detallenominaportal
˘˘: M
.
˘˘M N
Where
˘˘N S
(
˘˘S T
i
˘˘T U
=>
˘˘V X
i
˘˘Y Z
.
˘˘Z [
Consecutive
˘˘[ f
==
˘˘g i
nominaexactusdet
˘˘j z
.
˘˘z {
CONSECUTIVO˘˘{ Ü
)˘˘Ü á
.˘˘á à
FirstOrDefault˘˘à ñ
(˘˘ñ ó
)˘˘ó ò
;˘˘ò ô
if
¸¸$ &
(
¸¸' (
nominadetportal
¸¸( 7
==
¸¸8 :
null
¸¸; ?
)
¸¸? @
{
˝˝$ %
_logger
˛˛( /
.
˛˛/ 0
LogInformation
˛˛0 >
(
˛˛> ?
$"
˛˛? A
$str
˛˛A ^
{
˛˛^ _
nominaexactusdet
˛˛_ o
.
˛˛o p
CONSECUTIVO
˛˛p {
}
˛˛| }
$str
˛˛} ~
"
˛˛~ 
)˛˛ Ä
;˛˛Ä Å
SalaryPayrollDet
ÄÄ( 8
newPayrollDet
ÄÄ9 F
=
ÄÄG H
new
ÄÄI L
SalaryPayrollDet
ÄÄM ]
(
ÄÄ] ^
)
ÄÄ^ _
;
ÄÄ_ `
newPayrollDet
ÉÉ( 5
.
ÉÉ5 6
	IdCompany
ÉÉ6 ?
=
ÉÉ@ A
comp
ÉÉB F
.
ÉÉF G
Id
ÉÉG I
;
ÉÉI J
newPayrollDet
ÑÑ( 5
.
ÑÑ5 6
Consecutive
ÑÑ6 A
=
ÑÑB C
nominaexactusdet
ÑÑD T
.
ÑÑT U
CONSECUTIVO
ÑÑU `
;
ÑÑ` a
newPayrollDet
ÖÖ( 5
.
ÖÖ5 6
CodEmployee
ÖÖ6 A
=
ÖÖB C
nominaexactusdet
ÖÖD T
.
ÖÖT U
EMPLEADO
ÖÖU ]
;
ÖÖ] ^
newPayrollDet
ÜÜ( 5
.
ÜÜ5 6
Concept
ÜÜ6 =
=
ÜÜ> ?
nominaexactusdet
ÜÜ@ P
.
ÜÜP Q
CONCEPTO
ÜÜQ Y
;
ÜÜY Z
newPayrollDet
áá( 5
.
áá5 6
Payroll
áá6 =
=
áá> ?
nominaexactusdet
áá@ P
.
ááP Q
NOMINA
ááQ W
;
ááW X
newPayrollDet
àà( 5
.
àà5 6
PayRollNumber
àà6 C
=
ààD E
nominaexactusdet
ààF V
.
ààV W
NUMERO_NOMINA
ààW d
;
ààd e
newPayrollDet
ââ( 5
.
ââ5 6

CostCenter
ââ6 @
=
ââA B
nominaexactusdet
ââC S
.
ââS T
CENTRO_COSTO
ââT `
;
ââ` a
newPayrollDet
ää( 5
.
ää5 6
Amount
ää6 <
=
ää= >
nominaexactusdet
ää? O
.
ääO P
MONTO
ääP U
;
ääU V
newPayrollDet
ãã( 5
.
ãã5 6
Total
ãã6 ;
=
ãã< =
nominaexactusdet
ãã> N
.
ããN O
TOTAL
ããO T
;
ããT U
newPayrollDet
åå( 5
.
åå5 6
RegisterType
åå6 B
=
ååC D
nominaexactusdet
ååE U
.
ååU V
TIPO_REGISTRO
ååV c
;
ååc d
int
èè( +
nresuldetail
èè, 8
=
èè9 :"
salaryBandRepository
èè; O
.
èèO P"
RegisterNominaDetail
èèP d
(
èèd e
newPayrollDet
èèe r
)
èèr s
.
èès t
Result
èèt z
;
èèz {
_logger
ëë( /
.
ëë/ 0
LogInformation
ëë0 >
(
ëë> ?
$"
ëë? A
$str
ëëA j
{
ëëj k
nominaexactusdet
ëëk {
.
ëë{ |
CONSECUTIVOëë| á
}ëëá à
$strëëà õ
{ëëõ ú 
nominaexactuscabëëú ¨
.ëë¨ ≠
NOMINAëë≠ ≥
}ëë≥ ¥
$strëë¥ µ
{ëëµ ∂ 
nominaexactuscabëë∑ «
.ëë« »
NUMERO_NOMINAëë» ’
}ëë’ ÷
"ëë÷ ◊
)ëë◊ ÿ
;ëëÿ Ÿ"
nRegistrosDiferentes
ìì( <
--
ìì< >
;
ìì> ?
_logger
îî( /
.
îî/ 0
LogInformation
îî0 >
(
îî> ?
$"
îî? A
{
îîA B"
nRegistrosDiferentes
îîB V
}
îîV W
$str
îîW l
"
îîl m
)
îîm n
;
îîn o
}
ïï$ %
}
óó  !
_logger
òò  '
.
òò' (
LogInformation
òò( 6
(
òò6 7
$"
òò7 9
$str
òò9 x
{
òòx y
nominaexactuscabòòy â
.òòâ ä
NOMINAòòä ê
}òòê ë
$stròòë í
{òòí ì 
nominaexactuscabòòî §
.òò§ •
NUMERO_NOMINAòò• ≤
}òò≤ ≥
"òò≥ ¥
)òò¥ µ
;òòµ ∂
}
öö 
_logger
úú #
.
úú# $
LogInformation
úú$ 2
(
úú2 3
$"
úú3 5
$str
úú5 V
{
úúV W
nominaexactuscab
úúW g
.
úúg h
NOMINA
úúh n
}
úún o
$str
úúo p
{
úúp q
nominaexactuscabúúr Ç
.úúÇ É
NUMERO_NOMINAúúÉ ê
}úúê ë
"úúë í
)úúí ì
;úúì î
}
ùù 
_logger
üü 
.
üü  
LogInformation
üü  .
(
üü. /
$"
üü/ 1
$str
üü1 S
{
üüS T
comp
üüT X
.
üüX Y
Schema
üüY _
}
üü_ `
"
üü` a
)
üüa b
;
üüb c
}
†† 
catch
°° 
(
°° 
	Exception
°° $
ex
°°% '
)
°°' (
{
¢¢ 
_logger
§§ 
.
§§  
LogError
§§  (
(
§§( )
$str
§§) S
+
§§T U
ex
§§V X
.
§§X Y
Message
§§Y `
)
§§` a
;
§§a b
_logger
•• 
.
••  
LogError
••  (
(
••( )
$str
••) S
+
••T U
ex
••V X
.
••X Y

StackTrace
••Y c
)
••c d
;
••d e
}
¶¶ 
}
©© 
}
ØØ 
}
≤≤ 	
public
¥¥ 
void
¥¥ 
ImportLiquidacion
¥¥ %
(
¥¥% &
)
¥¥& '
{
µµ 	
_logger
∂∂ 
.
∂∂ 
LogInformation
∂∂ "
(
∂∂" #
$"
∂∂# %
$str
∂∂% A
"
∂∂A B
)
∂∂B C
;
∂∂C D
var
∏∏ 
CompaniesList
∏∏ 
=
∏∏ 
empresaRepository
∏∏  1
.
∏∏1 2
GetAll
∏∏2 8
(
∏∏8 9
)
∏∏9 :
.
∏∏: ;
Result
∏∏; A
;
∏∏A B
foreach
∫∫ 
(
∫∫ 
var
∫∫ 
comp
∫∫ 
in
∫∫  
CompaniesList
∫∫! .
)
∫∫. /
{
ªª 
if
ΩΩ 
(
ΩΩ 
!
ΩΩ 
string
ΩΩ 
.
ΩΩ 
IsNullOrEmpty
ΩΩ )
(
ΩΩ) *
comp
ΩΩ* .
.
ΩΩ. /
Schema
ΩΩ/ 5
)
ΩΩ5 6
)
ΩΩ6 7
{
ææ 
_logger
øø 
.
øø 
LogInformation
øø *
(
øø* +
$"
øø+ -
$str
øø- E
{
øøE F
comp
øøF J
.
øøJ K
Schema
øøK Q
}
øøQ R
"
øøR S
)
øøS T
;
øøT U
var
¿¿ %
liquidacionesCabExactus
¿¿ /
=
¿¿0 1(
exactusNominaCabRepository
¿¿2 L
.
¿¿L M
GetLiquidacionCab
¿¿M ^
(
¿¿^ _
comp
¿¿_ c
.
¿¿c d
Schema
¿¿d j
)
¿¿j k
.
¿¿k l
Result
¿¿l r
;
¿¿r s
var
¬¬  
liquidacionesCabGH
¬¬ *
=
¬¬+ ,"
salaryBandRepository
¬¬- A
.
¬¬A B#
GetLiquidacionCabList
¬¬B W
(
¬¬W X
comp
¬¬X \
.
¬¬\ ]
Id
¬¬] _
)
¬¬_ `
.
¬¬` a
Result
¬¬a g
;
¬¬g h
int
ƒƒ %
nRegistrosCabPendientes
ƒƒ /
=
ƒƒ0 1%
liquidacionesCabExactus
ƒƒ2 I
.
ƒƒI J
Count
ƒƒJ O
(
ƒƒO P
)
ƒƒP Q
-
ƒƒR S 
liquidacionesCabGH
ƒƒT f
.
ƒƒf g
Count
ƒƒg l
(
ƒƒl m
)
ƒƒm n
;
ƒƒn o
_logger
∆∆ 
.
∆∆ 
LogInformation
∆∆ +
(
∆∆+ ,
$"
∆∆, .
$str
∆∆. =
{
∆∆= >%
nRegistrosCabPendientes
∆∆> U
}
∆∆U V
$str
∆∆V d
"
∆∆d e
)
∆∆e f
;
∆∆f g
foreach
»» 
(
»» 
var
»»  
item
»»! %
in
»»& (%
liquidacionesCabExactus
»») @
)
»»@ A
{
…… 
var
ÀÀ 
existCab
ÀÀ $
=
ÀÀ% & 
liquidacionesCabGH
ÀÀ' 9
.
ÀÀ9 :
Where
ÀÀ: ?
(
ÀÀ? @
i
ÀÀ@ A
=>
ÀÀB D
i
ÀÀE F
.
ÀÀF G
nliquidation
ÀÀG S
==
ÀÀT V
item
ÀÀW [
.
ÀÀ[ \
LIQUIDACION
ÀÀ\ g
)
ÀÀg h
.
ÀÀh i
FirstOrDefault
ÀÀi w
(
ÀÀw x
)
ÀÀx y
;
ÀÀy z
if
ÕÕ 
(
ÕÕ 
existCab
ÕÕ $
==
ÕÕ% '
null
ÕÕ( ,
)
ÕÕ, -
{
ŒŒ 
LiquidacionCabDto
◊◊ -
dtocab
◊◊. 4
=
◊◊5 6
new
◊◊7 :
LiquidacionCabDto
◊◊; L
(
◊◊L M
)
◊◊M N
;
◊◊N O
dtocab
ŸŸ "
.
ŸŸ" #

nidcompany
ŸŸ# -
=
ŸŸ. /
comp
ŸŸ0 4
.
ŸŸ4 5
Id
ŸŸ5 7
;
ŸŸ7 8
dtocab
⁄⁄ "
.
⁄⁄" #
nliquidation
⁄⁄# /
=
⁄⁄0 1
item
⁄⁄2 6
.
⁄⁄6 7
LIQUIDACION
⁄⁄7 B
;
⁄⁄B C
dtocab
€€ "
.
€€" #
scodemployee
€€# /
=
€€0 1
item
€€2 6
.
€€6 7
EMPLEADO
€€7 ?
;
€€? @
dtocab
‹‹ "
.
‹‹" #
	scurrency
‹‹# ,
=
‹‹- .
item
‹‹/ 3
.
‹‹3 4
MONEDA
‹‹4 :
;
‹‹: ;
dtocab
›› "
.
››" #
sstateliquidation
››# 4
=
››5 6
item
››7 ;
.
››; <
ESTADO_LIQUIDAC
››< K
;
››K L
dtocab
ﬁﬁ "
.
ﬁﬁ" #
ddate_in
ﬁﬁ# +
=
ﬁﬁ, -
item
ﬁﬁ. 2
.
ﬁﬁ2 3
FECHA_INGRESO
ﬁﬁ3 @
;
ﬁﬁ@ A
dtocab
ﬂﬂ "
.
ﬂﬂ" #
	ddate_out
ﬂﬂ# ,
=
ﬂﬂ- .
item
ﬂﬂ/ 3
.
ﬂﬂ3 4
FECHA_SALIDA
ﬂﬂ4 @
;
ﬂﬂ@ A
dtocab
‡‡ "
.
‡‡" #
sclose_contracts
‡‡# 3
=
‡‡4 5
item
‡‡6 :
.
‡‡: ;
CERRAR_CONTRATOS
‡‡; K
;
‡‡K L
dtocab
·· "
.
··" #
nnumberaction
··# 0
=
··1 2
item
··3 7
.
··7 8
NUMERO_ACCION
··8 E
;
··E F
dtocab
‚‚ "
.
‚‚" #
spayway
‚‚# *
=
‚‚+ ,
item
‚‚- 1
.
‚‚1 2

FORMA_PAGO
‚‚2 <
;
‚‚< =
dtocab
„„ "
.
„„" #
saccountbank
„„# /
=
„„0 1
item
„„2 6
.
„„6 7
CUENTA_BANCO
„„7 C
;
„„C D
dtocab
‰‰ "
.
‰‰" #"
snumber_document_pay
‰‰# 7
=
‰‰8 9
item
‰‰: >
.
‰‰> ?
NUMERO_DOC_PAGO
‰‰? N
;
‰‰N O
dtocab
ÂÂ "
.
ÂÂ" #
saccountseat
ÂÂ# /
=
ÂÂ0 1
item
ÂÂ2 6
.
ÂÂ6 7
ASIENTO_CONTABLE
ÂÂ7 G
;
ÂÂG H
dtocab
ÊÊ "
.
ÊÊ" #
ddate_out_pay
ÊÊ# 0
=
ÊÊ1 2
item
ÊÊ3 7
.
ÊÊ7 8
FECHA_RETIRO_PAGO
ÊÊ8 I
;
ÊÊI J
dtocab
ÁÁ "
.
ÁÁ" #
suser_liquidation
ÁÁ# 4
=
ÁÁ5 6
item
ÁÁ7 ;
.
ÁÁ; <
USUARIO_LIQUIDAC
ÁÁ< L
;
ÁÁL M
dtocab
ËË "
.
ËË" #
ddate_liquidation
ËË# 4
=
ËË5 6
item
ËË7 ;
.
ËË; <
FECHA_LIQUIDACION
ËË< M
;
ËËM N
dtocab
ÈÈ "
.
ÈÈ" #
nsubtypedoc_pay
ÈÈ# 2
=
ÈÈ3 4
item
ÈÈ5 9
.
ÈÈ9 :
SUBTIPODOC_PAGO
ÈÈ: I
;
ÈÈI J
dtocab
ÍÍ "
.
ÍÍ" #
sbudget
ÍÍ# *
=
ÍÍ+ ,
item
ÍÍ- 1
.
ÍÍ1 2
PRESUPUESTO
ÍÍ2 =
;
ÍÍ= >
dtocab
ÎÎ "
.
ÎÎ" #
sunit_operative
ÎÎ# 2
=
ÎÎ3 4
item
ÎÎ5 9
.
ÎÎ9 :
UNIDAD_OPERATIVA
ÎÎ: J
;
ÎÎJ K
dtocab
ÏÏ "
.
ÏÏ" #
nnumber_apart
ÏÏ# 0
=
ÏÏ1 2
item
ÏÏ3 7
.
ÏÏ7 8
NUMERO_APARTADO
ÏÏ8 G
;
ÏÏG H
dtocab
ÌÌ "
.
ÌÌ" #
nnumber_exercised
ÌÌ# 4
=
ÌÌ5 6
item
ÌÌ7 ;
.
ÌÌ; <
NUMERO_EJERCIDO
ÌÌ< K
;
ÌÌK L
dtocab
ÓÓ "
.
ÓÓ" #
scalc_pay_nomina
ÓÓ# 3
=
ÓÓ4 5
item
ÓÓ6 :
.
ÓÓ: ;!
CALCULA_PAGO_NOMINA
ÓÓ; N
;
ÓÓN O
dtocab
ÔÔ "
.
ÔÔ" #
snomina_calc
ÔÔ# /
=
ÔÔ0 1
item
ÔÔ2 6
.
ÔÔ6 7
NOMINA_CALCULO
ÔÔ7 E
;
ÔÔE F
dtocab
 "
.
" #!
nnumber_nomina_calc
# 6
=
7 8
item
9 =
.
= >#
NUMERO_NOMINA_CALCULO
> S
;
S T
dtocab
ÒÒ "
.
ÒÒ" #!
scontract_term_type
ÒÒ# 6
=
ÒÒ7 8
item
ÒÒ9 =
.
ÒÒ= >%
TIPO_EXTINCION_CONTRATO
ÒÒ> U
;
ÒÒU V
dtocab
ÚÚ "
.
ÚÚ" #
ssituation_unac
ÚÚ# 2
=
ÚÚ3 4
item
ÚÚ5 9
.
ÚÚ9 :
SITUACION_INAC
ÚÚ: H
;
ÚÚH I
int
ıı 

nResultCab
ıı  *
=
ıı+ ,"
salaryBandRepository
ıı- A
.
ııA B$
RegisterLiquidacionCab
ııB X
(
ııX Y
dtocab
ııY _
)
ıı_ `
.
ıı` a
Result
ııa g
;
ııg h
if
˜˜ 
(
˜˜  

nResultCab
˜˜  *
>
˜˜+ ,
$num
˜˜- .
)
˜˜. /
{
¯¯ 
_logger
¸¸  '
.
¸¸' (
LogInformation
¸¸( 6
(
¸¸6 7
$"
¸¸7 9
$str
¸¸9 b
{
¸¸b c
dtocab
¸¸c i
.
¸¸i j
nliquidation
¸¸j v
}
¸¸v w
"
¸¸w x
)
¸¸x y
;
¸¸y z
var
ÄÄ  #%
liquidacionesDetExactus
ÄÄ$ ;
=
ÄÄ< =(
exactusNominaCabRepository
ÄÄ> X
.
ÄÄX Y
GetLiquidacionDet
ÄÄY j
(
ÄÄj k
comp
ÄÄk o
.
ÄÄo p
Schema
ÄÄp v
,
ÄÄv w
dtocab
ÄÄx ~
.
ÄÄ~ 
nliquidationÄÄ ã
)ÄÄã å
.ÄÄå ç
ResultÄÄç ì
;ÄÄì î
foreach
ÑÑ  '
(
ÑÑ( )
var
ÑÑ) ,
det
ÑÑ- 0
in
ÑÑ1 3%
liquidacionesDetExactus
ÑÑ4 K
)
ÑÑK L
{
ÖÖ  !
LiquidacionDetDto
àà$ 5
	dtoinsDet
àà6 ?
=
àà@ A
new
ààB E
LiquidacionDetDto
ààF W
(
ààW X
)
ààX Y
;
ààY Z
	dtoinsDet
ää$ -
.
ää- .

nidcompany
ää. 8
=
ää9 :
comp
ää; ?
.
ää? @
Id
ää@ B
;
ääB C
	dtoinsDet
ãã$ -
.
ãã- .
nliquidation
ãã. :
=
ãã; <
det
ãã= @
.
ãã@ A
LIQUIDACION
ããA L
;
ããL M
	dtoinsDet
åå$ -
.
åå- .
nline
åå. 3
=
åå4 5
det
åå6 9
.
åå9 :
LINEA
åå: ?
;
åå? @
	dtoinsDet
çç$ -
.
çç- .
sconcept
çç. 6
=
çç7 8
det
çç9 <
.
çç< =
CONCEPTO
çç= E
;
ççE F
	dtoinsDet
éé$ -
.
éé- .
sdescription
éé. :
=
éé; <
det
éé= @
.
éé@ A
DESCRIPCION
ééA L
;
ééL M
	dtoinsDet
èè$ -
.
èè- .
stypeconcept
èè. :
=
èè; <
det
èè= @
.
èè@ A
TIPO_CONCEPTO
èèA N
;
èèN O
	dtoinsDet
êê$ -
.
êê- .
	nsequence
êê. 7
=
êê8 9
det
êê: =
.
êê= >
	SECUENCIA
êê> G
;
êêG H
	dtoinsDet
ëë$ -
.
ëë- .
	nquantity
ëë. 7
=
ëë8 9
det
ëë: =
.
ëë= >
CANTIDAD
ëë> F
;
ëëF G
	dtoinsDet
íí$ -
.
íí- .
namount
íí. 5
=
íí6 7
det
íí8 ;
.
íí; <
MONTO
íí< A
;
ííA B
	dtoinsDet
ìì$ -
.
ìì- .
ntotal_calc
ìì. 9
=
ìì: ;
det
ìì< ?
.
ìì? @
TOTAL_CALCULADO
ìì@ O
;
ììO P
	dtoinsDet
îî$ -
.
îî- .
scentercost
îî. 9
=
îî: ;
det
îî< ?
.
îî? @
CENTRO_COSTO
îî@ L
;
îîL M
	dtoinsDet
ïï$ -
.
ïï- .
sledgeraccount
ïï. <
=
ïï= >
det
ïï? B
.
ïïB C
CUENTA_CONTABLE
ïïC R
;
ïïR S
int
òò$ '

nResultDet
òò( 2
=
òò3 4"
salaryBandRepository
òò5 I
.
òòI J$
RegisterLiquidacionDet
òòJ `
(
òò` a
	dtoinsDet
òòa j
)
òòj k
.
òòk l
Result
òòl r
;
òòr s
if
ôô$ &
(
ôô' (

nResultDet
ôô( 2
>
ôô3 4
$num
ôô5 6
)
ôô6 7
{
öö$ %
_logger
õõ( /
.
õõ/ 0
LogInformation
õõ0 >
(
õõ> ?
$"
õõ? A
$str
õõA g
{
õõg h
	dtoinsDet
õõh q
.
õõq r
sconcept
õõr z
}
õõz {
"
õõ{ |
)
õõ| }
;
õõ} ~
}
úú$ %
else
ùù$ (
{
ûû$ %
_logger
üü( /
.
üü/ 0
LogInformation
üü0 >
(
üü> ?
$"
üü? A
$str
üüA j
{
üüj k
	dtoinsDet
üük t
.
üüt u
sconcept
üüu }
}
üü} ~
"
üü~ 
)üü Ä
;üüÄ Å
}
††$ %
}
¢¢  !
}
´´ 
else
¨¨  
{
≠≠ 
_logger
ÆÆ  '
.
ÆÆ' (
LogInformation
ÆÆ( 6
(
ÆÆ6 7
$"
ÆÆ7 9
$str
ÆÆ9 e
{
ÆÆe f
dtocab
ÆÆf l
.
ÆÆl m
ddate_liquidation
ÆÆm ~
}
ÆÆ~ 
"ÆÆ Ä
)ÆÆÄ Å
;ÆÆÅ Ç
}
ØØ 
}
≤≤ %
nRegistrosCabPendientes
¥¥ /
--
¥¥/ 1
;
¥¥1 2
_logger
µµ 
.
µµ  
LogInformation
µµ  .
(
µµ. /
$"
µµ/ 1
{
µµ1 2%
nRegistrosCabPendientes
µµ2 I
}
µµI J
$str
µµJ T
"
µµT U
)
µµU V
;
µµV W
_logger
∑∑ 
.
∑∑  
LogInformation
∑∑  .
(
∑∑. /
$"
∑∑/ 1
$str
∑∑1 f
"
∑∑f g
)
∑∑g h
;
∑∑h i
}
ππ 
}
∫∫ 
_logger
ªª 
.
ªª 
LogInformation
ªª &
(
ªª& '
$"
ªª' )
$str
ªª) m
"
ªªm n
)
ªªn o
;
ªªo p
}
ºº 
_logger
ΩΩ 
.
ΩΩ 
LogInformation
ΩΩ "
(
ΩΩ" #
$"
ΩΩ# %
$str
ΩΩ% a
"
ΩΩa b
)
ΩΩb c
;
ΩΩc d
}
¿¿ 	
}
¬¬ 
}√√ †
~D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Puesto\IServices\IExactusPuestoLogic.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Puesto0 6
.6 7
	IServices7 @
{ 
public

 

	interface

 
IExactusPuestoLogic

 (
{ 
void 
Import 
( 
) 
; 
} 
} “
ÄD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Puesto\IServices\IExactusPuestoService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Puesto0 6
.6 7
	IServices7 @
{ 
public		 

	interface		 !
IExactusPuestoService		 *
{

 
} 
} ‚S
|D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Puesto\Services\ExactusPuestoLogic.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Puesto0 6
.6 7
Services7 ?
{ 
public 

class 
ExactusPuestoLogic #
:$ %
IExactusPuestoLogic& 9
{ 
private 
readonly 
IEmpresaRepository +
empresaRepository, =
;= >
private 
readonly $
IExactusPuestoRepository 1#
exactusPuestoRepository2 I
;I J
private 
readonly 
IBaseRepository (
<( )
Cargo) .
>. /
baseCargoRepository0 C
;C D
private 
readonly 
IBaseRepository (
<( )
Areas) .
>. /
baseAreaRepository0 B
;B C
private 
readonly 
ILogger  
<  !
ExactusPuestoLogic! 3
>3 4
_logger5 <
;< =
private 
readonly 
IBaseRepository (
<( )

SalaryBand) 3
>3 4!
baseBandBoxRepository5 J
;J K
public 
ExactusPuestoLogic !
(! "
IEmpresaRepository" 4
empresaRepository5 F
,F G$
IExactusPuestoRepository$ <#
exactusPuestoRepository= T
,T U
IBaseRepository$ 3
<3 4
Cargo4 9
>9 :
baseCargoRepository; N
,N O
IBaseRepository$ 3
<3 4
Areas4 9
>9 :
baseAreaRepository; M
,M N
ILogger  $ +
<  + ,
ExactusPuestoLogic  , >
>  > ?
_logger  @ G
,  G H
IBaseRepository!!$ 3
<!!3 4

SalaryBand!!4 >
>!!> ?!
baseBandBoxRepository!!@ U
)## 
{$$ 	
this%% 
.%% #
exactusPuestoRepository%% (
=%%) *#
exactusPuestoRepository%%+ B
;%%B C
this&& 
.&& 
empresaRepository&& "
=&&# $
empresaRepository&&% 6
;&&6 7
this'' 
.'' 
baseCargoRepository'' $
=''% &
baseCargoRepository''' :
;'': ;
this(( 
.(( 
baseAreaRepository(( #
=(($ %
baseAreaRepository((& 8
;((8 9
this)) 
.)) 
_logger)) 
=)) 
_logger)) "
;))" #
this** 
.** !
baseBandBoxRepository** &
=**' (!
baseBandBoxRepository**) >
;**> ?
}++ 	
public-- 
void-- 
Import-- 
(-- 
)-- 
{.. 	
_logger// 
.// 
LogInformation// "
(//" #
$str//# <
)//< =
;//= >
var00 
CompaniesList00 
=00 
empresaRepository00  1
.001 2
GetAll002 8
(008 9
)009 :
.00: ;
Result00; A
;00A B
_logger11 
.11 
LogInformation11 "
(11" #
string11# )
.11) *
Format11* 0
(110 1
$str111 P
,11P Q
CompaniesList11R _
.11_ `
Count11` e
(11e f
)11f g
)11g h
)11h i
;11i j"
ExactusPuestoFilterDto33 "
filterPuesto33# /
=330 1
new332 5"
ExactusPuestoFilterDto336 L
(33L M
)33M N
;33N O
var66 

Cargoslist66 
=66 
baseCargoRepository66 0
.660 1
GetAll661 7
(667 8
)668 9
.669 :
Result66: @
;66@ A
var88 
	areaslist88 
=88 
baseAreaRepository88 .
.88. /
GetAll88/ 5
(885 6
)886 7
.887 8
Result888 >
;88> ?
_logger99 
.99 
LogInformation99 "
(99" #
string99# )
.99) *
Format99* 0
(990 1
$str991 _
,99_ `

Cargoslist99a k
.99k l
Count99l q
(99q r
)99r s
)99s t
)99t u
;99u v
_logger;; 
.;; 
LogInformation;; "
(;;" #
$str;;# @
);;@ A
;;;A B
var>> 
bandboxlist>> 
=>> !
baseBandBoxRepository>> 3
.>>3 4
GetAll>>4 :
(>>: ;
)>>; <
.>>< =
Result>>= C
;>>C D
foreach@@ 
(@@ 
var@@ 
comp@@ 
in@@  
CompaniesList@@! .
)@@. /
{AA 
tryBB 
{CC 
ifDD 
(DD 
!DD 
stringDD 
.DD  
IsNullOrEmptyDD  -
(DD- .
compDD. 2
.DD2 3
SchemaDD3 9
)DD9 :
)DD: ;
{EE 
filterPuestoFF $
.FF$ %
SchemeFF% +
=FF, -
compFF. 2
.FF2 3
SchemaFF3 9
;FF9 :
varII 

puestoListII &
=II' (#
exactusPuestoRepositoryII) @
.II@ A
GetAllIIA G
(IIG H
filterPuestoIIH T
)IIT U
.IIU V
ResultIIV \
;II\ ]
_loggerKK 
.KK  
LogInformationKK  .
(KK. /
stringKK/ 5
.KK5 6
FormatKK6 <
(KK< =
$strKK= w
,KKw x

puestoList	KKy É
.
KKÉ Ñ
Count
KKÑ â
(
KKâ ä
)
KKä ã
,
KKã å
comp
KKç ë
.
KKë í
Descripcion
KKí ù
)
KKù û
)
KKû ü
;
KKü †
intMM 
nIdAreaDefaultMM *
=MM+ ,
	areaslistMM- 6
.MM6 7
WhereMM7 <
(MM< =
iMM= >
=>MM? A
iMMB C
.MMC D
	IdEmpresaMMD M
==MMN P
compMMQ U
.MMU V
IdMMV X
&&MMY [
iMM\ ]
.MM] ^

CodExactusMM^ h
==MMi k
$strMMl p
)MMp q
.MMq r
SelectMMr x
(MMx y
iMMy z
=>MM{ }
iMM~ 
.	MM Ä
Id
MMÄ Ç
)
MMÇ É
.
MMÉ Ñ
FirstOrDefault
MMÑ í
(
MMí ì
)
MMì î
;
MMî ï
foreachOO 
(OO  !
varOO! $
puestoOO% +
inOO, .

puestoListOO/ 9
)OO9 :
{PP 
varRR 
existRR  %
=RR& '

CargoslistRR( 2
.RR2 3
WhereRR3 8
(RR8 9
iRR9 :
=>RR; =
iRR> ?
.RR? @
	IdEmpresaRR@ I
==RRJ L
compRRM Q
.RRQ R
IdRRR T
&&RRU W
iRRX Y
.RRY Z

CodExactusRRZ d
==RRe g
puestoRRh n
.RRn o
DESCRIPCIONRRo z
)RRz {
.RR{ |
FirstOrDefault	RR| ä
(
RRä ã
)
RRã å
;
RRå ç
ifTT 
(TT  
existTT  %
==TT& (
nullTT) -
)TT- .
{UU 
HumanManagementVV  /
.VV/ 0
DomainVV0 6
.VV6 7
CargoVV7 <
.VV< =
ModelsVV= C
.VVC D
CargoVVD I

newCargoBdVVJ T
=VVU V
newVVW Z
HumanManagementVV[ j
.VVj k
DomainVVk q
.VVq r
CargoVVr w
.VVw x
ModelsVVx ~
.VV~ 
Cargo	VV Ñ
(
VVÑ Ö
)
VVÖ Ü
;
VVÜ á

newCargoBdXX  *
.XX* +
	IdEmpresaXX+ 4
=XX5 6
compXX7 ;
.XX; <
IdXX< >
;XX> ?

newCargoBdYY  *
.YY* +
	NameCargoYY+ 4
=YY5 6
puestoYY7 =
.YY= >
DESCRIPCIONYY> I
;YYI J

newCargoBdZZ  *
.ZZ* +

CodExactusZZ+ 5
=ZZ6 7
puestoZZ8 >
.ZZ> ?
PUESTOZZ? E
;ZZE F

newCargoBd[[  *
.[[* +
IdUpperCargo[[+ 7
=[[8 9
$num[[: ;
;[[; <

newCargoBd\\  *
.\\* +
IdArea\\+ 1
=\\2 3
nIdAreaDefault\\4 B
;\\B C

newCargoBd__  *
.__* +
Active__+ 1
=__2 3
puesto__4 :
.__: ;
ACTIVO__; A
==__B D
$str__E H
?__I J
true__K O
:__P Q
false__R W
;__W X

newCargoBd``  *
.``* +
IdUserRegister``+ 9
=``: ;
$num``< =
;``= >

newCargoBdaa  *
.aa* +
DateRegisteraa+ 7
=aa8 9
DateTimeaa: B
.aaB C
NowaaC F
;aaF G

newCargoBdbb  *
.bb* +
IdUserUpdatebb+ 7
=bb8 9
$numbb: ;
;bb; <

newCargoBdcc  *
.cc* +

DateUpdatecc+ 5
=cc6 7
DateTimecc8 @
.cc@ A
NowccA D
;ccD E
_loggerdd  '
.dd' (
LogInformationdd( 6
(dd6 7
stringdd7 =
.dd= >
Formatdd> D
(ddD E
$strddE v
,ddv w
puestoddx ~
.dd~ 
DESCRIPCION	dd ä
,
ddä ã
comp
ddå ê
.
ddê ë
Descripcion
ddë ú
)
ddú ù
)
ddù û
;
ddû ü
baseCargoRepositoryff  3
.ff3 4
Addff4 7
(ff7 8

newCargoBdff8 B
)ffB C
.ffC D
WaitffD H
(ffH I
)ffI J
;ffJ K
}hh 
}jj 
}mm 
}nn 
catchoo 
(oo 
	Exceptionoo  
exoo! #
)oo# $
{pp 
_loggerqq 
.qq 
LogErrorqq $
(qq$ %
$strqq% O
+qqP Q
exqqR T
.qqT U
MessageqqU \
)qq\ ]
;qq] ^
_loggerrr 
.rr 
LogErrorrr $
(rr$ %
$strrr% O
+rrP Q
exrrR T
.rrT U

StackTracerrU _
)rr_ `
;rr` a
}ss 
}vv 
_loggerww 
.ww 
LogInformationww "
(ww" #
$strww# m
)wwm n
;wwn o
}xx 	
}zz 
}{{ ï
~D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Puesto\Services\ExactusPuestoService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Exactus( /
./ 0
Puesto0 6
.6 7
Services7 ?
{ 
public 

class  
ExactusPuestoService %
:& ' 
CustomWindowsService( <
{ 
private 
readonly $
ICoreParameterRepository 1#
coreParameterRepository2 I
;I J
private 
readonly 
IExactusPuestoLogic ,
exactusPuestoLogic- ?
;? @
public  
ExactusPuestoService #
(# $$
ICoreParameterRepository$ <#
coreParameterRepository= T
,T U
IExactusPuestoLogicV i
exactusPuestoLogicj |
)| }
: 
base 
( #
coreParameterRepository *
)* +
{ 	
this 
. 
exactusPuestoLogic #
=$ %
exactusPuestoLogic& 8
;8 9
} 	
public 
override 
void 
Run  
(  !
)! "
{ 	
exactusPuestoLogic 
. 
Import %
(% &
)& '
;' (
} 	
public 
override 
void 
SetParameterBase -
(- .
). /
{ 	
ParameterFilter 
. 
ApplicationName +
=, -
	Constants. 7
.7 8
HumanManagemen8 F
.F G
ApplicationNameG V
;V W
ParameterFilter 
. 
Module "
=# $
	Constants% .
.. /
NotifyImportedUser/ A
.A B
ModuleB H
;H I
}   	
}!! 
}"" ÉF
qD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Extensions\CustomWindowsService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (

Extensions( 2
{ 
public 

abstract 
class  
CustomWindowsService .
{ 
private 
Timer 
feqProcessVh "
;" #
private 
Timer 
feqProcessDay #
;# $
private 
TimeSpan 
	StartTime "
;" #
private 
TimeSpan 
EndTime  
;  !
private 
bool 
	InProcess 
; 
public 
ParameterFilterDto !
ParameterFilter" 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
private 
readonly $
ICoreParameterRepository 1#
coreParameterRepository2 I
;I J
public  
CustomWindowsService #
(# $$
ICoreParameterRepository$ <#
coreParameterRepository= T
)T U
{ 	
this 
. #
coreParameterRepository (
=) *#
coreParameterRepository+ B
;B C
SetParameter 
( 
) 
; 
ParameterFilter 
= 
new !
ParameterFilterDto" 4
(4 5
)5 6
;6 7
} 	
public   
void   
Start   
(   
)   
{!! 	
try"" 
{## 
ParameterFilter$$ 
.$$  
Key$$  #
=$$$ %
	Constants$$& /
.$$/ 0
HumanManagemen$$0 >
.$$> ?
Keys$$? C
.$$C D
FrequencyProcVH$$D S
;$$S T
ParameterResultDto%% "
result%%# )
=%%* +#
coreParameterRepository%%, C
.%%C D
GetValue%%D L
(%%L M
ParameterFilter%%M \
)%%\ ]
.%%] ^
Result%%^ d
;%%d e
feqProcessVh&& 
=&& 
new&& "
Timer&&# (
(&&( )
result&&) /
.&&/ 0
ValueNumeric&&0 <
.&&< =
Value&&= B
)&&B C
;&&C D
feqProcessVh'' 
.'' 
Elapsed'' $
+=''% ' 
feqProcessVh_Elapsed''( <
;''< =
ParameterFilter(( 
.((  
Key((  #
=(($ %
	Constants((& /
.((/ 0
HumanManagemen((0 >
.((> ?
Keys((? C
.((C D

HoraInicio((D N
;((N O
ParameterResultDto)) "
resultStartTime))# 2
=))3 4#
coreParameterRepository))5 L
.))L M
GetValue))M U
())U V
ParameterFilter))V e
)))e f
.))f g
Result))g m
;))m n
	StartTime** 
=** 
DateTime** $
.**$ %
Parse**% *
(*** +
resultStartTime**+ :
.**: ;
ValueString**; F
)**F G
.**G H
	TimeOfDay**H Q
;**Q R
ParameterFilter++ 
.++  
Key++  #
=++$ %
	Constants++& /
.++/ 0
HumanManagemen++0 >
.++> ?
Keys++? C
.++C D
HoraFin++D K
;++K L
ParameterResultDto,, "
resultEndTime,,# 0
=,,1 2#
coreParameterRepository,,3 J
.,,J K
GetValue,,K S
(,,S T
ParameterFilter,,T c
),,c d
.,,d e
Result,,e k
;,,k l
EndTime-- 
=-- 
DateTime-- "
.--" #
Parse--# (
(--( )
resultEndTime--) 6
.--6 7
ValueString--7 B
)--B C
.--C D
	TimeOfDay--D M
;--M N
feqProcessVh.. 
... 
Start.. "
(.." #
)..# $
;..$ %
}// 
catch00 
(00 
	Exception00 
ex00 
)00  
{11 
}44 
}55 	
public77 
void77 
Finish77 
(77 
)77 
{88 	
if99 
(99 
feqProcessDay99 
!=99  
null99! %
&&99& (
feqProcessDay99) 6
.996 7
Enabled997 >
)99> ?
{:: 
feqProcessDay;; 
.;; 
Stop;; "
(;;" #
);;# $
;;;$ %
feqProcessDay<< 
.<< 
Elapsed<< %
-=<<& (!
feqProcessDay_Elapsed<<) >
;<<> ?
feqProcessDay== 
.== 
Dispose== %
(==% &
)==& '
;==' (
feqProcessDay>> 
=>> 
null>>  $
;>>$ %
}?? 
ifAA 
(AA 
feqProcessVhAA 
!=AA 
nullAA  $
&&AA% '
feqProcessVhAA( 4
.AA4 5
EnabledAA5 <
)AA< =
{BB 
feqProcessVhCC 
.CC 
StopCC !
(CC! "
)CC" #
;CC# $
feqProcessVhDD 
.DD 
ElapsedDD $
-=DD% ' 
feqProcessVh_ElapsedDD( <
;DD< =
feqProcessVhEE 
.EE 
DisposeEE $
(EE$ %
)EE% &
;EE& '
feqProcessVhFF 
=FF 
nullFF #
;FF# $
}GG 
	InProcessHH 
=HH 
falseHH 
;HH 
}II 	
voidKK  
feqProcessVh_ElapsedKK !
(KK! "
objectKK" (
senderKK) /
,KK/ 0
ElapsedEventArgsKK1 A
eKKB C
)KKC D
{LL 	
varMM 

horaActualMM 
=MM 
DateTimeMM %
.MM% &
NowMM& )
.MM) *
	TimeOfDayMM* 3
;MM3 4
ifNN 
(NN 

horaActualNN 
>=NN 
	StartTimeNN '
&&NN( *

horaActualNN+ 5
<=NN6 8
EndTimeNN9 @
)NN@ A
{OO 
ifPP 
(PP 
feqProcessDayPP !
==PP" $
nullPP% )
)PP) *
{QQ 
ParameterFilterRR #
.RR# $
KeyRR$ '
=RR( )
	ConstantsRR* 3
.RR3 4
HumanManagemenRR4 B
.RRB C
KeysRRC G
.RRG H
FrequencyProcDayRRH X
;RRX Y
ParameterResultDtoSS &
resultProcessDaySS' 7
=SS8 9#
coreParameterRepositorySS: Q
.SSQ R
GetValueSSR Z
(SSZ [
ParameterFilterSS[ j
)SSj k
.SSk l
ResultSSl r
;SSr s
feqProcessDayTT !
=TT" #
newTT$ '
TimerTT( -
(TT- .
resultProcessDayTT. >
.TT> ?
ValueNumericTT? K
.TTK L
ValueTTL Q
)TTQ R
;TTR S
feqProcessDayUU !
.UU! "
ElapsedUU" )
+=UU* ,!
feqProcessDay_ElapsedUU- B
;UUB C
}VV 
ifWW 
(WW 
!WW 
feqProcessDayWW "
.WW" #
EnabledWW# *
&&WW+ -
!WW. /
	InProcessWW/ 8
)WW8 9
{XX 
	InProcessYY 
=YY 
trueYY  $
;YY$ %
Run[[ 
([[ 
)[[ 
;[[ 
feqProcessDay\\ !
.\\! "
Start\\" '
(\\' (
)\\( )
;\\) *
}]] 
}^^ 
else__ 
{`` 
ifaa 
(aa 
feqProcessDayaa !
!=aa" $
nullaa% )
&&aa* ,
feqProcessDayaa- :
.aa: ;
Enabledaa; B
)aaB C
{bb 
	InProcesscc 
=cc 
falsecc  %
;cc% &
feqProcessDaydd !
.dd! "
Stopdd" &
(dd& '
)dd' (
;dd( )
}ee 
}ff 
}gg 	
voidii !
feqProcessDay_Elapsedii "
(ii" #
objectii# )
senderii* 0
,ii0 1
ElapsedEventArgsii2 B
eiiC D
)iiD E
{jj 	
Runkk 
(kk 
)kk 
;kk 
}ll 	
privatenn 
voidnn 
SetParameternn !
(nn! "
)nn" #
{oo 	
SetParameterBasepp 
(pp 
)pp 
;pp 
}qq 	
publicss 
abstractss 
voidss 
Runss  
(ss  !
)ss! "
;ss" #
publicuu 
abstractuu 
voiduu 
SetParameterBaseuu -
(uu- .
)uu. /
;uu/ 0
}vv 
}ww Ë
aD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Response\Result.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
Response( 0
{ 
public		 

class		 
Result		 
{

 
public 
int 
	StateCode 
{ 
get "
;" #
set$ '
;' (
}) *
public 
List 
< 
string 
> 
MessageError (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
Object 
Data 
{ 
get  
;  !
set" %
;% &
}' (
public 
Result 
( 
) 
{ 	
MessageError 
= 
new 
List #
<# $
string$ *
>* +
(+ ,
), -
;- .
} 	
} 
} Å
äD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\ServerUs\Asistencia\IServices\IServerUsAsistenciaService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
ServerUs( 0
.0 1

Asistencia1 ;
.; <
	IServices< E
{		 
public

 

	interface

 &
IServerUsAsistenciaService

 /
{ 
void 
Register 
( #
SURegisterAsistenciaDto -
dtoInsertAsistencia. A
)A B
;B C
} 
} à<
àD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\ServerUs\Asistencia\Services\ServerUsAsistenciaService.cs
	namespace 	
WSHumanManagement
 
. 
Application '
.' (
ServerUs( 0
.0 1

Asistencia1 ;
.; <
Services< D
{ 
public 

class %
ServerUsAsistenciaService *
:+ ,&
IServerUsAsistenciaService- G
{ 
private 
readonly 
IEmpresaRepository +
empresaRepository, =
;= >
private 
readonly )
ISUMovAsistenciaCabRepository 6&
movAsistenciaCabRepository7 Q
;Q R
private 
readonly )
ISUMovAsistenciaDetRepository 6&
movAsistenciaDetRepository7 Q
;Q R
public %
ServerUsAsistenciaService (
(( )
IEmpresaRepository) ;
empresaRepository< M
,M N)
ISUMovAsistenciaCabRepository )&
movAsistenciaCabRepository* D
,D E)
ISUMovAsistenciaDetRepository )&
movAsistenciaDetRepository* D
) 
{ 	
this 
. 
empresaRepository "
=# $
empresaRepository% 6
;6 7
this 
. &
movAsistenciaCabRepository +
=, -&
movAsistenciaCabRepository. H
;H I
this 
. &
movAsistenciaDetRepository +
=, -&
movAsistenciaDetRepository. H
;H I
} 	
public 
void 
Register 
( #
SURegisterAsistenciaDto 4
dtoInsertAsistencia5 H
)H I
{ 	
var   
CompaniesList   
=   
empresaRepository    1
.  1 2
GetAll  2 8
(  8 9
)  9 :
.  : ;
Result  ; A
;  A B
int"" 
?"" 
nIdIdentidad"" 
="" 
CompaniesList""  -
.""- .
Where"". 3
(""3 4
i""4 5
=>""6 8
i""9 :
."": ;
Id""; =
==""> @
dtoInsertAsistencia""A T
.""T U
	IdCompany""U ^
)""^ _
.""_ `
Select""` f
(""f g
i""g h
=>""i k
i""l m
.""m n

IdServerUs""n x
)""x y
.""y z
FirstOrDefault	""z à
(
""à â
)
""â ä
;
""ä ã
if## 
(## 
nIdIdentidad## 
==## 
null##  $
)##$ %
{$$ 
return%% 
;%% 
}&& 
SUGetNewIdFilterDto(( 
newidFilterDto((  .
=((/ 0
new((1 4
SUGetNewIdFilterDto((5 H
(((H I
)((I J
;((J K
newidFilterDto)) 
.)) 
cod_tipo_solicitud)) -
=)). /
dtoInsertAsistencia))0 C
.))C D
CodTipoSolicitud))D T
;))T U
newidFilterDto** 
.** 
	identidad** $
=**% &
nIdIdentidad**' 3
??**4 6
$num**7 8
;**8 9
int++ 
nNewNroSolicitud++  
=++! "&
movAsistenciaCabRepository++# =
.++= >
GetNewId++> F
(++F G
newidFilterDto++G U
)++U V
.++V W
Result++W ]
;++] ^
int-- 
nidColaborador-- 
=--  &
movAsistenciaCabRepository--! ;
.--; <
GetIdEmployee--< I
(--I J
newidFilterDto--J X
.--X Y
	identidad--Y b
,--b c
$str--d n
)--n o
.--o p
Result--p v
;--v w
SUInsertMovCabDto// 
insertcabDto// *
=//+ ,
new//- 0
SUInsertMovCabDto//1 B
(//B C
)//C D
;//D E
insertcabDto11 
.11 
	identidad11 "
=11# $
nIdIdentidad11% 1
??112 4
$num115 6
;116 7
insertcabDto33 
.33 
codtiposolicitud33 )
=33* +
dtoInsertAsistencia33, ?
.33? @
CodTipoSolicitud33@ P
;33P Q
insertcabDto44 
.44 
nrosolicitud44 %
=44& '
nNewNroSolicitud44( 8
;448 9
insertcabDto55 
.55 

centroresp55 #
=55$ %
dtoInsertAsistencia55& 9
.559 :!
CentroResponsabilidad55: O
;55O P
insertcabDto66 
.66 
idtrabajador66 %
=66& '
nidColaborador66( 6
;666 7
insertcabDto77 
.77 

codsubtipo77 #
=77$ %
dtoInsertAsistencia77& 9
.779 :
CodSubTipoSolicitud77: M
;77M N
insertcabDto88 
.88 
fecha_mov_solicitud88 ,
=88- .
dtoInsertAsistencia88/ B
.88B C
FechaSolicitud88C Q
;88Q R
insertcabDto99 
.99 !
descripcion_solicitud99 .
=99/ 0
dtoInsertAsistencia991 D
.99D E
DescripcionSolcitud99E X
;99X Y&
movAsistenciaCabRepository:: &
.::& '
Insert::' -
(::- .
insertcabDto::. :
)::: ;
.::; <
Wait::< @
(::@ A
)::A B
;::B C
SUInsertMovDetDto>> 
insertdetDto>> *
=>>+ ,
new>>- 0
SUInsertMovDetDto>>1 B
(>>B C
)>>C D
;>>D E
insertdetDto?? 
.?? 
	identidad?? "
=??# $
nIdIdentidad??% 1
????2 4
$num??5 6
;??6 7
insertdetDto@@ 
.@@ 
num_solicitud@@ &
=@@' (
nNewNroSolicitud@@) 9
;@@9 :
insertdetDtoBB 
.BB 
cod_tipo_solicitudBB +
=BB, -
dtoInsertAsistenciaBB. A
.BBA B
CodTipoSolicitudBBB R
;BBR S
insertdetDtoCC 
.CC !
cod_subtipo_solicitudCC .
=CC/ 0
dtoInsertAsistenciaCC1 D
.CCD E
CodSubTipoSolicitudCCE X
;CCX Y
insertdetDtoDD 
.DD 
fecha_movimientoDD )
=DD* +
dtoInsertAsistenciaDD, ?
.DD? @
FechaSolicitudDD@ N
;DDN O
insertdetDtoEE 
.EE 
idtrabajadorEE %
=EE& '
nidColaboradorEE( 6
;EE6 7
insertdetDtoFF 
.FF 
fecha_hora_inicioFF *
=FF+ ,
dtoInsertAsistenciaFF- @
.FF@ A
fecha_hora_inicioFFA R
;FFR S
insertdetDtoGG 
.GG 
fecha_hora_finalGG )
=GG* +
dtoInsertAsistenciaGG, ?
.GG? @
fecha_hora_finalGG@ P
;GGP Q
insertdetDtoHH 
.HH "
fecha_hora_inicio_realHH /
=HH0 1
dtoInsertAsistenciaHH2 E
.HHE F"
fecha_hora_inicio_realHHF \
;HH\ ]
insertdetDtoII 
.II !
fecha_hora_final_realII .
=II/ 0
dtoInsertAsistenciaII1 D
.IID E!
fecha_hora_final_realIIE Z
;IIZ [&
movAsistenciaDetRepositoryJJ &
.JJ& '
InsertJJ' -
(JJ- .
insertdetDtoJJ. :
)JJ: ;
.JJ; <
WaitJJ< @
(JJ@ A
)JJA B
;JJB C
}KK 	
}MM 
}NN 