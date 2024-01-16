�!
vD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlServerUs\Connections\ServerUsReadDbConnection.cs
	namespace 	
HumanManagement
 
. 
MsSqlServerUs '
.' (
Connections( 3
{ 
public 

class $
ServerUsReadDbConnection )
:* +%
IServerUsReadDbConnection, E
,E F
IDisposableG R
{ 
private 
readonly 
IDbConnection &

connection' 1
;1 2
public $
ServerUsReadDbConnection '
(' (
IConfiguration( 6
configuration7 D
)D E
{ 	

connection 
= 
new 
SqlConnection *
(* +
configuration+ 8
.8 9
GetConnectionString9 L
(L M
$strM i
)i j
)j k
;k l
} 	
public 
async 
Task 
< 
IReadOnlyList '
<' (
T( )
>) *
>* +

QueryAsync, 6
<6 7
T7 8
>8 9
(9 :
string: @
sqlA D
,D E
objectF L
paramM R
=S T
nullU Y
,Y Z
CommandType[ f
CommandTypeg r
=s t
CommandType	u �
.
� �
Text
� �
,
� �
IDbTransaction
� �
transaction
� �
=
� �
null
� �
,
� �
CancellationToken
� �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return 
( 
await 

connection $
.$ %

QueryAsync% /
</ 0
T0 1
>1 2
(2 3
sql3 6
,6 7
param8 =
,= >
transaction? J
,J K
nullL P
,P Q
CommandTypeR ]
)] ^
)^ _
._ `
AsList` f
(f g
)g h
;h i
} 	
public 
async 
Task 
< 
T 
> $
QueryFirstOrDefaultAsync 5
<5 6
T6 7
>7 8
(8 9
string9 ?
sql@ C
,C D
objectE K
paramL Q
=R S
nullT X
,X Y
IDbTransactionZ h
transactioni t
=u v
nullw {
,{ |
CancellationToken	} �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return 
await 

connection #
.# $$
QueryFirstOrDefaultAsync$ <
<< =
T= >
>> ?
(? @
sql@ C
,C D
paramE J
,J K
transactionL W
)W X
;X Y
} 	
public   
async   
Task   
<   
T   
>   
QuerySingleAsync   -
<  - .
T  . /
>  / 0
(  0 1
string  1 7
sql  8 ;
,  ; <
object  = C
param  D I
=  J K
null  L P
,  P Q
IDbTransaction  R `
transaction  a l
=  m n
null  o s
,  s t
CancellationToken	  u �
cancellationToken
  � �
=
  � �
default
  � �
)
  � �
{!! 	
return"" 
await"" 

connection"" #
.""# $
QuerySingleAsync""$ 4
<""4 5
T""5 6
>""6 7
(""7 8
sql""8 ;
,""; <
param""= B
,""B C
transaction""D O
)""O P
;""P Q
}## 	
public$$ 
void$$ 
Dispose$$ 
($$ 
)$$ 
{%% 	

connection&& 
.&& 
Dispose&& 
(&& 
)&&  
;&&  !
}'' 	
}(( 
})) �#
wD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlServerUs\Connections\ServerUsWriteDbConnection.cs
	namespace 	
HumanManagement
 
. 
MsSqlServerUs '
.' (
Connections( 3
{ 
public 

class %
ServerUsWriteDbConnection *
:+ ,&
IServerUsWriteDbConnection- G
{ 
private 
readonly 
IExactusDbContext *
context+ 2
;2 3
public %
ServerUsWriteDbConnection (
(( )
IExactusDbContext) :
context; B
)B C
{ 	
this 
. 
context 
= 
context "
;" #
} 	
public 
async 
Task 
< 
int 
> 
ExecuteAsync +
(+ ,
string, 2
sql3 6
,6 7
object8 >
param? D
=E F
nullG K
,K L
IDbTransactionM [
transaction\ g
=h i
nullj n
,n o
CancellationToken	p �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return 
await 
context  
.  !

Connection! +
.+ ,
ExecuteAsync, 8
(8 9
sql9 <
,< =
param> C
,C D
transactionE P
)P Q
;Q R
} 	
public 
async 
Task 
< 
IReadOnlyList '
<' (
T( )
>) *
>* +

QueryAsync, 6
<6 7
T7 8
>8 9
(9 :
string: @
sqlA D
,D E
objectF L
paramM R
=S T
nullU Y
,Y Z
IDbTransaction[ i
transactionj u
=v w
nullx |
,| }
CancellationToken	~ �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return 
( 
await 
context !
.! "

Connection" ,
., -

QueryAsync- 7
<7 8
T8 9
>9 :
(: ;
sql; >
,> ?
param@ E
,E F
transactionG R
)R S
)S T
.T U
AsListU [
([ \
)\ ]
;] ^
} 	
public 
async 
Task 
< 
T 
> $
QueryFirstOrDefaultAsync 5
<5 6
T6 7
>7 8
(8 9
string9 ?
sql@ C
,C D
objectE K
paramL Q
=R S
nullT X
,X Y
IDbTransactionZ h
transactioni t
=u v
nullw {
,{ |
CancellationToken	} �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return 
await 
context  
.  !

Connection! +
.+ ,$
QueryFirstOrDefaultAsync, D
<D E
TE F
>F G
(G H
sqlH K
,K L
paramM R
,R S
transactionT _
)_ `
;` a
}   	
public!! 
async!! 
Task!! 
<!! 
T!! 
>!! 
QuerySingleAsync!! -
<!!- .
T!!. /
>!!/ 0
(!!0 1
string!!1 7
sql!!8 ;
,!!; <
object!!= C
param!!D I
=!!J K
null!!L P
,!!P Q
IDbTransaction!!R `
transaction!!a l
=!!m n
null!!o s
,!!s t
CancellationToken	!!u �
cancellationToken
!!� �
=
!!� �
default
!!� �
)
!!� �
{"" 	
return## 
await## 
context##  
.##  !

Connection##! +
.##+ ,
QuerySingleAsync##, <
<##< =
T##= >
>##> ?
(##? @
sql##@ C
,##C D
param##E J
,##J K
transaction##L W
)##W X
;##X Y
}$$ 	
}%% 
}&& �
kD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlServerUs\Context\ServerUsDbContext.cs
	namespace

 	
