ި
bD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.CrossCutting\Utils\AppSettings.cs
	namespace 	
HumanManagement
 
. 
CrossCutting &
.& '
Utils' ,
{ 
public 

class 
AppSettings 
{ 
public		 
string		 
PathSaveFile		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
public

 
string

 
UrlFile

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
PathTempMailFiles '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 

MailServer  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
int 
MailPort 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
MailUser 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
MailPassword "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
int 
PasswordResetExpiry &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
SiteGrupoFeSeguro '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string  
FromMailNotification *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
string  
FromNameNotification *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
string (
PasswordRecoveryTemplateHtml 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
string 
TemplateCvHtml $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
TemplateCvDocx $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string #
TemplateCvPostulantDocx -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
string #
TemplateCvPostulantTemp -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
string 

PathSaveCv  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string (
InviteEvaluationTemplateHtml 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
string ,
 EvalNotiForEvaluatorTemplateHtml 6
{7 8
get9 <
;< =
set> A
;A B
}C D
public 
string ,
 EvalNotiForEvaluatedTemplateHtml 6
{7 8
get9 <
;< =
set> A
;A B
}C D
public 
string 2
&EvalExternNotiForEvaluadorTemplateHtml <
{= >
get? B
;B C
setD G
;G H
}I J
public 
string 2
&EvalInternNotiForEvaluadorTemplateHtml <
{= >
get? B
;B C
setD G
;G H
}I J
public 
string !
NewVacantTemplateHtml +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public   
string   %
InformeFinalTemplateExcel   /
{  0 1
get  2 5
;  5 6
set  7 :
;  : ;
}  < =
public!! 
string!! 
UrlJobOfferDetail!! '
{!!( )
get!!* -
;!!- .
set!!/ 2
;!!2 3
}!!4 5
public"" 
string"" 

UrlBumeran""  
{""! "
get""# &
;""& '
set""( +
;""+ ,
}""- .
public## 
string## 
UrlEvaluationExtern## )
{##* +
get##, /
;##/ 0
set##1 4
;##4 5
}##6 7
public$$ 
string$$ 
UrlEvaluationIntern$$ )
{$$* +
get$$, /
;$$/ 0
set$$1 4
;$$4 5
}$$6 7
public%% 
string%% '
RegisterRequestTemplateHtml%% 1
{%%2 3
get%%4 7
;%%7 8
set%%9 <
;%%< =
}%%> ?
public&& 
string&& '
RegisterRequestDocumentHtml&& 1
{&&2 3
get&&4 7
;&&7 8
set&&9 <
;&&< =
}&&> ?
public'' 
string'' '
DownloadRequestDocumentHtml'' 1
{''2 3
get''4 7
;''7 8
set''9 <
;''< =
}''> ?
public(( 
string(( $
AceptRequestTemplateHtml(( .
{((/ 0
get((1 4
;((4 5
set((6 9
;((9 :
}((; <
public)) 
string)) $
AceptRequestDocumentHTML)) .
{))/ 0
get))1 4
;))4 5
set))6 9
;))9 :
})); <
public** 
string** %
RejectRequestTemplateHtml** /
{**0 1
get**2 5
;**5 6
set**7 :
;**: ;
}**< =
public++ 
string++ -
!RejectRequestDocumentTemplateHtml++ 7
{++8 9
get++: =
;++= >
set++? B
;++B C
}++D E
public,, 
string,, 
UrlEvaluation,, #
{,,$ %
get,,& )
;,,) *
set,,+ .
;,,. /
},,0 1
public-- 
string-- #
UrlFichaDatosPostulante-- -
{--. /
get--0 3
;--3 4
set--5 8
;--8 9
}--: ;
public.. 
string.. )
PostulantSelectedTemplateHtml.. 3
{..4 5
get..6 9
;..9 :
set..; >
;..> ?
}..@ A
public// 
string// 0
$PostulantSelectedExternaTemplateHtml// :
{//; <
get//= @
;//@ A
set//B E
;//E F
}//G H
public00 
string00 ,
 PostulantNotSelectedTemplateHtml00 6
{007 8
get009 <
;00< =
set00> A
;00A B
}00C D
public11 
string11 3
'PostulantNotSelectedExternaTemplateHtml11 =
{11> ?
get11@ C
;11C D
set11E H
;11H I
}11J K
public22 
string22 /
#PostulantInternSelectedTemplateHtml22 9
{22: ;
get22< ?
;22? @
set22A D
;22D E
}22F G
public33 
string33 '
ActivateAccountTemplateHtml33 1
{332 3
get334 7
;337 8
set339 <
;33< =
}33> ?
public44 
string44 !
ConfirmationPostulant44 +
{44, -
get44. 1
;441 2
set443 6
;446 7
}448 9
public55 
int55 
IdPersonRRHH55 
{55  !
get55" %
;55% &
set55' *
;55* +
}55, -
public66 
string66 
MailRRHH66 
{66  
get66! $
;66$ %
set66& )
;66) *
}66+ ,
public77 
string77 
PasswordRecoveryUrl77 )
{77* +
get77, /
;77/ 0
set771 4
;774 5
}776 7
public88 
string88 
HomeUrl88 
{88 
get88  #
;88# $
set88% (
;88( )
}88* +
public99 
string99 "
URL_PHOTO_USER_DEFAULT99 ,
{99- .
get99/ 2
;992 3
set994 7
;997 8
}999 :
public:: 
string:: %
URL_PHOTO_COMPANY_DEFAULT:: /
{::0 1
get::2 5
;::5 6
set::7 :
;::: ;
}::< =
public;; 
string;; 
Certificado;; !
{;;" #
get;;$ '
;;;' (
set;;) ,
;;;, -
};;. /
public<< 
string<< 
PATHSAVE<< 
{<<  
get<<! $
;<<$ %
set<<& )
;<<) *
}<<+ ,
public== 
string== 
PATHDOWNLOAD== "
{==# $
get==% (
;==( )
set==* -
;==- .
}==/ 0
public>> 
string>> %
RegisterRequestAdvacement>> /
{>>0 1
get>>2 5
;>>5 6
set>>7 :
;>>: ;
}>>< =
public?? 
string?? 
FormatoFeSaludWord?? (
{??) *
get??+ .
;??. /
set??0 3
;??3 4
}??4 5
public@@ 
string@@ 
FormatoPacificoWord@@ )
{@@* +
get@@, /
;@@/ 0
set@@1 4
;@@4 5
}@@6 7
publicAA 
stringAA 
FormatoCambioEPSAA &
{AA' (
getAA) ,
;AA, -
setAA. 1
;AA1 2
}AA3 4
publicBB 
stringBB %
FormatoCambioCuentaSueldoBB /
{BB0 1
getBB2 5
;BB5 6
setBB7 :
;BB: ;
}BB< =
publicCC 
stringCC 
FormatoCambioCTSCC &
{CC' (
getCC) ,
;CC, -
setCC. 1
;CC1 2
}CC3 4
publicDD 
stringDD 
URLEVALUACIONDD #
{DD$ %
getDD& )
;DD) *
setDD+ .
;DD. /
}DD0 1
publicEE 
stringEE 0
$StaffRequestNotificationTemplateHtmlEE :
{EE; <
getEE= @
;EE@ A
setEEB E
;EEE F
}EEG H
publicFF 
stringFF 6
*StaffRequestNotificationAcceptTemplateHtmlFF @
{FFA B
getFFC F
;FFF G
setFFH K
;FFK L
}FFM N
publicGG 
stringGG 6
*StaffRequestNotificationRejectTemplateHtmlGG @
{GGA B
getGGC F
;GGF G
setGGH K
;GGK L
}GGM N
publicHH 
stringHH "
AceptRequestAdvacementHH ,
{HH- .
getHH/ 2
;HH2 3
setHH4 7
;HH7 8
}HH9 :
publicII 
stringII #
RejectRequestAdvacementII -
{II. /
getII0 3
;II3 4
setII5 8
;II8 9
}II: ;
publicJJ 
stringJJ "
RegisterRequestMedicalJJ ,
{JJ- .
getJJ/ 2
;JJ2 3
setJJ4 7
;JJ7 8
}JJ9 :
publicKK 
stringKK !
RegisterRequestBurialKK +
{KK, -
getKK. 1
;KK1 2
setKK3 6
;KK6 7
}KK8 9
publicLL 
stringLL 
MedicalObservadoLL &
{LL' (
getLL) ,
;LL, -
setLL. 1
;LL1 2
}LL3 4
publicMM 
stringMM 
MedicalAcceptMM #
{MM$ %
getMM& )
;MM) *
setMM+ .
;MM. /
}MM0 1
publicNN 
stringNN 
RejectMedicalNN #
{NN$ %
getNN& )
;NN) *
setNN+ .
;NN. /
}NN0 1
publicOO 
stringOO !
RegisterRequestSalaryOO +
{OO, -
getOO. 1
;OO1 2
setOO3 6
;OO6 7
}OO8 9
publicPP 
stringPP 
AcepteRequestSalaryPP )
{PP* +
getPP, /
;PP/ 0
setPP1 4
;PP4 5
}PP6 7
publicQQ 
stringQQ $
AcepteRequestSalaryAceptQQ .
{QQ/ 0
getQQ1 4
;QQ4 5
setQQ6 9
;QQ9 :
}QQ; <
publicRR 
stringRR 
RejectRequestSalaryRR )
{RR* +
getRR, /
;RR/ 0
setRR1 4
;RR4 5
}RR6 7
publicSS 
stringSS 
AceptRequestBurialSS (
{SS) *
getSS+ .
;SS. /
setSS0 3
;SS3 4
}SS5 6
publicTT 
stringTT !
AceptRequestBurialFinTT +
{TT, -
getTT. 1
;TT1 2
setTT3 6
;TT6 7
}TT8 9
publicUU 
stringUU 
RejectRequestBurialUU )
{UU* +
getUU, /
;UU/ 0
setUU1 4
;UU4 5
}UU6 7
publicVV 
stringVV 
AcepteRequestMedicoVV )
{VV* +
getVV, /
;VV/ 0
setVV1 4
;VV4 5
}VV6 7
publicWW 
stringWW $
DeleteEmployeeByCampaignWW .
{WW/ 0
getWW1 4
;WW4 5
setWW6 9
;WW9 :
}WW; <
publicXX 
stringXX !
AcepteRequestTypeSureXX +
{XX, -
getXX. 1
;XX1 2
setXX3 6
;XX6 7
}XX8 9
publicYY 
stringYY !
ApprovedRequestMedicoYY +
{YY, -
getYY. 1
;YY1 2
setYY3 6
;YY6 7
}YY8 9
publicZZ 
stringZZ  
RejectRequestMedicalZZ *
{ZZ+ ,
getZZ- 0
;ZZ0 1
setZZ2 5
;ZZ5 6
}ZZ7 8
public[[ 
string[[ 
RegisterRequestSure[[ )
{[[* +
get[[, /
;[[/ 0
set[[1 4
;[[4 5
}[[6 7
public\\ 
string\\ #
RegisterRequestTypeSure\\ -
{\\. /
get\\0 3
;\\3 4
set\\5 8
;\\8 9
}\\: ;
public]] 
string]] 
AcepteRequestSure]] '
{]]( )
get]]* -
;]]- .
set]]/ 2
;]]2 3
}]]4 5
public^^ 
string^^ 
RejectRequestSure^^ '
{^^( )
get^^* -
;^^- .
set^^/ 2
;^^2 3
}^^4 5
public__ 
string__ +
TemplateReporteEvaluationIntern__ 5
{__6 7
get__8 ;
;__; <
set__= @
;__@ A
}__B C
public`` 
string`` +
TemplateReporteEvaluationExtern`` 5
{``6 7
get``8 ;
;``; <
set``= @
;``@ A
}``B C
publicaa 
stringaa 3
'TemplateReporteEvaluationIntegralInternaa =
{aa> ?
getaa@ C
;aaC D
setaaE H
;aaH I
}aaJ K
publicbb 
stringbb 3
'TemplateReporteEvaluationIntegralExternbb =
{bb> ?
getbb@ C
;bbC D
setbbE H
;bbH I
}bbJ K
publiccc 
stringcc .
"NotificationEvaluationMailTemplatecc 8
{cc9 :
getcc; >
;cc> ?
setcc@ C
;ccC D
}ccE F
publicdd 
stringdd 
UrlStaffRequestdd %
{dd& '
getdd( +
;dd+ ,
setdd- 0
;dd0 1
}dd2 3
publicff 
stringff 
UrlApiDocRRHHff #
{ff$ %
getff& )
;ff) *
setff+ .
;ff. /
}ff0 1
publicgg 
stringgg 
ClientIdApiDocRRHHgg (
{gg) *
getgg+ .
;gg. /
setgg0 3
;gg3 4
}gg5 6
publichh 
stringhh "
ClientSecretApiDocRRHHhh ,
{hh- .
gethh/ 2
;hh2 3
sethh4 7
;hh7 8
}hh9 :
publicii 
stringii 
ApiMultitestii "
{ii# $
getii% (
;ii( )
setii* -
;ii- .
}ii/ 0
publickk 
stringkk 5
)TemplateSendNotificationSolicitudApprovedkk ?
{kk@ A
getkkB E
;kkE F
setkkG J
;kkJ K
}kkL M
publicll 
stringll :
.TemplateSendNotificationSolicitudApprovedFinalll D
{llE F
getllG J
;llJ K
setllL O
;llO P
}llQ R
publicmm 
stringmm  
UrlRecruitmentDetailmm *
{mm+ ,
getmm- 0
;mm0 1
setmm2 5
;mm5 6
}mm7 8
publicoo 
stringoo %
PostulantSelectedPrestaFeoo /
{oo0 1
getoo2 5
;oo5 6
setoo7 :
;oo: ;
}oo< =
publicpp 
stringpp $
PostulantSelectedGrupoFepp .
{pp/ 0
getpp1 4
;pp4 5
setpp6 9
;pp9 :
}pp; <
publicqq 
stringqq $
PostulantSelectedFeSaludqq .
{qq/ 0
getqq1 4
;qq4 5
setqq6 9
;qq9 :
}qq; <
publicrr 
stringrr $
PostulantSelectedCampoFerr .
{rr/ 0
getrr1 4
;rr4 5
setrr6 9
;rr9 :
}rr; <
publicss 
stringss *
TemplateExportDetailEvaluationss 4
{ss5 6
getss7 :
;ss: ;
setss< ?
;ss? @
}ssA B
publictt 
stringtt -
!PathSaveExportDetailEvaluationPDFtt 7
{tt8 9
gettt: =
;tt= >
settt? B
;ttB C
}ttD E
publicuu 
intuu 
DaysTimeLineuu 
{uu  !
getuu" %
;uu% &
setuu' *
;uu* +
}uu, -
publicvv 
stringvv .
"PostulantSelectedExternaBackgroundvv 8
{vv9 :
getvv; >
;vv> ?
setvv@ C
;vvC D
}vvE F
publicww 
stringww ,
 PostulantSelectedExternaColorDivww 6
{ww7 8
getww9 <
;ww< =
setww> A
;wwA B
}wwC D
publicxx 
stringxx /
#PostulantSelectedExternaColorButtonxx 9
{xx: ;
getxx< ?
;xx? @
setxxA D
;xxD E
}xxF G
publicyy 
stringyy 0
$PostulantSelectedExternaUrlInduccionyy :
{yy; <
getyy= @
;yy@ A
setyyB E
;yyE F
}yyG H
publiczz 
stringzz 1
%PostulantNotSelectedExternaBackgroundzz ;
{zz< =
getzz> A
;zzA B
setzzC F
;zzF G
}zzH I
public{{ 
string{{ 2
&PostulantNotSelectedExternaColorButton{{ <
{{{= >
get{{? B
;{{B C
set{{D G
;{{G H
}{{I J
public|| 
string|| 4
(PostulantNotSelectedExternaUrlPercepcion|| >
{||? @
get||A D
;||D E
set||F I
;||I J
}||K L
public}} 
string}} #
PathDocumentosPostulant}} -
{}}. /
get}}0 3
;}}3 4
set}}5 8
;}}8 9
}}}: ;
public 
string .
"PostulantSelectedInternaBackground 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
public
�� 
string
�� .
 PostulantSelectedInternaColorDiv
�� 6
{
��7 8
get
��9 <
;
��< =
set
��> A
;
��A B
}
��C D
public
�� 
string
�� 1
#PostulantSelectedInternaColorButton
�� 9
{
��: ;
get
��< ?
;
��? @
set
��A D
;
��D E
}
��F G
public
�� 
string
�� 2
$PostulantSelectedInternaTemplateHtml
�� :
{
��; <
get
��= @
;
��@ A
set
��B E
;
��E F
}
��G H
public
�� 
string
�� 2
$PostulantSelectedInternaUrlInduccion
�� :
{
��; <
get
��= @
;
��@ A
set
��B E
;
��E F
}
��G H
public
�� 
string
�� 3
%TemplateSendNotificationFichaPersonal
�� ;
{
��< =
get
��> A
;
��A B
set
��C F
;
��F G
}
��H I
public
�� 
string
�� +
UrlPostulantEvaluationInterna
�� 3
{
��4 5
get
��6 9
;
��9 :
set
��; >
;
��> ?
}
��@ A
public
�� 
string
�� +
UrlPostulantEvaluationExterna
�� 3
{
��4 5
get
��6 9
;
��9 :
set
��; >
;
��> ?
}
��@ A
public
�� 
string
�� (
UrlPostulantAdministration
�� 0
{
��1 2
get
��3 6
;
��6 7
set
��8 ;
;
��; <
}
��= >
}
�� 
}�� �*
`D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.CrossCutting\Utils\Constants.cs
	namespace 	
HumanManagement
 
. 
CrossCutting &
.& '
Utils' ,
{ 
public 

class 
	Constants 
{ 
public 
class 
Token 
{ 	
public 
const 
int  
INDEX_START_OF_TOKEN 1
=2 3
$num4 5
;5 6
}		 	
public

 
class

 
	LoginUser

 
{ 	
public 
const 
int 
NUMBER_ATTEMPT +
=, -
$num. /
;/ 0
} 	
public 
class 
StateCodeResult $
{ 	
public 
const 
int 
STATE_CODE_OK *
=+ ,
$num- 0
;0 1
public 
const 
int 
BAD_REQUEST (
=) *
$num+ .
;. /
public 
const 
int 
UNAUTHORIZED_ACCESS 0
=1 2
$num3 6
;6 7
public 
const 
int 
FILE_NOT_FOUND +
=, -
$num. 1
;1 2
public 
const 
int 
ERROR_EXCEPTION ,
=- .
$num/ 2
;2 3
public 
const 
int 

VALIDATION '
=( )
$num* -
;- .
} 	
public 
class 
PathTemplateHtml %
{ 	
public 
const 
string (
PATH_TEMPLATE_HTML_MAIL_USER  <
== >
$str? y
;y z
public 
class 
Request  
{ 
public 
const 
string #
RECRUITMENT$ /
=0 1
$str2 w
;w x
public 
const 
string #
REQUEST$ +
=, -
$str. p
;p q
public 
const 
string #
RESPONSE$ ,
=- .
$str/ q
;q r
}   
}!! 	
public## 
class## 
HumanManagemen## #
{$$ 	
public%% 
const%% 
string%% 
ApplicationName%%  /
=%%0 1
$str%%2 C
;%%C D
public&& 
const&& 
string&& 
ModuleCommon&&  ,
=&&- .
$str&&/ ?
;&&? @
public'' 
class'' 
Keys'' 
{(( 
public)) 
const)) 
string)) #
FrequencyProcDay))$ 4
=))5 6
$str))7 F
;))F G
public** 
const** 
string** #
FrequencyProcVH**$ 3
=**4 5
$str**6 D
;**D E
public++ 
const++ 
string++ #

HoraInicio++$ .
=++/ 0
$str++1 5
;++5 6
public,, 
const,, 
string,, #
HoraFin,,$ +
=,,, -
$str,,. 2
;,,2 3
}-- 
}.. 	
public00 
class00 
NotifyImportedUser00 '
{11 	
public22 
const22 
string22 
Module22  &
=22' (
$str22) B
;22B C
}33 	
public55 
class55 
PhotoDefault55 !
{66 	
public77 
const77 
string77 
URL_PHOTO_USER77  .
=77/ 0
$str771 c
;77c d
public88 
const88 
string88 
URL_PHOTO_COMPANY88  1
=882 3
$str884 k
;88k l
}99 	
public;; 
class;; 
Images;; 
{<< 	
public== 
const== 
string== 
FOLDER_USER==  +
===, -
$str==. C
;==C D
}>> 	
public@@ 
class@@ (
StaffRequestAttachedDocument@@ 1
{AA 	
publicBB 
constBB 
stringBB 
FOLDER_PERMITBB  -
=BB. /
$strBB0 H
;BBH I
publicCC 
constCC 
stringCC 
FOLDER_ABSENCECC  .
=CC/ 0
$strCC1 J
;CCJ K
publicDD 
constDD 
stringDD *
FOLDER_JUSTIFICATION_TARDINESSDD  >
=DD? @
$strDDA i
;DDi j
publicEE 
constEE 
stringEE 
FOLDER_LOANEE  +
=EE, -
$strEE. D
;EED E
publicFF 
constFF 
stringFF %
FOLDER_ACCOUNT_CHANGE_CTSFF  9
=FF: ;
$strFF< ^
;FF^ _
}GG 	
publicHH 
classHH  
StaffRequestApproverHH )
{II 	
publicJJ 
constJJ 
stringJJ 
MODULEJJ  &
=JJ' (
$strJJ) A
;JJA B
publicKK 
constKK 
stringKK 
KEYKK  #
=KK$ %
$strKK& 5
;KK5 6
publicLL 
constLL 
intLL 
APPROVAL_LEVELLL +
=LL, -
$numLL. /
;LL/ 0
}MM 	
}NN 
}OO �*
hD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.CrossCutting\Utils\ExecApiFormHelper.cs
	namespace		 	
HumanManagement		
 
.		 
CrossCutting		 &
.		& '
Utils		' ,
{

 
public 

static 
class 
ExecApiFormHelper )
<) *
TRequest* 2
,2 3
	TResponse4 =
>= >
where 
TRequest 
: 
class 
where 
	TResponse 
: 
class 
, 
new  #
(# $
)$ %
{ 
public 
static 
string 
ExecuteForm (
(( )
string) /
requestparam0 <
,< =
string> D
apiUrlE K
)K L
{ 	
string 
oResult 
= 
string #
.# $
Empty$ )
;) *
try 
{ 
HttpWebRequest 
request &
;& '
HttpWebResponse 
response  (
;( )
request 
= 

WebRequest $
.$ %
Create% +
(+ ,
apiUrl, 2
)2 3
as4 6
HttpWebRequest7 E
;E F
byte 
[ 
] 
data 
= 
UTF8Encoding *
.* +
UTF8+ /
./ 0
GetBytes0 8
(8 9
requestparam9 E
)E F
;F G
request 
. 
Method 
=  
$str! '
;' (
request   
.   
ContentLength   %
=  & '
data  ( ,
.  , -
Length  - 3
;  3 4
request"" 
."" 
ContentType"" #
=""$ %
$str""& I
;""I J
try%% 
{&& 
using'' 
('' 
Stream'' !

dataStream''" ,
=''- .
request''/ 6
.''6 7
GetRequestStream''7 G
(''G H
)''H I
)''I J
{(( 

dataStream)) "
.))" #
Write))# (
())( )
data))) -
,))- .
$num))/ 0
,))0 1
data))2 6
.))6 7
Length))7 =
)))= >
;))> ?

dataStream** "
.**" #
Close**# (
(**( )
)**) *
;*** +
}++ 
response,, 
=,, 
request,, &
.,,& '
GetResponse,,' 2
(,,2 3
),,3 4
as,,5 7
HttpWebResponse,,8 G
;,,G H
using-- 
(-- 
Stream-- !

dataStream--" ,
=--- .
response--/ 7
.--7 8
GetResponseStream--8 I
(--I J
)--J K
)--K L
{.. 
StreamReader// $
reader//% +
=//, -
new//. 1
StreamReader//2 >
(//> ?

dataStream//? I
)//I J
;//J K
string00 
responsejson00 +
=00, -
reader00. 4
.004 5
	ReadToEnd005 >
(00> ?
)00? @
;00@ A
oResult55 
=55  !
responsejson55" .
;55. /
}77 
}88 
catch99 
(99 
WebException99 #
e99$ %
)99% &
{:: 
try;; 
{<< 
var== 
responseCatch2== *
===+ ,
e==- .
.==. /
Response==/ 7
as==8 :
HttpWebResponse==; J
;==J K
StreamReader>> $
streamReader>>% 1
=>>2 3
new>>4 7
StreamReader>>8 D
(>>D E
responseCatch2>>E S
.>>S T
GetResponseStream>>T e
(>>e f
)>>f g
,>>g h
Encoding>>i q
.>>q r
UTF7>>r v
)>>v w
;>>w x
var?? 
d?? 
=?? 
streamReader??  ,
.??, -
	ReadToEnd??- 6
(??6 7
)??7 8
;??8 9
}@@ 
catchAA 
(AA 
WebExceptionAA '
)AA' (
{AA) *
}AA+ ,
}BB 
}CC 
catchDD 
(DD 
WebExceptionDD 
eDD  !
)DD! "
{EE 
tryFF 
{GG 
varHH 
responseCatch2HH &
=HH' (
eHH) *
.HH* +
ResponseHH+ 3
asHH4 6
HttpWebResponseHH7 F
;HHF G
StreamReaderII  
streamReaderII! -
=II. /
newII0 3
StreamReaderII4 @
(II@ A
responseCatch2IIA O
.IIO P
GetResponseStreamIIP a
(IIa b
)IIb c
,IIc d
EncodingIIe m
.IIm n
UTF7IIn r
)IIr s
;IIs t
varJJ 
dJJ 
=JJ 
streamReaderJJ (
.JJ( )
	ReadToEndJJ) 2
(JJ2 3
)JJ3 4
;JJ4 5
}LL 
catchNN 
(NN 
WebExceptionNN #
)NN# $
{NN% &
}NN' (
}OO 
returnSS 
oResultSS 
;SS 
}TT 	
}WW 
}YY ��
`D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.CrossCutting\Utils\Functions.cs
	namespace 	
