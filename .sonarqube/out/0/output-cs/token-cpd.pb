Î)
aD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.WebServices\ApiFormRepository.cs
	namespace		 	
HumanManagement		
 
.		 
WebServices		 %
{

 
public 

static 
class 
ApiFormRepository )
<) *
TRequest* 2
,2 3
	TResponse4 =
>= >
where 
TRequest 
: 
class 
where 
	TResponse 
: 
class 
, 
new  #
(# $
)$ %
{ 
public 
static 
string 
ExecuteForm (
(( )
string) /
requestparam0 <
,< =
string> D
apiUrlE K
)K L
{ 	
string 
oResult 
= 
string #
.# $
Empty$ )
;) *
try 
{ 
HttpWebRequest 
request &
;& '
HttpWebResponse 
response  (
;( )
request 
= 

WebRequest $
.$ %
Create% +
(+ ,
apiUrl, 2
)2 3
as4 6
HttpWebRequest7 E
;E F
byte 
[ 
] 
data 
= 
UTF8Encoding *
.* +
UTF8+ /
./ 0
GetBytes0 8
(8 9
requestparam9 E
)E F
;F G
request   
.   
Method   
=    
$str  ! '
;  ' (
request!! 
.!! 
ContentLength!! %
=!!& '
data!!( ,
.!!, -
Length!!- 3
;!!3 4
request## 
.## 
ContentType## #
=##$ %
$str##& I
;##I J
try&& 
{'' 
using(( 
((( 
Stream(( !

dataStream((" ,
=((- .
request((/ 6
.((6 7
GetRequestStream((7 G
(((G H
)((H I
)((I J
{)) 

dataStream** "
.**" #
Write**# (
(**( )
data**) -
,**- .
$num**/ 0
,**0 1
data**2 6
.**6 7
Length**7 =
)**= >
;**> ?

dataStream++ "
.++" #
Close++# (
(++( )
)++) *
;++* +
},, 
response-- 
=-- 
request-- &
.--& '
GetResponse--' 2
(--2 3
)--3 4
as--5 7
HttpWebResponse--8 G
;--G H
using.. 
(.. 
Stream.. !

dataStream.." ,
=..- .
response../ 7
...7 8
GetResponseStream..8 I
(..I J
)..J K
)..K L
{// 
StreamReader00 $
reader00% +
=00, -
new00. 1
StreamReader002 >
(00> ?

dataStream00? I
)00I J
;00J K
string11 
responsejson11 +
=11, -
reader11. 4
.114 5
	ReadToEnd115 >
(11> ?
)11? @
;11@ A
oResult66 
=66  !
responsejson66" .
;66. /
}88 
}99 
catch:: 
(:: 
WebException:: #
e::$ %
)::% &
{;; 
try<< 
{== 
var>> 
responseCatch2>> *
=>>+ ,
e>>- .
.>>. /
Response>>/ 7
as>>8 :
HttpWebResponse>>; J
;>>J K
StreamReader?? $
streamReader??% 1
=??2 3
new??4 7
StreamReader??8 D
(??D E
responseCatch2??E S
.??S T
GetResponseStream??T e
(??e f
)??f g
,??g h
Encoding??i q
.??q r
UTF7??r v
)??v w
;??w x
var@@ 
d@@ 
=@@ 
streamReader@@  ,
.@@, -
	ReadToEnd@@- 6
(@@6 7
)@@7 8
;@@8 9
}AA 
catchBB 
(BB 
WebExceptionBB '
)BB' (
{BB) *
}BB+ ,
}CC 
}DD 
catchEE 
(EE 
WebExceptionEE 
eEE  !
)EE! "
{FF 
tryGG 
{HH 
varII 
responseCatch2II &
=II' (
eII) *
.II* +
ResponseII+ 3
asII4 6
HttpWebResponseII7 F
;IIF G
StreamReaderJJ  
streamReaderJJ! -
=JJ. /
newJJ0 3
StreamReaderJJ4 @
(JJ@ A
responseCatch2JJA O
.JJO P
GetResponseStreamJJP a
(JJa b
)JJb c
,JJc d
EncodingJJe m
.JJm n
UTF7JJn r
)JJr s
;JJs t
varKK 
dKK 
=KK 
streamReaderKK (
.KK( )
	ReadToEndKK) 2
(KK2 3
)KK3 4
;KK4 5
}MM 
catchOO 
(OO 
WebExceptionOO #
)OO# $
{OO% &
}OO' (
}PP 
returnTT 
oResultTT 
;TT 
}UU 	
}XX 
}[[ ù*
lD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.WebServices\Repository\ApiFormRepository.cs
	namespace		 	
HumanManagement		
 
.		 
WebServices		 %
.		% &

Repository		& 0
{

 
public 

static 
class 
ApiFormRepository )
<) *
TRequest* 2
,2 3
	TResponse4 =
>= >
where 
TRequest 
: 
class 
where 
	TResponse 
: 
class 
, 
new  #
(# $
)$ %
{ 
public 
static 
string 
ExecuteForm (
(( )
string) /
requestparam0 <
,< =
string> D
apiUrlE K
)K L
{ 	
string 
oResult 
= 
string #
.# $
Empty$ )
;) *
try 
{ 
HttpWebRequest 
request &
;& '
HttpWebResponse 
response  (
;( )
request 
= 

WebRequest $
.$ %
Create% +
(+ ,
apiUrl, 2
)2 3
as4 6
HttpWebRequest7 E
;E F
byte 
[ 
] 
data 
= 
UTF8Encoding *
.* +
UTF8+ /
./ 0
GetBytes0 8
(8 9
requestparam9 E
)E F
;F G
request   
.   
Method   
=    
$str  ! '
;  ' (
request!! 
.!! 
ContentLength!! %
=!!& '
data!!( ,
.!!, -
Length!!- 3
;!!3 4
request## 
.## 
ContentType## #
=##$ %
$str##& I
;##I J
try&& 
{'' 
using(( 
((( 
Stream(( !

dataStream((" ,
=((- .
request((/ 6
.((6 7
GetRequestStream((7 G
(((G H
)((H I
)((I J
{)) 

dataStream** "
.**" #
Write**# (
(**( )
data**) -
,**- .
$num**/ 0
,**0 1
data**2 6
.**6 7
Length**7 =
)**= >
;**> ?

dataStream++ "
.++" #
Close++# (
(++( )
)++) *
;++* +
},, 
response-- 
=-- 
request-- &
.--& '
GetResponse--' 2
(--2 3
)--3 4
as--5 7
HttpWebResponse--8 G
;--G H
using.. 
(.. 
Stream.. !

dataStream.." ,
=..- .
response../ 7
...7 8
GetResponseStream..8 I
(..I J
)..J K
)..K L
{// 
StreamReader00 $
reader00% +
=00, -
new00. 1
StreamReader002 >
(00> ?

dataStream00? I
)00I J
;00J K
string11 
responsejson11 +
=11, -
reader11. 4
.114 5
	ReadToEnd115 >
(11> ?
)11? @
;11@ A
oResult66 
=66  !
responsejson66" .
;66. /
}88 
}99 
catch:: 
(:: 
WebException:: #
e::$ %
)::% &
{;; 
try<< 
{== 
var>> 
responseCatch2>> *
=>>+ ,
e>>- .
.>>. /
Response>>/ 7
as>>8 :
HttpWebResponse>>; J
;>>J K
StreamReader?? $
streamReader??% 1
=??2 3
new??4 7
StreamReader??8 D
(??D E
responseCatch2??E S
.??S T
GetResponseStream??T e
(??e f
)??f g
,??g h
Encoding??i q
.??q r
UTF7??r v
)??v w
;??w x
var@@ 
d@@ 
=@@ 
streamReader@@  ,
.@@, -
	ReadToEnd@@- 6
(@@6 7
)@@7 8
;@@8 9
}AA 
catchBB 
(BB 
WebExceptionBB '
)BB' (
{BB) *
}BB+ ,
}CC 
}DD 
catchEE 
(EE 
WebExceptionEE 
eEE  !
)EE! "
{FF 
tryGG 
{HH 
varII 
responseCatch2II &
=II' (
eII) *
.II* +
ResponseII+ 3
asII4 6
HttpWebResponseII7 F
;IIF G
StreamReaderJJ  
streamReaderJJ! -
=JJ. /
newJJ0 3
StreamReaderJJ4 @
(JJ@ A
responseCatch2JJA O
.JJO P
GetResponseStreamJJP a
(JJa b
)JJb c
,JJc d
EncodingJJe m
.JJm n
UTF7JJn r
)JJr s
;JJs t
varKK 
dKK 
=KK 
streamReaderKK (
.KK( )
	ReadToEndKK) 2
(KK2 3
)KK3 4
;KK4 5
}MM 
catchOO 
(OO 
WebExceptionOO #
)OO# $
{OO% &
}OO' (
}PP 
returnTT 
oResultTT 
;TT 
}UU 	
}XX 
}[[ 