HumanManagement


 
.

 
MsSqlServerUs

 '
.

' (
Context

( /
{ 
public 

class 
ServerUsDbContext "
:# $
	DbContext% .
,. /
IServerUsDbContext0 B
{ 
public 
ServerUsDbContext  
(  !
DbContextOptions! 1
<1 2
ServerUsDbContext2 C
>C D
optionsE L
)L M
: 
base 
( 
options 
) 
{ 	
} 	
public 
IDbConnection 

Connection '
=>( *
Database+ 3
.3 4
GetDbConnection4 C
(C D
)D E
;E F
} 
} �
pD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlServerUs\Context\ServerUsDbContextMsSql.cs
	namespace		 	
HumanManagement		
 
.		 
MsSqlServerUs		 '
.		' (
Context		( /
{

 
public 

class "
ServerUsDbContextMsSql '
:( )
	DbContext* 3
{ 
public "
ServerUsDbContextMsSql %
(% &
DbContextOptions& 6
<6 7"
ServerUsDbContextMsSql7 M
>M N
optionO U
)U V
: 
base 
( 
option 
) 
{ 	
} 	
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
ParameterConfig 
( 
modelBuilder (
)( )
;) *
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
} 	
private 
void 
ParameterConfig $
($ %
ModelBuilder% 1
modelBuilder2 >
)> ?
{ 	
} 	
public 
override 
async 
Task "
<" #
int# &
>& '
SaveChangesAsync( 8
(8 9
CancellationToken9 J
cancellationTokenK \
=] ^
default_ f
(f g
CancellationTokeng x
)x y
)y z
{ 	
return 
await 
base 
. 
SaveChangesAsync .
(. /
cancellationToken/ @
)@ A
;A B
} 	
} 
} �f
yD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlServerUs\Repository\SUMovAsistenciaCabRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlServerUs '
.' (

Repository( 2
{ 
public 

class (
SUMovAsistenciaCabRepository -
:. /)
ISUMovAsistenciaCabRepository0 M
{ 
private 
readonly %
IServerUsReadDbConnection 2$
ServerUsReadDbConnection3 K
;K L
private 
readonly 
ILogger  
<  !(
SUMovAsistenciaCabRepository! =
>= >
_logger? F
;F G
public (
SUMovAsistenciaCabRepository +
(+ ,%
IServerUsReadDbConnection, E$
ServerUsReadDbConnectionF ^
,^ _
ILogger` g
<g h)
SUMovAsistenciaCabRepository	h �
>
� �
_logger
� �
)
� �
{ 	
this 
. $
ServerUsReadDbConnection )
=* +$
ServerUsReadDbConnection, D
;D E
this 
. 
_logger 
= 
_logger "
;" #
} 	
public 
async 
Task 
< 
int 
> 
GetNewId '
(' (
SUGetNewIdFilterDto( ;
	filterDto< E
)E F
{ 	
string 
query 
= 
$str  !
;  ! "
query"" 
="" 
query"" 
."" 
Replace"" !
(""! "
$str""" /
,""/ 0
	filterDto""1 :
."": ;
	identidad""; D
.""D E
ToString""E M
(""M N
)""N O
)""O P
;""P Q
query## 
=## 
query## 
.## 
Replace## !
(##! "
$str##" 6
,##6 7
	filterDto##8 A
.##A B
cod_tipo_solicitud##B T
)##T U
;##U V
_logger%% 
.%% 
LogInformation%% "
(%%" #
$str%%# .
+%%/ 0
query%%1 6
)%%6 7
;%%7 8
var'' 
result'' 
='' 
await'' $
ServerUsReadDbConnection'' 7
.''7 8

QueryAsync''8 B
<''B C
int''C F
>''F G
(''G H
query''H M
,''M N
new((, /
{)), -
},,, -
),,- .
;,,. /
return.. 
result.. 
[.. 
$num.. 
].. 
;.. 
}// 	
public11 
async11 
Task11 
<11 
int11 
>11 
GetIdEmployee11 ,
(11, -
int11- 0
	identidad111 :
,11; <
string11= C
codemployee11D O
)11O P
{22 	
string33 
query33 
=33 
$str35 L
;55L M
query77 
=77 
query77 
.77 
Replace77 !
(77! "
$str77" /
,77/ 0
	identidad771 :
.77: ;
ToString77; C
(77C D
)77D E
)77E F
;77F G
query88 
=88 
query88 
.88 
Replace88 !
(88! "
$str88" 1
,881 2
codemployee883 >
)88> ?
;88? @
_logger99 
.99 
LogInformation99 "
(99" #
$str99# .
+99/ 0
query991 6
)996 7
;997 8
var;; 
result;; 
=;; 
await;; $
ServerUsReadDbConnection;; 7
.;;7 8

QueryAsync;;8 B
<;;B C
int;;C F
>;;F G
(;;G H
query;;H M
,;;M N
new<<, /
{==, -
}@@, -
)@@- .
;@@. /
returnBB 
resultBB 
.BB 
CountBB 
>BB  !
$numBB" #
?BB$ %
resultBB& ,
[BB, -
$numBB- .
]BB. /
:BB0 1
$numBB1 2
;BB3 4
}CC 	
publicEE 
asyncEE 
TaskEE 
<EE 
intEE 
>EE 
InsertEE %
(EE% &
SUInsertMovCabDtoEE& 7
	insertDtoEE8 A
)EEA B
{FF 	
stringHH 
queryHH 
=HH 
$strHi 
;ii 
_loggerkk 
.kk 
LogInformationkk "
(kk" #
$strkk# .
+kk/ 0
querykk1 6
)kk6 7
;kk7 8
varmm 
resultmm 
=mm 
awaitmm $
ServerUsReadDbConnectionmm 7
.mm7 8

QueryAsyncmm8 B
<mmB C
intmmC F
>mmF G
(mmG H
querymmH M
,mmM N
newnn, /
{oo, -
	identidadqq0 9
=qq: ;
	insertDtoqq< E
.qqE F
	identidadqqF O
,qqO P
codtiposolicitudrr0 @
=rrA B
	insertDtorrC L
.rrL M
codtiposolicitudrrM ]
,rr] ^
nrosolicitudss0 <
=ss= >
	insertDtoss? H
.ssH I
nrosolicitudssI U
,ssU V

centroresptt0 :
=tt; <
	insertDtott= F
.ttF G

centrorespttG Q
,ttQ R
idtrabajadoruu0 <
=uu= >
	insertDtouu? H
.uuH I
idtrabajadoruuI U
,uuU V

codsubtipovv0 :
=vv; <
	insertDtovv= F
.vvF G

codsubtipovvG Q
,vvQ R
fecha_mov_solicitudww0 C
=wwD E
	insertDtowwF O
.wwO P
fecha_mov_solicitudwwP c
,wwc d!
descripcion_solicitudxx0 E
=xxF G
	insertDtoxxH Q
.xxQ R!
descripcion_solicitudxxR g
,xxg h
codempleadoyy0 ;
=yy< =
	insertDtoyy> G
.yyG H
idtrabajadoryyH T
.yyT U
ToStringyyU ]
(yy] ^
$stryy^ b
)yyb c
}zz, -
)zz- .
;zz. /
return|| 
result|| 
.|| 
Count|| 
;||  
}}} 	
public
�� 
async
�� 
Task
�� 
<
�� 
bool
�� 
>
�� 
InsertPermSP
��  ,
(
��, -"
ServerUsInsPermSPDto
��- A
dto
��B E
)
��E F
{
�� 	
try
�� 
{
�� 
string
�� 
sqlstore
�� 
=
��  !
string
��" (
.
��( )
Format
��) /
(
��/ 0
$str
��0 G
)
��G H
;
��H I
var
�� 
queryParameters
�� #
=
��$ %
new
��& )
DynamicParameters
��* ;
(
��; <
)
��< =
;
��= >
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ 3
,
��@ A
dto
��B E
.
��E F
ai_identidad
��F R
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ <
,
��@ A
dto
��B E
.
��E F#
as_cod_tipo_solicitud
��F [
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ 8
,
��@ A
dto
��B E
.
��E F
as_cod_centroresp
��F W
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ :
,
��@ A
dto
��B E
.
��E F!
as_numero_documento
��F Y
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ ?
,
��@ A
dto
��B E
.
��E F&
as_cod_subtipo_solicitud
��F ^
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ 9
,
��@ A
dto
��B E
.
��E F 
adt_fch_movimiento
��F X
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ ;
,
��@ A
dto
��B E
.
��E F"
adt_fch_horas_inicio
��F Z
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ :
,
��@ A
dto
��B E
.
��E F!
adt_fch_horas_final
��F Y
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ <
,
��@ A
dto
��B E
.
��E F#
adt_fch_hora_ini_real
��F [
)
��` a
;
��a b
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ <
,
��@ A
dto
��B E
.
��E F#
adt_fch_hora_fin_real
��F [
)
��[ \
;
��\ ]
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q
ai_identidad
��Q ]
)
��] ^
;
��^ _
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q#
as_cod_tipo_solicitud
��Q f
)
��f g
;
��g h
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q
as_cod_centroresp
��Q b
)
��b c
;
��c d
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q!
as_numero_documento
��Q d
)
��d e
;
��e f
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q&
as_cod_subtipo_solicitud
��Q i
)
��i j
;
��j k
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q 
adt_fch_movimiento
��Q c
)
��c d
;
��d e
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q"
adt_fch_horas_inicio
��Q e
)
��e f
;
��f g
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q!
adt_fch_horas_final
��Q d
)
��d e
;
��e f
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q#
adt_fch_hora_ini_real
��Q f
)
��f g
;
��g h
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' K
+
��K L
dto
��M P
.
��P Q#
adt_fch_hora_fin_real
��Q f
)
��f g
;
��g h
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' N
+
��O P
sqlstore
��Q Y
)
��Y Z
;
��Z [
var
�� 
listUSer
�� 
=
�� 
await
�� $&
ServerUsReadDbConnection
��% =
.
��= >

QueryAsync
��> H
<
��H I
object
��I O
>
��O P
(
��P Q
sqlstore
�� 
,
�� 
queryParameters
�� $
,
��$ %
commandType
��& 1
:
��1 2
CommandType
��3 >
.
��> ?
StoredProcedure
��? N
)
��N O
;
��O P
_logger
�� 
.
�� 
LogInformation
�� &
(
��& '
$str
��' R
)
��R S
;
��S T
return
�� 
true
�� 
;
�� 
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
��\ ]
return
�� 
false
�� 
;
�� 
}
�� 
}
�� 	
}
�� 
}�� �
yD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlServerUs\Repository\SUMovAsistenciaDetRepository.cs
	namespace

 	
