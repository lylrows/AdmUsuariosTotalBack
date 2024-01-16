�/
tD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Connections\ExactusReadDbConnection.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '
Connections' 2
{ 
public 

class #
ExactusReadDbConnection (
:) *$
IExactusReadDbConnection+ C
,C D
IDisposableE P
{ 
private 
readonly 
IDbConnection &

connection' 1
;1 2
public #
ExactusReadDbConnection &
(& '
IConfiguration' 5
configuration6 C
)C D
{ 	

connection 
= 
new 
SqlConnection *
(* +
configuration+ 8
.8 9
GetConnectionString9 L
(L M
$strM h
)h i
)i j
;j k
} 	
public 
async 
Task 
< 
IReadOnlyList '
<' (
T( )
>) *
>* +

QueryAsync, 6
<6 7
T7 8
>8 9
(9 :
string: @
sqlA D
,D E
objectF L
paramM R
=S T
nullU Y
,Y Z
CommandType[ f
CommandTypeg r
=s t
CommandType	u �
.
� �
Text
� �
,
� �
IDbTransaction
� �
transaction
� �
=
� �
null
� �
,
� �
CancellationToken
� �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return 
( 
await 

connection $
.$ %

QueryAsync% /
</ 0
T0 1
>1 2
(2 3
sql3 6
,6 7
param8 =
,= >
transaction? J
,J K
nullL P
,P Q
CommandTypeR ]
)] ^
)^ _
._ `
AsList` f
(f g
)g h
;h i
} 	
public 
async 
Task 
< 
T 
> $
QueryFirstOrDefaultAsync 5
<5 6
T6 7
>7 8
(8 9
string9 ?
sql@ C
,C D
objectE K
paramL Q
=R S
nullT X
,X Y
IDbTransactionZ h
transactioni t
=u v
nullw {
,{ |
CancellationToken	} �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return   
await   

connection   #
.  # $$
QueryFirstOrDefaultAsync  $ <
<  < =
T  = >
>  > ?
(  ? @
sql  @ C
,  C D
param  E J
,  J K
transaction  L W
)  W X
;  X Y
}!! 	
public"" 
async"" 
Task"" 
<"" 
T"" 
>"" 
QuerySingleAsync"" -
<""- .
T"". /
>""/ 0
(""0 1
string""1 7
sql""8 ;
,""; <
object""= C
param""D I
=""J K
null""L P
,""P Q
IDbTransaction""R `
transaction""a l
=""m n
null""o s
,""s t
CancellationToken	""u �
cancellationToken
""� �
=
""� �
default
""� �
)
""� �
{## 	
return$$ 
await$$ 

connection$$ #
.$$# $
QuerySingleAsync$$$ 4
<$$4 5
T$$5 6
>$$6 7
($$7 8
sql$$8 ;
,$$; <
param$$= B
,$$B C
transaction$$D O
)$$O P
;$$P Q
}%% 	
public'' 
IDataReader'' 
ExecuteReader'' (
(''( )
string'') /
sql''0 3
,''3 4
object''5 ;
param''< A
=''B C
null''D H
,''H I
CommandType''J U
commandType''V a
=''b c
CommandType''d o
.''o p
Text''p t
,''t u
IDbTransaction	''v �
transaction
''� �
=
''� �
null
''� �
,
''� �
CancellationToken
''� �
cancellationToken
''� �
=
''� �
default
''� �
)
''� �
{(( 	
return)) 

connection)) 
.)) 
ExecuteReader)) ,
()), -
sql))- 0
,))0 1
param))2 7
,))7 8
transaction))9 D
,))D E
null))F J
,))J K
commandType))L W
)))W X
;))X Y
}** 	
public,, 

GridReader,, 
QueryMultiple,, '
(,,' (
string,,( .
sql,,/ 2
,,,2 3
object,,4 :
param,,; @
=,,A B
null,,C G
,,,G H
CommandType,,I T
commandType,,U `
=,,a b
CommandType,,c n
.,,n o
Text,,o s
,,,s t
IDbTransaction	,,u �
transaction
,,� �
=
,,� �
null
,,� �
,
,,� �
CancellationToken
,,� �
cancellationToken
,,� �
=
,,� �
default
,,� �
)
,,� �
{-- 	
return.. 

connection.. 
... 
QueryMultiple.. +
(..+ ,
sql.., /
,../ 0
param..1 6
,..6 7
transaction..8 C
,..C D
null..E I
,..I J
commandType..K V
)..V W
;..W X
}// 	
public11 
void11 
Dispose11 
(11 
)11 
{22 	

connection33 
.33 
Dispose33 
(33 
)33  
;33  !
}44 	
}55 
}66 �#
uD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Connections\ExactusWriteDbConnection.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '
Connections' 2
{ 
public 

class $
ExactusWriteDbConnection )
:* +%
IExactusWriteDbConnection, E
{ 
private 
readonly 
IExactusDbContext *
context+ 2
;2 3
public $
ExactusWriteDbConnection '
(' (
IExactusDbContext( 9
context: A
)A B
{ 	
this 
. 
context 
= 
context "
;" #
} 	
public 
async 
Task 
< 
int 
> 
ExecuteAsync +
(+ ,
string, 2
sql3 6
,6 7
object8 >
param? D
=E F
nullG K
,K L
IDbTransactionM [
transaction\ g
=h i
nullj n
,n o
CancellationToken	p �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return 
await 
context  
.  !

Connection! +
.+ ,
ExecuteAsync, 8
(8 9
sql9 <
,< =
param> C
,C D
transactionE P
)P Q
;Q R
} 	
public 
async 
Task 
< 
IReadOnlyList '
<' (
T( )
>) *
>* +

QueryAsync, 6
<6 7
T7 8
>8 9
(9 :
string: @
sqlA D
,D E
objectF L
paramM R
=S T
nullU Y
,Y Z
IDbTransaction[ i
transactionj u
=v w
nullx |
,| }
CancellationToken	~ �
cancellationToken
� �
=
� �
default
� �
)
� �
{ 	
return 
( 
await 
context !
.! "

Connection" ,
., -

QueryAsync- 7
<7 8
T8 9
>9 :
(: ;
sql; >
,> ?
param@ E
,E F
transactionG R
)R S
)S T
.T U
AsListU [
([ \
)\ ]
;] ^
} 	
public   
async   
Task   
<   
T   
>   $
QueryFirstOrDefaultAsync   5
<  5 6
T  6 7
>  7 8
(  8 9
string  9 ?
sql  @ C
,  C D
object  E K
param  L Q
=  R S
null  T X
,  X Y
IDbTransaction  Z h
transaction  i t
=  u v
null  w {
,  { |
CancellationToken	  } �
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
await"" 
context""  
.""  !

Connection""! +
.""+ ,$
QueryFirstOrDefaultAsync"", D
<""D E
T""E F
>""F G
(""G H
sql""H K
,""K L
param""M R
,""R S
transaction""T _
)""_ `
;""` a
}## 	
public$$ 
async$$ 
Task$$ 
<$$ 
T$$ 
>$$ 
QuerySingleAsync$$ -
<$$- .
T$$. /
>$$/ 0
($$0 1
string$$1 7
sql$$8 ;
,$$; <
object$$= C
param$$D I
=$$J K
null$$L P
,$$P Q
IDbTransaction$$R `
transaction$$a l
=$$m n
null$$o s
,$$s t
CancellationToken	$$u �
cancellationToken
$$� �
=
$$� �
default
$$� �
)
$$� �
{%% 	
return&& 
await&& 
context&&  
.&&  !

Connection&&! +
.&&+ ,
QuerySingleAsync&&, <
<&&< =
T&&= >
>&&> ?
(&&? @
sql&&@ C
,&&C D
param&&E J
,&&J K
transaction&&L W
)&&W X
;&&X Y
}'' 	
}(( 
})) �
iD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Context\ExactusDbContext.cs
	namespace

 	
HumanManagement


 
.

 
MsSqlExactus

 &
.

& '
Context

' .
{ 
public 

class 
ExactusDbContext !
:" #
	DbContext$ -
,- .
IExactusDbContext/ @
{ 
public 
ExactusDbContext 
(  
DbContextOptions  0
<0 1
ExactusDbContext1 A
>A B
optionsC J
)J K
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
} �
nD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Context\ExactusDbContextMsSql.cs
	namespace

 	
HumanManagement


 
.

 
MsSqlExactus

 &
.

& '
Context

' .
{ 
public 

class !
ExactusDbContextMsSql &
:' (
	DbContext) 2
{ 
public !
ExactusDbContextMsSql $
($ %
DbContextOptions% 5
<5 6!
ExactusDbContextMsSql6 K
>K L
optionM S
) 
: 
base 
( 
option 
) 
{ 	
}   	
	protected!! 
override!! 
void!! 
OnModelCreating!!  /
(!!/ 0
ModelBuilder!!0 <
modelBuilder!!= I
)!!I J
{"" 	
ParameterConfig## 
(## 
modelBuilder## (
)##( )
;##) *
base$$ 
.$$ 
OnModelCreating$$  
($$  !
modelBuilder$$! -
)$$- .
;$$. /
}%% 	
private&& 
void&& 
ParameterConfig&& $
(&&$ %
ModelBuilder&&% 1
modelBuilder&&2 >
)&&> ?
{'' 	
modelBuilder;; 
.;; 
Entity;; 
<;;  
ExactusEALLEmpleado;;  3
>;;3 4
(;;4 5
e;;5 6
=>;;7 9
{<< 
e== 
.== 
ToTable== 
(== 
$str== $
,==$ %
$str==& -
)==- .
.>> 
HasKey>> 
(>> 
x>> 
=>>> 
x>> 
.>> 
EMPLEADO>> '
)>>' (
;>>( )
e?? 
.?? 
Property?? 
(?? 
c?? 
=>?? 
c??  !
.??! "
EMPLEADO??" *
)??* +
;??+ ,
}@@ 
)@@ 
;@@ 
}FF 	
publicGG 
overrideGG 
asyncGG 
TaskGG "
<GG" #
intGG# &
>GG& '
SaveChangesAsyncGG( 8
(GG8 9
CancellationTokenGG9 J
cancellationTokenGGK \
=GG] ^
defaultGG_ f
(GGf g
CancellationTokenGGg x
)GGx y
)GGy z
{HH 	
returnmm 
awaitmm 
basemm 
.mm  
SaveChangesAsyncmm  0
(mm0 1
cancellationTokenmm1 B
)mmB C
;mmC D
}nn 	
}oo 
}pp �N
qD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Repository\BaseExactusRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '

Repository' 1
{ 
public 

class !
ExactusBaseRepository &
<& '
T' (
>( )
:* +"
IExactusBaseRepository, B
<B C
TC D
>D E
whereF K
TL M
:N O
classP U
{ 
	protected
 !
ExactusDbContextMsSql )
context+ 2
;2 3
	protected 
readonly 
DbSet  
<  !
T! "
>" #
dbSetEntity$ /
;/ 0
public !
ExactusBaseRepository $
($ %!
ExactusDbContextMsSql% :
context; B
)B C
{ 	
this 
. 
context 
= 
context "
;" #
dbSetEntity 
= 
this 
. 
context &
.& '
Set' *
<* +
T+ ,
>, -
(- .
). /
;/ 0
} 	
public 
async 
Task 
Delete  
(  !
T! "
entity# )
)) *
{ 	
context 
. 
Remove 
( 
entity !
)! "
;" #
await 
context 
. 
SaveChangesAsync *
(* +
)+ ,
;, -
} 	
public 
async 
Task 
DeleteRange %
(% &
List& *
<* +
T+ ,
>, -

entityList. 8
)8 9
{ 	
context   
.   
RemoveRange   
(    

entityList    *
)  * +
;  + ,
await!! 
context!! 
.!! 
SaveChangesAsync!! *
(!!* +
)!!+ ,
;!!, -
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
T$$ 
>$$ 
Find$$ !
($$! "
object$$" (
id$$) +
)$$+ ,
{%% 	
var&& 
entity&& 
=&& 
await&& 
dbSetEntity&& *
.&&* +
	FindAsync&&+ 4
(&&4 5
id&&5 7
)&&7 8
;&&8 9
dbSetEntity'' 
.'' 
Attach'' 
('' 
entity'' %
)''% &
.''& '
State''' ,
=''- .
EntityState''/ :
.'': ;
Detached''; C
;''C D
return(( 
entity(( 
;(( 
})) 	
public++ 
async++ 
Task++ 
<++ 
T++ 
>++ 
FindPredicate++ *
(++* +

Expression+++ 5
<++5 6
Func++6 :
<++: ;
T++; <
,++< =
bool++> B
>++B C
>++C D
	predicate++E N
)++N O
{,, 	
return-- 
await-- 
dbSetEntity-- $
.--$ %
Where--% *
(--* +
	predicate--+ 4
)--4 5
.--5 6
FirstOrDefaultAsync--6 I
(--I J
)--J K
;--K L
}.. 	
public00 
async00 
Task00 
<00 
List00 
<00 
T00  
>00  !
>00! "
FindAllPredicate00# 3
(003 4

Expression004 >
<00> ?
Func00? C
<00C D
T00D E
,00E F
bool00G K
>00K L
>00L M
	predicate00N W
)00W X
{11 	
return22 
await22 
dbSetEntity22 $
.22$ %
Where22% *
(22* +
	predicate22+ 4
)224 5
.225 6
ToListAsync226 A
(22A B
)22B C
;22C D
}33 	
public55 
async55 
Task55 
<55 
bool55 
>55 
Exist55  %
(55% &

Expression55& 0
<550 1
Func551 5
<555 6
T556 7
,557 8
bool559 =
>55= >
>55> ?
	predicate55@ I
)55I J
{66 	
return77 
await77 
dbSetEntity77 $
.77$ %
AnyAsync77% -
(77- .
	predicate77. 7
)777 8
;778 9
}88 	
public99 
async99 
Task99 
<99 
List99 
<99 
T99  
>99  !
>99! "
GetAll99# )
(99) *
)99* +
{:: 	
return;; 
await;; 
dbSetEntity;; $
.;;$ %
AsNoTracking;;% 1
(;;1 2
);;2 3
.;;3 4
ToListAsync;;4 ?
(;;? @
);;@ A
;;;A B
}<< 	
public== 
async== 
Task== 
Add== 
(== 
T== 
entity==  &
)==& '
{>> 	
await?? 
dbSetEntity?? 
.?? 
AddAsync?? &
(??& '
entity??' -
)??- .
;??. /
await@@ 
context@@ 
.@@ 
SaveChangesAsync@@ *
(@@* +
)@@+ ,
;@@, -
dbSetEntityAA 
.AA 
AttachAA 
(AA 
entityAA %
)AA% &
.AA& '
StateAA' ,
=AA- .
EntityStateAA/ :
.AA: ;
DetachedAA; C
;AAC D
}BB 	
publicDD 
asyncDD 
TaskDD 
AddRangeDD "
(DD" #
IEnumerableDD# .
<DD. /
TDD/ 0
>DD0 1

entityListDD2 <
)DD< =
{EE 	
awaitFF 
dbSetEntityFF 
.FF 
AddRangeAsyncFF +
(FF+ ,

entityListFF, 6
)FF6 7
;FF7 8
awaitGG 
contextGG 
.GG 
SaveChangesAsyncGG *
(GG* +
)GG+ ,
;GG, -
foreachHH 
(HH 
varHH 
itemHH 
inHH  

entityListHH! +
)HH+ ,
{II 
dbSetEntityJJ 
.JJ 
AttachJJ "
(JJ" #
itemJJ# '
)JJ' (
.JJ( )
StateJJ) .
=JJ/ 0
EntityStateJJ1 <
.JJ< =
DetachedJJ= E
;JJE F
}KK 
}LL 	
publicMM 
asyncMM 
TaskMM 
UpdateMM  
(MM  !
TMM! "
entityMM# )
)MM) *
{NN 	
dbSetEntityOO 
.OO 
AttachOO 
(OO 
entityOO %
)OO% &
;OO& '
contextPP 
.PP 
UpdatePP 
(PP 
entityPP !
)PP! "
;PP" #
awaitQQ 
contextQQ 
.QQ 
SaveChangesAsyncQQ *
(QQ* +
)QQ+ ,
;QQ, -
dbSetEntityRR 
.RR 
AttachRR 
(RR 
entityRR %
)RR% &
.RR& '
StateRR' ,
=RR- .
EntityStateRR/ :
.RR: ;
DetachedRR; C
;RRC D
}SS 	
publicTT 
asyncTT 
TaskTT 
UpdatePartialTT '
(TT' (
TTT( )
entityTT* 0
,TT0 1
paramsTT2 8

ExpressionTT9 C
<TTC D
FuncTTD H
<TTH I
TTTI J
,TTJ K
objectTTL R
>TTR S
>TTS T
[TTT U
]TTU V

propertiesTTW a
)TTa b
{UU 	
dbSetEntityVV 
.VV 
AttachVV 
(VV 
entityVV %
)VV% &
;VV& '
foreachXX 
(XX 
varXX 
propertyXX !
inXX" $

propertiesXX% /
)XX/ 0
{YY 
contextZZ 
.ZZ 
EntryZZ 
(ZZ 
entityZZ $
)ZZ$ %
.ZZ% &
PropertyZZ& .
(ZZ. /
propertyZZ/ 7
)ZZ7 8
.ZZ8 9

IsModifiedZZ9 C
=ZZD E
trueZZF J
;ZZJ K
}[[ 
await\\ 
context\\ 
.\\ 
SaveChangesAsync\\ *
(\\* +
)\\+ ,
;\\, -
}]] 	
public^^ 
async^^ 
Task^^ %
UpdatePartialNotIncluding^^ 3
(^^3 4
T^^4 5
entity^^6 <
,^^< =
params^^> D

Expression^^E O
<^^O P
Func^^P T
<^^T U
T^^U V
,^^V W
object^^X ^
>^^^ _
>^^_ `
[^^` a
]^^a b

properties^^c m
)^^m n
{__ 	
dbSetEntity`` 
.`` 
Attach`` 
(`` 
entity`` %
)``% &
;``& '
contextaa 
.aa 
Entryaa 
(aa 
entityaa  
)aa  !
.aa! "
Stateaa" '
=aa( )
EntityStateaa* 5
.aa5 6
Modifiedaa6 >
;aa> ?
foreachbb 
(bb 
varbb 
propertybb !
inbb" $

propertiesbb% /
)bb/ 0
{cc 
contextdd 
.dd 
Entrydd 
(dd 
entitydd $
)dd$ %
.dd% &
Propertydd& .
(dd. /
propertydd/ 7
)dd7 8
.dd8 9

IsModifieddd9 C
=ddD E
falseddF K
;ddK L
}ee 
awaitff 
contextff 
.ff 
SaveChangesAsyncff *
(ff* +
)ff+ ,
;ff, -
}gg 	
}jj 
}kk �
yD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Repository\ExactusDepartamentoRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '

Repository' 1
{ 
public 

class )
ExactusDepartamentoRepository .
:/ 0*
IExactusDepartamentoRepository2 P
{ 
private 
readonly $
IExactusReadDbConnection 1#
exactusReadDbConnection4 K
;K L
private 
readonly 
ILogger  
<  !)
ExactusDepartamentoRepository! >
>> ?
_logger@ G
;G H
public )
ExactusDepartamentoRepository ,
(, -$
IExactusReadDbConnection- E#
exactusReadDbConnectionF ]
,] ^
ILogger_ f
<f g*
ExactusDepartamentoRepository	g �
>
� �
_logger
� �
)
� �
{ 	
this 
. #
exactusReadDbConnection (
=) *#
exactusReadDbConnection+ B
;B C
this 
. 
_logger 
= 
_logger "
;" #
} 	
public 
async 
Task 
< 
List 
< 
ExactusDepartamento 2
>2 3
>3 4
GetAll5 ;
(; <&
ExactusDepartmentFilterDto< V
	filterDtoW `
)` a
{ 	
try 
{ 
string 
	storename  
=! "
$"# %
$str% &
{& '
	filterDto' 0
.0 1
Scheme1 7
}7 8
$str8 S
"S T
;T U
var   
queryParameters   #
=  $ %
new  & )
DynamicParameters  * ;
(  ; <
)  < =
;  = >
var"" 
list"" 
="" 
await""  #
exactusReadDbConnection""! 8
.""8 9

QueryAsync""9 C
<""C D
ExactusDepartamento""D W
>""W X
(""X Y
	storename## 
,## 
queryParameters$$ $
,$$$ %
commandType$$& 1
:$$1 2
CommandType$$3 >
.$$> ?
StoredProcedure$$? N
)$$N O
;$$O P
return&& 
list&& 
.&& 
ToList&& "
(&&" #
)&&# $
;&&$ %
}'' 
catch(( 
((( 
	Exception(( 
ex(( 
)((  
{)) 
_logger** 
.** 
LogError**  
(**  !
$str**! K
+**L M
ex**N P
.**P Q
Message**Q X
)**X Y
;**Y Z
_logger++ 
.++ 
LogError++  
(++  !
$str++! K
+++L M
ex++N P
.++P Q

StackTrace++Q [
)++[ \
;++\ ]
},, 
return-- 
new-- 
List-- 
<-- 
ExactusDepartamento-- /
>--/ 0
(--0 1
)--1 2
;--2 3
}.. 	
}// 
}00 �	
yD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Repository\ExactusEALLEmpleadoRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '

Repository' 1
{ 
public 

class )
ExactusEALLEmpleadoRepository .
:/ 0!
ExactusBaseRepository1 F
<F G
ExactusEALLEmpleadoG Z
>Z [
,[ \*
IExactusEALLEmpleadoRepository] {
{ 
private 
readonly $
IExactusReadDbConnection 1#
exactusReadDbConnection2 I
;I J
public )
ExactusEALLEmpleadoRepository ,
(, -$
IExactusReadDbConnection- E#
exactusReadDbConnectionF ]
,] ^!
ExactusDbContextMsSql 3
context4 ;
); <
: 
base 
( 
context 
) 
{ 	
this 
. #
exactusReadDbConnection (
=( )#
exactusReadDbConnection* A
;A B
} 	
} 
} �
uD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Repository\ExactusEmpleadoRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '

Repository' 1
{ 
public 

class %
ExactusEmpleadoRepository *
:+ ,&
IExactusEmpleadoRepository- G
{ 
private 
readonly $
IExactusReadDbConnection 1#
exactusReadDbConnection2 I
;I J
private 
readonly 
ILogger  
<  !%
ExactusEmpleadoRepository! :
>: ;
_logger< C
;C D
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public %
ExactusEmpleadoRepository (
(( )$
IExactusReadDbConnection) A#
exactusReadDbConnectionB Y
,Y Z
ILogger[ b
<b c%
ExactusEmpleadoRepositoryc |
>| }
_logger	~ �
,
� �
IConfiguration
� �
configuration
� �
)
� �
{ 	
this 
. #
exactusReadDbConnection (
=) *#
exactusReadDbConnection+ B
;B C
this 
. 
_logger 
= 
_logger "
;" #
Configuration 
= 
configuration )
;) *
} 	
public 
async 
Task 
< "
ExactusFullEmployeeDto 0
>0 1
GetAll2 8
(8 9$
ExactusEmpleadoFilterDto9 Q
	filterDtoR [
)[ \
{ 	
try 
{   "
ExactusFullEmployeeDto!! &#
oExactusFullEmployeeDto!!' >
=!!? @
new!!A D"
ExactusFullEmployeeDto!!E [
(!![ \
)!!\ ]
;!!] ^
string$$ 
	storename$$  
=$$! "
$"$$# %
$str$$% &
{$$& '
	filterDto$$' 0
.$$0 1
Scheme$$1 7
}$$7 8
$str$$8 P
"$$P Q
;$$Q R
var&& 
queryParameters&& #
=&&$ %
new&&& )
DynamicParameters&&* ;
(&&; <
)&&< =
;&&= >
var(( 
results(( 
=(( #
exactusReadDbConnection(( 5
.((5 6
QueryMultiple((6 C
(((C D
	storename)) 
,)) 
queryParameters** $
,**$ %
commandType**& 1
:**1 2
CommandType**3 >
.**> ?
StoredProcedure**? N
)**N O
;**O P
var-- 
	Empleados-- 
=-- 
results--  '
.--' (
Read--( ,
<--, -
ExactusEmpleado--- <
>--< =
(--= >
)--> ?
.--? @
ToList--@ F
(--F G
)--G H
;--H I
var.. 

Academicos.. 
=..  
results..! (
...( )
Read..) -
<..- .$
ExactusEmpleadoAcademico... F
>..F G
(..G H
)..H I
...I J
ToList..J P
(..P Q
)..Q R
;..R S
var// 
Experiencias//  
=//! "
results//# *
.//* +
Read//+ /
</// 0&
ExactusEmpleadoExperiencia//0 J
>//J K
(//K L
)//L M
.//M N
ToList//N T
(//T U
)//U V
;//V W
var00 
Familia00 
=00 
results00 %
.00% &
Read00& *
<00* +"
ExactusEmpleadoFamilia00+ A
>00A B
(00B C
)00C D
.00D E
ToList00E K
(00K L
)00L M
;00M N#
oExactusFullEmployeeDto22 '
.22' (
	Empleados22( 1
=222 3
	Empleados224 =
;22= >#
oExactusFullEmployeeDto33 '
.33' (

Academicos33( 2
=333 4

Academicos335 ?
;33? @#
oExactusFullEmployeeDto44 '
.44' (
Experiencias44( 4
=445 6
Experiencias447 C
;44C D#
oExactusFullEmployeeDto55 '
.55' (
Familia55( /
=550 1
Familia552 9
;559 :
return88 #
oExactusFullEmployeeDto88 .
;88. /
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;; 
_logger<< 
.<< 
LogError<<  
(<<  !
$str<<! H
)<<H I
;<<I J
_logger== 
.== 
LogError==  
(==  !
$str==! P
+==Q R
ex==S U
.==U V
Message==V ]
)==] ^
;==^ _
_logger>> 
.>> 
LogError>>  
(>>  !
$str>>! P
+>>Q R
ex>>S U
.>>U V

StackTrace>>V `
)>>` a
;>>a b
}?? 
return@@ 
new@@ "
ExactusFullEmployeeDto@@ -
(@@- .
)@@. /
;@@/ 0
}BB 	
publicDD 
asyncDD 
TaskDD 
<DD 
boolDD 
>DD 
InsertEmpleadoDD  .
(DD. /$
ExactusEmpleadoInsertDtoDD/ G
dtoDDH K
)DDK L
{EE 	
stringFF 
queryFF 
=FF 
$str	F� &
;
��& '
query
�� 
=
�� 
query
�� 
.
�� 
Replace
�� !
(
��! "
$str
��" ,
,
��, -
dto
��. 1
.
��1 2
Scheme
��2 8
)
��8 9
;
��9 :
var
�� 
result
�� 
=
�� 
await
�� %
exactusReadDbConnection
�� 6
.
��6 7

QueryAsync
��7 A
<
��A B
int
��B E
>
��E F
(
��F G
query
��G L
,
��L M
new
��, /
{
��, -
EMPLEADO
��0 8
=
��9 :
dto
��; >
.
��> ?
EMPLEADO
��? G
,
��G H
NOMBRE
��0 6
=
��7 8
dto
��9 <
.
��< =
NOMBRE
��= C
,
��C D
SEXO
��0 4
=
��5 6
dto
��7 :
.
��: ;
SEXO
��; ?
,
��? @
ESTADO_EMPLEADO
��0 ?
=
��@ A
dto
��B E
.
��E F
ESTADO_EMPLEADO
��F U
,
��U V
ACTIVO
��0 6
=
��7 8
dto
��9 <
.
��< =
ACTIVO
��= C
,
��C D
FECHA_INGRESO
��0 =
=
��> ?
dto
��@ C
.
��C D
FECHA_INGRESO
��D Q
,
��Q R
DEPARTAMENTO
��0 <
=
��= >
dto
��? B
.
��B C
DEPARTAMENTO
��C O
,
��O P
PUESTO
��0 6
=
��7 8
dto
��9 <
.
��< =
PUESTO
��= C
,
��C D
PLAZA
��0 5
=
��6 7
dto
��8 ;
.
��; <
PLAZA
��< A
,
��A B
NOMINA
��0 6
=
��7 8
dto
��9 <
.
��< =
NOMINA
��= C
,
��C D
CENTRO_COSTO
��0 <
=
��= >
dto
��? B
.
��B C
CENTRO_COSTO
��C O
,
��O P
FECHA_NACIMIENTO
��0 @
=
��A B
dto
��C F
.
��F G
FECHA_NACIMIENTO
��G W
,
��W X
	UBICACION
��0 9
=
��: ;
dto
��< ?
.
��? @
	UBICACION
��@ I
,
��I J
PAIS
��0 4
=
��5 6
dto
��7 :
.
��: ;
PAIS
��; ?
,
��? @
ESTADO_CIVIL
��0 <
=
��= >
dto
��? B
.
��B C
ESTADO_CIVIL
��C O
,
��O P
VACS_PENDIENTES
��0 ?
=
��@ A
dto
��B E
.
��E F
VACS_PENDIENTES
��F U
,
��U V
VACS_ULT_CALCULO
��0 @
=
��A B
dto
��C F
.
��F G
VACS_ULT_CALCULO
��G W
,
��W X 
SALARIO_REFERENCIA
��0 B
=
��C D
dto
��E H
.
��H I 
SALARIO_REFERENCIA
��I [
,
��[ \

FORMA_PAGO
��0 :
=
��; <
dto
��= @
.
��@ A

FORMA_PAGO
��A K
,
��K L
HORARIO
��0 7
=
��8 9
dto
��: =
.
��= >
HORARIO
��> E
,
��E F
FECHA_NO_PAGO
��0 =
=
��> ?
dto
��@ C
.
��C D
FECHA_NO_PAGO
��D Q
,
��Q R 
TIPO_SALARIO_AUMEN
��0 B
=
��C D
dto
��E H
.
��H I 
TIPO_SALARIO_AUMEN
��I [
,
��[ \
VACS_ADICIONALES
��0 @
=
��A B
dto
��C F
.
��F G
VACS_ADICIONALES
��G W
,
��W X
NoteExistsFlag
��0 >
=
��? @
dto
��A D
.
��D E
NoteExistsFlag
��E S
,
��S T

RecordDate
��0 :
=
��; <
dto
��= @
.
��@ A

RecordDate
��A K
,
��K L

RowPointer
��0 :
=
��; <
dto
��= @
.
��@ A

RowPointer
��A K
,
��K L
	CreatedBy
��0 9
=
��: ;
dto
��< ?
.
��? @
	CreatedBy
��@ I
,
��I J
	UpdatedBy
��0 9
=
��: ;
dto
��< ?
.
��? @
	UpdatedBy
��@ I
,
��I J

CreateDate
��0 :
=
��; <
dto
��= @
.
��@ A

CreateDate
��A K
,
��K L
DIRECCION_HAB
��0 =
=
��= >
dto
��? B
.
��B C
DIRECCION_HAB
��C P
}
��, -
)
��- .
;
��. /
return
�� 
result
�� 
.
�� 
Count
�� 
==
��  "
$num
��# $
;
��$ %
}
�� 	
public
�� 
async
�� 
Task
�� 
<
�� 
string
��  
>
��  !
InsertEmpleadoSP
��" 2
(
��2 3%
ExactusEmpleadoInsSpDto
��3 J
dto
��K N
)
��N O
{
�� 	
string
�� 
sqlstore
�� 
=
�� 
string
�� $
.
��$ %
Format
��% +
(
��+ ,
$str
��- F
,
��F G
dto
��G J
.
��J K
Schema
��K Q
)
��Q R
;
��R S
var
�� 
queryParameters
�� 
=
��  !
new
��" %
DynamicParameters
��& 7
(
��7 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  -
,
��- .
dto
��/ 2
.
��2 3

PSCONJUNTO
��3 =
)
��= >
;
��> ?
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSUSUARIO
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  -
,
��- .
dto
��/ 2
.
��2 3

PSEMPLEADO
��3 =
)
��= >
;
��> ?
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSNOMBRE
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  3
,
��3 4
dto
��5 8
.
��8 9
PSPRIMERAPELLIDO
��9 I
)
��I J
;
��J K
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  4
,
��4 5
dto
��6 9
.
��9 :
PSSEGUNDOAPELLIDO
��: K
)
��K L
;
��L M
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  /
,
��/ 0
dto
��1 4
.
��4 5
PSNOMBREPILA
��5 A
)
��A B
;
��B C
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  )
,
��) *
dto
��+ .
.
��. /
PSSEXO
��/ 5
)
��5 6
;
��6 7
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  /
,
��/ 0
dto
��1 4
.
��4 5
PSTIPOSANGRE
��5 A
)
��A B
;
��B C
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  3
,
��3 4
dto
��5 8
.
��8 9
PSIDENTIFICACION
��9 I
)
��I J
;
��J K
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSPASAPORTE
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  2
,
��2 3
dto
��4 7
.
��7 8
PDTFECHAINGRESO
��8 G
)
��G H
;
��H I
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  1
,
��1 2
dto
��3 6
.
��6 7
PSDEPARTAMENTO
��7 E
)
��E F
;
��F G
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSPUESTO
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  *
,
��* +
dto
��, /
.
��/ 0
PSPLAZA
��0 7
)
��7 8
;
��8 9
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSNOMINA
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  0
,
��0 1
dto
��2 5
.
��5 6
PSCENTROCOSTO
��6 C
)
��C D
;
��D E
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  5
,
��5 6
dto
��7 :
.
��: ; 
PDTFECHANACIMIENTO
��; M
)
��M N
;
��N O
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSUBICACION
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  )
,
��) *
dto
��+ .
.
��. /
PSPAIS
��/ 5
)
��5 6
;
��6 7
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  0
,
��0 1
dto
��2 5
.
��5 6
PSESTADOCIVIL
��6 C
)
��C D
;
��D E
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  1
,
��1 2
dto
��3 6
.
��6 7
PNDEPENDIENTES
��7 E
)
��E F
;
��F G
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSASEGURADO
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  0
,
��0 1
dto
��2 5
.
��5 6
PSCLASESEGURO
��6 C
)
��C D
;
��D E
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  4
,
��4 5
dto
��6 9
.
��9 :
PSPERMISOCONDUCIR
��: K
)
��K L
;
��L M
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  1
,
��1 2
dto
��3 6
.
��6 7
PSPERMISOSALUD
��7 E
)
��E F
;
��F G
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  (
,
��( )
dto
��* -
.
��- .
PSNIT
��. 3
)
��3 4
;
��4 5
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  6
,
��6 7
dto
��8 ;
.
��; <!
PNSALARIOREFERENCIA
��< O
)
��O P
;
��P Q
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  2
,
��2 3
dto
��4 7
.
��7 8
PSCUENTAENTIDAD
��8 G
)
��G H
;
��H I
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSFORMAPAGO
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  6
,
��6 7
dto
��8 ;
.
��; <!
PSENTIDADFINANCIERA
��< O
)
��O P
;
��P Q
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSHORARIO
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSTELEFONO1
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSNOTASTEL1
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSTELEFONO2
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSNOTASTEL2
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSTELEFONO3
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSNOTASTEL3
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  *
,
��* +
dto
��, /
.
��/ 0
PSEMAIL
��0 7
)
��7 8
;
��8 9
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  3
,
��3 4
dto
��5 8
.
��8 9
PDTFECHAANTIGEMP
��9 I
)
��I J
;
��J K
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  3
,
��3 4
dto
��5 8
.
��8 9
PDTFECHAANTIGGOB
��9 I
)
��I J
;
��J K
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO1
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO2
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO3
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO4
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO5
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO6
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO7
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO8
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSRUBRO9
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO10
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO11
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO12
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO13
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO14
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO15
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO16
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO17
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO18
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO19
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO20
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO21
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO22
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO23
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO24
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSRUBRO25
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  *
,
��* +
dto
��, /
.
��/ 0
PSNOTAS
��0 7
)
��7 8
;
��8 9
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  4
,
��4 5
dto
��6 9
.
��9 :
PNVACSADICIONALES
��: K
)
��K L
;
��L M
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  1
,
��1 2
$str
��3 ;
,
��; <
DbType
��= C
.
��C D
String
��D J
,
��J K
	direction
��L U
:
��U V 
ParameterDirection
��W i
.
��i j
Output
��j p
,
��p q
$num
��r u
)
��u v
;
��v w
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 0
+
��1 2
sqlstore
��3 ;
)
��; <
;
��< =
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B

PSCONJUNTO
��B L
)
��L M
;
��M N
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSUSUARIO
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B

PSEMPLEADO
��B L
)
��L M
;
��M N
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSNOMBRE
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSPRIMERAPELLIDO
��B R
)
��R S
;
��S T
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSSEGUNDOAPELLIDO
��B S
)
��S T
;
��T U
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSNOMBREPILA
��B N
)
��N O
;
��O P
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSSEXO
��B H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSTIPOSANGRE
��B N
)
��N O
;
��O P
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSIDENTIFICACION
��B R
)
��R S
;
��S T
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSPASAPORTE
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PDTFECHAINGRESO
��B Q
)
��Q R
;
��R S
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSDEPARTAMENTO
��B P
)
��P Q
;
��Q R
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSPUESTO
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSPLAZA
��B I
)
��I J
;
��J K
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSNOMINA
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSCENTROCOSTO
��B O
)
��O P
;
��P Q
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B 
PDTFECHANACIMIENTO
��B T
)
��T U
;
��U V
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSUBICACION
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSPAIS
��B H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSESTADOCIVIL
��B O
)
��O P
;
��P Q
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PNDEPENDIENTES
��B P
)
��P Q
;
��Q R
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSASEGURADO
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSCLASESEGURO
��B O
)
��O P
;
��P Q
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSPERMISOCONDUCIR
��B S
)
��S T
;
��T U
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSPERMISOSALUD
��B P
)
��P Q
;
��Q R
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSNIT
��B G
)
��G H
;
��H I
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B!
PNSALARIOREFERENCIA
��B U
)
��U V
;
��V W
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSCUENTAENTIDAD
��B Q
)
��Q R
;
��R S
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSFORMAPAGO
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B!
PSENTIDADFINANCIERA
��B U
)
��U V
;
��V W
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSHORARIO
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSTELEFONO1
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSNOTASTEL1
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSTELEFONO2
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSNOTASTEL2
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSTELEFONO3
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSNOTASTEL3
��B M
)
��M N
;
��N O
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSEMAIL
��B I
)
��I J
;
��J K
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PDTFECHAANTIGEMP
��B R
)
��R S
;
��S T
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PDTFECHAANTIGGOB
��B R
)
��R S
;
��S T
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO1
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO2
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO3
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO4
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO5
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO6
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO7
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO8
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSRUBRO9
��B J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO10
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO11
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO12
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO13
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO14
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO15
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO16
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO17
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO18
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO19
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO20
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO21
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO22
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO23
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO24
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
	PSRUBRO25
��B K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PSNOTAS
��B I
)
��I J
;
��J K
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# <
+
��< =
dto
��> A
.
��A B
PNVACSADICIONALES
��B S
)
��S T
;
��T U
var
�� 
listUSer
�� 
=
�� 
await
��  %
exactusReadDbConnection
��! 8
.
��8 9

QueryAsync
��9 C
<
��C D
object
��D J
>
��J K
(
��K L
sqlstore
�� 
,
�� 
queryParameters
��  
,
��  !
commandType
��" -
:
��- .
CommandType
��/ :
.
��: ;
StoredProcedure
��; J
)
��J K
;
��K L
string
�� 
MENSAJEERROR
�� 
=
��  !
queryParameters
��" 1
.
��1 2
Get
��2 5
<
��5 6
string
��6 <
>
��< =
(
��= >
$str
��> O
)
��O P
;
��P Q
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��: ;
MENSAJEERROR
��< H
)
��H I
;
��I J
return
�� 
MENSAJEERROR
�� 
;
��  
}
�� 	
public
�� 
async
�� 
Task
�� 
<
�� 
string
��  
>
��  !
InsertDireccionSP
��" 3
(
��3 4(
ExactusEmpleadoInsSpDirDto
��4 N
dto
��O R
)
��R S
{
�� 	
string
�� 
sqlstore
�� 
=
�� 
string
�� $
.
��$ %
Format
��% +
(
��+ ,
$str
��, J
,
��J K
dto
��L O
.
��O P
Schema
��P V
)
��V W
;
��W X
var
�� 
queryParameters
�� 
=
��  !
new
��" %
DynamicParameters
��& 7
(
��7 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  -
,
��- .
dto
��/ 2
.
��2 3

PSCONJUNTO
��3 =
)
��= >
;
��> ?
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSUSUARIO
��2 ;
)
��; <
;
��< =
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  -
,
��- .
dto
��/ 2
.
��2 3

PSEMPLEADO
��3 =
)
��= >
;
��> ?
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  2
,
��2 3
dto
��4 7
.
��7 8
PSTIPODIRECCION
��8 G
)
��G H
;
��H I
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  .
,
��. /
dto
��0 3
.
��3 4
PSDIRECCION
��4 ?
)
��? @
;
��@ A
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��, /
.
��/ 0
PSCAMPO1
��0 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��, /
.
��/ 0
PSCAMPO2
��0 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��, /
.
��/ 0
PSCAMPO3
��0 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��, /
.
��/ 0
PSCAMPO4
��0 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��, /
.
��/ 0
PSCAMPO5
��0 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��, /
.
��/ 0
PSCAMPO6
��0 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��, /
.
��/ 0
PSCAMPO7
��0 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��, /
.
��/ 0
PSCAMPO8
��0 8
)
��8 9
;
��9 :
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  +
,
��+ ,
dto
��- 0
.
��0 1
PSCAMPO9
��1 9
)
��9 :
;
��: ;
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  ,
,
��, -
dto
��. 1
.
��1 2
	PSCAMPO10
��2 ;
)
��; <
;
��< =
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 0
+
��1 2
sqlstore
��3 ;
)
��; <
;
��< =
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @

PSCONJUNTO
��@ J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
	PSUSUARIO
��@ I
)
��I J
;
��J K
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @

PSEMPLEADO
��@ J
)
��J K
;
��K L
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSTIPODIRECCION
��@ O
)
��O P
;
��P Q
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSDIRECCION
��@ K
)
��K L
;
��L M
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO1
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO2
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO3
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO4
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO5
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO6
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO7
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO8
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
PSCAMPO9
��@ H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��9 :
dto
��< ?
.
��? @
	PSCAMPO10
��@ I
)
��I J
;
��J K
queryParameters
�� 
.
�� 
Add
�� 
(
��  
$str
��  1
,
��1 2
$str
��3 ;
,
��; <
DbType
��= C
.
��C D
String
��D J
,
��J K
	direction
��L U
:
��U V 
ParameterDirection
��W i
.
��i j
Output
��j p
,
��p q
$num
��r u
)
��u v
;
��v w
var
�� 
listUSer
�� 
=
�� 
await
��  %
exactusReadDbConnection
��! 8
.
��8 9

QueryAsync
��9 C
<
��C D
object
��D J
>
��J K
(
��K L
sqlstore
�� 
,
�� 
queryParameters
��  
,
��  !
commandType
��" -
:
��- .
CommandType
��/ :
.
��: ;
StoredProcedure
��; J
)
��J K
;
��K L
string
�� 
MENSAJEERROR
�� 
=
��  !
queryParameters
��" 1
.
��1 2
Get
��2 5
<
��5 6
string
��6 <
>
��< =
(
��= >
$str
��> O
)
��O P
;
��P Q
_logger
�� 
.
�� 
LogInformation
�� "
(
��" #
$str
��# 9
+
��: ;
MENSAJEERROR
��< H
)
��H I
;
��I J
return
�� 
MENSAJEERROR
�� 
;
��  
}
�� 	
public
�� 
async
�� 
Task
�� 
<
�� 
List
�� 
<
�� %
ExactusEmpleadoTablaDto
�� 6
>
��6 7
>
��7 8
GetEmpleadoTabla
��9 I
(
��I J+
ExactusEmpleadoTablaFilterDto
��J g
	filterDto
��h q
)
��q r
{
�� 	
try
�� 
{
�� 
string
�� 
	storename
��  
=
��! "
$"
��# %
$str
��% &
{
��& '
	filterDto
��' 0
.
��0 1
Scheme
��1 7
}
��7 8
$str
��8 Q
"
��Q R
;
��R S
var
�� 
queryParameters
�� #
=
��$ %
new
��& )
DynamicParameters
��* ;
(
��; <
)
��< =
;
��= >
queryParameters
�� 
.
��  
Add
��  #
(
��# $
$str
��$ /
,
��/ 0
	filterDto
��1 :
.
��: ;
	TableName
��; D
)
��D E
;
��E F
var
�� 
list
�� 
=
�� 
await
��  %
exactusReadDbConnection
��! 8
.
��8 9

QueryAsync
��9 C
<
��C D%
ExactusEmpleadoTablaDto
��D [
>
��[ \
(
��\ ]
	storename
�� 
,
�� 
queryParameters
�� $
,
��$ %
commandType
��& 1
:
��1 2
CommandType
��3 >
.
��> ?
StoredProcedure
��? N
)
��N O
;
��O P
return
�� 
list
�� 
.
�� 
ToList
�� "
(
��" #
)
��# $
;
��$ %
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
_logger
�� 
.
�� 
LogError
��  
(
��  !
$str
��! H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogError
��  
(
��  !
$str
��! P
+
��Q R
ex
��S U
.
��U V
Message
��V ]
)
��] ^
;
��^ _
_logger
�� 
.
�� 
LogError
��  
(
��  !
$str
��! P
+
��Q R
ex
��S U
.
��U V

StackTrace
��V `
)
��` a
;
��a b
}
�� 
return
�� 
new
�� 
List
�� 
<
�� %
ExactusEmpleadoTablaDto
�� 3
>
��3 4
(
��4 5
)
��5 6
;
��6 7
}
�� 	
public
�� 
async
�� 
Task
�� 
<
�� !
ExactusGlobalCCPDto
�� -
>
��- .!
GetExactusGlobalCCP
��/ B
(
��B C
string
��C I
sschema
��J Q
)
��Q R
{
�� 	
try
�� 
{
�� 
string
�� 
	storename
��  
=
��! "
$"
��# %
$str
��% &
{
��& '
sschema
��' .
}
��. /
$str
��/ C
"
��C D
;
��D E
var
�� 
queryParameters
�� #
=
��$ %
new
��& )
DynamicParameters
��* ;
(
��; <
)
��< =
;
��= >
var
�� 
list
�� 
=
�� 
await
��  %
exactusReadDbConnection
��! 8
.
��8 9

QueryAsync
��9 C
<
��C D!
ExactusGlobalCCPDto
��D W
>
��W X
(
��X Y
	storename
�� 
,
�� 
queryParameters
�� $
,
��$ %
commandType
��& 1
:
��1 2
CommandType
��3 >
.
��> ?
StoredProcedure
��? N
)
��N O
;
��O P
return
�� 
list
�� 
.
�� 
FirstOrDefault
�� *
(
��* +
)
��+ ,
;
��, -
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
_logger
�� 
.
�� 
LogError
��  
(
��  !
$str
��! H
)
��H I
;
��I J
_logger
�� 
.
�� 
LogError
��  
(
��  !
$str
��! P
+
��Q R
ex
��S U
.
��U V
Message
��V ]
)
��] ^
;
��^ _
_logger
�� 
.
�� 
LogError
��  
(
��  !
$str
��! P
+
��Q R
ex
��S U
.
��U V

StackTrace
��V `
)
��` a
;
��a b
}
�� 
return
�� 
new
�� !
ExactusGlobalCCPDto
�� *
(
��+ ,
)
��, -
;
��- .
}
�� 	
}
�� 
}�� �y
{D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Repository\ExactusMedicalRequestRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '

Repository' 1
{ 
public 

class +
ExactusMedicalRequestRepository 0
:1 2,
 IExactusMedicalRequestRepository3 S
{ 
private 
readonly $
IExactusReadDbConnection 1#
exactusReadDbConnection2 I
;I J
private 
readonly 
ILogger  
<  !+
ExactusMedicalRequestRepository! @
>@ A
_loggerB I
;I J
public +
ExactusMedicalRequestRepository .
(. /$
IExactusReadDbConnection/ G#
exactusReadDbConnectionH _
,_ `
ILoggera h
<h i,
ExactusMedicalRequestRepository	i �
>
� �
_logger
� �
)
� �
{ 	
this 
. #
exactusReadDbConnection (
=) *#
exactusReadDbConnection+ B
;B C
this 
. 
_logger 
= 
_logger "
;" #
} 	
public 
async 
Task 
< )
ExactusMedicalRequestInsSpDto 7
>7 8"
InsertMedicalRequestSP9 O
(O P)
ExactusMedicalRequestInsSpDtoP m
dton q
)q r
{ 	
try 
{ 
string 
sqlstore 
=  !
string" (
.( )
Format) /
(/ 0
$str0 P
,P Q
dtoR U
.U V
SchemaV \
)\ ]
;] ^
var   
queryParameters   #
=  $ %
new  & )
DynamicParameters  * ;
(  ; <
)  < =
;  = >
queryParameters!! 
.!!  
Add!!  #
(!!# $
$str!!$ 1
,!!1 2
dto!!3 6
.!!6 7

PSCONJUNTO!!7 A
)!!A B
;!!B C
queryParameters"" 
.""  
Add""  #
(""# $
$str""$ 0
,""0 1
dto""2 5
.""5 6
	PSUSUARIO""6 ?
)""? @
;""@ A
queryParameters## 
.##  
Add##  #
(### $
$str##$ 1
,##1 2
dto##3 6
.##6 7

PSEMPLEADO##7 A
)##A B
;##B C
queryParameters$$ 
.$$  
Add$$  #
($$# $
$str$$$ 3
,$$3 4
dto$$5 8
.$$8 9
PSTIPOACCION$$9 E
)$$E F
;$$F G
queryParameters%% 
.%%  
Add%%  #
(%%# $
$str%%$ /
,%%/ 0
dto%%1 4
.%%4 5
PDTFECHA%%5 =
)%%= >
;%%> ?
queryParameters&& 
.&&  
Add&&  #
(&&# $
$str&&$ 3
,&&3 4
dto&&5 8
.&&8 9
PDTFECHARIGE&&9 E
)&&E F
;&&F G
queryParameters'' 
.''  
Add''  #
(''# $
$str''$ 4
,''4 5
dto''6 9
.''9 :
PDTFECHAVENCE'': G
)''G H
;''H I
queryParameters(( 
.((  
Add((  #
(((# $
$str(($ 3
,((3 4
dto((5 8
.((8 9
PNDIASACCION((9 E
)((E F
;((F G
queryParameters)) 
.))  
Add))  #
())# $
$str))$ /
,))/ 0
dto))1 4
.))4 5
PSNOMINA))5 =
)))= >
;))> ?
queryParameters** 
.**  
Add**  #
(**# $
$str**$ /
,**/ 0
dto**1 4
.**4 5
PSPUESTO**5 =
)**= >
;**> ?
queryParameters++ 
.++  
Add++  #
(++# $
$str++$ .
,++. /
dto++0 3
.++3 4
PSPLAZA++4 ;
)++; <
;++< =
queryParameters,, 
.,,  
Add,,  #
(,,# $
$str,,$ 5
,,,5 6
dto,,7 :
.,,: ;
PSDEPARTAMENTO,,; I
),,I J
;,,J K
queryParameters-- 
.--  
Add--  #
(--# $
$str--$ 4
,--4 5
dto--6 9
.--9 :
PSCENTROCOSTO--: G
)--G H
;--H I
queryParameters.. 
...  
Add..  #
(..# $
$str..$ :
,..: ;
dto..< ?
...? @
PNSALARIOREFERENCIA..@ S
)..S T
;..T U
queryParameters// 
.//  
Add//  #
(//# $
$str//$ 5
,//5 6
dto//7 :
.//: ;
PSTIPOAUSENCIA//; I
)//I J
;//J K
queryParameters00 
.00  
Add00  #
(00# $
$str00$ 7
,007 8
dto009 <
.00< =
PSESTADOEMPLEADO00= M
)00M N
;00N O
queryParameters11 
.11  
Add11  #
(11# $
$str11$ /
,11/ 0
dto111 4
.114 5
PSRUBRO1115 =
)11= >
;11> ?
queryParameters22 
.22  
Add22  #
(22# $
$str22$ /
,22/ 0
dto221 4
.224 5
PSRUBRO2225 =
)22= >
;22> ?
queryParameters33 
.33  
Add33  #
(33# $
$str33$ /
,33/ 0
dto331 4
.334 5
PSRUBRO3335 =
)33= >
;33> ?
queryParameters44 
.44  
Add44  #
(44# $
$str44$ /
,44/ 0
dto441 4
.444 5
PSRUBRO4445 =
)44= >
;44> ?
queryParameters55 
.55  
Add55  #
(55# $
$str55$ /
,55/ 0
dto551 4
.554 5
PSRUBRO5555 =
)55= >
;55> ?
queryParameters66 
.66  
Add66  #
(66# $
$str66$ /
,66/ 0
dto661 4
.664 5
PSRUBRO6665 =
)66= >
;66> ?
queryParameters77 
.77  
Add77  #
(77# $
$str77$ /
,77/ 0
dto771 4
.774 5
PSRUBRO7775 =
)77= >
;77> ?
queryParameters88 
.88  
Add88  #
(88# $
$str88$ /
,88/ 0
dto881 4
.884 5
PSRUBRO8885 =
)88= >
;88> ?
queryParameters99 
.99  
Add99  #
(99# $
$str99$ /
,99/ 0
dto991 4
.994 5
PSRUBRO9995 =
)99= >
;99> ?
queryParameters:: 
.::  
Add::  #
(::# $
$str::$ 0
,::0 1
dto::2 5
.::5 6
	PSRUBRO10::6 ?
)::? @
;::@ A
queryParameters;; 
.;;  
Add;;  #
(;;# $
$str;;$ .
,;;. /
dto;;0 3
.;;3 4
PSNOTAS;;4 ;
);;; <
;;;< =
queryParameters<< 
.<<  
Add<<  #
(<<# $
$str<<$ 5
,<<5 6
DbType<<7 =
.<<= >
Int32<<> C
,<<C D
	direction<<E N
:<<N O
ParameterDirection<<P b
.<<b c
Output<<c i
)<<i j
;<<j k
queryParameters== 
.==  
Add==  #
(==# $
$str==$ 5
,==5 6
$str==6 >
,==> ?
DbType==? E
.==E F
String==F L
,==L M
	direction==N W
:==W X
ParameterDirection==Y k
.==k l
Output==l r
,==r s
$num==s v
)==v w
;==w x
_logger@@ 
.@@ 
LogInformation@@ &
(@@& '
$str@@' N
+@@O P
dto@@Q T
.@@T U
Schema@@U [
)@@[ \
;@@\ ]
_loggerAA 
.AA 
LogInformationAA &
(AA& '
$strAA' N
+AAO P
dtoAAQ T
.AAT U

PSCONJUNTOAAU _
)AA_ `
;AA` a
_loggerBB 
.BB 
LogInformationBB &
(BB& '
$strBB' N
+BBO P
dtoBBQ T
.BBT U
	PSUSUARIOBBU ^
)BB^ _
;BB_ `
_loggerCC 
.CC 
LogInformationCC &
(CC& '
$strCC' N
+CCO P
dtoCCQ T
.CCT U

PSEMPLEADOCCU _
)CC_ `
;CC` a
_loggerDD 
.DD 
LogInformationDD &
(DD& '
$strDD' N
+DDO P
dtoDDQ T
.DDT U
PSTIPOACCIONDDU a
)DDa b
;DDb c
_loggerEE 
.EE 
LogInformationEE &
(EE& '
$strEE' N
+EEO P
dtoEEQ T
.EET U
PDTFECHAEEU ]
)EE] ^
;EE^ _
_loggerFF 
.FF 
LogInformationFF &
(FF& '
$strFF' N
+FFO P
dtoFFQ T
.FFT U
PDTFECHARIGEFFU a
)FFa b
;FFb c
_loggerGG 
.GG 
LogInformationGG &
(GG& '
$strGG' N
+GGO P
dtoGGQ T
.GGT U
PDTFECHAVENCEGGU b
)GGb c
;GGc d
_loggerHH 
.HH 
LogInformationHH &
(HH& '
$strHH' N
+HHO P
dtoHHQ T
.HHT U
PNDIASACCIONHHU a
)HHa b
;HHb c
_loggerII 
.II 
LogInformationII &
(II& '
$strII' N
+IIO P
dtoIIQ T
.IIT U
PSNOMINAIIU ]
)II] ^
;II^ _
_loggerJJ 
.JJ 
LogInformationJJ &
(JJ& '
$strJJ' N
+JJO P
dtoJJQ T
.JJT U
PSPUESTOJJU ]
)JJ] ^
;JJ^ _
_loggerKK 
.KK 
LogInformationKK &
(KK& '
$strKK' N
+KKO P
dtoKKQ T
.KKT U
PSPLAZAKKU \
)KK\ ]
;KK] ^
_loggerLL 
.LL 
LogInformationLL &
(LL& '
$strLL' N
+LLO P
dtoLLQ T
.LLT U
PSDEPARTAMENTOLLU c
)LLc d
;LLd e
_loggerMM 
.MM 
LogInformationMM &
(MM& '
$strMM' N
+MMO P
dtoMMQ T
.MMT U
PSCENTROCOSTOMMU b
)MMb c
;MMc d
_loggerNN 
.NN 
LogInformationNN &
(NN& '
$strNN' N
+NNO P
dtoNNQ T
.NNT U
PNSALARIOREFERENCIANNU h
)NNh i
;NNi j
_loggerOO 
.OO 
LogInformationOO &
(OO& '
$strOO' N
+OOO P
dtoOOQ T
.OOT U
PSTIPOAUSENCIAOOU c
)OOc d
;OOd e
_loggerPP 
.PP 
LogInformationPP &
(PP& '
$strPP' N
+PPO P
dtoPPQ T
.PPT U
PSESTADOEMPLEADOPPU e
)PPe f
;PPf g
_loggerQQ 
.QQ 
LogInformationQQ &
(QQ& '
$strQQ' N
+QQO P
dtoQQQ T
.QQT U
PSRUBRO1QQU ]
)QQ] ^
;QQ^ _
_loggerRR 
.RR 
LogInformationRR &
(RR& '
$strRR' N
+RRO P
dtoRRQ T
.RRT U
PSRUBRO2RRU ]
)RR] ^
;RR^ _
_loggerSS 
.SS 
LogInformationSS &
(SS& '
$strSS' N
+SSO P
dtoSSQ T
.SST U
PSRUBRO3SSU ]
)SS] ^
;SS^ _
_loggerTT 
.TT 
LogInformationTT &
(TT& '
$strTT' N
+TTO P
dtoTTQ T
.TTT U
PSRUBRO4TTU ]
)TT] ^
;TT^ _
_loggerUU 
.UU 
LogInformationUU &
(UU& '
$strUU' N
+UUO P
dtoUUQ T
.UUT U
PSRUBRO5UUU ]
)UU] ^
;UU^ _
_loggerVV 
.VV 
LogInformationVV &
(VV& '
$strVV' N
+VVO P
dtoVVQ T
.VVT U
PSRUBRO6VVU ]
)VV] ^
;VV^ _
_loggerWW 
.WW 
LogInformationWW &
(WW& '
$strWW' N
+WWO P
dtoWWQ T
.WWT U
PSRUBRO7WWU ]
)WW] ^
;WW^ _
_loggerXX 
.XX 
LogInformationXX &
(XX& '
$strXX' N
+XXO P
dtoXXQ T
.XXT U
PSRUBRO8XXU ]
)XX] ^
;XX^ _
_loggerYY 
.YY 
LogInformationYY &
(YY& '
$strYY' N
+YYO P
dtoYYQ T
.YYT U
PSRUBRO9YYU ]
)YY] ^
;YY^ _
_loggerZZ 
.ZZ 
LogInformationZZ &
(ZZ& '
$strZZ' N
+ZZO P
dtoZZQ T
.ZZT U
	PSRUBRO10ZZU ^
)ZZ^ _
;ZZ_ `
_logger[[ 
.[[ 
LogInformation[[ &
([[& '
$str[[' N
+[[O P
dto[[Q T
.[[T U
PSNOTAS[[U \
)[[\ ]
;[[] ^
_logger]] 
.]] 
LogInformation]] &
(]]& '
$str]]' N
+]]O P
sqlstore]]Q Y
)]]Y Z
;]]Z [
var`` 
listUSer`` 
=`` 
await`` $#
exactusReadDbConnection``% <
.``< =

QueryAsync``= G
<``G H
object``H N
>``N O
(``O P
sqlstoreaa 
,aa 
queryParametersbb $
,bb$ %
commandTypebb& 1
:bb1 2
CommandTypebb3 >
.bb> ?
StoredProcedurebb? N
)bbN O
;bbO P
_loggerdd 
.dd 
LogInformationdd &
(dd& '
$strdd' R
)ddR S
;ddS T
dtoff 
.ff 
PSMENSAJEERRORff "
=ff# $
queryParametersff% 4
.ff4 5
Getff5 8
<ff8 9
stringff9 ?
>ff? @
(ff@ A
$strffA R
)ffR S
;ffS T
dtogg 
.gg 
PNNUMEROACCIONgg "
=gg# $
(gg% &
queryParametersgg& 5
.gg5 6
Getgg6 9
<gg9 :
intgg: =
?gg= >
>gg> ?
(gg? @
$strgg@ Q
)ggQ R
)ggR S
??ggS U
$numggU V
;ggV W
}hh 
catchii 
(ii 
	Exceptionii 
exii 
)ii  
{jj 
dtokk 
.kk 
PSMENSAJEERRORkk "
=kk# $
$strkk% T
;kkT U
_loggerll 
.ll 
LogErrorll  
(ll  !
$strll! K
+llL M
exllN P
.llP Q
MessagellQ X
)llX Y
;llY Z
_loggermm 
.mm 
LogErrormm  
(mm  !
$strmm! K
+mmL M
exmmN P
.mmP Q

StackTracemmQ [
)mm[ \
;mm\ ]
}nn 
returnrr 
dtorr 
;rr 
}ss 	
}tt 
}uu �:
vD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Repository\ExactusNominaCabRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '

Repository' 1
{ 
public 

class &
ExactusNominaCabRepository +
:, -'
IExactusNominaCabRepository. I
{ 
private 
readonly $
IExactusReadDbConnection 1#
exactusReadDbConnection2 I
;I J
private 
readonly 
ILogger  
<  !+
ExactusMedicalRequestRepository! @
>@ A
_loggerB I
;I J
public &
ExactusNominaCabRepository )
() *$
IExactusReadDbConnection* B#
exactusReadDbConnectionC Z
,Z [
ILogger\ c
<c d,
ExactusMedicalRequestRepository	d �
>
� �
_logger
� �
)
� �
{ 	
this 
. #
exactusReadDbConnection (
=) *#
exactusReadDbConnection+ B
;B C
this 
. 
_logger 
= 
_logger "
;" #
} 	
public 
async 
Task 
< 
List 
< 
ExactusNominaCab /
>/ 0
>0 1
GetAll2 8
(8 9%
ExactusNominaCabFilterDto9 R
	filterDtoS \
)\ ]
{ 	
try 
{ 
string 
	storename  
=! "
$"# %
$str% &
{& '
	filterDto' 0
.0 1
Scheme1 7
}7 8
$str8 L
"L M
;M N
var   
queryParameters   #
=  $ %
new  & )
DynamicParameters  * ;
(  ; <
)  < =
;  = >
_logger"" 
."" 
LogError""  
(""  !
$"""! #
$str""# M
{""M N
	storename""N W
}""W X
"""X Y
)""Y Z
;""Z [
var$$ 
list$$ 
=$$ 
await$$  #
exactusReadDbConnection$$! 8
.$$8 9

QueryAsync$$9 C
<$$C D
ExactusNominaCab$$D T
>$$T U
($$U V
	storename%% 
,%% 
queryParameters&& $
,&&$ %
commandType&&& 1
:&&1 2
CommandType&&3 >
.&&> ?
StoredProcedure&&? N
)&&N O
;&&O P
return)) 
list)) 
.)) 
ToList)) "
())" #
)))# $
;))$ %
}** 
catch++ 
(++ 
	Exception++ 
ex++ 
)++  
{,, 
_logger.. 
... 
LogError..  
(..  !
$str..! K
+..L M
ex..N P
...P Q
Message..Q X
)..X Y
;..Y Z
_logger// 
.// 
LogError//  
(//  !
$str//! K
+//L M
ex//N P
.//P Q

StackTrace//Q [
)//[ \
;//\ ]
}00 
return11 
new11 
List11 
<11 
ExactusNominaCab11 -
>11- .
(11. /
)11/ 0
;110 1
}22 	
public55 
async55 
Task55 
<55 
List55 
<55 !
ExactusLiquidacionCab55 4
>554 5
>555 6
GetLiquidacionCab557 H
(55H I
string55I O
sSchema55P W
)55W X
{66 	
try77 
{88 
string99 
	storename99  
=99! "
$"99# %
$str99% &
{99& '
sSchema99' .
}99. /
$str99/ I
"99I J
;99J K
var;; 
queryParameters;; #
=;;$ %
new;;& )
DynamicParameters;;* ;
(;;; <
);;< =
;;;= >
var>> 
list>> 
=>> 
await>>  #
exactusReadDbConnection>>! 8
.>>8 9

QueryAsync>>9 C
<>>C D!
ExactusLiquidacionCab>>D Y
>>>Y Z
(>>Z [
	storename?? 
,?? 
queryParameters@@ $
,@@$ %
commandType@@& 1
:@@1 2
CommandType@@3 >
.@@> ?
StoredProcedure@@? N
)@@N O
;@@O P
returnCC 
listCC 
.CC 
ToListCC "
(CC" #
)CC# $
;CC$ %
}EE 
catchFF 
(FF 
	ExceptionFF 
exFF 
)FF  
{GG 
_loggerII 
.II 
LogErrorII  
(II  !
$strII! K
+IIL M
exIIN P
.IIP Q
MessageIIQ X
)IIX Y
;IIY Z
_loggerJJ 
.JJ 
LogErrorJJ  
(JJ  !
$strJJ! K
+JJL M
exJJN P
.JJP Q

StackTraceJJQ [
)JJ[ \
;JJ\ ]
}KK 
returnLL 
newLL 
ListLL 
<LL !
ExactusLiquidacionCabLL 1
>LL1 2
(LL2 3
)LL3 4
;LL4 5
}MM 	
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
ListQQ 
<QQ !
ExactusLiquidacionDetQQ 4
>QQ4 5
>QQ5 6
GetLiquidacionDetQQ7 H
(QQH I
stringQQI O
sSchemaQQP W
,QQW X
intQQX [
nliquidationQQ\ h
)QQh i
{RR 	
trySS 
{TT 
stringUU 
	storenameUU  
=UU! "
$"UU# %
$strUU% &
{UU& '
sSchemaUU' .
}UU. /
$strUU/ N
"UUN O
;UUO P
varWW 
queryParametersWW #
=WW$ %
newWW& )
DynamicParametersWW* ;
(WW; <
)WW< =
;WW= >
queryParametersXX 
.XX  
AddXX  #
(XX# $
$strXX$ 4
,XX4 5
nliquidationXX6 B
)XXB C
;XXC D
varZZ 
listZZ 
=ZZ 
awaitZZ  #
exactusReadDbConnectionZZ! 8
.ZZ8 9

QueryAsyncZZ9 C
<ZZC D!
ExactusLiquidacionDetZZD Y
>ZZY Z
(ZZZ [
	storename[[ 
,[[ 
queryParameters\\ $
,\\$ %
commandType\\& 1
:\\1 2
CommandType\\3 >
.\\> ?
StoredProcedure\\? N
)\\N O
;\\O P
return]] 
list]] 
.]] 
ToList]] "
(]]" #
)]]# $
;]]$ %
}^^ 
catch__ 
(__ 
	Exception__ 
ex__ 
)__  
{`` 
_loggeraa 
.aa 
LogErroraa  
(aa  !
$straa! K
+aaL M
exaaN P
.aaP Q
MessageaaQ X
)aaX Y
;aaY Z
_loggerbb 
.bb 
LogErrorbb  
(bb  !
$strbb! K
+bbL M
exbbN P
.bbP Q

StackTracebbQ [
)bb[ \
;bb\ ]
}cc 
returndd 
newdd 
Listdd 
<dd !
ExactusLiquidacionDetdd 1
>dd1 2
(dd2 3
)dd3 4
;dd4 5
}ee 	
}ff 
}gg �
sD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Repository\ExactusNominaRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '

