Ω/
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
CommandType	u Ä
.
Ä Å
Text
Å Ö
,
Ö Ü
IDbTransaction
á ï
transaction
ñ °
=
¢ £
null
§ ®
,
® ©
CancellationToken
™ ª
cancellationToken
º Õ
=
Œ œ
default
– ◊
)
◊ ÿ
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
CancellationToken	} é
cancellationToken
è †
=
° ¢
default
£ ™
)
™ ´
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
CancellationToken	""u Ü
cancellationToken
""á ò
=
""ô ö
default
""õ ¢
)
""¢ £
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
IDbTransaction	''v Ñ
transaction
''Ö ê
=
''ë í
null
''ì ó
,
''ó ò
CancellationToken
''ô ™
cancellationToken
''´ º
=
''Ω æ
default
''ø ∆
)
''∆ «
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
IDbTransaction	,,u É
transaction
,,Ñ è
=
,,ê ë
null
,,í ñ
,
,,ñ ó
CancellationToken
,,ò ©
cancellationToken
,,™ ª
=
,,º Ω
default
,,æ ≈
)
,,≈ ∆
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
}66 ¶#
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
CancellationToken	p Å
cancellationToken
Ç ì
=
î ï
default
ñ ù
)
ù û
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
CancellationToken	~ è
cancellationToken
ê °
=
¢ £
default
§ ´
)
´ ¨
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
CancellationToken	  } é
cancellationToken
  è †
=
  ° ¢
default
  £ ™
)
  ™ ´
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
CancellationToken	$$u Ü
cancellationToken
$$á ò
=
$$ô ö
default
$$õ ¢
)
$$¢ £
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
})) ≤
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
} £
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
}pp ùN
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
}kk ﬂ
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
ExactusDepartamentoRepository	g Ñ
>
Ñ Ö
_logger
Ü ç
)
ç é
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
}00 ¢	
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
} „≥
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
_logger	~ Ö
,
Ö Ü
IConfiguration
á ï
configuration
ñ £
)
£ §
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
$str	Fâ &
;
ââ& '
query
ãã 
=
ãã 
query
ãã 
.
ãã 
Replace
ãã !
(
ãã! "
$str
ãã" ,
,
ãã, -
dto
ãã. 1
.
ãã1 2
Scheme
ãã2 8
)
ãã8 9
;
ãã9 :
var
çç 
result
çç 
=
çç 
await
çç %
exactusReadDbConnection
çç 6
.
çç6 7

