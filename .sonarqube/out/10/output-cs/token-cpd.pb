�
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Departamento\IServices\IExactusDepartamentoLogic.cs
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
} �
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Departamento\IServices\IExactusDepartamentoService.cs
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
} �
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Departamento\Services\ExactusDepartamentoLogic.cs
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
departmentList	OOw �
.
OO� �
Count
OO� �
(
OO� �
)
OO� �
,
OO� �
comp
OO� �
.
OO� �
Descripcion
OO� �
)
OO� �
)
OO� �
;
OO� �
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
FirstOrDefault	TTz �
(
TT� �
)
TT� �
;
TT� �
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
Areas	YY~ �
(
YY� �
)
YY� �
;
YY� �
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
DESCRIPCION	gg~ �
,
gg� �
comp
gg� �
.
gg� �
Descripcion
gg� �
)
gg� �
)
gg� �
;
gg� �
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
�� 	
private
�� 
void
�� 
SetParameterBase
�� &
(
��& '
)
��' (
{
�� 	
ParameterFilter
�� 
.
�� 
ApplicationName
�� +
=
��, -
	Constants
��. 7
.
��7 8
HumanManagemen
��8 F
.
��F G
ApplicationName
��G V
;
��V W
ParameterFilter
�� 
.
�� 
Module
�� "
=
��# $
	Constants
��% .
.
��. /
HumanManagemen
��/ =
.
��= >
ModuleCommon
��> J
;
��J K
}
�� 	
public
�� 
void
�� 
Start
�� 
(
�� 
)
�� 
{
�� 	
try
�� 
{
�� 
ParameterFilter
�� 
=
��  !
new
��" % 
ParameterFilterDto
��& 8
(
��8 9
)
��9 :
;
��: ;
SetParameter
�� 
(
�� 
)
�� 
;
�� 
ParameterFilter
�� 
.
��  
Key
��  #
=
��$ %
	Constants
��& /
.
��/ 0
HumanManagemen
��0 >
.
��> ?
Keys
��? C
.
��C D
FrequencyProcVH
��D S
;
��S T 
ParameterResultDto
�� "
result
��# )
=
��* +%
coreParameterRepository
��, C
.
��C D
GetValue
��D L
(
��L M
ParameterFilter
��M \
)
��\ ]
.
��] ^
Result
��^ d
;
��d e
feqProcessVh
�� 
=
�� 
new
�� "
Timer
��# (
(
��( )
result
��) /
.
��/ 0
ValueNumeric
��0 <
.
��< =
Value
��= B
)
��B C
;
��C D
feqProcessVh
�� 
.
�� 
Elapsed
�� $
+=
��% '"
feqProcessVh_Elapsed
��( <
;
��< =
ParameterFilter
�� 
.
��  
Key
��  #
=
��$ %
	Constants
��& /
.
��/ 0
HumanManagemen
��0 >
.
��> ?
Keys
��? C
.
��C D

HoraInicio
��D N
;
��N O 
ParameterResultDto
�� "
resultStartTime
��# 2
=
��3 4%
coreParameterRepository
��5 L
.
��L M
GetValue
��M U
(
��U V
ParameterFilter
��V e
)
��e f
.
��f g
Result
��g m
;
��m n
	StartTime
�� 
=
�� 
DateTime
�� $
.
��$ %
Parse
��% *
(
��* +
resultStartTime
��+ :
.
��: ;
ValueString
��; F
)
��F G
.
��G H
	TimeOfDay
��H Q
;
��Q R
ParameterFilter
�� 
.
��  
Key
��  #
=
��$ %
	Constants
��& /
.
��/ 0
HumanManagemen
��0 >
.
��> ?
Keys
��? C
.
��C D
HoraFin
��D K
;
��K L 
ParameterResultDto
�� "
resultEndTime
��# 0
=
��1 2%
coreParameterRepository
��3 J
.
��J K
GetValue
��K S
(
��S T
ParameterFilter
��T c
)
��c d
.
��d e
Result
��e k
;
��k l
EndTime
�� 
=
�� 
DateTime
�� "
.
��" #
Parse
��# (
(
��( )
resultEndTime
��) 6
.
��6 7
ValueString
��7 B
)
��B C
.
��C D
	TimeOfDay
��D M
;
��M N
feqProcessVh
�� 
.
�� 
Start
�� "
(
��" #
)
��# $
;
��$ %
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
_logger
�� 
.
�� 
LogError
��  
(
��  !
$str
��! K
+
��L M
ex
��N P
.
��P Q
Message
��Q X
)
��X Y
;
��Y Z
_logger
�� 
.
�� 
LogError
��  
(
��  !
$str
��! K
+
��L M
ex
��N P
.
��P Q

StackTrace
��Q [
)
��[ \
;
��\ ]
}
�� 
}
�� 	
void
�� "
feqProcessVh_Elapsed
�� !
(
��! "
object
��" (
sender
��) /
,
��/ 0
ElapsedEventArgs
��1 A
e
��B C
)
��C D
{
�� 	
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
string
��# )
.
��) *
Format
��* 0
(
��0 1
$str
��1 G
)
��G H
)
��H I
;
��I J
var
�� 

horaActual
�� 
=
�� 
DateTime
�� %
.
��% &
Now
��& )
.
��) *
	TimeOfDay
��* 3
;
��3 4
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
string
��# )
.
��) *
Format
��* 0
(
��0 1
$str
��1 F
,
��F G

horaActual
��H R
.
��R S
ToString
��S [
(
��[ \
)
��\ ]
)
��] ^
)
��^ _
;
��_ `
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
string
��# )
.
��) *
Format
��* 0
(
��0 1
$str
��1 F
,
��F G
	StartTime
��H Q
.
��Q R
ToString
��R Z
(
��Z [
)
��[ \
)
��\ ]
)
��] ^
;
��^ _
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
string
��# )
.
��) *
Format
��* 0
(
��0 1
$str
��1 F
,
��F G
EndTime
��H O
.
��O P
ToString
��P X
(
��X Y
)
��Y Z
)
��Z [
)
��[ \
;
��\ ]
if
�� 
(
�� 

horaActual
�� 
>=
�� 
	StartTime
�� '
&&
��( *

horaActual
��+ 5
<=
��6 8
EndTime
��9 @
)
��@ A
{
�� 
if
�� 
(
�� 
feqProcessDay
�� !
==
��" $
null
��% )
)
��) *
{
�� 
ParameterFilter
�� #
.
��# $
Key
��$ '
=
��( )
	Constants
��* 3
.
��3 4
HumanManagemen
��4 B
.
��B C
Keys
��C G
.
��G H
FrequencyProcDay
��H X
;
��X Y 
ParameterResultDto
�� &
resultProcessDay
��' 7
=
��8 9%
coreParameterRepository
��: Q
.
��Q R
GetValue
��R Z
(
��Z [
ParameterFilter
��[ j
)
��j k
.
��k l
Result
��l r
;
��r s
feqProcessDay
�� !
=
��" #
new
��$ '
Timer
��( -
(
��- .
resultProcessDay
��. >
.
��> ?
ValueNumeric
��? K
.
��K L
Value
��L Q
)
��Q R
;
��R S
feqProcessDay
�� !
.
��! "
Elapsed
��" )
+=
��* ,#
feqProcessDay_Elapsed
��- B
;
��B C
}
�� 
if
�� 
(
�� 
!
�� 
feqProcessDay
�� "
.
��" #
Enabled
��# *
&&
��+ -
!
��. /
	InProcess
��/ 8
)
��8 9
{
�� 
	InProcess
�� 
=
�� 
true
��  $
;
��$ %
Run
�� 
(
�� 
)
�� 
;
�� 
feqProcessDay
�� !
.
��! "
Start
��" '
(
��' (
)
��( )
;
��) *
}
�� 
}
�� 
else
�� 
{
�� 
if
�� 
(
�� 
feqProcessDay
�� !
!=
��" $
null
��% )
&&
��* ,
feqProcessDay
��- :
.
��: ;
Enabled
��; B
)
��B C
{
�� 
	InProcess
�� 
=
�� 
false
��  %
;
��% &
feqProcessDay
�� !
.
��! "
Stop
��" &
(
��& '
)
��' (
;
��( )
}
�� 
}
�� 
}
�� 	
void
�� #
feqProcessDay_Elapsed
�� "
(
��" #
object
��# )
sender
��* 0
,
��0 1
ElapsedEventArgs
��2 B
e
��C D
)
��D E
{
�� 	
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
string
��# )
.
��) *
Format
��* 0
(
��0 1
$str
��1 H
)
��H I
)
��I J
;
��J K
Run
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
void
�� 
Run
�� 
(
�� 
)
�� 
{
�� 	
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
string
��# )
.
��) *
Format
��* 0
(
��0 1
$str
��1 6
)
��6 7
)
��7 8
;
��8 9
Import
�� 
(
�� 
)
�� 
;
�� 
}
�� 	
}
�� 
}�� �
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Departamento\Services\ExactusDepartamentoService.cs
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
exactusDepartamentoLogic	v �
)
� �
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
}&& �
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Empleado\IServices\IExactusEmpleadoService.cs
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
} ��
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Empleado\Services\ExactusEmpleadoService.cs
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
�� 
(
�� 
var
�� 
comp
�� 
in
��  
CompaniesList
��! .
)
��. /
{
�� 
try
�� 
{
�� 
if
�� 
(
�� 
!
�� 
string
�� 
.
��  
IsNullOrEmpty
��  -
(
��- .
comp
��. 2
.
��2 3
Schema
��3 9
)
��9 :
)
��: ;
{
�� 
filterEmpleado
�� &
.
��& '
Scheme
��' -
=
��. /
comp
��0 4
.
��4 5
Schema
��5 ;
;
��; <
var
�� 
fullempleado
�� (
=
��) *'
exactusEmpleadoRepository
��+ D
.
��D E
GetAll
��E K
(
��K L
filterEmpleado
��L Z
)
��Z [
.
��[ \
Result
��\ b
;
��b c
_logger
�� 
.
��  
LogInformation
��  .
(
��. /
string
��/ 5
.
��5 6
Format
��6 <
(
��< =
$str
��= y
,
��y z
fullempleado��{ �
.��� �
	Empleados��� �
.��� �
Count��� �
(��� �
)��� �
,��� �
comp��� �
.��� �
Descripcion��� �
)��� �
)��� �
;��� �
int
�� 
nIdAreaDefault
�� *
=
��+ ,
	areaslist
��- 6
.
��6 7
Where
��7 <
(
��< =
i
��= >
=>
��? A
i
��B C
.
��C D
	IdEmpresa
��D M
==
��N P
comp
��Q U
.
��U V
Id
��V X
&&
��Y [
i
��\ ]
.
��] ^

CodExactus
��^ h
==
��i k
$str
��l p
)
��p q
.
��q r
Select
��r x
(
��x y
i
��y z
=>
��{ }
i
��~ 
.�� �
Id��� �
)��� �
.��� �
FirstOrDefault��� �
(��� �
)��� �
;��� �
int
�� 
nIdCargoDefault
�� +
=
��, -

Cargoslist
��. 8
.
��8 9
Where
��9 >
(
��> ?
i
��? @
=>
��A C
i
��D E
.
��E F
	IdEmpresa
��F O
==
��P R
comp
��S W
.
��W X
Id
��X Z
&&
��[ ]
i
��^ _
.
��_ `