Repository' 1
{ 
public 

class #
ExactusNominaRepository (
:) *$
IExactusNominaRepository+ C
{ 
private 
readonly $
IExactusReadDbConnection 1#
exactusReadDbConnection2 I
;I J
private 
readonly 
ILogger  
<  !#
ExactusNominaRepository! 8
>8 9
_logger: A
;A B
public #
ExactusNominaRepository &
(& '$
IExactusReadDbConnection' ?#
exactusReadDbConnection@ W
,W X
ILoggerY `
<` a#
ExactusNominaRepositorya x
>x y
_logger	z �
)
� �
{ 	
this 
. #
exactusReadDbConnection (
=) *#
exactusReadDbConnection+ B
;B C
this 
. 
_logger 
= 
_logger "
;" #
} 	
public 
async 
Task 
< 
List 
< 
ExactusNomina ,
>, -
>- .
GetAll/ 5
(5 6"
ExactusNominaFilterDto6 L
	filterDtoM V
)V W
{ 	
try 
{ 
string 
	storename  
=! "
$"# %
$str% &
{& '
	filterDto' 0
.0 1
Scheme1 7
}7 8
$str8 L
"L M
;M N
var!! 
queryParameters!! #
=!!$ %
new!!& )
DynamicParameters!!* ;
(!!; <
)!!< =
;!!= >
queryParameters## 
.##  
Add##  #
(### $
$str##$ /
,##/ 0
	filterDto##1 :
.##: ;

NominaCode##; E
)##E F
;##F G
queryParameters$$ 
.$$  
Add$$  #
($$# $
$str$$$ 6
,$$6 7
	filterDto$$8 A
.$$A B
NominaNumber$$B N
)$$N O
;$$O P
var&& 
list&& 
=&& 
await&&  #
exactusReadDbConnection&&! 8
.&&8 9

QueryAsync&&9 C
<&&C D
ExactusNomina&&D Q
>&&Q R
(&&R S
	storename'' 
,'' 
queryParameters(( $
,(($ %
commandType((& 1
:((1 2
CommandType((3 >
.((> ?
StoredProcedure((? N
)((N O
;((O P
return++ 
list++ 
.++ 
ToList++ "
(++" #
)++# $
;++$ %
}-- 
catch.. 
(.. 
	Exception.. 
ex.. 
)..  
{// 
_logger00 
.00 
LogError00  
(00  !
$str00! K
+00L M
ex00N P
.00P Q
Message00Q X
)00X Y
;00Y Z
_logger11 
.11 
LogError11  
(11  !
$str11! K
+11L M
ex11N P
.11P Q

StackTrace11Q [
)11[ \
;11\ ]
}22 
return33 
new33 
List33 
<33 
ExactusNomina33 )
>33) *
(33* +
)33+ ,
;33, -
}44 	
}55 
}66 �
sD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.MsSqlExactus\Repository\ExactusPuestoRepository.cs
	namespace 	
HumanManagement
 
. 
MsSqlExactus &
.& '

Repository' 1
{ 
public 

class #
ExactusPuestoRepository (
:) *$
IExactusPuestoRepository+ C
{ 
private 
readonly $
IExactusReadDbConnection 1#
exactusReadDbConnection2 I
;I J
public #
ExactusPuestoRepository &
(& '$
IExactusReadDbConnection' ?#
exactusReadDbConnection@ W
)W X
{ 	
this 
. #
exactusReadDbConnection (
=) *#
exactusReadDbConnection+ B
;B C
} 	
public 
async 
Task 
< 
List 
< 
ExactusPuesto ,
>, -
>- .
GetAll/ 5
(5 6"
ExactusPuestoFilterDto6 L
	filterDtoM V
)V W
{ 	
string 
	storename 
= 
$" !
$str! "
{" #
	filterDto# ,
., -
Scheme- 3
}3 4
$str4 I
"I J
;J K
var 
queryParameters 
=  !
new" %
DynamicParameters& 7
(7 8
)8 9
;9 :
var 
list 
= 
await #
exactusReadDbConnection 4
.4 5

QueryAsync5 ?
<? @
ExactusPuesto@ M
>M N
(N O
	storename   
,   
queryParameters!!  
,!!  !
commandType!!" -
:!!- .
CommandType!!/ :
.!!: ;
StoredProcedure!!; J
)!!J K
;!!K L
return## 
list## 
.## 
ToList## 
(## 
)##  
;##  !
}$$ 	
}%% 
}&& 