HumanManagement
 
. 
CrossCutting &
.& '
Utils' ,
{ 
public 

class 
	Functions 
{ 
public 
static 
void 
DataSetToExcel )
() *
DataSet* 1
ds2 4
,4 5
string6 <
destination= H
)H I
{ 	
using 
( 
var 
workbook 
=  !
SpreadsheetDocument" 5
.5 6
Create6 <
(< =
destination= H
,H I
DocumentFormatJ X
.X Y
OpenXmlY `
.` a#
SpreadsheetDocumentTypea x
.x y
Workbook	y �
)
� �
)
� �
{ 
var 
workbookPart  
=! "
workbook# +
.+ ,
AddWorkbookPart, ;
(; <
)< =
;= >
workbook 
. 
WorkbookPart %
.% &
Workbook& .
=/ 0
new1 4
DocumentFormat5 C
.C D
OpenXmlD K
.K L
SpreadsheetL W
.W X
WorkbookX `
(` a
)a b
;b c
workbook 
. 
WorkbookPart %
.% &
Workbook& .
.. /
Sheets/ 5
=6 7
new8 ;
DocumentFormat< J
.J K
OpenXmlK R
.R S
SpreadsheetS ^
.^ _
Sheets_ e
(e f
)f g
;g h
var 

stylesPart 
=  
workbook! )
.) *
WorkbookPart* 6
.6 7

AddNewPart7 A
<A B
WorkbookStylesPartB T
>T U
(U V
)V W
;W X

stylesPart 
. 

Stylesheet %
=& '
new( +

Stylesheet, 6
(6 7
)7 8
;8 9
Font 
font 
= 
new 
Font  $
($ %
)% &
;& '
font 
. 
Append 
( 
new 
Color  %
(% &
)& '
{( )
Rgb* -
=. /
$str0 8
}9 :
): ;
;; <
font 
. 
Append 
( 
new 
Bold  $
($ %
)% &
)& '
;' (

stylesPart!! 
.!! 

Stylesheet!! %
.!!% &
Fonts!!& +
=!!, -
new!!. 1
Fonts!!2 7
(!!7 8
)!!8 9
;!!9 :

stylesPart"" 
."" 

Stylesheet"" %
.""% &
Fonts""& +
.""+ ,
Count"", 1
=""2 3
$num""4 5
;""5 6

stylesPart## 
.## 

Stylesheet## %
.##% &
Fonts##& +
.##+ ,
AppendChild##, 7
(##7 8
font##8 <
)##< =
;##= >

stylesPart$$ 
.$$ 

Stylesheet$$ %
.$$% &
Fonts$$& +
.$$+ ,
AppendChild$$, 7
($$7 8
new$$8 ;
Font$$< @
{$$A B
Color$$C H
=$$I J
new$$K N
Color$$O T
($$T U
)$$U V
{$$W X
Rgb$$Y \
=$$] ^
$str$$_ g
}$$h i
}$$j k
)$$k l
;$$l m

stylesPart'' 
.'' 

Stylesheet'' %
.''% &
Fills''& +
='', -
new''. 1
Fills''2 7
(''7 8
)''8 9
;''9 :
var** 
solidRed** 
=** 
new** "
PatternFill**# .
(**. /
)**/ 0
{**1 2
PatternType**3 >
=**? @
PatternValues**A N
.**N O
Solid**O T
}**U V
;**V W
solidRed++ 
.++ 
ForegroundColor++ (
=++) *
new+++ .
ForegroundColor++/ >
{++? @
Rgb++A D
=++E F
HexBinaryValue++G U
.++U V

FromString++V `
(++` a
$str++a i
)++i j
}++k l
;++l m
solidRed,, 
.,, 
BackgroundColor,, (
=,,) *
new,,+ .
BackgroundColor,,/ >
{,,? @
Indexed,,A H
=,,I J
$num,,K M
},,N O
;,,O P

stylesPart.. 
... 

Stylesheet.. %
...% &
Fills..& +
...+ ,
AppendChild.., 7
(..7 8
new..8 ;
Fill..< @
{..A B
PatternFill..C N
=..O P
new..Q T
PatternFill..U `
{..a b
PatternType..c n
=..o p
PatternValues..q ~
...~ 
None	.. �
}
..� �
}
..� �
)
..� �
;
..� �

stylesPart// 
.// 

Stylesheet// %
.//% &
Fills//& +
.//+ ,
AppendChild//, 7
(//7 8
new//8 ;
Fill//< @
{//A B
PatternFill//C N
=//O P
new//Q T
PatternFill//U `
{//a b
PatternType//c n
=//o p
PatternValues//q ~
.//~ 
Gray125	// �
}
//� �
}
//� �
)
//� �
;
//� �

stylesPart00 
.00 

Stylesheet00 %
.00% &
Fills00& +
.00+ ,
AppendChild00, 7
(007 8
new008 ;
Fill00< @
{00A B
PatternFill00C N
=00O P
solidRed00Q Y
}00Z [
)00[ \
;00\ ]

stylesPart11 
.11 

Stylesheet11 %
.11% &
Fills11& +
.11+ ,
Count11, 1
=112 3
$num114 5
;115 6

stylesPart44 
.44 

Stylesheet44 %
.44% &
Borders44& -
=44. /
new440 3
Borders444 ;
(44; <
)44< =
;44= >

stylesPart55 
.55 

Stylesheet55 %
.55% &
Borders55& -
.55- .
Count55. 3
=554 5
$num556 7
;557 8

stylesPart66 
.66 

Stylesheet66 %
.66% &
Borders66& -
.66- .
AppendChild66. 9
(669 :
new66: =
Border66> D
(66D E
)66E F
)66F G
;66G H

stylesPart99 
.99 

Stylesheet99 %
.99% &
CellStyleFormats99& 6
=997 8
new999 <
CellStyleFormats99= M
(99M N
)99N O
;99O P

stylesPart:: 
.:: 

Stylesheet:: %
.::% &
CellStyleFormats::& 6
.::6 7
Count::7 <
=::= >
$num::? @
;::@ A

stylesPart;; 
.;; 

Stylesheet;; %
.;;% &
CellStyleFormats;;& 6
.;;6 7
AppendChild;;7 B
(;;B C
new;;C F

CellFormat;;G Q
(;;Q R
);;R S
);;S T
;;;T U

stylesPart>> 
.>> 

Stylesheet>> %
.>>% &
CellFormats>>& 1
=>>2 3
new>>4 7
CellFormats>>8 C
(>>C D
)>>D E
;>>E F

stylesPart?? 
.?? 

Stylesheet?? %
.??% &
CellFormats??& 1
.??1 2
AppendChild??2 =
(??= >
new??> A

CellFormat??B L
(??L M
)??M N
)??N O
;??O P

stylesPart@@ 
.@@ 

Stylesheet@@ %
.@@% &
CellFormats@@& 1
.@@1 2
AppendChild@@2 =
(@@= >
new@@> A

CellFormat@@B L
{@@M N
FormatId@@O W
=@@X Y
$num@@Z [
,@@[ \
FontId@@] c
=@@d e
$num@@f g
,@@g h
BorderId@@i q
=@@r s
$num@@t u
,@@u v
FillId@@w }
=@@~ 
$num
@@� �
,
@@� �
	ApplyFill
@@� �
=
@@� �
true
@@� �
}
@@� �
)
@@� �
.
@@� �
AppendChild
@@� �
(
@@� �
new
@@� �
	Alignment
@@� �
{
@@� �

Horizontal
@@� �
=
@@� �'
HorizontalAlignmentValues
@@� �
.
@@� �
Center
@@� �
}
@@� �
)
@@� �
;
@@� �

stylesPartAA 
.AA 

StylesheetAA %
.AA% &
CellFormatsAA& 1
.AA1 2
AppendChildAA2 =
(AA= >
newAA> A

CellFormatAAB L
{AAM N
FormatIdAAO W
=AAX Y
$numAAZ [
,AA[ \
FontIdAA] c
=AAd e
$numAAf g
,AAg h
BorderIdAAi q
=AAr s
$numAAt u
,AAu v
FillIdAAw }
=AA~ 
$num
AA� �
,
AA� �
	ApplyFill
AA� �
=
AA� �
true
AA� �
}
AA� �
)
AA� �
.
AA� �
AppendChild
AA� �
(
AA� �
new
AA� �
	Alignment
AA� �
{
AA� �

Horizontal
AA� �
=
AA� �'
HorizontalAlignmentValues
AA� �
.
AA� �
Left
AA� �
}
AA� �
)
AA� �
;
AA� �

stylesPartBB 
.BB 

StylesheetBB %
.BB% &
CellFormatsBB& 1
.BB1 2
CountBB2 7
=BB8 9
$numBB: ;
;BB; <

stylesPartDD 
.DD 

StylesheetDD %
.DD% &
SaveDD& *
(DD* +
)DD+ ,
;DD, -
uintFF 
sheetIdFF 
=FF 
$numFF  
;FF  !
foreachHH 
(HH 
	DataTableHH "
tableHH# (
inHH) +
dsHH, .
.HH. /
TablesHH/ 5
)HH5 6
{II 
varJJ 
	sheetPartJJ !
=JJ" #
workbookJJ$ ,
.JJ, -
WorkbookPartJJ- 9
.JJ9 :

AddNewPartJJ: D
<JJD E
WorksheetPartJJE R
>JJR S
(JJS T
)JJT U
;JJU V
varKK 
	sheetDataKK !
=KK" #
newKK$ '
DocumentFormatKK( 6
.KK6 7
OpenXmlKK7 >
.KK> ?
SpreadsheetKK? J
.KKJ K
	SheetDataKKK T
(KKT U
)KKU V
;KKV W
	sheetPartLL 
.LL 
	WorksheetLL '
=LL( )
newLL* -
DocumentFormatLL. <
.LL< =
OpenXmlLL= D
.LLD E
SpreadsheetLLE P
.LLP Q
	WorksheetLLQ Z
(LLZ [
	sheetDataLL[ d
)LLd e
;LLe f
DocumentFormatNN "
.NN" #
OpenXmlNN# *
.NN* +
SpreadsheetNN+ 6
.NN6 7
SheetsNN7 =
sheetsNN> D
=NNE F
workbookNNG O
.NNO P
WorkbookPartNNP \
.NN\ ]
WorkbookNN] e
.NNe f
GetFirstChildNNf s
<NNs t
DocumentFormat	NNt �
.
NN� �
OpenXml
NN� �
.
NN� �
Spreadsheet
NN� �
.
NN� �
Sheets
NN� �
>
NN� �
(
NN� �
)
NN� �
;
NN� �
stringOO 
relationshipIdOO )
=OO* +
workbookOO, 4
.OO4 5
WorkbookPartOO5 A
.OOA B
GetIdOfPartOOB M
(OOM N
	sheetPartOON W
)OOW X
;OOX Y
ifQQ 
(QQ 
sheetsQQ 
.QQ 
ElementsQQ '
<QQ' (
DocumentFormatQQ( 6
.QQ6 7
OpenXmlQQ7 >
.QQ> ?
SpreadsheetQQ? J
.QQJ K
SheetQQK P
>QQP Q
(QQQ R
)QQR S
.QQS T
CountQQT Y
(QQY Z
)QQZ [
>QQ\ ]
$numQQ^ _
)QQ_ `
{RR 
sheetIdSS 
=SS  !
sheetsTT "
.TT" #
ElementsTT# +
<TT+ ,
DocumentFormatTT, :
.TT: ;
OpenXmlTT; B
.TTB C
SpreadsheetTTC N
.TTN O
SheetTTO T
>TTT U
(TTU V
)TTV W
.TTW X
SelectTTX ^
(TT^ _
sTT_ `
=>TTa c
sTTd e
.TTe f
SheetIdTTf m
.TTm n
ValueTTn s
)TTs t
.TTt u
MaxTTu x
(TTx y
)TTy z
+TT{ |
$numTT} ~
;TT~ 
}UU 
DocumentFormatWW "
.WW" #
OpenXmlWW# *
.WW* +
SpreadsheetWW+ 6
.WW6 7
SheetWW7 <
sheetWW= B
=WWC D
newWWE H
DocumentFormatWWI W
.WWW X
OpenXmlWWX _
.WW_ `
SpreadsheetWW` k
.WWk l
SheetWWl q
(WWq r
)WWr s
{WWt u
IdWWv x
=WWy z
relationshipId	WW{ �
,
WW� �
SheetId
WW� �
=
WW� �
sheetId
WW� �
,
WW� �
Name
WW� �
=
WW� �
table
WW� �
.
WW� �
	TableName
WW� �
}
WW� �
;
WW� �
sheetsXX 
.XX 
AppendXX !
(XX! "
sheetXX" '
)XX' (
;XX( )
DocumentFormatZZ "
.ZZ" #
OpenXmlZZ# *
.ZZ* +
SpreadsheetZZ+ 6
.ZZ6 7
RowZZ7 :
	headerRowZZ; D
=ZZE F
newZZG J
DocumentFormatZZK Y
.ZZY Z
OpenXmlZZZ a
.ZZa b
SpreadsheetZZb m
.ZZm n
RowZZn q
(ZZq r
)ZZr s
;ZZs t
Columnsll 

lstColumnsll &
=ll' (
	sheetPartll) 2
.ll2 3
	Worksheetll3 <
.ll< =
GetFirstChildll= J
<llJ K
ColumnsllK R
>llR S
(llS T
)llT U
;llU V
Booleanmm 
needToInsertColumnsmm /
=mm0 1
falsemm2 7
;mm7 8
ifnn 
(nn 

lstColumnsnn "
==nn# %
nullnn& *
)nn* +
{oo 

lstColumnspp "
=pp# $
newpp% (
Columnspp) 0
(pp0 1
)pp1 2
;pp2 3
needToInsertColumnsqq +
=qq, -
trueqq. 2
;qq2 3
}rr 
iftt 
(tt 
needToInsertColumnstt +
)tt+ ,
	sheetPartuu !
.uu! "
	Worksheetuu" +
.uu+ ,
InsertAtuu, 4
(uu4 5

lstColumnsuu5 ?
,uu? @
$numuuA B
)uuB C
;uuC D

lstColumnsww 
.ww 
Appendww %
(ww% &
newww& )
Columnww* 0
(ww0 1
)ww1 2
{ww3 4
Minww5 8
=ww9 :
$numww; <
,ww< =
Maxww> A
=wwB C
$numwwD E
,wwE F
WidthwwG L
=wwM N
$numwwO Q
,wwQ R
CustomWidthwwS ^
=ww_ `
truewwa e
}wwf g
)wwg h
;wwh i

lstColumnsxx 
.xx 
Appendxx %
(xx% &
newxx& )
Columnxx* 0
(xx0 1
)xx1 2
{xx3 4
Minxx5 8
=xx9 :
$numxx; <
,xx< =
Maxxx> A
=xxB C
$numxxD E
,xxE F
WidthxxG L
=xxM N
$numxxO Q
,xxQ R
CustomWidthxxS ^
=xx_ `
truexxa e
}xxf g
)xxg h
;xxh i

lstColumnsyy 
.yy 
Appendyy %
(yy% &
newyy& )
Columnyy* 0
(yy0 1
)yy1 2
{yy3 4
Minyy5 8
=yy9 :
$numyy; <
,yy< =
Maxyy> A
=yyB C
$numyyD E
,yyE F
WidthyyG L
=yyM N
$numyyO Q
,yyQ R
CustomWidthyyS ^
=yy_ `
trueyya e
}yyf g
)yyg h
;yyh i

lstColumnszz 
.zz 
Appendzz %
(zz% &
newzz& )
Columnzz* 0
(zz0 1
)zz1 2
{zz3 4
Minzz5 8
=zz9 :
$numzz; <
,zz< =
Maxzz> A
=zzB C
$numzzD E
,zzE F
WidthzzG L
=zzM N
$numzzO Q
,zzQ R
CustomWidthzzS ^
=zz_ `
truezza e
}zzf g
)zzg h
;zzh i