QueryAsync
çç7 A
<
ççA B
int
ççB E
>
ççE F
(
ççF G
query
ççG L
,
ççL M
new
éé, /
{
èè, -
EMPLEADO
êê0 8
=
êê9 :
dto
êê; >
.
êê> ?
EMPLEADO
êê? G
,
êêG H
NOMBRE
ëë0 6
=
ëë7 8
dto
ëë9 <
.
ëë< =
NOMBRE
ëë= C
,
ëëC D
SEXO
íí0 4
=
íí5 6
dto
íí7 :
.
íí: ;
SEXO
íí; ?
,
íí? @
ESTADO_EMPLEADO
ìì0 ?
=
ìì@ A
dto
ììB E
.
ììE F
ESTADO_EMPLEADO
ììF U
,
ììU V
ACTIVO
îî0 6
=
îî7 8
dto
îî9 <
.
îî< =
ACTIVO
îî= C
,
îîC D
FECHA_INGRESO
ïï0 =
=
ïï> ?
dto
ïï@ C
.
ïïC D
FECHA_INGRESO
ïïD Q
,
ïïQ R
DEPARTAMENTO
ññ0 <
=
ññ= >
dto
ññ? B
.
ññB C
DEPARTAMENTO
ññC O
,
ññO P
PUESTO
óó0 6
=
óó7 8
dto
óó9 <
.
óó< =
PUESTO
óó= C
,
óóC D
PLAZA
òò0 5
=
òò6 7
dto
òò8 ;
.
òò; <
PLAZA
òò< A
,
òòA B
NOMINA
ôô0 6
=
ôô7 8
dto
ôô9 <
.
ôô< =
NOMINA
ôô= C
,
ôôC D
CENTRO_COSTO
öö0 <
=
öö= >
dto
öö? B
.
ööB C
CENTRO_COSTO
ööC O
,
ööO P
FECHA_NACIMIENTO
õõ0 @
=
õõA B
dto
õõC F
.
õõF G
FECHA_NACIMIENTO
õõG W
,
õõW X
	UBICACION
úú0 9
=
úú: ;
dto
úú< ?
.
úú? @
	UBICACION
úú@ I
,
úúI J
PAIS
ùù0 4
=
ùù5 6
dto
ùù7 :
.
ùù: ;
PAIS
ùù; ?
,
ùù? @
ESTADO_CIVIL
ûû0 <
=
ûû= >
dto
ûû? B
.
ûûB C
ESTADO_CIVIL
ûûC O
,
ûûO P
VACS_PENDIENTES
üü0 ?
=
üü@ A
dto
üüB E
.
üüE F
VACS_PENDIENTES
üüF U
,
üüU V
VACS_ULT_CALCULO
††0 @
=
††A B
dto
††C F
.
††F G
VACS_ULT_CALCULO
††G W
,
††W X 
SALARIO_REFERENCIA
°°0 B
=
°°C D
dto
°°E H
.
°°H I 
SALARIO_REFERENCIA
°°I [
,
°°[ \

FORMA_PAGO
¢¢0 :
=
¢¢; <
dto
¢¢= @
.
¢¢@ A

FORMA_PAGO
¢¢A K
,
¢¢K L
HORARIO
££0 7
=
££8 9
dto
££: =
.
££= >
HORARIO
££> E
,
££E F
FECHA_NO_PAGO
§§0 =
=
§§> ?
dto
§§@ C
.
§§C D
FECHA_NO_PAGO
§§D Q
,
§§Q R 
TIPO_SALARIO_AUMEN
••0 B
=
••C D
dto
••E H
.
••H I 
TIPO_SALARIO_AUMEN
••I [
,
••[ \
VACS_ADICIONALES
¶¶0 @
=
¶¶A B
dto
¶¶C F
.
¶¶F G
VACS_ADICIONALES
¶¶G W
,
¶¶W X
NoteExistsFlag
ßß0 >
=
ßß? @
dto
ßßA D
.
ßßD E
NoteExistsFlag
ßßE S
,
ßßS T

RecordDate
®®0 :
=
®®; <
dto
®®= @
.
®®@ A

RecordDate
®®A K
,
®®K L

RowPointer
©©0 :
=
©©; <
dto
©©= @
.
©©@ A

RowPointer
©©A K
,
©©K L
	CreatedBy
™™0 9
=
™™: ;
dto
™™< ?
.
™™? @
	CreatedBy
™™@ I
,
™™I J
	UpdatedBy
´´0 9
=
´´: ;
dto
´´< ?
.
´´? @
	UpdatedBy
´´@ I
,
´´I J

CreateDate
¨¨0 :
=
¨¨; <
dto
¨¨= @
.
¨¨@ A

CreateDate
¨¨A K
,
¨¨K L
DIRECCION_HAB
≠≠0 =
=
≠≠= >
dto
≠≠? B
.
≠≠B C
DIRECCION_HAB
≠≠C P
}
ÆÆ, -
)
ÆÆ- .
;
ÆÆ. /
return
∞∞ 
result
∞∞ 
.
∞∞ 
Count
∞∞ 
==
∞∞  "
$num
∞∞# $
;
∞∞$ %
}
≤≤ 	
public
∂∂ 
async
∂∂ 
Task
∂∂ 
<
∂∂ 
string
∂∂  
>
∂∂  !
InsertEmpleadoSP
∂∂" 2
(
∂∂2 3%
ExactusEmpleadoInsSpDto
∂∂3 J
dto
∂∂K N
)
∂∂N O
{
∑∑ 	
string
∏∏ 
sqlstore
∏∏ 
=
∏∏ 
string
∏∏ $
.
∏∏$ %
Format
∏∏% +
(
∏∏+ ,
$str
∏∏- F
,
∏∏F G
dto
∏∏G J
.
∏∏J K
Schema
∏∏K Q
)
∏∏Q R
;
∏∏R S
var
∫∫ 
queryParameters
∫∫ 
=
∫∫  !
new
∫∫" %
DynamicParameters
∫∫& 7
(
∫∫7 8
)
∫∫8 9
;
∫∫9 :
queryParameters
ªª 
.
ªª 
Add
ªª 
(
ªª  
$str
ªª  -
,
ªª- .
dto
ªª/ 2
.
ªª2 3

PSCONJUNTO
ªª3 =
)
ªª= >
;
ªª> ?
queryParameters
ºº 
.
ºº 
Add
ºº 
(
ºº  
$str
ºº  ,
,
ºº, -
dto
ºº. 1
.
ºº1 2
	PSUSUARIO
ºº2 ;
)
ºº; <
;
ºº< =
queryParameters
ΩΩ 
.
ΩΩ 
Add
ΩΩ 
(
ΩΩ  
$str
ΩΩ  -
,
ΩΩ- .
dto
ΩΩ/ 2
.
ΩΩ2 3

PSEMPLEADO
ΩΩ3 =
)
ΩΩ= >
;
ΩΩ> ?
queryParameters
ææ 
.
ææ 
Add
ææ 
(
ææ  
$str
ææ  +
,
ææ+ ,
dto
ææ- 0
.
ææ0 1
PSNOMBRE
ææ1 9
)
ææ9 :
;
ææ: ;
queryParameters
øø 
.
øø 
Add
øø 
(
øø  
$str
øø  3
,
øø3 4
dto
øø5 8
.
øø8 9
PSPRIMERAPELLIDO
øø9 I
)
øøI J
;
øøJ K
queryParameters
¿¿ 
.
¿¿ 
Add
¿¿ 
(
¿¿  
$str
¿¿  4
,
¿¿4 5
dto
¿¿6 9
.
¿¿9 :
PSSEGUNDOAPELLIDO
¿¿: K
)
¿¿K L
;
¿¿L M
queryParameters
¡¡ 
.
¡¡ 
Add
¡¡ 
(
¡¡  
$str
¡¡  /
,
¡¡/ 0
dto
¡¡1 4
.
¡¡4 5
PSNOMBREPILA
¡¡5 A
)
¡¡A B
;
¡¡B C
queryParameters
¬¬ 
.
¬¬ 
Add
¬¬ 
(
¬¬  
$str
¬¬  )
,
¬¬) *
dto
¬¬+ .
.
¬¬. /
PSSEXO
¬¬/ 5
)
¬¬5 6
;
¬¬6 7
queryParameters
√√ 
.
√√ 
Add
√√ 
(
√√  
$str
√√  /
,
√√/ 0
dto
√√1 4
.
√√4 5
PSTIPOSANGRE
√√5 A
)
√√A B
;
√√B C
queryParameters
ƒƒ 
.
ƒƒ 
Add
ƒƒ 
(
ƒƒ  
$str
ƒƒ  3
,
ƒƒ3 4
dto
ƒƒ5 8
.
ƒƒ8 9
PSIDENTIFICACION
ƒƒ9 I
)
ƒƒI J
;
ƒƒJ K
queryParameters
≈≈ 
.
≈≈ 
Add
≈≈ 
(
≈≈  
$str
≈≈  .
,
≈≈. /
dto
≈≈0 3
.
≈≈3 4
PSPASAPORTE
≈≈4 ?
)
≈≈? @
;
≈≈@ A
queryParameters
∆∆ 
.
∆∆ 
Add
∆∆ 
(
∆∆  
$str
∆∆  2
,
∆∆2 3
dto
∆∆4 7
.
∆∆7 8
PDTFECHAINGRESO
∆∆8 G
)
∆∆G H
;
∆∆H I
queryParameters
«« 
.
«« 
Add
«« 
(
««  
$str
««  1
,
««1 2
dto
««3 6
.
««6 7
PSDEPARTAMENTO
««7 E
)
««E F
;
««F G
queryParameters
»» 
.
»» 
Add
»» 
(
»»  
$str
»»  +
,
»»+ ,
dto
»»- 0
.
»»0 1
PSPUESTO
»»1 9
)
»»9 :
;
»»: ;
queryParameters
…… 
.
…… 
Add
…… 
(
……  
$str
……  *
,
……* +
dto
……, /
.
……/ 0
PSPLAZA
……0 7
)
……7 8
;
……8 9
queryParameters
   
.
   
Add
   
(
    
$str
    +
,
  + ,
dto
  - 0
.
  0 1
PSNOMINA
  1 9
)
  9 :
;
  : ;
queryParameters
ÀÀ 
.
ÀÀ 
Add
ÀÀ 
(
ÀÀ  
$str
ÀÀ  0
,
ÀÀ0 1
dto
ÀÀ2 5
.
ÀÀ5 6
PSCENTROCOSTO
ÀÀ6 C
)
ÀÀC D
;
ÀÀD E
queryParameters
ÃÃ 
.
ÃÃ 
Add
ÃÃ 
(
ÃÃ  
$str
ÃÃ  5
,
ÃÃ5 6
dto
ÃÃ7 :
.
ÃÃ: ; 
PDTFECHANACIMIENTO
ÃÃ; M
)
ÃÃM N
;
ÃÃN O
queryParameters
ÕÕ 
.
ÕÕ 
Add
ÕÕ 
(
ÕÕ  
$str
ÕÕ  .
,
ÕÕ. /
dto
ÕÕ0 3
.
ÕÕ3 4
PSUBICACION
ÕÕ4 ?
)
ÕÕ? @
;
ÕÕ@ A
queryParameters
ŒŒ 
.
ŒŒ 
Add
ŒŒ 
(
ŒŒ  
$str
ŒŒ  )
,
ŒŒ) *
dto
ŒŒ+ .
.
ŒŒ. /
PSPAIS
ŒŒ/ 5
)
ŒŒ5 6
;
ŒŒ6 7
queryParameters
œœ 
.
œœ 
Add
œœ 
(
œœ  
$str
œœ  0
,
œœ0 1
dto
œœ2 5
.
œœ5 6
PSESTADOCIVIL
œœ6 C
)
œœC D
;
œœD E
queryParameters
–– 
.
–– 
Add
–– 
(
––  
$str
––  1
,
––1 2
dto
––3 6
.
––6 7
PNDEPENDIENTES
––7 E
)
––E F
;
––F G
queryParameters
—— 
.
—— 
Add
—— 
(
——  
$str
——  .
,
——. /
dto
——0 3
.
——3 4
PSASEGURADO
——4 ?
)
——? @
;
——@ A
queryParameters
““ 
.
““ 
Add
““ 
(
““  
$str
““  0
,
““0 1
dto
““2 5
.
““5 6
PSCLASESEGURO
““6 C
)
““C D
;
““D E
queryParameters
”” 
.
”” 
Add
”” 
(
””  
$str
””  4
,
””4 5
dto
””6 9
.
””9 :
PSPERMISOCONDUCIR
””: K
)
””K L
;
””L M
queryParameters
‘‘ 
.
‘‘ 
Add
‘‘ 
(
‘‘  
$str
‘‘  1
,
‘‘1 2
dto
‘‘3 6
.
‘‘6 7
PSPERMISOSALUD
‘‘7 E
)
‘‘E F
;
‘‘F G
queryParameters
’’ 
.
’’ 
Add
’’ 
(
’’  
$str
’’  (
,
’’( )
dto
’’* -
.
’’- .
PSNIT
’’. 3
)
’’3 4
;
’’4 5
queryParameters
÷÷ 
.
÷÷ 
Add
÷÷ 
(
÷÷  
$str
÷÷  6
,
÷÷6 7
dto
÷÷8 ;
.
÷÷; <!
PNSALARIOREFERENCIA
÷÷< O
)
÷÷O P
;
÷÷P Q
queryParameters
◊◊ 
.
◊◊ 
Add
◊◊ 
(
◊◊  
$str
◊◊  2
,
◊◊2 3
dto
◊◊4 7
.
◊◊7 8
PSCUENTAENTIDAD
◊◊8 G
)
◊◊G H
;
◊◊H I
queryParameters
ÿÿ 
.
ÿÿ 
Add
ÿÿ 
(
ÿÿ  
$str
ÿÿ  .
,
ÿÿ. /
dto
ÿÿ0 3
.
ÿÿ3 4
PSFORMAPAGO
ÿÿ4 ?
)
ÿÿ? @
;
ÿÿ@ A
queryParameters
ŸŸ 
.
ŸŸ 
Add
ŸŸ 
(
ŸŸ  
$str
ŸŸ  6
,
ŸŸ6 7
dto
ŸŸ8 ;
.
ŸŸ; <!
PSENTIDADFINANCIERA
ŸŸ< O
)
ŸŸO P
;
ŸŸP Q
queryParameters
⁄⁄ 
.
⁄⁄ 
Add
⁄⁄ 
(
⁄⁄  
$str
⁄⁄  ,
,
⁄⁄, -
dto
⁄⁄. 1
.
⁄⁄1 2
	PSHORARIO
⁄⁄2 ;
)
⁄⁄; <
;
⁄⁄< =
queryParameters
€€ 
.
€€ 
Add
€€ 
(
€€  
$str
€€  .
,
€€. /
dto
€€0 3
.
€€3 4
PSTELEFONO1
€€4 ?
)
€€? @
;
€€@ A
queryParameters
‹‹ 
.
‹‹ 
Add
‹‹ 
(
‹‹  
$str
‹‹  .
,
‹‹. /
dto
‹‹0 3
.
‹‹3 4
PSNOTASTEL1
‹‹4 ?
)
‹‹? @
;
‹‹@ A
queryParameters
›› 
.
›› 
Add
›› 
(
››  
$str
››  .
,
››. /
dto
››0 3
.
››3 4
PSTELEFONO2
››4 ?
)
››? @
;
››@ A
queryParameters
ﬁﬁ 
.
ﬁﬁ 
Add
ﬁﬁ 
(
ﬁﬁ  
$str
ﬁﬁ  .
,
ﬁﬁ. /
dto
ﬁﬁ0 3
.
ﬁﬁ3 4
PSNOTASTEL2
ﬁﬁ4 ?
)
ﬁﬁ? @
;
ﬁﬁ@ A
queryParameters
ﬂﬂ 
.
ﬂﬂ 
Add
ﬂﬂ 
(
ﬂﬂ  
$str
ﬂﬂ  .
,
ﬂﬂ. /
dto
ﬂﬂ0 3
.
ﬂﬂ3 4
PSTELEFONO3
ﬂﬂ4 ?
)
ﬂﬂ? @
;
ﬂﬂ@ A
queryParameters
‡‡ 
.
‡‡ 
Add
‡‡ 
(
‡‡  
$str
‡‡  .
,
‡‡. /
dto
‡‡0 3
.
‡‡3 4
PSNOTASTEL3
‡‡4 ?
)
‡‡? @
;
‡‡@ A
queryParameters
·· 
.
·· 
Add
·· 
(
··  
$str
··  *
,
··* +
dto
··, /
.
··/ 0
PSEMAIL
··0 7
)
··7 8
;
··8 9
queryParameters
‚‚ 
.
‚‚ 
Add
‚‚ 
(
‚‚  
$str
‚‚  3
,
‚‚3 4
dto
‚‚5 8
.
‚‚8 9
PDTFECHAANTIGEMP
‚‚9 I
)
‚‚I J
;
‚‚J K
queryParameters
„„ 
.
„„ 
Add
„„ 
(
„„  
$str
„„  3
,
„„3 4
dto
„„5 8
.
„„8 9
PDTFECHAANTIGGOB
„„9 I
)
„„I J
;
„„J K
queryParameters
‰‰ 
.
‰‰ 
Add
‰‰ 
(
‰‰  
$str
‰‰  +
,
‰‰+ ,
dto
‰‰- 0
.
‰‰0 1
PSRUBRO1
‰‰1 9
)
‰‰9 :
;
‰‰: ;
queryParameters
ÂÂ 
.
ÂÂ 
Add
ÂÂ 
(
ÂÂ  
$str
ÂÂ  +
,
ÂÂ+ ,
dto
ÂÂ- 0
.
ÂÂ0 1
PSRUBRO2
ÂÂ1 9
)
ÂÂ9 :
;
ÂÂ: ;
queryParameters
ÊÊ 
.
ÊÊ 
Add
ÊÊ 
(
ÊÊ  
$str
ÊÊ  +
,
ÊÊ+ ,
dto
ÊÊ- 0
.
ÊÊ0 1
PSRUBRO3
ÊÊ1 9
)
ÊÊ9 :
;
ÊÊ: ;
queryParameters
ÁÁ 
.
ÁÁ 
Add
ÁÁ 
(
ÁÁ  
$str
ÁÁ  +
,
ÁÁ+ ,
dto
ÁÁ- 0
.
ÁÁ0 1
PSRUBRO4
ÁÁ1 9
)
ÁÁ9 :
;
ÁÁ: ;
queryParameters
ËË 
.
ËË 
Add
ËË 
(
ËË  
$str
ËË  +
,
ËË+ ,
dto
ËË- 0
.
ËË0 1
PSRUBRO5
ËË1 9
)
ËË9 :
;
ËË: ;
queryParameters
ÈÈ 
.
ÈÈ 
Add
ÈÈ 
(
ÈÈ  
$str
ÈÈ  +
,
ÈÈ+ ,
dto
ÈÈ- 0
.
ÈÈ0 1
PSRUBRO6
ÈÈ1 9
)
ÈÈ9 :
;
ÈÈ: ;
queryParameters
ÍÍ 
.
ÍÍ 
Add
ÍÍ 
(
ÍÍ  
$str
ÍÍ  +
,
ÍÍ+ ,
dto
ÍÍ- 0
.
ÍÍ0 1
PSRUBRO7
ÍÍ1 9
)
ÍÍ9 :
;
ÍÍ: ;
queryParameters
ÎÎ 
.
ÎÎ 
Add
ÎÎ 
(
ÎÎ  
$str
ÎÎ  +
,
ÎÎ+ ,
dto
ÎÎ- 0
.
ÎÎ0 1
PSRUBRO8
ÎÎ1 9
)
ÎÎ9 :
;
ÎÎ: ;
queryParameters
ÏÏ 
.
ÏÏ 
Add
ÏÏ 
(
ÏÏ  
$str
ÏÏ  +
,
ÏÏ+ ,
dto
ÏÏ- 0
.
ÏÏ0 1
PSRUBRO9
ÏÏ1 9
)
ÏÏ9 :
;
ÏÏ: ;
queryParameters
ÌÌ 
.
ÌÌ 
Add
ÌÌ 
(
ÌÌ  
$str
ÌÌ  ,
,
ÌÌ, -
dto
ÌÌ. 1
.
ÌÌ1 2
	PSRUBRO10
ÌÌ2 ;
)
ÌÌ; <
;
ÌÌ< =
queryParameters
ÓÓ 
.
ÓÓ 
Add
ÓÓ 
(
ÓÓ  
$str
ÓÓ  ,
,
ÓÓ, -
dto
ÓÓ. 1
.
ÓÓ1 2
	PSRUBRO11
ÓÓ2 ;
)
ÓÓ; <
;
ÓÓ< =
queryParameters
ÔÔ 
.
ÔÔ 
Add
ÔÔ 
(
ÔÔ  
$str
ÔÔ  ,
,
ÔÔ, -
dto
ÔÔ. 1
.
ÔÔ1 2
	PSRUBRO12
ÔÔ2 ;
)
ÔÔ; <
;
ÔÔ< =
queryParameters
 
.
 
Add
 
(
  
$str
  ,
,
, -
dto
. 1
.
1 2
	PSRUBRO13
2 ;
)
; <
;
< =
queryParameters
ÒÒ 
.
ÒÒ 
Add
ÒÒ 
(
ÒÒ  
$str
ÒÒ  ,
,
ÒÒ, -
dto
ÒÒ. 1
.
ÒÒ1 2
	PSRUBRO14
ÒÒ2 ;
)
ÒÒ; <
;
ÒÒ< =
queryParameters
ÚÚ 
.
ÚÚ 
Add
ÚÚ 
(
ÚÚ  
$str
ÚÚ  ,
,
ÚÚ, -
dto
ÚÚ. 1
.
ÚÚ1 2
	PSRUBRO15
ÚÚ2 ;
)
ÚÚ; <
;
ÚÚ< =
queryParameters
ÛÛ 
.
ÛÛ 
Add
ÛÛ 
(
ÛÛ  
$str
ÛÛ  ,
,
ÛÛ, -
dto
ÛÛ. 1
.
ÛÛ1 2
	PSRUBRO16
ÛÛ2 ;
)
ÛÛ; <
;
ÛÛ< =
queryParameters
ÙÙ 
.
ÙÙ 
Add
ÙÙ 
(
ÙÙ  
$str
ÙÙ  ,
,
ÙÙ, -
dto
ÙÙ. 1
.
ÙÙ1 2
	PSRUBRO17
ÙÙ2 ;
)
ÙÙ; <
;
ÙÙ< =
queryParameters
ıı 
.
ıı 
Add
ıı 
(
ıı  
$str
ıı  ,
,
ıı, -
dto
ıı. 1
.
ıı1 2
	PSRUBRO18
ıı2 ;
)
ıı; <
;
ıı< =
queryParameters
ˆˆ 
.
ˆˆ 
Add
ˆˆ 
(
ˆˆ  
$str
ˆˆ  ,
,
ˆˆ, -
dto
ˆˆ. 1
.
ˆˆ1 2
	PSRUBRO19
ˆˆ2 ;
)
ˆˆ; <
;
ˆˆ< =
queryParameters
˜˜ 
.
˜˜ 
Add
˜˜ 
(
˜˜  
$str
˜˜  ,
,
˜˜, -
dto
˜˜. 1
.
˜˜1 2
	PSRUBRO20
˜˜2 ;
)
˜˜; <
;
˜˜< =
queryParameters
¯¯ 
.
¯¯ 
Add
¯¯ 
(
¯¯  
$str
¯¯  ,
,
¯¯, -
dto
¯¯. 1
.
¯¯1 2
	PSRUBRO21
¯¯2 ;
)
¯¯; <
;
¯¯< =
queryParameters
˘˘ 
.
˘˘ 
Add
˘˘ 
(
˘˘  
$str
˘˘  ,
,
˘˘, -
dto
˘˘. 1
.
˘˘1 2
	PSRUBRO22
˘˘2 ;
)
˘˘; <
;
˘˘< =
queryParameters
˙˙ 
.
˙˙ 
Add
˙˙ 
(
˙˙  
$str
˙˙  ,
,
˙˙, -
dto
˙˙. 1
.
˙˙1 2
	PSRUBRO23
˙˙2 ;
)
˙˙; <
;
˙˙< =
queryParameters
˚˚ 
.
˚˚ 
Add
˚˚ 
(
˚˚  
$str
˚˚  ,
,
˚˚, -
dto
˚˚. 1
.
˚˚1 2
	PSRUBRO24
˚˚2 ;
)
˚˚; <
;
˚˚< =
queryParameters
¸¸ 
.
¸¸ 
Add
¸¸ 
(
¸¸  
$str
¸¸  ,
,
¸¸, -
dto
¸¸. 1
.
¸¸1 2
	PSRUBRO25
¸¸2 ;
)
¸¸; <
;
¸¸< =
queryParameters
˝˝ 
.
˝˝ 
Add
˝˝ 
(
˝˝  
$str
˝˝  *
,
˝˝* +
dto
˝˝, /
.
˝˝/ 0
PSNOTAS
˝˝0 7
)
˝˝7 8
;
˝˝8 9
queryParameters
˛˛ 
.
˛˛ 
Add
˛˛ 
(
˛˛  
$str
˛˛  4
,
˛˛4 5
dto
˛˛6 9
.
˛˛9 :
PNVACSADICIONALES
˛˛: K
)
˛˛K L
;
˛˛L M
queryParameters
ÄÄ 
.
ÄÄ 
Add
ÄÄ 
(
ÄÄ  
$str
ÄÄ  1
,
ÄÄ1 2
$str
ÄÄ3 ;
,
ÄÄ; <
DbType
ÄÄ= C
.
ÄÄC D
String
ÄÄD J
,
ÄÄJ K
	direction
ÄÄL U
:
ÄÄU V 
ParameterDirection
ÄÄW i
.
ÄÄi j
Output
ÄÄj p
,
ÄÄp q
$num
ÄÄr u
)
ÄÄu v
;
ÄÄv w
_logger
ÇÇ 
.
ÇÇ 
LogInformation
ÇÇ "
(
ÇÇ" #
$str
ÇÇ# 0
+
ÇÇ1 2
sqlstore
ÇÇ3 ;
)
ÇÇ; <
;
ÇÇ< =
_logger
ÑÑ 
.
ÑÑ 
LogInformation
ÑÑ "
(
ÑÑ" #
$str
ÑÑ# <
+
ÑÑ< =
dto
ÑÑ> A
.
ÑÑA B

PSCONJUNTO
ÑÑB L
)
ÑÑL M
;
ÑÑM N
_logger
ÖÖ 
.
ÖÖ 
LogInformation
ÖÖ "
(
ÖÖ" #
$str
ÖÖ# <
+
ÖÖ< =
dto
ÖÖ> A
.
ÖÖA B
	PSUSUARIO
ÖÖB K
)
ÖÖK L
;
ÖÖL M
_logger
ÜÜ 
.
ÜÜ 
LogInformation
ÜÜ "
(
ÜÜ" #
$str
ÜÜ# <
+
ÜÜ< =
dto
ÜÜ> A
.
ÜÜA B

PSEMPLEADO
ÜÜB L
)
ÜÜL M
;
ÜÜM N
_logger
áá 
.
áá 
LogInformation
áá "
(
áá" #
$str
áá# <
+
áá< =
dto
áá> A
.
ááA B
PSNOMBRE
ááB J
)
ááJ K
;
ááK L
_logger
àà 
.
àà 
LogInformation
àà "
(
àà" #
$str
àà# <
+
àà< =
dto
àà> A
.
ààA B
PSPRIMERAPELLIDO
ààB R
)
ààR S
;
ààS T
_logger
ââ 
.
ââ 
LogInformation
ââ "
(
ââ" #
$str
ââ# <
+
ââ< =
dto
ââ> A
.
ââA B
PSSEGUNDOAPELLIDO
ââB S
)
ââS T
;
ââT U
_logger
ää 
.
ää 
LogInformation
ää "
(
ää" #
$str
ää# <
+
ää< =
dto
ää> A
.
ääA B
PSNOMBREPILA
ääB N
)
ääN O
;
ääO P
_logger
ãã 
.
ãã 
LogInformation
ãã "
(
ãã" #
$str
ãã# <
+
ãã< =
dto
ãã> A
.
ããA B
PSSEXO
ããB H
)
ããH I
;
ããI J
_logger
åå 
.
åå 
LogInformation
åå "
(
åå" #
$str
åå# <
+
åå< =
dto
åå> A
.
ååA B
PSTIPOSANGRE
ååB N
)
ååN O
;
ååO P
_logger
çç 
.
çç 
LogInformation
çç "
(
çç" #
$str
çç# <
+
çç< =
dto
çç> A
.
ççA B
PSIDENTIFICACION
ççB R
)
ççR S
;
ççS T
_logger
éé 
.
éé 
LogInformation
éé "
(
éé" #
$str
éé# <
+
éé< =
dto
éé> A
.
ééA B
PSPASAPORTE
ééB M
)
ééM N
;
ééN O
_logger
èè 
.
èè 
LogInformation
èè "
(
èè" #
$str
èè# <
+
èè< =
dto
èè> A
.
èèA B
PDTFECHAINGRESO
èèB Q
)
èèQ R
;
èèR S
_logger
êê 
.
êê 
LogInformation
êê "
(
êê" #
$str
êê# <
+
êê< =
dto
êê> A
.
êêA B
PSDEPARTAMENTO
êêB P
)
êêP Q
;
êêQ R
_logger
ëë 
.
ëë 
LogInformation
ëë "
(
ëë" #
$str
ëë# <
+
ëë< =
dto
ëë> A
.
ëëA B
PSPUESTO
ëëB J
)
ëëJ K
;
ëëK L
_logger
íí 
.
íí 
LogInformation
íí "
(
íí" #
$str
íí# <
+
íí< =
dto
íí> A
.
ííA B
PSPLAZA
ííB I
)
ííI J
;
ííJ K
_logger
ìì 
.
ìì 
LogInformation
ìì "
(
ìì" #
$str
ìì# <
+
ìì< =
dto
ìì> A
.
ììA B
PSNOMINA
ììB J
)
ììJ K
;
ììK L
_logger
îî 
.
îî 
LogInformation
îî "
(
îî" #
$str
îî# <
+
îî< =
dto
îî> A
.
îîA B
PSCENTROCOSTO
îîB O
)
îîO P
;
îîP Q
_logger
ïï 
.
ïï 
LogInformation
ïï "
(
ïï" #
$str
ïï# <
+
ïï< =
dto
ïï> A
.
ïïA B 
PDTFECHANACIMIENTO
ïïB T
)
ïïT U
;
ïïU V
_logger
ññ 
.
ññ 
LogInformation
ññ "
(
ññ" #
$str
ññ# <
+
ññ< =
dto
ññ> A
.
ññA B
PSUBICACION
ññB M
)
ññM N
;
ññN O
_logger
óó 
.
óó 
LogInformation
óó "
(
óó" #
$str
óó# <
+
óó< =
dto
óó> A
.
óóA B
PSPAIS
óóB H
)
óóH I
;
óóI J
_logger
òò 
.
òò 
LogInformation
òò "
(
òò" #
$str
òò# <
+
òò< =
dto
òò> A
.
òòA B
PSESTADOCIVIL
òòB O
)
òòO P
;
òòP Q
_logger
ôô 
.
ôô 
LogInformation
ôô "
(
ôô" #
$str
ôô# <
+
ôô< =
dto
ôô> A
.
ôôA B
PNDEPENDIENTES
ôôB P
)
ôôP Q
;
ôôQ R
_logger
öö 
.
öö 
LogInformation
öö "
(
öö" #
$str
öö# <
+
öö< =
dto
öö> A
.
ööA B
PSASEGURADO
ööB M
)
ööM N
;
ööN O
_logger
õõ 
.
õõ 
LogInformation
õõ "
(
õõ" #
$str
õõ# <
+
õõ< =
dto
õõ> A
.
õõA B
PSCLASESEGURO
õõB O
)
õõO P
;
õõP Q
_logger
úú 
.
úú 
LogInformation
úú "
(
úú" #
$str
úú# <
+
úú< =
dto
úú> A
.
úúA B
PSPERMISOCONDUCIR
úúB S
)
úúS T
;
úúT U
_logger
ùù 
.
ùù 
LogInformation
ùù "
(
ùù" #
$str
ùù# <
+
ùù< =
dto
ùù> A
.
ùùA B
PSPERMISOSALUD
ùùB P
)
ùùP Q
;
ùùQ R
_logger
ûû 
.
ûû 
LogInformation
ûû "
(
ûû" #
$str
ûû# <
+
ûû< =
dto
ûû> A
.
ûûA B
PSNIT
ûûB G
)
ûûG H
;
ûûH I
_logger
üü 
.
üü 
LogInformation
üü "
(
üü" #
$str
üü# <
+
üü< =
dto
üü> A
.
üüA B!
PNSALARIOREFERENCIA
üüB U
)
üüU V
;
üüV W
_logger
†† 
.
†† 
LogInformation
†† "
(
††" #
$str
††# <
+
††< =
dto
††> A
.
††A B
PSCUENTAENTIDAD
††B Q
)
††Q R
;
††R S
_logger
°° 
.
°° 
LogInformation
°° "
(
°°" #
$str
°°# <
+
°°< =
dto
°°> A
.
°°A B
PSFORMAPAGO
°°B M
)
°°M N
;
°°N O
_logger
¢¢ 
.
¢¢ 
LogInformation
¢¢ "
(
¢¢" #
$str
¢¢# <
+
¢¢< =
dto
¢¢> A
.
¢¢A B!
PSENTIDADFINANCIERA
¢¢B U
)
¢¢U V
;
¢¢V W
_logger
££ 
.
££ 
LogInformation
££ "
(
££" #
$str
££# <
+
££< =
dto
££> A
.
££A B
	PSHORARIO
££B K
)
££K L
;
££L M
_logger
§§ 
.
§§ 
LogInformation
§§ "
(
§§" #
$str
§§# <
+
§§< =
dto
§§> A
.
§§A B
PSTELEFONO1
§§B M
)
§§M N
;
§§N O
_logger
•• 
.
•• 
LogInformation
•• "
(
••" #
$str
••# <
+
••< =
dto
••> A
.
••A B
PSNOTASTEL1
••B M
)
••M N
;
••N O
_logger
¶¶ 
.
¶¶ 
LogInformation
¶¶ "
(
¶¶" #
$str
¶¶# <
+
¶¶< =
dto
¶¶> A
.
¶¶A B
PSTELEFONO2
¶¶B M
)
¶¶M N
;
¶¶N O
_logger
ßß 
.
ßß 
LogInformation
ßß "
(
ßß" #
$str
ßß# <
+
ßß< =
dto
ßß> A
.
ßßA B
PSNOTASTEL2
ßßB M
)
ßßM N
;
ßßN O
_logger
®® 
.
®® 
LogInformation
®® "
(
®®" #
$str
®®# <
+
®®< =
dto
®®> A
.
®®A B
PSTELEFONO3
®®B M
)
®®M N
;
®®N O
_logger
©© 
.
©© 
LogInformation
©© "
(
©©" #
$str
©©# <
+
©©< =
dto
©©> A
.
©©A B
PSNOTASTEL3
©©B M
)
©©M N
;
©©N O
_logger
™™ 
.
™™ 
LogInformation
™™ "
(
™™" #
$str
™™# <
+
™™< =
dto
™™> A
.
™™A B
PSEMAIL
™™B I
)
™™I J
;
™™J K
_logger
´´ 
.
´´ 
LogInformation
´´ "
(
´´" #
$str
´´# <
+
´´< =
dto
´´> A
.
´´A B
PDTFECHAANTIGEMP
´´B R
)
´´R S
;
´´S T
_logger
¨¨ 
.
¨¨ 
LogInformation
¨¨ "
(
¨¨" #
$str
¨¨# <
+
¨¨< =
dto
¨¨> A
.
¨¨A B
PDTFECHAANTIGGOB
¨¨B R
)
¨¨R S
;
¨¨S T
_logger
≠≠ 
.
≠≠ 
LogInformation
≠≠ "
(
≠≠" #
$str
≠≠# <
+
≠≠< =
dto
≠≠> A
.
≠≠A B
PSRUBRO1
≠≠B J
)
≠≠J K
;
≠≠K L
_logger
ÆÆ 
.
ÆÆ 
LogInformation
ÆÆ "
(
ÆÆ" #
$str
ÆÆ# <
+
ÆÆ< =
dto
ÆÆ> A
.
ÆÆA B
PSRUBRO2
ÆÆB J
)
ÆÆJ K
;
ÆÆK L
_logger
ØØ 
.
ØØ 
LogInformation
ØØ "
(
ØØ" #
$str
ØØ# <
+
ØØ< =
dto
ØØ> A
.
ØØA B
PSRUBRO3
ØØB J
)
ØØJ K
;
ØØK L
_logger
∞∞ 
.
∞∞ 
LogInformation
∞∞ "
(
∞∞" #
$str
∞∞# <
+
∞∞< =
dto
∞∞> A
.
∞∞A B
PSRUBRO4
∞∞B J
)
∞∞J K
;
∞∞K L
_logger
±± 
.
±± 
LogInformation
±± "
(
±±" #
$str
±±# <
+
±±< =
dto
±±> A
.
±±A B
PSRUBRO5
±±B J
)
±±J K
;
±±K L
_logger
≤≤ 
.
≤≤ 
LogInformation
≤≤ "
(
≤≤" #
$str
≤≤# <
+
≤≤< =
dto
≤≤> A
.
≤≤A B
PSRUBRO6
≤≤B J
)
≤≤J K
;
≤≤K L
_logger
≥≥ 
.
≥≥ 
LogInformation
≥≥ "
(
≥≥" #
$str
≥≥# <
+
≥≥< =
dto
≥≥> A
.
≥≥A B
PSRUBRO7
≥≥B J
)
≥≥J K
;
≥≥K L
_logger
¥¥ 
.
¥¥ 
LogInformation
¥¥ "
(
¥¥" #
$str
¥¥# <
+
¥¥< =
dto
¥¥> A
.
¥¥A B
PSRUBRO8
¥¥B J
)
¥¥J K
;
¥¥K L
_logger
µµ 
.
µµ 
LogInformation
µµ "
(
µµ" #
$str
µµ# <
+
µµ< =
dto
µµ> A
.
µµA B
PSRUBRO9
µµB J
)
µµJ K
;
µµK L
_logger
∂∂ 
.
∂∂ 
LogInformation
∂∂ "
(
∂∂" #
$str
∂∂# <
+
∂∂< =
dto
∂∂> A
.
∂∂A B
	PSRUBRO10
∂∂B K
)
∂∂K L
;
∂∂L M
_logger
∑∑ 
.
∑∑ 
LogInformation
∑∑ "
(
∑∑" #
$str
∑∑# <
+
∑∑< =
dto
∑∑> A
.
∑∑A B
	PSRUBRO11
∑∑B K
)
∑∑K L
;
∑∑L M
_logger
∏∏ 
.
∏∏ 
LogInformation
∏∏ "
(
∏∏" #
$str
∏∏# <
+
∏∏< =
dto
∏∏> A
.
∏∏A B
	PSRUBRO12
∏∏B K
)
∏∏K L
;
∏∏L M
_logger
ππ 
.
ππ 
LogInformation
ππ "
(
ππ" #
$str
ππ# <
+
ππ< =
dto
ππ> A
.
ππA B
	PSRUBRO13
ππB K
)
ππK L
;
ππL M
_logger
∫∫ 
.
∫∫ 
LogInformation
∫∫ "
(
∫∫" #
$str
∫∫# <
+
∫∫< =
dto
∫∫> A
.
∫∫A B
	PSRUBRO14
∫∫B K
)
∫∫K L
;
∫∫L M
_logger
ªª 
.
ªª 
LogInformation
ªª "
(
ªª" #
$str
ªª# <
+
ªª< =
dto
ªª> A
.
ªªA B
	PSRUBRO15
ªªB K
)
ªªK L
;
ªªL M
_logger
ºº 
.
ºº 
LogInformation
ºº "
(
ºº" #
$str
ºº# <
+
ºº< =
dto
ºº> A
.
ººA B
	PSRUBRO16
ººB K
)
ººK L
;
ººL M
_logger
ΩΩ 
.
ΩΩ 
LogInformation
ΩΩ "
(
ΩΩ" #
$str
ΩΩ# <
+
ΩΩ< =
dto
ΩΩ> A
.
ΩΩA B
	PSRUBRO17
ΩΩB K
)
ΩΩK L
;
ΩΩL M
_logger
ææ 
.
ææ 
LogInformation
ææ "
(
ææ" #
$str
ææ# <
+
ææ< =
dto
ææ> A
.
ææA B
	PSRUBRO18
ææB K
)
ææK L
;
ææL M
_logger
øø 
.
øø 
LogInformation
øø "
(
øø" #
$str
øø# <
+
øø< =
dto
øø> A
.
øøA B
	PSRUBRO19
øøB K
)
øøK L
;
øøL M
_logger
¿¿ 
.
¿¿ 
LogInformation
¿¿ "
(
¿¿" #
$str
¿¿# <
+
¿¿< =
dto
¿¿> A
.
¿¿A B
	PSRUBRO20
¿¿B K
)
¿¿K L
;
¿¿L M
_logger
¡¡ 
.
¡¡ 
LogInformation
¡¡ "
(
¡¡" #
$str
¡¡# <
+
¡¡< =
dto
¡¡> A
.
¡¡A B
	PSRUBRO21
¡¡B K
)
¡¡K L
;
¡¡L M
_logger
¬¬ 
.
¬¬ 
LogInformation
¬¬ "
(
¬¬" #
$str
¬¬# <
+
¬¬< =
dto
¬¬> A
.
¬¬A B
	PSRUBRO22
¬¬B K
)
¬¬K L
;
¬¬L M
_logger
√√ 
.
√√ 
LogInformation
√√ "
(
√√" #
$str
√√# <
+
√√< =
dto
√√> A
.
√√A B
	PSRUBRO23
√√B K
)
√√K L
;
√√L M
_logger
ƒƒ 
.
ƒƒ 
LogInformation
ƒƒ "
(
ƒƒ" #
$str
ƒƒ# <
+
ƒƒ< =
dto
ƒƒ> A
.
ƒƒA B
	PSRUBRO24
ƒƒB K
)
ƒƒK L
;
ƒƒL M
_logger
≈≈ 
.
≈≈ 
LogInformation
≈≈ "
(
≈≈" #
$str
≈≈# <
+
≈≈< =
dto
≈≈> A
.
≈≈A B
	PSRUBRO25
≈≈B K
)
≈≈K L
;
≈≈L M
_logger
∆∆ 
.
∆∆ 
LogInformation
∆∆ "
(
∆∆" #
$str
∆∆# <
+
∆∆< =
dto
∆∆> A
.
∆∆A B
PSNOTAS
∆∆B I
)
∆∆I J
;
∆∆J K
_logger
«« 
.
«« 
LogInformation
«« "
(
««" #
$str
««# <
+
««< =
dto
««> A
.
««A B
PNVACSADICIONALES
««B S
)
««S T
;
««T U
var
ÀÀ 
listUSer
ÀÀ 
=
ÀÀ 
await
ÀÀ  %
exactusReadDbConnection
ÀÀ! 8
.
ÀÀ8 9

QueryAsync
ÀÀ9 C
<
ÀÀC D
object
ÀÀD J
>
ÀÀJ K
(
ÀÀK L
sqlstore
ÃÃ 
,
ÃÃ 
queryParameters
ÕÕ  
,
ÕÕ  !
commandType
ÕÕ" -
:
ÕÕ- .
CommandType
ÕÕ/ :
.
ÕÕ: ;
StoredProcedure
ÕÕ; J
)
ÕÕJ K
;
ÕÕK L
string
œœ 
MENSAJEERROR
œœ 
=
œœ  !
queryParameters
œœ" 1
.
œœ1 2
Get
œœ2 5
<
œœ5 6
string
œœ6 <
>
œœ< =
(
œœ= >
$str
œœ> O
)
œœO P
;
œœP Q
_logger
–– 
.
–– 
LogInformation
–– "
(
––" #
$str
––# 9
+
––: ;
MENSAJEERROR
––< H
)
––H I
;
––I J
return
““ 
MENSAJEERROR
““ 
;
““  
}
”” 	
public
’’ 
async
’’ 
Task
’’ 
<
’’ 
string
’’  
>
’’  !
InsertDireccionSP
’’" 3
(
’’3 4(
ExactusEmpleadoInsSpDirDto
’’4 N
dto
’’O R
)
’’R S
{
÷÷ 	
string
◊◊ 
sqlstore
◊◊ 
=
◊◊ 
string
◊◊ $
.
◊◊$ %
Format
◊◊% +
(
◊◊+ ,
$str
◊◊, J
,
◊◊J K
dto
◊◊L O
.
◊◊O P
Schema
◊◊P V
)
◊◊V W
;
◊◊W X
var
ŸŸ 
queryParameters
ŸŸ 
=
ŸŸ  !
new
ŸŸ" %
DynamicParameters
ŸŸ& 7
(
ŸŸ7 8
)
ŸŸ8 9
;
ŸŸ9 :
queryParameters
€€ 
.
€€ 
Add
€€ 
(
€€  
$str
€€  -
,
€€- .
dto
€€/ 2
.
€€2 3

PSCONJUNTO
€€3 =
)
€€= >
;
€€> ?
queryParameters
‹‹ 
.
‹‹ 
Add
‹‹ 
(
‹‹  
$str
‹‹  ,
,
‹‹, -
dto
‹‹. 1
.
‹‹1 2
	PSUSUARIO
‹‹2 ;
)
‹‹; <
;
‹‹< =
queryParameters
›› 
.
›› 
Add
›› 
(
››  
$str
››  -
,
››- .
dto
››/ 2
.
››2 3

PSEMPLEADO
››3 =
)
››= >
;
››> ?
queryParameters
ﬁﬁ 
.
ﬁﬁ 
Add
ﬁﬁ 
(
ﬁﬁ  
$str
ﬁﬁ  2
,
ﬁﬁ2 3
dto
ﬁﬁ4 7
.
ﬁﬁ7 8
PSTIPODIRECCION
ﬁﬁ8 G
)
ﬁﬁG H
;
ﬁﬁH I
queryParameters
ﬂﬂ 
.
ﬂﬂ 
Add
ﬂﬂ 
(
ﬂﬂ  
$str
ﬂﬂ  .
,
ﬂﬂ. /
dto
ﬂﬂ0 3
.
ﬂﬂ3 4
PSDIRECCION
ﬂﬂ4 ?
)
ﬂﬂ? @
;
ﬂﬂ@ A
queryParameters
‡‡ 
.
‡‡ 
Add
‡‡ 
(
‡‡  
$str
‡‡  +
,
‡‡+ ,
dto
‡‡, /
.
‡‡/ 0
PSCAMPO1
‡‡0 8
)
‡‡8 9
;
‡‡9 :
queryParameters
·· 
.
·· 
Add
·· 
(
··  
$str
··  +
,
··+ ,
dto
··, /
.
··/ 0
PSCAMPO2
··0 8
)
··8 9
;
··9 :
queryParameters
‚‚ 
.
‚‚ 
Add
‚‚ 
(
‚‚  
$str
‚‚  +
,
‚‚+ ,
dto
‚‚, /
.
‚‚/ 0
PSCAMPO3
‚‚0 8
)
‚‚8 9
;
‚‚9 :
queryParameters
„„ 
.
„„ 
Add
„„ 
(
„„  
$str
„„  +
,
„„+ ,
dto
„„, /
.
„„/ 0
PSCAMPO4
„„0 8
)
„„8 9
;
„„9 :
queryParameters
‰‰ 
.
‰‰ 
Add
‰‰ 
(
‰‰  
$str
‰‰  +
,
‰‰+ ,
dto
‰‰, /
.
‰‰/ 0
PSCAMPO5
‰‰0 8
)
‰‰8 9
;
‰‰9 :
queryParameters
ÂÂ 
.
ÂÂ 
Add
ÂÂ 
(
ÂÂ  
$str
ÂÂ  +
,
ÂÂ+ ,
dto
ÂÂ, /
.
ÂÂ/ 0
PSCAMPO6
ÂÂ0 8
)
ÂÂ8 9
;
ÂÂ9 :
queryParameters
ÊÊ 
.
ÊÊ 
Add
ÊÊ 
(
ÊÊ  
$str
ÊÊ  +
,
ÊÊ+ ,
dto
ÊÊ, /
.
ÊÊ/ 0
PSCAMPO7
ÊÊ0 8
)
ÊÊ8 9
;
ÊÊ9 :
queryParameters
ÁÁ 
.
ÁÁ 
Add
ÁÁ 
(
ÁÁ  
$str
ÁÁ  +
,
ÁÁ+ ,
dto
ÁÁ, /
.
ÁÁ/ 0
PSCAMPO8
ÁÁ0 8
)
ÁÁ8 9
;
ÁÁ9 :
queryParameters
ËË 
.
ËË 
Add
ËË 
(
ËË  
$str
ËË  +
,
ËË+ ,
dto
ËË- 0
.
ËË0 1
PSCAMPO9
ËË1 9
)
ËË9 :
;
ËË: ;
queryParameters
ÈÈ 
.
ÈÈ 
Add
ÈÈ 
(
ÈÈ  
$str
ÈÈ  ,
,
ÈÈ, -
dto
ÈÈ. 1
.
ÈÈ1 2
	PSCAMPO10
ÈÈ2 ;
)
ÈÈ; <
;
ÈÈ< =
_logger
ÏÏ 
.
ÏÏ 
LogInformation
ÏÏ "
(
ÏÏ" #
$str
ÏÏ# 0
+
ÏÏ1 2
sqlstore
ÏÏ3 ;
)
ÏÏ; <
;
ÏÏ< =
_logger
ÌÌ 
.
ÌÌ 
LogInformation
ÌÌ "
(
ÌÌ" #
$str
ÌÌ# 9
+
ÌÌ9 :
dto
ÌÌ< ?
.
ÌÌ? @

PSCONJUNTO
ÌÌ@ J
)
ÌÌJ K
;
ÌÌK L
_logger
ÓÓ 
.
ÓÓ 
LogInformation
ÓÓ "
(
ÓÓ" #
$str
ÓÓ# 9
+
ÓÓ9 :
dto
ÓÓ< ?
.
ÓÓ? @
	PSUSUARIO
ÓÓ@ I
)
ÓÓI J
;
ÓÓJ K
_logger
ÔÔ 
.
ÔÔ 
LogInformation
ÔÔ "
(
ÔÔ" #
$str
ÔÔ# 9
+
ÔÔ9 :
dto
ÔÔ< ?
.
ÔÔ? @

PSEMPLEADO
ÔÔ@ J
)
ÔÔJ K
;
ÔÔK L
_logger
 
.
 
LogInformation
 "
(
" #
$str
# 9
+
9 :
dto
< ?
.
? @
PSTIPODIRECCION
@ O
)
O P
;
P Q
_logger
ÒÒ 
.
ÒÒ 
LogInformation
ÒÒ "
(
ÒÒ" #
$str
ÒÒ# 9
+
ÒÒ9 :
dto
ÒÒ< ?
.
ÒÒ? @
PSDIRECCION
ÒÒ@ K
)
ÒÒK L
;
ÒÒL M
_logger
ÚÚ 
.
ÚÚ 
LogInformation
ÚÚ "
(
ÚÚ" #
$str
ÚÚ# 9
+
ÚÚ9 :
dto
ÚÚ< ?
.
ÚÚ? @
PSCAMPO1
ÚÚ@ H
)
ÚÚH I
;
ÚÚI J
_logger
ÛÛ 
.
ÛÛ 
LogInformation
ÛÛ "
(
ÛÛ" #
$str
ÛÛ# 9
+
ÛÛ9 :
dto
ÛÛ< ?
.
ÛÛ? @
PSCAMPO2
ÛÛ@ H
)
ÛÛH I
;
ÛÛI J
_logger
ÙÙ 
.
ÙÙ 
LogInformation
ÙÙ "
(
ÙÙ" #
$str
ÙÙ# 9
+
ÙÙ9 :
dto
ÙÙ< ?
.
ÙÙ? @
PSCAMPO3
ÙÙ@ H
)
ÙÙH I
;
ÙÙI J
_logger
ıı 
.
ıı 
LogInformation
ıı "
(
ıı" #
$str
ıı# 9
+
ıı9 :
dto
ıı< ?
.
ıı? @
PSCAMPO4
ıı@ H
)
ııH I
;
ııI J
_logger
ˆˆ 
.
ˆˆ 
LogInformation
ˆˆ "
(
ˆˆ" #
$str
ˆˆ# 9
+
ˆˆ9 :
dto
ˆˆ< ?
.
ˆˆ? @
PSCAMPO5
ˆˆ@ H
)
ˆˆH I
;
ˆˆI J
_logger
˜˜ 
.
˜˜ 
LogInformation
˜˜ "
(
˜˜" #
$str
˜˜# 9
+
˜˜9 :
dto
˜˜< ?
.
˜˜? @
PSCAMPO6
˜˜@ H
)
˜˜H I
;
˜˜I J
_logger
¯¯ 
.
¯¯ 
LogInformation
¯¯ "
(
¯¯" #
$str
¯¯# 9
+
¯¯9 :
dto
¯¯< ?
.
¯¯? @
PSCAMPO7
¯¯@ H
)
¯¯H I
;
¯¯I J
_logger
˘˘ 
.
˘˘ 
LogInformation
˘˘ "
(
˘˘" #
$str
˘˘# 9
+
˘˘9 :
dto
˘˘< ?
.
˘˘? @
PSCAMPO8
˘˘@ H
)
˘˘H I
;
˘˘I J
_logger
˙˙ 
.
˙˙ 
LogInformation
˙˙ "
(
˙˙" #
$str
˙˙# 9
+
˙˙9 :
dto
˙˙< ?
.
˙˙? @
PSCAMPO9
˙˙@ H
)
˙˙H I
;
˙˙I J
_logger
˚˚ 
.
˚˚ 
LogInformation
˚˚ "
(
˚˚" #
$str
˚˚# 9
+
˚˚9 :
dto
˚˚< ?
.
˚˚? @
	PSCAMPO10
˚˚@ I
)
˚˚I J
;
˚˚J K
queryParameters
ÄÄ 
.
ÄÄ 
Add
ÄÄ 
(
ÄÄ  
$str
ÄÄ  1
,
ÄÄ1 2
$str
ÄÄ3 ;
,
ÄÄ; <
DbType
ÄÄ= C
.
ÄÄC D
String
ÄÄD J
,
ÄÄJ K
	direction
ÄÄL U
:
ÄÄU V 
ParameterDirection
ÄÄW i
.
ÄÄi j
Output
ÄÄj p
,
ÄÄp q
$num
ÄÄr u
)
ÄÄu v
;
ÄÄv w
var
ÇÇ 
listUSer
ÇÇ 
=
ÇÇ 
await
ÇÇ  %
exactusReadDbConnection
ÇÇ! 8
.
ÇÇ8 9

QueryAsync
ÇÇ9 C
<
ÇÇC D
object
ÇÇD J
>
ÇÇJ K
(
ÇÇK L
sqlstore
ÉÉ 
,
ÉÉ 
queryParameters
ÑÑ  
,
ÑÑ  !
commandType
ÑÑ" -
:
ÑÑ- .
CommandType
ÑÑ/ :
.
ÑÑ: ;
StoredProcedure
ÑÑ; J
)
ÑÑJ K
;
ÑÑK L
string
ÜÜ 
MENSAJEERROR
ÜÜ 
=
ÜÜ  !
queryParameters
ÜÜ" 1
.
ÜÜ1 2
Get
ÜÜ2 5
<
ÜÜ5 6
string
ÜÜ6 <
>
ÜÜ< =
(
ÜÜ= >
$str
ÜÜ> O
)
ÜÜO P
;
ÜÜP Q
_logger
áá 
.
áá 
LogInformation
áá "
(
áá" #
$str
áá# 9
+
áá: ;
MENSAJEERROR
áá< H
)
ááH I
;
ááI J
return
ää 
MENSAJEERROR
ää 
;
ää  
}
ãã 	
public
éé 
async
éé 
Task
éé 
<
éé 
List
éé 
<
éé %
ExactusEmpleadoTablaDto
éé 6
>
éé6 7
>
éé7 8
GetEmpleadoTabla
éé9 I
(
ééI J+
ExactusEmpleadoTablaFilterDto
ééJ g
	filterDto
ééh q
)
ééq r
{
èè 	
try
êê 
{
ëë 
string
ìì 
	storename
ìì  
=
ìì! "
$"
ìì# %
$str
ìì% &
{
ìì& '
	filterDto
ìì' 0
.
ìì0 1
Scheme
ìì1 7
}
ìì7 8
$str
ìì8 Q
"
ììQ R
;
ììR S
var
ïï 
queryParameters
ïï #
=
ïï$ %
new
ïï& )
DynamicParameters
ïï* ;
(
ïï; <
)
ïï< =
;
ïï= >
queryParameters
ññ 
.
ññ  
Add
ññ  #
(
ññ# $
$str
ññ$ /
,
ññ/ 0
	filterDto
ññ1 :
.
ññ: ;
	TableName
ññ; D
)
ññD E
;
ññE F
var
òò 
list
òò 
=
òò 
await
òò  %
exactusReadDbConnection
òò! 8
.
òò8 9

QueryAsync
òò9 C
<
òòC D%
ExactusEmpleadoTablaDto
òòD [
>
òò[ \
(
òò\ ]
	storename
ôô 
,
ôô 
queryParameters
öö $
,
öö$ %
commandType
öö& 1
:
öö1 2
CommandType
öö3 >
.
öö> ?
StoredProcedure
öö? N
)
ööN O
;
ööO P
return
úú 
list
úú 
.
úú 
ToList
úú "
(
úú" #
)
úú# $
;
úú$ %
}
ùù 
catch
ûû 
(
ûû 
	Exception
ûû 
ex
ûû 
)
ûû  
{
üü 
_logger
†† 
.
†† 
LogError
††  
(
††  !
$str
††! H
)
††H I
;
††I J
_logger
°° 
.
°° 
LogError
°°  
(
°°  !
$str
°°! P
+
°°Q R
ex
°°S U
.
°°U V
Message
°°V ]
)
°°] ^
;
°°^ _
_logger
¢¢ 
.
¢¢ 
LogError
¢¢  
(
¢¢  !
$str
¢¢! P
+
¢¢Q R
ex
¢¢S U
.
¢¢U V

StackTrace
¢¢V `
)
¢¢` a
;
¢¢a b
}
££ 
return
§§ 
new
§§ 
List
§§ 
<
§§ %
ExactusEmpleadoTablaDto
§§ 3
>
§§3 4
(
§§4 5
)
§§5 6
;
§§6 7
}
¶¶ 	
public
©© 
async
©© 
Task
©© 
<
©© !
ExactusGlobalCCPDto
©© -
>
©©- .!
GetExactusGlobalCCP
©©/ B
(
©©B C
string
©©C I
sschema
©©J Q
)
©©Q R
{
™™ 	
try
´´ 
{
¨¨ 
string
ÆÆ 
	storename
ÆÆ  
=
ÆÆ! "
$"
ÆÆ# %
$str
ÆÆ% &
{
ÆÆ& '
sschema
ÆÆ' .
}
ÆÆ. /
$str
ÆÆ/ C
"
ÆÆC D
;
ÆÆD E
var
∞∞ 
queryParameters
∞∞ #
=
∞∞$ %
new
∞∞& )
DynamicParameters
∞∞* ;
(
∞∞; <
)
∞∞< =
;
∞∞= >
var
≤≤ 
list
≤≤ 
=
≤≤ 
await
≤≤  %
exactusReadDbConnection
≤≤! 8
.
≤≤8 9

QueryAsync
≤≤9 C
<
≤≤C D!
ExactusGlobalCCPDto
≤≤D W
>
≤≤W X
(
≤≤X Y
	storename
≥≥ 
,
≥≥ 
queryParameters
¥¥ $
,
¥¥$ %
commandType
¥¥& 1
:
¥¥1 2
CommandType
¥¥3 >
.
¥¥> ?
StoredProcedure
¥¥? N
)
¥¥N O
;
¥¥O P
return
∂∂ 
list
∂∂ 
.
∂∂ 
FirstOrDefault
∂∂ *
(
∂∂* +
)
∂∂+ ,
;
∂∂, -
}
∑∑ 
catch
∏∏ 
(
∏∏ 
	Exception
∏∏ 
ex
∏∏ 
)
∏∏  
{
ππ 
_logger
∫∫ 
.
∫∫ 
LogError
∫∫  
(
∫∫  !
$str
∫∫! H
)
∫∫H I
;
∫∫I J
_logger
ªª 
.
ªª 
LogError
ªª  
(
ªª  !
$str
ªª! P
+
ªªQ R
ex
ªªS U
.
ªªU V
Message
ªªV ]
)
ªª] ^
;
ªª^ _
_logger
ºº 
.
ºº 
LogError
ºº  
(
ºº  !
$str
ºº! P
+
ººQ R
ex
ººS U
.
ººU V

StackTrace
ººV `
)
ºº` a
;
ººa b
}
ΩΩ 
return
ææ 
new
ææ !
ExactusGlobalCCPDto
ææ *
(
ææ+ ,
)
ææ, -
;
ææ- .
}
øø 	
}
¿¿ 
}¡¡ Æy
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
ExactusMedicalRequestRepository	i à
>
à â
_logger
ä ë
)
ë í
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
}uu ˘:
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
ExactusMedicalRequestRepository	d É
>
É Ñ
_logger
Ö å
)
å ç
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
}gg µ
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
_logger	z Å
)
Å Ç
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
}66 ’
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