CodExactus
��` j
==
��k m
$str
��n r
)
��r s
.
��s t
Select
��t z
(
��z {
i
��{ |
=>
��} 
i��� �
.��� �
Id��� �
)��� �
.��� �
FirstOrDefault��� �
(��� �
)��� �
;��� �
List
�� 
<
��  
ExactusEmpleadoDto
�� /
>
��/ 0"
importedEmployeeList
��1 E
=
��F G
new
��H K
List
��L P
<
��P Q 
ExactusEmpleadoDto
��Q c
>
��c d
(
��d e
)
��e f
;
��f g
foreach
�� 
(
��  !
var
��! $
emp
��% (
in
��) +
fullempleado
��, 8
.
��8 9
	Empleados
��9 B
)
��B C
{
�� 
var
�� 
exist
��  %
=
��& '
EmpleadosBD
��( 3
.
��3 4
Where
��4 9
(
��9 :
i
��: ;
=>
��< >
i
��? @
.
��@ A
	IdCompany
��A J
==
��K M
comp
��N R
.
��R S
Id
��S U
&&
��V X
i
��Y Z
.
��Z [
CodEmployee
��[ f
==
��g i
emp
��j m
.
��m n
EMPLEADO
��n v
)
��v w
.
��w x
FirstOrDefault��x �
(��� �
)��� �
;��� �
if
�� 
(
��  
exist
��  %
==
��& (
null
��) -
)
��- .
{
�� 
if
��  "
(
��# $
emp
��$ '
.
��' (
ESTADO_EMPLEADO
��( 7
==
��8 :
$str
��; A
)
��A B
{
��  !
continue
��$ ,
;
��, -
}
��  !
string
��  &
	FirstName
��' 0
=
��1 2
string
��3 9
.
��9 :
Empty
��: ?
;
��? @
string
��  &

SecondName
��' 1
=
��2 3
string
��4 :
.
��: ;
Empty
��; @
;
��@ A
emp
��  #
.
��# $
NOMBRE_PILA
��$ /
=
��0 1
emp
��2 5
.
��5 6
NOMBRE_PILA
��6 A
==
��B D
null
��E I
?
��J K
string
��L R
.
��R S
Empty
��S X
:
��Y Z
emp
��[ ^
.
��^ _
NOMBRE_PILA
��_ j
;
��j k
var
��  #
arNombre
��$ ,
=
��- .
emp
��/ 2
.
��2 3
NOMBRE_PILA
��3 >
.
��> ?
Trim
��? C
(
��C D
)
��D E
.
��E F
Split
��F K
(
��K L
$str
��L O
)
��O P
;
��P Q
if
��  "
(
��# $
arNombre
��$ ,
.
��, -
Length
��- 3
==
��4 6
$num
��7 8
)
��8 9
{
��  !
	FirstName
��$ -
=
��. /
arNombre
��0 8
[
��8 9
$num
��9 :
]
��: ;
;
��; <
}
��  !
else
��  $
if
��% '
(
��( )
arNombre
��) 1
.
��1 2
Length
��2 8
==
��9 ;
$num
��< =
)
��= >
{
��  !
	FirstName
��$ -
=
��. /
arNombre
��0 8
[
��8 9
$num
��9 :
]
��: ;
;
��; <

SecondName
��$ .
=
��/ 0
arNombre
��1 9
[
��9 :
$num
��: ;
]
��; <
;
��< =
}
��  !
else
��  $
if
��% '
(
��( )
arNombre
��) 1
.
��1 2
Length
��2 8
>
��9 :
$num
��; <
)
��< =
{
��  !
for
��$ '
(
��( )
int
��) ,
i
��- .
=
��/ 0
$num
��1 2
;
��2 3
i
��4 5
<
��6 7
arNombre
��8 @
.
��@ A
Length
��A G
;
��G H
i
��I J
++
��J L
)
��L M
{
��$ %
if
��( *
(
��+ ,
i
��, -
==
��. 0
$num
��1 2
)
��2 3
{
��( )
	FirstName
��, 5
=
��6 7
arNombre
��8 @
[
��@ A
i
��A B
]
��B C
;
��C D
}
��( )
else
��( ,
if
��- /
(
��0 1
i
��1 2
==
��3 5
$num
��6 7
)
��7 8
{
��( )

SecondName
��, 6
=
��7 8
arNombre
��9 A
[
��A B
i
��B C
]
��C D
;
��D E
}
��( )
else
��( ,
{
��( )

SecondName
��, 6
+=
��7 9
$str
��: =
+
��> ?
arNombre
��@ H
[
��H I
i
��I J
]
��J K
;
��K L
}
��( )
}
��$ %
}
��  !"
importedEmployeeList
��  4
.
��4 5
Add
��5 8
(
��8 9
new
��9 < 
ExactusEmpleadoDto
��= O
{
��  !
	CodPerson
��$ -
=
��. /
emp
��0 3
.
��3 4
EMPLEADO
��4 <
,
��< =
	FirstName
��$ -
=
��. /
	FirstName
��0 9
,
��9 :

SecondName
��$ .
=
��/ 0

SecondName
��1 ;
,
��; <
LastName
��$ ,
=
��- .
emp
��/ 2
.
��2 3
PRIMER_APELLIDO
��3 B
==
��C E
null
��F J
?
��K L
string
��M S
.
��S T
Empty
��T Y
:
��Z [
emp
��\ _
.
��_ `
PRIMER_APELLIDO
��` o
,
��o p
MotherLastName
��$ 2
=
��3 4
emp
��5 8
.
��8 9
SEGUNDO_APELLIDO
��9 I
==
��J L
null
��M Q
?
��R S
string
��T Z
.
��Z [
Empty
��[ `
:
��a b
emp
��c f
.
��f g
SEGUNDO_APELLIDO
��g w
,
��w x
plaza
��$ )
=
��* +
emp
��, /
.
��/ 0
PLAZA
��0 5
,
��5 6
IdSex
��$ )
=
��* +
emp
��, /
.
��/ 0
SEXO
��0 4
==
��5 7
$str
��8 ;
?
��< =
$num
��> @
:
��A B
$num
��C E
,
��E F
	BirthDate
��$ -
=
��. /
emp
��0 3
.
��3 4
FECHA_NACIMIENTO
��4 D
,
��D E
Identification
��$ 2
=
��3 4
emp
��5 8
.
��8 9
IDENTIFICACION
��9 G
,
��G H
IsNoDomiciled
��$ 1
=
��2 3
true
��4 8
,
��8 9
CodEmployee
��$ /
=
��0 1
emp
��2 5
.
��5 6
EMPLEADO
��6 >
,
��> ?
Email
��$ )
=
��* +
emp
��, /
.
��/ 0
E_MAIL
��0 6
,
��6 7
AdmissionDate
��$ 1
=
��2 3
emp
��4 7
.
��7 8
FECHA_INGRESO
��8 E
,
��E F
IsDependents
��$ 0
=
��1 2
true
��3 7
,
��7 8"
DateOffirstAdmission
��$ 8
=
��9 :
DateTime
��; C
.
��C D
Now
��D G
,
��G H&
UniversityGraduationDate
��$ <
=
��= >
null
��? C
,
��C D
CountryentryDate
��$ 4
=
��5 6
null
��7 ;
,
��; <
IdState
��$ +
=
��, -
emp
��. 1
.
��1 2
ESTADO_EMPLEADO
��2 A
==
��B D
$str
��E K
?
��L M
$num
��N P
:
��Q R
$num
��S U
,
��U V

CodeCharge
��$ .
=
��/ 0
emp
��1 4
.
��4 5
PUESTO
��5 ;
,
��; <
	IdCompany
��$ -
=
��. /
comp
��0 4
.
��4 5
Id
��5 7
,
��7 8
IdActive
��$ ,
=
��- .
emp
��/ 2
.
��2 3
ACTIVO
��3 9
==
��: <
$str
��= @
?
��A B
$num
��C E
:
��F G
$num
��H J
,
��J K
IdCivilStatus
��$ 1
=
��2 3
civilStatusList
��4 C
.
��C D
Where
��D I
(
��I J
i
��J K
=>
��L N
i
��O P
.
��P Q

ShortValue
��Q [
==
��\ ^
emp
��_ b
.
��b c
ESTADO_CIVIL
��c o
)
��o p
.
��p q
Select
��q w
(
��w x
i
��x y
=>
��z |
i
��} ~
.
��~ 
Id�� �
)��� �
.��� �
FirstOrDefault��� �
(��� �
)��� �
,��� �
	BloodType
��$ -
=
��. /
emp
��0 3
.
��3 4
TIPO_SANGRE
��4 ?
,
��? @
Passport
��$ ,
=
��- .
emp
��/ 2
.
��2 3
	PASAPORTE