lstColumns{{ 
.{{ 
Append{{ %
({{% &
new{{& )
Column{{* 0
({{0 1
){{1 2
{{{3 4
Min{{5 8
={{9 :
$num{{; <
,{{< =
Max{{> A
={{B C
$num{{D E
,{{E F
Width{{G L
={{M N
$num{{O Q
,{{Q R
CustomWidth{{S ^
={{_ `
true{{a e
}{{f g
){{g h
;{{h i
List}} 
<}} 
String}} 
>}}  
columns}}! (
=}}) *
new}}+ .
List}}/ 3
<}}3 4
string}}4 :
>}}: ;
(}}; <
)}}< =
;}}= >
foreach~~ 
(~~ 

DataColumn~~ '
column~~( .
in~~/ 1
table~~2 7
.~~7 8
Columns~~8 ?
)~~? @
{ 
columns
�� 
.
��  
Add
��  #
(
��# $
column
��$ *
.
��* +

ColumnName
��+ 5
)
��5 6
;
��6 7
DocumentFormat
�� &
.
��& '
OpenXml
��' .
.
��. /
Spreadsheet
��/ :
.
��: ;
Cell
��; ?
cell
��@ D
=
��E F
new
��G J
DocumentFormat
��K Y
.
��Y Z
OpenXml
��Z a
.
��a b
Spreadsheet
��b m
.
��m n
Cell
��n r
(
��r s
)
��s t
;
��t u
cell
�� 
.
�� 
DataType
�� %
=
��& '
DocumentFormat
��( 6
.
��6 7
OpenXml
��7 >
.
��> ?
Spreadsheet
��? J
.
��J K

CellValues
��K U
.
��U V
String
��V \
;
��\ ]
cell
�� 
.
�� 
	CellValue
�� &
=
��' (
new
��) ,
DocumentFormat
��- ;
.
��; <
OpenXml
��< C
.
��C D
Spreadsheet
��D O
.
��O P
	CellValue
��P Y
(
��Y Z
column
��Z `
.
��` a

ColumnName
��a k
)
��k l
;
��l m
cell
�� 
.
�� 

StyleIndex
�� '
=
��( )
$num
��* +
;
��+ ,
	headerRow
�� !
.
��! "
AppendChild
��" -
(
��- .
cell
��. 2
)
��2 3
;
��3 4
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� )
(
��) *
	headerRow
��* 3
)
��3 4
;
��4 5
foreach
�� 
(
�� 
DataRow
�� $
dsrow
��% *
in
��+ -
table
��. 3
.
��3 4
Rows
��4 8
)
��8 9
{
�� 
DocumentFormat
�� &
.
��& '
OpenXml
��' .
.
��. /
Spreadsheet
��/ :
.
��: ;
Row
��; >
newRow
��? E
=
��F G
new
��H K
DocumentFormat
��L Z
.
��Z [
OpenXml
��[ b
.
��b c
Spreadsheet
��c n
.
��n o
Row
��o r
(
��r s
)
��s t
;
��t u
foreach
�� 
(
��  !
String
��! '
col
��( +
in
��, .
columns
��/ 6
)
��6 7
{
�� 
DocumentFormat
�� *
.
��* +
OpenXml
��+ 2
.
��2 3
Spreadsheet
��3 >
.
��> ?
Cell
��? C
cell
��D H
=
��I J
new
��K N
DocumentFormat
��O ]
.
��] ^
OpenXml
��^ e
.
��e f
Spreadsheet
��f q
.
��q r
Cell
��r v
(
��v w
)
��w x
;
��x y
cell
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cell
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
dsrow
��^ c
[
��c d
col
��d g
]
��g h
.
��h i
ToString
��i q
(
��q r
)
��r s
)
��s t
;
��t u
cell
��  
.
��  !

StyleIndex
��! +
=
��, -
$num
��. /
;
��/ 0
newRow
�� "
.
��" #
AppendChild
��# .
(
��. /
cell
��/ 3
)
��3 4
;
��4 5
}
�� 
	sheetData
�� !
.
��! "
AppendChild
��" -
(
��- .
newRow
��. 4
)
��4 5
;
��5 6
}
�� 
}
�� 
}
�� 
}
�� 	
public
�� 
static
�� 
void
�� '
DataTableToExcelWithStyle
�� 4
(
��4 5
	DataTable
��5 >
table
��? D
,
��D E
string
��F L
destination
��M X
)
��X Y
{
�� 	
try
�� 
{
�� 
using
�� 
(
�� 
var
�� 
spreadsheet
�� &
=
��' (!
SpreadsheetDocument
��) <
.
��< =
Create
��= C
(
��C D
destination
��D O
,
��O P%
SpreadsheetDocumentType
��Q h
.
��h i
Workbook
��i q
)
��q r
)
��r s
{
�� 
spreadsheet
�� 
.
��  
AddWorkbookPart
��  /
(
��/ 0
)
��0 1
;
��1 2
spreadsheet
�� 
.
��  
WorkbookPart
��  ,
.
��, -
Workbook
��- 5
=
��6 7
new
��8 ;
Workbook
��< D
(
��D E
)
��E F
;
��F G
var
�� 
wsPart
�� 
=
��  
spreadsheet
��! ,
.
��, -
WorkbookPart
��- 9
.
��9 :

AddNewPart
��: D
<
��D E
WorksheetPart
��E R
>
��R S
(
��S T
)
��T U
;
��U V
wsPart
�� 
.
�� 
	Worksheet
�� $
=
��% &
new
��' *
	Worksheet
��+ 4
(
��4 5
)
��5 6
;
��6 7
var
�� 

stylesPart
�� "
=
��# $
spreadsheet
��% 0
.
��0 1
WorkbookPart
��1 =
.
��= >

AddNewPart
��> H
<
��H I 
WorkbookStylesPart
��I [
>
��[ \
(
��\ ]
)
��] ^
;
��^ _

stylesPart
�� 
.
�� 

Stylesheet
�� )
=
��* +
new
��, /

Stylesheet
��0 :
(
��: ;
)
��; <
;
��< =
Font
�� 
font
�� 
=
�� 
new
��  #
Font
��$ (
(
��( )
)
��) *
;
��* +
font
�� 
.
�� 
Append
�� 
(
��  
new
��  #
Color
��$ )
(
��) *
)
��* +
{
��, -
Rgb
��. 1
=
��2 3
$str
��4 <
}
��= >
)
��> ?
;
��? @
font
�� 
.
�� 
Append
�� 
(
��  
new
��  #
Bold
��$ (
(
��( )
)
��) *
)
��* +
;
��+ ,

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fonts
��* /
=
��0 1
new
��2 5
Fonts
��6 ;
(
��; <
)
��< =
;
��= >

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fonts
��* /
.
��/ 0
Count
��0 5
=
��6 7
$num
��8 9
;
��9 :

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fonts
��* /
.
��/ 0
AppendChild
��0 ;
(
��; <
font
��< @
)
��@ A
;
��A B

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fonts
��* /
.
��/ 0
AppendChild
��0 ;
(
��; <
new
��< ?
Font
��@ D
{
��E F
Color
��G L
=
��M N
new
��O R
Color
��S X
(
��X Y
)
��Y Z
{
��[ \
Rgb
��] `
=
��a b
$str
��c k
}
��l m
}
��n o
)
��o p
;
��p q

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fills
��* /
=
��0 1
new
��2 5
Fills
��6 ;
(
��; <
)
��< =
;
��= >
var
�� 
solidRed
��  
=
��! "
new
��# &
PatternFill
��' 2
(
��2 3
)
��3 4
{
��5 6
PatternType
��7 B
=
��C D
PatternValues
��E R
.
��R S
Solid
��S X
}
��Y Z
;
��Z [
solidRed
�� 
.
�� 
ForegroundColor
�� ,
=
��- .
new
��/ 2
ForegroundColor
��3 B
{
��C D
Rgb
��E H
=
��I J
HexBinaryValue
��K Y
.
��Y Z

FromString
��Z d
(
��d e
$str
��e m
)
��m n
}
��o p
;
��p q
solidRed
�� 
.
�� 
BackgroundColor
�� ,
=
��- .
new
��/ 2
BackgroundColor
��3 B
{
��C D
Indexed
��E L
=
��M N
$num
��O Q
}
��R S
;
��S T

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fills
��* /
.
��/ 0
AppendChild
��0 ;
(
��; <
new
��< ?
Fill
��@ D
{
��E F
PatternFill
��G R
=
��S T
new
��U X
PatternFill
��Y d
{
��e f
PatternType
��g r
=
��s t
PatternValues��u �
.��� �
None��� �
}��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fills
��* /
.
��/ 0
AppendChild
��0 ;
(
��; <
new
��< ?
Fill
��@ D
{
��E F
PatternFill
��G R
=
��S T
new
��U X
PatternFill
��Y d
{
��e f
PatternType
��g r
=
��s t
PatternValues��u �
.��� �
Gray125��� �
}��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fills
��* /
.
��/ 0
AppendChild
��0 ;
(
��; <
new
��< ?
Fill
��@ D
{
��E F
PatternFill
��G R
=
��S T
solidRed
��U ]
}
��^ _
)
��_ `
;
��` a

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Fills
��* /
.
��/ 0
Count
��0 5
=
��6 7
$num
��8 9
;
��9 :

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Borders
��* 1
=
��2 3
new
��4 7
Borders
��8 ?
(
��? @
)
��@ A
;
��A B

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Borders
��* 1
.
��1 2
Count
��2 7
=
��8 9
$num
��: ;
;
��; <

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Borders
��* 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A
Border
��B H
(
��H I
)
��I J
)
��J K
;
��K L

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
CellStyleFormats
��* :
=
��; <
new
��= @
CellStyleFormats
��A Q
(
��Q R
)
��R S
;
��S T

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
CellStyleFormats
��* :
.
��: ;
Count
��; @
=
��A B
$num
��C D
;
��D E

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
CellStyleFormats
��* :
.
��: ;
AppendChild
��; F
(
��F G
new
��G J

CellFormat
��K U
(
��U V
)
��V W
)
��W X
;
��X Y

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
CellFormats
��* 5
=
��6 7
new
��8 ;
CellFormats
��< G
(
��G H
)
��H I
;
��I J

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
CellFormats
��* 5
.
��5 6
AppendChild
��6 A
(
��A B
new
��B E

CellFormat
��F P
(
��P Q
)
��Q R
)
��R S
;
��S T

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
CellFormats
��* 5
.
��5 6
AppendChild
��6 A
(
��A B
new
��B E

CellFormat
��F P
{
��Q R
FormatId
��S [
=
��\ ]
$num
��^ _
,
��_ `
FontId
��a g
=
��h i
$num
��j k
,
��k l
BorderId
��m u
=
��v w
$num
��x y
,
��y z
FillId��{ �
=��� �
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
CellFormats
��* 5
.
��5 6
AppendChild
��6 A
(
��A B
new
��B E

CellFormat
��F P
{
��Q R
FormatId
��S [
=
��\ ]
$num
��^ _
,
��_ `
FontId
��a g
=
��h i
$num
��j k
,
��k l
BorderId
��m u
=
��v w
$num
��x y
,
��y z
FillId��{ �
=��� �
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Left��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� )
.
��) *
Save
��* .
(
��. /
)
��/ 0
;
��0 1
Columns
�� 
columnExcel
�� '
=
��( )
new
��* -
Columns
��. 5
(
��5 6
)
��6 7
;
��7 8
int
�� 
contadorColumn
�� &
=
��' (
$num
��) *
;
��* +
foreach
�� 
(
�� 

DataColumn
�� '
column
��( .
in
��/ 1
table
��2 7
.
��7 8
Columns
��8 ?
)
��? @
{
�� 
columnExcel
�� #
.
��# $
Append
��$ *
(
��* +
new
��+ .
Column
��/ 5
(
��5 6
)
��6 7
{
��8 9
Min
��: =
=
��> ?
Convert
��@ G
.
��G H
ToUInt32
��H P
(
��P Q
contadorColumn
��Q _
)
��_ `
,
��` a
Max
��b e
=
��f g
Convert
��h o
.
��o p
ToUInt32
��p x
(
��x y
contadorColumn��y �
)��� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn
�� &
++
��& (
;
��( )
}
�� 
wsPart
�� 
.
�� 
	Worksheet
�� $
.
��$ %
Append
��% +
(
��+ ,
columnExcel
��, 7
)
��7 8
;
��8 9
var
�� 
	sheetData
�� !
=
��" #
wsPart
��$ *
.
��* +
	Worksheet
��+ 4
.
��4 5
AppendChild
��5 @
(
��@ A
new
��A D
	SheetData
��E N
(
��N O
)
��O P
)
��P Q
;
��Q R
DocumentFormat
�� "
.
��" #
OpenXml
��# *
.
��* +
Spreadsheet
��+ 6
.
��6 7
Row
��7 :
	headerRow
��; D
=
��E F
new
��G J
DocumentFormat
��K Y
.
��Y Z
OpenXml
��Z a
.
��a b
Spreadsheet
��b m
.
��m n
Row
��n q
(
��q r
)
��r s
;
��s t
List
�� 
<
�� 
String
�� 
>
��  
columns
��! (
=
��) *
new
��+ .
List
��/ 3
<
��3 4
string
��4 :
>
��: ;
(
��; <
)
��< =
;
��= >
foreach
�� 
(
�� 

DataColumn
�� '
column
��( .
in
��/ 1
table
��2 7
.
��7 8
Columns
��8 ?
)
��? @
{
�� 
columns
�� 
.
��  
Add
��  #
(
��# $
column
��$ *
.
��* +

ColumnName
��+ 5
)
��5 6
;
��6 7
DocumentFormat
�� &
.
��& '
OpenXml
��' .
.
��. /
Spreadsheet
��/ :
.
��: ;
Cell
��; ?
cell
��@ D
=
��E F
new
��G J
DocumentFormat
��K Y
.
��Y Z
OpenXml
��Z a
.
��a b
Spreadsheet
��b m
.
��m n
Cell
��n r
(
��r s
)
��s t
;
��t u
cell
�� 
.
�� 
DataType
�� %
=
��& '
DocumentFormat
��( 6
.
��6 7
OpenXml
��7 >
.
��> ?
Spreadsheet
��? J
.
��J K

CellValues
��K U
.
��U V
String
��V \
;
��\ ]
cell
�� 
.
�� 
	CellValue
�� &
=
��' (
new
��) ,
DocumentFormat
��- ;
.
��; <
OpenXml
��< C
.
��C D
Spreadsheet
��D O
.
��O P
	CellValue
��P Y
(
��Y Z
column
��Z `
.
��` a

ColumnName
��a k
)
��k l
;
��l m
cell
�� 
.
�� 

StyleIndex
�� '
=
��( )
$num
��* +
;
��+ ,
	headerRow
�� !
.
��! "
AppendChild
��" -
(
��- .
cell
��. 2
)
��2 3
;
��3 4
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� )
(
��) *
	headerRow
��* 3
)
��3 4
;
��4 5
foreach
�� 
(
�� 
DataRow
�� $
dsrow
��% *
in
��+ -
table
��. 3
.
��3 4
Rows
��4 8
)
��8 9
{
�� 
DocumentFormat
�� &
.
��& '
OpenXml
��' .
.
��. /
Spreadsheet
��/ :
.
��: ;
Row
��; >
newRow
��? E
=
��F G
new
��H K
DocumentFormat
��L Z
.
��Z [
OpenXml
��[ b
.
��b c
Spreadsheet
��c n
.
��n o
Row
��o r
(
��r s
)
��s t
;
��t u
foreach
�� 
(
��  !
String
��! '
col
��( +
in
��, .
columns
��/ 6
)
��6 7
{
�� 
DocumentFormat
�� *
.
��* +
OpenXml
��+ 2
.
��2 3
Spreadsheet
��3 >
.
��> ?
Cell
��? C
cell
��D H
=
��I J
new
��K N
DocumentFormat
��O ]
.
��] ^
OpenXml
��^ e
.
��e f
Spreadsheet
��f q
.
��q r
Cell
��r v
(
��v w
)
��w x
;
��x y
cell
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cell
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
dsrow
��^ c
[
��c d
col
��d g
]
��g h
.
��h i
ToString
��i q
(
��q r
)
��r s
)
��s t
;
��t u
cell
��  
.
��  !

StyleIndex
��! +
=
��, -
$num
��. /
;
��/ 0
newRow
�� "
.
��" #
AppendChild
��# .
(
��. /
cell
��/ 3
)
��3 4
;
��4 5
}
�� 
	sheetData
�� !
.
��! "
AppendChild
��" -
(
��- .
newRow
��. 4
)
��4 5
;
��5 6
}
�� 
wsPart
�� 
.
�� 
	Worksheet
�� $
.
��$ %
Save
��% )
(
��) *
)
��* +
;
��+ ,
var
�� 
sheets
�� 
=
��  
spreadsheet
��! ,
.
��, -
WorkbookPart
��- 9
.
��9 :
Workbook
��: B
.
��B C
AppendChild
��C N
(
��N O
new
��O R
Sheets
��S Y
(
��Y Z
)
��Z [
)
��[ \
;
��\ ]
sheets
�� 
.
�� 
AppendChild
�� &
(
��& '
new
��' *
Sheet
��+ 0
(
��0 1
)
��1 2
{
��3 4
Id
��5 7
=
��8 9
spreadsheet
��: E
.
��E F
WorkbookPart
��F R
.
��R S
GetIdOfPart
��S ^
(
��^ _
wsPart
��_ e
)
��e f
,
��f g
SheetId
��h o
=
��p q
$num
��r s
,
��s t
Name
��u y
=
��z {
$str��| �
}��� �
)��� �
;��� �
spreadsheet
�� 
.
��  
WorkbookPart
��  ,
.
��, -
Workbook
��- 5
.
��5 6
Save
��6 :
(
��: ;
)
��; <
;
��< =
}
�� 
}
�� 
catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 
var
�� 
error
�� 
=
�� 
ex
�� 
;
�� 
}
�� 
}
�� 	
public
�� 
static
�� 
void
�� 
SalaryBandXLS
�� (
(
��( )
	DataTable
��) 2
table
��3 8
,
��8 9
string
��: @
destination
��A L
)
��L M
{
�� 	
using
�� 
(
�� 
var
�� 
spreadsheet
�� "
=
��# $!
SpreadsheetDocument
��% 8
.
��8 9
Create
��9 ?
(
��? @
destination
��@ K
,
��K L%
SpreadsheetDocumentType
��M d
.
��d e
Workbook
��e m
)
��m n
)
��n o
{
�� 
spreadsheet
�� 
.
�� 
AddWorkbookPart
�� +
(
��+ ,
)
��, -
;
��- .
spreadsheet
�� 
.
�� 
WorkbookPart
�� (
.
��( )
Workbook
��) 1
=
��2 3
new
��4 7
Workbook
��8 @
(
��@ A
)
��A B
;
��B C
var
�� 
wsPart
�� 
=
�� 
spreadsheet
�� (
.
��( )
WorkbookPart
��) 5
.
��5 6

AddNewPart
��6 @
<
��@ A
WorksheetPart
��A N
>
��N O
(
��O P
)
��P Q
;
��Q R
wsPart
�� 
.
�� 
	Worksheet
��  
=
��! "
new
��# &
	Worksheet
��' 0
(
��0 1
)
��1 2
;
��2 3
var
�� 

stylesPart
�� 
=
��  
spreadsheet
��! ,
.
��, -
WorkbookPart
��- 9
.
��9 :

AddNewPart
��: D
<
��D E 
WorkbookStylesPart
��E W
>
��W X
(
��X Y
)
��Y Z
;
��Z [

stylesPart
�� 
.
�� 

Stylesheet
�� %
=
��& '
new
��( +

Stylesheet
��, 6
(
��6 7
)
��7 8
;
��8 9
Font
�� 
font
�� 
=
�� 
new
�� 
Font
��  $
(
��$ %
)
��% &
;
��& '
font
�� 
.
�� 
Append
�� 
(
�� 
new
�� 
Color
��  %
(
��% &
)
��& '
{
��( )
Rgb
��* -
=
��. /
$str
��0 8
}
��9 :
)
��: ;
;
��; <
font
�� 
.
�� 
Append
�� 
(
�� 
new
�� 
Bold
��  $
(
��$ %
)
��% &
)
��& '
;
��' (

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
=
��, -
new
��. 1
Fonts
��2 7
(
��7 8
)
��8 9
;
��9 :

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
font
��8 <
)
��< =
;
��= >

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
}
��j k
)
��k l
;
��l m

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
,
��i j
Bold
��j n
=
��o p
new
��q t
Bold
��u y
(
��y z
)
��z {
}
��| }
)
��} ~
;
��~ 

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
Count
��, 1
=
��2 3
$num
��4 5
;
��5 6

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
=
��, -
new
��. 1
Fills
��2 7
(
��7 8
)
��8 9
;
��9 :
var
�� 
solidRed
�� 
=
�� 
new
�� "
PatternFill
��# .
(
��. /
)
��/ 0
{
��1 2
PatternType
��3 >
=
��? @
PatternValues
��A N
.
��N O
Solid
��O T
}
��U V
;
��V W
solidRed
�� 
.
�� 
ForegroundColor
�� (
=
��) *
new
��+ .
ForegroundColor
��/ >
{
��? @
Rgb
��A D
=
��E F
HexBinaryValue
��G U
.
��U V

FromString
��V `
(
��` a
$str
��a i
)
��i j
}
��k l
;
��l m
solidRed
�� 
.
�� 
BackgroundColor
�� (
=
��) *
new
��+ .
BackgroundColor
��/ >
{
��? @
Indexed
��A H
=
��I J
$num
��K M
}
��N O
;
��O P
var
�� 
solidCeleste
��  
=
��! "
new
��# &
PatternFill
��' 2
(
��2 3
)
��3 4
{
��5 6
PatternType
��7 B
=
��C D
PatternValues
��E R
.
��R S
Solid
��S X
}
��Y Z
;
��Z [
solidCeleste
�� 
.
�� 
ForegroundColor
�� ,
=
��- .
new
��/ 2
ForegroundColor
��3 B
{
��C D
Rgb
��E H
=
��I J
HexBinaryValue
��K Y
.
��Y Z

FromString
��Z d
(
��d e
$str
��e m
)
��m n
}
��o p
;
��p q
solidCeleste
�� 
.
�� 
BackgroundColor
�� ,
=
��- .
new
��/ 2
BackgroundColor
��3 B
{
��C D
Indexed
��E L
=
��M N
$num
��O Q
}
��R S
;
��S T

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
new
��Q T
PatternFill
��U `
{
��a b
PatternType
��c n
=
��o p
PatternValues
��q ~
.
��~ 
None�� �
}��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
new
��Q T
PatternFill
��U `
{
��a b
PatternType
��c n
=
��o p
PatternValues
��q ~
.
��~ 
Gray125�� �
}��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
solidRed
��Q Y
}
��Z [
)
��[ \
;
��\ ]

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
solidCeleste
��Q ]
}
��] ^
)
��^ _
;
��_ `

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
Count
��, 1
=
��2 3
$num
��4 5
;
��5 6

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
=
��. /
new
��0 3
Borders
��4 ;
(
��; <
)
��< =
;
��= >

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
.
��- .
Count
��. 3
=
��4 5
$num
��6 7
;
��7 8

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
.
��- .
AppendChild
��. 9
(
��9 :
new
��: =
Border
��> D
(
��D E
)
��E F
)
��F G
;
��G H

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
=
��7 8
new
��9 <
CellStyleFormats
��= M
(
��M N
)
��N O
;
��O P

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
.
��6 7
Count
��7 <
=
��= >
$num
��? @
;
��@ A

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
.
��6 7
AppendChild
��7 B
(
��B C
new
��C F

CellFormat
��G Q
(
��Q R
)
��R S
)
��S T
;
��T U

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
=
��2 3
new
��4 7
CellFormats
��8 C
(
��C D
)
��D E
;
��E F

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
(
��L M
)
��M N
)
��N O
;
��O P

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Left��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
Count
��2 7
=
��8 9
$num
��: ;
;
��; <

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Save
��& *
(
��* +
)
��+ ,
;
��, -
Columns
�� 
columnExcel
�� #
=
��$ %
new
��& )
Columns
��* 1
(
��1 2
)
��2 3
;
��3 4
int
�� 
contadorColumn
�� "
=
��# $
$num
��% &
;
��& '
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
wsPart
�� 
.
�� 
	Worksheet
��  
.
��  !
Append
��! '
(
��' (
columnExcel
��( 3
)
��3 4
;
��4 5
var
�� 
	sheetData
�� 
=
�� 
wsPart
��  &
.
��& '
	Worksheet
��' 0
.
��0 1
AppendChild
��1 <
(
��< =
new
��= @
	SheetData
��A J
(
��J K
)
��K L
)
��L M
;
��M N
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Row
��3 6
	headerRow
��7 @
=
��A B
new
��C F
DocumentFormat
��G U
.
��U V
OpenXml
��V ]
.
��] ^
Spreadsheet
��^ i
.
��i j
Row
��j m
(
��m n
)
��n o
;
��o p
List
�� 
<
�� 
String
�� 
>
�� 
columns
�� $
=
��% &
new
��' *
List
��+ /
<
��/ 0
string
��0 6
>
��6 7
(
��7 8
)
��8 9
;
��9 :
foreach
�� 
(
�� 

DataColumn
�� #
column
��$ *
in
��+ -
table
��. 3
.
��3 4
Columns
��4 ;
)
��; <
{
�� 
columns
�� 
.
�� 
Add
�� 
(
��  
column
��  &
.
��& '

ColumnName
��' 1
)
��1 2
;
��2 3
DocumentFormat
�� "
.
��" #
OpenXml
��# *
.
��* +
Spreadsheet
��+ 6
.
��6 7
Cell
��7 ;
cell
��< @
=
��A B
new
��C F
DocumentFormat
��G U
.
��U V
OpenXml
��V ]
.
��] ^
Spreadsheet
��^ i
.
��i j
Cell
��j n
(
��n o
)
��o p
;
��p q
cell
�� 
.
�� 
DataType
�� !
=
��" #
DocumentFormat
��$ 2
.
��2 3
OpenXml
��3 :
.
��: ;
Spreadsheet
��; F
.
��F G

CellValues
��G Q
.
��Q R
String
��R X
;
��X Y
cell
�� 
.
�� 
	CellValue
�� "
=
��# $
new
��% (
DocumentFormat
��) 7
.
��7 8
OpenXml
��8 ?
.
��? @
Spreadsheet
��@ K
.
��K L
	CellValue
��L U
(
��U V
column
��V \
.
��\ ]

ColumnName
��] g
)
��g h
;
��h i
cell
�� 
.
�� 

StyleIndex
�� #
=
��$ %
$num
��& '
;
��' (
	headerRow
�� 
.
�� 
AppendChild
�� )
(
��) *
cell
��* .
)
��. /
;
��/ 0
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� %
(
��% &
	headerRow
��& /
)
��/ 0
;
��0 1
foreach
�� 
(
�� 
DataRow
��  
dsrow
��! &
in
��' )
table
��* /
.
��/ 0
Rows
��0 4
)
��4 5
{
�� 
DocumentFormat
�� "
.
��" #
OpenXml
��# *
.
��* +
Spreadsheet
��+ 6
.
��6 7
Row
��7 :
newRow
��; A
=
��B C
new
��D G
DocumentFormat
��H V
.
��V W
OpenXml
��W ^
.
��^ _
Spreadsheet
��_ j
.
��j k
Row
��k n
(
��n o
)
��o p
;
��p q
foreach
�� 
(
�� 
String
�� #
col
��$ '
in
��( *
columns
��+ 2
)
��2 3
{
�� 
DocumentFormat
�� &
.
��& '
OpenXml
��' .
.
��. /
Spreadsheet
��/ :
.
��: ;
Cell
��; ?
cell
��@ D
=
��E F
new
��G J
DocumentFormat
��K Y
.
��Y Z
OpenXml
��Z a
.
��a b
Spreadsheet
��b m
.
��m n
Cell
��n r
(
��r s
)
��s t
;
��t u
cell
�� 
.
�� 
DataType
�� %
=
��& '
DocumentFormat
��( 6
.
��6 7
OpenXml
��7 >
.
��> ?
Spreadsheet
��? J
.
��J K

CellValues
��K U
.
��U V
String
��V \
;
��\ ]
cell
�� 
.
�� 
	CellValue
�� &
=
��' (
new
��) ,
DocumentFormat
��- ;
.
��; <
OpenXml
��< C
.
��C D
Spreadsheet
��D O
.
��O P
	CellValue
��P Y
(
��Y Z
dsrow
��Z _
[
��_ `
col
��` c
]
��c d
.
��d e
ToString
��e m
(
��m n
)
��n o
)
��o p
;
��p q
cell
�� 
.
�� 

StyleIndex
�� '
=
��( )
$num
��* +
;
��+ ,
newRow
�� 
.
�� 
AppendChild
�� *
(
��* +
cell
��+ /
)
��/ 0
;
��0 1
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� )
(
��) *
newRow
��* 0
)
��0 1
;
��1 2
}
�� 
wsPart
�� 
.
�� 
	Worksheet
��  
.
��  !
Save
��! %
(
��% &
)
��& '
;
��' (
var
�� 
sheets
�� 
=
�� 
spreadsheet
�� (
.
��( )
WorkbookPart
��) 5
.
��5 6
Workbook
��6 >
.
��> ?
AppendChild
��? J
(
��J K
new
��K N
Sheets
��O U
(
��U V
)
��V W
)
��W X
;
��X Y
sheets
�� 
.
�� 
AppendChild
�� "
(
��" #
new
��# &
Sheet
��' ,
(
��, -
)
��- .
{
��/ 0
Id
��1 3
=
��4 5
spreadsheet
��6 A
.
��A B
WorkbookPart
��B N
.
��N O
GetIdOfPart
��O Z
(
��Z [
wsPart
��[ a
)
��a b
,
��b c
SheetId
��d k
=
��l m
$num
��n o
,
��o p
Name
��q u
=
��v w
$str��x �
}��� �
)��� �
;��� �
spreadsheet
�� 
.
�� 
WorkbookPart
�� (
.
��( )
Workbook
��) 1
.
��1 2
Save
��2 6
(
��6 7
)
��7 8
;
��8 9
}
�� 
}
�� 	
public
�� 
static
�� 
void
�� 
BudgetResumeXLS
�� *
(
��* +
	DataTable
��+ 4
table
��5 :
,
��: ;
string
��< B
destination
��C N
,
��N O
int
��O R
currentPeriod
��S `
,
��$ %
decimal
��& -&
totalPreviousExecAmount2
��. F
,
��F G
decimal
��G N&
totalPreviousExecAmount1
��O g
,
��g h
decimal
��h o&
totalPreviousExecAmount��p �
,
��$ %
decimal
��& -$
totalCurrentExecAmount
��. D
,
��F G
decimal
��G N!
totalPreviousAmount
��O b
,
��$ %
decimal
��& - 
totalCurrentAmount
��. @
,
��F G
decimal
��G N 
totalVariationPorc
��O a
,
��g h
decimal
��h o#
totalVariationAmount��p �
)
�� 
{
�� 	
using
�� 
(
�� 
var
�� 
spreadsheet
�� "
=
��# $!
SpreadsheetDocument
��% 8
.
��8 9
Create
��9 ?
(
��? @
destination
��@ K
,
��K L%
SpreadsheetDocumentType
��M d
.
��d e
Workbook
��e m
)
��m n
)
��n o
{
�� 
spreadsheet
�� 
.
�� 
AddWorkbookPart
�� +
(
��+ ,
)
��, -
;
��- .
spreadsheet
�� 
.
�� 
WorkbookPart
�� (
.
��( )
Workbook
��) 1
=
��2 3
new
��4 7
Workbook
��8 @
(
��@ A
)
��A B
;
��B C
var
�� 
wsPart
�� 
=
�� 
spreadsheet
�� (
.
��( )
WorkbookPart
��) 5
.
��5 6

AddNewPart
��6 @
<
��@ A
WorksheetPart
��A N
>
��N O
(
��O P
)
��P Q
;
��Q R
wsPart
�� 
.
�� 
	Worksheet
��  
=
��! "
new
��# &
	Worksheet
��' 0
(
��0 1
)
��1 2
;
��2 3
var
�� 

stylesPart
�� 
=
��  
spreadsheet
��! ,
.
��, -
WorkbookPart
��- 9
.
��9 :

AddNewPart
��: D
<
��D E 
WorkbookStylesPart
��E W
>
��W X
(
��X Y
)
��Y Z
;
��Z [

stylesPart
�� 
.
�� 

Stylesheet
�� %
=
��& '
new
��( +

Stylesheet
��, 6
(
��6 7
)
��7 8
;
��8 9
Font
�� 
font
�� 
=
�� 
new
�� 
Font
��  $
(
��$ %
)
��% &
;
��& '
font
�� 
.
�� 
Append
�� 
(
�� 
new
�� 
Color
��  %
(
��% &
)
��& '
{
��( )
Rgb
��* -
=
��. /
$str
��0 8
}
��9 :
)
��: ;
;
��; <
font
�� 
.
�� 
Append
�� 
(
�� 
new
�� 
Bold
��  $
(
��$ %
)
��% &
)
��& '
;
��' (

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
=
��, -
new
��. 1
Fonts
��2 7
(
��7 8
)
��8 9
;
��9 :

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
Count
��, 1
=
��2 3
$num
��4 5
;
��5 6

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
font
��8 <
)
��< =
;
��= >

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
}
��j k
)
��k l
;
��l m

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
,
��j k
Bold
��l p
=
��q r
new
��s v
Bold
��w {
(
��{ |
)
��| }
}�� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
=
��, -
new
��. 1
Fills
��2 7
(
��7 8
)
��8 9
;
��9 :
var
�� 
solidRed
�� 
=
�� 
new
�� "
PatternFill
��# .
(
��. /
)
��/ 0
{
��1 2
PatternType
��3 >
=
��? @
PatternValues
��A N
.
��N O
Solid
��O T
}
��U V
;
��V W
solidRed
�� 
.
�� 
ForegroundColor
�� (
=
��) *
new
��+ .
ForegroundColor
��/ >
{
��? @
Rgb
��A D
=
��E F
HexBinaryValue
��G U
.
��U V

FromString
��V `
(
��` a
$str
��a i
)
��i j
}
��k l
;
��l m
solidRed
�� 
.
�� 
BackgroundColor
�� (
=
��) *
new
��+ .
BackgroundColor
��/ >
{
��? @
Indexed
��A H
=
��I J
$num
��K M
}
��N O
;
��O P
var
�� 
	fondogris
�� 
=
�� 
new
��  #
PatternFill
��$ /
(
��/ 0
)
��0 1
{
��2 3
PatternType
��4 ?
=
��@ A
PatternValues
��B O
.
��O P
Solid
��P U
}
��V W
;
��W X
	fondogris
�� 
.
�� 
ForegroundColor
�� )
=
��* +
new
��, /
ForegroundColor
��0 ?
{
��@ A
Rgb
��B E
=
��F G
HexBinaryValue
��H V
.
��V W

FromString
��W a
(
��a b
$str
��b j
)
��j k
}
��l m
;
��m n
	fondogris
�� 
.
�� 
BackgroundColor
�� )
=
��* +
new
��, /
BackgroundColor
��0 ?
{
��@ A
Indexed
��B I
=
��J K
$num
��L N
}
��O P
;
��P Q
var
�� 
fondoazultotal
�� "
=
��# $
new
��% (
PatternFill
��) 4
(
��4 5
)
��5 6
{
��7 8
PatternType
��9 D
=
��E F
PatternValues
��G T
.
��T U
Solid
��U Z
}
��[ \
;
��\ ]
fondoazultotal
�� 
.
�� 
ForegroundColor
�� .
=
��/ 0
new
��1 4
ForegroundColor
��5 D
{
��E F
Rgb
��G J
=
��K L
HexBinaryValue
��M [
.
��[ \

FromString
��\ f
(
��f g
$str
��g o
)
��o p
}
��q r
;
��r s
fondoazultotal
�� 
.
�� 
BackgroundColor
�� .
=
��/ 0
new
��1 4
BackgroundColor
��5 D
{
��E F
Indexed
��G N
=
��O P
$num
��Q S
}
��T U
;
��U V

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
new
��Q T
PatternFill
��U `
{
��a b
PatternType
��c n
=
��o p
PatternValues
��q ~
.
��~ 
None�� �
}��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
new
��Q T
PatternFill
��U `
{
��a b
PatternType
��c n
=
��o p
PatternValues
��q ~
.
��~ 
Gray125�� �
}��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
solidRed
��Q Y
}
��Z [
)
��[ \
;
��\ ]

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
	fondogris
��Q Z
}
��[ \
)
��\ ]
;
��] ^

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
fondoazultotal
��Q _
}
��` a
)
��a b
;
��b c

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
Count
��, 1
=
��2 3
$num
��4 5
;
��5 6

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
=
��. /
new
��0 3
Borders
��4 ;
(
��; <
)
��< =
;
��= >

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
.
��- .
AppendChild
��. 9
(
��9 :
new
��: =
Border
��> D
(
��D E
)
��E F
)
��F G
;
��G H

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
.
��- .
AppendChild
��. 9
(
��9 :
new
��: =
Border
��> D
(
��D E
)
��E F
{
��G H

LeftBorder
��I S
=
��S T
new
��U X

LeftBorder
��Y c
(
��c d
)
��d e
{
��f g
Style
��h m
=
��m n 
BorderStyleValues��p �
.��� �
Thin��� �
}��� �
,��� �
RightBorder��� �
=��� �
new��� �
RightBorder��� �
(��� �
)��� �
{��� �
Style��� �
=��� �!
BorderStyleValues��� �
.��� �
Thin��� �
}��� �
,
�� 
BottomBorder
�� 
=
��  
new
��! $
BottomBorder
��% 1
(
��1 2
)
��2 3
{
��4 5
Style
��6 ;
=
��< =
BorderStyleValues
��> O
.
��O P
Thin
��P T
}
��U V
,
��V W
	TopBorder
��X a
=
��b c
new
��d g
	TopBorder
��h q
(
��q r
)
��r s
{
��t u
Style
��v {
=
��| } 
BorderStyleValues��~ �
.��� �
Thin��� �
}��� �
}
�� 
)
�� 
;
�� 

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
.
��- .
Count
��. 3
=
��4 5
$num
��6 7
;
��7 8

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
=
��7 8
new
��9 <
CellStyleFormats
��= M
(
��M N
)
��N O
;
��O P

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
.
��6 7
Count
��7 <
=
��= >
$num
��? @
;
��@ A

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
.
��6 7
AppendChild
��7 B
(
��B C
new
��C F

CellFormat
��G Q
(
��Q R
)
��R S
)
��S T
;
��T U

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
=
��2 3
new
��4 7
CellFormats
��8 C
(
��C D
)
��D E
;
��E F

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
(
��L M
)
��M N
)
��N O
;
��O P

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
Count
��2 7
=
��8 9
$num
��: ;
;
��; <

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Save
��& *
(
��* +
)
��+ ,
;
��, -
Columns
�� 
columnExcel
�� #
=
��$ %
new
��& )
Columns
��* 1
(
��1 2
)
��2 3
;
��3 4
int
�� 
contadorColumn
�� "
=
��# $
$num
��% &
;
��& '
foreach
�� 
(
�� 

DataColumn
�� #
column
��$ *
in
��+ -
table
��. 3
.
��3 4
Columns
��4 ;
)
��; <
{
�� 
columnExcel
�� 
.
��  
Append
��  &
(
��& '
new
��' *
Column
��+ 1
(
��1 2
)
��2 3
{
��4 5
Min
��6 9
=
��: ;
Convert
��< C
.
��C D
ToUInt32
��D L
(
��L M
contadorColumn
��M [
)
��[ \
,
��\ ]
Max
��^ a
=
��b c
Convert
��d k
.
��k l
ToUInt32
��l t
(
��t u
contadorColumn��u �
)��� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn
�� "
++
��" $
;
��$ %
}
�� 
wsPart
�� 
.
�� 
	Worksheet
��  
.
��  !
Append
��! '
(
��' (
columnExcel
��( 3
)
��3 4
;
��4 5
var
�� 
	sheetData
�� 
=
�� 
wsPart
��  &
.
��& '
	Worksheet
��' 0
.
��0 1
AppendChild
��1 <
(
��< =
new
��= @
	SheetData
��A J
(
��J K
)
��K L
)
��L M
;
��M N
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Row
��3 6
titleRowWhite1
��7 E
=
��F G
new
��H K
DocumentFormat
��L Z
.
��Z [
OpenXml
��[ b
.
��b c
Spreadsheet
��c n
.
��n o
Row
��o r
(
��r s
)
��s t
;
��t u
	sheetData
�� 
.
�� 
AppendChild
�� %
(
��% &
titleRowWhite1
��& 4
)
��4 5
;
��5 6
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Row
��3 6
titleRow
��7 ?
=
��@ A
new
��B E
DocumentFormat
��F T
.
��T U
OpenXml
��U \
.
��\ ]
Spreadsheet
��] h
.
��h i
Row
��i l
(
��l m
)
��m n
;
��n o
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7
	cellTitle
��8 A
=
��B C
new
��D G
DocumentFormat
��H V
.
��V W
OpenXml
��W ^
.
��^ _
Spreadsheet
��_ j
.
��j k
Cell
��k o
(
��o p
)
��p q
;
��q r
	cellTitle
�� 
.
�� 
DataType
�� "
=
��# $
DocumentFormat
��% 3
.
��3 4
OpenXml
��4 ;
.
��; <
Spreadsheet
��< G
.
��G H

CellValues
��H R
.
��R S
String
��S Y
;
��Y Z
	cellTitle
�� 
.
�� 
	CellValue
�� #
=
��$ %
new
��& )
DocumentFormat
��* 8
.
��8 9
OpenXml
��9 @
.
��@ A
Spreadsheet
��A L
.
��L M
	CellValue
��M V
(
��V W
$str
��W {
+
��{ |
currentPeriod��} �
)��� �
;��� �
	cellTitle
�� 
.
�� 

StyleIndex
�� $
=
��% &
$num
��' (
;
��( )
titleRow
�� 
.
�� 
AppendChild
�� $
(
��$ %
	cellTitle
��% .
)
��. /
;
��/ 0
	sheetData
�� 
.
�� 
AppendChild
�� %
(
��% &
titleRow
��& .
)
��. /
;
��/ 0
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Row
��3 6
titleRowWhite2
��7 E
=
��F G
new
��H K
DocumentFormat
��L Z
.
��Z [
OpenXml
��[ b
.
��b c
Spreadsheet
��c n
.
��n o
Row
��o r
(
��r s
)
��s t
;
��t u
	sheetData
�� 
.
�� 
AppendChild
�� %
(
��% &
titleRowWhite2
��& 4
)
��4 5
;
��5 6

MergeCells
�� 

mergeCells
�� %
=
��& '
new
��( +

MergeCells
��, 6
(
��6 7
)
��7 8
;
��8 9

mergeCells
�� 
.
�� 
Append
�� !
(
��! "
new
��" %
	MergeCell
��& /
(
��/ 0
)
��0 1
{
��2 3
	Reference
��4 =
=
��> ?
new
��@ C
StringValue
��D O
(
��O P
$str
��P W
)
��W X
}
��Y Z
)
��Z [
;
��[ \
wsPart
�� 
.
�� 
	Worksheet
��  
.
��  !
InsertAfter
��! ,
(
��, -

mergeCells
��- 7
,
��7 8
wsPart
��9 ?
.
��? @
	Worksheet
��@ I
.
��I J
Elements
��J R
<
��R S
	SheetData
��S \
>
��\ ]
(
��] ^
)
��^ _
.
��_ `
First
��` e
(
��e f
)
��f g
)
��g h
;
��h i
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Row
��3 6
	headerRow
��7 @
=
��A B
new
��C F
DocumentFormat
��G U
.
��U V
OpenXml
��V ]
.
��] ^
Spreadsheet
��^ i
.
��i j
Row
��j m
(
��m n
)
��n o
;
��o p
List
�� 
<
�� 
String
�� 
>
�� 
columns
�� $
=
��% &
new
��' *
List
��+ /
<
��/ 0
string
��0 6
>
��6 7
(
��7 8
)
��8 9
;
��9 :
foreach
�� 
(
�� 

DataColumn
�� #
column
��$ *
in
��+ -
table
��. 3
.
��3 4
Columns
��4 ;
)
��; <
{
�� 
if
�� 
(
�� 
column
�� 
.
�� 

ColumnName
�� )
!=
��* ,
$str
��- 6
)
��6 7
{
�� 
columns
�� 
.
��  
Add
��  #
(
��# $
column
��$ *
.
��* +

ColumnName
��+ 5
)
��5 6
;
��6 7
DocumentFormat
�� &
.
��& '
OpenXml
��' .
.
��. /
Spreadsheet
��/ :
.
��: ;
Cell
��; ?
cell
��@ D
=
��E F
new
��G J
DocumentFormat
��K Y
.
��Y Z
OpenXml
��Z a
.
��a b
Spreadsheet
��b m
.
��m n
Cell
��n r
(
��r s
)
��s t
;
��t u
cell
�� 
.
�� 
DataType
�� %
=
��& '
DocumentFormat
��( 6
.
��6 7
OpenXml
��7 >
.
��> ?
Spreadsheet
��? J
.
��J K

CellValues
��K U
.
��U V
String
��V \
;
��\ ]
cell
�� 
.
�� 
	CellValue
�� &
=
��' (
new
��) ,
DocumentFormat
��- ;
.
��; <
OpenXml
��< C
.
��C D
Spreadsheet
��D O
.
��O P
	CellValue
��P Y
(
��Y Z
column
��Z `
.
��` a

ColumnName
��a k
)
��k l
;
��l m
cell
�� 
.
�� 

StyleIndex
�� '
=
��( )
$num
��* +
;
��+ ,
	headerRow
�� !
.
��! "
AppendChild
��" -
(
��- .
cell
��. 2
)
��2 3
;
��3 4
}
�� 
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� %
(
��% &
	headerRow
��& /
)
��/ 0
;
��0 1
foreach
�� 
(
�� 
DataRow
��  
dsrow
��! &
in
��' )
table
��* /
.
��/ 0
Rows
��0 4
)
��4 5
{
�� 
DocumentFormat
�� "
.
��" #
OpenXml
��# *
.
��* +
Spreadsheet
��+ 6
.
��6 7
Row
��7 :
newRow
��; A
=
��B C
new
��D G
DocumentFormat
��H V
.
��V W
OpenXml
��W ^
.
��^ _
Spreadsheet
��_ j
.
��j k
Row
��k n
(
��n o
)
��o p
;
��p q
bool
�� 
bisgroup
�� !
=
��" #
dsrow
��$ )
[
��) *
$str
��* 3
]
��3 4
.
��4 5
ToString
��5 =
(
��= >
)
��> ?
==
��@ B
$str
��C F
?
��G H
true
��I M
:
��N O
false
��P U
;
��U V
foreach
�� 
(
�� 
String
�� #
col
��$ '
in
��( *
columns
��+ 2
)
��2 3
{
�� 
DocumentFormat
�� &
.
��& '
OpenXml
��' .
.
��. /
Spreadsheet
��/ :
.
��: ;
Cell
��; ?
cell
��@ D
=
��E F
new
��G J
DocumentFormat
��K Y
.
��Y Z
OpenXml
��Z a
.
��a b
Spreadsheet
��b m
.
��m n
Cell
��n r
(
��r s
)
��s t
;
��t u
if
�� 
(
�� 
col
�� 
!=
��  "
$str
��# )
)
��) *
{
�� 
cell
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cell
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
dsrow
��^ c
[
��c d
col
��d g
]
��g h
.
��h i
ToString
��i q
(
��q r
)
��r s
)
��s t
;
��t u
}
�� 
else
�� 
{
�� 
cell
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cell
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
dsrow
��^ c
[
��c d
col
��d g
]
��g h
.
��h i
ToString
��i q
(
��q r
)
��r s
)
��s t
;
��t u
}
�� 
if
�� 
(
�� 
bisgroup
�� $
)
��$ %
cell
��  
.
��  !

StyleIndex
��! +
=
��, -
$num
��. /
;
��/ 0
else
�� 
cell
��  
.
��  !

StyleIndex
��! +
=
��, -
$num
��. /
;
��/ 0
newRow
�� 
.
�� 
AppendChild
�� *
(
��* +
cell
��+ /
)
��/ 0
;
��0 1
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� )
(
��) *
newRow
��* 0
)
��0 1
;
��1 2
}
�� 
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Row
��3 6
footerRowWhite1
��7 F
=
��G H
new
��I L
DocumentFormat
��M [
.
��[ \
OpenXml
��\ c
.
��c d
Spreadsheet
��d o
.
��o p
Row
��p s
(
��s t
)
��t u
;
��u v
	sheetData
�� 
.
�� 
AppendChild
�� %
(
��% &
footerRowWhite1
��& 5
)
��5 6
;
��6 7
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Row
��3 6
totalRow
��7 ?
=
��@ A
new
��B E
DocumentFormat
��F T
.
��T U
OpenXml
��U \
.
��\ ]
Spreadsheet
��] h
.
��h i
Row
��i l
(
��l m
)
��m n
;
��n o
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7
cellTotalGrupoFe
��8 H
=
��I J
new
��K N
DocumentFormat
��O ]
.
��] ^
OpenXml
��^ e
.
��e f
Spreadsheet
��f q
.
��q r
Cell
��r v
(
��v w
)
��w x
;
��x y
cellTotalGrupoFe
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cellTotalGrupoFe
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
$str
��^ n
)
��n o
;
��o p
cellTotalGrupoFe
��  
.
��  !

StyleIndex
��! +
=
��, -
$num
��. /
;
��/ 0
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7%
cellPreviousExecAmount2
��8 O
=
��P Q
new
��R U
DocumentFormat
��V d
.
��d e
OpenXml
��e l
.
��l m
Spreadsheet
��m x
.
��x y
Cell
��y }
(
��} ~
)
��~ 
;�� �%
cellPreviousExecAmount2
�� '
.
��' (
DataType
��( 0
=
��1 2
DocumentFormat
��3 A
.
��A B
OpenXml
��B I
.
��I J
Spreadsheet
��J U
.
��U V

CellValues
��V `
.
��` a
String
��a g
;
��g h%
cellPreviousExecAmount2
�� '
.
��' (
	CellValue
��( 1
=
��2 3
new
��4 7
DocumentFormat
��8 F
.
��F G
OpenXml
��G N
.
��N O
Spreadsheet
��O Z
.
��Z [
	CellValue
��[ d
(
��d e
String
��e k
.
��k l
Format
��l r
(
��r s
$str
��s z
,
��z {'
totalPreviousExecAmount2��| �
)��� �
)��� �
;��� �%
cellPreviousExecAmount2
�� '
.
��' (

StyleIndex
��( 2
=
��3 4
$num
��5 6
;
��6 7
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7%
cellPreviousExecAmount1
��8 O
=
��P Q
new
��R U
DocumentFormat
��V d
.
��d e
OpenXml
��e l
.
��l m
Spreadsheet
��m x
.
��x y
Cell
��y }
(
��} ~
)
��~ 
;�� �%
cellPreviousExecAmount1
�� '
.
��' (
DataType
��( 0
=
��1 2
DocumentFormat
��3 A
.
��A B
OpenXml
��B I
.
��I J
Spreadsheet
��J U
.
��U V

CellValues
��V `
.
��` a
String
��a g
;
��g h%
cellPreviousExecAmount1
�� '
.
��' (
	CellValue
��( 1
=
��2 3
new
��4 7
DocumentFormat
��8 F
.
��F G
OpenXml
��G N
.
��N O
Spreadsheet
��O Z
.
��Z [
	CellValue
��[ d
(
��d e
String
��e k
.
��k l
Format
��l r
(
��r s
$str
��s z
,
��z {'
totalPreviousExecAmount1��| �
)��� �
)��� �
;��� �%
cellPreviousExecAmount1
�� '
.
��' (

StyleIndex
��( 2
=
��3 4
$num
��5 6
;
��6 7
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7$
cellPreviousExecAmount
��8 N
=
��O P
new
��Q T
DocumentFormat
��U c
.
��c d
OpenXml
��d k
.
��k l
Spreadsheet
��l w
.
��w x
Cell
��x |
(
��| }
)
��} ~
;
��~ $
cellPreviousExecAmount
�� &
.
��& '
DataType
��' /
=
��0 1
DocumentFormat
��2 @
.
��@ A
OpenXml
��A H
.
��H I
Spreadsheet
��I T
.
��T U

CellValues
��U _
.
��_ `
String
��` f
;
��f g$
cellPreviousExecAmount
�� &
.
��& '
	CellValue
��' 0
=
��1 2
new
��3 6
DocumentFormat
��7 E
.
��E F
OpenXml
��F M
.
��M N
Spreadsheet
��N Y
.
��Y Z
	CellValue
��Z c
(
��c d
String
��d j
.
��j k
Format
��k q
(
��q r
$str
��r y
,
��y z&
totalPreviousExecAmount��{ �
)��� �
)��� �
;��� �$
cellPreviousExecAmount
�� &
.
��& '

StyleIndex
��' 1
=
��2 3
$num
��4 5
;
��5 6
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7#
cellCurrentExecAmount
��8 M
=
��N O
new
��P S
DocumentFormat
��T b
.
��b c
OpenXml
��c j
.
��j k
Spreadsheet
��k v
.
��v w
Cell
��w {
(
��{ |
)
��| }
;
��} ~#
cellCurrentExecAmount
�� %
.
��% &
DataType
��& .
=
��/ 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T

CellValues
��T ^
.
��^ _
String
��_ e
;
��e f#
cellCurrentExecAmount
�� %
.
��% &
	CellValue
��& /
=
��0 1
new
��2 5
DocumentFormat
��6 D
.
��D E
OpenXml
��E L
.
��L M
Spreadsheet
��M X
.
��X Y
	CellValue
��Y b
(
��b c
String
��c i
.
��i j
Format
��j p
(
��p q
$str
��q x
,
��x y%
totalCurrentExecAmount��z �
)��� �
)��� �
;��� �#
cellCurrentExecAmount
�� %
.
��% &

StyleIndex
��& 0
=
��1 2
$num
��3 4
;
��4 5
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7 
cellPreviousAmount
��8 J
=
��K L
new
��M P
DocumentFormat
��Q _
.
��_ `
OpenXml
��` g
.
��g h
Spreadsheet
��h s
.
��s t
Cell
��t x
(
��x y
)
��y z
;
��z { 
cellPreviousAmount
�� "
.
��" #
DataType
��# +
=
��, -
DocumentFormat
��. <
.
��< =
OpenXml
��= D
.
��D E
Spreadsheet
��E P
.
��P Q

CellValues
��Q [
.
��[ \
String
��\ b
;
��b c 
cellPreviousAmount
�� "
.
��" #
	CellValue
��# ,
=
��- .
new
��/ 2
DocumentFormat
��3 A
.
��A B
OpenXml
��B I
.
��I J
Spreadsheet
��J U
.
��U V
	CellValue
��V _
(
��_ `
String
��` f
.
��f g
Format
��g m
(
��m n
$str
��n u
,
��u v"
totalPreviousAmount��w �
)��� �
)��� �
;��� � 
cellPreviousAmount
�� "
.
��" #

StyleIndex
��# -
=
��. /
$num
��0 1
;
��1 2
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7
cellCurrentAmount
��8 I
=
��J K
new
��L O
DocumentFormat
��P ^
.
��^ _
OpenXml
��_ f
.
��f g
Spreadsheet
��g r
.
��r s
Cell
��s w
(
��w x
)
��x y
;
��y z
cellCurrentAmount
�� !
.
��! "
DataType
��" *
=
��+ ,
DocumentFormat
��- ;
.
��; <
OpenXml
��< C
.
��C D
Spreadsheet
��D O
.
��O P

CellValues
��P Z
.
��Z [
String
��[ a
;
��a b
cellCurrentAmount
�� !
.
��! "
	CellValue
��" +
=
��, -
new
��. 1
DocumentFormat
��2 @
.
��@ A
OpenXml
��A H
.
��H I
Spreadsheet
��I T
.
��T U
	CellValue
��U ^
(
��^ _
String
��_ e
.
��e f
Format
��f l
(
��l m
$str
��m t
,
��t u!
totalCurrentAmount��v �
)��� �
)��� �
;��� �
cellCurrentAmount
�� !
.
��! "

StyleIndex
��" ,
=
��- .
$num
��/ 0
;
��0 1
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7
cellVariationPorc
��8 I
=
��J K
new
��L O
DocumentFormat
��P ^
.
��^ _
OpenXml
��_ f
.
��f g
Spreadsheet
��g r
.
��r s
Cell
��s w
(
��w x
)
��x y
;
��y z
cellVariationPorc
�� !
.
��! "
DataType
��" *
=
��+ ,
DocumentFormat
��- ;
.
��; <
OpenXml
��< C
.
��C D
Spreadsheet
��D O
.
��O P

CellValues
��P Z
.
��Z [
String
��[ a
;
��a b
cellVariationPorc
�� !
.
��! "
	CellValue
��" +
=
��, -
new
��. 1
DocumentFormat
��2 @
.
��@ A
OpenXml
��A H
.
��H I
Spreadsheet
��I T
.
��T U
	CellValue
��U ^
(
��^ _
String
��_ e
.
��e f
Format
��f l
(
��l m
$str
��m t
,
��t u!
totalVariationPorc��v �
)��� �
+��� �
$str��� �
)��� �
;��� �
cellVariationPorc
�� !
.
��! "

StyleIndex
��" ,
=
��- .
$num
��/ 0
;
��0 1
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Cell
��3 7!
cellVariationAmount
��8 K
=
��L M
new
��N Q
DocumentFormat
��R `
.
��` a
OpenXml
��a h
.
��h i
Spreadsheet
��i t
.
��t u
Cell
��u y
(
��y z
)
��z {
;
��{ |!
cellVariationAmount
�� #
.
��# $
DataType
��$ ,
=
��- .
DocumentFormat
��/ =
.
��= >
OpenXml
��> E
.
��E F
Spreadsheet
��F Q
.
��Q R

CellValues
��R \
.
��\ ]
String
��] c
;
��c d!
cellVariationAmount
�� #
.
��# $
	CellValue
��$ -
=
��. /
new
��0 3
DocumentFormat
��4 B
.
��B C
OpenXml
��C J
.
��J K
Spreadsheet
��K V
.
��V W
	CellValue
��W `
(
��` a
String
��a g
.
��g h
Format
��h n
(
��n o
$str
��o v
,
��v w#
totalVariationAmount��x �
)��� �
)��� �
;��� �!
cellVariationAmount
�� #
.
��# $

StyleIndex
��$ .
=
��/ 0
$num
��1 2
;
��2 3
totalRow
�� 
.
�� 
Append
�� 
(
��  
cellTotalGrupoFe
��  0
,
��0 1%
cellPreviousExecAmount2
��1 H
,
��H I%
cellPreviousExecAmount1
��J a
,
��a b$
cellPreviousExecAmount
��c y
,
��y z$
cellCurrentExecAmount��{ �
,��� �"
cellPreviousAmount��� �
,��� �!
cellCurrentAmount��� �
,��� �!
cellVariationPorc��� �
,��� �#
cellVariationAmount��� �
)��� �
;��� �
	sheetData
�� 
.
�� 
AppendChild
�� %
(
��% &
totalRow
��& .
)
��. /
;
��/ 0
wsPart
�� 
.
�� 
	Worksheet
��  
.
��  !
Save
��! %
(
��% &
)
��& '
;
��' (
var
�� 
sheets
�� 
=
�� 
spreadsheet
�� (
.
��( )
WorkbookPart
��) 5
.
��5 6
Workbook
��6 >
.
��> ?
AppendChild
��? J
(
��J K
new
��K N
Sheets
��O U
(
��U V
)
��V W
)
��W X
;
��X Y
sheets
�� 
.
�� 
AppendChild
�� "
(
��" #
new
��# &
Sheet
��' ,
(
��, -
)
��- .
{
��/ 0
Id
��1 3
=
��4 5
spreadsheet
��6 A
.
��A B
WorkbookPart
��B N
.
��N O
GetIdOfPart
��O Z
(
��Z [
wsPart
��[ a
)
��a b
,
��b c
SheetId
��d k
=
��l m
$num
��n o
,
��o p
Name
��q u
=
��v w
$str��x �
}��� �
)��� �
;��� �
spreadsheet
�� 
.
�� 
WorkbookPart
�� (
.
��( )
Workbook
��) 1
.
��1 2
Save
��2 6
(
��6 7
)
��7 8
;
��8 9
}
�� 
}
�� 	
public
�� 
static
�� 
void
�� "
EconomicConditionXLS
�� /
(
��/ 0
	DataTable
��0 9
table
��: ?
,
��? @
string
��A G
destination
��H S
)
��S T
{
�� 	
using
�� 
(
�� 
var
�� 
spreadsheet
�� "
=
��# $!
SpreadsheetDocument
��% 8
.
��8 9
Create
��9 ?
(
��? @
destination
��@ K
,
��K L%
SpreadsheetDocumentType
��M d
.
��d e
Workbook
��e m
)
��m n
)
��n o
{
�� 
spreadsheet
�� 
.
�� 
AddWorkbookPart
�� +
(
��+ ,
)
��, -
;
��- .
spreadsheet
�� 
.
�� 
WorkbookPart
�� (
.
��( )
Workbook
��) 1
=
��2 3
new
��4 7
Workbook
��8 @
(
��@ A
)
��A B
;
��B C
var
�� 
wsPart
�� 
=
�� 
spreadsheet
�� (
.
��( )
WorkbookPart
��) 5
.
��5 6

AddNewPart
��6 @
<
��@ A
WorksheetPart
��A N
>
��N O
(
��O P
)
��P Q
;
��Q R
wsPart
�� 
.
�� 
	Worksheet
��  
=
��! "
new
��# &
	Worksheet
��' 0
(
��0 1
)
��1 2
;
��2 3
var
�� 

stylesPart
�� 
=
��  
spreadsheet
��! ,
.
��, -
WorkbookPart
��- 9
.
��9 :

AddNewPart
��: D
<
��D E 
WorkbookStylesPart
��E W
>
��W X
(
��X Y
)
��Y Z
;
��Z [

stylesPart
�� 
.
�� 

Stylesheet
�� %
=
��& '
new
��( +

Stylesheet
��, 6
(
��6 7
)
��7 8
;
��8 9
Font
�� 
font
�� 
=
�� 
new
�� 
Font
��  $
(
��$ %
)
��% &
;
��& '
font
�� 
.
�� 
Append
�� 
(
�� 
new
�� 
Color
��  %
(
��% &
)
��& '
{
��( )
Rgb
��* -
=
��. /
$str
��0 8
}
��9 :
)
��: ;
;
��; <
font
�� 
.
�� 
Append
�� 
(
�� 
new
�� 
Bold
��  $
(
��$ %
)
��% &
)
��& '
;
��' (

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
=
��, -
new
��. 1
Fonts
��2 7
(
��7 8
)
��8 9
;
��9 :

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
Count
��, 1
=
��2 3
$num
��4 5
;
��5 6

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
font
��8 <
)
��< =
;
��= >

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
}
��j k
)
��k l
;
��l m

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
,
��j k
Bold
��k o
=
��p q
new
��r u
Bold
��v z
(
��z {
)
��{ |
}
��} ~
)
��~ 
;�� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
=
��, -
new
��. 1
Fills
��2 7
(
��7 8
)
��8 9
;
��9 :
var
�� 
solidRed
�� 
=
�� 
new
�� "
PatternFill
��# .
(
��. /
)
��/ 0
{
��1 2
PatternType
��3 >
=
��? @
PatternValues
��A N
.
��N O
Solid
��O T
}
��U V
;
��V W
solidRed
�� 
.
�� 
ForegroundColor
�� (
=
��) *
new
��+ .
ForegroundColor
��/ >
{
��? @
Rgb
��A D
=
��E F
HexBinaryValue
��G U
.
��U V

FromString
��V `
(
��` a
$str
��a i
)
��i j
}
��k l
;
��l m
solidRed
�� 
.
�� 
BackgroundColor
�� (
=
��) *
new
��+ .
BackgroundColor
��/ >
{
��? @
Indexed
��A H
=
��I J
$num
��K M
}
��N O
;
��O P
var
�� 
	fondogris
�� 
=
�� 
new
��  #
PatternFill
��$ /
(
��/ 0
)
��0 1
{
��2 3
PatternType
��4 ?
=
��@ A
PatternValues
��B O
.
��O P
Solid
��P U
}
��V W
;
��W X
	fondogris
�� 
.
�� 
ForegroundColor
�� )
=
��* +
new
��, /
ForegroundColor
��0 ?
{
��@ A
Rgb
��B E
=
��F G
HexBinaryValue
��H V
.
��V W

FromString
��W a
(
��a b
$str
��b j
)
��j k
}
��l m
;
��m n
	fondogris
�� 
.
�� 
BackgroundColor
�� )
=
��* +
new
��, /
BackgroundColor
��0 ?
{
��@ A
Indexed
��B I
=
��J K
$num
��L N
}
��O P
;
��P Q
var
�� 
fondoceleste
��  
=
��! "
new
��# &
PatternFill
��' 2
(
��2 3
)
��3 4
{
��5 6
PatternType
��7 B
=
��C D
PatternValues
��E R
.
��R S
Solid
��S X
}
��Y Z
;
��Z [
fondoceleste
�� 
.
�� 
ForegroundColor
�� ,
=
��- .
new
��/ 2
ForegroundColor
��3 B
{
��C D
Rgb
��E H
=
��I J
HexBinaryValue
��K Y
.
��Y Z

FromString
��Z d
(
��d e
$str
��e m
)
��m n
}
��o p
;
��p q
fondoceleste
�� 
.
�� 
BackgroundColor
�� ,
=
��- .
new
��/ 2
BackgroundColor
��3 B
{
��C D
Indexed
��E L
=
��M N
$num
��O Q
}
��R S
;
��S T
var
�� 
fondoamarillo
�� !
=
��" #
new
��$ '
PatternFill
��( 3
(
��3 4
)
��4 5
{
��6 7
PatternType
��8 C
=
��D E
PatternValues
��F S
.
��S T
Solid
��T Y
}
��Z [
;
��[ \
fondoamarillo
�� 
.
�� 
ForegroundColor
�� -
=
��. /
new
��0 3
ForegroundColor
��4 C
{
��D E
Rgb
��F I
=
��J K
HexBinaryValue
��L Z
.
��Z [

FromString
��[ e
(
��e f
$str
��f n
)
��n o
}
��p q
;
��q r
fondoamarillo
�� 
.
�� 
BackgroundColor
�� -
=
��. /
new
��0 3
BackgroundColor
��4 C
{
��D E
Indexed
��F M
=
��N O
$num
��P R
}
��S T
;
��T U
var
�� 
fondoverdeclaro
�� #
=
��$ %
new
��& )
PatternFill
��* 5
(
��5 6
)
��6 7
{
��8 9
PatternType
��: E
=
��F G
PatternValues
��H U
.
��U V
Solid
��V [
}
��\ ]
;
��] ^
fondoverdeclaro
�� 
.
��  
ForegroundColor
��  /
=
��0 1
new
��2 5
ForegroundColor
��6 E
{
��F G
Rgb
��H K
=
��L M
HexBinaryValue
��N \
.
��\ ]

FromString
��] g
(
��g h
$str
��h p
)
��p q
}
��r s
;
��s t
fondoverdeclaro
�� 
.
��  
BackgroundColor
��  /
=
��0 1
new
��2 5
BackgroundColor
��6 E
{
��F G
Indexed
��H O
=
��P Q
$num
��R T
}
��U V
;
��V W
var
�� 
fondoverdeoscuro
�� $
=
��% &
new
��' *
PatternFill
��+ 6
(
��6 7
)
��7 8
{
��9 :
PatternType
��; F
=
��G H
PatternValues
��I V
.
��V W
Solid
��W \
}
��] ^
;
��^ _
fondoverdeoscuro
��  
.
��  !
ForegroundColor
��! 0
=
��1 2
new
��3 6
ForegroundColor
��7 F
{
��G H
Rgb
��I L
=
��M N
HexBinaryValue
��O ]
.
��] ^

FromString
��^ h
(
��h i
$str
��i q
)
��q r
}
��s t
;
��t u
fondoverdeoscuro
��  
.
��  !
BackgroundColor
��! 0
=
��1 2
new
��3 6
BackgroundColor
��7 F
{
��G H
Indexed
��I P
=
��Q R
$num
��S U
}
��V W
;
��W X

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
new
��Q T
PatternFill
��U `
{
��a b
PatternType
��c n
=
��o p
PatternValues
��q ~
.
��~ 
None�� �
}��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
new
��Q T
PatternFill
��U `
{
��a b
PatternType
��c n
=
��o p
PatternValues
��q ~
.
��~ 
Gray125�� �
}��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
solidRed
��Q Y
}
��Z [
)
��[ \
;
��\ ]

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
	fondogris
��Q Z
}
��[ \
)
��\ ]
;
��] ^

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
fondoceleste
��Q ]
}
��^ _
)
��_ `
;
��` a

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
fondoamarillo
��Q ^
}
��_ `
)
��` a
;
��a b

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
fondoverdeclaro
��Q `
}
��a b
)
��b c
;
��c d

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Fill
��< @
{
��A B
PatternFill
��C N
=
��O P
fondoverdeoscuro
��Q a
}
��b c
)
��c d
;
��d e

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
.
��+ ,
Count
��, 1
=
��2 3
$num
��4 5
;
��5 6

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
=
��. /
new
��0 3
Borders
��4 ;
(
��; <
)
��< =
;
��= >

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
.
��- .
AppendChild
��. 9
(
��9 :
new
��: =
Border
��> D
(
��D E
)
��E F
)
��F G
;
��G H

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
.
��- .
AppendChild
��. 9
(
��9 :
new
��: =
Border
��> D
(
��D E
)
��E F
{
�� 

LeftBorder
�� 
=
��  
new
��! $

LeftBorder
��% /
(
��/ 0
)
��0 1
{
��2 3
Style
��4 9
=
��: ;
BorderStyleValues
��< M
.
��M N
Thin
��N R
}
��S T
,
��T U
RightBorder
�� 
=
��  !
new
��" %
RightBorder
��& 1
(
��1 2
)
��2 3
{
��4 5
Style
��6 ;
=
��< =
BorderStyleValues
��> O
.
��O P
Thin
��P T
}
��U V
,
�� 
BottomBorder
��  
=
��! "
new
��# &
BottomBorder
��' 3
(
��3 4
)
��4 5
{
��6 7
Style
��8 =
=
��> ?
BorderStyleValues
��@ Q
.
��Q R
Thin
��R V
}
��W X
,
��X Y
	TopBorder
�� 
=
�� 
new
��  #
	TopBorder
��$ -
(
��- .
)
��. /
{
��0 1
Style
��2 7
=
��8 9
BorderStyleValues
��: K
.
��K L
Thin
��L P
}
��Q R
}
�� 
)
�� 
;
�� 

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Borders
��& -
.
��- .
Count
��. 3
=
��4 5
$num
��6 7
;
��7 8

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
=
��7 8
new
��9 <
CellStyleFormats
��= M
(
��M N
)
��N O
;
��O P

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
.
��6 7
Count
��7 <
=
��= >
$num
��? @
;
��@ A

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellStyleFormats
��& 6
.
��6 7
AppendChild
��7 B
(
��B C
new
��C F

CellFormat
��G Q
(
��Q R
)
��R S
)
��S T
;
��T U

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
=
��2 3
new
��4 7
CellFormats
��8 C
(
��C D
)
��D E
;
��E F

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
(
��L M
)
��M N
)
��N O
;
��O P

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Left��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
,��� �
WrapText��� �
=��� �
true��� �
,��� �
Vertical��� �
=��� �'
VerticalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
ApplyNumberFormat
��O `
=
��` a
true
��a e
,
��e f
NumberFormatId
��g u
=
��u v
$num
��v w
,
��w x
FormatId��y �
=��� �
$num��� �
,��� �
FontId��� �
=��� �
$num��� �
,��� �
BorderId��� �
=��� �
$num��� �
,��� �
FillId��� �
=��� �
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Right��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Right��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
ApplyNumberFormat
��O `
=
��` a
true
��a e
,
��e f
NumberFormatId
��g u
=
��u v
$num
��w y
,
��y z
FormatId��{ �
=��� �
$num��� �
,��� �
FontId��� �
=��� �
$num��� �
,��� �
BorderId��� �
=��� �
$num��� �
,��� �
FillId��� �
=��� �
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
,��� �
Vertical��� �
=��� �'
VerticalAlignmentValues��� �
.��� �
Center��� �
,��� �
WrapText��� �
=��� �
true��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
,��� �
Vertical��� �
=��� �'
VerticalAlignmentValues��� �
.��� �
Center��� �
,��� �
WrapText��� �
=��� �
true��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
,��� �
Vertical��� �
=��� �'
VerticalAlignmentValues��� �
.��� �
Center��� �
,��� �
WrapText��� �
=��� �
true��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
AppendChild
��2 =
(
��= >
new
��> A

CellFormat
��B L
{
��M N
FormatId
��O W
=
��X Y
$num
��Z [
,
��[ \
FontId
��] c
=
��d e
$num
��f g
,
��g h
BorderId
��i q
=
��r s
$num
��t u
,
��u v
FillId
��w }
=
��~ 
$num��� �
,��� �
	ApplyFill��� �
=��� �
true��� �
}��� �
)��� �
.��� �
AppendChild��� �
(��� �
new��� �
	Alignment��� �
{��� �

Horizontal��� �
=��� �)
HorizontalAlignmentValues��� �
.��� �
Center��� �
,��� �
Vertical��� �
=��� �'
VerticalAlignmentValues��� �
.��� �
Center��� �
,��� �
WrapText��� �
=��� �
true��� �
}��� �
)��� �
;��� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
CellFormats
��& 1
.
��1 2
Count
��2 7
=
��8 9
$num
��: ;
;
��; <

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Save
��& *
(
��* +
)
��+ ,
;
��, -
Columns
�� 
columnExcel
�� #
=
��$ %
new
��& )
Columns
��* 1
(
��1 2
)
��2 3
;
��3 4
int
�� 
contadorColumn
�� "
=
��# $
$num
��% &
;
��& '
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
columnExcel
�� 
.
�� 
Append
�� "
(
��" #
new
��# &
Column
��' -
(
��- .
)
��. /
{
��0 1
Min
��2 5
=
��6 7
Convert
��8 ?
.
��? @
ToUInt32
��@ H
(
��H I
contadorColumn
��I W
)
��W X
,
��X Y
Max
��Z ]
=
��^ _
Convert
��` g
.
��g h
ToUInt32
��h p
(
��p q
contadorColumn
��q 
)�� �
,��� �
Width��� �
=��� �
$num��� �
,��� �
CustomWidth��� �
=��� �
true��� �
}��� �
)��� �
;��� �
contadorColumn��� �
++��� �
;��� �
wsPart
�� 
.
�� 
	Worksheet
��  
.
��  !
Append
��! '
(
��' (
columnExcel
��( 3
)
��3 4
;
��4 5
var
�� 
	sheetData
�� 
=
�� 
wsPart
��  &
.
��& '
	Worksheet
��' 0
.
��0 1
AppendChild
��1 <
(
��< =
new
��= @
	SheetData
��A J
(
��J K
)
��K L
)
��L M
;
��M N
DocumentFormat
�� 
.
�� 
OpenXml
�� &
.
��& '
Spreadsheet
��' 2
.
��2 3
Row
��3 6
	headerRow
��7 @
=
��A B
new
��C F
DocumentFormat
��G U
.
��U V
OpenXml
��V ]
.
��] ^
Spreadsheet
��^ i
.
��i j
Row
��j m
(
��m n
)
��n o
;
��o p
List
�� 
<
�� 
String
�� 
>
�� 
columns
�� $
=
��% &
new
��' *
List
��+ /
<
��/ 0
string
��0 6
>
��6 7
(
��7 8
)
��8 9
;
��9 :
List
�� 
<
�� 
string
�� 
>
�� 
columnasstring
�� +
=
��, -
new
��. 1
List
��2 6
<
��6 7
string
��7 =
>
��= >
(
��> ?
)
��? @
;
��@ A
columnasstring
�� 
.
�� 
Add
�� "
(
��" #
$str
��# +
)
��+ ,
;
��, -
columnasstring
�� 
.
�� 
Add
�� "
(
��" #
$str
��# 0
)
��0 1
;
��1 2
columnasstring
�� 
.
�� 
Add
�� "
(
��" #
$str
��# *
)
��* +
;
��+ ,
columnasstring
�� 
.
�� 
Add
�� "
(
��" #
$str
��# )
)
��) *
;
��* +
columnasstring
�� 
.
�� 
Add
�� "
(
��" #
$str
��# .
)
��. /
;
��/ 0
List
�� 
<
�� 
string
�� 
>
�� 
columnascelestes
�� -
=
��. /
new
��0 3
List
��4 8
<
��8 9
string
��9 ?
>
��? @
(
��@ A
)
��A B
;
��B C
columnascelestes
��  
.
��  !
Add
��! $
(
��$ %
$"
��% '
$str
��' 1
"
��1 2
)
��2 3
;
��3 4
columnascelestes
��  
.
��  !
Add
��! $
(
��$ %
$"
��% '
$str
��' 6
"
��6 7
)
��7 8
;
��8 9
columnascelestes
��  
.
��  !
Add
��! $
(
��$ %
$"
��% '
$str
��' 3
"
��3 4
)
��4 5
;
��5 6
columnascelestes
��  
.
��  !
Add
��! $
(
��$ %
$"
��% '
$str
��' +
"
��+ ,
)
��, -
;
��- .
columnascelestes
��  
.
��  !
Add
��! $
(
��$ %
$"
��% '
$str
��' 8
"
��8 9
)
��9 :
;
��: ;
columnascelestes
��  
.
��  !
Add
��! $
(
��$ %
$"
��% '
$str
��' 2
"
��2 3
)
��3 4
;
��4 5
columnascelestes
��  
.
��  !
Add
��! $
(
��$ %
$"
��% '
$str
��' 1
"
��1 2
)
��2 3
;
��3 4
columnascelestes
��  
.
��  !
Add
��! $
(
��$ %
$"
��% '
$str
��' 2
"
��2 3
)
��3 4
;
��4 5
List
�� 
<
�� 
string
�� 
>
�� 
columnasamarillas
�� .
=
��/ 0
new
��1 4
List
��5 9
<
��9 :
string
��: @
>
��@ A
(
��A B
)
��B C
;
��C D
columnasamarillas
�� !
.
��! "
Add
��" %
(
��% &
$"
��& (
$str
��( ;
"
��; <
)
��< =
;
��= >
columnasamarillas
�� !
.
��! "
Add
��" %
(
��% &
$"
��& (
$str
��( ;
"
��; <
)
��< =
;
��= >
List
�� 
<
�� 
string
�� 
>
��  
columnasverdeclaro
�� /
=
��0 1
new
��2 5
List
��6 :
<
��: ;
string
��; A
>
��A B
(
��B C
)
��C D
;
��D E 
columnasverdeclaro
�� "
.
��" #
Add
��# &
(
��& '
$"
��' )
$str
��) 5
"
��5 6
)
��6 7
;
��7 8 
columnasverdeclaro
�� "
.
��" #
Add
��# &
(
��& '
$"
��' )
$str
��) :
"
��: ;
)
��; <
;
��< = 
columnasverdeclaro
�� "
.
��" #
Add
��# &
(
��& '
$"
��' )
$str
��) 7
"
��7 8
)
��8 9
;
��9 : 
columnasverdeclaro
�� "
.
��" #
Add
��# &
(
��& '
$"
��' )
$str
��) /
"
��/ 0
)
��0 1
;
��1 2 
columnasverdeclaro
�� "
.
��" #
Add
��# &
(
��& '
$"
��' )
$str
��) <
"
��< =
)
��= >
;
��> ? 
columnasverdeclaro
�� "
.
��" #
Add
��# &
(
��& '
$"
��' )
$str
��) 6
"
��6 7
)
��7 8
;
��8 9 
columnasverdeclaro
�� "
.
��" #
Add
��# &
(
��& '
$"
��' )
$str
��) 5
"
��5 6
)
��6 7
;
��7 8 
columnasverdeclaro
�� "
.
��" #
Add
��# &
(
��& '
$"
��' )
$str
��) 6
"
��6 7
)
��7 8
;
��8 9
List
�� 
<
�� 
string
�� 
>
�� !
columnasverdeoscuro
�� 0
=
��1 2
new
��3 6
List
��7 ;
<
��; <
string
��< B
>
��B C
(
��C D
)
��D E
;
��E F!
columnasverdeoscuro
�� #
.
��# $
Add
��$ '
(
��' (
$"
��( *
$str
��* 4
"
��4 5
)
��5 6
;
��6 7!
columnasverdeoscuro
�� #
.
��# $
Add
��$ '
(
��' (
$"
��( *
$str
��* 9
"
��9 :
)
��: ;
;
��; <
foreach
�� 
(
�� 

DataColumn
�� #
column
��$ *
in
��+ -
table
��. 3
.
��3 4
Columns
��4 ;
)
��; <
{
�� 
columns
�� 
.
�� 
Add
�� 
(
��  
column
��  &
.
��& '

ColumnName
��' 1
)
��1 2
;
��2 3
DocumentFormat
�� "
.
��" #
OpenXml
��# *
.
��* +
Spreadsheet
��+ 6
.
��6 7
Cell
��7 ;
newcell
��< C
=
��D E
new
��F I
DocumentFormat
��J X
.
��X Y
OpenXml
��Y `
.
��` a
Spreadsheet
��a l
.
��l m
Cell
��m q
(
��q r
)
��r s
;
��s t
newcell
�� 
.
�� 
DataType
�� $
=
��% &
DocumentFormat
��' 5
.
��5 6
OpenXml
��6 =
.
��= >
Spreadsheet
��> I
.
��I J

CellValues
��J T
.
��T U
InlineString
��U a
;
��a b
if
�� 
(
�� 
column
�� 
.
�� 

ColumnName
�� )
.
��) *
Contains
��* 2
(
��2 3
$str
��3 <
)
��< =
)
��= >
{
��? @
newcell
�� 
.
��  
	CellValue
��  )
=
��* +
new
��, /
DocumentFormat
��0 >
.
��> ?
OpenXml
��? F
.
��F G
Spreadsheet
��G R
.
��R S
	CellValue
��S \
(
��\ ]
$str
��] _
)
��_ `
;
��` a
newcell
�� 
.
��  

StyleIndex
��  *
=
��+ ,
$num
��- .
;
��. /
}
�� 
else
�� 
{
�� 
string
�� 
columnexcel
�� *
=
��+ ,
column
��- 3
.
��3 4

ColumnName
��4 >
.
��> ?
Replace
��? F
(
��F G
$str
��G K
,
��K L
$str
��M O
)
��O P
;
��P Q
columnexcel
�� #
=
��$ %
columnexcel
��& 1
.
��1 2
Replace
��2 9
(
��9 :
$str
��: =
,
��= >
$str
��? C
)
��C D
;
��D E
newcell
�� 
.
��  
	CellValue
��  )
=
��* +
new
��, /
DocumentFormat
��0 >
.
��> ?
OpenXml
��? F
.
��F G
Spreadsheet
��G R
.
��R S
	CellValue
��S \
(
��\ ]
columnexcel
��] h
)
��h i
;
��i j
newcell
�� 
.
��  
InlineString
��  ,
=
��- .
new
��/ 2
InlineString
��3 ?
(
��? @
)
��@ A
{
��B C
Text
��D H
=
��I J
new
��K N
Text
��O S
(
��S T
)
��T U
{
��V W
Text
��X \
=
��] ^
columnexcel
��_ j
}
��k l
}
��m n
;
��n o
if
�� 
(
�� 
columnascelestes
�� ,
.
��, -
Contains
��- 5
(
��5 6
column
��6 <
.
��< =

ColumnName
��= G
)
��G H
)
��H I
{
�� 
newcell
�� #
.
��# $

StyleIndex
��$ .
=
��/ 0
$num
��1 2
;
��2 3
}
�� 
else
�� 
{
�� 
if
�� 
(
��  
columnasamarillas
��  1
.
��1 2
Contains
��2 :
(
��: ;
column
��; A
.
��A B

ColumnName
��B L
)
��L M
)
��M N
{
�� 
newcell
��  '
.
��' (

StyleIndex
��( 2
=
��3 4
$num
��5 6
;
��6 7
}
�� 
else
��  
{
�� 
if
��  "
(
��# $ 
columnasverdeclaro
��$ 6
.
��6 7
Contains
��7 ?
(
��? @
column
��@ F
.
��F G

ColumnName
��G Q
)
��Q R
)
��R S
{
��  !
newcell
��& -
.
��- .

StyleIndex
��. 8
=
��9 :
$num
��; <
;
��< =
}
��  !
else
��  $
{
��% &
if
��$ &
(
��' (!
columnasverdeoscuro
��( ;
.
��; <
Contains
��< D
(
��D E
column
��E K
.
��K L

ColumnName
��L V
)
��V W
)
��W X
{
��$ %
newcell
��* 1
.
��1 2

StyleIndex
��2 <
=
��= >
$num
��? A
;
��A B
}
��$ %
else
��$ (
{
��$ %
newcell
��* 1
.
��1 2

StyleIndex
��2 <
=
��= >
$num
��? @
;
��@ A
}
��$ %
}
��  !
}
�� 
}
�� 
}
�� 
	headerRow
�� 
.
�� 
AppendChild
�� )
(
��) *
newcell
��* 1
)
��1 2
;
��2 3
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� %
(
��% &
	headerRow
��& /
)
��/ 0
;
��0 1
foreach
�� 
(
�� 
DataRow
��  
dsrow
��! &
in
��' )
table
��* /
.
��/ 0
Rows
��0 4
)
��4 5
{
�� 
DocumentFormat
�� "
.
��" #
OpenXml
��# *
.
��* +
Spreadsheet
��+ 6
.
��6 7
Row
��7 :
newRow
��; A
=
��B C
new
��D G
DocumentFormat
��H V
.
��V W
OpenXml
��W ^
.
��^ _
Spreadsheet
��_ j
.
��j k
Row
��k n
(
��n o
)
��o p
;
��p q
foreach
�� 
(
�� 
String
�� #
col
��$ '
in
��( *
columns
��+ 2
)
��2 3
{
�� 
DocumentFormat
�� &
.
��& '
OpenXml
��' .
.
��. /
Spreadsheet
��/ :
.
��: ;
Cell
��; ?
cell
��@ D
=
��E F
new
��G J
DocumentFormat
��K Y
.
��Y Z
OpenXml
��Z a
.
��a b
Spreadsheet
��b m
.
��m n
Cell
��n r
(
��r s
)
��s t
;
��t u
if
�� 
(
�� 
col
�� 
.
��  
Contains
��  (
(
��( )
$str
��) 2
)
��2 3
)
��3 4
{
�� 
cell
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cell
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
$str
��^ `
)
��` a
;
��a b
cell
��  
.
��  !

StyleIndex
��! +
=
��, -
$num
��. /
;
��/ 0
}
�� 
else
�� 
{
�� 
if
�� 
(
��  
columnasstring
��  .
.
��. /
Contains
��/ 7
(
��7 8
col
��8 ;
)
��; <
)
��< =
{
�� 
cell
��  $
.
��$ %

StyleIndex
��% /
=
��0 1
$num
��2 3
;
��3 4
cell
��  $
.
��$ %
DataType
��% -
=
��. /
DocumentFormat
��0 >
.
��> ?
OpenXml
��? F
.
��F G
Spreadsheet
��G R
.
��R S

CellValues
��S ]
.
��] ^
String
��^ d
;
��d e
cell
��  $
.
��$ %
	CellValue
��% .
=
��/ 0
new
��1 4
DocumentFormat
��5 C
.
��C D
OpenXml
��D K
.
��K L
Spreadsheet
��L W
.
��W X
	CellValue
��X a
(
��a b
dsrow
��b g
[
��g h
col
��h k
]
��k l
.
��l m
ToString
��m u
(
��u v
)
��v w
)
��w x
;
��x y
}
�� 
else
��  
{
�� 
if
��  "
(
��# $
col
��$ '
.
��' (
Contains
��( 0
(
��0 1
$str
��1 C
)
��C D
)
��D E
{
��  !
DateTime
��$ ,
celdadt
��- 4
=
��5 6
DateTime
��7 ?
.
��? @
Parse
��@ E
(
��E F
dsrow
��F K
[
��K L
col
��L O
]
��O P
.
��P Q
ToString
��Q Y
(
��Y Z
)
��Z [
)
��[ \
;
��\ ]
string
��$ *
valueString
��+ 6
=
��7 8
celdadt
��9 @
.
��@ A
ToOADate
��A I
(
��I J
)
��J K
.
��K L
ToString
��L T
(
��T U
)
��U V
;
��V W
	CellValue
��$ -
	cellValue
��. 7
=
��8 9
new
��: =
	CellValue
��> G
(
��G H
valueString
��H S
)
��S T
;
��T U
cell
��$ (
.
��( )
DataType
��) 1
=
��2 3
new
��4 7
	EnumValue
��8 A
<
��A B

CellValues
��B L
>
��L M
(
��M N

CellValues
��N X
.
��X Y
Number
��Y _
)
��_ `
;
��` a
cell
��$ (
.
��( )

StyleIndex
��) 3
=
��4 5
$num
��6 7
;
��7 8
cell
��$ (
.
��( )
Append
��) /
(
��/ 0
	cellValue
��0 9
)
��9 :
;
��: ;
}
��  !
else
��  $
{
��% &
cell
��$ (
.
��( )
DataType
��) 1
=
��2 3
DocumentFormat
��4 B
.
��B C
OpenXml
��C J
.
��J K
Spreadsheet
��K V
.
��V W

CellValues
��W a
.
��a b
Number
��b h
;
��h i
cell
��$ (
.
��( )
	CellValue
��) 2
=
��3 4
new
��5 8
DocumentFormat
��9 G
.
��G H
OpenXml
��H O
.
��O P
Spreadsheet
��P [
.
��[ \
	CellValue
��\ e
(
��e f
dsrow
��f k
[
��k l
col
��l o
]
��o p
.
��p q
ToString
��q y
(
��y z
)
��z {
)
��{ |
;
��| }
cell
��$ (
.
��( )

StyleIndex
��) 3
=
��4 5
$num
��6 7
;
��7 8
}
��  !
}
�� 
}
�� 
newRow
�� 
.
�� 
AppendChild
�� *
(
��* +
cell
��+ /
)
��/ 0
;
��0 1
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� )
(
��) *
newRow
��* 0
)
��0 1
;
��1 2
}
�� 
wsPart
�� 
.
�� 
	Worksheet
��  
.
��  !
Save
��! %
(
��% &
)
��& '
;
��' (
var
�� 
sheets
�� 
=
�� 
spreadsheet
�� (
.
��( )
WorkbookPart
��) 5
.
��5 6
Workbook
��6 >
.
��> ?
AppendChild
��? J
(
��J K
new
��K N
Sheets
��O U
(
��U V
)
��V W
)
��W X
;
��X Y
sheets
�� 
.
�� 
AppendChild
�� "
(
��" #
new
��# &
Sheet
��' ,
(
��, -
)
��- .
{
��/ 0
Id
��1 3
=
��4 5
spreadsheet
��6 A
.
��A B
WorkbookPart
��B N
.
��N O
GetIdOfPart
��O Z
(
��Z [
wsPart
��[ a
)
��a b
,
��b c
SheetId
��d k
=
��l m
$num
��n o
,
��o p
Name
��q u
=
��v w
$str��x �
}��� �
)��� �
;��� �
spreadsheet
�� 
.
�� 
WorkbookPart
�� (
.
��( )
Workbook
��) 1
.
��1 2
Save
��2 6
(
��6 7
)
��7 8
;
��8 9
}
�� 
}
�� 	
public
�� 
static
�� 
void
��  
StructureSalaryXLS
�� -
(
��- .
	DataTable
��. 7
table
��8 =
,
��= >
string
��? E
destination
��F Q
)
��Q R
{
�� 	
using
�� 
(
�� 
var
�� 
spreadsheet
�� "
=
��# $!
SpreadsheetDocument
��% 8
.
��8 9
Create
��9 ?
(
��? @
destination
��@ K
,
��K L%
SpreadsheetDocumentType
��M d
.
��d e
Workbook
��e m
)
��m n
)
��n o
{
�� 
spreadsheet
�� 
.
�� 
AddWorkbookPart
�� +
(
��+ ,
)
��, -
;
��- .
spreadsheet
�� 
.
�� 
WorkbookPart
�� (
.
��( )
Workbook
��) 1
=
��2 3
new
��4 7
Workbook
��8 @
(
��@ A
)
��A B
;
��B C
var
�� 
wsPart
�� 
=
�� 
spreadsheet
�� (
.
��( )
WorkbookPart
��) 5
.
��5 6

AddNewPart
��6 @
<
��@ A
WorksheetPart
��A N
>
��N O
(
��O P
)
��P Q
;
��Q R
wsPart
�� 
.
�� 
	Worksheet
��  
=
��! "
new
��# &
	Worksheet
��' 0
(
��0 1
)
��1 2
;
��2 3
var
�� 

stylesPart
�� 
=
��  
spreadsheet
��! ,
.
��, -
WorkbookPart
��- 9
.
��9 :

AddNewPart
��: D
<
��D E 
WorkbookStylesPart
��E W
>
��W X
(
��X Y
)
��Y Z
;
��Z [

stylesPart
�� 
.
�� 

Stylesheet
�� %
=
��& '
new
��( +

Stylesheet
��, 6
(
��6 7
)
��7 8
;
��8 9
Font
�� 
font
�� 
=
�� 
new
�� 
Font
��  $
(
��$ %
)
��% &
;
��& '
font
�� 
.
�� 
Append
�� 
(
�� 
new
�� 
Color
��  %
(
��% &
)
��& '
{
��( )
Rgb
��* -
=
��. /
$str
��0 8
}
��9 :
)
��: ;
;
��; <
font
�� 
.
�� 
Append
�� 
(
�� 
new
�� 
Bold
��  $
(
��$ %
)
��% &
)
��& '
;
��' (

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
=
��, -
new
��. 1
Fonts
��2 7
(
��7 8
)
��8 9
;
��9 :

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
font
��8 <
)
��< =
;
��= >

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
}
��j k
)
��k l
;
��l m

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
,
��i j
Bold
��k o
=
��p q
new
��r u
Bold
��v z
(
��z {
)
��{ |
}
��} ~
)
��~ 
;�� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
AppendChild
��, 7
(
��7 8
new
��8 ;
Font
��< @
{
��A B
Color
��C H
=
��I J
new
��K N
Color
��O T
(
��T U
)
��U V
{
��W X
Rgb
��Y \
=
��] ^
$str
��_ g
}
��h i
,
��i j
Bold
��k o
=
��p q
new
��r u
Bold
��v z
(
��z {
)
��{ |
}
��} ~
)
��~ 
;�� �

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fonts
��& +
.
��+ ,
Count
��, 1
=
��2 3
$num
��4 5
;
��5 6

stylesPart
�� 
.
�� 

Stylesheet
�� %
.
��% &
Fills
��& +
=
��, -
new
��. 1
Fills
��2 7
(
��7 8
)
��8 9
;
��9 :
var
�� 
solidRed
�� 
=
�� 
new
�� "
PatternFill
��# .
(
��. /
)
��/ 0
{
��1 2
PatternType
��3 >
=
��? @
PatternValues
��A N
.
��N O
Solid
��O T
}
��U V
;
��V W
solidRed
�� 
.
�� 
ForegroundColor
�� (
=
��) *
new
��+ .
ForegroundColor
��/ >
{
��? @
Rgb
��A D
=
��E F
HexBinaryValue
��G U
.
��U V

FromString
��V `
(
��` a
$str
��a i
)
��i j
}
��k l
;
��l m
solidRed
�� 
.
�� 
BackgroundColor
�� (
=
��) *
new
��+ .
BackgroundColor
��/ >
{
��? @
Indexed
��A H
=
��I J
$num
��K M
}
��N O
;
��O P
var
�	�	 
solidCeleste
�	�	  
=
�	�	! "
new
�	�	# &
PatternFill
�	�	' 2
(
�	�	2 3
)
�	�	3 4
{
�	�	5 6
PatternType
�	�	7 B
=
�	�	C D
PatternValues
�	�	E R
.
�	�	R S
Solid
�	�	S X
}
�	�	Y Z
;
�	�	Z [
solidCeleste
�	�	 
.
�	�	 
ForegroundColor
�	�	 ,
=
�	�	- .
new
�	�	/ 2
ForegroundColor
�	�	3 B
{
�	�	C D
Rgb
�	�	E H
=
�	�	I J
HexBinaryValue
�	�	K Y
.
�	�	Y Z

FromString
�	�	Z d
(
�	�	d e
$str
�	�	e m
)
�	�	m n
}
�	�	o p
;
�	�	p q
solidCeleste
�	�	 
.
�	�	 
BackgroundColor
�	�	 ,
=
�	�	- .
new
�	�	/ 2
BackgroundColor
�	�	3 B
{
�	�	C D
Indexed
�	�	E L
=
�	�	M N
$num
�	�	O Q
}
�	�	R S
;
�	�	S T
var
�	�	 
fondo_semaforo_01
�	�	 %
=
�	�	& '
new
�	�	( +
PatternFill
�	�	, 7
(
�	�	7 8
)
�	�	8 9
{
�	�	: ;
PatternType
�	�	< G
=
�	�	H I
PatternValues
�	�	J W
.
�	�	W X
Solid
�	�	X ]
}
�	�	^ _
;
�	�	_ `
fondo_semaforo_01
�	�	 !
.
�	�	! "
ForegroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
ForegroundColor
�	�	8 G
{
�	�	H I
Rgb
�	�	J M
=
�	�	N O
HexBinaryValue
�	�	P ^
.
�	�	^ _

FromString
�	�	_ i
(
�	�	i j
$str
�	�	j r
)
�	�	r s
}
�	�	t u
;
�	�	u v
fondo_semaforo_01
�	�	 !
.
�	�	! "
BackgroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
BackgroundColor
�	�	8 G
{
�	�	H I
Indexed
�	�	J Q
=
�	�	R S
$num
�	�	T V
}
�	�	W X
;
�	�	X Y
var
�	�	 
fondo_semaforo_02
�	�	 %
=
�	�	& '
new
�	�	( +
PatternFill
�	�	, 7
(
�	�	7 8
)
�	�	8 9
{
�	�	: ;
PatternType
�	�	< G
=
�	�	H I
PatternValues
�	�	J W
.
�	�	W X
Solid
�	�	X ]
}
�	�	^ _
;
�	�	_ `
fondo_semaforo_02
�	�	 !
.
�	�	! "
ForegroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
ForegroundColor
�	�	8 G
{
�	�	H I
Rgb
�	�	J M
=
�	�	N O
HexBinaryValue
�	�	P ^
.
�	�	^ _

FromString
�	�	_ i
(
�	�	i j
$str
�	�	j r
)
�	�	r s
}
�	�	t u
;
�	�	u v
fondo_semaforo_02
�	�	 !
.
�	�	! "
BackgroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
BackgroundColor
�	�	8 G
{
�	�	H I
Indexed
�	�	J Q
=
�	�	R S
$num
�	�	T V
}
�	�	W X
;
�	�	X Y
var
�	�	 
fondo_semaforo_03
�	�	 %
=
�	�	& '
new
�	�	( +
PatternFill
�	�	, 7
(
�	�	7 8
)
�	�	8 9
{
�	�	: ;
PatternType
�	�	< G
=
�	�	H I
PatternValues
�	�	J W
.
�	�	W X
Solid
�	�	X ]
}
�	�	^ _
;
�	�	_ `
fondo_semaforo_03
�	�	 !
.
�	�	! "
ForegroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
ForegroundColor
�	�	8 G
{
�	�	H I
Rgb
�	�	J M
=
�	�	N O
HexBinaryValue
�	�	P ^
.
�	�	^ _

FromString
�	�	_ i
(
�	�	i j
$str
�	�	j r
)
�	�	r s
}
�	�	t u
;
�	�	u v
fondo_semaforo_03
�	�	 !
.
�	�	! "
BackgroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
BackgroundColor
�	�	8 G
{
�	�	H I
Indexed
�	�	J Q
=
�	�	R S
$num
�	�	T V
}
�	�	W X
;
�	�	X Y
var
�	�	 
fondo_semaforo_04
�	�	 %
=
�	�	& '
new
�	�	( +
PatternFill
�	�	, 7
(
�	�	7 8
)
�	�	8 9
{
�	�	: ;
PatternType
�	�	< G
=
�	�	H I
PatternValues
�	�	J W
.
�	�	W X
Solid
�	�	X ]
}
�	�	^ _
;
�	�	_ `
fondo_semaforo_04
�	�	 !
.
�	�	! "
ForegroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
ForegroundColor
�	�	8 G
{
�	�	H I
Rgb
�	�	J M
=
�	�	N O
HexBinaryValue
�	�	P ^
.
�	�	^ _

FromString
�	�	_ i
(
�	�	i j
$str
�	�	j r
)
�	�	r s
}
�	�	t u
;
�	�	u v
fondo_semaforo_04
�	�	 !
.
�	�	! "
BackgroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
BackgroundColor
�	�	8 G
{
�	�	H I
Indexed
�	�	J Q
=
�	�	R S
$num
�	�	T V
}
�	�	W X
;
�	�	X Y
var
�	�	 
fondo_semaforo_05
�	�	 %
=
�	�	& '
new
�	�	( +
PatternFill
�	�	, 7
(
�	�	7 8
)
�	�	8 9
{
�	�	: ;
PatternType
�	�	< G
=
�	�	H I
PatternValues
�	�	J W
.
�	�	W X
Solid
�	�	X ]
}
�	�	^ _
;
�	�	_ `
fondo_semaforo_05
�	�	 !
.
�	�	! "
ForegroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
ForegroundColor
�	�	8 G
{
�	�	H I
Rgb
�	�	J M
=
�	�	N O
HexBinaryValue
�	�	P ^
.
�	�	^ _

FromString
�	�	_ i
(
�	�	i j
$str
�	�	j r
)
�	�	r s
}
�	�	t u
;
�	�	u v
fondo_semaforo_05
�	�	 !
.
�	�	! "
BackgroundColor
�	�	" 1
=
�	�	2 3
new
�	�	4 7
BackgroundColor
�	�	8 G
{
�	�	H I
Indexed
�	�	J Q
=
�	�	R S
$num
�	�	T V
}
�	�	W X
;
�	�	X Y

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
new
�	�	Q T
PatternFill
�	�	U `
{
�	�	a b
PatternType
�	�	c n
=
�	�	o p
PatternValues
�	�	q ~
.
�	�	~ 
None�	�	 �
}�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
new
�	�	Q T
PatternFill
�	�	U `
{
�	�	a b
PatternType
�	�	c n
=
�	�	o p
PatternValues
�	�	q ~
.
�	�	~ 
Gray125�	�	 �
}�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
solidRed
�	�	Q Y
}
�	�	Z [
)
�	�	[ \
;
�	�	\ ]

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
solidCeleste
�	�	Q ]
}
�	�	^ _
)
�	�	_ `
;
�	�	` a

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
fondo_semaforo_01
�	�	Q b
}
�	�	c d
)
�	�	d e
;
�	�	e f

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
fondo_semaforo_02
�	�	Q b
}
�	�	c d
)
�	�	d e
;
�	�	e f

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
fondo_semaforo_03
�	�	Q b
}
�	�	c d
)
�	�	d e
;
�	�	e f

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
fondo_semaforo_04
�	�	Q b
}
�	�	c d
)
�	�	d e
;
�	�	e f

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
AppendChild
�	�	, 7
(
�	�	7 8
new
�	�	8 ;
Fill
�	�	< @
{
�	�	A B
PatternFill
�	�	C N
=
�	�	O P
fondo_semaforo_05
�	�	Q b
}
�	�	c d
)
�	�	d e
;
�	�	e f

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Fills
�	�	& +
.
�	�	+ ,
Count
�	�	, 1
=
�	�	2 3
$num
�	�	4 5
;
�	�	5 6

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Borders
�	�	& -
=
�	�	. /
new
�	�	0 3
Borders
�	�	4 ;
(
�	�	; <
)
�	�	< =
;
�	�	= >

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Borders
�	�	& -
.
�	�	- .
AppendChild
�	�	. 9
(
�	�	9 :
new
�	�	: =
Border
�	�	> D
(
�	�	D E
)
�	�	E F
)
�	�	F G
;
�	�	G H

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Borders
�	�	& -
.
�	�	- .
AppendChild
�	�	. 9
(
�	�	9 :
new
�	�	: =
Border
�	�	> D
(
�	�	D E
)
�	�	E F
{
�	�	 

LeftBorder
�	�	 
=
�	�	  
new
�	�	! $

LeftBorder
�	�	% /
(
�	�	/ 0
)
�	�	0 1
{
�	�	2 3
Style
�	�	4 9
=
�	�	: ;
BorderStyleValues
�	�	< M
.
�	�	M N
Thin
�	�	N R
}
�	�	S T
,
�	�	T U
RightBorder
�	�	 
=
�	�	  !
new
�	�	" %
RightBorder
�	�	& 1
(
�	�	1 2
)
�	�	2 3
{
�	�	4 5
Style
�	�	6 ;
=
�	�	< =
BorderStyleValues
�	�	> O
.
�	�	O P
Thin
�	�	P T
}
�	�	U V
,
�	�	 
BottomBorder
�	�	  
=
�	�	! "
new
�	�	# &
BottomBorder
�	�	' 3
(
�	�	3 4
)
�	�	4 5
{
�	�	6 7
Style
�	�	8 =
=
�	�	> ?
BorderStyleValues
�	�	@ Q
.
�	�	Q R
Thin
�	�	R V
}
�	�	W X
,
�	�	X Y
	TopBorder
�	�	 
=
�	�	 
new
�	�	  #
	TopBorder
�	�	$ -
(
�	�	- .
)
�	�	. /
{
�	�	0 1
Style
�	�	2 7
=
�	�	8 9
BorderStyleValues
�	�	: K
.
�	�	K L
Thin
�	�	L P
}
�	�	Q R
}
�	�	 
)
�	�	 
;
�	�	 

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Borders
�	�	& -
.
�	�	- .
Count
�	�	. 3
=
�	�	4 5
$num
�	�	6 7
;
�	�	7 8

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellStyleFormats
�	�	& 6
=
�	�	7 8
new
�	�	9 <
CellStyleFormats
�	�	= M
(
�	�	M N
)
�	�	N O
;
�	�	O P

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellStyleFormats
�	�	& 6
.
�	�	6 7
Count
�	�	7 <
=
�	�	= >
$num
�	�	? @
;
�	�	@ A

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellStyleFormats
�	�	& 6
.
�	�	6 7
AppendChild
�	�	7 B
(
�	�	B C
new
�	�	C F

CellFormat
�	�	G Q
(
�	�	Q R
)
�	�	R S
)
�	�	S T
;
�	�	T U

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
=
�	�	2 3
new
�	�	4 7
CellFormats
�	�	8 C
(
�	�	C D
)
�	�	D E
;
�	�	E F

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
(
�	�	L M
)
�	�	M N
)
�	�	N O
;
�	�	O P

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
FormatId
�	�	O W
=
�	�	X Y
$num
�	�	Z [
,
�	�	[ \
FontId
�	�	] c
=
�	�	d e
$num
�	�	f g
,
�	�	g h
BorderId
�	�	i q
=
�	�	r s
$num
�	�	t u
,
�	�	u v
FillId
�	�	w }
=
�	�	~ 
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Center�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
FormatId
�	�	O W
=
�	�	X Y
$num
�	�	Z [
,
�	�	[ \
FontId
�	�	] c
=
�	�	d e
$num
�	�	f g
,
�	�	g h
BorderId
�	�	i q
=
�	�	r s
$num
�	�	t u
,
�	�	u v
FillId
�	�	w }
=
�	�	~ 
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Left�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
FormatId
�	�	O W
=
�	�	X Y
$num
�	�	Z [
,
�	�	[ \
FontId
�	�	] c
=
�	�	d e
$num
�	�	f g
,
�	�	g h
BorderId
�	�	i q
=
�	�	r s
$num
�	�	t u
,
�	�	u v
FillId
�	�	w }
=
�	�	~ 
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Center�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
ApplyNumberFormat
�	�	O `
=
�	�	a b
true
�	�	c g
,
�	�	g h
NumberFormatId
�	�	i w
=
�	�	x y
$num
�	�	z |
,
�	�	| }
FormatId�	�	~ �
=�	�	� �
$num�	�	� �
,�	�	� �
FontId�	�	� �
=�	�	� �
$num�	�	� �
,�	�	� �
BorderId�	�	� �
=�	�	� �
$num�	�	� �
,�	�	� �
FillId�	�	� �
=�	�	� �
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Center�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
ApplyNumberFormat
�	�	O `
=
�	�	a b
true
�	�	c g
,
�	�	g h
NumberFormatId
�	�	i w
=
�	�	x y
$num
�	�	z {
,
�	�	{ |
FormatId�	�	} �
=�	�	� �
$num�	�	� �
,�	�	� �
FontId�	�	� �
=�	�	� �
$num�	�	� �
,�	�	� �
BorderId�	�	� �
=�	�	� �
$num�	�	� �
,�	�	� �
FillId�	�	� �
=�	�	� �
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Right�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
FormatId
�	�	O W
=
�	�	X Y
$num
�	�	Z [
,
�	�	[ \
FontId
�	�	] c
=
�	�	d e
$num
�	�	f g
,
�	�	g h
BorderId
�	�	i q
=
�	�	r s
$num
�	�	t u
,
�	�	u v
FillId
�	�	w }
=
�	�	~ 
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Center�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
FormatId
�	�	O W
=
�	�	X Y
$num
�	�	Z [
,
�	�	[ \
FontId
�	�	] c
=
�	�	d e
$num
�	�	f g
,
�	�	g h
BorderId
�	�	i q
=
�	�	r s
$num
�	�	t u
,
�	�	u v
FillId
�	�	w }
=
�	�	~ 
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Center�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
FormatId
�	�	O W
=
�	�	X Y
$num
�	�	Z [
,
�	�	[ \
FontId
�	�	] c
=
�	�	d e
$num
�	�	f g
,
�	�	g h
BorderId
�	�	i q
=
�	�	r s
$num
�	�	t u
,
�	�	u v
FillId
�	�	w }
=
�	�	~ 
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Center�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
FormatId
�	�	O W
=
�	�	X Y
$num
�	�	Z [
,
�	�	[ \
FontId
�	�	] c
=
�	�	d e
$num
�	�	f g
,
�	�	g h
BorderId
�	�	i q
=
�	�	r s
$num
�	�	t u
,
�	�	u v
FillId
�	�	w }
=
�	�	~ 
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Center�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
AppendChild
�	�	2 =
(
�	�	= >
new
�	�	> A

CellFormat
�	�	B L
{
�	�	M N
FormatId
�	�	O W
=
�	�	X Y
$num
�	�	Z [
,
�	�	[ \
FontId
�	�	] c
=
�	�	d e
$num
�	�	f g
,
�	�	g h
BorderId
�	�	i q
=
�	�	r s
$num
�	�	t u
,
�	�	u v
FillId
�	�	w }
=
�	�	~ 
$num�	�	� �
,�	�	� �
	ApplyFill�	�	� �
=�	�	� �
true�	�	� �
}�	�	� �
)�	�	� �
.�	�	� �
AppendChild�	�	� �
(�	�	� �
new�	�	� �
	Alignment�	�	� �
{�	�	� �

Horizontal�	�	� �
=�	�	� �)
HorizontalAlignmentValues�	�	� �
.�	�	� �
Center�	�	� �
}�	�	� �
)�	�	� �
;�	�	� �

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
CellFormats
�	�	& 1
.
�	�	1 2
Count
�	�	2 7
=
�	�	8 9
$num
�	�	: <
;
�	�	< =

stylesPart
�	�	 
.
�	�	 

Stylesheet
�	�	 %
.
�	�	% &
Save
�	�	& *
(
�	�	* +
)
�	�	+ ,
;
�	�	, -
List
�	�	 
<
�	�	 
string
�	�	 
>
�	�	 
columnasstring
�	�	 +
=
�	�	, -
new
�	�	. 1
List
�	�	2 6
<
�	�	6 7
string
�	�	7 =
>
�	�	= >
(
�	�	> ?
)
�	�	? @
;
�	�	@ A
List
�	�	 
<
�	�	 
string
�	�	 
>
�	�	 
columnasfecha
�	�	 *
=
�	�	+ ,
new
�	�	- 0
List
�	�	1 5
<
�	�	5 6
string
�	�	6 <
>
�	�	< =
(
�	�	= >
)
�	�	> ?
;
�	�	? @
List
�	�	 
<
�	�	 
string
�	�	 
>
�	�	 
columnasmonto
�	�	 *
=
�	�	+ ,
new
�	�	- 0
List
�	�	1 5
<
�	�	5 6
string
�	�	6 <
>
�	�	< =
(
�	�	= >
)
�	�	> ?
;
�	�	? @
List
�	�	 
<
�	�	 
string
�	�	 
>
�	�	 
columnassemaforos
�	�	 .
=
�	�	/ 0
new
�	�	1 4
List
�	�	5 9
<
�	�	9 :
string
�	�	: @
>
�	�	@ A
(
�	�	A B
)
�	�	B C
;
�	�	C D
columnasstring
�	�	 
.
�	�	 
Add
�	�	 "
(
�	�	" #
$str
�	�	# +
)
�	�	+ ,
;
�	�	, -
columnasstring
�	�	 
.
�	�	 
Add
�	�	 "
(
�	�	" #
$str
�	�	# +
)
�	�	+ ,
;
�	�	, -
columnasstring
�	�	 
.
�	�	 
Add
�	�	 "
(
�	�	" #
$str
�	�	# *
)
�	�	* +
;
�	�	+ ,
columnasstring
�	�	 
.
�	�	 
Add
�	�	 "
(
�	�	" #
$str
�	�	# )
)
�	�	) *
;
�	�	* +
columnasstring
�	�	 
.
�	�	 
Add
�	�	 "
(
�	�	" #
$str
�	�	# .
)
�	�	. /
;
�	�	/ 0
columnasfecha
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" 1
)
�	�	1 2
;
�	�	2 3
columnasstring
�	�	 
.
�	�	 
Add
�	�	 "
(
�	�	" #
$str
�	�	# 5
)
�	�	5 6
;
�	�	6 7
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" 1
)
�	�	1 2
;
�	�	2 3
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" (
)
�	�	( )
;
�	�	) *
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" B
)
�	�	B C
;
�	�	C D
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" C
)
�	�	C D
;
�	�	D E
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" 1
)
�	�	1 2
;
�	�	2 3
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" 5
)
�	�	5 6
;
�	�	6 7
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" 6
)
�	�	6 7
;
�	�	7 8
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" @
)
�	�	@ A
;
�	�	A B
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" 5
)
�	�	5 6
;
�	�	6 7
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" :
)
�	�	: ;
;
�	�	; <
columnasstring
�	�	 
.
�	�	 
Add
�	�	 "
(
�	�	" #
$str
�	�	# 4
)
�	�	4 5
;
�	�	5 6
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" -
)
�	�	- .
;
�	�	. /
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" ,
)
�	�	, -
;
�	�	- .
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" -
)
�	�	- .
;
�	�	. /
columnasmonto
�	�	 
.
�	�	 
Add
�	�	 !
(
�	�	! "
$str
�	�	" /
)
�	�	/ 0
;
�	�	0 1
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& .
)
�	�	. /
;
�	�	/ 0
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& /
)
�	�	/ 0
;
�	�	0 1
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& /
)
�	�	/ 0
;
�	�	0 1
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& /
)
�	�	/ 0
;
�	�	0 1
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& /
)
�	�	/ 0
;
�	�	0 1
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& /
)
�	�	/ 0
;
�	�	0 1
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& /
)
�	�	/ 0
;
�	�	0 1
columnassemaforos
�	�	 !
.
�	�	! "
Add
�	�	" %
(
�	�	% &
$str
�	�	& /
)
�	�	/ 0
;
�	�	0 1
columnassemaforos
�
�
 !