HumanManagement


 
.

 
MsSqlServerUs

 '
.

' (

Repository

( 2
{ 
public 

class (
SUMovAsistenciaDetRepository -
:. /)
ISUMovAsistenciaDetRepository0 M
{ 
private 
readonly %
IServerUsReadDbConnection 2$
ServerUsReadDbConnection3 K
;K L
public (
SUMovAsistenciaDetRepository +
(+ ,%
IServerUsReadDbConnection, E$
ServerUsReadDbConnectionF ^
)^ _
{ 	
this 
. $
ServerUsReadDbConnection )
=* +$
ServerUsReadDbConnection, D
;D E
} 	
public 
async 
Task 
< 
int 
> 
Insert %
(% &
SUInsertMovDetDto& 7
	insertDto8 A
)A B
{ 	
string 
query 
= 
$str/ 
;// 
var55 
result55 
=55 
await55 $
ServerUsReadDbConnection55 7
.557 8

QueryAsync558 B
<55B C
int55C F
>55F G
(55G H
query55H M
,55M N
new66, /
{77, -
	identidad990 9
=99: ;
	insertDto99< E
.99E F
	identidad99F O
,99O P
num_solicitud::0 =
=::> ?
	insertDto::@ I
.::I J
num_solicitud::J W
,::W X
cod_tipo_solicitud;;0 B
=;;C D
	insertDto;;E N
.;;N O
cod_tipo_solicitud;;O a
,;;a b!
cod_subtipo_solicitud<<0 E
=<<F G
	insertDto<<H Q
.<<Q R!
cod_subtipo_solicitud<<R g
,<<g h
fecha_movimiento==0 @
===A B
	insertDto==C L
.==L M
fecha_movimiento==M ]
,==] ^
idtrabajador>>0 <
=>>= >
	insertDto>>? H
.>>H I
idtrabajador>>I U
,>>U V
fecha_hora_inicio??0 A
=??B C
	insertDto??D M
.??M N
fecha_hora_inicio??N _
,??_ `
fecha_hora_final@@0 @
=@@A B
	insertDto@@C L
.@@L M
fecha_hora_final@@M ]
,@@] ^"
fecha_hora_inicio_realAA0 F
=AAG H
	insertDtoAAI R
.AAR S"
fecha_hora_inicio_realAAS i
,AAi j!
fecha_hora_final_realBB0 E
=BBF G
	insertDtoBBH Q
.BBQ R!
fecha_hora_final_realBBR g
,BBg h
}DD, -
)DD- .
;DD. /
returnFF 
resultFF 
.FF 
CountFF 
;FF  
}GG 	
}HH 
}II 