��3 <
,
��< =
IdNationality
��$ 1
=
��2 3
nationalityList
��4 C
.
��C D
Where
��D I
(
��I J
i
��J K
=>
��L N
i
��O P
.
��P Q

ShortValue
��Q [
==
��\ ^
emp
��_ b
.
��b c
PAIS
��c g
)
��g h
.
��h i
Select
��i o
(
��o p
i
��p q
=>
��r t
i
��u v
.
��v w
Id
��w y
)
��y z
.
��z {
FirstOrDefault��{ �
(��� �
)��� �
,��� �
Sede
��$ (
=
��) *
emp
��+ .
.
��. /
	UBICACION
��/ 8
,
��8 9

CenterCost
��$ .
=
��/ 0
emp
��1 4
.
��4 5
CENTRO_COSTO
��5 A
,
��A B
CodeBank
��$ ,
=
��- .
emp
��/ 2
.
��2 3 
ENTIDAD_FINANCIERA
��3 E
,
��E F
AccountBank
��$ /
=
��0 1
emp
��1 4
.
��4 5
CUENTA_ENTIDAD
��5 C
,
��C D
Cciaccount_bank
��$ 3
=
��4 5
string
��6 <
.
��< =
Empty
��= B
,
��B C!
CurrencyAccountBank
��$ 7
=
��8 9
emp
��: =
.
��= >
RUBRO7
��> D
,
��D E
CodeBankCts
��$ /
=
��/ 0
emp
��1 4
.
��4 5
RUBRO10
��5 <
,
��< =

AccountCts
��$ .
=
��. /
emp
��0 3
.
��3 4
RUBRO9
��4 :
,
��: ;
CurrencyCts
��$ /
=
��/ 0
emp
��1 4
.
��4 5
RUBRO8
��5 ;
,
��; <
AfpCode
��$ +
=
��+ ,
emp
��- 0
.
��0 1
RUBRO6
��1 7
,
��7 8
DEPARTAMENTO_DIR
��$ 4
=
��5 6
emp
��6 9
.
��9 :
DEPARTAMENTO_DIR
��: J
,
��J K
	PROVINCIA
��$ -
=
��. /
emp
��0 3
.
��3 4
	PROVINCIA
��4 =
,
��= >
DISTRITO
��$ ,
=
��. /
emp
��0 3
.
��3 4
DISTRITO
��4 <
,
��= >
DIRECCIONEMP
��$ 0
=
��1 2
emp
��3 6
.
��6 7
DIRECCIONEMP
��7 C
,
��C D
	TELEFONO1
��$ -
=
��. /
emp
��0 3
.
��3 4
	TELEFONO1
��4 =
,
��= >
	TELEFONO2
��$ -
=
��. /
emp
��0 3
.
��3 4
	TELEFONO2
��4 =
,
��= >
	TELEFONO3
��$ -
=
��- .
emp
��/ 2
.
��2 3
	TELEFONO3
��3 <
,
��< ="
DIVISION_GEOGRAFICA2
��$ 8
=
��9 :
emp
��; >
.
��> ?"
DIVISION_GEOGRAFICA2
��? S
}
��  !
)
��! "
;
��" #
}
�� 
else
��  
{
��! "
if
��  "
(
��# $
emp
��$ '
.
��' (
EMPLEADO
��( 0
==
��1 3
$str
��4 >
)
��> ?
{
��  !
var
��$ '
ddd
��( +
=
��, -
$str
��. 0
;
��0 1
}
��  !
int
��  # 
nIdStateExactusEmp
��$ 6
=
��7 8
emp
��9 <
.
��< =
ESTADO_EMPLEADO
��= L
==
��M O
$str
��P V
?
��W X
$num
��Y [
:
��\ ]
$num
��^ `
;
��` a
if
��  "
(
��# $
exist
��$ )
.
��) *
IdState
��* 1
!=
��2 4 
nIdStateExactusEmp
��5 G
)
��G H
{
��  !
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$str
��; v
,
��v w
emp
��x {
.
��{ |
NOMBRE_PILA��| �
,��� �
emp��� �
.��� �
ESTADO_EMPLEADO��� �
)��� �
;��� �
exist
��$ )
.
��) *
IdState
��* 1
=
��2 3 
nIdStateExactusEmp
��4 F
;
��F G
}
��  !
if
��  "
(
��# $
emp
��$ '
.
��' (
ESTADO_EMPLEADO
��( 7
!=
��8 :
$str
��; A
)
��A B
{
��  !
var
��$ '
personaupdate
��( 5
=
��6 7"
basePersonRepository
��8 L
.
��L M
Find
��M Q
(
��Q R
exist
��R W
.
��W X
IdPerson
��X `
)
��` a
.
��a b
Result
��b h
;
��h i
string
��$ *
	FirstName
��+ 4
=
��5 6
string
��7 =
.
��= >
Empty
��> C
;
��C D
string
��$ *

SecondName
��+ 5
=
��6 7
string
��8 >
.
��> ?
Empty
��? D
;
��D E
emp
��$ '
.
��' (
NOMBRE_PILA
��( 3
=
��4 5
emp
��6 9
.
��9 :
NOMBRE_PILA
��: E
==
��F H
null
��I M
?
��N O
string
��P V
.
��V W
Empty
��W \
:
��] ^
emp
��_ b
.
��b c
NOMBRE_PILA
��c n
;
��n o
var
��$ '
arNombre
��( 0
=
��1 2
emp
��3 6
.
��6 7
NOMBRE_PILA
��7 B
.
��B C
Trim
��C G
(
��G H
)
��H I
.
��I J
Split
��J O
(
��O P
$str
��P S
)
��S T
;
��T U
if
��$ &
(
��' (
arNombre
��( 0
.
��0 1
Length
��1 7
==
��8 :
$num
��; <
)
��< =
{
��$ %
	FirstName
��( 1
=
��2 3
arNombre
��4 <
[
��< =
$num
��= >
]
��> ?
;
��? @
}
��$ %
else
��$ (
if
��) +
(
��, -
arNombre
��- 5
.
��5 6
Length
��6 <
==
��= ?
$num
��@ A
)
��A B
{
��$ %
	FirstName
��( 1
=
��2 3
arNombre
��4 <
[
��< =
$num
��= >
]
��> ?
;
��? @

SecondName
��( 2
=
��3 4
arNombre
��5 =
[
��= >
$num
��> ?
]
��? @
;
��@ A
}
��$ %
else
��$ (
if
��) +
(
��, -
arNombre
��- 5
.
��5 6
Length
��6 <
>
��= >
$num
��? @
)
��@ A
{
��$ %
for
��( +
(
��, -
int
��- 0
i
��1 2
=
��3 4
$num
��5 6
;
��6 7
i
��8 9
<
��: ;
arNombre
��< D
.
��D E
Length
��E K
;
��K L
i
��M N
++
��N P
)
��P Q
{
��( )
if
��, .
(
��/ 0
i
��0 1
==
��2 4
$num
��5 6
)
��6 7
{
��, -
	FirstName
��0 9
=
��: ;
arNombre
��< D
[
��D E
i
��E F
]
��F G
;
��G H
}
��, -
else
��, 0
if
��1 3
(
��4 5
i
��5 6
==
��7 9
$num
��: ;
)
��; <
{
��, -

SecondName
��0 :
=
��; <
arNombre
��= E
[
��E F
i
��F G
]
��G H
;
��H I
}
��, -
else
��, 0
{
��, -

SecondName
��0 :
+=
��; =
$str
��> A
+
��B C
arNombre
��D L
[
��L M
i
��M N
]
��N O
;
��O P
}
��, -
}
��( )
}
��$ %
personaupdate
��$ 1
.
��1 2
	FirstName
��2 ;
=
��< =
	FirstName
��> G
;
��G H
personaupdate
��$ 1
.
��1 2

SecondName
��2 <
=
��= >

SecondName
��? I
;
��I J
personaupdate
��$ 1
.
��1 2
LastName
��2 :
=
��; <
emp
��= @
.
��@ A
PRIMER_APELLIDO
��A P
==
��Q S
null
��T X
?
��Y Z
string
��[ a
.
��a b
Empty
��b g
:
��h i
emp
��j m
.
��m n
PRIMER_APELLIDO
��n }
;
��} ~
personaupdate
��$ 1
.
��1 2
MotherLastName
��2 @
=
��A B
emp
��C F
.
��F G
SEGUNDO_APELLIDO
��G W
==
��X Z
null
��[ _
?
��` a
string
��b h
.
��h i
Empty
��i n
:
��o p
emp
��q t
.
��t u
SEGUNDO_APELLIDO��u �
;��� �
personaupdate
��$ 1
.
��1 2
IdSex
��2 7
=
��8 9
emp
��: =
.
��= >
SEXO
��> B
==
��C E
$str
��F I
?
��J K
$num
��L N
:
��O P
$num
��Q S
;
��S T
personaupdate
��$ 1
.
��1 2
	BirthDate
��2 ;
=
��< =
emp
��> A
.
��A B
FECHA_NACIMIENTO
��B R
;
��R S
exist
��$ )
.
��) *
plaza
��* /
=
��0 1
emp
��2 5
.
��5 6
PLAZA
��6 ;
;
��; <
personaupdate
��$ 1
.
��1 2
Email
��2 7
=
��8 9
emp
��: =
.
��= >
E_MAIL
��> D
;
��D E
exist
��$ )
.
��) *
AdmissionDate
��* 7
=
��8 9
emp
��: =
.
��= >
FECHA_INGRESO
��> K
;
��K L
personaupdate
��$ 1
.
��1 2
IdCivilStatus
��2 ?
=
��@ A
civilStatusList
��B Q
.
��Q R
Where
��R W
(
��W X
i
��X Y
=>
��Z \
i
��] ^
.
��^ _

ShortValue
��_ i
==
��j l
emp
��m p
.
��p q
ESTADO_CIVIL
��q }
)
��} ~
.
��~ 
Select�� �
(��� �
i��� �
=>��� �
i��� �
.��� �
Id��� �
)��� �
.��� �
FirstOrDefault��� �
(��� �
)��� �
;��� �
personaupdate
��$ 1
.
��1 2
	BloodType
��2 ;
=
��< =
emp
��> A
.
��A B
TIPO_SANGRE
��B M
;
��M N
personaupdate
��$ 1
.
��1 2
Passport
��2 :
=
��; <
emp
��= @
.
��@ A
	PASAPORTE
��A J
;
��J K
personaupdate
��$ 1
.
��1 2
IdNationality
��2 ?
=
��@ A
nationalityList
��B Q
.
��Q R
Where
��R W
(
��W X
i
��X Y
=>
��Z \
i
��] ^
.
��^ _

ShortValue
��_ i
==
��j l
emp
��m p
.
��p q
PAIS
��q u
)
��u v
.
��v w
Select
��w }
(
��} ~
i
��~ 
=>��� �
i��� �
.��� �
Id��� �
)��� �
.��� �
FirstOrDefault��� �
(��� �
)��� �
;��� �
exist
��$ )
.
��) *
Sede
��* .
=
��/ 0
emp
��1 4
.
��4 5
	UBICACION
��5 >
;
��> ?
exist
��$ )
.
��) *

CenterCost
��* 4
=
��5 6
emp
��7 :
.
��: ;
CENTRO_COSTO
��; G
;
��G H
exist
��$ )
.
��) *
CodeBank
��* 2
=
��3 4
emp
��5 8
.
��8 9 
ENTIDAD_FINANCIERA
��9 K
;
��K L
exist
��$ )
.
��) *
AccountBank
��* 5
=
��6 7
emp
��8 ;
.
��; <
CUENTA_ENTIDAD
��< J
;
��J K
exist
��$ )
.
��) *
Cciaccount_bank
��* 9
=
��: ;
string
��< B
.
��B C
Empty
��C H
;
��H I
exist
��$ )
.
��) *!
CurrencyAccountBank
��* =
=
��> ?
emp
��@ C
.
��C D
RUBRO7
��D J
;
��J K
exist
��$ )
.
��) *
CodeBankCts
��* 5
=
��6 7
emp
��8 ;
.
��; <
RUBRO10
��< C
;
��C D
exist
��$ )
.
��) *

AccountCts
��* 4
=
��5 6
emp
��7 :
.
��: ;
RUBRO9
��; A
;
��A B
exist
��$ )
.
��) *
CurrencyCts
��* 5
=
��6 7
emp
��8 ;
.
��; <
RUBRO8
��< B
;
��B C
exist
��$ )
.
��) *
AfpCode
��* 1
=
��2 3
emp
��4 7
.
��7 8
RUBRO6
��8 >
;
��> ?
int
��$ '
?
��' (
su_entsegvida
��) 6
=
��7 8
null
��9 =
;
��= >
if
��$ &
(
��' (
!
��( )
string
��) /
.
��/ 0
IsNullOrEmpty
��0 =
(
��= >
emp
��> A
.
��A B
U_ENTSEGVIDA
��B N
)
��N O
)
��O P
{
��$ %
su_entsegvida
��( 5
=
��6 7
int
��8 ;
.
��; <
Parse
��< A
(
��A B
emp
��B E
.
��E F
U_ENTSEGVIDA
��F R
)
��R S
;
��S T
}
��$ %
exist
��$ )
.
��) *
su_entsegvida
��* 7
=
��8 9
su_entsegvida
��: G
;
��G H
int
��$ '
?
��' (

su_planeps
��) 3
=
��4 5
null
��6 :
;
��: ;
if
��$ &
(
��' (
!
��( )
string
��) /
.
��/ 0
IsNullOrEmpty
��0 =
(
��= >
emp
��> A
.
��A B
	U_PLANEPS
��B K
)
��K L
)
��L M
{
��$ %

su_planeps
��( 2
=
��3 4
int
��5 8
.
��8 9
Parse
��9 >
(
��> ?
emp
��? B
.
��B C
	U_PLANEPS
��C L
)
��L M
;
��M N
}
��$ %
exist
��$ )
.
��) *

su_planeps
��* 4
=
��5 6

su_planeps
��7 A
;
��A B
int
��$ '
?
��' (
su_plansegpri
��) 6
=
��7 8
null
��9 =
;
��= >
if
��$ &
(
��' (
!
��( )
string
��) /
.
��/ 0
IsNullOrEmpty
��0 =
(
��= >
emp
��> A
.
��A B
U_PLANSEGPRI
��B N
)
��N O
)
��O P
{
��$ %
su_plansegpri
��( 5
=
��6 7
int
��8 ;
.
��; <
Parse
��< A
(
��A B
emp
��B E
.
��E F
U_PLANSEGPRI
��F R
)
��R S
;
��S T
}
��$ %
exist
��$ )
.
��) *
su_plansegpri
��* 7
=
��8 9
su_plansegpri
��: G
;
��G H
int
��$ '
?
��' (
su_sctrsalud
��) 5
=
��6 7
null
��8 <
;
��< =
if
��$ &
(
��' (
emp
��( +
.
��+ ,
U_SCTRSALUD
��, 7
!=
��8 :
null
��; ?
)
��? @
{
��$ %
su_sctrsalud
��( 4
=
��5 6
int
��7 :
.
��: ;
Parse
��; @
(
��@ A
emp
��A D
.
��D E
U_SCTRSALUD
��E P
.
��P Q
ToString
��Q Y
(
��Y Z
)
��Z [
)
��[ \
;
��\ ]
}
��$ %
exist
��$ )
.
��) *
su_sctrsalud
��* 6
=
��7 8
su_sctrsalud
��9 E
;
��E F
int
��$ '
?
��' (
su_entsegpract
��) 7
=
��8 9
null
��: >
;
��> ?
if
��$ &
(
��' (
!
��( )
string
��) /
.
��/ 0
IsNullOrEmpty
��0 =
(
��= >
emp
��> A
.
��A B
U_ENTSEGPRACT
��B O
)
��O P
)
��P Q
{
��$ %
su_entsegpract
��( 6
=
��7 8
int
��9 <
.
��< =
Parse
��= B
(
��B C
emp
��C F
.
��F G
U_ENTSEGPRACT
��G T
)
��T U
;
��U V
}
��$ %
exist
��$ )
.
��) *
su_entsegpract
��* 8
=
��9 :
su_entsegpract
��; I
;
��I J
var
��$ '!
inserbackupempleado
��( ;
=
��< =
personRepository
��> N
.
��N O$
RegisterBackupEmpleado
��O e
(
��e f
personaupdate
��f s
.
��s t
	CodPerson
��t }
)
��} ~
.
��~ 
Result�� �
;��� �"
basePersonRepository
��$ 8
.
��8 9
Update
��9 ?
(
��? @
personaupdate
��@ M
)
��M N
.
��N O
Wait
��O S
(
��S T
)
��T U
;
��U V$
baseEmployeeRepository
��$ :
.
��: ;
Update
��; A
(
��A B
exist
��B G
)
��G H
.
��H I
Wait
��I M
(
��M N
)
��N O
;
��O P
}
��  !
}
�� 
}
�� "
importedEmployeeList
�� ,
.
��, -
ForEach
��- 4
(
��4 5
x
��5 6
=>
��7 9
{
�� 
int
�� 

idPosition
��  *
=
��+ ,

Cargoslist
��- 7
.
��7 8
Where
��8 =
(
��= >
i
��> ?
=>
��@ B
i
��C D
.
��D E
	IdEmpresa
��E N
==
��O Q
x
��R S
.
��S T
	IdCompany
��T ]
&&
��^ `
i
��a b
.
��b c

CodExactus
��c m
==
��n p
x
��q r
.
��r s

CodeCharge
��s }
)
��} ~
.
��~ 
Select�� �
(��� �
i��� �
=>��� �
i��� �
.��� �
Id��� �
)��� �
.��� �
FirstOrDefault��� �
(��� �
)��� �
;��� �
if
�� 
(
��  

idPosition
��  *
==
��+ -
$num
��. /
)
��/ 0
{
��1 2

idPosition
��  *
=
��+ ,
nIdCargoDefault
��- <
;
��< =
}
�� 
x
�� 
.
�� 

IdPosition
�� (
=
��) *

idPosition
��+ 5
;
��5 6
int
�� 
idCtsOriginBank
��  /
=
��0 1
bankList
��2 :
.
��: ;
Where
��; @
(
��@ A
i
��A B
=>
��C E
i
��F G
.
��G H
CodeBank
��H P
==
��Q S
x
��T U
.
��U V
CtsOriginBank
��V c
)
��c d
.
��d e
Select
��e k
(
��k l
i
��l m
=>
��n p
i
��q r
.
��r s
Id
��s u
)
��u v
.
��v w
FirstOrDefault��w �
(��� �
)��� �
;��� �
if
�� 
(
��  
idCtsOriginBank
��  /
>
��0 1
$num
��2 3
)
��3 4
{
�� 
x
��  !
.
��! "
IdCtsOriginBank
��" 1
=
��2 3
idCtsOriginBank
��4 C
;
��C D
}
�� 
int
�� 
idOriginBank
��  ,
=
��- .
bankList
��/ 7
.
��7 8
Where
��8 =
(
��= >
i
��> ?
=>
��@ B
i
��C D
.
��D E
CodeBank
��E M
==
��N P
x
��Q R
.
��R S$
OriginBankRemuneration
��S i
)
��i j
.
��j k
Select
��k q
(
��q r
i
��r s
=>
��t v
i
��w x
.
��x y
Id
��y {
)
��{ |
.
��| }
FirstOrDefault��} �
(��� �
)��� �
;��� �
if
�� 
(
��  
idOriginBank
��  ,
>
��- .
$num
��/ 0
)
��0 1
{
�� 
x
��  !
.
��! "
IdOriginBank
��" .
=
��/ 0
idOriginBank
��1 =
;
��= >
}
�� 
int
�� 
idFinancialEntity
��  1
=
��2 3
bankList
��4 <
.
��< =
Where
��= B
(
��B C
i
��C D
=>
��E G
i
��H I
.
��I J
CodeBank
��J R
==
��S U
x
��V W
.
��W X
FinancialEntity
��X g
)
��g h
.
��h i
Select
��i o
(
��o p
i
��p q
=>
��r t
i
��u v
.
��v w
Id
��w y
)
��y z
.
��z {
FirstOrDefault��{ �
(��� �
)��� �
;��� �
if
�� 
(
��  
idFinancialEntity
��  1
>
��2 3
$num
��4 5
)
��5 6
{
�� 
x
��  !
.
��! "
IdFinancialEntity
��" 3
=
��4 5
idFinancialEntity
��6 G
;
��G H
}
�� 
}
�� 
)
�� 
;
�� "
importedEmployeeList
�� ,
.
��, -
ForEach
��- 4
(
��4 5
x
��5 6
=>
��7 9
{
�� 
var
�� 
person
��  &
=
��' (
mapper
��) /
.
��/ 0
Map
��0 3
<
��3 4
PersonModel
��4 ?
>
��? @
(
��@ A
x
��A B
)
��B C
;
��C D
var
�� 
employee
��  (
=
��) *
mapper
��+ 1
.
��1 2
Map
��2 5
<
��5 6
EmployeeModel
��6 C
>
��C D
(
��D E
x
��E F
)
��F G
;
��G H
var
�� 
employeeFile
��  ,
=
��- .
mapper
��/ 5
.
��5 6
Map
��6 9
<
��9 :
EmployeeFile
��: F
>
��F G
(
��G H
x
��H I
)
��I J
;
��J K
employee
�� $
.
��$ %
DateRegister
��% 1
=
��2 3
DateTime
��4 <
.
��< =
Now
��= @
;
��@ A
employee
�� $
.
��$ %

DateUpdate
��% /
=
��0 1
DateTime
��2 :
.
��: ;
Now
��; >
;
��> ?
employee
�� $
.
��$ %
IdUserRegister
��% 3
=
��4 5
$num
��6 7
;
��7 8
employee
�� $
.
��$ %
IdUserUpdate
��% 1
=
��2 3
$num
��4 5
;
��5 6
employeeFile
�� (
.
��( )
DateRegister
��) 5
=
��6 7
DateTime
��8 @
.
��@ A
Now
��A D
;
��D E
employeeFile
�� (
.
��( )

DateUpdate
��) 3
=
��4 5
DateTime
��6 >
.
��> ?
Now
��? B
;
��B C
employeeFile
�� (
.
��( )
IdUserRegister
��) 7
=
��8 9
$num
��: ;
;
��; <
employeeFile
�� (
.
��( )
IdUserUpdate
��) 5
=
��6 7
$num
��8 9
;
��9 :
person
�� "
.
��" #
Active
��# )
=
��* +
employee
��, 4
.
��4 5
IdState
��5 <
==
��= ?
$num
��@ B
?
��C D
true
��E I
:
��J K
false
��L Q
;
��Q R
bool
��  
exist
��! &
=
��' ("
basePersonRepository
��) =
.
��= >
Exist
��> C
(
��C D
x
��D E
=>
��F H
x
��I J
.
��J K
	CodPerson
��K T
.
��T U
Equals
��U [
(
��[ \
person
��\ b
.
��b c
	CodPerson
��c l
)
��l m
)
��m n
.
��n o
Result
��o u
;
��u v
if
�� 
(
��  
!
��  !
exist
��! &
)
��& '
{
�� 
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
string
��7 =
.
��= >
Format
��> D
(
��D E
$str
��E y
,
��y z
$"
��{ }
{
��} ~
person��~ �
.��� �
	FirstName��� �
}��� �
$str��� �
{��� �
person��� �
.��� �

SecondName��� �
}��� �
$str��� �
{��� �
person��� �
.��� �
LastName��� �
}��� �
$str��� �
{��� �
person��� �
.��� �
MotherLastName��� �
}��� �
"��� �
,��� �
comp��� �
.��� �
Descripcion��� �
)��� �
)��� �
;��� �
try
��  #
{
��  !
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$str
��; [
)
��[ \
;
��\ ]"
basePersonRepository
��$ 8
.
��8 9
Add
��9 <
(
��< =
person
��= C
)
��C D
.
��D E
Wait
��E I
(
��I J
)
��J K
;
��K L
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 X
+
��Y Z
ex
��[ ]
.
��] ^
Message
��^ e
)
��e f
;
��f g
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 X
+
��Y Z
ex
��[ ]
.
��] ^

StackTrace
��^ h
)
��h i
;
��i j
}
��  !
employee
��  (
.
��( )
IdPerson
��) 1
=
��2 3
person
��4 :
.
��: ;
Id
��; =
;
��= >
try
��  #
{
��  !
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$str
��; ]
)
��] ^
;
��^ _
employee
��$ ,
.
��, -
ExistsInExactus
��- <
=
��= >
true
��? C
;
��C D
employee
��$ ,
.
��, -
IdCostcenter
��- 9
=
��: ;
$num
��< =
;
��= >
employee
��$ ,
.
��, -
	IdPayroll
��- 6
=
��7 8
$num
��9 :
;
��: ;$
baseEmployeeRepository
��$ :
.
��: ;
Add
��; >
(
��> ?
employee
��? G
)
��G H
.
��H I
Wait
��I M
(
��M N
)
��N O
;
��O P
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 Z
+
��[ \
ex
��] _
.
��_ `
Message
��` g
)
��g h
;
��h i
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 Z
+
��[ \
ex
��] _
.
��_ `

StackTrace
��` j
)
��j k
;
��k l
}
��  !
employeeFile
��  ,
.
��, -