.
�
�
! "
Add
�
�
" %
(
�
�
% &
$str
�
�
& /
)
�
�
/ 0
;
�
�
0 1
columnassemaforos
�
�
 !
.
�
�
! "
Add
�
�
" %
(
�
�
% &
$str
�
�
& /
)
�
�
/ 0
;
�
�
0 1
columnassemaforos
�
�
 !
.
�
�
! "
Add
�
�
" %
(
�
�
% &
$str
�
�
& /
)
�
�
/ 0
;
�
�
0 1
columnassemaforos
�
�
 !
.
�
�
! "
Add
�
�
" %
(
�
�
% &
$str
�
�
& /
)
�
�
/ 0
;
�
�
0 1
columnassemaforos
�
�
 !
.
�
�
! "
Add
�
�
" %
(
�
�
% &
$str
�
�
& /
)
�
�
/ 0
;
�
�
0 1
columnassemaforos
�
�
 !
.
�
�
! "
Add
�
�
" %
(
�
�
% &
$str
�
�
& /
)
�
�
/ 0
;
�
�
0 1
Columns
�
�
 
columnExcel
�
�
 #
=
�
�
$ %
new
�
�
& )
Columns
�
�
* 1
(
�
�
1 2
)
�
�
2 3
;
�
�
3 4
int
�
�
 
