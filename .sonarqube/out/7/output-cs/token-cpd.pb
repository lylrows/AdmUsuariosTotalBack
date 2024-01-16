ï
dD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.Security\Encryption\Cryptography.cs
	namespace 	
HumanManagement
 
. 
Security "
." #

Encryption# -
{ 
public		 

class		 
Cryptography		 
:		 
ICryptography		  -
{

 
public 
string 

GetMd5Hash  
(  !
string! '
input( -
)- .
{ 	
MD5 
md5Hash 
= 
MD5 
. 
Create $
($ %
)% &
;& '
byte 
[ 
] 
data 
= 
md5Hash !
.! "
ComputeHash" -
(- .
Encoding. 6
.6 7
UTF87 ;
.; <
GetBytes< D
(D E
inputE J
)J K
)K L
;L M
return (
FromBytesToStringHexadecimal /
(/ 0
data0 4
)4 5
;5 6
} 	
public 
bool 
VerifyMd5Hash !
(! "
string" (
input) .
,. /
string0 6
hash7 ;
); <
{ 	
string 
hashOfInput 
=  

GetMd5Hash! +
(+ ,
input, 1
)1 2
;2 3
return $
CompareStringHexadecimal +
(+ ,
hashOfInput, 7
,7 8
hash9 =
)= >
;> ?
} 	
private 
string (
FromBytesToStringHexadecimal 3
(3 4
byte4 8
[8 9
]9 :
data; ?
)? @
{ 	
StringBuilder 
sBuilder "
=# $
new% (
StringBuilder) 6
(6 7
)7 8
;8 9
for 
( 
int 
i 
= 
$num 
; 
i 
< 
data  $
.$ %
Length% +
;+ ,
i- .
++. 0
)0 1
{ 
sBuilder 
. 
Append 
(  
data  $
[$ %
i% &
]& '
.' (
ToString( 0
(0 1
$str1 5
)5 6
)6 7
;7 8
} 
return 
sBuilder 
. 
ToString $
($ %
)% &
;& '
} 	
private!! 
bool!! $
CompareStringHexadecimal!! -
(!!- .
string!!. 4
inputOne!!5 =
,!!= >
string!!? E
inputTwo!!F N
)!!N O
{"" 	
StringComparer## 
comparer## #
=##$ %
StringComparer##& 4
.##4 5
OrdinalIgnoreCase##5 F
;##F G
return%% 
$num%% 
==%% 
comparer%%  
.%%  !
Compare%%! (
(%%( )
inputOne%%) 1
,%%1 2
inputTwo%%3 ;
)%%; <
;%%< =
}&& 	
}'' 
}(( ž

^D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.Security\PasswordGenerator.cs
	namespace 	
HumanManagement
 
. 
Security "
{ 
public 

class 
PasswordGenerator "
:# $
IPasswordGenerator% 7
{ 
public		 
string		 
Generate		 
(		 
int		 "
length		# )
)		) *
{

 	
using 
( $
RNGCryptoServiceProvider +
cryptRNG, 4
=5 6
new7 :$
RNGCryptoServiceProvider; S
(S T
)T U
)U V
{ 
byte 
[ 
] 
tokenBuffer "
=# $
new% (
byte) -
[- .
length. 4
]4 5
;5 6
cryptRNG 
. 
GetBytes !
(! "
tokenBuffer" -
)- .
;. /
return 
Convert 
. 
ToBase64String -
(- .
tokenBuffer. 9
)9 :
.: ;
Remove; A
(A B
lengthB H
)H I
;I J
} 
} 	
} 
} ±
[D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.Security\TokenGenerator.cs
	namespace

 	
HumanManagement


 
.

 
Security

 "
{ 
public 

class 
TokenGenerator 
:  !
ITokenGenerator" 1
{ 
private 
readonly 
TokenOption $
tokenOption% 0
;0 1
private 
readonly 

JwtOptions #

jwtOptions$ .
;. /
public 
int 
	TokenLife 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 
TokenGenerator 
( 
IOptions &
<& '
TokenOption' 2
>2 3
tokenOption4 ?
,? @
IOptionsA I
<I J

JwtOptionsJ T
>T U

jwtOptionsV `
)` a
{ 	
this 
. 
tokenOption 
= 
tokenOption *
.* +
Value+ 0
;0 1
this 
. 

jwtOptions 
= 

jwtOptions (
.( )
Value) .
;. /
	TokenLife 
= 
this 
. 

jwtOptions '
.' (
ExpiryMinutes( 5
;5 6
} 	
public 
string 
Generate 
( 
int "
IdUser# )
)) *
{ 	
var 
tokenHandler 
= 
new "#
JwtSecurityTokenHandler# :
(: ;
); <
;< =
var 
key 
= 
Encoding 
. 
ASCII $
.$ %
GetBytes% -
(- .
tokenOption. 9
.9 :
Secret: @
)@ A
;A B
var 
tokenDescriptor 
=  !
new" %#
SecurityTokenDescriptor& =
{ 
Subject 
= 
new 
ClaimsIdentity ,
(, -
new- 0
Claim1 6
[6 7
]7 8
{ 
new 
Claim 
( 

ClaimTypes (
.( )
Name) -
,- .
IdUser/ 5
.5 6
ToString6 >
(> ?
)? @
)@ A
}   
)   
,   
Expires!! 
=!! 
DateTime!! "
.!!" #
UtcNow!!# )
.!!) *

AddMinutes!!* 4
(!!4 5

jwtOptions!!5 ?
.!!? @
ExpiryMinutes!!@ M
)!!M N
,!!N O
SigningCredentials"" "
=""# $
new""% (
SigningCredentials"") ;
(""; <
new""< ? 
SymmetricSecurityKey""@ T
(""T U
key""U X
)""X Y
,""Y Z
SecurityAlgorithms""[ m
.""m n 
HmacSha256Signature	""n 
)
"" ‚
}## 
;## 
var$$ 
token$$ 
=$$ 
tokenHandler$$ $
.$$$ %
CreateToken$$% 0
($$0 1
tokenDescriptor$$1 @
)$$@ A
;$$A B
return%% 
tokenHandler%% 
.%%  

WriteToken%%  *
(%%* +
token%%+ 0
)%%0 1
;%%1 2
}&& 	
public(( 
int(( 
GetTokenLife(( 
(((  
)((  !
{)) 	
return** 
	TokenLife** 
;** 
}++ 	
},, 
}-- 