IdEmployee
��- 7
=
��8 9
employee
��: B
.
��B C
Id
��C E
;
��E F
try
��  #
{
��  !
var
��$ '
inseraddres
��( 3
=
��4 5
personRepository
��6 F
.
��F G)
InsertAddressPersonByUbigeo
��G b
(
��b c
x
��d e
.
��e f"
DIVISION_GEOGRAFICA2
��f z
,
��z {
x
��| }
.
��} ~
DIRECCIONEMP��~ �
,��� �
employee��� �
.��� �
IdPerson��� �
)��� �
.��� �
Result��� �
;��� �
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 Z
+
��[ \
ex
��] _
.
��_ `
Message
��` g
)
��g h
;
��h i
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 Z
+
��[ \
ex
��] _
.
��_ `

StackTrace
��` j
)
��j k
;
��k l
}
��  !
try
��  #
{
��  !
var
��$ '
estudios
��( 0
=
��1 2
fullempleado
��3 ?
.
��? @

Academicos
��@ J
.
��J K
Where
��K P
(
��P Q
i
��Q R
=>
��S U
i
��V W
.
��W X
EMPLEADO
��X `
==
��a c
x
��d e
.
��e f
	CodPerson
��f o
)
��p q
.
��q r
ToList
��r x
(
��x y
)
��y z
;
��z {
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$"
��; =
$str
��= L
{
��L M
estudios
��M U
.
��U V
Count
��V [
(
��[ \
)
��\ ]
}
��] ^
$str
��^ n
{
��n o
x
��o p
.
��p q
	CodPerson
��q z
}
��z {
$str
��{ |
"
��| }
)
��} ~
;
��~ 
foreach
��$ +
(
��, -
var
��- 0
est
��1 4
in
��5 7
estudios
��8 @
)
��@ A
{
��$ %
var
��( +
ins_estudio
��, 7
=
��8 9
personRepository
��: J
.
��J K"
InsertAcademicPerson
��K _
(
��_ `
est
��` c
.
��c d
TIPO_ACADEMICO
��d r
,
��r s
est
��s v
.
��v w
INSTITUCION��w �
,��� �
est��� �
.��� �
	CONCLUIDO��� �
,��� �
est
��, /
.
��/ 0
FECHA_OBTENCION
��0 ?
,
��? @
est
��@ C
.
��C D
FECHA_VENCIMIENTO
��D U
,
��U V
est
��V Y
.
��Y Z
U_PROFESION
��Z e
,
��e f
est
��f i
.
��i j
TITULO
��j p
,
��p q
x
��q r
.
��r s
	CodPerson
��s |
)
��| }
.
��} ~
Result��~ �
;��� �
}
��$ %
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 Z
+
��[ \
ex
��] _
.
��_ `
Message
��` g
)
��g h
;
��h i
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 Z
+
��[ \
ex
��] _
.
��_ `

StackTrace
��` j
)
��j k
;
��k l
}
��  !
try
��  #
{
��  !
List
��$ (
<
��( )
string
��) /
>
��/ 0
lstTelefonos
��1 =
=
��> ?
new
��@ C
List
��D H
<
��H I
string
��I O
>
��O P
(
��P Q
)
��Q R
;
��R S
if
��$ &
(
��' (
!
��( )
string
��) /
.
��/ 0
IsNullOrEmpty
��0 =
(
��= >
x
��> ?
.
��? @
	TELEFONO1
��@ I
)
��I J
&&
��K M
x
��N O
.
��O P
	TELEFONO1
��P Y
!=
��Y [
$str
��\ _
)
��_ `
{
��$ %
lstTelefonos
��( 4
.
��4 5
Add
��5 8
(
��8 9
x
��9 :
.
��: ;
	TELEFONO1
��; D
)
��D E
;
��E F
}
��$ %
if
��$ &
(
��' (
!
��( )
string
��) /
.
��/ 0
IsNullOrEmpty
��0 =
(
��= >
x
��> ?
.
��? @
	TELEFONO2
��@ I
)
��I J
&&
��K M
x
��N O
.
��O P
	TELEFONO2
��P Y
!=
��Z \
$str
��] `
)
��` a
{
��$ %
lstTelefonos
��( 4
.
��4 5
Add
��5 8
(
��8 9
x
��9 :
.
��: ;
	TELEFONO2
��; D
)
��D E
;
��E F
}
��$ %
if
��$ &
(
��' (
!
��( )
string
��) /
.
��/ 0
IsNullOrEmpty
��0 =
(
��= >
x
��> ?
.
��? @
	TELEFONO3
��@ I
)
��I J
&&
��K M
x
��N O
.
��O P
	TELEFONO3
��P Y
!=
��Z \
$str
��] `
)
��` a
{
��$ %
lstTelefonos
��( 4
.
��4 5
Add
��5 8
(
��8 9
x
��9 :
.
��: ;
	TELEFONO3
��; D
)
��D E
;
��E F
}
��$ %
if
��$ &
(
��' (
lstTelefonos
��( 4
.
��4 5
Any
��5 8
(
��8 9
)
��9 :
)
��: ;
{
��$ %
foreach
��( /
(
��0 1
var
��1 4
phonestring
��5 @
in
��A C
lstTelefonos
��D P
)
��P Q
{
��( )
Phone
��, 1

phoneModel
��2 <
=
��= >
new
��? B
Phone
��C H
(
��H I
)
��I J
;
��J K

phoneModel
��, 6
.
��6 7
IdPerson
��7 ?
=
��@ A
person
��B H
.
��H I
Id
��I K
;
��K L

phoneModel
��, 6
.
��6 7
DateRegister
��7 C
=
��D E
DateTime
��F N
.
��N O
Now
��O R
;
��R S

phoneModel
��, 6
.
��6 7
UserRegister
��7 C
=
��D E
$num
��F G
;
��G H

phoneModel
��, 6
.
��6 7
phone
��7 <
=
��= >
phonestring
��? J
;
��J K!
basePhoneRepository
��, ?
.
��? @
Add
��@ C
(
��C D

phoneModel
��D N
)
��N O
.
��O P
Wait
��P T
(
��T U
)
��U V
;
��V W
}
��( )
}
��$ %
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 _
+
��` a
ex
��b d
.
��d e
Message
��e l
)
��l m
;
��m n
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 _
+
��` a
ex
��b d
.
��d e

StackTrace
��e o
)
��o p
;
��p q
}
��  !
try
��  #
{
��  !
var
��$ '
experiencias
��( 4
=
��5 6
fullempleado
��7 C
.
��C D
Experiencias
��D P
.
��P Q
Where
��Q V
(
��V W
i
��W X
=>
��Y [
i
��\ ]
.
��] ^
EMPLEADO
��^ f
==
��g i
x
��j k
.
��k l
	CodPerson
��l u
)
��u v
.
��v w
ToList
��w }
(
��} ~
)
��~ 
;�� �
foreach
��$ +
(
��, -
var
��- 0
exp
��1 4
in
��5 7
experiencias
��8 D
)
��D E
{
��$ %
var
��( +
dtojob
��, 2
=
��3 4
new
��5 8
HumanManagement
��9 H
.
��H I
Domain
��I O
.
��O P
Employee
��P X
.
��X Y
Dto
��Y \
.
��\ ]
InsertJobDto
��] i
(
��i j
)
��j k
;
��k l
dtojob
��( .
.
��. /
namejob
��/ 6
=
��7 8
exp
��9 <
.
��< =
EMPRESA
��= D
;
��D E
dtojob
��( .
.
��. /
nid_employee
��/ ;
=
��< =
employee
��> F
.
��F G
Id
��G I
;
��I J
dtojob
��( .
.
��. /
positionjob
��/ :
=
��; <
exp
��= @
.
��@ A
PUESTO
��A G
;
��G H
dtojob
��( .
.
��. /
	sfunction
��/ 8
=
��9 :
exp
��; >
.
��> ?
	FUNCIONES
��? H
;
��H I
dtojob
��( .
.
��. /
timejob
��/ 6
=
��7 8
string
��9 ?
.
��? @
Empty
��@ E
;
��E F 
employeeRepository
��( :
.
��: ;
	InsertJob
��; D
(
��D E
dtojob
��E K
)
��K L
.
��L M
Wait
��M Q
(
��Q R
)
��R S
;
��S T
}
��$ %
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 _
+
��` a
ex
��b d
.
��d e
Message
��e l
)
��l m
;
��m n
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 _
+
��` a
ex
��b d
.
��d e

StackTrace
��e o
)
��o p
;
��p q
}
��  !
try
��  #
{
��  !
var
��$ '
familialist
��( 3
=
��4 5
fullempleado
��6 B
.
��B C
Familia
��C J
.
��J K
Where
��K P
(
��P Q
i
��Q R
=>
��S U
i
��V W
.
��W X
EMPLEADO
��X `
==
��a c
x
��d e
.
��e f
	CodPerson
��f o
)
��o p
.
��p q
ToList
��q w
(
��w x
)
��x y
;
��y z
foreach
��$ +
(
��, -
var
��- 0
familia
��1 8
in
��9 ;
familialist
��< G
)
��G H
{
��$ % 
employeeRepository
��( :
.
��: ;
	InsertSon
��; D
(
��D E
new
��E H
HumanManagement
��I X
.
��X Y
Domain
��Y _
.
��_ `
Employee
��` h
.
��h i
Dto
��i l
.
��l m
InsertSonDto
��m y
(
��y z
)
��z {
{
��( )
ddateofbirth
��, 8
=
��9 :
familia
��; B
.
��B C
FECHA_NACIMIENTO
��C S
==
��T V
null
��W [
?
��\ ]
DateTime
��^ f
.
��f g
Now
��g j
:
��k l
familia
��m t
.
��t u
FECHA_NACIMIENTO��u �
.��� �
Value��� �
,��� �
sfamilytype
��, 7
=
��7 8
familia
��9 @
.
��@ A
VINCULO
��A H
,
��H I
	sfullname
��, 5
=
��6 7
familia
��8 ?
.
��? @
NOMBRE
��@ F
,
��F G
	slastname
��, 5
=
��6 7
familia
��8 ?
.
��? @
PATERNO
��@ G
,
��G H
smotherslastname
��, <
=
��= >
familia
��? F
.
��F G
MATERNO
��G N
,
��N O
nid_employee
��, 8
=
��9 :
employee
��; C
.
��C D
Id
��D F
}
��( )
)
��) *
.
��* +
Wait
��+ /
(
��/ 0
)
��0 1
;
��1 2
}
��$ %
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 _
+
��` a
ex
��b d
.
��d e
Message
��e l
)
��l m
;
��m n
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 _
+
��` a
ex
��b d
.
��d e

StackTrace
��e o
)
��o p
;
��p q
}
��  !
try
��  #
{
��  !
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$str
��; a
)
��a b
;
��b c(
baseEmployeeFileRepository
��$ >
.
��> ?
Add
��? B
(
��B C
employeeFile
��C O
)
��O P
.
��P Q
Wait
��Q U
(
��U V
)
��V W
;
��W X
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 _
+
��` a
ex
��b d
.
��d e
Message
��e l
)
��l m
;
��m n
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 _
+
��` a
ex
��b d
.
��d e

StackTrace
��e o
)
��o p
;
��p q
}
��  !
User
��  $
user
��% )
=
��* +
new
��, /
User
��0 4
{
��  !
UserName
��$ ,
=
��- .
person
��/ 5
.
��5 6
	CodPerson
��6 ?
,
��? @
Password
��$ ,
=
��- .
person
��/ 5
.
��5 6
	CodPerson
��6 ?
,
��? @
IdPerson
��$ ,
=
��- .
person
��/ 5
.
��5 6
Id
��6 8
,
��8 9
Active
��$ *
=
��+ ,
person
��- 3
.
��3 4
Active
��4 :
,
��: ;
State
��$ )
=
��* +
$num
��, -
}
��  !
;
��! "
try
��  #
{
��  !
user
��$ (
.
��( ) 
SetEncryptPassword
��) ;
(
��; <
cryptography
��< H
)
��H I
;
��I J
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$str
��; Y
)
��Y Z
;
��Z [ 
baseUserRepository
��$ 6
.
��6 7
Add
��7 :
(
��: ;
user
��; ?
)
��? @
.
��@ A
Wait
��A E
(
��E F
)
��F G
;
��G H
}
��  !
catch
��  %
(
��& '
	Exception
��' 0
ex
��1 3
)
��3 4
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 V
+
��W X
ex
��Y [
.
��[ \
Message
��\ c
)
��c d
;
��d e
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$str
��5 V
+
��W X
ex
��Y [
.
��[ \

StackTrace
��\ f
)
��f g
;
��g h
}
��  !
UserMailDto
��  +
userMailDto
��, 7
=
��8 9
new
��: =
UserMailDto
��> I
{
��  !
UserName
��$ ,
=
��- .
user
��/ 3
.
��3 4
UserName
��4 <
,
��< =
Password
��$ ,
=
��- .
person
��/ 5
.
��5 6
	CodPerson
��6 ?
,
��? @
Email
��$ )
=
��* +
person
��, 2
.
��2 3
Email
��3 8
,
��8 9
FullName
��$ ,
=
��- .
$"
��/ 1
{
��1 2
person
��2 8
.
��8 9
	FirstName
��9 B
}
��B C
$str
��C D
{
��D E
person
��E K
.
��K L

SecondName
��L V
}
��V W
$str
��W Y
{
��Y Z
person
��Z `
.
��` a
LastName
��a i
}
��i j
$str
��j k
{
��k l
person
��l r
.
��r s
MotherLastName��s �
}��� �
"��� �
}
��  !
;
��! "
userMailDtoList
��  /
.
��/ 0
Add
��0 3
(
��3 4
userMailDto
��4 ?
)
��? @
;
��@ A
}
�� 
else
��  
{
��! "
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$str
��7 X
+
��Y Z
person
��[ a
.
��a b
	CodPerson
��b k
)
��k l
;
��l m
}
�� 
}
�� 
)
�� 
;
�� 
}
�� 
}
�� 
catch
�� 
(
�� 
	Exception
��  
ex
��! #
)
��# $
{
�� 
_logger
�� 
.
�� 
LogError
�� $
(
��$ %
$str
��% 8
+
��9 :
ex
��; =
.
��= >
Message
��> E
)
��E F
;
��F G
_logger
�� 
.
�� 
LogError
�� $
(
��$ %
$str
��% 8
+
��9 :
ex
��; =
.
��= >

StackTrace
��> H
)
��H I
;
��I J
}
�� 
}
�� 
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
)
��9 :
;
��: ;
}
�� 	
private
�� 
void
�� 
SendMail
�� 
(
�� 
)
�� 
{
�� 	
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# >
)
��> ?
;
��? @
userMailDtoList
�� 
.
�� 
ForEach
�� #
(
��# $
x
��$ %
=>
��& (
{
�� 
try
�� 
{
�� 
var
�� 
userRegistered
�� &
=
��' (
new
��) ,
UserRegistered
��- ;
(
��; <
x
��< =
)
��= >
;
��> ?
MailSenderUser
�� "
mailSenderUser
��# 1
=
��2 3
new
��4 7
MailSenderUser
��8 F
(
��F G

htmlReader
��G Q
,
��Q R
userRegistered
��S a
.
��a b
UserMail
��b j
)
��j k
;
��k l
var
�� 
objMail
�� 
=
��  !
mailSenderUser
��" 0
.
��0 1
GetMail
��1 8
(
��8 9
)
��9 :
;
��: ;
objMail
�� 
.
�� 
From
��  
=
��! "
Configuration
��# 0
[
��0 1
$str
��1 S
]
��S T
.
��T U
ToString
��U ]
(
��] ^
)
��^ _
;
��_ `
objMail
�� 
.
�� 
FromName
�� $
=
��% &
Configuration
��' 4
[
��4 5
$str
��5 W
]
��W X
.
��X Y
ToString
��Y a
(
��a b
)
��b c
;
��c d
_logger
�� 
.
�� 
LogInformation
�� *
(
��* +
string
��+ 1
.
��1 2
Format
��2 8
(
��8 9
$str
��9 P
,
��P Q
objMail
��R Y
.
��Y Z
To
��Z \
[
��\ ]
$num
��] ^
]
��^ _
.
��_ `
ToString
��` h
(
��h i
)
��i j
)
��j k
)
��k l
;
��l m
mailRepository
�� "
.
��" #
SendMail
��# +
(
��+ ,
objMail
��, 3
)
��3 4
;
��4 5
_logger
�� 
.
�� 
LogInformation
�� *
(
��* +
$str
��+ M
)
��M N
;
��N O
}
�� 
catch
�� 
(
�� 
	Exception
��  
ex
��! #
)
��$ %
{
�� 
_logger
�� 
.
�� 
LogError
�� $
(
��$ %
$str
��% :
+
��; <
ex
��= ?
.
��? @
Message
��@ G
)
��G H
;
��H I
_logger
�� 
.
�� 
LogError
�� $
(
��$ %
$str
��% :
+
��; <
ex
��= ?
.
��? @

StackTrace
��@ J
)
��J K
;
��K L
}
�� 
}
�� 
)
�� 
;
�� 
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# ;
)
��; <
;
��< =
}
�� 	
public
�� 
void
�� 
Export
�� 
(
�� 
)
�� 
{
�� 	
var
�� 
CompaniesList
�� 
=
�� 
empresaRepository
��  1
.
��1 2
GetAll
��2 8
(
��8 9
)
��9 :
.
��: ;
Result
��; A
;
��A B
var
�� "
empleadosporexportar
�� $
=
��% & 
employeeRepository
��' 9
.
��9 :&
EmployeeForSendToExactus
��: R
(
��R S
)
��S T
.
��T U
Result
��U [
;
��[ \
foreach
�� 
(
�� 
var
�� 
emp
�� 
in
�� "
empleadosporexportar
��  4
)
��4 5
{
�� 
var
�� 
person
�� 
=
�� "
basePersonRepository
�� 1
.
��1 2
Find
��2 6
(
��6 7
emp
��7 :
.
��: ;
IdPerson
��; C
)
��C D
.
��D E
Result
��E K
;
��K L
if
�� 
(
�� 
string
�� 
.
�� 
IsNullOrEmpty
�� (
(
��( )
person
��) /
.
��/ 0
	CodPerson
��0 9
)
��9 :
)
��: ;
{
�� 
continue
�� 
;
�� 
}
�� &
ExactusEmpleadoInsertDto
�� (
	dtoinsert
��) 2
=
��3 4
new
��5 8&
ExactusEmpleadoInsertDto
��9 Q
(
��Q R
)
��R S
;
��S T!
ExactusEALLEmpleado
�� #
modelEmpleado
��$ 1
=
��2 3
new
��4 7!
ExactusEALLEmpleado
��8 K
(
��K L
)
��L M
;
��M N
var
�� 
cargo
�� 
=
�� !
baseCargoRepository
�� /
.
��/ 0
Find
��0 4
(
��4 5
emp
��5 8
.
��8 9

IdPosition
��9 C
)
��C D
.
��D E
Result
��E K
;
��K L
var
�� 
area
�� 
=
��  
baseAreaRepository
�� -
.
��- .
Find
��. 2
(
��2 3
cargo
��3 8
.
��8 9
IdArea
��9 ?
)
��? @
.
��@ A
Result
��A G
;
��G H
	dtoinsert
�� 
.
�� 
Scheme
��  
=
��! "
CompaniesList
��# 0
.
��0 1
Where
��1 6
(
��6 7
i
��7 8
=>
��9 ;
i
��< =
.
��= >
Id
��> @
==
��A C
emp
��D G
.
��G H
	IdCompany
��H Q
)
��Q R
.
��R S
Select
��S Y
(
��Y Z
i
��Z [
=>
��\ ^
i
��_ `
.
��` a
Schema
��a g
)
��g h
.
��h i
FirstOrDefault
��i w
(
��w x
)
��x y
;
��y z
	dtoinsert
�� 
.
�� 
EMPLEADO
�� "
=
��# $
emp
��% (
.
��( )
CodEmployee
��) 4
;
��4 5
	dtoinsert
�� 
.
�� 
NOMBRE
��  
=
��! "
person
��# )
.
��) *
	FirstName
��* 3
+
��4 5
$str
��6 9
+
��: ;
person
��< B
.
��B C

SecondName
��C M
??
��N P
$str
��Q S
+
��T U
$str
��V Y
+
��Z [
person
��\ b
.
��b c
LastName
��c k
+
��l m
$str
��n q
+
��r s
person
��t z
.
��z {
MotherLastName��{ �
;��� �
	dtoinsert
�� 
.
�� 
SEXO
�� 
=
��  
person
��! '
.
��' (
IdSex
��( -
==
��. 0
$num
��1 3
?
��4 5
$str
��6 9
:
��: ;
$str
��< ?
;
��? @
	dtoinsert
�� 
.
�� 
ESTADO_EMPLEADO
�� )
=
��* +
$str
��, 2
;
��2 3
	dtoinsert
�� 
.
�� 
ACTIVO
��  
=
��! "
$str
��# &
;
��& '
	dtoinsert
�� 
.
�� 
FECHA_INGRESO
�� '
=
��( )
emp
��* -
.
��- .
AdmissionDate
��. ;
;
��; <
	dtoinsert
�� 
.
�� 
DEPARTAMENTO
�� &
=
��' (
area
��) -
.
��- .

CodExactus
��. 8
==
��9 ;
null
��< @
?
��A B
$str
��C G
:
��H I
area
��J N
.
��N O

CodExactus
��O Y
;
��Y Z
	dtoinsert
�� 
.
�� 
PUESTO
��  
=
��! "
cargo
��# (
.
��( )

CodExactus
��) 3
==
��4 6
null
��7 ;
?
��< =
$str
��> B
:
��C D
cargo
��E J
.
��J K

CodExactus
��K U
;
��U V
	dtoinsert
�� 
.
�� 
PLAZA
�� 
=
��  !
$str
��" &
;
��& '
	dtoinsert
�� 
.
�� 
NOMINA
��  
=
��! "
$str
��# '
;
��' (
	dtoinsert
�� 
.
�� 
CENTRO_COSTO
�� &
=
��' (
$str
��) -
;
��- .
	dtoinsert
�� 
.
�� 
FECHA_NACIMIENTO
�� *
=
��+ ,
person
��- 3
.
��3 4
	BirthDate
��4 =
==
��= ?
null
��@ D
?
��E F
DateTime
��H P
.
��P Q
Now
��Q T
:
��V W
person
��X ^
.
��^ _
	BirthDate
��_ h
.
��h i
Value
��i n
;
��n o
	dtoinsert
�� 
.
�� 
DIRECCION_HAB
�� (
=
��) *
$str��+ �
;��� �
	dtoinsert
�� 
.
�� 
	UBICACION
�� #
=
��$ %
$str
��& -
;
��- .
	dtoinsert
�� 
.
�� 
PAIS
�� 
=
��  
$str
��! &
;
��& '
	dtoinsert
�� 
.
�� 
ESTADO_CIVIL
�� &
=
��' (
$str
��) ,
;
��, -
	dtoinsert
�� 
.
�� 
VACS_PENDIENTES
�� )
=
��* +
$num
��, -
;
��- .
	dtoinsert
�� 
.
�� 
VACS_ULT_CALCULO
�� *
=
��+ ,
DateTime
��- 5
.
��5 6
Now
��6 9
;
��9 :
	dtoinsert
�� 
.
��  
SALARIO_REFERENCIA
�� ,
=
��- .
$num
��/ 0
;
��0 1
	dtoinsert
�� 
.
�� 

FORMA_PAGO
�� $
=
��% &
$str
��' *
;
��* +
	dtoinsert
�� 
.
�� 
HORARIO
�� !
=
��" #
$str
��$ *
;
��* +
	dtoinsert
�� 
.
�� 
FECHA_NO_PAGO
�� '
=
��( )
DateTime
��* 2
.
��2 3
Now
��3 6
;
��6 7
	dtoinsert
�� 
.
��  
TIPO_SALARIO_AUMEN
�� ,
=
��- .
$str
��/ 2
;
��2 3
	dtoinsert
�� 
.
�� 
VACS_ADICIONALES
�� *
=
��+ ,
$num
��- .
;
��. /
	dtoinsert
�� 
.
�� 
NoteExistsFlag
�� (
=
��) *
$num
��+ ,
;
��, -
	dtoinsert
�� 
.
�� 

RecordDate
�� $
=
��% &
DateTime
��' /
.
��/ 0
Now
��0 3
;
��3 4
	dtoinsert
�� 
.
�� 

RowPointer
�� $
=
��% &
Guid
��' +
.
��+ ,
NewGuid
��, 3
(
��3 4
)
��4 5
;
��5 6
	dtoinsert
�� 
.
�� 
	CreatedBy
�� #
=
��$ %
$str
��& *
;
��* +
	dtoinsert
�� 
.
�� 
	UpdatedBy
�� #
=
��$ %
$str
��& *
;
��* +
	dtoinsert
�� 
.
�� 

CreateDate
�� $
=
��% &
DateTime
��' /
.
��/ 0
Now
��0 3
;
��3 4
try
�� 
{
�� 
var
�� 
ninsert
�� !
=
��" #'
exactusEmpleadoRepository
��$ =
.
��= >
InsertEmpleado
��> L
(
��L M
	dtoinsert
��M V
)
��V W
.
��W X
Result
��X ^
;
��^ _
}
�� 
catch
�� 
(
�� 
	Exception
��  
ex
��! #
)
��# $
{
�� 
throw
�� 
;
�� 
}
�� 
}
�� 
}
�� 	
}
�� 
}�� �
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Nomina\IServices\IExactusNominaService.cs
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
} ��
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
NUMERO_NOMINA	{{t �
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
�� 
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$str
��7 z
)
��z {
;
��{ |
SalaryPayrollCab
��  0#
newsalaryPayrollCabBD
��1 F
=
��G H
new
��I L
SalaryPayrollCab
��M ]
(
��] ^
)
��^ _
;
��_ `#
newsalaryPayrollCabBD
��  5
.
��5 6
	IdCompany
��6 ?
=
��@ A
comp
��B F
.
��F G
Id
��G I
;
��I J#
newsalaryPayrollCabBD
��  5
.
��5 6
Year
��6 :
=
��; <
nYeadNomina
��= H
;
��H I#
newsalaryPayrollCabBD
��  5
.
��5 6
Month
��6 ;
=
��< =
nMonthNomina
��> J
;
��J K#
newsalaryPayrollCabBD
��  5
.
��5 6

NominaCode
��6 @
=
��A B
nominaexactuscab
��C S
.
��S T
NOMINA
��T Z
;
��Z [#
newsalaryPayrollCabBD
��  5
.
��5 6
NominaNumber
��6 B
=
��C D
nominaexactuscab
��E U
.
��U V
NUMERO_NOMINA
��V c
;
��c d#
newsalaryPayrollCabBD
��  5
.
��5 6
PERIODO
��6 =
=
��> ?
nominaexactuscab
��@ P
.
��P Q
PERIODO
��Q X
;
��X Y#
newsalaryPayrollCabBD
��  5
.
��5 6
FECHA_APROBACION
��6 F
=
��G H
nominaexactuscab
��I Y
.
��Y Z
FECHA_APROBACION
��Z j
;
��j k#
newsalaryPayrollCabBD
��  5
.
��5 6

FECHA_PAGO
��6 @
=
��A B
nominaexactuscab
��C S
.
��S T

FECHA_PAGO
��T ^
;
��^ _#
newsalaryPayrollCabBD
��  5
.
��5 6
APROBADA_POR
��6 B
=
��C D
nominaexactuscab
��E U
.
��U V
APROBADA_POR
��V b
;
��b c
var
��  #
nRegisterCabecera
��$ 5
=
��6 7"
salaryBandRepository
��8 L
.
��L M
RegisterNominaCab
��M ^
(
��^ _#
newsalaryPayrollCabBD
��_ t
)
��t u
.
��u v
Result
��v |
;
��| }
if
��  "
(
��# $
nRegisterCabecera
��$ 5
>
��6 7
$num
��8 9
)
��9 :
{
��  !
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$"
��; =
$str
��= a
{
��a b
nominaexactuscab
��b r
.
��r s
NOMINA
��s y
}
��y z
$str
��z {
{
��{ |
nominaexactuscab��} �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �
filterNomina
��$ 0
.
��0 1

NominaCode
��1 ;
=
��< =#
newsalaryPayrollCabBD
��> S
.
��S T

NominaCode
��T ^
;
��^ _
filterNomina
��$ 0
.
��0 1
NominaNumber
��1 =
=
��> ?#
newsalaryPayrollCabBD
��@ U
.
��U V
NominaNumber
��V b
;
��b c
var
��$ '
nominalistexactus
��( 9
=
��: ;%
exactusNominaRepository
��< S
.
��S T
GetAll
��T Z
(
��Z [
filterNomina
��[ g
)
��g h
.
��h i
Result
��i o
;
��o p
int
��$ '!
nTotalDetalleNomina
��( ;
=
��< =
nominalistexactus
��> O
.
��O P
Count
��P U
(
��U V
)
��V W
;
��W X
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$"
��; =
$str
��= I
{
��I J!
nTotalDetalleNomina
��K ^
}
��^ _
$str��_ �
{��� � 
nominaexactuscab��� �
.��� �
NOMINA��� �
}��� �
$str��� �
{��� � 
nominaexactuscab��� �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �
foreach
��$ +
(
��, -
var
��- 0
nominaexactusdet
��1 A
in
��B D
nominalistexactus
��E V
)
��V W
{
��$ %
SalaryPayrollDet
��( 8
newPayrollDet
��9 F
=
��G H
new
��I L
SalaryPayrollDet
��M ]
(
��] ^
)
��^ _
;
��_ `
newPayrollDet
��( 5
.
��5 6
	IdCompany
��6 ?
=
��@ A
comp
��B F
.
��F G
Id
��G I
;
��I J
newPayrollDet
��( 5
.
��5 6
Consecutive
��6 A
=
��B C
nominaexactusdet
��D T
.
��T U
CONSECUTIVO
��U `
;
��` a
newPayrollDet
��( 5
.
��5 6
CodEmployee
��6 A
=
��B C
nominaexactusdet
��D T
.
��T U
EMPLEADO
��U ]
;
��] ^
newPayrollDet
��( 5
.
��5 6
Concept
��6 =
=
��> ?
nominaexactusdet
��@ P
.
��P Q
CONCEPTO
��Q Y
;
��Y Z
newPayrollDet
��( 5
.
��5 6
Payroll
��6 =
=
��> ?
nominaexactusdet
��@ P
.
��P Q
NOMINA
��Q W
;
��W X
newPayrollDet
��( 5
.
��5 6
PayRollNumber
��6 C
=
��D E
nominaexactusdet
��F V
.
��V W
NUMERO_NOMINA
��W d
;
��d e
newPayrollDet
��( 5
.
��5 6

CostCenter
��6 @
=
��A B
nominaexactusdet
��C S
.
��S T
CENTRO_COSTO
��T `
;
��` a
newPayrollDet
��( 5
.
��5 6
Amount
��6 <
=
��= >
nominaexactusdet
��? O
.
��O P
MONTO
��P U
;
��U V
newPayrollDet
��( 5
.
��5 6
Total
��6 ;
=
��< =
nominaexactusdet
��> N
.
��N O
TOTAL
��O T
;
��T U
newPayrollDet
��( 5
.
��5 6
RegisterType
��6 B
=
��C D
nominaexactusdet
��E U
.
��U V
TIPO_REGISTRO
��V c
;
��c d
newPayrollDet
��( 5
.
��5 6
Active
��6 <
=
��= >
true
��? C
;
��C D
newPayrollDet
��( 5
.
��5 6
IdUserRegister
��6 D
=
��E F
$num
��G H
;
��H I
newPayrollDet
��( 5
.
��5 6
DateRegister
��6 B
=
��C D
DateTime
��E M
.
��M N
Now
��N Q
;
��Q R
newPayrollDet
��( 5
.
��5 6
IdUserUpdate
��6 B
=
��C D
$num
��E F
;
��F G
newPayrollDet
��( 5
.
��5 6

DateUpdate
��6 @
=
��A B
DateTime
��C K
.
��K L
Now
��L O
;
��O P
int
��( +
nresuldetail
��, 8
=
��9 :"
salaryBandRepository
��; O
.
��O P"
RegisterNominaDetail
��P d
(
��d e
newPayrollDet
��e r
)
��r s
.
��s t
Result
��t z
;
��z {
_logger
��( /
.
��/ 0
LogInformation
��0 >
(
��> ?
$"
��? A
$str
��A j
{
��j k
nominaexactusdet
��k {
.
��{ |
CONSECUTIVO��| �
}��� �
$str��� �
{��� � 
nominaexactuscab��� �
.��� �
NOMINA��� �
}��� �
$str��� �
{��� � 
nominaexactuscab��� �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �!
nTotalDetalleNomina
��( ;
--
��; =
;
��= >
_logger
��( /
.
��/ 0
LogInformation
��0 >
(
��> ?
$"
��? A
{
��A B!
nTotalDetalleNomina
��B U
}
��U V
$str
��V k
"
��k l
)
��l m
;
��m n
}
��$ %
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$"
��; =
$str
��= |
{
��| }
nominaexactuscab��} �
.��� �
NOMINA��� �
}��� �
$str��� �
{��� � 
nominaexactuscab��� �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �
_logger
��$ +
.
��+ ,
LogInformation
��, :
(
��: ;
$"
��; =
$str��= �
"��� �
)��� �
;��� �
}
��  !
else
��  $
{
��  !
_logger
��$ +
.
��+ ,
LogError
��, 4
(
��4 5
$"
��5 7
$str
��7 d
{
��d e
nominaexactuscab
��e u
.
��u v
NOMINA
��v |
}
��| }
$str
��} ~
{
��~  
nominaexactuscab��� �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �
}
��  !
}
�� 
else
��  
{
�� 
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$str
��7 |
)
��| }
;
��} ~
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 a
{
��a b
nominaexactuscab
��b r
.
��r s
NOMINA
��s y
}
��y z
$str
��z {
{
��{ |
nominaexactuscab��} �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 \
{
��\ ]$
currentNominaCabPortal
��] s
.
��s t

NominaCode
��t ~
}
��~ 
"�� �
)��� �
;��� �
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 ^
{
��^ _$
currentNominaCabPortal
��_ u
.
��u v
NominaNumber��v �
}��� �
"��� �
)��� �
;��� �
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 [
{
��[ \$
currentNominaCabPortal
��\ r
.
��r s
	IdCompany
��s |
}
��| }
"
��} ~
)
��~ 
;�� �
var
��  #!
detallenominaportal
��$ 7
=
��8 9"
salaryBandRepository
��: N
.
��N O"
GetSalaryPayrollDets
��O c
(
��c d$
currentNominaCabPortal
��d z
.
��z {

NominaCode��{ �
,��� �&
currentNominaCabPortal��� �
.��� �
NominaNumber��� �
,��� �&
currentNominaCabPortal��� �
.��� �
	IdCompany��� �
)��� �
.��� �
Result��� �
;��� �
filterNomina
��  ,
.
��, -

NominaCode
��- 7
=
��8 9$
currentNominaCabPortal
��: P
.
��P Q

NominaCode
��Q [
;
��[ \
filterNomina
��  ,
.
��, -
NominaNumber
��- 9
=
��: ;$
currentNominaCabPortal
��< R
.
��R S
NominaNumber
��S _
;
��_ `
var
��  #
nominalistexactus
��$ 5
=
��6 7%
exactusNominaRepository
��8 O
.
��O P
GetAll
��P V
(
��V W
filterNomina
��W c
)
��c d
.
��d e
Result
��e k
;
��k l
int
��  #
nRegistrosExactus
��$ 5
=
��6 7
nominalistexactus
��8 I
.
��I J
Count
��J O
(
��O P
)
��P Q
;
��Q R
int
��  #
nRegistrosPortal
��$ 4
=
��5 6!
detallenominaportal
��7 J
.
��J K
Count
��K P
(
��P Q
)
��Q R
;
��R S
int
��  #"
nRegistrosDiferentes
��$ 8
=
��9 :
nRegistrosExactus
��; L
-
��M N
nRegistrosPortal
��O _
;
��_ `
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 T
{
��T U
nRegistrosExactus
��V g
}
��g h
"
��h i
)
��i j
;
��j k
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 S
{
��S T
nRegistrosPortal
��U e
}
��e f
"
��f g
)
��g h
;
��h i
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 Q
{
��Q R
nRegistrosExactus
��T e
-
��f g
nRegistrosPortal
��h x
}
��x y
"
��y z
)
��z {
;
��{ |
foreach
��  '
(
��( )
var
��) ,
nominaexactusdet
��- =
in
��> @
nominalistexactus
��A R
)
��R S
{
��  !
var
��$ '
nominadetportal
��( 7
=
��8 9!
detallenominaportal
��: M
.
��M N
Where
��N S
(
��S T
i
��T U
=>
��V X
i
��Y Z
.
��Z [
Consecutive
��[ f
==
��g i
nominaexactusdet
��j z
.
��z {
CONSECUTIVO��{ �
)��� �
.��� �
FirstOrDefault��� �
(��� �
)��� �
;��� �
if
��$ &
(
��' (
nominadetportal
��( 7
==
��8 :
null
��; ?
)
��? @
{
��$ %
_logger
��( /
.
��/ 0
LogInformation
��0 >
(
��> ?
$"
��? A
$str
��A ^
{
��^ _
nominaexactusdet
��_ o
.
��o p
CONSECUTIVO
��p {
}
��| }
$str
��} ~
"
��~ 
)�� �
;��� �
SalaryPayrollDet
��( 8
newPayrollDet
��9 F
=
��G H
new
��I L
SalaryPayrollDet
��M ]
(
��] ^
)
��^ _
;
��_ `
newPayrollDet
��( 5
.
��5 6
	IdCompany
��6 ?
=
��@ A
comp
��B F
.
��F G
Id
��G I
;
��I J
newPayrollDet
��( 5
.
��5 6
Consecutive
��6 A
=
��B C
nominaexactusdet
��D T
.
��T U
CONSECUTIVO
��U `
;
��` a
newPayrollDet
��( 5
.
��5 6
CodEmployee
��6 A
=
��B C
nominaexactusdet
��D T
.
��T U
EMPLEADO
��U ]
;
��] ^
newPayrollDet
��( 5
.
��5 6
Concept
��6 =
=
��> ?
nominaexactusdet
��@ P
.
��P Q
CONCEPTO
��Q Y
;
��Y Z
newPayrollDet
��( 5
.
��5 6
Payroll
��6 =
=
��> ?
nominaexactusdet
��@ P
.
��P Q
NOMINA
��Q W
;
��W X
newPayrollDet
��( 5
.
��5 6
PayRollNumber
��6 C
=
��D E
nominaexactusdet
��F V
.
��V W
NUMERO_NOMINA
��W d
;
��d e
newPayrollDet
��( 5
.
��5 6

CostCenter
��6 @
=
��A B
nominaexactusdet
��C S
.
��S T
CENTRO_COSTO
��T `
;
��` a
newPayrollDet
��( 5
.
��5 6
Amount
��6 <
=
��= >
nominaexactusdet
��? O
.
��O P
MONTO
��P U
;
��U V
newPayrollDet
��( 5
.
��5 6
Total
��6 ;
=
��< =
nominaexactusdet
��> N
.
��N O
TOTAL
��O T
;
��T U
newPayrollDet
��( 5
.
��5 6
RegisterType
��6 B
=
��C D
nominaexactusdet
��E U
.
��U V
TIPO_REGISTRO
��V c
;
��c d
int
��( +
nresuldetail
��, 8
=
��9 :"
salaryBandRepository
��; O
.
��O P"
RegisterNominaDetail
��P d
(
��d e
newPayrollDet
��e r
)
��r s
.
��s t
Result
��t z
;
��z {
_logger
��( /
.
��/ 0
LogInformation
��0 >
(
��> ?
$"
��? A
$str
��A j
{
��j k
nominaexactusdet
��k {
.
��{ |
CONSECUTIVO��| �
}��� �
$str��� �
{��� � 
nominaexactuscab��� �
.��� �
NOMINA��� �
}��� �
$str��� �
{��� � 
nominaexactuscab��� �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �"
nRegistrosDiferentes
��( <
--
��< >
;
��> ?
_logger
��( /
.
��/ 0
LogInformation
��0 >
(
��> ?
$"
��? A
{
��A B"
nRegistrosDiferentes
��B V
}
��V W
$str
��W l
"
��l m
)
��m n
;
��n o
}
��$ %
}
��  !
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 x
{
��x y
nominaexactuscab��y �
.��� �
NOMINA��� �
}��� �
$str��� �
{��� � 
nominaexactuscab��� �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �
}
�� 
_logger
�� #
.
��# $
LogInformation
��$ 2
(
��2 3
$"
��3 5
$str
��5 V
{
��V W
nominaexactuscab
��W g
.
��g h
NOMINA
��h n
}
��n o
$str
��o p
{
��p q
nominaexactuscab��r �
.��� �
NUMERO_NOMINA��� �
}��� �
"��� �
)��� �
;��� �
}
�� 
_logger
�� 
.
��  
LogInformation
��  .
(
��. /
$"
��/ 1
$str
��1 S
{
��S T
comp
��T X
.
��X Y
Schema
��Y _
}
��_ `
"
��` a
)
��a b
;
��b c
}
�� 
catch
�� 
(
�� 
	Exception
�� $
ex
��% '
)
��' (
{
�� 
_logger
�� 
.
��  
LogError
��  (
(
��( )
$str
��) S
+
��T U
ex
��V X
.
��X Y
Message
��Y `
)
��` a
;
��a b
_logger
�� 
.
��  
LogError
��  (
(
��( )
$str
��) S
+
��T U
ex
��V X
.
��X Y

StackTrace
��Y c
)
��c d
;
��d e
}
�� 
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� 
ImportLiquidacion
�� %
(
��% &
)
��& '
{
�� 	
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$"
��# %
$str
��% A
"
��A B
)
��B C
;
��C D
var
�� 
CompaniesList
�� 
=
�� 
empresaRepository
��  1
.
��1 2
GetAll
��2 8
(
��8 9
)
��9 :
.
��: ;
Result
��; A
;
��A B
foreach
�� 
(
�� 
var
�� 
comp
�� 
in
��  
CompaniesList
��! .
)
��. /
{
�� 
if
�� 
(
�� 
!
�� 
string
�� 
.
�� 
IsNullOrEmpty
�� )
(
��) *
comp
��* .
.
��. /
Schema
��/ 5
)
��5 6
)
��6 7
{
�� 
_logger
�� 
.
�� 
LogInformation
�� *
(
��* +
$"
��+ -
$str
��- E
{
��E F
comp
��F J
.
��J K
Schema
��K Q
}
��Q R
"
��R S
)
��S T
;
��T U
var
�� %
liquidacionesCabExactus
�� /
=
��0 1(
exactusNominaCabRepository
��2 L
.
��L M
GetLiquidacionCab
��M ^
(
��^ _
comp
��_ c
.
��c d
Schema
��d j
)
��j k
.
��k l
Result
��l r
;
��r s
var
��  
liquidacionesCabGH
�� *
=
��+ ,"
salaryBandRepository
��- A
.
��A B#
GetLiquidacionCabList
��B W
(
��W X
comp
��X \
.
��\ ]
Id
��] _
)
��_ `
.
��` a
Result
��a g
;
��g h
int
�� %
nRegistrosCabPendientes
�� /
=
��0 1%
liquidacionesCabExactus
��2 I
.
��I J
Count
��J O
(
��O P
)
��P Q
-
��R S 
liquidacionesCabGH
��T f
.
��f g
Count
��g l
(
��l m
)
��m n
;
��n o
_logger
�� 
.
�� 
LogInformation
�� +
(
��+ ,
$"
��, .
$str
��. =
{
��= >%
nRegistrosCabPendientes
��> U
}
��U V
$str
��V d
"
��d e
)
��e f
;
��f g
foreach
�� 
(
�� 
var
��  
item
��! %
in
��& (%
liquidacionesCabExactus
��) @
)
��@ A
{
�� 
var
�� 
existCab
�� $
=
��% & 
liquidacionesCabGH
��' 9
.
��9 :
Where
��: ?
(
��? @
i
��@ A
=>
��B D
i
��E F
.
��F G
nliquidation
��G S
==
��T V
item
��W [
.
��[ \
LIQUIDACION
��\ g
)
��g h
.
��h i
FirstOrDefault
��i w
(
��w x
)
��x y
;
��y z
if
�� 
(
�� 
existCab
�� $
==
��% '
null
��( ,
)
��, -
{
�� 
LiquidacionCabDto
�� -
dtocab
��. 4
=
��5 6
new
��7 :
LiquidacionCabDto
��; L
(
��L M
)
��M N
;
��N O
dtocab
�� "
.
��" #

nidcompany
��# -
=
��. /
comp
��0 4
.
��4 5
Id
��5 7
;
��7 8
dtocab
�� "
.
��" #
nliquidation
��# /
=
��0 1
item
��2 6
.
��6 7
LIQUIDACION
��7 B
;
��B C
dtocab
�� "
.
��" #
scodemployee
��# /
=
��0 1
item
��2 6
.
��6 7
EMPLEADO
��7 ?
;
��? @
dtocab
�� "
.
��" #
	scurrency
��# ,
=
��- .
item
��/ 3
.
��3 4
MONEDA
��4 :
;
��: ;
dtocab
�� "
.
��" #
sstateliquidation
��# 4
=
��5 6
item
��7 ;
.
��; <
ESTADO_LIQUIDAC
��< K
;
��K L
dtocab
�� "
.
��" #
ddate_in
��# +
=
��, -
item
��. 2
.
��2 3
FECHA_INGRESO
��3 @
;
��@ A
dtocab
�� "
.
��" #
	ddate_out
��# ,
=
��- .
item
��/ 3
.
��3 4
FECHA_SALIDA
��4 @
;
��@ A
dtocab
�� "
.
��" #
sclose_contracts
��# 3
=
��4 5
item
��6 :
.
��: ;
CERRAR_CONTRATOS
��; K
;
��K L
dtocab
�� "
.
��" #
nnumberaction
��# 0
=
��1 2
item
��3 7
.
��7 8
NUMERO_ACCION
��8 E
;
��E F
dtocab
�� "
.
��" #
spayway
��# *
=
��+ ,
item
��- 1
.
��1 2

FORMA_PAGO
��2 <
;
��< =
dtocab
�� "
.
��" #
saccountbank
��# /
=
��0 1
item
��2 6
.
��6 7
CUENTA_BANCO
��7 C
;
��C D
dtocab
�� "
.
��" #"
snumber_document_pay
��# 7
=
��8 9
item
��: >
.
��> ?
NUMERO_DOC_PAGO
��? N
;
��N O
dtocab
�� "
.
��" #
saccountseat
��# /
=
��0 1
item
��2 6
.
��6 7
ASIENTO_CONTABLE
��7 G
;
��G H
dtocab
�� "
.
��" #
ddate_out_pay
��# 0
=
��1 2
item
��3 7
.
��7 8
FECHA_RETIRO_PAGO
��8 I
;
��I J
dtocab
�� "
.
��" #
suser_liquidation
��# 4
=
��5 6
item
��7 ;
.
��; <
USUARIO_LIQUIDAC
��< L
;
��L M
dtocab
�� "
.
��" #
ddate_liquidation
��# 4
=
��5 6
item
��7 ;
.
��; <
FECHA_LIQUIDACION
��< M
;
��M N
dtocab
�� "
.
��" #
nsubtypedoc_pay
��# 2
=
��3 4
item
��5 9
.
��9 :
SUBTIPODOC_PAGO
��: I
;
��I J
dtocab
�� "
.
��" #
sbudget
��# *
=
��+ ,
item
��- 1
.
��1 2
PRESUPUESTO
��2 =
;
��= >
dtocab
�� "
.
��" #
sunit_operative
��# 2
=
��3 4
item
��5 9
.
��9 :
UNIDAD_OPERATIVA
��: J
;
��J K
dtocab
�� "
.
��" #
nnumber_apart
��# 0
=
��1 2
item
��3 7
.
��7 8
NUMERO_APARTADO
��8 G
;
��G H
dtocab
�� "
.
��" #
nnumber_exercised
��# 4
=
��5 6
item
��7 ;
.
��; <
NUMERO_EJERCIDO
��< K
;
��K L
dtocab
�� "
.
��" #
scalc_pay_nomina
��# 3
=
��4 5
item
��6 :
.
��: ;!
CALCULA_PAGO_NOMINA
��; N
;
��N O
dtocab
�� "
.
��" #
snomina_calc
��# /
=
��0 1
item
��2 6
.
��6 7
NOMINA_CALCULO
��7 E
;
��E F
dtocab
�� "
.
��" #!
nnumber_nomina_calc
��# 6
=
��7 8
item
��9 =
.
��= >#
NUMERO_NOMINA_CALCULO
��> S
;
��S T
dtocab
�� "
.
��" #!
scontract_term_type
��# 6
=
��7 8
item
��9 =
.
��= >%
TIPO_EXTINCION_CONTRATO
��> U
;
��U V
dtocab
�� "
.
��" #
ssituation_unac
��# 2
=
��3 4
item
��5 9
.
��9 :
SITUACION_INAC
��: H
;
��H I
int
�� 

nResultCab
��  *
=
��+ ,"
salaryBandRepository
��- A
.
��A B$
RegisterLiquidacionCab
��B X
(
��X Y
dtocab
��Y _
)
��_ `
.
��` a
Result
��a g
;
��g h
if
�� 
(
��  

nResultCab
��  *
>
��+ ,
$num
��- .
)
��. /
{
�� 
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 b
{
��b c
dtocab
��c i
.
��i j
nliquidation
��j v
}
��v w
"
��w x
)
��x y
;
��y z
var
��  #%
liquidacionesDetExactus
��$ ;
=
��< =(
exactusNominaCabRepository
��> X
.
��X Y
GetLiquidacionDet
��Y j
(
��j k
comp
��k o
.
��o p
Schema
��p v
,
��v w
dtocab
��x ~
.
��~ 
nliquidation�� �
)��� �
.��� �
Result��� �
;��� �
foreach
��  '
(
��( )
var
��) ,
det
��- 0
in
��1 3%
liquidacionesDetExactus
��4 K
)
��K L
{
��  !
LiquidacionDetDto
��$ 5
	dtoinsDet
��6 ?
=
��@ A
new
��B E
LiquidacionDetDto
��F W
(
��W X
)
��X Y
;
��Y Z
	dtoinsDet
��$ -
.
��- .

nidcompany
��. 8
=
��9 :
comp
��; ?
.
��? @
Id
��@ B
;
��B C
	dtoinsDet
��$ -
.
��- .
nliquidation
��. :
=
��; <
det
��= @
.
��@ A
LIQUIDACION
��A L
;
��L M
	dtoinsDet
��$ -
.
��- .
nline
��. 3
=
��4 5
det
��6 9
.
��9 :
LINEA
��: ?
;
��? @
	dtoinsDet
��$ -
.
��- .
sconcept
��. 6
=
��7 8
det
��9 <
.
��< =
CONCEPTO
��= E
;
��E F
	dtoinsDet
��$ -
.
��- .
sdescription
��. :
=
��; <
det
��= @
.
��@ A
DESCRIPCION
��A L
;
��L M
	dtoinsDet
��$ -
.
��- .
stypeconcept
��. :
=
��; <
det
��= @
.
��@ A
TIPO_CONCEPTO
��A N
;
��N O
	dtoinsDet
��$ -
.
��- .
	nsequence
��. 7
=
��8 9
det
��: =
.
��= >
	SECUENCIA
��> G
;
��G H
	dtoinsDet
��$ -
.
��- .
	nquantity
��. 7
=
��8 9
det
��: =
.
��= >
CANTIDAD
��> F
;
��F G
	dtoinsDet
��$ -
.
��- .
namount
��. 5
=
��6 7
det
��8 ;
.
��; <
MONTO
��< A
;
��A B
	dtoinsDet
��$ -
.
��- .
ntotal_calc
��. 9
=
��: ;
det
��< ?
.
��? @
TOTAL_CALCULADO
��@ O
;
��O P
	dtoinsDet
��$ -
.
��- .
scentercost
��. 9
=
��: ;
det
��< ?
.
��? @
CENTRO_COSTO
��@ L
;
��L M
	dtoinsDet
��$ -
.
��- .
sledgeraccount
��. <
=
��= >
det
��? B
.
��B C
CUENTA_CONTABLE
��C R
;
��R S
int
��$ '

nResultDet
��( 2
=
��3 4"
salaryBandRepository
��5 I
.
��I J$
RegisterLiquidacionDet
��J `
(
��` a
	dtoinsDet
��a j
)
��j k
.
��k l
Result
��l r
;
��r s
if
��$ &
(
��' (

nResultDet
��( 2
>
��3 4
$num
��5 6
)
��6 7
{
��$ %
_logger
��( /
.
��/ 0
LogInformation
��0 >
(
��> ?
$"
��? A
$str
��A g
{
��g h
	dtoinsDet
��h q
.
��q r
sconcept
��r z
}
��z {
"
��{ |
)
��| }
;
��} ~
}
��$ %
else
��$ (
{
��$ %
_logger
��( /
.
��/ 0
LogInformation
��0 >
(
��> ?
$"
��? A
$str
��A j
{
��j k
	dtoinsDet
��k t
.
��t u
sconcept
��u }
}
��} ~
"
��~ 
)�� �
;��� �
}
��$ %
}
��  !
}
�� 
else
��  
{
�� 
_logger
��  '
.
��' (
LogInformation
��( 6
(
��6 7
$"
��7 9
$str
��9 e
{
��e f
dtocab
��f l
.
��l m
ddate_liquidation
��m ~
}
��~ 
"�� �
)��� �
;��� �
}
�� 
}
�� %
nRegistrosCabPendientes
�� /
--
��/ 1
;
��1 2
_logger
�� 
.
��  
LogInformation
��  .
(
��. /
$"
��/ 1
{
��1 2%
nRegistrosCabPendientes
��2 I
}
��I J
$str
��J T
"
��T U
)
��U V
;
��V W
_logger
�� 
.
��  
LogInformation
��  .
(
��. /
$"
��/ 1
$str
��1 f
"
��f g
)
��g h
;
��h i
}
�� 
}
�� 
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$"
��' )
$str
��) m
"
��m n
)
��n o
;
��o p
}
�� 
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$"
��# %
$str
��% a
"
��a b
)
��b c
;
��c d
}
�� 	
}
�� 
}�� �
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
} �
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\Exactus\Puesto\IServices\IExactusPuestoService.cs
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
} �S
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

puestoList	KKy �
.
KK� �
Count
KK� �
(
KK� �
)
KK� �
,
KK� �
comp
KK� �
.
KK� �
Descripcion
KK� �
)
KK� �
)
KK� �
;
KK� �
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
.	MM �
Id
MM� �
)
MM� �
.
MM� �
FirstOrDefault
MM� �
(
MM� �
)
MM� �
;
MM� �
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
FirstOrDefault	RR| �
(
RR� �
)
RR� �
;
RR� �
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
Cargo	VV �
(
VV� �
)
VV� �
;
VV� �

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
DESCRIPCION	dd �
,
dd� �
comp
dd� �
.
dd� �
Descripcion
dd� �
)
dd� �
)
dd� �
;
dd� �
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
}{{ �
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
}"" �F
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
}ww �
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
} �
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\ServerUs\Asistencia\IServices\IServerUsAsistenciaService.cs
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
} �<
�D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\WSHumanManagement.Application\ServerUs\Asistencia\Services\ServerUsAsistenciaService.cs
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
FirstOrDefault	""z �
(
""� �
)
""� �
;
""� �
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