contadorColumn
�
�
 "
=
�
�
# $
$num
�
�
% &
;
�
�
& '
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
columnExcel
�
�
 
.
�
�
 
Append
�
�
 "
(
�
�
" #
new
�
�
# &
Column
�
�
' -
(
�
�
- .
)
�
�
. /
{
�
�
0 1
Min
�
�
2 5
=
�
�
6 7
Convert
�
�
8 ?
.
�
�
? @
ToUInt32
�
�
@ H
(
�
�
H I
contadorColumn
�
�
I W
)
�
�
W X
,
�
�
X Y
Max
�
�
Z ]
=
�
�
^ _
Convert
�
�
` g
.
�
�
g h
ToUInt32
�
�
h p
(
�
�
p q
contadorColumn
�
�
q 
)�
�
 �
,�
�
� �
Width�
�
� �
=�
�
� �
$num�
�
� �
,�
�
� �
CustomWidth�
�
� �
=�
�
� �
true�
�
� �
}�
�
� �
)�
�
� �
;�
�
� �
contadorColumn�
�
� �
++�
�
� �
;�
�
� �
wsPart
�
�
 
.
�
�
 
	Worksheet
�
�
  
.
�
�
  !
Append
�
�
! '
(
�
�
' (
columnExcel
�
�
( 3
)
�
�
3 4
;
�
�
4 5
var
�
�
 
	sheetData
�
�
 
=
�
�
 
wsPart
�
�
  &
.
�
�
& '
	Worksheet
�
�
' 0
.
�
�
0 1
AppendChild
�
�
1 <
(
�
�
< =
new
�
�
= @
	SheetData
�
�
A J
(
�
�
J K
)
�
�
K L
)
�
�
L M
;
�
�
M N
DocumentFormat
�
�
 
.
�
�
 
OpenXml
�
�
 &
.
�
�
& '
Spreadsheet
�
�
' 2
.
�
�
2 3
Row
�
�
3 6
	headerRow
�
�
7 @
=
�
�
A B
new
�
�
C F
DocumentFormat
�
�
G U
.
�
�
U V
OpenXml
�
�
V ]
.
�
�
] ^
Spreadsheet
�
�
^ i
.
�
�
i j
Row
�
�
j m
(
�
�
m n
)
�
�
n o
;
�
�
o p
List
�
�
 
<
�
�
 
String
�
�
 
>
�
�
 
columns
�
�
 $
=
�
�
% &
new
�
�
' *
List
�
�
+ /
<
�
�
/ 0
string
�
�
0 6
>
�
�
6 7
(
�
�
7 8
)
�
�
8 9
;
�
�
9 :
foreach
�
�
 
(
�
�
 

DataColumn
�
�
 #
column
�
�
$ *
in
�
�
+ -
table
�
�
. 3
.
�
�
3 4
Columns
�
�
4 ;
)
�
�
; <
{
�
�
 
columns
�
�
 
.
�
�
 
Add
�
�
 
(
�
�
  
column
�
�
  &
.
�
�
& '

ColumnName
�
�
' 1
)
�
�
1 2
;
�
�
2 3
DocumentFormat
�
�
 "
.
�
�
" #
OpenXml
�
�
# *
.
�
�
* +
Spreadsheet
�
�
+ 6
.
�
�
6 7
Cell
�
�
7 ;
cell
�
�
< @
=
�
�
A B
new
�
�
C F
DocumentFormat
�
�
G U
.
�
�
U V
OpenXml
�
�
V ]
.
�
�
] ^
Spreadsheet
�
�
^ i
.
�
�
i j
Cell
�
�
j n
(
�
�
n o
)
�
�
o p
;
�
�
p q
cell
�
�
 
.
�
�
 
DataType
�
�
 !
=
�
�
" #
DocumentFormat
�
�
$ 2
.
�
�
2 3
OpenXml
�
�
3 :
.
�
�
: ;
Spreadsheet
�
�
; F
.
�
�
F G

CellValues
�
�
G Q
.
�
�
Q R
String
�
�
R X
;
�
�
X Y
cell
�
�
 
.
�
�
 
	CellValue
�
�
 "
=
�
�
# $
new
�
�
% (
DocumentFormat
�
�
) 7
.
�
�
7 8
OpenXml
�
�
8 ?
.
�
�
? @
Spreadsheet
�
�
@ K
.
�
�
K L
	CellValue
�
�
L U
(
�
�
U V
column
�
�
V \
.
�
�
\ ]

ColumnName
�
�
] g
)
�
�
g h
;
�
�
h i
cell
�
�
 
.
�
�
 

StyleIndex
�
�
 #
=
�
�
$ %
$num
�
�
& '
;
�
�
' (
	headerRow
�
�
 
.
�
�
 
AppendChild
�
�
 )
(
�
�
) *
cell
�
�
* .
)
�
�
. /
;
�
�
/ 0
}
�
�
 
	sheetData
�
�
 
.
�
�
 
AppendChild
�
�
 %
(
�
�
% &
	headerRow
�
�
& /
)
�
�
/ 0
;
�
�
0 1
foreach
�
�
 
(
�
�
 
DataRow
�
�
  
dsrow
�
�
! &
in
�
�
' )
table
�
�
* /
.
�
�
/ 0
Rows
�
�
0 4
)
�
�
4 5
{
�
�
 
DocumentFormat
�
�
 "
.
�
�
" #
OpenXml
�
�
# *
.
�
�
* +
Spreadsheet
�
�
+ 6
.
�
�
6 7
Row
�
�
7 :
newRow
�
�
; A
=
�
�
B C
new
�
�
D G
DocumentFormat
�
�
H V
.
�
�
V W
OpenXml
�
�
W ^
.
�
�
^ _
Spreadsheet
�
�
_ j
.
�
�
j k
Row
�
�
k n
(
�
�
n o
)
�
�
o p
;
�
�
p q
foreach
�
�
 
(
�
�
 
String
�
�
 #
col
�
�
$ '
in
�
�
( *
columns
�
�
+ 2
)
�
�
2 3
{
�
�
 
DocumentFormat
�
�
 &
.
�
�
& '
OpenXml
�
�
' .
.
�
�
. /
Spreadsheet
�
�
/ :
.
�
�
: ;
Cell
�
�
; ?
cell
�
�
@ D
=
�
�
E F
new
�
�
G J
DocumentFormat
�
�
K Y
.
�
�
Y Z
OpenXml
�
�
Z a
.
�
�
a b
Spreadsheet
�
�
b m
.
�
�
m n
Cell
�
�
n r
(
�
�
r s
)
�
�
s t
;
�
�
t u
if
�
�
 
(
�
�
 
columnasfecha
�
�
 )
.
�
�
) *
Contains
�
�
* 2
(
�
�
2 3
col
�
�
3 6
)
�
�
6 7
)
�
�
7 8
{
�
�
 
DateTime
�
�
 $
celdadt
�
�
% ,
=
�
�
- .
DateTime
�
�
/ 7
.
�
�
7 8
Parse
�
�
8 =
(
�
�
= >
dsrow
�
�
> C
[
�
�
C D
col
�
�
D G
]
�
�
G H
.
�
�
H I
ToString
�
�
I Q
(
�
�
Q R
)
�
�
R S
)
�
�
S T
;
�
�
T U
string
�
�
 "
valueString
�
�
# .
=
�
�
/ 0
celdadt
�
�
1 8
.
�
�
8 9
ToOADate
�
�
9 A
(
�
�
A B
)
�
�
B C
.
�
�
C D
ToString
�
�
D L
(
�
�
L M
)
�
�
M N
;
�
�
N O
	CellValue
�
�
 %
	cellValue
�
�
& /
=
�
�
0 1
new
�
�
2 5
	CellValue
�
�
6 ?
(
�
�
? @
valueString
�
�
@ K
)
�
�
K L
;
�
�
L M
cell
�
�
  
.
�
�
  !
DataType
�
�
! )
=
�
�
* +
new
�
�
, /
	EnumValue
�
�
0 9
<
�
�
9 :

CellValues
�
�
: D
>
�
�
D E
(
�
�
E F

CellValues
�
�
F P
.
�
�
P Q
Number
�
�
Q W
)
�
�
W X
;
�
�
X Y
cell
�
�
  
.
�
�
  !

StyleIndex
�
�
! +
=
�
�
, -
$num
�
�
. /
;
�
�
/ 0
cell
�
�
  
.
�
�
  !
Append
�
�
! '
(
�
�
' (
	cellValue
�
�
( 1
)
�
�
1 2
;
�
�
2 3
}
�
�
 
else
�
�
 
if
�
�
 
(
�
�
  !
columnasmonto
�
�
! .
.
�
�
. /
Contains
�
�
/ 7
(
�
�
7 8
col
�
�
8 ;
)
�
�
; <
)
�
�
< =
{
�
�
 
cell
�
�
  
.
�
�
  !
DataType
�
�
! )
=
�
�
* +
DocumentFormat
�
�
, :
.
�
�
: ;
OpenXml
�
�
; B
.
�
�
B C
Spreadsheet
�
�
C N
.
�
�
N O

CellValues
�
�
O Y
.
�
�
Y Z
Number
�
�
Z `
;
�
�
` a
cell
�
�
  
.
�
�
  !
	CellValue
�
�
! *
=
�
�
+ ,
new
�
�
- 0
DocumentFormat
�
�
1 ?
.
�
�
? @
OpenXml
�
�
@ G
.
�
�
G H
Spreadsheet
�
�
H S
.
�
�
S T
	CellValue
�
�
T ]
(
�
�
] ^
dsrow
�
�
^ c
[
�
�
c d
col
�
�
d g
]
�
�
g h
.
�
�
h i
ToString
�
�
i q
(
�
�
q r
)
�
�
r s
)
�
�
s t
;
�
�
t u
cell
�
�
  
.
�
�
  !

StyleIndex
�
�
! +
=
�
�
, -
$num
�
�
. /
;
�
�
/ 0
}
�
�
 
else
�
�
 
if
�
�
 
(
�
�
  !
columnasstring
�
�
! /
.
�
�
/ 0
Contains
�
�
0 8
(
�
�
8 9
col
�
�
9 <
)
�
�
< =
)
�
�
= >
{
�
�
 
cell
�
�
  
.
�
�
  !

StyleIndex
�
�
! +
=
�
�
, -
$num
�
�
. /
;
�
�
/ 0
cell
�
�
  
.
�
�
  !
DataType
�
�
! )
=
�
�
* +
DocumentFormat
�
�
, :
.
�
�
: ;
OpenXml
�
�
; B
.
�
�
B C
Spreadsheet
�
�
C N
.
�
�
N O

CellValues
�
�
O Y
.
�
�
Y Z
String
�
�
Z `
;
�
�
` a
cell
�
�
  
.
�
�
  !
	CellValue
�
�
! *
=
�
�
+ ,
new
�
�
- 0
DocumentFormat
�
�
1 ?
.
�
�
? @
OpenXml
�
�
@ G
.
�
�
G H
Spreadsheet
�
�
H S
.
�
�
S T
	CellValue
�
�
T ]
(
�
�
] ^
dsrow
�
�
^ c
[
�
�
c d
col
�
�
d g
]
�
�
g h
.
�
�
h i
ToString
�
�
i q
(
�
�
q r
)
�
�
r s
)
�
�
s t
;
�
�
t u
}
�
�
 
else
�
�
 
if
�
�
 
(
�
�
  !
col
�
�
! $
.
�
�
$ %
Contains
�
�
% -
(
�
�
- .
$str
�
�
. B
)
�
�
B C
)
�
�
C D
{
�
�
 
string
�
�
 "
valorsemaforo
�
�
# 0
=
�
�
1 2
dsrow
�
�
3 8
[
�
�
8 9
col
�
�
9 <
]
�
�
< =
.
�
�
= >
ToString
�
�
> F
(
�
�
F G
)
�
�
G H
;
�
�
H I
if
�� 
(
��  
valorsemaforo
��  -
==
��. 0
$str
��1 6
)
��6 7
{
�� 
cell
��  $
.
��$ %

StyleIndex
��% /
=
��0 1
$num
��2 3
;
��3 4
}
�� 
else
��  
if
��! #
(
��$ %
valorsemaforo
��% 2
==
��3 5
$str
��6 ;
)
��; <
{
�� 
cell
��  $
.
��$ %

StyleIndex
��% /
=
��0 1
$num
��2 3
;
��3 4
}
�� 
else
��  
if
��! #
(
��$ %
valorsemaforo
��% 2
==
��3 5
$str
��6 ;
)
��; <
{
�� 
cell
��  $
.
��$ %

StyleIndex
��% /
=
��0 1
$num
��2 3
;
��3 4
}
�� 
else
��  
if
��! #
(
��$ %
valorsemaforo
��% 2
==
��3 5
$str
��6 ;
)
��; <
{
�� 
cell
��  $
.
��$ %

StyleIndex
��% /
=
��0 1
$num
��2 3
;
��3 4
}
�� 
else
��  
{
�� 
cell
��  $
.
��$ %

StyleIndex
��% /
=
��0 1
$num
��2 4
;
��4 5
}
�� 
cell
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cell
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
valorsemaforo
��^ k
)
��k l
;
��l m
}
�� 
else
�� 
if
�� 
(
��  !
columnassemaforos
��! 2
.
��2 3
Contains
��3 ;
(
��; <
col
��< ?
)
��? @
)
��@ A
{
��B C
cell
��  
.
��  !

StyleIndex
��! +
=
��, -
$num
��. 0
;
��0 1
cell
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cell
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
dsrow
��^ c
[
��c d
col
��d g
]
��g h
.
��h i
ToString
��i q
(
��q r
)
��r s
)
��s t
;
��t u
}
�� 
else
�� 
{
�� 
cell
��  
.
��  !

StyleIndex
��! +
=
��, -
$num
��. /
;
��/ 0
cell
��  
.
��  !
DataType
��! )
=
��* +
DocumentFormat
��, :
.
��: ;
OpenXml
��; B
.
��B C
Spreadsheet
��C N
.
��N O

CellValues
��O Y
.
��Y Z
String
��Z `
;
��` a
cell
��  
.
��  !
	CellValue
��! *
=
��+ ,
new
��- 0
DocumentFormat
��1 ?
.
��? @
OpenXml
��@ G
.
��G H
Spreadsheet
��H S
.
��S T
	CellValue
��T ]
(
��] ^
dsrow
��^ c
[
��c d
col
��d g
]
��g h
.
��h i
ToString
��i q
(
��q r
)
��r s
)
��s t
;
��t u
}
�� 
newRow
�� 
.
�� 
AppendChild
�� *
(
��* +
cell
��+ /
)
��/ 0
;
��0 1
}
�� 
	sheetData
�� 
.
�� 
AppendChild
�� )
(
��) *
newRow
��* 0
)
��0 1
;
��1 2
}
�� 
wsPart
�� 
.
�� 
	Worksheet
��  
.
��  !
Save
��! %
(
��% &
)
��& '
;
��' (
var
�� 
sheets
�� 
=
�� 
spreadsheet
�� (
.
��( )
WorkbookPart
��) 5
.
��5 6
Workbook
��6 >
.
��> ?
AppendChild
��? J
(
��J K
new
��K N
Sheets
��O U
(
��U V
)
��V W
)
��W X
;
��X Y
sheets
�� 
.
�� 
AppendChild
�� "
(
��" #
new
��# &
Sheet
��' ,
(
��, -
)
��- .
{
��/ 0
Id
��1 3
=
��4 5
spreadsheet
��6 A
.
��A B
WorkbookPart
��B N
.
��N O
GetIdOfPart
��O Z
(
��Z [
wsPart
��[ a
)
��a b
,
��b c
SheetId
��d k
=
��l m
$num
��n o
,
��o p
Name
��q u
=
��v w
$str��x �
}��� �
)��� �
;��� �
spreadsheet
�� 
.
�� 
WorkbookPart
�� (
.
��( )
Workbook
��) 1
.
��1 2
Save
��2 6
(
��6 7
)
��7 8
;
��8 9
}
�� 
}
�� 	
public
�� 
static
�� 
void
�� 
	AddToCell
�� $
(
��$ %
	SheetData
��% .
	sheetData
��/ 8
,
��8 9
UInt32Value
��: E

styleIndex
��F P
,
��P Q
UInt32
��R X
uint32rowIndex
��Y g
,
��g h
string
��i o
strColumnName
��p }
,
��} ~
DocumentFormat�� �
.��� �
OpenXml��� �
.��� �
	EnumValue��� �
<��� �

CellValues��� �
>��� �
CellDataType��� �
,��� �
string��� �
strCellValue��� �
)��� �
{
�� 	
Row
�� 
row
�� 
=
�� 
new
�� 
Row
�� 
(
�� 
)
�� 
{
��  !
RowIndex
��" *
=
��+ ,
uint32rowIndex
��- ;
}
��< =
;
��= >
Cell
�� 
cell
�� 
=
�� 
new
�� 
Cell
��  
(
��  !
)
��! "
;
��" #
cell
�� 
=
�� 
new
�� 
Cell
�� 
(
�� 
)
�� 
{
�� 

StyleIndex
��  *
=
��+ ,

styleIndex
��- 7
}
��8 9
;
��9 :
cell
�� 
.
�� 
CellReference
�� 
=
��  
strColumnName
��! .
+
��/ 0
row
��1 4
.
��4 5
RowIndex
��5 =
.
��= >
ToString
��> F
(
��F G
)
��G H
;
��H I
cell
�� 
.
�� 
DataType
�� 
=
�� 
CellDataType
�� (
;
��( )
cell
�� 
.
�� 
	CellValue
�� 
=
�� 
new
��  
	CellValue
��! *
(
��* +
strCellValue
��+ 7
)
��7 8
;
��8 9
row
�� 
.
�� 
AppendChild
�� 
(
�� 
cell
��  
)
��  !
;
��! "
	sheetData
�� 
.
�� 
Append
�� 
(
�� 
row
��  
)
��  !
;
��! "
}
�� 	
public
�� 
static
�� 
void
�� 
	ReadExcel
�� $
(
��$ %
string
��% +
path
��, 0
,
��0 1
DataSet
��2 9
ds
��: <
)
��< =
{
�� 	
using
�� 
(
�� 

FileStream
�� 
fs
��  
=
��! "
new
��# &

FileStream
��' 1
(
��1 2
path
��2 6
,
��6 7
FileMode
��8 @
.
��@ A
Open
��A E
,
��E F

FileAccess
��G Q
.
��Q R
Read
��R V
,
��V W
	FileShare
��X a
.
��a b
	ReadWrite
��b k
)
��k l
)
��l m
{
�� 
using
�� 
(
�� !
SpreadsheetDocument
�� *
doc
��+ .
=
��/ 0!
SpreadsheetDocument
��1 D
.
��D E
Open
��E I
(
��I J
fs
��J L
,
��L M
false
��N S
)
��S T
)
��T U
{
�� 
WorkbookPart
��  
workbookPart
��! -
=
��. /
doc
��0 3
.
��3 4
WorkbookPart
��4 @
;
��@ A#
SharedStringTablePart
�� )
sstpart
��* 1
=
��2 3
workbookPart
��4 @
.
��@ A
GetPartsOfType
��A O
<
��O P#
SharedStringTablePart
��P e
>
��e f
(
��f g
)
��g h
.
��h i
First
��i n
(
��n o
)
��o p
;
��p q
SharedStringTable
�� %
sst
��& )
=
��* +
sstpart
��, 3
.
��3 4
SharedStringTable
��4 E
;
��E F
WorksheetPart
�� !
worksheetPart
��" /
=
��0 1
workbookPart
��2 >
.
��> ?
WorksheetParts
��? M
.
��M N
First
��N S
(
��S T
)
��T U
;
��U V
	Worksheet
�� 
sheet
�� #
=
��$ %
worksheetPart
��& 3
.
��3 4
	Worksheet
��4 =
;
��= >
var
�� 
cells
�� 
=
�� 
sheet
��  %
.
��% &
Descendants
��& 1
<
��1 2
Cell
��2 6
>
��6 7
(
��7 8
)
��8 9
;
��9 :
var
�� 
rows
�� 
=
�� 
sheet
�� $
.
��$ %
Descendants
��% 0
<
��0 1
Row
��1 4
>
��4 5
(
��5 6
)
��6 7
;
��7 8
Console
�� 
.
�� 
	WriteLine
�� %
(
��% &
$str
��& 7
,
��7 8
rows
��9 =
.
��= >
	LongCount
��> G
(
��G H
)
��H I
)
��I J
;
��J K
Console
�� 
.
�� 
	WriteLine
�� %
(
��% &
$str
��& 8
,
��8 9
cells
��: ?
.
��? @
	LongCount
��@ I
(
��I J
)
��J K
)
��K L
;
��L M
foreach
�� 
(
�� 
Cell
�� !
cell
��" &
in
��' )
cells
��* /
)
��/ 0
{
�� 
if
�� 
(
�� 
(
�� 
cell
�� !
.
��! "
DataType
��" *
!=
��+ -
null
��. 2
)
��2 3
&&
��4 6
(
��7 8
cell
��8 <
.
��< =
DataType
��= E
==
��F H

CellValues
��I S
.
��S T
SharedString
��T `
)
��` a
)
��a b
{
�� 
int
�� 
ssid
��  $
=
��% &
int
��' *
.
��* +
Parse
��+ 0
(
��0 1
cell
��1 5
.
��5 6
	CellValue
��6 ?
.
��? @
Text
��@ D
)
��D E
;
��E F
string
�� "
str
��# &
=
��' (
sst
��) ,
.
��, -
ChildElements
��- :
[
��: ;
ssid
��; ?
]
��? @
.
��@ A
	InnerText
��A J
;
��J K
Console
�� #
.
��# $
	WriteLine
��$ -
(
��- .
$str
��. F
,
��F G
ssid
��H L
,
��L M
str
��N Q
)
��Q R
;
��R S
}
�� 
else
�� 
if
�� 
(
��  !
cell
��! %
.
��% &
	CellValue
��& /
!=
��0 2
null
��3 7
)
��7 8
{
�� 
Console
�� #
.
��# $
	WriteLine
��$ -
(
��- .
$str
��. B
,
��B C
cell
��D H
.
��H I
	CellValue
��I R
.
��R S
Text
��S W
)
��W X
;
��X Y
}
�� 
}
�� 
foreach
�� 
(
�� 
Row
��  
row
��! $
in
��% '
rows
��( ,
)
��, -
{
�� 
foreach
�� 
(
��  !
Cell
��! %
c
��& '
in
��( *
row
��+ .
.
��. /
Elements
��/ 7
<
��7 8
Cell
��8 <
>
��< =
(
��= >
)
��> ?
)
��? @
{
�� 
if
�� 
(
��  
(
��  !
c
��! "
.
��" #
DataType
��# +
!=
��, .
null
��/ 3
)
��3 4
&&
��5 7
(
��8 9
c
��9 :
.
��: ;
DataType
��; C
==
��D F

CellValues
��G Q
.
��Q R
SharedString
��R ^
)
��^ _
)
��_ `
{
�� 
int
��  #
ssid
��$ (
=
��) *
int
��+ .
.
��. /
Parse
��/ 4
(
��4 5
c
��5 6
.
��6 7
	CellValue
��7 @
.
��@ A
Text
��A E
)
��E F
;
��F G
string
��  &
str
��' *
=
��+ ,
sst
��- 0
.
��0 1
ChildElements
��1 >
[
��> ?
ssid
��? C
]
��C D
.
��D E
	InnerText
��E N
;
��N O
Console
��  '
.
��' (
	WriteLine
��( 1
(
��1 2
$str
��2 J
,
��J K
ssid
��L P
,
��P Q
str
��R U
)
��U V
;
��V W
}
�� 
else
��  
if
��! #
(
��$ %
c
��% &
.
��& '
	CellValue
��' 0
!=
��1 3
null
��4 8
)
��8 9
{
�� 
Console
��  '
.
��' (
	WriteLine
��( 1
(
��1 2
$str
��2 F
,
��F G
c
��H I
.
��I J
	CellValue
��J S
.
��S T
Text
��T X
)
��X Y
;
��Y Z
}
�� 
}
�� 
}
�� 
}
�� 
}
�� 
}
�� 	
public
�� 
static
�� 
string
��  
MonthByDescription
�� /
(
��/ 0
string
��0 6
descriptionMonth
��7 G
)
��G H
{
�� 	
string
�� 
_month
�� 
=
�� 
string
�� "
.
��" #
Empty
��# (
;
��( )
switch
�� 
(
�� 
descriptionMonth
�� #
.
��# $
ToUpper
��$ +
(
��+ ,
)
��, -
.
��- .
Trim
��. 2
(
��2 3
)
��3 4
)
��4 5
{
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
��  
:
��  !
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� !
:
��! "
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
�� 
:
�� 
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
��  
:
��  !
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
case
�� 
$str
��  
:
��  !
_month
�� 
=
�� 
$str
�� !
;
��! "
break
�� 
;
�� 
}
�� 
return
�� 
_month
�� 
;
�� 
}
�� 	
public
�� 
static
�� 
string
�� 
CleanBase64File
�� ,
(
��, -
string
��- 3
base64String
��4 @
)
��@ A
{
�� 	
base64String
�� 
=
�� 
base64String
�� '
.
��' (
Replace
��( /
(
��/ 0
$str��0 �
,��� �
$str��� �
)��� �
;��� �
base64String
�� 
=
�� 
base64String
�� '
.
��' (
Replace
��( /
(
��/ 0
$str��0 �
,��� �
$str��� �
)��� �
;��� �
base64String
�� 
=
�� 
base64String
�� '
.
��' (
Replace
��( /
(
��/ 0
$str
��0 N
,
��N O
$str
��P R
)
��R S
;
��S T
base64String
�� 
=
�� 
base64String
�� '
.
��' (
Replace
��( /
(
��/ 0
$str
��0 I
,
��I J
$str
��K M
)
��M N
;
��N O
base64String
�� 
=
�� 
base64String
�� '
.
��' (
Replace
��( /
(
��/ 0
$str
��0 H
,
��H I
$str
��J L
)
��L M
;
��M N
base64String
�� 
=
�� 
base64String
�� '
.
��' (
Replace
��( /
(
��/ 0
$str
��0 W
,
��W X
$str
��Y [
)
��[ \
;
��\ ]
return
�� 
base64String
�� 
;
��  
}
�� 	
}
�� 
}�� �
_D:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.CrossCutting\Utils\LeerHtml.cs
	namespace 	
HumanManagement
 
. 
CrossCutting &
.& '
Utils' ,
{ 
public 

class 
LeerHtml 
{ 
public 
static 
string 
LeerTemplateHTML -
(- .
string. 4
url5 8
)8 9
{ 	
using		 
(		 
StreamReader		 
lector		  &
=		' (
new		) ,
StreamReader		- 9
(		9 :
url		: =
,		= >
System		? E
.		E F
Text		F J
.		J K
Encoding		K S
.		S T
UTF8		T X
)		X Y
)		Y Z
{

 
return 
lector 
. 
	ReadToEnd '
(' (
)( )
;) *
} 
} 	
} 
} �
dD:\GIT_EFITEC2021\GrupoFeFaseDos\HumanManagement\HumanManagement.CrossCutting\Utils\Notifications.cs
	namespace 	
HumanManagement
 
. 
CrossCutting &
.& '
Utils' ,
{ 
public		 

class		 
Notifications		 
:		  
Hub		! $
{

 
public 
override 
Task 
OnConnectedAsync -
(- .
). /
{ 	
return 
base 
. 
OnConnectedAsync (
(( )
)) *
;* +
} 	
public 
Task 
NotificationAll #
(# $
string$ *
mensaje+ 2
)2 3
{ 	
return 
Clients 
. 
All 
. 
	SendAsync (
(( )
$str) <
,< =
mensaje> E
)E F
;F G
} 	
} 
} 