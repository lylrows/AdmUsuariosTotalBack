ﬁ®
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
ÄÄ 
string
ÄÄ .
 PostulantSelectedInternaColorDiv
ÄÄ 6
{
ÄÄ7 8
get
ÄÄ9 <
;
ÄÄ< =
set
ÄÄ> A
;
ÄÄA B
}
ÄÄC D
public
ÅÅ 
string
ÅÅ 1
#PostulantSelectedInternaColorButton
ÅÅ 9
{
ÅÅ: ;
get
ÅÅ< ?
;
ÅÅ? @
set
ÅÅA D
;
ÅÅD E
}
ÅÅF G
public
ÇÇ 
string
ÇÇ 2
$PostulantSelectedInternaTemplateHtml
ÇÇ :
{
ÇÇ; <
get
ÇÇ= @
;
ÇÇ@ A
set
ÇÇB E
;
ÇÇE F
}
ÇÇG H
public
ÉÉ 
string
ÉÉ 2
$PostulantSelectedInternaUrlInduccion
ÉÉ :
{
ÉÉ; <
get
ÉÉ= @
;
ÉÉ@ A
set
ÉÉB E
;
ÉÉE F
}
ÉÉG H
public
ÖÖ 
string
ÖÖ 3
%TemplateSendNotificationFichaPersonal
ÖÖ ;
{
ÖÖ< =
get
ÖÖ> A
;
ÖÖA B
set
ÖÖC F
;
ÖÖF G
}
ÖÖH I
public
ÜÜ 
string
ÜÜ +
UrlPostulantEvaluationInterna
ÜÜ 3
{
ÜÜ4 5
get
ÜÜ6 9
;
ÜÜ9 :
set
ÜÜ; >
;
ÜÜ> ?
}
ÜÜ@ A
public
áá 
string
áá +
UrlPostulantEvaluationExterna
áá 3
{
áá4 5
get
áá6 9
;
áá9 :
set
áá; >
;
áá> ?
}
áá@ A
public
àà 
string
àà (
UrlPostulantAdministration
àà 0
{
àà1 2
get
àà3 6
;
àà6 7
set
àà8 ;
;
àà; <
}
àà= >
}
ââ 
}ää ˇ*
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
}OO ï*
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
}YY á¿
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
Workbook	y Å
)
Å Ç
)
Ç É
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
None	.. É
}
..Ñ Ö
}
..Ü á
)
..á à
;
..à â

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
Gray125	// Ü
}
//á à
}
//â ä
)
//ä ã
;
//ã å

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
@@Ä Å
,
@@Å Ç
	ApplyFill
@@É å
=
@@ç é
true
@@è ì
}
@@î ï
)
@@ï ñ
.
@@ñ ó
AppendChild
@@ó ¢
(
@@¢ £
new
@@£ ¶
	Alignment
@@ß ∞
{
@@± ≤

Horizontal
@@≥ Ω
=
@@æ ø'
HorizontalAlignmentValues
@@¿ Ÿ
.
@@Ÿ ⁄
Center
@@⁄ ‡
}
@@· ‚
)
@@‚ „
;
@@„ ‰

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
AAÄ Å
,
AAÅ Ç
	ApplyFill
AAÉ å
=
AAç é
true
AAè ì
}
AAî ï
)
AAï ñ
.
AAñ ó
AppendChild
AAó ¢
(
AA¢ £
new
AA£ ¶
	Alignment
AAß ∞
{
AA± ≤

Horizontal
AA≥ Ω
=
AAæ ø'
HorizontalAlignmentValues
AA¿ Ÿ
.
AAŸ ⁄
Left
AA⁄ ﬁ
}
AAﬂ ‡
)
AA‡ ·
;
AA· ‚

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
DocumentFormat	NNt Ç
.
NNÇ É
OpenXml
NNÉ ä
.
NNä ã
Spreadsheet
NNã ñ
.
NNñ ó
Sheets
NNó ù
>
NNù û
(
NNû ü
)
NNü †
;
NN† °
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
relationshipId	WW{ â
,
WWâ ä
SheetId
WWã í
=
WWì î
sheetId
WWï ú
,
WWú ù
Name
WWû ¢
=
WW£ §
table
WW• ™
.
WW™ ´
	TableName
WW´ ¥
}
WWµ ∂
;
WW∂ ∑
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
ÄÄ 
.
ÄÄ  
Add
ÄÄ  #
(
ÄÄ# $
column
ÄÄ$ *
.
ÄÄ* +

ColumnName
ÄÄ+ 5
)
ÄÄ5 6
;
ÄÄ6 7
DocumentFormat
ÇÇ &
.
ÇÇ& '
OpenXml
ÇÇ' .
.
ÇÇ. /
Spreadsheet
ÇÇ/ :
.
ÇÇ: ;
Cell
ÇÇ; ?
cell
ÇÇ@ D
=
ÇÇE F
new
ÇÇG J
DocumentFormat
ÇÇK Y
.
ÇÇY Z
OpenXml
ÇÇZ a
.
ÇÇa b
Spreadsheet
ÇÇb m
.
ÇÇm n
Cell
ÇÇn r
(
ÇÇr s
)
ÇÇs t
;
ÇÇt u
cell
ÉÉ 
.
ÉÉ 
DataType
ÉÉ %
=
ÉÉ& '
DocumentFormat
ÉÉ( 6
.
ÉÉ6 7
OpenXml
ÉÉ7 >
.
ÉÉ> ?
Spreadsheet
ÉÉ? J
.
ÉÉJ K

CellValues
ÉÉK U
.
ÉÉU V
String
ÉÉV \
;
ÉÉ\ ]
cell
ÑÑ 
.
ÑÑ 
	CellValue
ÑÑ &
=
ÑÑ' (
new
ÑÑ) ,
DocumentFormat
ÑÑ- ;
.
ÑÑ; <
OpenXml
ÑÑ< C
.
ÑÑC D
Spreadsheet
ÑÑD O
.
ÑÑO P
	CellValue
ÑÑP Y
(
ÑÑY Z
column
ÑÑZ `
.
ÑÑ` a

ColumnName
ÑÑa k
)
ÑÑk l
;
ÑÑl m
cell
ÖÖ 
.
ÖÖ 

StyleIndex
ÖÖ '
=
ÖÖ( )
$num
ÖÖ* +
;
ÖÖ+ ,
	headerRow
ÜÜ !
.
ÜÜ! "
AppendChild
ÜÜ" -
(
ÜÜ- .
cell
ÜÜ. 2
)
ÜÜ2 3
;
ÜÜ3 4
}
áá 
	sheetData
ââ 
.
ââ 
AppendChild
ââ )
(
ââ) *
	headerRow
ââ* 3
)
ââ3 4
;
ââ4 5
foreach
ãã 
(
ãã 
DataRow
ãã $
dsrow
ãã% *
in
ãã+ -
table
ãã. 3
.
ãã3 4
Rows
ãã4 8
)
ãã8 9
{
åå 
DocumentFormat
çç &
.
çç& '
OpenXml
çç' .
.
çç. /
Spreadsheet
çç/ :
.
çç: ;
Row
çç; >
newRow
çç? E
=
ççF G
new
ççH K
DocumentFormat
ççL Z
.
ççZ [
OpenXml
çç[ b
.
ççb c
Spreadsheet
ççc n
.
ççn o
Row
çço r
(
ççr s
)
ççs t
;
ççt u
foreach
éé 
(
éé  !
String
éé! '
col
éé( +
in
éé, .
columns
éé/ 6
)
éé6 7
{
èè 
DocumentFormat
êê *
.
êê* +
OpenXml
êê+ 2
.
êê2 3
Spreadsheet
êê3 >
.
êê> ?
Cell
êê? C
cell
êêD H
=
êêI J
new
êêK N
DocumentFormat
êêO ]
.
êê] ^
OpenXml
êê^ e
.
êêe f
Spreadsheet
êêf q
.
êêq r
Cell
êêr v
(
êêv w
)
êêw x
;
êêx y
cell
ëë  
.
ëë  !
DataType
ëë! )
=
ëë* +
DocumentFormat
ëë, :
.
ëë: ;
OpenXml
ëë; B
.
ëëB C
Spreadsheet
ëëC N
.
ëëN O

CellValues
ëëO Y
.
ëëY Z
String
ëëZ `
;
ëë` a
cell
íí  
.
íí  !
	CellValue
íí! *
=
íí+ ,
new
íí- 0
DocumentFormat
íí1 ?
.
íí? @
OpenXml
íí@ G
.
ííG H
Spreadsheet
ííH S
.
ííS T
	CellValue
ííT ]
(
íí] ^
dsrow
íí^ c
[
ííc d
col
ííd g
]
ííg h
.
ííh i
ToString
ííi q
(
ííq r
)
íír s
)
íís t
;
íít u
cell
ìì  
.
ìì  !

StyleIndex
ìì! +
=
ìì, -
$num
ìì. /
;
ìì/ 0
newRow
îî "
.
îî" #
AppendChild
îî# .
(
îî. /
cell
îî/ 3
)
îî3 4
;
îî4 5
}
ïï 
	sheetData
óó !
.
óó! "
AppendChild
óó" -
(
óó- .
newRow
óó. 4
)
óó4 5
;
óó5 6
}
òò 
}
ôô 
}
öö 
}
õõ 	
public
úú 
static
úú 
void
úú '
DataTableToExcelWithStyle
úú 4
(
úú4 5
	DataTable
úú5 >
table
úú? D
,
úúD E
string
úúF L
destination
úúM X
)
úúX Y
{
ùù 	
try
ûû 
{
üü 
using
†† 
(
†† 
var
†† 
spreadsheet
†† &
=
††' (!
SpreadsheetDocument
††) <
.
††< =
Create
††= C
(
††C D
destination
††D O
,
††O P%
SpreadsheetDocumentType
††Q h
.
††h i
Workbook
††i q
)
††q r
)
††r s
{
°° 
spreadsheet
¢¢ 
.
¢¢  
AddWorkbookPart
¢¢  /
(
¢¢/ 0
)
¢¢0 1
;
¢¢1 2
spreadsheet
££ 
.
££  
WorkbookPart
££  ,
.
££, -
Workbook
££- 5
=
££6 7
new
££8 ;
Workbook
££< D
(
££D E
)
££E F
;
££F G
var
§§ 
wsPart
§§ 
=
§§  
spreadsheet
§§! ,
.
§§, -
WorkbookPart
§§- 9
.
§§9 :

AddNewPart
§§: D
<
§§D E
WorksheetPart
§§E R
>
§§R S
(
§§S T
)
§§T U
;
§§U V
wsPart
•• 
.
•• 
	Worksheet
•• $
=
••% &
new
••' *
	Worksheet
••+ 4
(
••4 5
)
••5 6
;
••6 7
var
ßß 

stylesPart
ßß "
=
ßß# $
spreadsheet
ßß% 0
.
ßß0 1
WorkbookPart
ßß1 =
.
ßß= >

AddNewPart
ßß> H
<
ßßH I 
WorkbookStylesPart
ßßI [
>
ßß[ \
(
ßß\ ]
)
ßß] ^
;
ßß^ _

stylesPart
®® 
.
®® 

Stylesheet
®® )
=
®®* +
new
®®, /

Stylesheet
®®0 :
(
®®: ;
)
®®; <
;
®®< =
Font
´´ 
font
´´ 
=
´´ 
new
´´  #
Font
´´$ (
(
´´( )
)
´´) *
;
´´* +
font
¨¨ 
.
¨¨ 
Append
¨¨ 
(
¨¨  
new
¨¨  #
Color
¨¨$ )
(
¨¨) *
)
¨¨* +
{
¨¨, -
Rgb
¨¨. 1
=
¨¨2 3
$str
¨¨4 <
}
¨¨= >
)
¨¨> ?
;
¨¨? @
font
≠≠ 
.
≠≠ 
Append
≠≠ 
(
≠≠  
new
≠≠  #
Bold
≠≠$ (
(
≠≠( )
)
≠≠) *
)
≠≠* +
;
≠≠+ ,

stylesPart
∞∞ 
.
∞∞ 

Stylesheet
∞∞ )
.
∞∞) *
Fonts
∞∞* /
=
∞∞0 1
new
∞∞2 5
Fonts
∞∞6 ;
(
∞∞; <
)
∞∞< =
;
∞∞= >

stylesPart
±± 
.
±± 

Stylesheet
±± )
.
±±) *
Fonts
±±* /
.
±±/ 0
Count
±±0 5
=
±±6 7
$num
±±8 9
;
±±9 :

stylesPart
≤≤ 
.
≤≤ 

Stylesheet
≤≤ )
.
≤≤) *
Fonts
≤≤* /
.
≤≤/ 0
AppendChild
≤≤0 ;
(
≤≤; <
font
≤≤< @
)
≤≤@ A
;
≤≤A B

stylesPart
≥≥ 
.
≥≥ 

Stylesheet
≥≥ )
.
≥≥) *
Fonts
≥≥* /
.
≥≥/ 0
AppendChild
≥≥0 ;
(
≥≥; <
new
≥≥< ?
Font
≥≥@ D
{
≥≥E F
Color
≥≥G L
=
≥≥M N
new
≥≥O R
Color
≥≥S X
(
≥≥X Y
)
≥≥Y Z
{
≥≥[ \
Rgb
≥≥] `
=
≥≥a b
$str
≥≥c k
}
≥≥l m
}
≥≥n o
)
≥≥o p
;
≥≥p q

stylesPart
∂∂ 
.
∂∂ 

Stylesheet
∂∂ )
.
∂∂) *
Fills
∂∂* /
=
∂∂0 1
new
∂∂2 5
Fills
∂∂6 ;
(
∂∂; <
)
∂∂< =
;
∂∂= >
var
ππ 
solidRed
ππ  
=
ππ! "
new
ππ# &
PatternFill
ππ' 2
(
ππ2 3
)
ππ3 4
{
ππ5 6
PatternType
ππ7 B
=
ππC D
PatternValues
ππE R
.
ππR S
Solid
ππS X
}
ππY Z
;
ππZ [
solidRed
∫∫ 
.
∫∫ 
ForegroundColor
∫∫ ,
=
∫∫- .
new
∫∫/ 2
ForegroundColor
∫∫3 B
{
∫∫C D
Rgb
∫∫E H
=
∫∫I J
HexBinaryValue
∫∫K Y
.
∫∫Y Z

FromString
∫∫Z d
(
∫∫d e
$str
∫∫e m
)
∫∫m n
}
∫∫o p
;
∫∫p q
solidRed
ªª 
.
ªª 
BackgroundColor
ªª ,
=
ªª- .
new
ªª/ 2
BackgroundColor
ªª3 B
{
ªªC D
Indexed
ªªE L
=
ªªM N
$num
ªªO Q
}
ªªR S
;
ªªS T

stylesPart
ΩΩ 
.
ΩΩ 

Stylesheet
ΩΩ )
.
ΩΩ) *
Fills
ΩΩ* /
.
ΩΩ/ 0
AppendChild
ΩΩ0 ;
(
ΩΩ; <
new
ΩΩ< ?
Fill
ΩΩ@ D
{
ΩΩE F
PatternFill
ΩΩG R
=
ΩΩS T
new
ΩΩU X
PatternFill
ΩΩY d
{
ΩΩe f
PatternType
ΩΩg r
=
ΩΩs t
PatternValuesΩΩu Ç
.ΩΩÇ É
NoneΩΩÉ á
}ΩΩà â
}ΩΩä ã
)ΩΩã å
;ΩΩå ç

stylesPart
ææ 
.
ææ 

Stylesheet
ææ )
.
ææ) *
Fills
ææ* /
.
ææ/ 0
AppendChild
ææ0 ;
(
ææ; <
new
ææ< ?
Fill
ææ@ D
{
ææE F
PatternFill
ææG R
=
ææS T
new
ææU X
PatternFill
ææY d
{
ææe f
PatternType
ææg r
=
ææs t
PatternValuesææu Ç
.ææÇ É
Gray125ææÉ ä
}ææã å
}ææç é
)ææé è
;ææè ê

stylesPart
øø 
.
øø 

Stylesheet
øø )
.
øø) *
Fills
øø* /
.
øø/ 0
AppendChild
øø0 ;
(
øø; <
new
øø< ?
Fill
øø@ D
{
øøE F
PatternFill
øøG R
=
øøS T
solidRed
øøU ]
}
øø^ _
)
øø_ `
;
øø` a

stylesPart
¿¿ 
.
¿¿ 

Stylesheet
¿¿ )
.
¿¿) *
Fills
¿¿* /
.
¿¿/ 0
Count
¿¿0 5
=
¿¿6 7
$num
¿¿8 9
;
¿¿9 :

stylesPart
√√ 
.
√√ 

Stylesheet
√√ )
.
√√) *
Borders
√√* 1
=
√√2 3
new
√√4 7
Borders
√√8 ?
(
√√? @
)
√√@ A
;
√√A B

stylesPart
ƒƒ 
.
ƒƒ 

Stylesheet
ƒƒ )
.
ƒƒ) *
Borders
ƒƒ* 1
.
ƒƒ1 2
Count
ƒƒ2 7
=
ƒƒ8 9
$num
ƒƒ: ;
;
ƒƒ; <

stylesPart
≈≈ 
.
≈≈ 

Stylesheet
≈≈ )
.
≈≈) *
Borders
≈≈* 1
.
≈≈1 2
AppendChild
≈≈2 =
(
≈≈= >
new
≈≈> A
Border
≈≈B H
(
≈≈H I
)
≈≈I J
)
≈≈J K
;
≈≈K L

stylesPart
»» 
.
»» 

Stylesheet
»» )
.
»») *
CellStyleFormats
»»* :
=
»»; <
new
»»= @
CellStyleFormats
»»A Q
(
»»Q R
)
»»R S
;
»»S T

stylesPart
…… 
.
…… 

Stylesheet
…… )
.
……) *
CellStyleFormats
……* :
.
……: ;
Count
……; @
=
……A B
$num
……C D
;
……D E

stylesPart
   
.
   

Stylesheet
   )
.
  ) *
CellStyleFormats
  * :
.
  : ;
AppendChild
  ; F
(
  F G
new
  G J

CellFormat
  K U
(
  U V
)
  V W
)
  W X
;
  X Y

stylesPart
ÕÕ 
.
ÕÕ 

Stylesheet
ÕÕ )
.
ÕÕ) *
CellFormats
ÕÕ* 5
=
ÕÕ6 7
new
ÕÕ8 ;
CellFormats
ÕÕ< G
(
ÕÕG H
)
ÕÕH I
;
ÕÕI J

stylesPart
ŒŒ 
.
ŒŒ 

Stylesheet
ŒŒ )
.
ŒŒ) *
CellFormats
ŒŒ* 5
.
ŒŒ5 6
AppendChild
ŒŒ6 A
(
ŒŒA B
new
ŒŒB E

CellFormat
ŒŒF P
(
ŒŒP Q
)
ŒŒQ R
)
ŒŒR S
;
ŒŒS T

stylesPart
œœ 
.
œœ 

Stylesheet
œœ )
.
œœ) *
CellFormats
œœ* 5
.
œœ5 6
AppendChild
œœ6 A
(
œœA B
new
œœB E

CellFormat
œœF P
{
œœQ R
FormatId
œœS [
=
œœ\ ]
$num
œœ^ _
,
œœ_ `
FontId
œœa g
=
œœh i
$num
œœj k
,
œœk l
BorderId
œœm u
=
œœv w
$num
œœx y
,
œœy z
FillIdœœ{ Å
=œœÇ É
$numœœÑ Ö
,œœÖ Ü
	ApplyFillœœá ê
=œœë í
trueœœì ó
}œœò ô
)œœô ö
.œœö õ
AppendChildœœõ ¶
(œœ¶ ß
newœœß ™
	Alignmentœœ´ ¥
{œœµ ∂

Horizontalœœ∑ ¡
=œœ¬ √)
HorizontalAlignmentValuesœœƒ ›
.œœ› ﬁ
Centerœœﬁ ‰
}œœÂ Ê
)œœÊ Á
;œœÁ Ë

stylesPart
–– 
.
–– 

Stylesheet
–– )
.
––) *
CellFormats
––* 5
.
––5 6
AppendChild
––6 A
(
––A B
new
––B E

CellFormat
––F P
{
––Q R
FormatId
––S [
=
––\ ]
$num
––^ _
,
––_ `
FontId
––a g
=
––h i
$num
––j k
,
––k l
BorderId
––m u
=
––v w
$num
––x y
,
––y z
FillId––{ Å
=––Ç É
$num––Ñ Ö
,––Ö Ü
	ApplyFill––á ê
=––ë í
true––ì ó
}––ò ô
)––ô ö
.––ö õ
AppendChild––õ ¶
(––¶ ß
new––ß ™
	Alignment––´ ¥
{––µ ∂

Horizontal––∑ ¡
=––¬ √)
HorizontalAlignmentValues––ƒ ›
.––› ﬁ
Left––ﬁ ‚
}––„ ‰
)––‰ Â
;––Â Ê

stylesPart
‘‘ 
.
‘‘ 

Stylesheet
‘‘ )
.
‘‘) *
Save
‘‘* .
(
‘‘. /
)
‘‘/ 0
;
‘‘0 1
Columns
◊◊ 
columnExcel
◊◊ '
=
◊◊( )
new
◊◊* -
Columns
◊◊. 5
(
◊◊5 6
)
◊◊6 7
;
◊◊7 8
int
ÿÿ 
contadorColumn
ÿÿ &
=
ÿÿ' (
$num
ÿÿ) *
;
ÿÿ* +
foreach
⁄⁄ 
(
⁄⁄ 

DataColumn
⁄⁄ '
column
⁄⁄( .
in
⁄⁄/ 1
table
⁄⁄2 7
.
⁄⁄7 8
Columns
⁄⁄8 ?
)
⁄⁄? @
{
€€ 
columnExcel
‹‹ #
.
‹‹# $
Append
‹‹$ *
(
‹‹* +
new
‹‹+ .
Column
‹‹/ 5
(
‹‹5 6
)
‹‹6 7
{
‹‹8 9
Min
‹‹: =
=
‹‹> ?
Convert
‹‹@ G
.
‹‹G H
ToUInt32
‹‹H P
(
‹‹P Q
contadorColumn
‹‹Q _
)
‹‹_ `
,
‹‹` a
Max
‹‹b e
=
‹‹f g
Convert
‹‹h o
.
‹‹o p
ToUInt32
‹‹p x
(
‹‹x y
contadorColumn‹‹y á
)‹‹á à
,‹‹à â
Width‹‹ä è
=‹‹ê ë
$num‹‹í î
,‹‹î ï
CustomWidth‹‹ñ °
=‹‹¢ £
true‹‹§ ®
}‹‹© ™
)‹‹™ ´
;‹‹´ ¨
contadorColumn
›› &
++
››& (
;
››( )
}
ﬁﬁ 
wsPart
·· 
.
·· 
	Worksheet
·· $
.
··$ %
Append
··% +
(
··+ ,
columnExcel
··, 7
)
··7 8
;
··8 9
var
„„ 
	sheetData
„„ !
=
„„" #
wsPart
„„$ *
.
„„* +
	Worksheet
„„+ 4
.
„„4 5
AppendChild
„„5 @
(
„„@ A
new
„„A D
	SheetData
„„E N
(
„„N O
)
„„O P
)
„„P Q
;
„„Q R
DocumentFormat
ÊÊ "
.
ÊÊ" #
OpenXml
ÊÊ# *
.
ÊÊ* +
Spreadsheet
ÊÊ+ 6
.
ÊÊ6 7
Row
ÊÊ7 :
	headerRow
ÊÊ; D
=
ÊÊE F
new
ÊÊG J
DocumentFormat
ÊÊK Y
.
ÊÊY Z
OpenXml
ÊÊZ a
.
ÊÊa b
Spreadsheet
ÊÊb m
.
ÊÊm n
Row
ÊÊn q
(
ÊÊq r
)
ÊÊr s
;
ÊÊs t
List
ÁÁ 
<
ÁÁ 
String
ÁÁ 
>
ÁÁ  
columns
ÁÁ! (
=
ÁÁ) *
new
ÁÁ+ .
List
ÁÁ/ 3
<
ÁÁ3 4
string
ÁÁ4 :
>
ÁÁ: ;
(
ÁÁ; <
)
ÁÁ< =
;
ÁÁ= >
foreach
ËË 
(
ËË 

DataColumn
ËË '
column
ËË( .
in
ËË/ 1
table
ËË2 7
.
ËË7 8
Columns
ËË8 ?
)
ËË? @
{
ÈÈ 
columns
ÍÍ 
.
ÍÍ  
Add
ÍÍ  #
(
ÍÍ# $
column
ÍÍ$ *
.
ÍÍ* +

ColumnName
ÍÍ+ 5
)
ÍÍ5 6
;
ÍÍ6 7
DocumentFormat
ÏÏ &
.
ÏÏ& '
OpenXml
ÏÏ' .
.
ÏÏ. /
Spreadsheet
ÏÏ/ :
.
ÏÏ: ;
Cell
ÏÏ; ?
cell
ÏÏ@ D
=
ÏÏE F
new
ÏÏG J
DocumentFormat
ÏÏK Y
.
ÏÏY Z
OpenXml
ÏÏZ a
.
ÏÏa b
Spreadsheet
ÏÏb m
.
ÏÏm n
Cell
ÏÏn r
(
ÏÏr s
)
ÏÏs t
;
ÏÏt u
cell
ÓÓ 
.
ÓÓ 
DataType
ÓÓ %
=
ÓÓ& '
DocumentFormat
ÓÓ( 6
.
ÓÓ6 7
OpenXml
ÓÓ7 >
.
ÓÓ> ?
Spreadsheet
ÓÓ? J
.
ÓÓJ K

CellValues
ÓÓK U
.
ÓÓU V
String
ÓÓV \
;
ÓÓ\ ]
cell
ÔÔ 
.
ÔÔ 
	CellValue
ÔÔ &
=
ÔÔ' (
new
ÔÔ) ,
DocumentFormat
ÔÔ- ;
.
ÔÔ; <
OpenXml
ÔÔ< C
.
ÔÔC D
Spreadsheet
ÔÔD O
.
ÔÔO P
	CellValue
ÔÔP Y
(
ÔÔY Z
column
ÔÔZ `
.
ÔÔ` a

ColumnName
ÔÔa k
)
ÔÔk l
;
ÔÔl m
cell
 
.
 

StyleIndex
 '
=
( )
$num
* +
;
+ ,
	headerRow
ÒÒ !
.
ÒÒ! "
AppendChild
ÒÒ" -
(
ÒÒ- .
cell
ÒÒ. 2
)
ÒÒ2 3
;
ÒÒ3 4
}
ÚÚ 
	sheetData
ÛÛ 
.
ÛÛ 
AppendChild
ÛÛ )
(
ÛÛ) *
	headerRow
ÛÛ* 3
)
ÛÛ3 4
;
ÛÛ4 5
foreach
ıı 
(
ıı 
DataRow
ıı $
dsrow
ıı% *
in
ıı+ -
table
ıı. 3
.
ıı3 4
Rows
ıı4 8
)
ıı8 9
{
ˆˆ 
DocumentFormat
˜˜ &
.
˜˜& '
OpenXml
˜˜' .
.
˜˜. /
Spreadsheet
˜˜/ :
.
˜˜: ;
Row
˜˜; >
newRow
˜˜? E
=
˜˜F G
new
˜˜H K
DocumentFormat
˜˜L Z
.
˜˜Z [
OpenXml
˜˜[ b
.
˜˜b c
Spreadsheet
˜˜c n
.
˜˜n o
Row
˜˜o r
(
˜˜r s
)
˜˜s t
;
˜˜t u
foreach
¯¯ 
(
¯¯  !
String
¯¯! '
col
¯¯( +
in
¯¯, .
columns
¯¯/ 6
)
¯¯6 7
{
˘˘ 
DocumentFormat
˙˙ *
.
˙˙* +
OpenXml
˙˙+ 2
.
˙˙2 3
Spreadsheet
˙˙3 >
.
˙˙> ?
Cell
˙˙? C
cell
˙˙D H
=
˙˙I J
new
˙˙K N
DocumentFormat
˙˙O ]
.
˙˙] ^
OpenXml
˙˙^ e
.
˙˙e f
Spreadsheet
˙˙f q
.
˙˙q r
Cell
˙˙r v
(
˙˙v w
)
˙˙w x
;
˙˙x y
cell
öö  
.
öö  !
DataType
öö! )
=
öö* +
DocumentFormat
öö, :
.
öö: ;
OpenXml
öö; B
.
ööB C
Spreadsheet
ööC N
.
ööN O

CellValues
ööO Y
.
ööY Z
String
ööZ `
;
öö` a
cell
õõ  
.
õõ  !
	CellValue
õõ! *
=
õõ+ ,
new
õõ- 0
DocumentFormat
õõ1 ?
.
õõ? @
OpenXml
õõ@ G
.
õõG H
Spreadsheet
õõH S
.
õõS T
	CellValue
õõT ]
(
õõ] ^
dsrow
õõ^ c
[
õõc d
col
õõd g
]
õõg h
.
õõh i
ToString
õõi q
(
õõq r
)
õõr s
)
õõs t
;
õõt u
cell
úú  
.
úú  !

StyleIndex
úú! +
=
úú, -
$num
úú. /
;
úú/ 0
newRow
ùù "
.
ùù" #
AppendChild
ùù# .
(
ùù. /
cell
ùù/ 3
)
ùù3 4
;
ùù4 5
}
ûû 
	sheetData
üü !
.
üü! "
AppendChild
üü" -
(
üü- .
newRow
üü. 4
)
üü4 5
;
üü5 6
}
†† 
wsPart
¢¢ 
.
¢¢ 
	Worksheet
¢¢ $
.
¢¢$ %
Save
¢¢% )
(
¢¢) *
)
¢¢* +
;
¢¢+ ,
var
•• 
sheets
•• 
=
••  
spreadsheet
••! ,
.
••, -
WorkbookPart
••- 9
.
••9 :
Workbook
••: B
.
••B C
AppendChild
••C N
(
••N O
new
••O R
Sheets
••S Y
(
••Y Z
)
••Z [
)
••[ \
;
••\ ]
sheets
¶¶ 
.
¶¶ 
AppendChild
¶¶ &
(
¶¶& '
new
¶¶' *
Sheet
¶¶+ 0
(
¶¶0 1
)
¶¶1 2
{
¶¶3 4
Id
¶¶5 7
=
¶¶8 9
spreadsheet
¶¶: E
.
¶¶E F
WorkbookPart
¶¶F R
.
¶¶R S
GetIdOfPart
¶¶S ^
(
¶¶^ _
wsPart
¶¶_ e
)
¶¶e f
,
¶¶f g
SheetId
¶¶h o
=
¶¶p q
$num
¶¶r s
,
¶¶s t
Name
¶¶u y
=
¶¶z {
$str¶¶| ì
}¶¶î ï
)¶¶ï ñ
;¶¶ñ ó
spreadsheet
®® 
.
®®  
WorkbookPart
®®  ,
.
®®, -
Workbook
®®- 5
.
®®5 6
Save
®®6 :
(
®®: ;
)
®®; <
;
®®< =
}
©© 
}
™™ 
catch
´´ 
(
´´ 
	Exception
´´ 
ex
´´ 
)
´´  
{
¨¨ 
var
≠≠ 
error
≠≠ 
=
≠≠ 
ex
≠≠ 
;
≠≠ 
}
ÆÆ 
}
ØØ 	
public
≤≤ 
static
≤≤ 
void
≤≤ 
SalaryBandXLS
≤≤ (
(
≤≤( )
	DataTable
≤≤) 2
table
≤≤3 8
,
≤≤8 9
string
≤≤: @
destination
≤≤A L
)
≤≤L M
{
≥≥ 	
using
¥¥ 
(
¥¥ 
var
¥¥ 
spreadsheet
¥¥ "
=
¥¥# $!
SpreadsheetDocument
¥¥% 8
.
¥¥8 9
Create
¥¥9 ?
(
¥¥? @
destination
¥¥@ K
,
¥¥K L%
SpreadsheetDocumentType
¥¥M d
.
¥¥d e
Workbook
¥¥e m
)
¥¥m n
)
¥¥n o
{
µµ 
spreadsheet
∂∂ 
.
∂∂ 
AddWorkbookPart
∂∂ +
(
∂∂+ ,
)
∂∂, -
;
∂∂- .
spreadsheet
∑∑ 
.
∑∑ 
WorkbookPart
∑∑ (
.
∑∑( )
Workbook
∑∑) 1
=
∑∑2 3
new
∑∑4 7
Workbook
∑∑8 @
(
∑∑@ A
)
∑∑A B
;
∑∑B C
var
∏∏ 
wsPart
∏∏ 
=
∏∏ 
spreadsheet
∏∏ (
.
∏∏( )
WorkbookPart
∏∏) 5
.
∏∏5 6

AddNewPart
∏∏6 @
<
∏∏@ A
WorksheetPart
∏∏A N
>
∏∏N O
(
∏∏O P
)
∏∏P Q
;
∏∏Q R
wsPart
ππ 
.
ππ 
	Worksheet
ππ  
=
ππ! "
new
ππ# &
	Worksheet
ππ' 0
(
ππ0 1
)
ππ1 2
;
ππ2 3
var
ªª 

stylesPart
ªª 
=
ªª  
spreadsheet
ªª! ,
.
ªª, -
WorkbookPart
ªª- 9
.
ªª9 :

AddNewPart
ªª: D
<
ªªD E 
WorkbookStylesPart
ªªE W
>
ªªW X
(
ªªX Y
)
ªªY Z
;
ªªZ [

stylesPart
ºº 
.
ºº 

Stylesheet
ºº %
=
ºº& '
new
ºº( +

Stylesheet
ºº, 6
(
ºº6 7
)
ºº7 8
;
ºº8 9
Font
øø 
font
øø 
=
øø 
new
øø 
Font
øø  $
(
øø$ %
)
øø% &
;
øø& '
font
¿¿ 
.
¿¿ 
Append
¿¿ 
(
¿¿ 
new
¿¿ 
Color
¿¿  %
(
¿¿% &
)
¿¿& '
{
¿¿( )
Rgb
¿¿* -
=
¿¿. /
$str
¿¿0 8
}
¿¿9 :
)
¿¿: ;
;
¿¿; <
font
¡¡ 
.
¡¡ 
Append
¡¡ 
(
¡¡ 
new
¡¡ 
Bold
¡¡  $
(
¡¡$ %
)
¡¡% &
)
¡¡& '
;
¡¡' (

stylesPart
ƒƒ 
.
ƒƒ 

Stylesheet
ƒƒ %
.
ƒƒ% &
Fonts
ƒƒ& +
=
ƒƒ, -
new
ƒƒ. 1
Fonts
ƒƒ2 7
(
ƒƒ7 8
)
ƒƒ8 9
;
ƒƒ9 :

stylesPart
≈≈ 
.
≈≈ 

Stylesheet
≈≈ %
.
≈≈% &
Fonts
≈≈& +
.
≈≈+ ,
AppendChild
≈≈, 7
(
≈≈7 8
font
≈≈8 <
)
≈≈< =
;
≈≈= >

stylesPart
∆∆ 
.
∆∆ 

Stylesheet
∆∆ %
.
∆∆% &
Fonts
∆∆& +
.
∆∆+ ,
AppendChild
∆∆, 7
(
∆∆7 8
new
∆∆8 ;
Font
∆∆< @
{
∆∆A B
Color
∆∆C H
=
∆∆I J
new
∆∆K N
Color
∆∆O T
(
∆∆T U
)
∆∆U V
{
∆∆W X
Rgb
∆∆Y \
=
∆∆] ^
$str
∆∆_ g
}
∆∆h i
}
∆∆j k
)
∆∆k l
;
∆∆l m

stylesPart
«« 
.
«« 

Stylesheet
«« %
.
««% &
Fonts
««& +
.
««+ ,
AppendChild
««, 7
(
««7 8
new
««8 ;
Font
««< @
{
««A B
Color
««C H
=
««I J
new
««K N
Color
««O T
(
««T U
)
««U V
{
««W X
Rgb
««Y \
=
««] ^
$str
««_ g
}
««h i
,
««i j
Bold
««j n
=
««o p
new
««q t
Bold
««u y
(
««y z
)
««z {
}
««| }
)
««} ~
;
««~ 

stylesPart
»» 
.
»» 

Stylesheet
»» %
.
»»% &
Fonts
»»& +
.
»»+ ,
Count
»», 1
=
»»2 3
$num
»»4 5
;
»»5 6

stylesPart
ÀÀ 
.
ÀÀ 

Stylesheet
ÀÀ %
.
ÀÀ% &
Fills
ÀÀ& +
=
ÀÀ, -
new
ÀÀ. 1
Fills
ÀÀ2 7
(
ÀÀ7 8
)
ÀÀ8 9
;
ÀÀ9 :
var
ŒŒ 
solidRed
ŒŒ 
=
ŒŒ 
new
ŒŒ "
PatternFill
ŒŒ# .
(
ŒŒ. /
)
ŒŒ/ 0
{
ŒŒ1 2
PatternType
ŒŒ3 >
=
ŒŒ? @
PatternValues
ŒŒA N
.
ŒŒN O
Solid
ŒŒO T
}
ŒŒU V
;
ŒŒV W
solidRed
œœ 
.
œœ 
ForegroundColor
œœ (
=
œœ) *
new
œœ+ .
ForegroundColor
œœ/ >
{
œœ? @
Rgb
œœA D
=
œœE F
HexBinaryValue
œœG U
.
œœU V

FromString
œœV `
(
œœ` a
$str
œœa i
)
œœi j
}
œœk l
;
œœl m
solidRed
–– 
.
–– 
BackgroundColor
–– (
=
––) *
new
––+ .
BackgroundColor
––/ >
{
––? @
Indexed
––A H
=
––I J
$num
––K M
}
––N O
;
––O P
var
““ 
solidCeleste
““  
=
““! "
new
““# &
PatternFill
““' 2
(
““2 3
)
““3 4
{
““5 6
PatternType
““7 B
=
““C D
PatternValues
““E R
.
““R S
Solid
““S X
}
““Y Z
;
““Z [
solidCeleste
”” 
.
”” 
ForegroundColor
”” ,
=
””- .
new
””/ 2
ForegroundColor
””3 B
{
””C D
Rgb
””E H
=
””I J
HexBinaryValue
””K Y
.
””Y Z

FromString
””Z d
(
””d e
$str
””e m
)
””m n
}
””o p
;
””p q
solidCeleste
‘‘ 
.
‘‘ 
BackgroundColor
‘‘ ,
=
‘‘- .
new
‘‘/ 2
BackgroundColor
‘‘3 B
{
‘‘C D
Indexed
‘‘E L
=
‘‘M N
$num
‘‘O Q
}
‘‘R S
;
‘‘S T

stylesPart
ÿÿ 
.
ÿÿ 

Stylesheet
ÿÿ %
.
ÿÿ% &
Fills
ÿÿ& +
.
ÿÿ+ ,
AppendChild
ÿÿ, 7
(
ÿÿ7 8
new
ÿÿ8 ;
Fill
ÿÿ< @
{
ÿÿA B
PatternFill
ÿÿC N
=
ÿÿO P
new
ÿÿQ T
PatternFill
ÿÿU `
{
ÿÿa b
PatternType
ÿÿc n
=
ÿÿo p
PatternValues
ÿÿq ~
.
ÿÿ~ 
Noneÿÿ É
}ÿÿÑ Ö
}ÿÿÜ á
)ÿÿá à
;ÿÿà â

stylesPart
ŸŸ 
.
ŸŸ 

Stylesheet
ŸŸ %
.
ŸŸ% &
Fills
ŸŸ& +
.
ŸŸ+ ,
AppendChild
ŸŸ, 7
(
ŸŸ7 8
new
ŸŸ8 ;
Fill
ŸŸ< @
{
ŸŸA B
PatternFill
ŸŸC N
=
ŸŸO P
new
ŸŸQ T
PatternFill
ŸŸU `
{
ŸŸa b
PatternType
ŸŸc n
=
ŸŸo p
PatternValues
ŸŸq ~
.
ŸŸ~ 
Gray125ŸŸ Ü
}ŸŸá à
}ŸŸâ ä
)ŸŸä ã
;ŸŸã å

stylesPart
⁄⁄ 
.
⁄⁄ 

Stylesheet
⁄⁄ %
.
⁄⁄% &
Fills
⁄⁄& +
.
⁄⁄+ ,
AppendChild
⁄⁄, 7
(
⁄⁄7 8
new
⁄⁄8 ;
Fill
⁄⁄< @
{
⁄⁄A B
PatternFill
⁄⁄C N
=
⁄⁄O P
solidRed
⁄⁄Q Y
}
⁄⁄Z [
)
⁄⁄[ \
;
⁄⁄\ ]

stylesPart
€€ 
.
€€ 

Stylesheet
€€ %
.
€€% &
Fills
€€& +
.
€€+ ,
AppendChild
€€, 7
(
€€7 8
new
€€8 ;
Fill
€€< @
{
€€A B
PatternFill
€€C N
=
€€O P
solidCeleste
€€Q ]
}
€€] ^
)
€€^ _
;
€€_ `

stylesPart
‹‹ 
.
‹‹ 

Stylesheet
‹‹ %
.
‹‹% &
Fills
‹‹& +
.
‹‹+ ,
Count
‹‹, 1
=
‹‹2 3
$num
‹‹4 5
;
‹‹5 6

stylesPart
ﬂﬂ 
.
ﬂﬂ 

Stylesheet
ﬂﬂ %
.
ﬂﬂ% &
Borders
ﬂﬂ& -
=
ﬂﬂ. /
new
ﬂﬂ0 3
Borders
ﬂﬂ4 ;
(
ﬂﬂ; <
)
ﬂﬂ< =
;
ﬂﬂ= >

stylesPart
‡‡ 
.
‡‡ 

Stylesheet
‡‡ %
.
‡‡% &
Borders
‡‡& -
.
‡‡- .
Count
‡‡. 3
=
‡‡4 5
$num
‡‡6 7
;
‡‡7 8

stylesPart
·· 
.
·· 

Stylesheet
·· %
.
··% &
Borders
··& -
.
··- .
AppendChild
··. 9
(
··9 :
new
··: =
Border
··> D
(
··D E
)
··E F
)
··F G
;
··G H

stylesPart
‰‰ 
.
‰‰ 

Stylesheet
‰‰ %
.
‰‰% &
CellStyleFormats
‰‰& 6
=
‰‰7 8
new
‰‰9 <
CellStyleFormats
‰‰= M
(
‰‰M N
)
‰‰N O
;
‰‰O P

stylesPart
ÂÂ 
.
ÂÂ 

Stylesheet
ÂÂ %
.
ÂÂ% &
CellStyleFormats
ÂÂ& 6
.
ÂÂ6 7
Count
ÂÂ7 <
=
ÂÂ= >
$num
ÂÂ? @
;
ÂÂ@ A

stylesPart
ÊÊ 
.
ÊÊ 

Stylesheet
ÊÊ %
.
ÊÊ% &
CellStyleFormats
ÊÊ& 6
.
ÊÊ6 7
AppendChild
ÊÊ7 B
(
ÊÊB C
new
ÊÊC F

CellFormat
ÊÊG Q
(
ÊÊQ R
)
ÊÊR S
)
ÊÊS T
;
ÊÊT U

stylesPart
ÈÈ 
.
ÈÈ 

Stylesheet
ÈÈ %
.
ÈÈ% &
CellFormats
ÈÈ& 1
=
ÈÈ2 3
new
ÈÈ4 7
CellFormats
ÈÈ8 C
(
ÈÈC D
)
ÈÈD E
;
ÈÈE F

stylesPart
ÍÍ 
.
ÍÍ 

Stylesheet
ÍÍ %
.
ÍÍ% &
CellFormats
ÍÍ& 1
.
ÍÍ1 2
AppendChild
ÍÍ2 =
(
ÍÍ= >
new
ÍÍ> A

CellFormat
ÍÍB L
(
ÍÍL M
)
ÍÍM N
)
ÍÍN O
;
ÍÍO P

stylesPart
ÎÎ 
.
ÎÎ 

Stylesheet
ÎÎ %
.
ÎÎ% &
CellFormats
ÎÎ& 1
.
ÎÎ1 2
AppendChild
ÎÎ2 =
(
ÎÎ= >
new
ÎÎ> A

CellFormat
ÎÎB L
{
ÎÎM N
FormatId
ÎÎO W
=
ÎÎX Y
$num
ÎÎZ [
,
ÎÎ[ \
FontId
ÎÎ] c
=
ÎÎd e
$num
ÎÎf g
,
ÎÎg h
BorderId
ÎÎi q
=
ÎÎr s
$num
ÎÎt u
,
ÎÎu v
FillId
ÎÎw }
=
ÎÎ~ 
$numÎÎÄ Å
,ÎÎÅ Ç
	ApplyFillÎÎÉ å
=ÎÎç é
trueÎÎè ì
}ÎÎî ï
)ÎÎï ñ
.ÎÎñ ó
AppendChildÎÎó ¢
(ÎÎ¢ £
newÎÎ£ ¶
	AlignmentÎÎß ∞
{ÎÎ± ≤

HorizontalÎÎ≥ Ω
=ÎÎæ ø)
HorizontalAlignmentValuesÎÎ¿ Ÿ
.ÎÎŸ ⁄
CenterÎÎ⁄ ‡
}ÎÎ· ‚
)ÎÎ‚ „
;ÎÎ„ ‰

stylesPart
ÏÏ 
.
ÏÏ 

Stylesheet
ÏÏ %
.
ÏÏ% &
CellFormats
ÏÏ& 1
.
ÏÏ1 2
AppendChild
ÏÏ2 =
(
ÏÏ= >
new
ÏÏ> A

CellFormat
ÏÏB L
{
ÏÏM N
FormatId
ÏÏO W
=
ÏÏX Y
$num
ÏÏZ [
,
ÏÏ[ \
FontId
ÏÏ] c
=
ÏÏd e
$num
ÏÏf g
,
ÏÏg h
BorderId
ÏÏi q
=
ÏÏr s
$num
ÏÏt u
,
ÏÏu v
FillId
ÏÏw }
=
ÏÏ~ 
$numÏÏÄ Å
,ÏÏÅ Ç
	ApplyFillÏÏÉ å
=ÏÏç é
trueÏÏè ì
}ÏÏî ï
)ÏÏï ñ
.ÏÏñ ó
AppendChildÏÏó ¢
(ÏÏ¢ £
newÏÏ£ ¶
	AlignmentÏÏß ∞
{ÏÏ± ≤

HorizontalÏÏ≥ Ω
=ÏÏæ ø)
HorizontalAlignmentValuesÏÏ¿ Ÿ
.ÏÏŸ ⁄
LeftÏÏ⁄ ﬁ
}ÏÏﬂ ‡
)ÏÏ‡ ·
;ÏÏ· ‚

stylesPart
ÓÓ 
.
ÓÓ 

Stylesheet
ÓÓ %
.
ÓÓ% &
CellFormats
ÓÓ& 1
.
ÓÓ1 2
AppendChild
ÓÓ2 =
(
ÓÓ= >
new
ÓÓ> A

CellFormat
ÓÓB L
{
ÓÓM N
FormatId
ÓÓO W
=
ÓÓX Y
$num
ÓÓZ [
,
ÓÓ[ \
FontId
ÓÓ] c
=
ÓÓd e
$num
ÓÓf g
,
ÓÓg h
BorderId
ÓÓi q
=
ÓÓr s
$num
ÓÓt u
,
ÓÓu v
FillId
ÓÓw }
=
ÓÓ~ 
$numÓÓÄ Å
,ÓÓÅ Ç
	ApplyFillÓÓÉ å
=ÓÓç é
trueÓÓè ì
}ÓÓî ï
)ÓÓï ñ
.ÓÓñ ó
AppendChildÓÓó ¢
(ÓÓ¢ £
newÓÓ£ ¶
	AlignmentÓÓß ∞
{ÓÓ± ≤

HorizontalÓÓ≥ Ω
=ÓÓæ ø)
HorizontalAlignmentValuesÓÓ¿ Ÿ
.ÓÓŸ ⁄
CenterÓÓ⁄ ‡
}ÓÓ· ‚
)ÓÓ‚ „
;ÓÓ„ ‰

stylesPart
ÙÙ 
.
ÙÙ 

Stylesheet
ÙÙ %
.
ÙÙ% &
CellFormats
ÙÙ& 1
.
ÙÙ1 2
Count
ÙÙ2 7
=
ÙÙ8 9
$num
ÙÙ: ;
;
ÙÙ; <

stylesPart
ˆˆ 
.
ˆˆ 

Stylesheet
ˆˆ %
.
ˆˆ% &
Save
ˆˆ& *
(
ˆˆ* +
)
ˆˆ+ ,
;
ˆˆ, -
Columns
˘˘ 
columnExcel
˘˘ #
=
˘˘$ %
new
˘˘& )
Columns
˘˘* 1
(
˘˘1 2
)
˘˘2 3
;
˘˘3 4
int
˙˙ 
contadorColumn
˙˙ "
=
˙˙# $
$num
˙˙% &
;
˙˙& '
columnExcel
˛˛ 
.
˛˛ 
Append
˛˛ "
(
˛˛" #
new
˛˛# &
Column
˛˛' -
(
˛˛- .
)
˛˛. /
{
˛˛0 1
Min
˛˛2 5
=
˛˛6 7
Convert
˛˛8 ?
.
˛˛? @
ToUInt32
˛˛@ H
(
˛˛H I
contadorColumn
˛˛I W
)
˛˛W X
,
˛˛X Y
Max
˛˛Z ]
=
˛˛^ _
Convert
˛˛` g
.
˛˛g h
ToUInt32
˛˛h p
(
˛˛p q
contadorColumn
˛˛q 
)˛˛ Ä
,˛˛Ä Å
Width˛˛Ç á
=˛˛à â
$num˛˛ä è
,˛˛è ê
CustomWidth˛˛ë ú
=˛˛ù û
true˛˛ü £
}˛˛§ •
)˛˛• ¶
;˛˛¶ ß
contadorColumn˛˛® ∂
++˛˛∂ ∏
;˛˛∏ π
columnExcel
ˇˇ 
.
ˇˇ 
Append
ˇˇ "
(
ˇˇ" #
new
ˇˇ# &
Column
ˇˇ' -
(
ˇˇ- .
)
ˇˇ. /
{
ˇˇ0 1
Min
ˇˇ2 5
=
ˇˇ6 7
Convert
ˇˇ8 ?
.
ˇˇ? @
ToUInt32
ˇˇ@ H
(
ˇˇH I
contadorColumn
ˇˇI W
)
ˇˇW X
,
ˇˇX Y
Max
ˇˇZ ]
=
ˇˇ^ _
Convert
ˇˇ` g
.
ˇˇg h
ToUInt32
ˇˇh p
(
ˇˇp q
contadorColumn
ˇˇq 
)ˇˇ Ä
,ˇˇÄ Å
WidthˇˇÇ á
=ˇˇà â
$numˇˇä è
,ˇˇè ê
CustomWidthˇˇë ú
=ˇˇù û
trueˇˇü £
}ˇˇ§ •
)ˇˇ• ¶
;ˇˇ¶ ß
contadorColumnˇˇ® ∂
++ˇˇ∂ ∏
;ˇˇ∏ π
columnExcel
ÄÄ 
.
ÄÄ 
Append
ÄÄ "
(
ÄÄ" #
new
ÄÄ# &
Column
ÄÄ' -
(
ÄÄ- .
)
ÄÄ. /
{
ÄÄ0 1
Min
ÄÄ2 5
=
ÄÄ6 7
Convert
ÄÄ8 ?
.
ÄÄ? @
ToUInt32
ÄÄ@ H
(
ÄÄH I
contadorColumn
ÄÄI W
)
ÄÄW X
,
ÄÄX Y
Max
ÄÄZ ]
=
ÄÄ^ _
Convert
ÄÄ` g
.
ÄÄg h
ToUInt32
ÄÄh p
(
ÄÄp q
contadorColumn
ÄÄq 
)ÄÄ Ä
,ÄÄÄ Å
WidthÄÄÇ á
=ÄÄà â
$numÄÄä å
,ÄÄå ç
CustomWidthÄÄé ô
=ÄÄö õ
trueÄÄú †
}ÄÄ° ¢
)ÄÄ¢ £
;ÄÄ£ §
contadorColumnÄÄ• ≥
++ÄÄ≥ µ
;ÄÄµ ∂
columnExcel
ÅÅ 
.
ÅÅ 
Append
ÅÅ "
(
ÅÅ" #
new
ÅÅ# &
Column
ÅÅ' -
(
ÅÅ- .
)
ÅÅ. /
{
ÅÅ0 1
Min
ÅÅ2 5
=
ÅÅ6 7
Convert
ÅÅ8 ?
.
ÅÅ? @
ToUInt32
ÅÅ@ H
(
ÅÅH I
contadorColumn
ÅÅI W
)
ÅÅW X
,
ÅÅX Y
Max
ÅÅZ ]
=
ÅÅ^ _
Convert
ÅÅ` g
.
ÅÅg h
ToUInt32
ÅÅh p
(
ÅÅp q
contadorColumn
ÅÅq 
)ÅÅ Ä
,ÅÅÄ Å
WidthÅÅÇ á
=ÅÅà â
$numÅÅä è
,ÅÅè ê
CustomWidthÅÅë ú
=ÅÅù û
trueÅÅü £
}ÅÅ§ •
)ÅÅ• ¶
;ÅÅ¶ ß
contadorColumnÅÅ® ∂
++ÅÅ∂ ∏
;ÅÅ∏ π
columnExcel
ÇÇ 
.
ÇÇ 
Append
ÇÇ "
(
ÇÇ" #
new
ÇÇ# &
Column
ÇÇ' -
(
ÇÇ- .
)
ÇÇ. /
{
ÇÇ0 1
Min
ÇÇ2 5
=
ÇÇ6 7
Convert
ÇÇ8 ?
.
ÇÇ? @
ToUInt32
ÇÇ@ H
(
ÇÇH I
contadorColumn
ÇÇI W
)
ÇÇW X
,
ÇÇX Y
Max
ÇÇZ ]
=
ÇÇ^ _
Convert
ÇÇ` g
.
ÇÇg h
ToUInt32
ÇÇh p
(
ÇÇp q
contadorColumn
ÇÇq 
)ÇÇ Ä
,ÇÇÄ Å
WidthÇÇÇ á
=ÇÇà â
$numÇÇä è
,ÇÇè ê
CustomWidthÇÇë ú
=ÇÇù û
trueÇÇü £
}ÇÇ§ •
)ÇÇ• ¶
;ÇÇ¶ ß
contadorColumnÇÇ® ∂
++ÇÇ∂ ∏
;ÇÇ∏ π
columnExcel
ÉÉ 
.
ÉÉ 
Append
ÉÉ "
(
ÉÉ" #
new
ÉÉ# &
Column
ÉÉ' -
(
ÉÉ- .
)
ÉÉ. /
{
ÉÉ0 1
Min
ÉÉ2 5
=
ÉÉ6 7
Convert
ÉÉ8 ?
.
ÉÉ? @
ToUInt32
ÉÉ@ H
(
ÉÉH I
contadorColumn
ÉÉI W
)
ÉÉW X
,
ÉÉX Y
Max
ÉÉZ ]
=
ÉÉ^ _
Convert
ÉÉ` g
.
ÉÉg h
ToUInt32
ÉÉh p
(
ÉÉp q
contadorColumn
ÉÉq 
)ÉÉ Ä
,ÉÉÄ Å
WidthÉÉÇ á
=ÉÉà â
$numÉÉä é
,ÉÉé è
CustomWidthÉÉê õ
=ÉÉú ù
trueÉÉû ¢
}ÉÉ£ §
)ÉÉ§ •
;ÉÉ• ¶
contadorColumnÉÉß µ
++ÉÉµ ∑
;ÉÉ∑ ∏
columnExcel
ÑÑ 
.
ÑÑ 
Append
ÑÑ "
(
ÑÑ" #
new
ÑÑ# &
Column
ÑÑ' -
(
ÑÑ- .
)
ÑÑ. /
{
ÑÑ0 1
Min
ÑÑ2 5
=
ÑÑ6 7
Convert
ÑÑ8 ?
.
ÑÑ? @
ToUInt32
ÑÑ@ H
(
ÑÑH I
contadorColumn
ÑÑI W
)
ÑÑW X
,
ÑÑX Y
Max
ÑÑZ ]
=
ÑÑ^ _
Convert
ÑÑ` g
.
ÑÑg h
ToUInt32
ÑÑh p
(
ÑÑp q
contadorColumn
ÑÑq 
)ÑÑ Ä
,ÑÑÄ Å
WidthÑÑÇ á
=ÑÑà â
$numÑÑä è
,ÑÑè ê
CustomWidthÑÑë ú
=ÑÑù û
trueÑÑü £
}ÑÑ§ •
)ÑÑ• ¶
;ÑÑ¶ ß
contadorColumnÑÑ® ∂
++ÑÑ∂ ∏
;ÑÑ∏ π
columnExcel
ÖÖ 
.
ÖÖ 
Append
ÖÖ "
(
ÖÖ" #
new
ÖÖ# &
Column
ÖÖ' -
(
ÖÖ- .
)
ÖÖ. /
{
ÖÖ0 1
Min
ÖÖ2 5
=
ÖÖ6 7
Convert
ÖÖ8 ?
.
ÖÖ? @
ToUInt32
ÖÖ@ H
(
ÖÖH I
contadorColumn
ÖÖI W
)
ÖÖW X
,
ÖÖX Y
Max
ÖÖZ ]
=
ÖÖ^ _
Convert
ÖÖ` g
.
ÖÖg h
ToUInt32
ÖÖh p
(
ÖÖp q
contadorColumn
ÖÖq 
)ÖÖ Ä
,ÖÖÄ Å
WidthÖÖÇ á
=ÖÖà â
$numÖÖä é
,ÖÖé è
CustomWidthÖÖê õ
=ÖÖú ù
trueÖÖû ¢
}ÖÖ£ §
)ÖÖ§ •
;ÖÖ• ¶
contadorColumnÖÖß µ
++ÖÖµ ∑
;ÖÖ∑ ∏
columnExcel
ÜÜ 
.
ÜÜ 
Append
ÜÜ "
(
ÜÜ" #
new
ÜÜ# &
Column
ÜÜ' -
(
ÜÜ- .
)
ÜÜ. /
{
ÜÜ0 1
Min
ÜÜ2 5
=
ÜÜ6 7
Convert
ÜÜ8 ?
.
ÜÜ? @
ToUInt32
ÜÜ@ H
(
ÜÜH I
contadorColumn
ÜÜI W
)
ÜÜW X
,
ÜÜX Y
Max
ÜÜZ ]
=
ÜÜ^ _
Convert
ÜÜ` g
.
ÜÜg h
ToUInt32
ÜÜh p
(
ÜÜp q
contadorColumn
ÜÜq 
)ÜÜ Ä
,ÜÜÄ Å
WidthÜÜÇ á
=ÜÜà â
$numÜÜä è
,ÜÜè ê
CustomWidthÜÜë ú
=ÜÜù û
trueÜÜü £
}ÜÜ§ •
)ÜÜ• ¶
;ÜÜ¶ ß
contadorColumnÜÜ® ∂
++ÜÜ∂ ∏
;ÜÜ∏ π
columnExcel
áá 
.
áá 
Append
áá "
(
áá" #
new
áá# &
Column
áá' -
(
áá- .
)
áá. /
{
áá0 1
Min
áá2 5
=
áá6 7
Convert
áá8 ?
.
áá? @
ToUInt32
áá@ H
(
ááH I
contadorColumn
ááI W
)
ááW X
,
ááX Y
Max
ááZ ]
=
áá^ _
Convert
áá` g
.
áág h
ToUInt32
ááh p
(
ááp q
contadorColumn
ááq 
)áá Ä
,ááÄ Å
WidthááÇ á
=ááà â
$numááä é
,ááé è
CustomWidthááê õ
=ááú ù
trueááû ¢
}áá£ §
)áá§ •
;áá• ¶
contadorColumnááß µ
++ááµ ∑
;áá∑ ∏
columnExcel
àà 
.
àà 
Append
àà "
(
àà" #
new
àà# &
Column
àà' -
(
àà- .
)
àà. /
{
àà0 1
Min
àà2 5
=
àà6 7
Convert
àà8 ?
.
àà? @
ToUInt32
àà@ H
(
ààH I
contadorColumn
ààI W
)
ààW X
,
ààX Y
Max
ààZ ]
=
àà^ _
Convert
àà` g
.
ààg h
ToUInt32
ààh p
(
ààp q
contadorColumn
ààq 
)àà Ä
,ààÄ Å
WidthààÇ á
=ààà â
$numààä è
,ààè ê
CustomWidthààë ú
=ààù û
trueààü £
}àà§ •
)àà• ¶
;àà¶ ß
contadorColumnàà® ∂
++àà∂ ∏
;àà∏ π
columnExcel
ââ 
.
ââ 
Append
ââ "
(
ââ" #
new
ââ# &
Column
ââ' -
(
ââ- .
)
ââ. /
{
ââ0 1
Min
ââ2 5
=
ââ6 7
Convert
ââ8 ?
.
ââ? @
ToUInt32
ââ@ H
(
ââH I
contadorColumn
ââI W
)
ââW X
,
ââX Y
Max
ââZ ]
=
ââ^ _
Convert
ââ` g
.
ââg h
ToUInt32
ââh p
(
ââp q
contadorColumn
ââq 
)ââ Ä
,ââÄ Å
WidthââÇ á
=ââà â
$numââä è
,ââè ê
CustomWidthââë ú
=ââù û
trueââü £
}ââ§ •
)ââ• ¶
;ââ¶ ß
contadorColumnââ® ∂
++ââ∂ ∏
;ââ∏ π
columnExcel
ää 
.
ää 
Append
ää "
(
ää" #
new
ää# &
Column
ää' -
(
ää- .
)
ää. /
{
ää0 1
Min
ää2 5
=
ää6 7
Convert
ää8 ?
.
ää? @
ToUInt32
ää@ H
(
ääH I
contadorColumn
ääI W
)
ääW X
,
ääX Y
Max
ääZ ]
=
ää^ _
Convert
ää` g
.
ääg h
ToUInt32
ääh p
(
ääp q
contadorColumn
ääq 
)ää Ä
,ääÄ Å
WidthääÇ á
=ääà â
$numäää è
,ääè ê
CustomWidthääë ú
=ääù û
trueääü £
}ää§ •
)ää• ¶
;ää¶ ß
contadorColumnää® ∂
++ää∂ ∏
;ää∏ π
columnExcel
ãã 
.
ãã 
Append
ãã "
(
ãã" #
new
ãã# &
Column
ãã' -
(
ãã- .
)
ãã. /
{
ãã0 1
Min
ãã2 5
=
ãã6 7
Convert
ãã8 ?
.
ãã? @
ToUInt32
ãã@ H
(
ããH I
contadorColumn
ããI W
)
ããW X
,
ããX Y
Max
ããZ ]
=
ãã^ _
Convert
ãã` g
.
ããg h
ToUInt32
ããh p
(
ããp q
contadorColumn
ããq 
)ãã Ä
,ããÄ Å
WidthããÇ á
=ããà â
$numããä é
,ããé è
CustomWidthããê õ
=ããú ù
trueããû ¢
}ãã£ §
)ãã§ •
;ãã• ¶
contadorColumnããß µ
++ããµ ∑
;ãã∑ ∏
columnExcel
åå 
.
åå 
Append
åå "
(
åå" #
new
åå# &
Column
åå' -
(
åå- .
)
åå. /
{
åå0 1
Min
åå2 5
=
åå6 7
Convert
åå8 ?
.
åå? @
ToUInt32
åå@ H
(
ååH I
contadorColumn
ååI W
)
ååW X
,
ååX Y
Max
ååZ ]
=
åå^ _
Convert
åå` g
.
ååg h
ToUInt32
ååh p
(
ååp q
contadorColumn
ååq 
)åå Ä
,ååÄ Å
WidthååÇ á
=ååà â
$numååä é
,ååé è
CustomWidthååê õ
=ååú ù
trueååû ¢
}åå£ §
)åå§ •
;åå• ¶
contadorColumnååß µ
++ååµ ∑
;åå∑ ∏
columnExcel
çç 
.
çç 
Append
çç "
(
çç" #
new
çç# &
Column
çç' -
(
çç- .
)
çç. /
{
çç0 1
Min
çç2 5
=
çç6 7
Convert
çç8 ?
.
çç? @
ToUInt32
çç@ H
(
ççH I
contadorColumn
ççI W
)
ççW X
,
ççX Y
Max
ççZ ]
=
çç^ _
Convert
çç` g
.
ççg h
ToUInt32
ççh p
(
ççp q
contadorColumn
ççq 
)çç Ä
,ççÄ Å
WidthççÇ á
=ççà â
$numççä é
,ççé è
CustomWidthççê õ
=ççú ù
trueççû ¢
}çç£ §
)çç§ •
;çç• ¶
contadorColumnççß µ
++ççµ ∑
;çç∑ ∏
columnExcel
éé 
.
éé 
Append
éé "
(
éé" #
new
éé# &
Column
éé' -
(
éé- .
)
éé. /
{
éé0 1
Min
éé2 5
=
éé6 7
Convert
éé8 ?
.
éé? @
ToUInt32
éé@ H
(
ééH I
contadorColumn
ééI W
)
ééW X
,
ééX Y
Max
ééZ ]
=
éé^ _
Convert
éé` g
.
éég h
ToUInt32
ééh p
(
éép q
contadorColumn
ééq 
)éé Ä
,ééÄ Å
WidthééÇ á
=ééà â
$numééä ã
,ééã å
CustomWidthééç ò
=ééô ö
trueééõ ü
}éé† °
)éé° ¢
;éé¢ £
contadorColumnéé§ ≤
++éé≤ ¥
;éé¥ µ
columnExcel
èè 
.
èè 
Append
èè "
(
èè" #
new
èè# &
Column
èè' -
(
èè- .
)
èè. /
{
èè0 1
Min
èè2 5
=
èè6 7
Convert
èè8 ?
.
èè? @
ToUInt32
èè@ H
(
èèH I
contadorColumn
èèI W
)
èèW X
,
èèX Y
Max
èèZ ]
=
èè^ _
Convert
èè` g
.
èèg h
ToUInt32
èèh p
(
èèp q
contadorColumn
èèq 
)èè Ä
,èèÄ Å
WidthèèÇ á
=èèà â
$numèèä ã
,èèã å
CustomWidthèèç ò
=èèô ö
trueèèõ ü
}èè† °
)èè° ¢
;èè¢ £
contadorColumnèè§ ≤
++èè≤ ¥
;èè¥ µ
columnExcel
êê 
.
êê 
Append
êê "
(
êê" #
new
êê# &
Column
êê' -
(
êê- .
)
êê. /
{
êê0 1
Min
êê2 5
=
êê6 7
Convert
êê8 ?
.
êê? @
ToUInt32
êê@ H
(
êêH I
contadorColumn
êêI W
)
êêW X
,
êêX Y
Max
êêZ ]
=
êê^ _
Convert
êê` g
.
êêg h
ToUInt32
êêh p
(
êêp q
contadorColumn
êêq 
)êê Ä
,êêÄ Å
WidthêêÇ á
=êêà â
$numêêä é
,êêé è
CustomWidthêêê õ
=êêú ù
trueêêû ¢
}êê£ §
)êê§ •
;êê• ¶
contadorColumnêêß µ
++êêµ ∑
;êê∑ ∏
columnExcel
ëë 
.
ëë 
Append
ëë "
(
ëë" #
new
ëë# &
Column
ëë' -
(
ëë- .
)
ëë. /
{
ëë0 1
Min
ëë2 5
=
ëë6 7
Convert
ëë8 ?
.
ëë? @
ToUInt32
ëë@ H
(
ëëH I
contadorColumn
ëëI W
)
ëëW X
,
ëëX Y
Max
ëëZ ]
=
ëë^ _
Convert
ëë` g
.
ëëg h
ToUInt32
ëëh p
(
ëëp q
contadorColumn
ëëq 
)ëë Ä
,ëëÄ Å
WidthëëÇ á
=ëëà â
$numëëä é
,ëëé è
CustomWidthëëê õ
=ëëú ù
trueëëû ¢
}ëë£ §
)ëë§ •
;ëë• ¶
contadorColumnëëß µ
++ëëµ ∑
;ëë∑ ∏
columnExcel
íí 
.
íí 
Append
íí "
(
íí" #
new
íí# &
Column
íí' -
(
íí- .
)
íí. /
{
íí0 1
Min
íí2 5
=
íí6 7
Convert
íí8 ?
.
íí? @
ToUInt32
íí@ H
(
ííH I
contadorColumn
ííI W
)
ííW X
,
ííX Y
Max
ííZ ]
=
íí^ _
Convert
íí` g
.
ííg h
ToUInt32
ííh p
(
ííp q
contadorColumn
ííq 
)íí Ä
,ííÄ Å
WidthííÇ á
=ííà â
$numííä è
,ííè ê
CustomWidthííë ú
=ííù û
trueííü £
}íí§ •
)íí• ¶
;íí¶ ß
contadorColumníí® ∂
++íí∂ ∏
;íí∏ π
columnExcel
ìì 
.
ìì 
Append
ìì "
(
ìì" #
new
ìì# &
Column
ìì' -
(
ìì- .
)
ìì. /
{
ìì0 1
Min
ìì2 5
=
ìì6 7
Convert
ìì8 ?
.
ìì? @
ToUInt32
ìì@ H
(
ììH I
contadorColumn
ììI W
)
ììW X
,
ììX Y
Max
ììZ ]
=
ìì^ _
Convert
ìì` g
.
ììg h
ToUInt32
ììh p
(
ììp q
contadorColumn
ììq 
)ìì Ä
,ììÄ Å
WidthììÇ á
=ììà â
$numììä è
,ììè ê
CustomWidthììë ú
=ììù û
trueììü £
}ìì§ •
)ìì• ¶
;ìì¶ ß
contadorColumnìì® ∂
++ìì∂ ∏
;ìì∏ π
columnExcel
îî 
.
îî 
Append
îî "
(
îî" #
new
îî# &
Column
îî' -
(
îî- .
)
îî. /
{
îî0 1
Min
îî2 5
=
îî6 7
Convert
îî8 ?
.
îî? @
ToUInt32
îî@ H
(
îîH I
contadorColumn
îîI W
)
îîW X
,
îîX Y
Max
îîZ ]
=
îî^ _
Convert
îî` g
.
îîg h
ToUInt32
îîh p
(
îîp q
contadorColumn
îîq 
)îî Ä
,îîÄ Å
WidthîîÇ á
=îîà â
$numîîä è
,îîè ê
CustomWidthîîë ú
=îîù û
trueîîü £
}îî§ •
)îî• ¶
;îî¶ ß
contadorColumnîî® ∂
++îî∂ ∏
;îî∏ π
columnExcel
ïï 
.
ïï 
Append
ïï "
(
ïï" #
new
ïï# &
Column
ïï' -
(
ïï- .
)
ïï. /
{
ïï0 1
Min
ïï2 5
=
ïï6 7
Convert
ïï8 ?
.
ïï? @
ToUInt32
ïï@ H
(
ïïH I
contadorColumn
ïïI W
)
ïïW X
,
ïïX Y
Max
ïïZ ]
=
ïï^ _
Convert
ïï` g
.
ïïg h
ToUInt32
ïïh p
(
ïïp q
contadorColumn
ïïq 
)ïï Ä
,ïïÄ Å
WidthïïÇ á
=ïïà â
$numïïä é
,ïïé è
CustomWidthïïê õ
=ïïú ù
trueïïû ¢
}ïï£ §
)ïï§ •
;ïï• ¶
contadorColumnïïß µ
++ïïµ ∑
;ïï∑ ∏
columnExcel
ññ 
.
ññ 
Append
ññ "
(
ññ" #
new
ññ# &
Column
ññ' -
(
ññ- .
)
ññ. /
{
ññ0 1
Min
ññ2 5
=
ññ6 7
Convert
ññ8 ?
.
ññ? @
ToUInt32
ññ@ H
(
ññH I
contadorColumn
ññI W
)
ññW X
,
ññX Y
Max
ññZ ]
=
ññ^ _
Convert
ññ` g
.
ññg h
ToUInt32
ññh p
(
ññp q
contadorColumn
ññq 
)ññ Ä
,ññÄ Å
WidthññÇ á
=ññà â
$numññä é
,ññé è
CustomWidthññê õ
=ññú ù
trueññû ¢
}ññ£ §
)ññ§ •
;ññ• ¶
contadorColumnññß µ
++ññµ ∑
;ññ∑ ∏
columnExcel
óó 
.
óó 
Append
óó "
(
óó" #
new
óó# &
Column
óó' -
(
óó- .
)
óó. /
{
óó0 1
Min
óó2 5
=
óó6 7
Convert
óó8 ?
.
óó? @
ToUInt32
óó@ H
(
óóH I
contadorColumn
óóI W
)
óóW X
,
óóX Y
Max
óóZ ]
=
óó^ _
Convert
óó` g
.
óóg h
ToUInt32
óóh p
(
óóp q
contadorColumn
óóq 
)óó Ä
,óóÄ Å
WidthóóÇ á
=óóà â
$numóóä é
,óóé è
CustomWidthóóê õ
=óóú ù
trueóóû ¢
}óó£ §
)óó§ •
;óó• ¶
contadorColumnóóß µ
++óóµ ∑
;óó∑ ∏
columnExcel
òò 
.
òò 
Append
òò "
(
òò" #
new
òò# &
Column
òò' -
(
òò- .
)
òò. /
{
òò0 1
Min
òò2 5
=
òò6 7
Convert
òò8 ?
.
òò? @
ToUInt32
òò@ H
(
òòH I
contadorColumn
òòI W
)
òòW X
,
òòX Y
Max
òòZ ]
=
òò^ _
Convert
òò` g
.
òòg h
ToUInt32
òòh p
(
òòp q
contadorColumn
òòq 
)òò Ä
,òòÄ Å
WidthòòÇ á
=òòà â
$numòòä é
,òòé è
CustomWidthòòê õ
=òòú ù
trueòòû ¢
}òò£ §
)òò§ •
;òò• ¶
contadorColumnòòß µ
++òòµ ∑
;òò∑ ∏
columnExcel
ôô 
.
ôô 
Append
ôô "
(
ôô" #
new
ôô# &
Column
ôô' -
(
ôô- .
)
ôô. /
{
ôô0 1
Min
ôô2 5
=
ôô6 7
Convert
ôô8 ?
.
ôô? @
ToUInt32
ôô@ H
(
ôôH I
contadorColumn
ôôI W
)
ôôW X
,
ôôX Y
Max
ôôZ ]
=
ôô^ _
Convert
ôô` g
.
ôôg h
ToUInt32
ôôh p
(
ôôp q
contadorColumn
ôôq 
)ôô Ä
,ôôÄ Å
WidthôôÇ á
=ôôà â
$numôôä é
,ôôé è
CustomWidthôôê õ
=ôôú ù
trueôôû ¢
}ôô£ §
)ôô§ •
;ôô• ¶
contadorColumnôôß µ
++ôôµ ∑
;ôô∑ ∏
columnExcel
öö 
.
öö 
Append
öö "
(
öö" #
new
öö# &
Column
öö' -
(
öö- .
)
öö. /
{
öö0 1
Min
öö2 5
=
öö6 7
Convert
öö8 ?
.
öö? @
ToUInt32
öö@ H
(
ööH I
contadorColumn
ööI W
)
ööW X
,
ööX Y
Max
ööZ ]
=
öö^ _
Convert
öö` g
.
öög h
ToUInt32
ööh p
(
ööp q
contadorColumn
ööq 
)öö Ä
,ööÄ Å
WidthööÇ á
=ööà â
$numööä é
,ööé è
CustomWidthööê õ
=ööú ù
trueööû ¢
}öö£ §
)öö§ •
;öö• ¶
contadorColumnööß µ
++ööµ ∑
;öö∑ ∏
columnExcel
õõ 
.
õõ 
Append
õõ "
(
õõ" #
new
õõ# &
Column
õõ' -
(
õõ- .
)
õõ. /
{
õõ0 1
Min
õõ2 5
=
õõ6 7
Convert
õõ8 ?
.
õõ? @
ToUInt32
õõ@ H
(
õõH I
contadorColumn
õõI W
)
õõW X
,
õõX Y
Max
õõZ ]
=
õõ^ _
Convert
õõ` g
.
õõg h
ToUInt32
õõh p
(
õõp q
contadorColumn
õõq 
)õõ Ä
,õõÄ Å
WidthõõÇ á
=õõà â
$numõõä é
,õõé è
CustomWidthõõê õ
=õõú ù
trueõõû ¢
}õõ£ §
)õõ§ •
;õõ• ¶
contadorColumnõõß µ
++õõµ ∑
;õõ∑ ∏
columnExcel
úú 
.
úú 
Append
úú "
(
úú" #
new
úú# &
Column
úú' -
(
úú- .
)
úú. /
{
úú0 1
Min
úú2 5
=
úú6 7
Convert
úú8 ?
.
úú? @
ToUInt32
úú@ H
(
úúH I
contadorColumn
úúI W
)
úúW X
,
úúX Y
Max
úúZ ]
=
úú^ _
Convert
úú` g
.
úúg h
ToUInt32
úúh p
(
úúp q
contadorColumn
úúq 
)úú Ä
,úúÄ Å
WidthúúÇ á
=úúà â
$numúúä é
,úúé è
CustomWidthúúê õ
=úúú ù
trueúúû ¢
}úú£ §
)úú§ •
;úú• ¶
contadorColumnúúß µ
++úúµ ∑
;úú∑ ∏
columnExcel
ùù 
.
ùù 
Append
ùù "
(
ùù" #
new
ùù# &
Column
ùù' -
(
ùù- .
)
ùù. /
{
ùù0 1
Min
ùù2 5
=
ùù6 7
Convert
ùù8 ?
.
ùù? @
ToUInt32
ùù@ H
(
ùùH I
contadorColumn
ùùI W
)
ùùW X
,
ùùX Y
Max
ùùZ ]
=
ùù^ _
Convert
ùù` g
.
ùùg h
ToUInt32
ùùh p
(
ùùp q
contadorColumn
ùùq 
)ùù Ä
,ùùÄ Å
WidthùùÇ á
=ùùà â
$numùùä é
,ùùé è
CustomWidthùùê õ
=ùùú ù
trueùùû ¢
}ùù£ §
)ùù§ •
;ùù• ¶
contadorColumnùùß µ
++ùùµ ∑
;ùù∑ ∏
columnExcel
ûû 
.
ûû 
Append
ûû "
(
ûû" #
new
ûû# &
Column
ûû' -
(
ûû- .
)
ûû. /
{
ûû0 1
Min
ûû2 5
=
ûû6 7
Convert
ûû8 ?
.
ûû? @
ToUInt32
ûû@ H
(
ûûH I
contadorColumn
ûûI W
)
ûûW X
,
ûûX Y
Max
ûûZ ]
=
ûû^ _
Convert
ûû` g
.
ûûg h
ToUInt32
ûûh p
(
ûûp q
contadorColumn
ûûq 
)ûû Ä
,ûûÄ Å
WidthûûÇ á
=ûûà â
$numûûä é
,ûûé è
CustomWidthûûê õ
=ûûú ù
trueûûû ¢
}ûû£ §
)ûû§ •
;ûû• ¶
contadorColumnûûß µ
++ûûµ ∑
;ûû∑ ∏
columnExcel
üü 
.
üü 
Append
üü "
(
üü" #
new
üü# &
Column
üü' -
(
üü- .
)
üü. /
{
üü0 1
Min
üü2 5
=
üü6 7
Convert
üü8 ?
.
üü? @
ToUInt32
üü@ H
(
üüH I
contadorColumn
üüI W
)
üüW X
,
üüX Y
Max
üüZ ]
=
üü^ _
Convert
üü` g
.
üüg h
ToUInt32
üüh p
(
üüp q
contadorColumn
üüq 
)üü Ä
,üüÄ Å
WidthüüÇ á
=üüà â
$numüüä é
,üüé è
CustomWidthüüê õ
=üüú ù
trueüüû ¢
}üü£ §
)üü§ •
;üü• ¶
contadorColumnüüß µ
++üüµ ∑
;üü∑ ∏
columnExcel
†† 
.
†† 
Append
†† "
(
††" #
new
††# &
Column
††' -
(
††- .
)
††. /
{
††0 1
Min
††2 5
=
††6 7
Convert
††8 ?
.
††? @
ToUInt32
††@ H
(
††H I
contadorColumn
††I W
)
††W X
,
††X Y
Max
††Z ]
=
††^ _
Convert
††` g
.
††g h
ToUInt32
††h p
(
††p q
contadorColumn
††q 
)†† Ä
,††Ä Å
Width††Ç á
=††à â
$num††ä é
,††é è
CustomWidth††ê õ
=††ú ù
true††û ¢
}††£ §
)††§ •
;††• ¶
contadorColumn††ß µ
++††µ ∑
;††∑ ∏
columnExcel
°° 
.
°° 
Append
°° "
(
°°" #
new
°°# &
Column
°°' -
(
°°- .
)
°°. /
{
°°0 1
Min
°°2 5
=
°°6 7
Convert
°°8 ?
.
°°? @
ToUInt32
°°@ H
(
°°H I
contadorColumn
°°I W
)
°°W X
,
°°X Y
Max
°°Z ]
=
°°^ _
Convert
°°` g
.
°°g h
ToUInt32
°°h p
(
°°p q
contadorColumn
°°q 
)°° Ä
,°°Ä Å
Width°°Ç á
=°°à â
$num°°ä é
,°°é è
CustomWidth°°ê õ
=°°ú ù
true°°û ¢
}°°£ §
)°°§ •
;°°• ¶
contadorColumn°°ß µ
++°°µ ∑
;°°∑ ∏
columnExcel
¢¢ 
.
¢¢ 
Append
¢¢ "
(
¢¢" #
new
¢¢# &
Column
¢¢' -
(
¢¢- .
)
¢¢. /
{
¢¢0 1
Min
¢¢2 5
=
¢¢6 7
Convert
¢¢8 ?
.
¢¢? @
ToUInt32
¢¢@ H
(
¢¢H I
contadorColumn
¢¢I W
)
¢¢W X
,
¢¢X Y
Max
¢¢Z ]
=
¢¢^ _
Convert
¢¢` g
.
¢¢g h
ToUInt32
¢¢h p
(
¢¢p q
contadorColumn
¢¢q 
)¢¢ Ä
,¢¢Ä Å
Width¢¢Ç á
=¢¢à â
$num¢¢ä é
,¢¢é è
CustomWidth¢¢ê õ
=¢¢ú ù
true¢¢û ¢
}¢¢£ §
)¢¢§ •
;¢¢• ¶
contadorColumn¢¢ß µ
++¢¢µ ∑
;¢¢∑ ∏
columnExcel
££ 
.
££ 
Append
££ "
(
££" #
new
££# &
Column
££' -
(
££- .
)
££. /
{
££0 1
Min
££2 5
=
££6 7
Convert
££8 ?
.
££? @
ToUInt32
££@ H
(
££H I
contadorColumn
££I W
)
££W X
,
££X Y
Max
££Z ]
=
££^ _
Convert
££` g
.
££g h
ToUInt32
££h p
(
££p q
contadorColumn
££q 
)££ Ä
,££Ä Å
Width££Ç á
=££à â
$num££ä é
,££é è
CustomWidth££ê õ
=££ú ù
true££û ¢
}£££ §
)££§ •
;££• ¶
contadorColumn££ß µ
++££µ ∑
;££∑ ∏
columnExcel
§§ 
.
§§ 
Append
§§ "
(
§§" #
new
§§# &
Column
§§' -
(
§§- .
)
§§. /
{
§§0 1
Min
§§2 5
=
§§6 7
Convert
§§8 ?
.
§§? @
ToUInt32
§§@ H
(
§§H I
contadorColumn
§§I W
)
§§W X
,
§§X Y
Max
§§Z ]
=
§§^ _
Convert
§§` g
.
§§g h
ToUInt32
§§h p
(
§§p q
contadorColumn
§§q 
)§§ Ä
,§§Ä Å
Width§§Ç á
=§§à â
$num§§ä é
,§§é è
CustomWidth§§ê õ
=§§ú ù
true§§û ¢
}§§£ §
)§§§ •
;§§• ¶
contadorColumn§§ß µ
++§§µ ∑
;§§∑ ∏
columnExcel
•• 
.
•• 
Append
•• "
(
••" #
new
••# &
Column
••' -
(
••- .
)
••. /
{
••0 1
Min
••2 5
=
••6 7
Convert
••8 ?
.
••? @
ToUInt32
••@ H
(
••H I
contadorColumn
••I W
)
••W X
,
••X Y
Max
••Z ]
=
••^ _
Convert
••` g
.
••g h
ToUInt32
••h p
(
••p q
contadorColumn
••q 
)•• Ä
,••Ä Å
Width••Ç á
=••à â
$num••ä é
,••é è
CustomWidth••ê õ
=••ú ù
true••û ¢
}••£ §
)••§ •
;••• ¶
contadorColumn••ß µ
++••µ ∑
;••∑ ∏
columnExcel
¶¶ 
.
¶¶ 
Append
¶¶ "
(
¶¶" #
new
¶¶# &
Column
¶¶' -
(
¶¶- .
)
¶¶. /
{
¶¶0 1
Min
¶¶2 5
=
¶¶6 7
Convert
¶¶8 ?
.
¶¶? @
ToUInt32
¶¶@ H
(
¶¶H I
contadorColumn
¶¶I W
)
¶¶W X
,
¶¶X Y
Max
¶¶Z ]
=
¶¶^ _
Convert
¶¶` g
.
¶¶g h
ToUInt32
¶¶h p
(
¶¶p q
contadorColumn
¶¶q 
)¶¶ Ä
,¶¶Ä Å
Width¶¶Ç á
=¶¶à â
$num¶¶ä é
,¶¶é è
CustomWidth¶¶ê õ
=¶¶ú ù
true¶¶û ¢
}¶¶£ §
)¶¶§ •
;¶¶• ¶
contadorColumn¶¶ß µ
++¶¶µ ∑
;¶¶∑ ∏
columnExcel
ßß 
.
ßß 
Append
ßß "
(
ßß" #
new
ßß# &
Column
ßß' -
(
ßß- .
)
ßß. /
{
ßß0 1
Min
ßß2 5
=
ßß6 7
Convert
ßß8 ?
.
ßß? @
ToUInt32
ßß@ H
(
ßßH I
contadorColumn
ßßI W
)
ßßW X
,
ßßX Y
Max
ßßZ ]
=
ßß^ _
Convert
ßß` g
.
ßßg h
ToUInt32
ßßh p
(
ßßp q
contadorColumn
ßßq 
)ßß Ä
,ßßÄ Å
WidthßßÇ á
=ßßà â
$numßßä é
,ßßé è
CustomWidthßßê õ
=ßßú ù
trueßßû ¢
}ßß£ §
)ßß§ •
;ßß• ¶
contadorColumnßßß µ
++ßßµ ∑
;ßß∑ ∏
columnExcel
®® 
.
®® 
Append
®® "
(
®®" #
new
®®# &
Column
®®' -
(
®®- .
)
®®. /
{
®®0 1
Min
®®2 5
=
®®6 7
Convert
®®8 ?
.
®®? @
ToUInt32
®®@ H
(
®®H I
contadorColumn
®®I W
)
®®W X
,
®®X Y
Max
®®Z ]
=
®®^ _
Convert
®®` g
.
®®g h
ToUInt32
®®h p
(
®®p q
contadorColumn
®®q 
)®® Ä
,®®Ä Å
Width®®Ç á
=®®à â
$num®®ä é
,®®é è
CustomWidth®®ê õ
=®®ú ù
true®®û ¢
}®®£ §
)®®§ •
;®®• ¶
contadorColumn®®ß µ
++®®µ ∑
;®®∑ ∏
columnExcel
©© 
.
©© 
Append
©© "
(
©©" #
new
©©# &
Column
©©' -
(
©©- .
)
©©. /
{
©©0 1
Min
©©2 5
=
©©6 7
Convert
©©8 ?
.
©©? @
ToUInt32
©©@ H
(
©©H I
contadorColumn
©©I W
)
©©W X
,
©©X Y
Max
©©Z ]
=
©©^ _
Convert
©©` g
.
©©g h
ToUInt32
©©h p
(
©©p q
contadorColumn
©©q 
)©© Ä
,©©Ä Å
Width©©Ç á
=©©à â
$num©©ä é
,©©é è
CustomWidth©©ê õ
=©©ú ù
true©©û ¢
}©©£ §
)©©§ •
;©©• ¶
contadorColumn©©ß µ
++©©µ ∑
;©©∑ ∏
columnExcel
™™ 
.
™™ 
Append
™™ "
(
™™" #
new
™™# &
Column
™™' -
(
™™- .
)
™™. /
{
™™0 1
Min
™™2 5
=
™™6 7
Convert
™™8 ?
.
™™? @
ToUInt32
™™@ H
(
™™H I
contadorColumn
™™I W
)
™™W X
,
™™X Y
Max
™™Z ]
=
™™^ _
Convert
™™` g
.
™™g h
ToUInt32
™™h p
(
™™p q
contadorColumn
™™q 
)™™ Ä
,™™Ä Å
Width™™Ç á
=™™à â
$num™™ä é
,™™é è
CustomWidth™™ê õ
=™™ú ù
true™™û ¢
}™™£ §
)™™§ •
;™™• ¶
contadorColumn™™ß µ
++™™µ ∑
;™™∑ ∏
columnExcel
´´ 
.
´´ 
Append
´´ "
(
´´" #
new
´´# &
Column
´´' -
(
´´- .
)
´´. /
{
´´0 1
Min
´´2 5
=
´´6 7
Convert
´´8 ?
.
´´? @
ToUInt32
´´@ H
(
´´H I
contadorColumn
´´I W
)
´´W X
,
´´X Y
Max
´´Z ]
=
´´^ _
Convert
´´` g
.
´´g h
ToUInt32
´´h p
(
´´p q
contadorColumn
´´q 
)´´ Ä
,´´Ä Å
Width´´Ç á
=´´à â
$num´´ä é
,´´é è
CustomWidth´´ê õ
=´´ú ù
true´´û ¢
}´´£ §
)´´§ •
;´´• ¶
contadorColumn´´ß µ
++´´µ ∑
;´´∑ ∏
wsPart
¥¥ 
.
¥¥ 
	Worksheet
¥¥  
.
¥¥  !
Append
¥¥! '
(
¥¥' (
columnExcel
¥¥( 3
)
¥¥3 4
;
¥¥4 5
var
∂∂ 
	sheetData
∂∂ 
=
∂∂ 
wsPart
∂∂  &
.
∂∂& '
	Worksheet
∂∂' 0
.
∂∂0 1
AppendChild
∂∂1 <
(
∂∂< =
new
∂∂= @
	SheetData
∂∂A J
(
∂∂J K
)
∂∂K L
)
∂∂L M
;
∂∂M N
DocumentFormat
ππ 
.
ππ 
OpenXml
ππ &
.
ππ& '
Spreadsheet
ππ' 2
.
ππ2 3
Row
ππ3 6
	headerRow
ππ7 @
=
ππA B
new
ππC F
DocumentFormat
ππG U
.
ππU V
OpenXml
ππV ]
.
ππ] ^
Spreadsheet
ππ^ i
.
ππi j
Row
ππj m
(
ππm n
)
ππn o
;
ππo p
List
∫∫ 
<
∫∫ 
String
∫∫ 
>
∫∫ 
columns
∫∫ $
=
∫∫% &
new
∫∫' *
List
∫∫+ /
<
∫∫/ 0
string
∫∫0 6
>
∫∫6 7
(
∫∫7 8
)
∫∫8 9
;
∫∫9 :
foreach
ªª 
(
ªª 

DataColumn
ªª #
column
ªª$ *
in
ªª+ -
table
ªª. 3
.
ªª3 4
Columns
ªª4 ;
)
ªª; <
{
ºº 
columns
ΩΩ 
.
ΩΩ 
Add
ΩΩ 
(
ΩΩ  
column
ΩΩ  &
.
ΩΩ& '

ColumnName
ΩΩ' 1
)
ΩΩ1 2
;
ΩΩ2 3
DocumentFormat
øø "
.
øø" #
OpenXml
øø# *
.
øø* +
Spreadsheet
øø+ 6
.
øø6 7
Cell
øø7 ;
cell
øø< @
=
øøA B
new
øøC F
DocumentFormat
øøG U
.
øøU V
OpenXml
øøV ]
.
øø] ^
Spreadsheet
øø^ i
.
øøi j
Cell
øøj n
(
øøn o
)
øøo p
;
øøp q
cell
¡¡ 
.
¡¡ 
DataType
¡¡ !
=
¡¡" #
DocumentFormat
¡¡$ 2
.
¡¡2 3
OpenXml
¡¡3 :
.
¡¡: ;
Spreadsheet
¡¡; F
.
¡¡F G

CellValues
¡¡G Q
.
¡¡Q R
String
¡¡R X
;
¡¡X Y
cell
¬¬ 
.
¬¬ 
	CellValue
¬¬ "
=
¬¬# $
new
¬¬% (
DocumentFormat
¬¬) 7
.
¬¬7 8
OpenXml
¬¬8 ?
.
¬¬? @
Spreadsheet
¬¬@ K
.
¬¬K L
	CellValue
¬¬L U
(
¬¬U V
column
¬¬V \
.
¬¬\ ]

ColumnName
¬¬] g
)
¬¬g h
;
¬¬h i
cell
√√ 
.
√√ 

StyleIndex
√√ #
=
√√$ %
$num
√√& '
;
√√' (
	headerRow
ƒƒ 
.
ƒƒ 
AppendChild
ƒƒ )
(
ƒƒ) *
cell
ƒƒ* .
)
ƒƒ. /
;
ƒƒ/ 0
}
≈≈ 
	sheetData
∆∆ 
.
∆∆ 
AppendChild
∆∆ %
(
∆∆% &
	headerRow
∆∆& /
)
∆∆/ 0
;
∆∆0 1
foreach
»» 
(
»» 
DataRow
»»  
dsrow
»»! &
in
»»' )
table
»»* /
.
»»/ 0
Rows
»»0 4
)
»»4 5
{
…… 
DocumentFormat
   "
.
  " #
OpenXml
  # *
.
  * +
Spreadsheet
  + 6
.
  6 7
Row
  7 :
newRow
  ; A
=
  B C
new
  D G
DocumentFormat
  H V
.
  V W
OpenXml
  W ^
.
  ^ _
Spreadsheet
  _ j
.
  j k
Row
  k n
(
  n o
)
  o p
;
  p q
foreach
ÀÀ 
(
ÀÀ 
String
ÀÀ #
col
ÀÀ$ '
in
ÀÀ( *
columns
ÀÀ+ 2
)
ÀÀ2 3
{
ÃÃ 
DocumentFormat
ÕÕ &
.
ÕÕ& '
OpenXml
ÕÕ' .
.
ÕÕ. /
Spreadsheet
ÕÕ/ :
.
ÕÕ: ;
Cell
ÕÕ; ?
cell
ÕÕ@ D
=
ÕÕE F
new
ÕÕG J
DocumentFormat
ÕÕK Y
.
ÕÕY Z
OpenXml
ÕÕZ a
.
ÕÕa b
Spreadsheet
ÕÕb m
.
ÕÕm n
Cell
ÕÕn r
(
ÕÕr s
)
ÕÕs t
;
ÕÕt u
cell
ŒŒ 
.
ŒŒ 
DataType
ŒŒ %
=
ŒŒ& '
DocumentFormat
ŒŒ( 6
.
ŒŒ6 7
OpenXml
ŒŒ7 >
.
ŒŒ> ?
Spreadsheet
ŒŒ? J
.
ŒŒJ K

CellValues
ŒŒK U
.
ŒŒU V
String
ŒŒV \
;
ŒŒ\ ]
cell
œœ 
.
œœ 
	CellValue
œœ &
=
œœ' (
new
œœ) ,
DocumentFormat
œœ- ;
.
œœ; <
OpenXml
œœ< C
.
œœC D
Spreadsheet
œœD O
.
œœO P
	CellValue
œœP Y
(
œœY Z
dsrow
œœZ _
[
œœ_ `
col
œœ` c
]
œœc d
.
œœd e
ToString
œœe m
(
œœm n
)
œœn o
)
œœo p
;
œœp q
cell
–– 
.
–– 

StyleIndex
–– '
=
––( )
$num
––* +
;
––+ ,
newRow
—— 
.
—— 
AppendChild
—— *
(
——* +
cell
——+ /
)
——/ 0
;
——0 1
}
““ 
	sheetData
”” 
.
”” 
AppendChild
”” )
(
””) *
newRow
””* 0
)
””0 1
;
””1 2
}
‘‘ 
wsPart
÷÷ 
.
÷÷ 
	Worksheet
÷÷  
.
÷÷  !
Save
÷÷! %
(
÷÷% &
)
÷÷& '
;
÷÷' (
var
ÿÿ 
sheets
ÿÿ 
=
ÿÿ 
spreadsheet
ÿÿ (
.
ÿÿ( )
WorkbookPart
ÿÿ) 5
.
ÿÿ5 6
Workbook
ÿÿ6 >
.
ÿÿ> ?
AppendChild
ÿÿ? J
(
ÿÿJ K
new
ÿÿK N
Sheets
ÿÿO U
(
ÿÿU V
)
ÿÿV W
)
ÿÿW X
;
ÿÿX Y
sheets
ŸŸ 
.
ŸŸ 
AppendChild
ŸŸ "
(
ŸŸ" #
new
ŸŸ# &
Sheet
ŸŸ' ,
(
ŸŸ, -
)
ŸŸ- .
{
ŸŸ/ 0
Id
ŸŸ1 3
=
ŸŸ4 5
spreadsheet
ŸŸ6 A
.
ŸŸA B
WorkbookPart
ŸŸB N
.
ŸŸN O
GetIdOfPart
ŸŸO Z
(
ŸŸZ [
wsPart
ŸŸ[ a
)
ŸŸa b
,
ŸŸb c
SheetId
ŸŸd k
=
ŸŸl m
$num
ŸŸn o
,
ŸŸo p
Name
ŸŸq u
=
ŸŸv w
$strŸŸx è
}ŸŸê ë
)ŸŸë í
;ŸŸí ì
spreadsheet
€€ 
.
€€ 
WorkbookPart
€€ (
.
€€( )
Workbook
€€) 1
.
€€1 2
Save
€€2 6
(
€€6 7
)
€€7 8
;
€€8 9
}
›› 
}
ﬁﬁ 	
public
·· 
static
·· 
void
·· 
BudgetResumeXLS
·· *
(
··* +
	DataTable
··+ 4
table
··5 :
,
··: ;
string
··< B
destination
··C N
,
··N O
int
··O R
currentPeriod
··S `
,
‚‚$ %
decimal
‚‚& -&
totalPreviousExecAmount2
‚‚. F
,
‚‚F G
decimal
‚‚G N&
totalPreviousExecAmount1
‚‚O g
,
‚‚g h
decimal
‚‚h o&
totalPreviousExecAmount‚‚p á
,
„„$ %
decimal
„„& -$
totalCurrentExecAmount
„„. D
,
„„F G
decimal
„„G N!
totalPreviousAmount
„„O b
,
‰‰$ %
decimal
‰‰& - 
totalCurrentAmount
‰‰. @
,
‰‰F G
decimal
‰‰G N 
totalVariationPorc
‰‰O a
,
‰‰g h
decimal
‰‰h o#
totalVariationAmount‰‰p Ñ
)
ÂÂ 
{
ÊÊ 	
using
ÁÁ 
(
ÁÁ 
var
ÁÁ 
spreadsheet
ÁÁ "
=
ÁÁ# $!
SpreadsheetDocument
ÁÁ% 8
.
ÁÁ8 9
Create
ÁÁ9 ?
(
ÁÁ? @
destination
ÁÁ@ K
,
ÁÁK L%
SpreadsheetDocumentType
ÁÁM d
.
ÁÁd e
Workbook
ÁÁe m
)
ÁÁm n
)
ÁÁn o
{
ËË 
spreadsheet
ÈÈ 
.
ÈÈ 
AddWorkbookPart
ÈÈ +
(
ÈÈ+ ,
)
ÈÈ, -
;
ÈÈ- .
spreadsheet
ÍÍ 
.
ÍÍ 
WorkbookPart
ÍÍ (
.
ÍÍ( )
Workbook
ÍÍ) 1
=
ÍÍ2 3
new
ÍÍ4 7
Workbook
ÍÍ8 @
(
ÍÍ@ A
)
ÍÍA B
;
ÍÍB C
var
ÎÎ 
wsPart
ÎÎ 
=
ÎÎ 
spreadsheet
ÎÎ (
.
ÎÎ( )
WorkbookPart
ÎÎ) 5
.
ÎÎ5 6

AddNewPart
ÎÎ6 @
<
ÎÎ@ A
WorksheetPart
ÎÎA N
>
ÎÎN O
(
ÎÎO P
)
ÎÎP Q
;
ÎÎQ R
wsPart
ÏÏ 
.
ÏÏ 
	Worksheet
ÏÏ  
=
ÏÏ! "
new
ÏÏ# &
	Worksheet
ÏÏ' 0
(
ÏÏ0 1
)
ÏÏ1 2
;
ÏÏ2 3
var
ÓÓ 

stylesPart
ÓÓ 
=
ÓÓ  
spreadsheet
ÓÓ! ,
.
ÓÓ, -
WorkbookPart
ÓÓ- 9
.
ÓÓ9 :

AddNewPart
ÓÓ: D
<
ÓÓD E 
WorkbookStylesPart
ÓÓE W
>
ÓÓW X
(
ÓÓX Y
)
ÓÓY Z
;
ÓÓZ [

stylesPart
ÔÔ 
.
ÔÔ 

Stylesheet
ÔÔ %
=
ÔÔ& '
new
ÔÔ( +

Stylesheet
ÔÔ, 6
(
ÔÔ6 7
)
ÔÔ7 8
;
ÔÔ8 9
Font
ÚÚ 
font
ÚÚ 
=
ÚÚ 
new
ÚÚ 
Font
ÚÚ  $
(
ÚÚ$ %
)
ÚÚ% &
;
ÚÚ& '
font
ÛÛ 
.
ÛÛ 
Append
ÛÛ 
(
ÛÛ 
new
ÛÛ 
Color
ÛÛ  %
(
ÛÛ% &
)
ÛÛ& '
{
ÛÛ( )
Rgb
ÛÛ* -
=
ÛÛ. /
$str
ÛÛ0 8
}
ÛÛ9 :
)
ÛÛ: ;
;
ÛÛ; <
font
ÙÙ 
.
ÙÙ 
Append
ÙÙ 
(
ÙÙ 
new
ÙÙ 
Bold
ÙÙ  $
(
ÙÙ$ %
)
ÙÙ% &
)
ÙÙ& '
;
ÙÙ' (

stylesPart
˜˜ 
.
˜˜ 

Stylesheet
˜˜ %
.
˜˜% &
Fonts
˜˜& +
=
˜˜, -
new
˜˜. 1
Fonts
˜˜2 7
(
˜˜7 8
)
˜˜8 9
;
˜˜9 :

stylesPart
¯¯ 
.
¯¯ 

Stylesheet
¯¯ %
.
¯¯% &
Fonts
¯¯& +
.
¯¯+ ,
Count
¯¯, 1
=
¯¯2 3
$num
¯¯4 5
;
¯¯5 6

stylesPart
˘˘ 
.
˘˘ 

Stylesheet
˘˘ %
.
˘˘% &
Fonts
˘˘& +
.
˘˘+ ,
AppendChild
˘˘, 7
(
˘˘7 8
font
˘˘8 <
)
˘˘< =
;
˘˘= >

stylesPart
˙˙ 
.
˙˙ 

Stylesheet
˙˙ %
.
˙˙% &
Fonts
˙˙& +
.
˙˙+ ,
AppendChild
˙˙, 7
(
˙˙7 8
new
˙˙8 ;
Font
˙˙< @
{
˙˙A B
Color
˙˙C H
=
˙˙I J
new
˙˙K N
Color
˙˙O T
(
˙˙T U
)
˙˙U V
{
˙˙W X
Rgb
˙˙Y \
=
˙˙] ^
$str
˙˙_ g
}
˙˙h i
}
˙˙j k
)
˙˙k l
;
˙˙l m

stylesPart
˚˚ 
.
˚˚ 

Stylesheet
˚˚ %
.
˚˚% &
Fonts
˚˚& +
.
˚˚+ ,
AppendChild
˚˚, 7
(
˚˚7 8
new
˚˚8 ;
Font
˚˚< @
{
˚˚A B
Color
˚˚C H
=
˚˚I J
new
˚˚K N
Color
˚˚O T
(
˚˚T U
)
˚˚U V
{
˚˚W X
Rgb
˚˚Y \
=
˚˚] ^
$str
˚˚_ g
}
˚˚h i
,
˚˚j k
Bold
˚˚l p
=
˚˚q r
new
˚˚s v
Bold
˚˚w {
(
˚˚{ |
)
˚˚| }
}˚˚ Ä
)˚˚Ä Å
;˚˚Å Ç

stylesPart
˛˛ 
.
˛˛ 

Stylesheet
˛˛ %
.
˛˛% &
Fills
˛˛& +
=
˛˛, -
new
˛˛. 1
Fills
˛˛2 7
(
˛˛7 8
)
˛˛8 9
;
˛˛9 :
var
ÅÅ 
solidRed
ÅÅ 
=
ÅÅ 
new
ÅÅ "
PatternFill
ÅÅ# .
(
ÅÅ. /
)
ÅÅ/ 0
{
ÅÅ1 2
PatternType
ÅÅ3 >
=
ÅÅ? @
PatternValues
ÅÅA N
.
ÅÅN O
Solid
ÅÅO T
}
ÅÅU V
;
ÅÅV W
solidRed
ÇÇ 
.
ÇÇ 
ForegroundColor
ÇÇ (
=
ÇÇ) *
new
ÇÇ+ .
ForegroundColor
ÇÇ/ >
{
ÇÇ? @
Rgb
ÇÇA D
=
ÇÇE F
HexBinaryValue
ÇÇG U
.
ÇÇU V

FromString
ÇÇV `
(
ÇÇ` a
$str
ÇÇa i
)
ÇÇi j
}
ÇÇk l
;
ÇÇl m
solidRed
ÉÉ 
.
ÉÉ 
BackgroundColor
ÉÉ (
=
ÉÉ) *
new
ÉÉ+ .
BackgroundColor
ÉÉ/ >
{
ÉÉ? @
Indexed
ÉÉA H
=
ÉÉI J
$num
ÉÉK M
}
ÉÉN O
;
ÉÉO P
var
ÖÖ 
	fondogris
ÖÖ 
=
ÖÖ 
new
ÖÖ  #
PatternFill
ÖÖ$ /
(
ÖÖ/ 0
)
ÖÖ0 1
{
ÖÖ2 3
PatternType
ÖÖ4 ?
=
ÖÖ@ A
PatternValues
ÖÖB O
.
ÖÖO P
Solid
ÖÖP U
}
ÖÖV W
;
ÖÖW X
	fondogris
ÜÜ 
.
ÜÜ 
ForegroundColor
ÜÜ )
=
ÜÜ* +
new
ÜÜ, /
ForegroundColor
ÜÜ0 ?
{
ÜÜ@ A
Rgb
ÜÜB E
=
ÜÜF G
HexBinaryValue
ÜÜH V
.
ÜÜV W

FromString
ÜÜW a
(
ÜÜa b
$str
ÜÜb j
)
ÜÜj k
}
ÜÜl m
;
ÜÜm n
	fondogris
áá 
.
áá 
BackgroundColor
áá )
=
áá* +
new
áá, /
BackgroundColor
áá0 ?
{
áá@ A
Indexed
ááB I
=
ááJ K
$num
ááL N
}
ááO P
;
ááP Q
var
ää 
fondoazultotal
ää "
=
ää# $
new
ää% (
PatternFill
ää) 4
(
ää4 5
)
ää5 6
{
ää7 8
PatternType
ää9 D
=
ääE F
PatternValues
ääG T
.
ääT U
Solid
ääU Z
}
ää[ \
;
ää\ ]
fondoazultotal
ãã 
.
ãã 
ForegroundColor
ãã .
=
ãã/ 0
new
ãã1 4
ForegroundColor
ãã5 D
{
ããE F
Rgb
ããG J
=
ããK L
HexBinaryValue
ããM [
.
ãã[ \

FromString
ãã\ f
(
ããf g
$str
ããg o
)
ãão p
}
ããq r
;
ããr s
fondoazultotal
åå 
.
åå 
BackgroundColor
åå .
=
åå/ 0
new
åå1 4
BackgroundColor
åå5 D
{
ååE F
Indexed
ååG N
=
ååO P
$num
ååQ S
}
ååT U
;
ååU V

stylesPart
èè 
.
èè 

Stylesheet
èè %
.
èè% &
Fills
èè& +
.
èè+ ,
AppendChild
èè, 7
(
èè7 8
new
èè8 ;
Fill
èè< @
{
èèA B
PatternFill
èèC N
=
èèO P
new
èèQ T
PatternFill
èèU `
{
èèa b
PatternType
èèc n
=
èèo p
PatternValues
èèq ~
.
èè~ 
Noneèè É
}èèÑ Ö
}èèÜ á
)èèá à
;èèà â

stylesPart
êê 
.
êê 

Stylesheet
êê %
.
êê% &
Fills
êê& +
.
êê+ ,
AppendChild
êê, 7
(
êê7 8
new
êê8 ;
Fill
êê< @
{
êêA B
PatternFill
êêC N
=
êêO P
new
êêQ T
PatternFill
êêU `
{
êêa b
PatternType
êêc n
=
êêo p
PatternValues
êêq ~
.
êê~ 
Gray125êê Ü
}êêá à
}êêâ ä
)êêä ã
;êêã å

stylesPart
ëë 
.
ëë 

Stylesheet
ëë %
.
ëë% &
Fills
ëë& +
.
ëë+ ,
AppendChild
ëë, 7
(
ëë7 8
new
ëë8 ;
Fill
ëë< @
{
ëëA B
PatternFill
ëëC N
=
ëëO P
solidRed
ëëQ Y
}
ëëZ [
)
ëë[ \
;
ëë\ ]

stylesPart
íí 
.
íí 

Stylesheet
íí %
.
íí% &
Fills
íí& +
.
íí+ ,
AppendChild
íí, 7
(
íí7 8
new
íí8 ;
Fill
íí< @
{
ííA B
PatternFill
ííC N
=
ííO P
	fondogris
ííQ Z
}
íí[ \
)
íí\ ]
;
íí] ^

stylesPart
ìì 
.
ìì 

Stylesheet
ìì %
.
ìì% &
Fills
ìì& +
.
ìì+ ,
AppendChild
ìì, 7
(
ìì7 8
new
ìì8 ;
Fill
ìì< @
{
ììA B
PatternFill
ììC N
=
ììO P
fondoazultotal
ììQ _
}
ìì` a
)
ììa b
;
ììb c

stylesPart
îî 
.
îî 

Stylesheet
îî %
.
îî% &
Fills
îî& +
.
îî+ ,
Count
îî, 1
=
îî2 3
$num
îî4 5
;
îî5 6

stylesPart
óó 
.
óó 

Stylesheet
óó %
.
óó% &
Borders
óó& -
=
óó. /
new
óó0 3
Borders
óó4 ;
(
óó; <
)
óó< =
;
óó= >

stylesPart
ôô 
.
ôô 

Stylesheet
ôô %
.
ôô% &
Borders
ôô& -
.
ôô- .
AppendChild
ôô. 9
(
ôô9 :
new
ôô: =
Border
ôô> D
(
ôôD E
)
ôôE F
)
ôôF G
;
ôôG H

stylesPart
öö 
.
öö 

Stylesheet
öö %
.
öö% &
Borders
öö& -
.
öö- .
AppendChild
öö. 9
(
öö9 :
new
öö: =
Border
öö> D
(
ööD E
)
ööE F
{
ööG H

LeftBorder
ööI S
=
ööS T
new
ööU X

LeftBorder
ööY c
(
ööc d
)
ööd e
{
ööf g
Style
ööh m
=
ööm n 
BorderStyleValuesööp Å
.ööÅ Ç
ThinööÇ Ü
}ööá à
,ööà â
RightBorderööâ î
=ööï ñ
newööó ö
RightBorderööõ ¶
(öö¶ ß
)ööß ®
{öö© ™
Styleöö´ ∞
=öö± ≤!
BorderStyleValuesöö≥ ƒ
.ööƒ ≈
Thinöö≈ …
}öö  À
,
õõ 
BottomBorder
õõ 
=
õõ  
new
õõ! $
BottomBorder
õõ% 1
(
õõ1 2
)
õõ2 3
{
õõ4 5
Style
õõ6 ;
=
õõ< =
BorderStyleValues
õõ> O
.
õõO P
Thin
õõP T
}
õõU V
,
õõV W
	TopBorder
õõX a
=
õõb c
new
õõd g
	TopBorder
õõh q
(
õõq r
)
õõr s
{
õõt u
Style
õõv {
=
õõ| } 
BorderStyleValuesõõ~ è
.õõè ê
Thinõõê î
}õõï ñ
}
úú 
)
úú 
;
úú 

stylesPart
ùù 
.
ùù 

Stylesheet
ùù %
.
ùù% &
Borders
ùù& -
.
ùù- .
Count
ùù. 3
=
ùù4 5
$num
ùù6 7
;
ùù7 8

stylesPart
†† 
.
†† 

Stylesheet
†† %
.
††% &
CellStyleFormats
††& 6
=
††7 8
new
††9 <
CellStyleFormats
††= M
(
††M N
)
††N O
;
††O P

stylesPart
°° 
.
°° 

Stylesheet
°° %
.
°°% &
CellStyleFormats
°°& 6
.
°°6 7
Count
°°7 <
=
°°= >
$num
°°? @
;
°°@ A

stylesPart
¢¢ 
.
¢¢ 

Stylesheet
¢¢ %
.
¢¢% &
CellStyleFormats
¢¢& 6
.
¢¢6 7
AppendChild
¢¢7 B
(
¢¢B C
new
¢¢C F

CellFormat
¢¢G Q
(
¢¢Q R
)
¢¢R S
)
¢¢S T
;
¢¢T U

stylesPart
¶¶ 
.
¶¶ 

Stylesheet
¶¶ %
.
¶¶% &
CellFormats
¶¶& 1
=
¶¶2 3
new
¶¶4 7
CellFormats
¶¶8 C
(
¶¶C D
)
¶¶D E
;
¶¶E F

stylesPart
ßß 
.
ßß 

Stylesheet
ßß %
.
ßß% &
CellFormats
ßß& 1
.
ßß1 2
AppendChild
ßß2 =
(
ßß= >
new
ßß> A

CellFormat
ßßB L
(
ßßL M
)
ßßM N
)
ßßN O
;
ßßO P

stylesPart
®® 
.
®® 

Stylesheet
®® %
.
®®% &
CellFormats
®®& 1
.
®®1 2
AppendChild
®®2 =
(
®®= >
new
®®> A

CellFormat
®®B L
{
®®M N
FormatId
®®O W
=
®®X Y
$num
®®Z [
,
®®[ \
FontId
®®] c
=
®®d e
$num
®®f g
,
®®g h
BorderId
®®i q
=
®®r s
$num
®®t u
,
®®u v
FillId
®®w }
=
®®~ 
$num®®Ä Å
,®®Å Ç
	ApplyFill®®É å
=®®ç é
true®®è ì
}®®î ï
)®®ï ñ
.®®ñ ó
AppendChild®®ó ¢
(®®¢ £
new®®£ ¶
	Alignment®®ß ∞
{®®± ≤

Horizontal®®≥ Ω
=®®æ ø)
HorizontalAlignmentValues®®¿ Ÿ
.®®Ÿ ⁄
Center®®⁄ ‡
}®®· ‚
)®®‚ „
;®®„ ‰

stylesPart
©© 
.
©© 

Stylesheet
©© %
.
©©% &
CellFormats
©©& 1
.
©©1 2
AppendChild
©©2 =
(
©©= >
new
©©> A

CellFormat
©©B L
{
©©M N
FormatId
©©O W
=
©©X Y
$num
©©Z [
,
©©[ \
FontId
©©] c
=
©©d e
$num
©©f g
,
©©g h
BorderId
©©i q
=
©©r s
$num
©©t u
,
©©u v
FillId
©©w }
=
©©~ 
$num©©Ä Å
,©©Å Ç
	ApplyFill©©É å
=©©ç é
true©©è ì
}©©î ï
)©©ï ñ
.©©ñ ó
AppendChild©©ó ¢
(©©¢ £
new©©£ ¶
	Alignment©©ß ∞
{©©± ≤

Horizontal©©≥ Ω
=©©æ ø)
HorizontalAlignmentValues©©¿ Ÿ
.©©Ÿ ⁄
Center©©⁄ ‡
}©©· ‚
)©©‚ „
;©©„ ‰

stylesPart
™™ 
.
™™ 

Stylesheet
™™ %
.
™™% &
CellFormats
™™& 1
.
™™1 2
AppendChild
™™2 =
(
™™= >
new
™™> A

CellFormat
™™B L
{
™™M N
FormatId
™™O W
=
™™X Y
$num
™™Z [
,
™™[ \
FontId
™™] c
=
™™d e
$num
™™f g
,
™™g h
BorderId
™™i q
=
™™r s
$num
™™t u
,
™™u v
FillId
™™w }
=
™™~ 
$num™™Ä Å
,™™Å Ç
	ApplyFill™™É å
=™™ç é
true™™è ì
}™™î ï
)™™ï ñ
.™™ñ ó
AppendChild™™ó ¢
(™™¢ £
new™™£ ¶
	Alignment™™ß ∞
{™™± ≤

Horizontal™™≥ Ω
=™™æ ø)
HorizontalAlignmentValues™™¿ Ÿ
.™™Ÿ ⁄
Center™™⁄ ‡
}™™· ‚
)™™‚ „
;™™„ ‰

stylesPart
´´ 
.
´´ 

Stylesheet
´´ %
.
´´% &
CellFormats
´´& 1
.
´´1 2
AppendChild
´´2 =
(
´´= >
new
´´> A

CellFormat
´´B L
{
´´M N
FormatId
´´O W
=
´´X Y
$num
´´Z [
,
´´[ \
FontId
´´] c
=
´´d e
$num
´´f g
,
´´g h
BorderId
´´i q
=
´´r s
$num
´´t u
,
´´u v
FillId
´´w }
=
´´~ 
$num´´Ä Å
,´´Å Ç
	ApplyFill´´É å
=´´ç é
true´´è ì
}´´î ï
)´´ï ñ
.´´ñ ó
AppendChild´´ó ¢
(´´¢ £
new´´£ ¶
	Alignment´´ß ∞
{´´± ≤

Horizontal´´≥ Ω
=´´æ ø)
HorizontalAlignmentValues´´¿ Ÿ
.´´Ÿ ⁄
Center´´⁄ ‡
}´´· ‚
)´´‚ „
;´´„ ‰

stylesPart
¨¨ 
.
¨¨ 

Stylesheet
¨¨ %
.
¨¨% &
CellFormats
¨¨& 1
.
¨¨1 2
AppendChild
¨¨2 =
(
¨¨= >
new
¨¨> A

CellFormat
¨¨B L
{
¨¨M N
FormatId
¨¨O W
=
¨¨X Y
$num
¨¨Z [
,
¨¨[ \
FontId
¨¨] c
=
¨¨d e
$num
¨¨f g
,
¨¨g h
BorderId
¨¨i q
=
¨¨r s
$num
¨¨t u
,
¨¨u v
FillId
¨¨w }
=
¨¨~ 
$num¨¨Ä Å
,¨¨Å Ç
	ApplyFill¨¨É å
=¨¨ç é
true¨¨è ì
}¨¨î ï
)¨¨ï ñ
.¨¨ñ ó
AppendChild¨¨ó ¢
(¨¨¢ £
new¨¨£ ¶
	Alignment¨¨ß ∞
{¨¨± ≤

Horizontal¨¨≥ Ω
=¨¨æ ø)
HorizontalAlignmentValues¨¨¿ Ÿ
.¨¨Ÿ ⁄
Center¨¨⁄ ‡
}¨¨· ‚
)¨¨‚ „
;¨¨„ ‰

stylesPart
≠≠ 
.
≠≠ 

Stylesheet
≠≠ %
.
≠≠% &
CellFormats
≠≠& 1
.
≠≠1 2
Count
≠≠2 7
=
≠≠8 9
$num
≠≠: ;
;
≠≠; <

stylesPart
ØØ 
.
ØØ 

Stylesheet
ØØ %
.
ØØ% &
Save
ØØ& *
(
ØØ* +
)
ØØ+ ,
;
ØØ, -
Columns
≤≤ 
columnExcel
≤≤ #
=
≤≤$ %
new
≤≤& )
Columns
≤≤* 1
(
≤≤1 2
)
≤≤2 3
;
≤≤3 4
int
≥≥ 
contadorColumn
≥≥ "
=
≥≥# $
$num
≥≥% &
;
≥≥& '
foreach
µµ 
(
µµ 

DataColumn
µµ #
column
µµ$ *
in
µµ+ -
table
µµ. 3
.
µµ3 4
Columns
µµ4 ;
)
µµ; <
{
∂∂ 
columnExcel
∑∑ 
.
∑∑  
Append
∑∑  &
(
∑∑& '
new
∑∑' *
Column
∑∑+ 1
(
∑∑1 2
)
∑∑2 3
{
∑∑4 5
Min
∑∑6 9
=
∑∑: ;
Convert
∑∑< C
.
∑∑C D
ToUInt32
∑∑D L
(
∑∑L M
contadorColumn
∑∑M [
)
∑∑[ \
,
∑∑\ ]
Max
∑∑^ a
=
∑∑b c
Convert
∑∑d k
.
∑∑k l
ToUInt32
∑∑l t
(
∑∑t u
contadorColumn∑∑u É
)∑∑É Ñ
,∑∑Ñ Ö
Width∑∑Ü ã
=∑∑å ç
$num∑∑é ê
,∑∑ê ë
CustomWidth∑∑í ù
=∑∑û ü
true∑∑† §
}∑∑• ¶
)∑∑¶ ß
;∑∑ß ®
contadorColumn
∏∏ "
++
∏∏" $
;
∏∏$ %
}
ππ 
wsPart
ºº 
.
ºº 
	Worksheet
ºº  
.
ºº  !
Append
ºº! '
(
ºº' (
columnExcel
ºº( 3
)
ºº3 4
;
ºº4 5
var
ææ 
	sheetData
ææ 
=
ææ 
wsPart
ææ  &
.
ææ& '
	Worksheet
ææ' 0
.
ææ0 1
AppendChild
ææ1 <
(
ææ< =
new
ææ= @
	SheetData
ææA J
(
ææJ K
)
ææK L
)
ææL M
;
ææM N
DocumentFormat
¡¡ 
.
¡¡ 
OpenXml
¡¡ &
.
¡¡& '
Spreadsheet
¡¡' 2
.
¡¡2 3
Row
¡¡3 6
titleRowWhite1
¡¡7 E
=
¡¡F G
new
¡¡H K
DocumentFormat
¡¡L Z
.
¡¡Z [
OpenXml
¡¡[ b
.
¡¡b c
Spreadsheet
¡¡c n
.
¡¡n o
Row
¡¡o r
(
¡¡r s
)
¡¡s t
;
¡¡t u
	sheetData
»» 
.
»» 
AppendChild
»» %
(
»»% &
titleRowWhite1
»»& 4
)
»»4 5
;
»»5 6
DocumentFormat
   
.
   
OpenXml
   &
.
  & '
Spreadsheet
  ' 2
.
  2 3
Row
  3 6
titleRow
  7 ?
=
  @ A
new
  B E
DocumentFormat
  F T
.
  T U
OpenXml
  U \
.
  \ ]
Spreadsheet
  ] h
.
  h i
Row
  i l
(
  l m
)
  m n
;
  n o
DocumentFormat
ÀÀ 
.
ÀÀ 
OpenXml
ÀÀ &
.
ÀÀ& '
Spreadsheet
ÀÀ' 2
.
ÀÀ2 3
Cell
ÀÀ3 7
	cellTitle
ÀÀ8 A
=
ÀÀB C
new
ÀÀD G
DocumentFormat
ÀÀH V
.
ÀÀV W
OpenXml
ÀÀW ^
.
ÀÀ^ _
Spreadsheet
ÀÀ_ j
.
ÀÀj k
Cell
ÀÀk o
(
ÀÀo p
)
ÀÀp q
;
ÀÀq r
	cellTitle
ÃÃ 
.
ÃÃ 
DataType
ÃÃ "
=
ÃÃ# $
DocumentFormat
ÃÃ% 3
.
ÃÃ3 4
OpenXml
ÃÃ4 ;
.
ÃÃ; <
Spreadsheet
ÃÃ< G
.
ÃÃG H

CellValues
ÃÃH R
.
ÃÃR S
String
ÃÃS Y
;
ÃÃY Z
	cellTitle
ÕÕ 
.
ÕÕ 
	CellValue
ÕÕ #
=
ÕÕ$ %
new
ÕÕ& )
DocumentFormat
ÕÕ* 8
.
ÕÕ8 9
OpenXml
ÕÕ9 @
.
ÕÕ@ A
Spreadsheet
ÕÕA L
.
ÕÕL M
	CellValue
ÕÕM V
(
ÕÕV W
$str
ÕÕW {
+
ÕÕ{ |
currentPeriodÕÕ} ä
)ÕÕä ã
;ÕÕã å
	cellTitle
ŒŒ 
.
ŒŒ 

StyleIndex
ŒŒ $
=
ŒŒ% &
$num
ŒŒ' (
;
ŒŒ( )
titleRow
–– 
.
–– 
AppendChild
–– $
(
––$ %
	cellTitle
––% .
)
––. /
;
––/ 0
	sheetData
—— 
.
—— 
AppendChild
—— %
(
——% &
titleRow
——& .
)
——. /
;
——/ 0
DocumentFormat
”” 
.
”” 
OpenXml
”” &
.
””& '
Spreadsheet
””' 2
.
””2 3
Row
””3 6
titleRowWhite2
””7 E
=
””F G
new
””H K
DocumentFormat
””L Z
.
””Z [
OpenXml
””[ b
.
””b c
Spreadsheet
””c n
.
””n o
Row
””o r
(
””r s
)
””s t
;
””t u
	sheetData
⁄⁄ 
.
⁄⁄ 
AppendChild
⁄⁄ %
(
⁄⁄% &
titleRowWhite2
⁄⁄& 4
)
⁄⁄4 5
;
⁄⁄5 6

MergeCells
ﬁﬁ 

mergeCells
ﬁﬁ %
=
ﬁﬁ& '
new
ﬁﬁ( +

MergeCells
ﬁﬁ, 6
(
ﬁﬁ6 7
)
ﬁﬁ7 8
;
ﬁﬁ8 9

mergeCells
·· 
.
·· 
Append
·· !
(
··! "
new
··" %
	MergeCell
··& /
(
··/ 0
)
··0 1
{
··2 3
	Reference
··4 =
=
··> ?
new
··@ C
StringValue
··D O
(
··O P
$str
··P W
)
··W X
}
··Y Z
)
··Z [
;
··[ \
wsPart
ÂÂ 
.
ÂÂ 
	Worksheet
ÂÂ  
.
ÂÂ  !
InsertAfter
ÂÂ! ,
(
ÂÂ, -

mergeCells
ÂÂ- 7
,
ÂÂ7 8
wsPart
ÂÂ9 ?
.
ÂÂ? @
	Worksheet
ÂÂ@ I
.
ÂÂI J
Elements
ÂÂJ R
<
ÂÂR S
	SheetData
ÂÂS \
>
ÂÂ\ ]
(
ÂÂ] ^
)
ÂÂ^ _
.
ÂÂ_ `
First
ÂÂ` e
(
ÂÂe f
)
ÂÂf g
)
ÂÂg h
;
ÂÂh i
DocumentFormat
ÈÈ 
.
ÈÈ 
OpenXml
ÈÈ &
.
ÈÈ& '
Spreadsheet
ÈÈ' 2
.
ÈÈ2 3
Row
ÈÈ3 6
	headerRow
ÈÈ7 @
=
ÈÈA B
new
ÈÈC F
DocumentFormat
ÈÈG U
.
ÈÈU V
OpenXml
ÈÈV ]
.
ÈÈ] ^
Spreadsheet
ÈÈ^ i
.
ÈÈi j
Row
ÈÈj m
(
ÈÈm n
)
ÈÈn o
;
ÈÈo p
List
ÍÍ 
<
ÍÍ 
String
ÍÍ 
>
ÍÍ 
columns
ÍÍ $
=
ÍÍ% &
new
ÍÍ' *
List
ÍÍ+ /
<
ÍÍ/ 0
string
ÍÍ0 6
>
ÍÍ6 7
(
ÍÍ7 8
)
ÍÍ8 9
;
ÍÍ9 :
foreach
ÎÎ 
(
ÎÎ 

DataColumn
ÎÎ #
column
ÎÎ$ *
in
ÎÎ+ -
table
ÎÎ. 3
.
ÎÎ3 4
Columns
ÎÎ4 ;
)
ÎÎ; <
{
ÏÏ 
if
ÓÓ 
(
ÓÓ 
column
ÓÓ 
.
ÓÓ 

ColumnName
ÓÓ )
!=
ÓÓ* ,
$str
ÓÓ- 6
)
ÓÓ6 7
{
ÔÔ 
columns
ÒÒ 
.
ÒÒ  
Add
ÒÒ  #
(
ÒÒ# $
column
ÒÒ$ *
.
ÒÒ* +

ColumnName
ÒÒ+ 5
)
ÒÒ5 6
;
ÒÒ6 7
DocumentFormat
ÚÚ &
.
ÚÚ& '
OpenXml
ÚÚ' .
.
ÚÚ. /
Spreadsheet
ÚÚ/ :
.
ÚÚ: ;
Cell
ÚÚ; ?
cell
ÚÚ@ D
=
ÚÚE F
new
ÚÚG J
DocumentFormat
ÚÚK Y
.
ÚÚY Z
OpenXml
ÚÚZ a
.
ÚÚa b
Spreadsheet
ÚÚb m
.
ÚÚm n
Cell
ÚÚn r
(
ÚÚr s
)
ÚÚs t
;
ÚÚt u
cell
ÙÙ 
.
ÙÙ 
DataType
ÙÙ %
=
ÙÙ& '
DocumentFormat
ÙÙ( 6
.
ÙÙ6 7
OpenXml
ÙÙ7 >
.
ÙÙ> ?
Spreadsheet
ÙÙ? J
.
ÙÙJ K

CellValues
ÙÙK U
.
ÙÙU V
String
ÙÙV \
;
ÙÙ\ ]
cell
ıı 
.
ıı 
	CellValue
ıı &
=
ıı' (
new
ıı) ,
DocumentFormat
ıı- ;
.
ıı; <
OpenXml
ıı< C
.
ııC D
Spreadsheet
ııD O
.
ııO P
	CellValue
ııP Y
(
ııY Z
column
ııZ `
.
ıı` a

ColumnName
ııa k
)
ıık l
;
ııl m
cell
ˆˆ 
.
ˆˆ 

StyleIndex
ˆˆ '
=
ˆˆ( )
$num
ˆˆ* +
;
ˆˆ+ ,
	headerRow
˜˜ !
.
˜˜! "
AppendChild
˜˜" -
(
˜˜- .
cell
˜˜. 2
)
˜˜2 3
;
˜˜3 4
}
¯¯ 
}
˙˙ 
	sheetData
˚˚ 
.
˚˚ 
AppendChild
˚˚ %
(
˚˚% &
	headerRow
˚˚& /
)
˚˚/ 0
;
˚˚0 1
foreach
˝˝ 
(
˝˝ 
DataRow
˝˝  
dsrow
˝˝! &
in
˝˝' )
table
˝˝* /
.
˝˝/ 0
Rows
˝˝0 4
)
˝˝4 5
{
˛˛ 
DocumentFormat
ˇˇ "
.
ˇˇ" #
OpenXml
ˇˇ# *
.
ˇˇ* +
Spreadsheet
ˇˇ+ 6
.
ˇˇ6 7
Row
ˇˇ7 :
newRow
ˇˇ; A
=
ˇˇB C
new
ˇˇD G
DocumentFormat
ˇˇH V
.
ˇˇV W
OpenXml
ˇˇW ^
.
ˇˇ^ _
Spreadsheet
ˇˇ_ j
.
ˇˇj k
Row
ˇˇk n
(
ˇˇn o
)
ˇˇo p
;
ˇˇp q
bool
ÇÇ 
bisgroup
ÇÇ !
=
ÇÇ" #
dsrow
ÇÇ$ )
[
ÇÇ) *
$str
ÇÇ* 3
]
ÇÇ3 4
.
ÇÇ4 5
ToString
ÇÇ5 =
(
ÇÇ= >
)
ÇÇ> ?
==
ÇÇ@ B
$str
ÇÇC F
?
ÇÇG H
true
ÇÇI M
:
ÇÇN O
false
ÇÇP U
;
ÇÇU V
foreach
ÑÑ 
(
ÑÑ 
String
ÑÑ #
col
ÑÑ$ '
in
ÑÑ( *
columns
ÑÑ+ 2
)
ÑÑ2 3
{
ÖÖ 
DocumentFormat
ââ &
.
ââ& '
OpenXml
ââ' .
.
ââ. /
Spreadsheet
ââ/ :
.
ââ: ;
Cell
ââ; ?
cell
ââ@ D
=
ââE F
new
ââG J
DocumentFormat
ââK Y
.
ââY Z
OpenXml
ââZ a
.
ââa b
Spreadsheet
ââb m
.
ââm n
Cell
âân r
(
ââr s
)
ââs t
;
âât u
if
ää 
(
ää 
col
ää 
!=
ää  "
$str
ää# )
)
ää) *
{
ãã 
cell
åå  
.
åå  !
DataType
åå! )
=
åå* +
DocumentFormat
åå, :
.
åå: ;
OpenXml
åå; B
.
ååB C
Spreadsheet
ååC N
.
ååN O

CellValues
ååO Y
.
ååY Z
String
ååZ `
;
åå` a
cell
çç  
.
çç  !
	CellValue
çç! *
=
çç+ ,
new
çç- 0
DocumentFormat
çç1 ?
.
çç? @
OpenXml
çç@ G
.
ççG H
Spreadsheet
ççH S
.
ççS T
	CellValue
ççT ]
(
çç] ^
dsrow
çç^ c
[
ççc d
col
ççd g
]
ççg h
.
ççh i
ToString
ççi q
(
ççq r
)
ççr s
)
ççs t
;
ççt u
}
éé 
else
èè 
{
êê 
cell
ëë  
.
ëë  !
DataType
ëë! )
=
ëë* +
DocumentFormat
ëë, :
.
ëë: ;
OpenXml
ëë; B
.
ëëB C
Spreadsheet
ëëC N
.
ëëN O

CellValues
ëëO Y
.
ëëY Z
String
ëëZ `
;
ëë` a
cell
íí  
.
íí  !
	CellValue
íí! *
=
íí+ ,
new
íí- 0
DocumentFormat
íí1 ?
.
íí? @
OpenXml
íí@ G
.
ííG H
Spreadsheet
ííH S
.
ííS T
	CellValue
ííT ]
(
íí] ^
dsrow
íí^ c
[
ííc d
col
ííd g
]
ííg h
.
ííh i
ToString
ííi q
(
ííq r
)
íír s
)
íís t
;
íít u
}
ìì 
if
ññ 
(
ññ 
bisgroup
ññ $
)
ññ$ %
cell
óó  
.
óó  !

StyleIndex
óó! +
=
óó, -
$num
óó. /
;
óó/ 0
else
òò 
cell
ôô  
.
ôô  !

StyleIndex
ôô! +
=
ôô, -
$num
ôô. /
;
ôô/ 0
newRow
õõ 
.
õõ 
AppendChild
õõ *
(
õõ* +
cell
õõ+ /
)
õõ/ 0
;
õõ0 1
}
úú 
	sheetData
ùù 
.
ùù 
AppendChild
ùù )
(
ùù) *
newRow
ùù* 0
)
ùù0 1
;
ùù1 2
}
ûû 
DocumentFormat
¢¢ 
.
¢¢ 
OpenXml
¢¢ &
.
¢¢& '
Spreadsheet
¢¢' 2
.
¢¢2 3
Row
¢¢3 6
footerRowWhite1
¢¢7 F
=
¢¢G H
new
¢¢I L
DocumentFormat
¢¢M [
.
¢¢[ \
OpenXml
¢¢\ c
.
¢¢c d
Spreadsheet
¢¢d o
.
¢¢o p
Row
¢¢p s
(
¢¢s t
)
¢¢t u
;
¢¢u v
	sheetData
££ 
.
££ 
AppendChild
££ %
(
££% &
footerRowWhite1
££& 5
)
££5 6
;
££6 7
DocumentFormat
®® 
.
®® 
OpenXml
®® &
.
®®& '
Spreadsheet
®®' 2
.
®®2 3
Row
®®3 6
totalRow
®®7 ?
=
®®@ A
new
®®B E
DocumentFormat
®®F T
.
®®T U
OpenXml
®®U \
.
®®\ ]
Spreadsheet
®®] h
.
®®h i
Row
®®i l
(
®®l m
)
®®m n
;
®®n o
DocumentFormat
™™ 
.
™™ 
OpenXml
™™ &
.
™™& '
Spreadsheet
™™' 2
.
™™2 3
Cell
™™3 7
cellTotalGrupoFe
™™8 H
=
™™I J
new
™™K N
DocumentFormat
™™O ]
.
™™] ^
OpenXml
™™^ e
.
™™e f
Spreadsheet
™™f q
.
™™q r
Cell
™™r v
(
™™v w
)
™™w x
;
™™x y
cellTotalGrupoFe
´´  
.
´´  !
DataType
´´! )
=
´´* +
DocumentFormat
´´, :
.
´´: ;
OpenXml
´´; B
.
´´B C
Spreadsheet
´´C N
.
´´N O

CellValues
´´O Y
.
´´Y Z
String
´´Z `
;
´´` a
cellTotalGrupoFe
¨¨  
.
¨¨  !
	CellValue
¨¨! *
=
¨¨+ ,
new
¨¨- 0
DocumentFormat
¨¨1 ?
.
¨¨? @
OpenXml
¨¨@ G
.
¨¨G H
Spreadsheet
¨¨H S
.
¨¨S T
	CellValue
¨¨T ]
(
¨¨] ^
$str
¨¨^ n
)
¨¨n o
;
¨¨o p
cellTotalGrupoFe
≠≠  
.
≠≠  !

StyleIndex
≠≠! +
=
≠≠, -
$num
≠≠. /
;
≠≠/ 0
DocumentFormat
ØØ 
.
ØØ 
OpenXml
ØØ &
.
ØØ& '
Spreadsheet
ØØ' 2
.
ØØ2 3
Cell
ØØ3 7%
cellPreviousExecAmount2
ØØ8 O
=
ØØP Q
new
ØØR U
DocumentFormat
ØØV d
.
ØØd e
OpenXml
ØØe l
.
ØØl m
Spreadsheet
ØØm x
.
ØØx y
Cell
ØØy }
(
ØØ} ~
)
ØØ~ 
;ØØ Ä%
cellPreviousExecAmount2
∞∞ '
.
∞∞' (
DataType
∞∞( 0
=
∞∞1 2
DocumentFormat
∞∞3 A
.
∞∞A B
OpenXml
∞∞B I
.
∞∞I J
Spreadsheet
∞∞J U
.
∞∞U V

CellValues
∞∞V `
.
∞∞` a
String
∞∞a g
;
∞∞g h%
cellPreviousExecAmount2
±± '
.
±±' (
	CellValue
±±( 1
=
±±2 3
new
±±4 7
DocumentFormat
±±8 F
.
±±F G
OpenXml
±±G N
.
±±N O
Spreadsheet
±±O Z
.
±±Z [
	CellValue
±±[ d
(
±±d e
String
±±e k
.
±±k l
Format
±±l r
(
±±r s
$str
±±s z
,
±±z {'
totalPreviousExecAmount2±±| î
)±±î ï
)±±ï ñ
;±±ñ ó%
cellPreviousExecAmount2
≤≤ '
.
≤≤' (

StyleIndex
≤≤( 2
=
≤≤3 4
$num
≤≤5 6
;
≤≤6 7
DocumentFormat
µµ 
.
µµ 
OpenXml
µµ &
.
µµ& '
Spreadsheet
µµ' 2
.
µµ2 3
Cell
µµ3 7%
cellPreviousExecAmount1
µµ8 O
=
µµP Q
new
µµR U
DocumentFormat
µµV d
.
µµd e
OpenXml
µµe l
.
µµl m
Spreadsheet
µµm x
.
µµx y
Cell
µµy }
(
µµ} ~
)
µµ~ 
;µµ Ä%
cellPreviousExecAmount1
∂∂ '
.
∂∂' (
DataType
∂∂( 0
=
∂∂1 2
DocumentFormat
∂∂3 A
.
∂∂A B
OpenXml
∂∂B I
.
∂∂I J
Spreadsheet
∂∂J U
.
∂∂U V

CellValues
∂∂V `
.
∂∂` a
String
∂∂a g
;
∂∂g h%
cellPreviousExecAmount1
∑∑ '
.
∑∑' (
	CellValue
∑∑( 1
=
∑∑2 3
new
∑∑4 7
DocumentFormat
∑∑8 F
.
∑∑F G
OpenXml
∑∑G N
.
∑∑N O
Spreadsheet
∑∑O Z
.
∑∑Z [
	CellValue
∑∑[ d
(
∑∑d e
String
∑∑e k
.
∑∑k l
Format
∑∑l r
(
∑∑r s
$str
∑∑s z
,
∑∑z {'
totalPreviousExecAmount1∑∑| î
)∑∑ï ñ
)∑∑ñ ó
;∑∑ó ò%
cellPreviousExecAmount1
∏∏ '
.
∏∏' (

StyleIndex
∏∏( 2
=
∏∏3 4
$num
∏∏5 6
;
∏∏6 7
DocumentFormat
∫∫ 
.
∫∫ 
OpenXml
∫∫ &
.
∫∫& '
Spreadsheet
∫∫' 2
.
∫∫2 3
Cell
∫∫3 7$
cellPreviousExecAmount
∫∫8 N
=
∫∫O P
new
∫∫Q T
DocumentFormat
∫∫U c
.
∫∫c d
OpenXml
∫∫d k
.
∫∫k l
Spreadsheet
∫∫l w
.
∫∫w x
Cell
∫∫x |
(
∫∫| }
)
∫∫} ~
;
∫∫~ $
cellPreviousExecAmount
ªª &
.
ªª& '
DataType
ªª' /
=
ªª0 1
DocumentFormat
ªª2 @
.
ªª@ A
OpenXml
ªªA H
.
ªªH I
Spreadsheet
ªªI T
.
ªªT U

CellValues
ªªU _
.
ªª_ `
String
ªª` f
;
ªªf g$
cellPreviousExecAmount
ºº &
.
ºº& '
	CellValue
ºº' 0
=
ºº1 2
new
ºº3 6
DocumentFormat
ºº7 E
.
ººE F
OpenXml
ººF M
.
ººM N
Spreadsheet
ººN Y
.
ººY Z
	CellValue
ººZ c
(
ººc d
String
ººd j
.
ººj k
Format
ººk q
(
ººq r
$str
ººr y
,
ººy z&
totalPreviousExecAmountºº{ í
)ººí ì
)ººî ï
;ººï ñ$
cellPreviousExecAmount
ΩΩ &
.
ΩΩ& '

StyleIndex
ΩΩ' 1
=
ΩΩ2 3
$num
ΩΩ4 5
;
ΩΩ5 6
DocumentFormat
øø 
.
øø 
OpenXml
øø &
.
øø& '
Spreadsheet
øø' 2
.
øø2 3
Cell
øø3 7#
cellCurrentExecAmount
øø8 M
=
øøN O
new
øøP S
DocumentFormat
øøT b
.
øøb c
OpenXml
øøc j
.
øøj k
Spreadsheet
øøk v
.
øøv w
Cell
øøw {
(
øø{ |
)
øø| }
;
øø} ~#
cellCurrentExecAmount
¿¿ %
.
¿¿% &
DataType
¿¿& .
=
¿¿/ 0
DocumentFormat
¿¿1 ?
.
¿¿? @
OpenXml
¿¿@ G
.
¿¿G H
Spreadsheet
¿¿H S
.
¿¿S T

CellValues
¿¿T ^
.
¿¿^ _
String
¿¿_ e
;
¿¿e f#
cellCurrentExecAmount
¡¡ %
.
¡¡% &
	CellValue
¡¡& /
=
¡¡0 1
new
¡¡2 5
DocumentFormat
¡¡6 D
.
¡¡D E
OpenXml
¡¡E L
.
¡¡L M
Spreadsheet
¡¡M X
.
¡¡X Y
	CellValue
¡¡Y b
(
¡¡b c
String
¡¡c i
.
¡¡i j
Format
¡¡j p
(
¡¡p q
$str
¡¡q x
,
¡¡x y%
totalCurrentExecAmount¡¡z ê
)¡¡ê ë
)¡¡ë í
;¡¡í ì#
cellCurrentExecAmount
¬¬ %
.
¬¬% &

StyleIndex
¬¬& 0
=
¬¬1 2
$num
¬¬3 4
;
¬¬4 5
DocumentFormat
ƒƒ 
.
ƒƒ 
OpenXml
ƒƒ &
.
ƒƒ& '
Spreadsheet
ƒƒ' 2
.
ƒƒ2 3
Cell
ƒƒ3 7 
cellPreviousAmount
ƒƒ8 J
=
ƒƒK L
new
ƒƒM P
DocumentFormat
ƒƒQ _
.
ƒƒ_ `
OpenXml
ƒƒ` g
.
ƒƒg h
Spreadsheet
ƒƒh s
.
ƒƒs t
Cell
ƒƒt x
(
ƒƒx y
)
ƒƒy z
;
ƒƒz { 
cellPreviousAmount
≈≈ "
.
≈≈" #
DataType
≈≈# +
=
≈≈, -
DocumentFormat
≈≈. <
.
≈≈< =
OpenXml
≈≈= D
.
≈≈D E
Spreadsheet
≈≈E P
.
≈≈P Q

CellValues
≈≈Q [
.
≈≈[ \
String
≈≈\ b
;
≈≈b c 
cellPreviousAmount
∆∆ "
.
∆∆" #
	CellValue
∆∆# ,
=
∆∆- .
new
∆∆/ 2
DocumentFormat
∆∆3 A
.
∆∆A B
OpenXml
∆∆B I
.
∆∆I J
Spreadsheet
∆∆J U
.
∆∆U V
	CellValue
∆∆V _
(
∆∆_ `
String
∆∆` f
.
∆∆f g
Format
∆∆g m
(
∆∆m n
$str
∆∆n u
,
∆∆u v"
totalPreviousAmount∆∆w ä
)∆∆ä ã
)∆∆ã å
;∆∆å ç 
cellPreviousAmount
«« "
.
««" #

StyleIndex
««# -
=
««. /
$num
««0 1
;
««1 2
DocumentFormat
…… 
.
…… 
OpenXml
…… &
.
……& '
Spreadsheet
……' 2
.
……2 3
Cell
……3 7
cellCurrentAmount
……8 I
=
……J K
new
……L O
DocumentFormat
……P ^
.
……^ _
OpenXml
……_ f
.
……f g
Spreadsheet
……g r
.
……r s
Cell
……s w
(
……w x
)
……x y
;
……y z
cellCurrentAmount
   !
.
  ! "
DataType
  " *
=
  + ,
DocumentFormat
  - ;
.
  ; <
OpenXml
  < C
.
  C D
Spreadsheet
  D O
.
  O P

CellValues
  P Z
.
  Z [
String
  [ a
;
  a b
cellCurrentAmount
ÀÀ !
.
ÀÀ! "
	CellValue
ÀÀ" +
=
ÀÀ, -
new
ÀÀ. 1
DocumentFormat
ÀÀ2 @
.
ÀÀ@ A
OpenXml
ÀÀA H
.
ÀÀH I
Spreadsheet
ÀÀI T
.
ÀÀT U
	CellValue
ÀÀU ^
(
ÀÀ^ _
String
ÀÀ_ e
.
ÀÀe f
Format
ÀÀf l
(
ÀÀl m
$str
ÀÀm t
,
ÀÀt u!
totalCurrentAmountÀÀv à
)ÀÀà â
)ÀÀâ ä
;ÀÀä ã
cellCurrentAmount
ÃÃ !
.
ÃÃ! "

StyleIndex
ÃÃ" ,
=
ÃÃ- .
$num
ÃÃ/ 0
;
ÃÃ0 1
DocumentFormat
œœ 
.
œœ 
OpenXml
œœ &
.
œœ& '
Spreadsheet
œœ' 2
.
œœ2 3
Cell
œœ3 7
cellVariationPorc
œœ8 I
=
œœJ K
new
œœL O
DocumentFormat
œœP ^
.
œœ^ _
OpenXml
œœ_ f
.
œœf g
Spreadsheet
œœg r
.
œœr s
Cell
œœs w
(
œœw x
)
œœx y
;
œœy z
cellVariationPorc
–– !
.
––! "
DataType
––" *
=
––+ ,
DocumentFormat
––- ;
.
––; <
OpenXml
––< C
.
––C D
Spreadsheet
––D O
.
––O P

CellValues
––P Z
.
––Z [
String
––[ a
;
––a b
cellVariationPorc
—— !
.
——! "
	CellValue
——" +
=
——, -
new
——. 1
DocumentFormat
——2 @
.
——@ A
OpenXml
——A H
.
——H I
Spreadsheet
——I T
.
——T U
	CellValue
——U ^
(
——^ _
String
——_ e
.
——e f
Format
——f l
(
——l m
$str
——m t
,
——t u!
totalVariationPorc——v à
)——à â
+——ä ã
$str——å ê
)——ê ë
;——ë í
cellVariationPorc
““ !
.
““! "

StyleIndex
““" ,
=
““- .
$num
““/ 0
;
““0 1
DocumentFormat
‘‘ 
.
‘‘ 
OpenXml
‘‘ &
.
‘‘& '
Spreadsheet
‘‘' 2
.
‘‘2 3
Cell
‘‘3 7!
cellVariationAmount
‘‘8 K
=
‘‘L M
new
‘‘N Q
DocumentFormat
‘‘R `
.
‘‘` a
OpenXml
‘‘a h
.
‘‘h i
Spreadsheet
‘‘i t
.
‘‘t u
Cell
‘‘u y
(
‘‘y z
)
‘‘z {
;
‘‘{ |!
cellVariationAmount
’’ #
.
’’# $
DataType
’’$ ,
=
’’- .
DocumentFormat
’’/ =
.
’’= >
OpenXml
’’> E
.
’’E F
Spreadsheet
’’F Q
.
’’Q R

CellValues
’’R \
.
’’\ ]
String
’’] c
;
’’c d!
cellVariationAmount
÷÷ #
.
÷÷# $
	CellValue
÷÷$ -
=
÷÷. /
new
÷÷0 3
DocumentFormat
÷÷4 B
.
÷÷B C
OpenXml
÷÷C J
.
÷÷J K
Spreadsheet
÷÷K V
.
÷÷V W
	CellValue
÷÷W `
(
÷÷` a
String
÷÷a g
.
÷÷g h
Format
÷÷h n
(
÷÷n o
$str
÷÷o v
,
÷÷v w#
totalVariationAmount÷÷x å
)÷÷å ç
)÷÷ç é
;÷÷é è!
cellVariationAmount
◊◊ #
.
◊◊# $

StyleIndex
◊◊$ .
=
◊◊/ 0
$num
◊◊1 2
;
◊◊2 3
totalRow
⁄⁄ 
.
⁄⁄ 
Append
⁄⁄ 
(
⁄⁄  
cellTotalGrupoFe
⁄⁄  0
,
⁄⁄0 1%
cellPreviousExecAmount2
⁄⁄1 H
,
⁄⁄H I%
cellPreviousExecAmount1
⁄⁄J a
,
⁄⁄a b$
cellPreviousExecAmount
⁄⁄c y
,
⁄⁄y z$
cellCurrentExecAmount⁄⁄{ ê
,⁄⁄ê ë"
cellPreviousAmount⁄⁄í §
,⁄⁄§ •!
cellCurrentAmount⁄⁄¶ ∑
,⁄⁄∑ ∏!
cellVariationPorc⁄⁄π  
,⁄⁄  À#
cellVariationAmount⁄⁄Ã ﬂ
)⁄⁄ﬂ ‡
;⁄⁄‡ ·
	sheetData
‹‹ 
.
‹‹ 
AppendChild
‹‹ %
(
‹‹% &
totalRow
‹‹& .
)
‹‹. /
;
‹‹/ 0
wsPart
ÂÂ 
.
ÂÂ 
	Worksheet
ÂÂ  
.
ÂÂ  !
Save
ÂÂ! %
(
ÂÂ% &
)
ÂÂ& '
;
ÂÂ' (
var
ÈÈ 
sheets
ÈÈ 
=
ÈÈ 
spreadsheet
ÈÈ (
.
ÈÈ( )
WorkbookPart
ÈÈ) 5
.
ÈÈ5 6
Workbook
ÈÈ6 >
.
ÈÈ> ?
AppendChild
ÈÈ? J
(
ÈÈJ K
new
ÈÈK N
Sheets
ÈÈO U
(
ÈÈU V
)
ÈÈV W
)
ÈÈW X
;
ÈÈX Y
sheets
ÍÍ 
.
ÍÍ 
AppendChild
ÍÍ "
(
ÍÍ" #
new
ÍÍ# &
Sheet
ÍÍ' ,
(
ÍÍ, -
)
ÍÍ- .
{
ÍÍ/ 0
Id
ÍÍ1 3
=
ÍÍ4 5
spreadsheet
ÍÍ6 A
.
ÍÍA B
WorkbookPart
ÍÍB N
.
ÍÍN O
GetIdOfPart
ÍÍO Z
(
ÍÍZ [
wsPart
ÍÍ[ a
)
ÍÍa b
,
ÍÍb c
SheetId
ÍÍd k
=
ÍÍl m
$num
ÍÍn o
,
ÍÍo p
Name
ÍÍq u
=
ÍÍv w
$strÍÍx ê
}ÍÍë í
)ÍÍí ì
;ÍÍì î
spreadsheet
ÏÏ 
.
ÏÏ 
WorkbookPart
ÏÏ (
.
ÏÏ( )
Workbook
ÏÏ) 1
.
ÏÏ1 2
Save
ÏÏ2 6
(
ÏÏ6 7
)
ÏÏ7 8
;
ÏÏ8 9
}
ÓÓ 
}
ÔÔ 	
public
 
static
 
void
 "
EconomicConditionXLS
 /
(
/ 0
	DataTable
0 9
table
: ?
,
? @
string
A G
destination
H S
)
S T
{
ÒÒ 	
using
ÚÚ 
(
ÚÚ 
var
ÚÚ 
spreadsheet
ÚÚ "
=
ÚÚ# $!
SpreadsheetDocument
ÚÚ% 8
.
ÚÚ8 9
Create
ÚÚ9 ?
(
ÚÚ? @
destination
ÚÚ@ K
,
ÚÚK L%
SpreadsheetDocumentType
ÚÚM d
.
ÚÚd e
Workbook
ÚÚe m
)
ÚÚm n
)
ÚÚn o
{
ÛÛ 
spreadsheet
ÙÙ 
.
ÙÙ 
AddWorkbookPart
ÙÙ +
(
ÙÙ+ ,
)
ÙÙ, -
;
ÙÙ- .
spreadsheet
ıı 
.
ıı 
WorkbookPart
ıı (
.
ıı( )
Workbook
ıı) 1
=
ıı2 3
new
ıı4 7
Workbook
ıı8 @
(
ıı@ A
)
ııA B
;
ııB C
var
ˆˆ 
wsPart
ˆˆ 
=
ˆˆ 
spreadsheet
ˆˆ (
.
ˆˆ( )
WorkbookPart
ˆˆ) 5
.
ˆˆ5 6

AddNewPart
ˆˆ6 @
<
ˆˆ@ A
WorksheetPart
ˆˆA N
>
ˆˆN O
(
ˆˆO P
)
ˆˆP Q
;
ˆˆQ R
wsPart
˜˜ 
.
˜˜ 
	Worksheet
˜˜  
=
˜˜! "
new
˜˜# &
	Worksheet
˜˜' 0
(
˜˜0 1
)
˜˜1 2
;
˜˜2 3
var
˘˘ 

stylesPart
˘˘ 
=
˘˘  
spreadsheet
˘˘! ,
.
˘˘, -
WorkbookPart
˘˘- 9
.
˘˘9 :

AddNewPart
˘˘: D
<
˘˘D E 
WorkbookStylesPart
˘˘E W
>
˘˘W X
(
˘˘X Y
)
˘˘Y Z
;
˘˘Z [

stylesPart
˙˙ 
.
˙˙ 

Stylesheet
˙˙ %
=
˙˙& '
new
˙˙( +

Stylesheet
˙˙, 6
(
˙˙6 7
)
˙˙7 8
;
˙˙8 9
Font
˝˝ 
font
˝˝ 
=
˝˝ 
new
˝˝ 
Font
˝˝  $
(
˝˝$ %
)
˝˝% &
;
˝˝& '
font
˛˛ 
.
˛˛ 
Append
˛˛ 
(
˛˛ 
new
˛˛ 
Color
˛˛  %
(
˛˛% &
)
˛˛& '
{
˛˛( )
Rgb
˛˛* -
=
˛˛. /
$str
˛˛0 8
}
˛˛9 :
)
˛˛: ;
;
˛˛; <
font
ˇˇ 
.
ˇˇ 
Append
ˇˇ 
(
ˇˇ 
new
ˇˇ 
Bold
ˇˇ  $
(
ˇˇ$ %
)
ˇˇ% &
)
ˇˇ& '
;
ˇˇ' (

stylesPart
ÇÇ 
.
ÇÇ 

Stylesheet
ÇÇ %
.
ÇÇ% &
Fonts
ÇÇ& +
=
ÇÇ, -
new
ÇÇ. 1
Fonts
ÇÇ2 7
(
ÇÇ7 8
)
ÇÇ8 9
;
ÇÇ9 :

stylesPart
ÉÉ 
.
ÉÉ 

Stylesheet
ÉÉ %
.
ÉÉ% &
Fonts
ÉÉ& +
.
ÉÉ+ ,
Count
ÉÉ, 1
=
ÉÉ2 3
$num
ÉÉ4 5
;
ÉÉ5 6

stylesPart
ÑÑ 
.
ÑÑ 

Stylesheet
ÑÑ %
.
ÑÑ% &
Fonts
ÑÑ& +
.
ÑÑ+ ,
AppendChild
ÑÑ, 7
(
ÑÑ7 8
font
ÑÑ8 <
)
ÑÑ< =
;
ÑÑ= >

stylesPart
ÖÖ 
.
ÖÖ 

Stylesheet
ÖÖ %
.
ÖÖ% &
Fonts
ÖÖ& +
.
ÖÖ+ ,
AppendChild
ÖÖ, 7
(
ÖÖ7 8
new
ÖÖ8 ;
Font
ÖÖ< @
{
ÖÖA B
Color
ÖÖC H
=
ÖÖI J
new
ÖÖK N
Color
ÖÖO T
(
ÖÖT U
)
ÖÖU V
{
ÖÖW X
Rgb
ÖÖY \
=
ÖÖ] ^
$str
ÖÖ_ g
}
ÖÖh i
}
ÖÖj k
)
ÖÖk l
;
ÖÖl m

stylesPart
ÜÜ 
.
ÜÜ 

Stylesheet
ÜÜ %
.
ÜÜ% &
Fonts
ÜÜ& +
.
ÜÜ+ ,
AppendChild
ÜÜ, 7
(
ÜÜ7 8
new
ÜÜ8 ;
Font
ÜÜ< @
{
ÜÜA B
Color
ÜÜC H
=
ÜÜI J
new
ÜÜK N
Color
ÜÜO T
(
ÜÜT U
)
ÜÜU V
{
ÜÜW X
Rgb
ÜÜY \
=
ÜÜ] ^
$str
ÜÜ_ g
}
ÜÜh i
,
ÜÜj k
Bold
ÜÜk o
=
ÜÜp q
new
ÜÜr u
Bold
ÜÜv z
(
ÜÜz {
)
ÜÜ{ |
}
ÜÜ} ~
)
ÜÜ~ 
;ÜÜ Ä

stylesPart
ââ 
.
ââ 

Stylesheet
ââ %
.
ââ% &
Fills
ââ& +
=
ââ, -
new
ââ. 1
Fills
ââ2 7
(
ââ7 8
)
ââ8 9
;
ââ9 :
var
åå 
solidRed
åå 
=
åå 
new
åå "
PatternFill
åå# .
(
åå. /
)
åå/ 0
{
åå1 2
PatternType
åå3 >
=
åå? @
PatternValues
ååA N
.
ååN O
Solid
ååO T
}
ååU V
;
ååV W
solidRed
çç 
.
çç 
ForegroundColor
çç (
=
çç) *
new
çç+ .
ForegroundColor
çç/ >
{
çç? @
Rgb
ççA D
=
ççE F
HexBinaryValue
ççG U
.
ççU V

FromString
ççV `
(
çç` a
$str
çça i
)
ççi j
}
ççk l
;
ççl m
solidRed
éé 
.
éé 
BackgroundColor
éé (
=
éé) *
new
éé+ .
BackgroundColor
éé/ >
{
éé? @
Indexed
ééA H
=
ééI J
$num
ééK M
}
ééN O
;
ééO P
var
êê 
	fondogris
êê 
=
êê 
new
êê  #
PatternFill
êê$ /
(
êê/ 0
)
êê0 1
{
êê2 3
PatternType
êê4 ?
=
êê@ A
PatternValues
êêB O
.
êêO P
Solid
êêP U
}
êêV W
;
êêW X
	fondogris
ëë 
.
ëë 
ForegroundColor
ëë )
=
ëë* +
new
ëë, /
ForegroundColor
ëë0 ?
{
ëë@ A
Rgb
ëëB E
=
ëëF G
HexBinaryValue
ëëH V
.
ëëV W

FromString
ëëW a
(
ëëa b
$str
ëëb j
)
ëëj k
}
ëël m
;
ëëm n
	fondogris
íí 
.
íí 
BackgroundColor
íí )
=
íí* +
new
íí, /
BackgroundColor
íí0 ?
{
íí@ A
Indexed
ííB I
=
ííJ K
$num
ííL N
}
ííO P
;
ííP Q
var
îî 
fondoceleste
îî  
=
îî! "
new
îî# &
PatternFill
îî' 2
(
îî2 3
)
îî3 4
{
îî5 6
PatternType
îî7 B
=
îîC D
PatternValues
îîE R
.
îîR S
Solid
îîS X
}
îîY Z
;
îîZ [
fondoceleste
ïï 
.
ïï 
ForegroundColor
ïï ,
=
ïï- .
new
ïï/ 2
ForegroundColor
ïï3 B
{
ïïC D
Rgb
ïïE H
=
ïïI J
HexBinaryValue
ïïK Y
.
ïïY Z

FromString
ïïZ d
(
ïïd e
$str
ïïe m
)
ïïm n
}
ïïo p
;
ïïp q
fondoceleste
ññ 
.
ññ 
BackgroundColor
ññ ,
=
ññ- .
new
ññ/ 2
BackgroundColor
ññ3 B
{
ññC D
Indexed
ññE L
=
ññM N
$num
ññO Q
}
ññR S
;
ññS T
var
òò 
fondoamarillo
òò !
=
òò" #
new
òò$ '
PatternFill
òò( 3
(
òò3 4
)
òò4 5
{
òò6 7
PatternType
òò8 C
=
òòD E
PatternValues
òòF S
.
òòS T
Solid
òòT Y
}
òòZ [
;
òò[ \
fondoamarillo
ôô 
.
ôô 
ForegroundColor
ôô -
=
ôô. /
new
ôô0 3
ForegroundColor
ôô4 C
{
ôôD E
Rgb
ôôF I
=
ôôJ K
HexBinaryValue
ôôL Z
.
ôôZ [

FromString
ôô[ e
(
ôôe f
$str
ôôf n
)
ôôn o
}
ôôp q
;
ôôq r
fondoamarillo
öö 
.
öö 
BackgroundColor
öö -
=
öö. /
new
öö0 3
BackgroundColor
öö4 C
{
ööD E
Indexed
ööF M
=
ööN O
$num
ööP R
}
ööS T
;
ööT U
var
úú 
fondoverdeclaro
úú #
=
úú$ %
new
úú& )
PatternFill
úú* 5
(
úú5 6
)
úú6 7
{
úú8 9
PatternType
úú: E
=
úúF G
PatternValues
úúH U
.
úúU V
Solid
úúV [
}
úú\ ]
;
úú] ^
fondoverdeclaro
ùù 
.
ùù  
ForegroundColor
ùù  /
=
ùù0 1
new
ùù2 5
ForegroundColor
ùù6 E
{
ùùF G
Rgb
ùùH K
=
ùùL M
HexBinaryValue
ùùN \
.
ùù\ ]

FromString
ùù] g
(
ùùg h
$str
ùùh p
)
ùùp q
}
ùùr s
;
ùùs t
fondoverdeclaro
ûû 
.
ûû  
BackgroundColor
ûû  /
=
ûû0 1
new
ûû2 5
BackgroundColor
ûû6 E
{
ûûF G
Indexed
ûûH O
=
ûûP Q
$num
ûûR T
}
ûûU V
;
ûûV W
var
†† 
fondoverdeoscuro
†† $
=
††% &
new
††' *
PatternFill
††+ 6
(
††6 7
)
††7 8
{
††9 :
PatternType
††; F
=
††G H
PatternValues
††I V
.
††V W
Solid
††W \
}
††] ^
;
††^ _
fondoverdeoscuro
°°  
.
°°  !
ForegroundColor
°°! 0
=
°°1 2
new
°°3 6
ForegroundColor
°°7 F
{
°°G H
Rgb
°°I L
=
°°M N
HexBinaryValue
°°O ]
.
°°] ^

FromString
°°^ h
(
°°h i
$str
°°i q
)
°°q r
}
°°s t
;
°°t u
fondoverdeoscuro
¢¢  
.
¢¢  !
BackgroundColor
¢¢! 0
=
¢¢1 2
new
¢¢3 6
BackgroundColor
¢¢7 F
{
¢¢G H
Indexed
¢¢I P
=
¢¢Q R
$num
¢¢S U
}
¢¢V W
;
¢¢W X

stylesPart
ßß 
.
ßß 

Stylesheet
ßß %
.
ßß% &
Fills
ßß& +
.
ßß+ ,
AppendChild
ßß, 7
(
ßß7 8
new
ßß8 ;
Fill
ßß< @
{
ßßA B
PatternFill
ßßC N
=
ßßO P
new
ßßQ T
PatternFill
ßßU `
{
ßßa b
PatternType
ßßc n
=
ßßo p
PatternValues
ßßq ~
.
ßß~ 
Noneßß É
}ßßÑ Ö
}ßßÜ á
)ßßá à
;ßßà â

stylesPart
®® 
.
®® 

Stylesheet
®® %
.
®®% &
Fills
®®& +
.
®®+ ,
AppendChild
®®, 7
(
®®7 8
new
®®8 ;
Fill
®®< @
{
®®A B
PatternFill
®®C N
=
®®O P
new
®®Q T
PatternFill
®®U `
{
®®a b
PatternType
®®c n
=
®®o p
PatternValues
®®q ~
.
®®~ 
Gray125®® Ü
}®®á à
}®®â ä
)®®ä ã
;®®ã å

stylesPart
©© 
.
©© 

Stylesheet
©© %
.
©©% &
Fills
©©& +
.
©©+ ,
AppendChild
©©, 7
(
©©7 8
new
©©8 ;
Fill
©©< @
{
©©A B
PatternFill
©©C N
=
©©O P
solidRed
©©Q Y
}
©©Z [
)
©©[ \
;
©©\ ]

stylesPart
™™ 
.
™™ 

Stylesheet
™™ %
.
™™% &
Fills
™™& +
.
™™+ ,
AppendChild
™™, 7
(
™™7 8
new
™™8 ;
Fill
™™< @
{
™™A B
PatternFill
™™C N
=
™™O P
	fondogris
™™Q Z
}
™™[ \
)
™™\ ]
;
™™] ^

stylesPart
´´ 
.
´´ 

Stylesheet
´´ %
.
´´% &
Fills
´´& +
.
´´+ ,
AppendChild
´´, 7
(
´´7 8
new
´´8 ;
Fill
´´< @
{
´´A B
PatternFill
´´C N
=
´´O P
fondoceleste
´´Q ]
}
´´^ _
)
´´_ `
;
´´` a

stylesPart
¨¨ 
.
¨¨ 

Stylesheet
¨¨ %
.
¨¨% &
Fills
¨¨& +
.
¨¨+ ,
AppendChild
¨¨, 7
(
¨¨7 8
new
¨¨8 ;
Fill
¨¨< @
{
¨¨A B
PatternFill
¨¨C N
=
¨¨O P
fondoamarillo
¨¨Q ^
}
¨¨_ `
)
¨¨` a
;
¨¨a b

stylesPart
≠≠ 
.
≠≠ 

Stylesheet
≠≠ %
.
≠≠% &
Fills
≠≠& +
.
≠≠+ ,
AppendChild
≠≠, 7
(
≠≠7 8
new
≠≠8 ;
Fill
≠≠< @
{
≠≠A B
PatternFill
≠≠C N
=
≠≠O P
fondoverdeclaro
≠≠Q `
}
≠≠a b
)
≠≠b c
;
≠≠c d

stylesPart
ÆÆ 
.
ÆÆ 

Stylesheet
ÆÆ %
.
ÆÆ% &
Fills
ÆÆ& +
.
ÆÆ+ ,
AppendChild
ÆÆ, 7
(
ÆÆ7 8
new
ÆÆ8 ;
Fill
ÆÆ< @
{
ÆÆA B
PatternFill
ÆÆC N
=
ÆÆO P
fondoverdeoscuro
ÆÆQ a
}
ÆÆb c
)
ÆÆc d
;
ÆÆd e

stylesPart
±± 
.
±± 

Stylesheet
±± %
.
±±% &
Fills
±±& +
.
±±+ ,
Count
±±, 1
=
±±2 3
$num
±±4 5
;
±±5 6

stylesPart
¥¥ 
.
¥¥ 

Stylesheet
¥¥ %
.
¥¥% &
Borders
¥¥& -
=
¥¥. /
new
¥¥0 3
Borders
¥¥4 ;
(
¥¥; <
)
¥¥< =
;
¥¥= >

stylesPart
µµ 
.
µµ 

Stylesheet
µµ %
.
µµ% &
Borders
µµ& -
.
µµ- .
AppendChild
µµ. 9
(
µµ9 :
new
µµ: =
Border
µµ> D
(
µµD E
)
µµE F
)
µµF G
;
µµG H

stylesPart
∂∂ 
.
∂∂ 

Stylesheet
∂∂ %
.
∂∂% &
Borders
∂∂& -
.
∂∂- .
AppendChild
∂∂. 9
(
∂∂9 :
new
∂∂: =
Border
∂∂> D
(
∂∂D E
)
∂∂E F
{
∑∑ 

LeftBorder
∏∏ 
=
∏∏  
new
∏∏! $

LeftBorder
∏∏% /
(
∏∏/ 0
)
∏∏0 1
{
∏∏2 3
Style
∏∏4 9
=
∏∏: ;
BorderStyleValues
∏∏< M
.
∏∏M N
Thin
∏∏N R
}
∏∏S T
,
∏∏T U
RightBorder
ππ 
=
ππ  !
new
ππ" %
RightBorder
ππ& 1
(
ππ1 2
)
ππ2 3
{
ππ4 5
Style
ππ6 ;
=
ππ< =
BorderStyleValues
ππ> O
.
ππO P
Thin
ππP T
}
ππU V
,
∫∫ 
BottomBorder
ªª  
=
ªª! "
new
ªª# &
BottomBorder
ªª' 3
(
ªª3 4
)
ªª4 5
{
ªª6 7
Style
ªª8 =
=
ªª> ?
BorderStyleValues
ªª@ Q
.
ªªQ R
Thin
ªªR V
}
ªªW X
,
ªªX Y
	TopBorder
ºº 
=
ºº 
new
ºº  #
	TopBorder
ºº$ -
(
ºº- .
)
ºº. /
{
ºº0 1
Style
ºº2 7
=
ºº8 9
BorderStyleValues
ºº: K
.
ººK L
Thin
ººL P
}
ººQ R
}
ΩΩ 
)
ΩΩ 
;
ΩΩ 

stylesPart
ææ 
.
ææ 

Stylesheet
ææ %
.
ææ% &
Borders
ææ& -
.
ææ- .
Count
ææ. 3
=
ææ4 5
$num
ææ6 7
;
ææ7 8

stylesPart
¡¡ 
.
¡¡ 

Stylesheet
¡¡ %
.
¡¡% &
CellStyleFormats
¡¡& 6
=
¡¡7 8
new
¡¡9 <
CellStyleFormats
¡¡= M
(
¡¡M N
)
¡¡N O
;
¡¡O P

stylesPart
¬¬ 
.
¬¬ 

Stylesheet
¬¬ %
.
¬¬% &
CellStyleFormats
¬¬& 6
.
¬¬6 7
Count
¬¬7 <
=
¬¬= >
$num
¬¬? @
;
¬¬@ A

stylesPart
√√ 
.
√√ 

Stylesheet
√√ %
.
√√% &
CellStyleFormats
√√& 6
.
√√6 7
AppendChild
√√7 B
(
√√B C
new
√√C F

CellFormat
√√G Q
(
√√Q R
)
√√R S
)
√√S T
;
√√T U

stylesPart
∆∆ 
.
∆∆ 

Stylesheet
∆∆ %
.
∆∆% &
CellFormats
∆∆& 1
=
∆∆2 3
new
∆∆4 7
CellFormats
∆∆8 C
(
∆∆C D
)
∆∆D E
;
∆∆E F

stylesPart
«« 
.
«« 

Stylesheet
«« %
.
««% &
CellFormats
««& 1
.
««1 2
AppendChild
««2 =
(
««= >
new
««> A

CellFormat
««B L
(
««L M
)
««M N
)
««N O
;
««O P

stylesPart
»» 
.
»» 

Stylesheet
»» %
.
»»% &
CellFormats
»»& 1
.
»»1 2
AppendChild
»»2 =
(
»»= >
new
»»> A

CellFormat
»»B L
{
»»M N
FormatId
»»O W
=
»»X Y
$num
»»Z [
,
»»[ \
FontId
»»] c
=
»»d e
$num
»»f g
,
»»g h
BorderId
»»i q
=
»»r s
$num
»»t u
,
»»u v
FillId
»»w }
=
»»~ 
$num»»Ä Å
,»»Å Ç
	ApplyFill»»É å
=»»ç é
true»»è ì
}»»î ï
)»»ï ñ
.»»ñ ó
AppendChild»»ó ¢
(»»¢ £
new»»£ ¶
	Alignment»»ß ∞
{»»± ≤

Horizontal»»≥ Ω
=»»æ ø)
HorizontalAlignmentValues»»¿ Ÿ
.»»Ÿ ⁄
Center»»⁄ ‡
}»»· ‚
)»»‚ „
;»»„ ‰

stylesPart
…… 
.
…… 

Stylesheet
…… %
.
……% &
CellFormats
……& 1
.
……1 2
AppendChild
……2 =
(
……= >
new
……> A

CellFormat
……B L
{
……M N
FormatId
……O W
=
……X Y
$num
……Z [
,
……[ \
FontId
……] c
=
……d e
$num
……f g
,
……g h
BorderId
……i q
=
……r s
$num
……t u
,
……u v
FillId
……w }
=
……~ 
$num……Ä Å
,……Å Ç
	ApplyFill……É å
=……ç é
true……è ì
}……î ï
)……ï ñ
.……ñ ó
AppendChild……ó ¢
(……¢ £
new……£ ¶
	Alignment……ß ∞
{……± ≤

Horizontal……≥ Ω
=……æ ø)
HorizontalAlignmentValues……¿ Ÿ
.……Ÿ ⁄
Left……⁄ ﬁ
}……ﬂ ‡
)……‡ ·
;……· ‚

stylesPart
   
.
   

Stylesheet
   %
.
  % &
CellFormats
  & 1
.
  1 2
AppendChild
  2 =
(
  = >
new
  > A

CellFormat
  B L
{
  M N
FormatId
  O W
=
  X Y
$num
  Z [
,
  [ \
FontId
  ] c
=
  d e
$num
  f g
,
  g h
BorderId
  i q
=
  r s
$num
  t u
,
  u v
FillId
  w }
=
  ~ 
$num  Ä Å
,  Å Ç
	ApplyFill  É å
=  ç é
true  è ì
}  î ï
)  ï ñ
.  ñ ó
AppendChild  ó ¢
(  ¢ £
new  £ ¶
	Alignment  ß ∞
{  ± ≤

Horizontal  ≥ Ω
=  æ ø)
HorizontalAlignmentValues  ¿ Ÿ
.  Ÿ ⁄
Center  ⁄ ‡
,  · ‚
WrapText  ‚ Í
=  Í Î
true  Î Ô
,   Ò
Vertical  Ò ˘
=  ˘ ˙'
VerticalAlignmentValues  ˚ í
.  í ì
Center  ì ô
}  ô ö
)  ö õ
;  õ ú

stylesPart
ÀÀ 
.
ÀÀ 

Stylesheet
ÀÀ %
.
ÀÀ% &
CellFormats
ÀÀ& 1
.
ÀÀ1 2
AppendChild
ÀÀ2 =
(
ÀÀ= >
new
ÀÀ> A

CellFormat
ÀÀB L
{
ÀÀM N
ApplyNumberFormat
ÀÀO `
=
ÀÀ` a
true
ÀÀa e
,
ÀÀe f
NumberFormatId
ÀÀg u
=
ÀÀu v
$num
ÀÀv w
,
ÀÀw x
FormatIdÀÀy Å
=ÀÀÇ É
$numÀÀÑ Ö
,ÀÀÖ Ü
FontIdÀÀá ç
=ÀÀé è
$numÀÀê ë
,ÀÀë í
BorderIdÀÀì õ
=ÀÀú ù
$numÀÀû ü
,ÀÀü †
FillIdÀÀ° ß
=ÀÀ® ©
$numÀÀ™ ´
,ÀÀ´ ¨
	ApplyFillÀÀ≠ ∂
=ÀÀ∑ ∏
trueÀÀπ Ω
}ÀÀæ ø
)ÀÀø ¿
.ÀÀ¿ ¡
AppendChildÀÀ¡ Ã
(ÀÀÃ Õ
newÀÀÕ –
	AlignmentÀÀ— ⁄
{ÀÀ€ ‹

HorizontalÀÀ› Á
=ÀÀË È)
HorizontalAlignmentValuesÀÀÍ É
.ÀÀÉ Ñ
RightÀÀÑ â
}ÀÀä ã
)ÀÀã å
;ÀÀå ç

stylesPart
ÃÃ 
.
ÃÃ 

Stylesheet
ÃÃ %
.
ÃÃ% &
CellFormats
ÃÃ& 1
.
ÃÃ1 2
AppendChild
ÃÃ2 =
(
ÃÃ= >
new
ÃÃ> A

CellFormat
ÃÃB L
{
ÃÃM N
FormatId
ÃÃO W
=
ÃÃX Y
$num
ÃÃZ [
,
ÃÃ[ \
FontId
ÃÃ] c
=
ÃÃd e
$num
ÃÃf g
,
ÃÃg h
BorderId
ÃÃi q
=
ÃÃr s
$num
ÃÃt u
,
ÃÃu v
FillId
ÃÃw }
=
ÃÃ~ 
$numÃÃÄ Å
,ÃÃÅ Ç
	ApplyFillÃÃÉ å
=ÃÃç é
trueÃÃè ì
}ÃÃî ï
)ÃÃï ñ
.ÃÃñ ó
AppendChildÃÃó ¢
(ÃÃ¢ £
newÃÃ£ ¶
	AlignmentÃÃß ∞
{ÃÃ± ≤

HorizontalÃÃ≥ Ω
=ÃÃæ ø)
HorizontalAlignmentValuesÃÃ¿ Ÿ
.ÃÃŸ ⁄
RightÃÃ⁄ ﬂ
}ÃÃ‡ ·
)ÃÃ· ‚
;ÃÃ‚ „

stylesPart
ÕÕ 
.
ÕÕ 

Stylesheet
ÕÕ %
.
ÕÕ% &
CellFormats
ÕÕ& 1
.
ÕÕ1 2
AppendChild
ÕÕ2 =
(
ÕÕ= >
new
ÕÕ> A

CellFormat
ÕÕB L
{
ÕÕM N
ApplyNumberFormat
ÕÕO `
=
ÕÕ` a
true
ÕÕa e
,
ÕÕe f
NumberFormatId
ÕÕg u
=
ÕÕu v
$num
ÕÕw y
,
ÕÕy z
FormatIdÕÕ{ É
=ÕÕÑ Ö
$numÕÕÜ á
,ÕÕá à
FontIdÕÕâ è
=ÕÕê ë
$numÕÕí ì
,ÕÕì î
BorderIdÕÕï ù
=ÕÕû ü
$numÕÕ† °
,ÕÕ° ¢
FillIdÕÕ£ ©
=ÕÕ™ ´
$numÕÕ¨ ≠
,ÕÕ≠ Æ
	ApplyFillÕÕØ ∏
=ÕÕπ ∫
trueÕÕª ø
}ÕÕ¿ ¡
)ÕÕ¡ ¬
.ÕÕ¬ √
AppendChildÕÕ√ Œ
(ÕÕŒ œ
newÕÕœ “
	AlignmentÕÕ” ‹
{ÕÕ› ﬁ

HorizontalÕÕﬂ È
=ÕÕÍ Î)
HorizontalAlignmentValuesÕÕÏ Ö
.ÕÕÖ Ü
CenterÕÕÜ å
}ÕÕç é
)ÕÕé è
;ÕÕè ê

stylesPart
œœ 
.
œœ 

Stylesheet
œœ %
.
œœ% &
CellFormats
œœ& 1
.
œœ1 2
AppendChild
œœ2 =
(
œœ= >
new
œœ> A

CellFormat
œœB L
{
œœM N
FormatId
œœO W
=
œœX Y
$num
œœZ [
,
œœ[ \
FontId
œœ] c
=
œœd e
$num
œœf g
,
œœg h
BorderId
œœi q
=
œœr s
$num
œœt u
,
œœu v
FillId
œœw }
=
œœ~ 
$numœœÄ Å
,œœÅ Ç
	ApplyFillœœÉ å
=œœç é
trueœœè ì
}œœî ï
)œœï ñ
.œœñ ó
AppendChildœœó ¢
(œœ¢ £
newœœ£ ¶
	Alignmentœœß ∞
{œœ± ≤

Horizontalœœ≥ Ω
=œœæ ø)
HorizontalAlignmentValuesœœ¿ Ÿ
.œœŸ ⁄
Centerœœ⁄ ‡
,œœ· ‚
Verticalœœ„ Î
=œœÎ Ï'
VerticalAlignmentValuesœœÌ Ñ
.œœÑ Ö
CenterœœÖ ã
,œœã å
WrapTextœœç ï
=œœï ñ
trueœœó õ
}œœú ù
)œœù û
;œœû ü

stylesPart
–– 
.
–– 

Stylesheet
–– %
.
––% &
CellFormats
––& 1
.
––1 2
AppendChild
––2 =
(
––= >
new
––> A

CellFormat
––B L
{
––M N
FormatId
––O W
=
––X Y
$num
––Z [
,
––[ \
FontId
––] c
=
––d e
$num
––f g
,
––g h
BorderId
––i q
=
––r s
$num
––t u
,
––u v
FillId
––w }
=
––~ 
$num––Ä Å
,––Å Ç
	ApplyFill––É å
=––ç é
true––è ì
}––î ï
)––ï ñ
.––ñ ó
AppendChild––ó ¢
(––¢ £
new––£ ¶
	Alignment––ß ∞
{––± ≤

Horizontal––≥ Ω
=––æ ø)
HorizontalAlignmentValues––¿ Ÿ
.––Ÿ ⁄
Center––⁄ ‡
,––‡ ·
Vertical––‚ Í
=––Î Ï'
VerticalAlignmentValues––Ì Ñ
.––Ñ Ö
Center––Ö ã
,––ã å
WrapText––ç ï
=––ñ ó
true––ò ú
}––ù û
)––û ü
;––ü †

stylesPart
—— 
.
—— 

Stylesheet
—— %
.
——% &
CellFormats
——& 1
.
——1 2
AppendChild
——2 =
(
——= >
new
——> A

CellFormat
——B L
{
——M N
FormatId
——O W
=
——X Y
$num
——Z [
,
——[ \
FontId
——] c
=
——d e
$num
——f g
,
——g h
BorderId
——i q
=
——r s
$num
——t u
,
——u v
FillId
——w }
=
——~ 
$num——Ä Å
,——Å Ç
	ApplyFill——É å
=——ç é
true——è ì
}——î ï
)——ï ñ
.——ñ ó
AppendChild——ó ¢
(——¢ £
new——£ ¶
	Alignment——ß ∞
{——± ≤

Horizontal——≥ Ω
=——æ ø)
HorizontalAlignmentValues——¿ Ÿ
.——Ÿ ⁄
Center——⁄ ‡
,——‡ ·
Vertical——‚ Í
=——Î Ï'
VerticalAlignmentValues——Ì Ñ
.——Ñ Ö
Center——Ö ã
,——ã å
WrapText——ç ï
=——ñ ó
true——ò ú
}——ù û
)——û ü
;——ü †

stylesPart
““ 
.
““ 

Stylesheet
““ %
.
““% &
CellFormats
““& 1
.
““1 2
AppendChild
““2 =
(
““= >
new
““> A

CellFormat
““B L
{
““M N
FormatId
““O W
=
““X Y
$num
““Z [
,
““[ \
FontId
““] c
=
““d e
$num
““f g
,
““g h
BorderId
““i q
=
““r s
$num
““t u
,
““u v
FillId
““w }
=
““~ 
$num““Ä Å
,““Å Ç
	ApplyFill““É å
=““ç é
true““è ì
}““î ï
)““ï ñ
.““ñ ó
AppendChild““ó ¢
(““¢ £
new““£ ¶
	Alignment““ß ∞
{““± ≤

Horizontal““≥ Ω
=““æ ø)
HorizontalAlignmentValues““¿ Ÿ
.““Ÿ ⁄
Center““⁄ ‡
,““‡ ·
Vertical““‚ Í
=““Î Ï'
VerticalAlignmentValues““Ì Ñ
.““Ñ Ö
Center““Ö ã
,““ã å
WrapText““ç ï
=““ñ ó
true““ò ú
}““ù û
)““û ü
;““ü †

stylesPart
ˆˆ 
.
ˆˆ 

Stylesheet
ˆˆ %
.
ˆˆ% &
CellFormats
ˆˆ& 1
.
ˆˆ1 2
Count
ˆˆ2 7
=
ˆˆ8 9
$num
ˆˆ: ;
;
ˆˆ; <

stylesPart
¯¯ 
.
¯¯ 

Stylesheet
¯¯ %
.
¯¯% &
Save
¯¯& *
(
¯¯* +
)
¯¯+ ,
;
¯¯, -
Columns
˚˚ 
columnExcel
˚˚ #
=
˚˚$ %
new
˚˚& )
Columns
˚˚* 1
(
˚˚1 2
)
˚˚2 3
;
˚˚3 4
int
¸¸ 
contadorColumn
¸¸ "
=
¸¸# $
$num
¸¸% &
;
¸¸& '
columnExcel
ÇÇ 
.
ÇÇ 
Append
ÇÇ "
(
ÇÇ" #
new
ÇÇ# &
Column
ÇÇ' -
(
ÇÇ- .
)
ÇÇ. /
{
ÇÇ0 1
Min
ÇÇ2 5
=
ÇÇ6 7
Convert
ÇÇ8 ?
.
ÇÇ? @
ToUInt32
ÇÇ@ H
(
ÇÇH I
contadorColumn
ÇÇI W
)
ÇÇW X
,
ÇÇX Y
Max
ÇÇZ ]
=
ÇÇ^ _
Convert
ÇÇ` g
.
ÇÇg h
ToUInt32
ÇÇh p
(
ÇÇp q
contadorColumn
ÇÇq 
)ÇÇ Ä
,ÇÇÄ Å
WidthÇÇÇ á
=ÇÇà â
$numÇÇä é
,ÇÇé è
CustomWidthÇÇê õ
=ÇÇú ù
trueÇÇû ¢
}ÇÇ£ §
)ÇÇ§ •
;ÇÇ• ¶
contadorColumnÇÇß µ
++ÇÇµ ∑
;ÇÇ∑ ∏
columnExcel
ÉÉ 
.
ÉÉ 
Append
ÉÉ "
(
ÉÉ" #
new
ÉÉ# &
Column
ÉÉ' -
(
ÉÉ- .
)
ÉÉ. /
{
ÉÉ0 1
Min
ÉÉ2 5
=
ÉÉ6 7
Convert
ÉÉ8 ?
.
ÉÉ? @
ToUInt32
ÉÉ@ H
(
ÉÉH I
contadorColumn
ÉÉI W
)
ÉÉW X
,
ÉÉX Y
Max
ÉÉZ ]
=
ÉÉ^ _
Convert
ÉÉ` g
.
ÉÉg h
ToUInt32
ÉÉh p
(
ÉÉp q
contadorColumn
ÉÉq 
)ÉÉ Ä
,ÉÉÄ Å
WidthÉÉÇ á
=ÉÉà â
$numÉÉä é
,ÉÉé è
CustomWidthÉÉê õ
=ÉÉú ù
trueÉÉû ¢
}ÉÉ£ §
)ÉÉ§ •
;ÉÉ• ¶
contadorColumnÉÉß µ
++ÉÉµ ∑
;ÉÉ∑ ∏
columnExcel
ÑÑ 
.
ÑÑ 
Append
ÑÑ "
(
ÑÑ" #
new
ÑÑ# &
Column
ÑÑ' -
(
ÑÑ- .
)
ÑÑ. /
{
ÑÑ0 1
Min
ÑÑ2 5
=
ÑÑ6 7
Convert
ÑÑ8 ?
.
ÑÑ? @
ToUInt32
ÑÑ@ H
(
ÑÑH I
contadorColumn
ÑÑI W
)
ÑÑW X
,
ÑÑX Y
Max
ÑÑZ ]
=
ÑÑ^ _
Convert
ÑÑ` g
.
ÑÑg h
ToUInt32
ÑÑh p
(
ÑÑp q
contadorColumn
ÑÑq 
)ÑÑ Ä
,ÑÑÄ Å
WidthÑÑÇ á
=ÑÑà â
$numÑÑä é
,ÑÑé è
CustomWidthÑÑê õ
=ÑÑú ù
trueÑÑû ¢
}ÑÑ£ §
)ÑÑ§ •
;ÑÑ• ¶
contadorColumnÑÑß µ
++ÑÑµ ∑
;ÑÑ∑ ∏
columnExcel
ÖÖ 
.
ÖÖ 
Append
ÖÖ "
(
ÖÖ" #
new
ÖÖ# &
Column
ÖÖ' -
(
ÖÖ- .
)
ÖÖ. /
{
ÖÖ0 1
Min
ÖÖ2 5
=
ÖÖ6 7
Convert
ÖÖ8 ?
.
ÖÖ? @
ToUInt32
ÖÖ@ H
(
ÖÖH I
contadorColumn
ÖÖI W
)
ÖÖW X
,
ÖÖX Y
Max
ÖÖZ ]
=
ÖÖ^ _
Convert
ÖÖ` g
.
ÖÖg h
ToUInt32
ÖÖh p
(
ÖÖp q
contadorColumn
ÖÖq 
)ÖÖ Ä
,ÖÖÄ Å
WidthÖÖÇ á
=ÖÖà â
$numÖÖä å
,ÖÖå ç
CustomWidthÖÖé ô
=ÖÖö õ
trueÖÖú †
}ÖÖ° ¢
)ÖÖ¢ £
;ÖÖ£ §
contadorColumnÖÖ• ≥
++ÖÖ≥ µ
;ÖÖµ ∂
columnExcel
ÜÜ 
.
ÜÜ 
Append
ÜÜ "
(
ÜÜ" #
new
ÜÜ# &
Column
ÜÜ' -
(
ÜÜ- .
)
ÜÜ. /
{
ÜÜ0 1
Min
ÜÜ2 5
=
ÜÜ6 7
Convert
ÜÜ8 ?
.
ÜÜ? @
ToUInt32
ÜÜ@ H
(
ÜÜH I
contadorColumn
ÜÜI W
)
ÜÜW X
,
ÜÜX Y
Max
ÜÜZ ]
=
ÜÜ^ _
Convert
ÜÜ` g
.
ÜÜg h
ToUInt32
ÜÜh p
(
ÜÜp q
contadorColumn
ÜÜq 
)ÜÜ Ä
,ÜÜÄ Å
WidthÜÜÇ á
=ÜÜà â
$numÜÜä é
,ÜÜé è
CustomWidthÜÜê õ
=ÜÜú ù
trueÜÜû ¢
}ÜÜ£ §
)ÜÜ§ •
;ÜÜ• ¶
contadorColumnÜÜß µ
++ÜÜµ ∑
;ÜÜ∑ ∏
columnExcel
áá 
.
áá 
Append
áá "
(
áá" #
new
áá# &
Column
áá' -
(
áá- .
)
áá. /
{
áá0 1
Min
áá2 5
=
áá6 7
Convert
áá8 ?
.
áá? @
ToUInt32
áá@ H
(
ááH I
contadorColumn
ááI W
)
ááW X
,
ááX Y
Max
ááZ ]
=
áá^ _
Convert
áá` g
.
áág h
ToUInt32
ááh p
(
ááp q
contadorColumn
ááq 
)áá Ä
,ááÄ Å
WidthááÇ á
=ááà â
$numááä å
,ááå ç
CustomWidthááé ô
=ááö õ
trueááú †
}áá° ¢
)áá¢ £
;áá£ §
contadorColumnáá• ≥
++áá≥ µ
;ááµ ∂
columnExcel
ââ 
.
ââ 
Append
ââ "
(
ââ" #
new
ââ# &
Column
ââ' -
(
ââ- .
)
ââ. /
{
ââ0 1
Min
ââ2 5
=
ââ6 7
Convert
ââ8 ?
.
ââ? @
ToUInt32
ââ@ H
(
ââH I
contadorColumn
ââI W
)
ââW X
,
ââX Y
Max
ââZ ]
=
ââ^ _
Convert
ââ` g
.
ââg h
ToUInt32
ââh p
(
ââp q
contadorColumn
ââq 
)ââ Ä
,ââÄ Å
WidthââÇ á
=ââà â
$numââä ã
,ââã å
CustomWidthââç ò
=ââô ö
trueââõ ü
}ââ† °
)ââ° ¢
;ââ¢ £
contadorColumnââ§ ≤
++ââ≤ ¥
;ââ¥ µ
columnExcel
ãã 
.
ãã 
Append
ãã "
(
ãã" #
new
ãã# &
Column
ãã' -
(
ãã- .
)
ãã. /
{
ãã0 1
Min
ãã2 5
=
ãã6 7
Convert
ãã8 ?
.
ãã? @
ToUInt32
ãã@ H
(
ããH I
contadorColumn
ããI W
)
ããW X
,
ããX Y
Max
ããZ ]
=
ãã^ _
Convert
ãã` g
.
ããg h
ToUInt32
ããh p
(
ããp q
contadorColumn
ããq 
)ãã Ä
,ããÄ Å
WidthããÇ á
=ããà â
$numããä å
,ããå ç
CustomWidthããé ô
=ããö õ
trueããú †
}ãã° ¢
)ãã¢ £
;ãã£ §
contadorColumnãã• ≥
++ãã≥ µ
;ããµ ∂
columnExcel
åå 
.
åå 
Append
åå "
(
åå" #
new
åå# &
Column
åå' -
(
åå- .
)
åå. /
{
åå0 1
Min
åå2 5
=
åå6 7
Convert
åå8 ?
.
åå? @
ToUInt32
åå@ H
(
ååH I
contadorColumn
ååI W
)
ååW X
,
ååX Y
Max
ååZ ]
=
åå^ _
Convert
åå` g
.
ååg h
ToUInt32
ååh p
(
ååp q
contadorColumn
ååq 
)åå Ä
,ååÄ Å
WidthååÇ á
=ååà â
$numååä å
,ååå ç
CustomWidthååé ô
=ååö õ
trueååú †
}åå° ¢
)åå¢ £
;åå£ §
contadorColumnåå• ≥
++åå≥ µ
;ååµ ∂
columnExcel
çç 
.
çç 
Append
çç "
(
çç" #
new
çç# &
Column
çç' -
(
çç- .
)
çç. /
{
çç0 1
Min
çç2 5
=
çç6 7
Convert
çç8 ?
.
çç? @
ToUInt32
çç@ H
(
ççH I
contadorColumn
ççI W
)
ççW X
,
ççX Y
Max
ççZ ]
=
çç^ _
Convert
çç` g
.
ççg h
ToUInt32
ççh p
(
ççp q
contadorColumn
ççq 
)çç Ä
,ççÄ Å
WidthççÇ á
=ççà â
$numççä å
,ççå ç
CustomWidthççé ô
=ççö õ
trueççú †
}çç° ¢
)çç¢ £
;çç£ §
contadorColumnçç• ≥
++çç≥ µ
;ççµ ∂
columnExcel
éé 
.
éé 
Append
éé "
(
éé" #
new
éé# &
Column
éé' -
(
éé- .
)
éé. /
{
éé0 1
Min
éé2 5
=
éé6 7
Convert
éé8 ?
.
éé? @
ToUInt32
éé@ H
(
ééH I
contadorColumn
ééI W
)
ééW X
,
ééX Y
Max
ééZ ]
=
éé^ _
Convert
éé` g
.
éég h
ToUInt32
ééh p
(
éép q
contadorColumn
ééq 
)éé Ä
,ééÄ Å
WidthééÇ á
=ééà â
$numééä å
,ééå ç
CustomWidthééé ô
=ééö õ
trueééú †
}éé° ¢
)éé¢ £
;éé£ §
contadorColumnéé• ≥
++éé≥ µ
;ééµ ∂
columnExcel
èè 
.
èè 
Append
èè "
(
èè" #
new
èè# &
Column
èè' -
(
èè- .
)
èè. /
{
èè0 1
Min
èè2 5
=
èè6 7
Convert
èè8 ?
.
èè? @
ToUInt32
èè@ H
(
èèH I
contadorColumn
èèI W
)
èèW X
,
èèX Y
Max
èèZ ]
=
èè^ _
Convert
èè` g
.
èèg h
ToUInt32
èèh p
(
èèp q
contadorColumn
èèq 
)èè Ä
,èèÄ Å
WidthèèÇ á
=èèà â
$numèèä å
,èèå ç
CustomWidthèèé ô
=èèö õ
trueèèú †
}èè° ¢
)èè¢ £
;èè£ §
contadorColumnèè• ≥
++èè≥ µ
;èèµ ∂
columnExcel
êê 
.
êê 
Append
êê "
(
êê" #
new
êê# &
Column
êê' -
(
êê- .
)
êê. /
{
êê0 1
Min
êê2 5
=
êê6 7
Convert
êê8 ?
.
êê? @
ToUInt32
êê@ H
(
êêH I
contadorColumn
êêI W
)
êêW X
,
êêX Y
Max
êêZ ]
=
êê^ _
Convert
êê` g
.
êêg h
ToUInt32
êêh p
(
êêp q
contadorColumn
êêq 
)êê Ä
,êêÄ Å
WidthêêÇ á
=êêà â
$numêêä å
,êêå ç
CustomWidthêêé ô
=êêö õ
trueêêú †
}êê° ¢
)êê¢ £
;êê£ §
contadorColumnêê• ≥
++êê≥ µ
;êêµ ∂
columnExcel
ëë 
.
ëë 
Append
ëë "
(
ëë" #
new
ëë# &
Column
ëë' -
(
ëë- .
)
ëë. /
{
ëë0 1
Min
ëë2 5
=
ëë6 7
Convert
ëë8 ?
.
ëë? @
ToUInt32
ëë@ H
(
ëëH I
contadorColumn
ëëI W
)
ëëW X
,
ëëX Y
Max
ëëZ ]
=
ëë^ _
Convert
ëë` g
.
ëëg h
ToUInt32
ëëh p
(
ëëp q
contadorColumn
ëëq 
)ëë Ä
,ëëÄ Å
WidthëëÇ á
=ëëà â
$numëëä å
,ëëå ç
CustomWidthëëé ô
=ëëö õ
trueëëú †
}ëë° ¢
)ëë¢ £
;ëë£ §
contadorColumnëë• ≥
++ëë≥ µ
;ëëµ ∂
columnExcel
íí 
.
íí 
Append
íí "
(
íí" #
new
íí# &
Column
íí' -
(
íí- .
)
íí. /
{
íí0 1
Min
íí2 5
=
íí6 7
Convert
íí8 ?
.
íí? @
ToUInt32
íí@ H
(
ííH I
contadorColumn
ííI W
)
ííW X
,
ííX Y
Max
ííZ ]
=
íí^ _
Convert
íí` g
.
ííg h
ToUInt32
ííh p
(
ííp q
contadorColumn
ííq 
)íí Ä
,ííÄ Å
WidthííÇ á
=ííà â
$numííä å
,ííå ç
CustomWidthííé ô
=ííö õ
trueííú †
}íí° ¢
)íí¢ £
;íí£ §
contadorColumníí• ≥
++íí≥ µ
;ííµ ∂
columnExcel
îî 
.
îî 
Append
îî "
(
îî" #
new
îî# &
Column
îî' -
(
îî- .
)
îî. /
{
îî0 1
Min
îî2 5
=
îî6 7
Convert
îî8 ?
.
îî? @
ToUInt32
îî@ H
(
îîH I
contadorColumn
îîI W
)
îîW X
,
îîX Y
Max
îîZ ]
=
îî^ _
Convert
îî` g
.
îîg h
ToUInt32
îîh p
(
îîp q
contadorColumn
îîq 
)îî Ä
,îîÄ Å
WidthîîÇ á
=îîà â
$numîîä ã
,îîã å
CustomWidthîîç ò
=îîô ö
trueîîõ ü
}îî† °
)îî° ¢
;îî¢ £
contadorColumnîî§ ≤
++îî≤ ¥
;îî¥ µ
columnExcel
ññ 
.
ññ 
Append
ññ "
(
ññ" #
new
ññ# &
Column
ññ' -
(
ññ- .
)
ññ. /
{
ññ0 1
Min
ññ2 5
=
ññ6 7
Convert
ññ8 ?
.
ññ? @
ToUInt32
ññ@ H
(
ññH I
contadorColumn
ññI W
)
ññW X
,
ññX Y
Max
ññZ ]
=
ññ^ _
Convert
ññ` g
.
ññg h
ToUInt32
ññh p
(
ññp q
contadorColumn
ññq 
)ññ Ä
,ññÄ Å
WidthññÇ á
=ññà â
$numññä å
,ññå ç
CustomWidthññé ô
=ññö õ
trueññú †
}ññ° ¢
)ññ¢ £
;ññ£ §
contadorColumnññ• ≥
++ññ≥ µ
;ññµ ∂
columnExcel
òò 
.
òò 
Append
òò "
(
òò" #
new
òò# &
Column
òò' -
(
òò- .
)
òò. /
{
òò0 1
Min
òò2 5
=
òò6 7
Convert
òò8 ?
.
òò? @
ToUInt32
òò@ H
(
òòH I
contadorColumn
òòI W
)
òòW X
,
òòX Y
Max
òòZ ]
=
òò^ _
Convert
òò` g
.
òòg h
ToUInt32
òòh p
(
òòp q
contadorColumn
òòq 
)òò Ä
,òòÄ Å
WidthòòÇ á
=òòà â
$numòòä ã
,òòã å
CustomWidthòòç ò
=òòô ö
trueòòõ ü
}òò† °
)òò° ¢
;òò¢ £
contadorColumnòò§ ≤
++òò≤ ¥
;òò¥ µ
columnExcel
öö 
.
öö 
Append
öö "
(
öö" #
new
öö# &
Column
öö' -
(
öö- .
)
öö. /
{
öö0 1
Min
öö2 5
=
öö6 7
Convert
öö8 ?
.
öö? @
ToUInt32
öö@ H
(
ööH I
contadorColumn
ööI W
)
ööW X
,
ööX Y
Max
ööZ ]
=
öö^ _
Convert
öö` g
.
öög h
ToUInt32
ööh p
(
ööp q
contadorColumn
ööq 
)öö Ä
,ööÄ Å
WidthööÇ á
=ööà â
$numööä å
,ööå ç
CustomWidthööé ô
=ööö õ
trueööú †
}öö° ¢
)öö¢ £
;öö£ §
contadorColumnöö• ≥
++öö≥ µ
;ööµ ∂
columnExcel
õõ 
.
õõ 
Append
õõ "
(
õõ" #
new
õõ# &
Column
õõ' -
(
õõ- .
)
õõ. /
{
õõ0 1
Min
õõ2 5
=
õõ6 7
Convert
õõ8 ?
.
õõ? @
ToUInt32
õõ@ H
(
õõH I
contadorColumn
õõI W
)
õõW X
,
õõX Y
Max
õõZ ]
=
õõ^ _
Convert
õõ` g
.
õõg h
ToUInt32
õõh p
(
õõp q
contadorColumn
õõq 
)õõ Ä
,õõÄ Å
WidthõõÇ á
=õõà â
$numõõä å
,õõå ç
CustomWidthõõé ô
=õõö õ
trueõõú †
}õõ° ¢
)õõ¢ £
;õõ£ §
contadorColumnõõ• ≥
++õõ≥ µ
;õõµ ∂
columnExcel
úú 
.
úú 
Append
úú "
(
úú" #
new
úú# &
Column
úú' -
(
úú- .
)
úú. /
{
úú0 1
Min
úú2 5
=
úú6 7
Convert
úú8 ?
.
úú? @
ToUInt32
úú@ H
(
úúH I
contadorColumn
úúI W
)
úúW X
,
úúX Y
Max
úúZ ]
=
úú^ _
Convert
úú` g
.
úúg h
ToUInt32
úúh p
(
úúp q
contadorColumn
úúq 
)úú Ä
,úúÄ Å
WidthúúÇ á
=úúà â
$numúúä å
,úúå ç
CustomWidthúúé ô
=úúö õ
trueúúú †
}úú° ¢
)úú¢ £
;úú£ §
contadorColumnúú• ≥
++úú≥ µ
;úúµ ∂
columnExcel
ùù 
.
ùù 
Append
ùù "
(
ùù" #
new
ùù# &
Column
ùù' -
(
ùù- .
)
ùù. /
{
ùù0 1
Min
ùù2 5
=
ùù6 7
Convert
ùù8 ?
.
ùù? @
ToUInt32
ùù@ H
(
ùùH I
contadorColumn
ùùI W
)
ùùW X
,
ùùX Y
Max
ùùZ ]
=
ùù^ _
Convert
ùù` g
.
ùùg h
ToUInt32
ùùh p
(
ùùp q
contadorColumn
ùùq 
)ùù Ä
,ùùÄ Å
WidthùùÇ á
=ùùà â
$numùùä å
,ùùå ç
CustomWidthùùé ô
=ùùö õ
trueùùú †
}ùù° ¢
)ùù¢ £
;ùù£ §
contadorColumnùù• ≥
++ùù≥ µ
;ùùµ ∂
columnExcel
ûû 
.
ûû 
Append
ûû "
(
ûû" #
new
ûû# &
Column
ûû' -
(
ûû- .
)
ûû. /
{
ûû0 1
Min
ûû2 5
=
ûû6 7
Convert
ûû8 ?
.
ûû? @
ToUInt32
ûû@ H
(
ûûH I
contadorColumn
ûûI W
)
ûûW X
,
ûûX Y
Max
ûûZ ]
=
ûû^ _
Convert
ûû` g
.
ûûg h
ToUInt32
ûûh p
(
ûûp q
contadorColumn
ûûq 
)ûû Ä
,ûûÄ Å
WidthûûÇ á
=ûûà â
$numûûä å
,ûûå ç
CustomWidthûûé ô
=ûûö õ
trueûûú †
}ûû° ¢
)ûû¢ £
;ûû£ §
contadorColumnûû• ≥
++ûû≥ µ
;ûûµ ∂
columnExcel
üü 
.
üü 
Append
üü "
(
üü" #
new
üü# &
Column
üü' -
(
üü- .
)
üü. /
{
üü0 1
Min
üü2 5
=
üü6 7
Convert
üü8 ?
.
üü? @
ToUInt32
üü@ H
(
üüH I
contadorColumn
üüI W
)
üüW X
,
üüX Y
Max
üüZ ]
=
üü^ _
Convert
üü` g
.
üüg h
ToUInt32
üüh p
(
üüp q
contadorColumn
üüq 
)üü Ä
,üüÄ Å
WidthüüÇ á
=üüà â
$numüüä å
,üüå ç
CustomWidthüüé ô
=üüö õ
trueüüú †
}üü° ¢
)üü¢ £
;üü£ §
contadorColumnüü• ≥
++üü≥ µ
;üüµ ∂
columnExcel
†† 
.
†† 
Append
†† "
(
††" #
new
††# &
Column
††' -
(
††- .
)
††. /
{
††0 1
Min
††2 5
=
††6 7
Convert
††8 ?
.
††? @
ToUInt32
††@ H
(
††H I
contadorColumn
††I W
)
††W X
,
††X Y
Max
††Z ]
=
††^ _
Convert
††` g
.
††g h
ToUInt32
††h p
(
††p q
contadorColumn
††q 
)†† Ä
,††Ä Å
Width††Ç á
=††à â
$num††ä å
,††å ç
CustomWidth††é ô
=††ö õ
true††ú †
}††° ¢
)††¢ £
;††£ §
contadorColumn††• ≥
++††≥ µ
;††µ ∂
columnExcel
°° 
.
°° 
Append
°° "
(
°°" #
new
°°# &
Column
°°' -
(
°°- .
)
°°. /
{
°°0 1
Min
°°2 5
=
°°6 7
Convert
°°8 ?
.
°°? @
ToUInt32
°°@ H
(
°°H I
contadorColumn
°°I W
)
°°W X
,
°°X Y
Max
°°Z ]
=
°°^ _
Convert
°°` g
.
°°g h
ToUInt32
°°h p
(
°°p q
contadorColumn
°°q 
)°° Ä
,°°Ä Å
Width°°Ç á
=°°à â
$num°°ä å
,°°å ç
CustomWidth°°é ô
=°°ö õ
true°°ú †
}°°° ¢
)°°¢ £
;°°£ §
contadorColumn°°• ≥
++°°≥ µ
;°°µ ∂
columnExcel
¢¢ 
.
¢¢ 
Append
¢¢ "
(
¢¢" #
new
¢¢# &
Column
¢¢' -
(
¢¢- .
)
¢¢. /
{
¢¢0 1
Min
¢¢2 5
=
¢¢6 7
Convert
¢¢8 ?
.
¢¢? @
ToUInt32
¢¢@ H
(
¢¢H I
contadorColumn
¢¢I W
)
¢¢W X
,
¢¢X Y
Max
¢¢Z ]
=
¢¢^ _
Convert
¢¢` g
.
¢¢g h
ToUInt32
¢¢h p
(
¢¢p q
contadorColumn
¢¢q 
)¢¢ Ä
,¢¢Ä Å
Width¢¢Ç á
=¢¢à â
$num¢¢ä å
,¢¢å ç
CustomWidth¢¢é ô
=¢¢ö õ
true¢¢ú †
}¢¢° ¢
)¢¢¢ £
;¢¢£ §
contadorColumn¢¢• ≥
++¢¢≥ µ
;¢¢µ ∂
columnExcel
££ 
.
££ 
Append
££ "
(
££" #
new
££# &
Column
££' -
(
££- .
)
££. /
{
££0 1
Min
££2 5
=
££6 7
Convert
££8 ?
.
££? @
ToUInt32
££@ H
(
££H I
contadorColumn
££I W
)
££W X
,
££X Y
Max
££Z ]
=
££^ _
Convert
££` g
.
££g h
ToUInt32
££h p
(
££p q
contadorColumn
££q 
)££ Ä
,££Ä Å
Width££Ç á
=££à â
$num££ä å
,££å ç
CustomWidth££é ô
=££ö õ
true££ú †
}££° ¢
)££¢ £
;£££ §
contadorColumn££• ≥
++££≥ µ
;££µ ∂
columnExcel
•• 
.
•• 
Append
•• "
(
••" #
new
••# &
Column
••' -
(
••- .
)
••. /
{
••0 1
Min
••2 5
=
••6 7
Convert
••8 ?
.
••? @
ToUInt32
••@ H
(
••H I
contadorColumn
••I W
)
••W X
,
••X Y
Max
••Z ]
=
••^ _
Convert
••` g
.
••g h
ToUInt32
••h p
(
••p q
contadorColumn
••q 
)•• Ä
,••Ä Å
Width••Ç á
=••à â
$num••ä ã
,••ã å
CustomWidth••ç ò
=••ô ö
true••õ ü
}••† °
)••° ¢
;••¢ £
contadorColumn••§ ≤
++••≤ ¥
;••¥ µ
columnExcel
ßß 
.
ßß 
Append
ßß "
(
ßß" #
new
ßß# &
Column
ßß' -
(
ßß- .
)
ßß. /
{
ßß0 1
Min
ßß2 5
=
ßß6 7
Convert
ßß8 ?
.
ßß? @
ToUInt32
ßß@ H
(
ßßH I
contadorColumn
ßßI W
)
ßßW X
,
ßßX Y
Max
ßßZ ]
=
ßß^ _
Convert
ßß` g
.
ßßg h
ToUInt32
ßßh p
(
ßßp q
contadorColumn
ßßq 
)ßß Ä
,ßßÄ Å
WidthßßÇ á
=ßßà â
$numßßä å
,ßßå ç
CustomWidthßßé ô
=ßßö õ
trueßßú †
}ßß° ¢
)ßß¢ £
;ßß£ §
contadorColumnßß• ≥
++ßß≥ µ
;ßßµ ∂
wsPart
ØØ 
.
ØØ 
	Worksheet
ØØ  
.
ØØ  !
Append
ØØ! '
(
ØØ' (
columnExcel
ØØ( 3
)
ØØ3 4
;
ØØ4 5
var
±± 
	sheetData
±± 
=
±± 
wsPart
±±  &
.
±±& '
	Worksheet
±±' 0
.
±±0 1
AppendChild
±±1 <
(
±±< =
new
±±= @
	SheetData
±±A J
(
±±J K
)
±±K L
)
±±L M
;
±±M N
DocumentFormat
¥¥ 
.
¥¥ 
OpenXml
¥¥ &
.
¥¥& '
Spreadsheet
¥¥' 2
.
¥¥2 3
Row
¥¥3 6
	headerRow
¥¥7 @
=
¥¥A B
new
¥¥C F
DocumentFormat
¥¥G U
.
¥¥U V
OpenXml
¥¥V ]
.
¥¥] ^
Spreadsheet
¥¥^ i
.
¥¥i j
Row
¥¥j m
(
¥¥m n
)
¥¥n o
;
¥¥o p
List
µµ 
<
µµ 
String
µµ 
>
µµ 
columns
µµ $
=
µµ% &
new
µµ' *
List
µµ+ /
<
µµ/ 0
string
µµ0 6
>
µµ6 7
(
µµ7 8
)
µµ8 9
;
µµ9 :
List
∑∑ 
<
∑∑ 
string
∑∑ 
>
∑∑ 
columnasstring
∑∑ +
=
∑∑, -
new
∑∑. 1
List
∑∑2 6
<
∑∑6 7
string
∑∑7 =
>
∑∑= >
(
∑∑> ?
)
∑∑? @
;
∑∑@ A
columnasstring
∏∏ 
.
∏∏ 
Add
∏∏ "
(
∏∏" #
$str
∏∏# +
)
∏∏+ ,
;
∏∏, -
columnasstring
ππ 
.
ππ 
Add
ππ "
(
ππ" #
$str
ππ# 0
)
ππ0 1
;
ππ1 2
columnasstring
∫∫ 
.
∫∫ 
Add
∫∫ "
(
∫∫" #
$str
∫∫# *
)
∫∫* +
;
∫∫+ ,
columnasstring
ªª 
.
ªª 
Add
ªª "
(
ªª" #
$str
ªª# )
)
ªª) *
;
ªª* +
columnasstring
ºº 
.
ºº 
Add
ºº "
(
ºº" #
$str
ºº# .
)
ºº. /
;
ºº/ 0
List
ææ 
<
ææ 
string
ææ 
>
ææ 
columnascelestes
ææ -
=
ææ. /
new
ææ0 3
List
ææ4 8
<
ææ8 9
string
ææ9 ?
>
ææ? @
(
ææ@ A
)
ææA B
;
ææB C
columnascelestes
¿¿  
.
¿¿  !
Add
¿¿! $
(
¿¿$ %
$"
¿¿% '
$str
¿¿' 1
"
¿¿1 2
)
¿¿2 3
;
¿¿3 4
columnascelestes
¡¡  
.
¡¡  !
Add
¡¡! $
(
¡¡$ %
$"
¡¡% '
$str
¡¡' 6
"
¡¡6 7
)
¡¡7 8
;
¡¡8 9
columnascelestes
¬¬  
.
¬¬  !
Add
¬¬! $
(
¬¬$ %
$"
¬¬% '
$str
¬¬' 3
"
¬¬3 4
)
¬¬4 5
;
¬¬5 6
columnascelestes
√√  
.
√√  !
Add
√√! $
(
√√$ %
$"
√√% '
$str
√√' +
"
√√+ ,
)
√√, -
;
√√- .
columnascelestes
ƒƒ  
.
ƒƒ  !
Add
ƒƒ! $
(
ƒƒ$ %
$"
ƒƒ% '
$str
ƒƒ' 8
"
ƒƒ8 9
)
ƒƒ9 :
;
ƒƒ: ;
columnascelestes
≈≈  
.
≈≈  !
Add
≈≈! $
(
≈≈$ %
$"
≈≈% '
$str
≈≈' 2
"
≈≈2 3
)
≈≈3 4
;
≈≈4 5
columnascelestes
∆∆  
.
∆∆  !
Add
∆∆! $
(
∆∆$ %
$"
∆∆% '
$str
∆∆' 1
"
∆∆1 2
)
∆∆2 3
;
∆∆3 4
columnascelestes
««  
.
««  !
Add
««! $
(
««$ %
$"
««% '
$str
««' 2
"
««2 3
)
««3 4
;
««4 5
List
…… 
<
…… 
string
…… 
>
…… 
columnasamarillas
…… .
=
……/ 0
new
……1 4
List
……5 9
<
……9 :
string
……: @
>
……@ A
(
……A B
)
……B C
;
……C D
columnasamarillas
ÃÃ !
.
ÃÃ! "
Add
ÃÃ" %
(
ÃÃ% &
$"
ÃÃ& (
$str
ÃÃ( ;
"
ÃÃ; <
)
ÃÃ< =
;
ÃÃ= >
columnasamarillas
ÕÕ !
.
ÕÕ! "
Add
ÕÕ" %
(
ÕÕ% &
$"
ÕÕ& (
$str
ÕÕ( ;
"
ÕÕ; <
)
ÕÕ< =
;
ÕÕ= >
List
–– 
<
–– 
string
–– 
>
––  
columnasverdeclaro
–– /
=
––0 1
new
––2 5
List
––6 :
<
––: ;
string
––; A
>
––A B
(
––B C
)
––C D
;
––D E 
columnasverdeclaro
““ "
.
““" #
Add
““# &
(
““& '
$"
““' )
$str
““) 5
"
““5 6
)
““6 7
;
““7 8 
columnasverdeclaro
”” "
.
””" #
Add
””# &
(
””& '
$"
””' )
$str
””) :
"
””: ;
)
””; <
;
””< = 
columnasverdeclaro
‘‘ "
.
‘‘" #
Add
‘‘# &
(
‘‘& '
$"
‘‘' )
$str
‘‘) 7
"
‘‘7 8
)
‘‘8 9
;
‘‘9 : 
columnasverdeclaro
’’ "
.
’’" #
Add
’’# &
(
’’& '
$"
’’' )
$str
’’) /
"
’’/ 0
)
’’0 1
;
’’1 2 
columnasverdeclaro
÷÷ "
.
÷÷" #
Add
÷÷# &
(
÷÷& '
$"
÷÷' )
$str
÷÷) <
"
÷÷< =
)
÷÷= >
;
÷÷> ? 
columnasverdeclaro
◊◊ "
.
◊◊" #
Add
◊◊# &
(
◊◊& '
$"
◊◊' )
$str
◊◊) 6
"
◊◊6 7
)
◊◊7 8
;
◊◊8 9 
columnasverdeclaro
ÿÿ "
.
ÿÿ" #
Add
ÿÿ# &
(
ÿÿ& '
$"
ÿÿ' )
$str
ÿÿ) 5
"
ÿÿ5 6
)
ÿÿ6 7
;
ÿÿ7 8 
columnasverdeclaro
ŸŸ "
.
ŸŸ" #
Add
ŸŸ# &
(
ŸŸ& '
$"
ŸŸ' )
$str
ŸŸ) 6
"
ŸŸ6 7
)
ŸŸ7 8
;
ŸŸ8 9
List
€€ 
<
€€ 
string
€€ 
>
€€ !
columnasverdeoscuro
€€ 0
=
€€1 2
new
€€3 6
List
€€7 ;
<
€€; <
string
€€< B
>
€€B C
(
€€C D
)
€€D E
;
€€E F!
columnasverdeoscuro
›› #
.
››# $
Add
››$ '
(
››' (
$"
››( *
$str
››* 4
"
››4 5
)
››5 6
;
››6 7!
columnasverdeoscuro
ﬁﬁ #
.
ﬁﬁ# $
Add
ﬁﬁ$ '
(
ﬁﬁ' (
$"
ﬁﬁ( *
$str
ﬁﬁ* 9
"
ﬁﬁ9 :
)
ﬁﬁ: ;
;
ﬁﬁ; <
foreach
„„ 
(
„„ 

DataColumn
„„ #
column
„„$ *
in
„„+ -
table
„„. 3
.
„„3 4
Columns
„„4 ;
)
„„; <
{
‰‰ 
columns
ÂÂ 
.
ÂÂ 
Add
ÂÂ 
(
ÂÂ  
column
ÂÂ  &
.
ÂÂ& '

ColumnName
ÂÂ' 1
)
ÂÂ1 2
;
ÂÂ2 3
DocumentFormat
ÁÁ "
.
ÁÁ" #
OpenXml
ÁÁ# *
.
ÁÁ* +
Spreadsheet
ÁÁ+ 6
.
ÁÁ6 7
Cell
ÁÁ7 ;
newcell
ÁÁ< C
=
ÁÁD E
new
ÁÁF I
DocumentFormat
ÁÁJ X
.
ÁÁX Y
OpenXml
ÁÁY `
.
ÁÁ` a
Spreadsheet
ÁÁa l
.
ÁÁl m
Cell
ÁÁm q
(
ÁÁq r
)
ÁÁr s
;
ÁÁs t
newcell
ÈÈ 
.
ÈÈ 
DataType
ÈÈ $
=
ÈÈ% &
DocumentFormat
ÈÈ' 5
.
ÈÈ5 6
OpenXml
ÈÈ6 =
.
ÈÈ= >
Spreadsheet
ÈÈ> I
.
ÈÈI J

CellValues
ÈÈJ T
.
ÈÈT U
InlineString
ÈÈU a
;
ÈÈa b
if
ÍÍ 
(
ÍÍ 
column
ÍÍ 
.
ÍÍ 

ColumnName
ÍÍ )
.
ÍÍ) *
Contains
ÍÍ* 2
(
ÍÍ2 3
$str
ÍÍ3 <
)
ÍÍ< =
)
ÍÍ= >
{
ÍÍ? @
newcell
ÎÎ 
.
ÎÎ  
	CellValue
ÎÎ  )
=
ÎÎ* +
new
ÎÎ, /
DocumentFormat
ÎÎ0 >
.
ÎÎ> ?
OpenXml
ÎÎ? F
.
ÎÎF G
Spreadsheet
ÎÎG R
.
ÎÎR S
	CellValue
ÎÎS \
(
ÎÎ\ ]
$str
ÎÎ] _
)
ÎÎ_ `
;
ÎÎ` a
newcell
ÏÏ 
.
ÏÏ  

StyleIndex
ÏÏ  *
=
ÏÏ+ ,
$num
ÏÏ- .
;
ÏÏ. /
}
ÌÌ 
else
ÓÓ 
{
ÔÔ 
string
 
columnexcel
 *
=
+ ,
column
- 3
.
3 4

ColumnName
4 >
.
> ?
Replace
? F
(
F G
$str
G K
,
K L
$str
M O
)
O P
;
P Q
columnexcel
ÚÚ #
=
ÚÚ$ %
columnexcel
ÚÚ& 1
.
ÚÚ1 2
Replace
ÚÚ2 9
(
ÚÚ9 :
$str
ÚÚ: =
,
ÚÚ= >
$str
ÚÚ? C
)
ÚÚC D
;
ÚÚD E
newcell
ÙÙ 
.
ÙÙ  
	CellValue
ÙÙ  )
=
ÙÙ* +
new
ÙÙ, /
DocumentFormat
ÙÙ0 >
.
ÙÙ> ?
OpenXml
ÙÙ? F
.
ÙÙF G
Spreadsheet
ÙÙG R
.
ÙÙR S
	CellValue
ÙÙS \
(
ÙÙ\ ]
columnexcel
ÙÙ] h
)
ÙÙh i
;
ÙÙi j
newcell
ıı 
.
ıı  
InlineString
ıı  ,
=
ıı- .
new
ıı/ 2
InlineString
ıı3 ?
(
ıı? @
)
ıı@ A
{
ııB C
Text
ııD H
=
ııI J
new
ııK N
Text
ııO S
(
ııS T
)
ııT U
{
ııV W
Text
ııX \
=
ıı] ^
columnexcel
ıı_ j
}
ıık l
}
ıım n
;
ıın o
if
˘˘ 
(
˘˘ 
columnascelestes
˘˘ ,
.
˘˘, -
Contains
˘˘- 5
(
˘˘5 6
column
˘˘6 <
.
˘˘< =

ColumnName
˘˘= G
)
˘˘G H
)
˘˘H I
{
˙˙ 
newcell
˚˚ #
.
˚˚# $

StyleIndex
˚˚$ .
=
˚˚/ 0
$num
˚˚1 2
;
˚˚2 3
}
¸¸ 
else
˝˝ 
{
˛˛ 
if
ˇˇ 
(
ˇˇ  
columnasamarillas
ˇˇ  1
.
ˇˇ1 2
Contains
ˇˇ2 :
(
ˇˇ: ;
column
ˇˇ; A
.
ˇˇA B

ColumnName
ˇˇB L
)
ˇˇL M
)
ˇˇM N
{
ÄÄ 
newcell
ÅÅ  '
.
ÅÅ' (

StyleIndex
ÅÅ( 2
=
ÅÅ3 4
$num
ÅÅ5 6
;
ÅÅ6 7
}
ÇÇ 
else
ÉÉ  
{
ÑÑ 
if
ÖÖ  "
(
ÖÖ# $ 
columnasverdeclaro
ÖÖ$ 6
.
ÖÖ6 7
Contains
ÖÖ7 ?
(
ÖÖ? @
column
ÖÖ@ F
.
ÖÖF G

ColumnName
ÖÖG Q
)
ÖÖQ R
)
ÖÖR S
{
ÜÜ  !
newcell
áá& -
.
áá- .

StyleIndex
áá. 8
=
áá9 :
$num
áá; <
;
áá< =
}
àà  !
else
ââ  $
{
ââ% &
if
ää$ &
(
ää' (!
columnasverdeoscuro
ää( ;
.
ää; <
Contains
ää< D
(
ääD E
column
ääE K
.
ääK L

ColumnName
ääL V
)
ääV W
)
ääW X
{
ãã$ %
newcell
åå* 1
.
åå1 2

StyleIndex
åå2 <
=
åå= >
$num
åå? A
;
ååA B
}
çç$ %
else
éé$ (
{
èè$ %
newcell
êê* 1
.
êê1 2

StyleIndex
êê2 <
=
êê= >
$num
êê? @
;
êê@ A
}
ëë$ %
}
íí  !
}
ìì 
}
îî 
}
ïï 
	headerRow
òò 
.
òò 
AppendChild
òò )
(
òò) *
newcell
òò* 1
)
òò1 2
;
òò2 3
}
ôô 
	sheetData
õõ 
.
õõ 
AppendChild
õõ %
(
õõ% &
	headerRow
õõ& /
)
õõ/ 0
;
õõ0 1
foreach
ùù 
(
ùù 
DataRow
ùù  
dsrow
ùù! &
in
ùù' )
table
ùù* /
.
ùù/ 0
Rows
ùù0 4
)
ùù4 5
{
ûû 
DocumentFormat
üü "
.
üü" #
OpenXml
üü# *
.
üü* +
Spreadsheet
üü+ 6
.
üü6 7
Row
üü7 :
newRow
üü; A
=
üüB C
new
üüD G
DocumentFormat
üüH V
.
üüV W
OpenXml
üüW ^
.
üü^ _
Spreadsheet
üü_ j
.
üüj k
Row
üük n
(
üün o
)
üüo p
;
üüp q
foreach
†† 
(
†† 
String
†† #
col
††$ '
in
††( *
columns
††+ 2
)
††2 3
{
°° 
DocumentFormat
¢¢ &
.
¢¢& '
OpenXml
¢¢' .
.
¢¢. /
Spreadsheet
¢¢/ :
.
¢¢: ;
Cell
¢¢; ?
cell
¢¢@ D
=
¢¢E F
new
¢¢G J
DocumentFormat
¢¢K Y
.
¢¢Y Z
OpenXml
¢¢Z a
.
¢¢a b
Spreadsheet
¢¢b m
.
¢¢m n
Cell
¢¢n r
(
¢¢r s
)
¢¢s t
;
¢¢t u
if
•• 
(
•• 
col
•• 
.
••  
Contains
••  (
(
••( )
$str
••) 2
)
••2 3
)
••3 4
{
¶¶ 
cell
ßß  
.
ßß  !
DataType
ßß! )
=
ßß* +
DocumentFormat
ßß, :
.
ßß: ;
OpenXml
ßß; B
.
ßßB C
Spreadsheet
ßßC N
.
ßßN O

CellValues
ßßO Y
.
ßßY Z
String
ßßZ `
;
ßß` a
cell
®®  
.
®®  !
	CellValue
®®! *
=
®®+ ,
new
®®- 0
DocumentFormat
®®1 ?
.
®®? @
OpenXml
®®@ G
.
®®G H
Spreadsheet
®®H S
.
®®S T
	CellValue
®®T ]
(
®®] ^
$str
®®^ `
)
®®` a
;
®®a b
cell
©©  
.
©©  !

StyleIndex
©©! +
=
©©, -
$num
©©. /
;
©©/ 0
}
´´ 
else
¨¨ 
{
≠≠ 
if
ÆÆ 
(
ÆÆ  
columnasstring
ÆÆ  .
.
ÆÆ. /
Contains
ÆÆ/ 7
(
ÆÆ7 8
col
ÆÆ8 ;
)
ÆÆ; <
)
ÆÆ< =
{
ØØ 
cell
±±  $
.
±±$ %

StyleIndex
±±% /
=
±±0 1
$num
±±2 3
;
±±3 4
cell
≤≤  $
.
≤≤$ %
DataType
≤≤% -
=
≤≤. /
DocumentFormat
≤≤0 >
.
≤≤> ?
OpenXml
≤≤? F
.
≤≤F G
Spreadsheet
≤≤G R
.
≤≤R S

CellValues
≤≤S ]
.
≤≤] ^
String
≤≤^ d
;
≤≤d e
cell
≥≥  $
.
≥≥$ %
	CellValue
≥≥% .
=
≥≥/ 0
new
≥≥1 4
DocumentFormat
≥≥5 C
.
≥≥C D
OpenXml
≥≥D K
.
≥≥K L
Spreadsheet
≥≥L W
.
≥≥W X
	CellValue
≥≥X a
(
≥≥a b
dsrow
≥≥b g
[
≥≥g h
col
≥≥h k
]
≥≥k l
.
≥≥l m
ToString
≥≥m u
(
≥≥u v
)
≥≥v w
)
≥≥w x
;
≥≥x y
}
¥¥ 
else
µµ  
{
∂∂ 
if
∏∏  "
(
∏∏# $
col
∏∏$ '
.
∏∏' (
Contains
∏∏( 0
(
∏∏0 1
$str
∏∏1 C
)
∏∏C D
)
∏∏D E
{
ππ  !
DateTime
∫∫$ ,
celdadt
∫∫- 4
=
∫∫5 6
DateTime
∫∫7 ?
.
∫∫? @
Parse
∫∫@ E
(
∫∫E F
dsrow
∫∫F K
[
∫∫K L
col
∫∫L O
]
∫∫O P
.
∫∫P Q
ToString
∫∫Q Y
(
∫∫Y Z
)
∫∫Z [
)
∫∫[ \
;
∫∫\ ]
string
ªª$ *
valueString
ªª+ 6
=
ªª7 8
celdadt
ªª9 @
.
ªª@ A
ToOADate
ªªA I
(
ªªI J
)
ªªJ K
.
ªªK L
ToString
ªªL T
(
ªªT U
)
ªªU V
;
ªªV W
	CellValue
ºº$ -
	cellValue
ºº. 7
=
ºº8 9
new
ºº: =
	CellValue
ºº> G
(
ººG H
valueString
ººH S
)
ººS T
;
ººT U
cell
ΩΩ$ (
.
ΩΩ( )
DataType
ΩΩ) 1
=
ΩΩ2 3
new
ΩΩ4 7
	EnumValue
ΩΩ8 A
<
ΩΩA B

CellValues
ΩΩB L
>
ΩΩL M
(
ΩΩM N

CellValues
ΩΩN X
.
ΩΩX Y
Number
ΩΩY _
)
ΩΩ_ `
;
ΩΩ` a
cell
ææ$ (
.
ææ( )

StyleIndex
ææ) 3
=
ææ4 5
$num
ææ6 7
;
ææ7 8
cell
øø$ (
.
øø( )
Append
øø) /
(
øø/ 0
	cellValue
øø0 9
)
øø9 :
;
øø: ;
}
¿¿  !
else
¡¡  $
{
¡¡% &
cell
√√$ (
.
√√( )
DataType
√√) 1
=
√√2 3
DocumentFormat
√√4 B
.
√√B C
OpenXml
√√C J
.
√√J K
Spreadsheet
√√K V
.
√√V W

CellValues
√√W a
.
√√a b
Number
√√b h
;
√√h i
cell
ƒƒ$ (
.
ƒƒ( )
	CellValue
ƒƒ) 2
=
ƒƒ3 4
new
ƒƒ5 8
DocumentFormat
ƒƒ9 G
.
ƒƒG H
OpenXml
ƒƒH O
.
ƒƒO P
Spreadsheet
ƒƒP [
.
ƒƒ[ \
	CellValue
ƒƒ\ e
(
ƒƒe f
dsrow
ƒƒf k
[
ƒƒk l
col
ƒƒl o
]
ƒƒo p
.
ƒƒp q
ToString
ƒƒq y
(
ƒƒy z
)
ƒƒz {
)
ƒƒ{ |
;
ƒƒ| }
cell
≈≈$ (
.
≈≈( )

StyleIndex
≈≈) 3
=
≈≈4 5
$num
≈≈6 7
;
≈≈7 8
}
∆∆  !
}
«« 
}
»» 
newRow
ÃÃ 
.
ÃÃ 
AppendChild
ÃÃ *
(
ÃÃ* +
cell
ÃÃ+ /
)
ÃÃ/ 0
;
ÃÃ0 1
}
ÕÕ 
	sheetData
ŒŒ 
.
ŒŒ 
AppendChild
ŒŒ )
(
ŒŒ) *
newRow
ŒŒ* 0
)
ŒŒ0 1
;
ŒŒ1 2
}
œœ 
wsPart
”” 
.
”” 
	Worksheet
””  
.
””  !
Save
””! %
(
””% &
)
””& '
;
””' (
var
◊◊ 
sheets
◊◊ 
=
◊◊ 
spreadsheet
◊◊ (
.
◊◊( )
WorkbookPart
◊◊) 5
.
◊◊5 6
Workbook
◊◊6 >
.
◊◊> ?
AppendChild
◊◊? J
(
◊◊J K
new
◊◊K N
Sheets
◊◊O U
(
◊◊U V
)
◊◊V W
)
◊◊W X
;
◊◊X Y
sheets
ÿÿ 
.
ÿÿ 
AppendChild
ÿÿ "
(
ÿÿ" #
new
ÿÿ# &
Sheet
ÿÿ' ,
(
ÿÿ, -
)
ÿÿ- .
{
ÿÿ/ 0
Id
ÿÿ1 3
=
ÿÿ4 5
spreadsheet
ÿÿ6 A
.
ÿÿA B
WorkbookPart
ÿÿB N
.
ÿÿN O
GetIdOfPart
ÿÿO Z
(
ÿÿZ [
wsPart
ÿÿ[ a
)
ÿÿa b
,
ÿÿb c
SheetId
ÿÿd k
=
ÿÿl m
$num
ÿÿn o
,
ÿÿo p
Name
ÿÿq u
=
ÿÿv w
$strÿÿx ç
}ÿÿé è
)ÿÿè ê
;ÿÿê ë
spreadsheet
⁄⁄ 
.
⁄⁄ 
WorkbookPart
⁄⁄ (
.
⁄⁄( )
Workbook
⁄⁄) 1
.
⁄⁄1 2
Save
⁄⁄2 6
(
⁄⁄6 7
)
⁄⁄7 8
;
⁄⁄8 9
}
‹‹ 
}
›› 	
public
ﬂﬂ 
static
ﬂﬂ 
void
ﬂﬂ  
StructureSalaryXLS
ﬂﬂ -
(
ﬂﬂ- .
	DataTable
ﬂﬂ. 7
table
ﬂﬂ8 =
,
ﬂﬂ= >
string
ﬂﬂ? E
destination
ﬂﬂF Q
)
ﬂﬂQ R
{
‡‡ 	
using
·· 
(
·· 
var
·· 
spreadsheet
·· "
=
··# $!
SpreadsheetDocument
··% 8
.
··8 9
Create
··9 ?
(
··? @
destination
··@ K
,
··K L%
SpreadsheetDocumentType
··M d
.
··d e
Workbook
··e m
)
··m n
)
··n o
{
‚‚ 
spreadsheet
„„ 
.
„„ 
AddWorkbookPart
„„ +
(
„„+ ,
)
„„, -
;
„„- .
spreadsheet
‰‰ 
.
‰‰ 
WorkbookPart
‰‰ (
.
‰‰( )
Workbook
‰‰) 1
=
‰‰2 3
new
‰‰4 7
Workbook
‰‰8 @
(
‰‰@ A
)
‰‰A B
;
‰‰B C
var
ÂÂ 
wsPart
ÂÂ 
=
ÂÂ 
spreadsheet
ÂÂ (
.
ÂÂ( )
WorkbookPart
ÂÂ) 5
.
ÂÂ5 6

AddNewPart
ÂÂ6 @
<
ÂÂ@ A
WorksheetPart
ÂÂA N
>
ÂÂN O
(
ÂÂO P
)
ÂÂP Q
;
ÂÂQ R
wsPart
ÊÊ 
.
ÊÊ 
	Worksheet
ÊÊ  
=
ÊÊ! "
new
ÊÊ# &
	Worksheet
ÊÊ' 0
(
ÊÊ0 1
)
ÊÊ1 2
;
ÊÊ2 3
var
ËË 

stylesPart
ËË 
=
ËË  
spreadsheet
ËË! ,
.
ËË, -
WorkbookPart
ËË- 9
.
ËË9 :

AddNewPart
ËË: D
<
ËËD E 
WorkbookStylesPart
ËËE W
>
ËËW X
(
ËËX Y
)
ËËY Z
;
ËËZ [

stylesPart
ÈÈ 
.
ÈÈ 

Stylesheet
ÈÈ %
=
ÈÈ& '
new
ÈÈ( +

Stylesheet
ÈÈ, 6
(
ÈÈ6 7
)
ÈÈ7 8
;
ÈÈ8 9
Font
ÏÏ 
font
ÏÏ 
=
ÏÏ 
new
ÏÏ 
Font
ÏÏ  $
(
ÏÏ$ %
)
ÏÏ% &
;
ÏÏ& '
font
ÌÌ 
.
ÌÌ 
Append
ÌÌ 
(
ÌÌ 
new
ÌÌ 
Color
ÌÌ  %
(
ÌÌ% &
)
ÌÌ& '
{
ÌÌ( )
Rgb
ÌÌ* -
=
ÌÌ. /
$str
ÌÌ0 8
}
ÌÌ9 :
)
ÌÌ: ;
;
ÌÌ; <
font
ÓÓ 
.
ÓÓ 
Append
ÓÓ 
(
ÓÓ 
new
ÓÓ 
Bold
ÓÓ  $
(
ÓÓ$ %
)
ÓÓ% &
)
ÓÓ& '
;
ÓÓ' (

stylesPart
ÒÒ 
.
ÒÒ 

Stylesheet
ÒÒ %
.
ÒÒ% &
Fonts
ÒÒ& +
=
ÒÒ, -
new
ÒÒ. 1
Fonts
ÒÒ2 7
(
ÒÒ7 8
)
ÒÒ8 9
;
ÒÒ9 :

stylesPart
ÚÚ 
.
ÚÚ 

Stylesheet
ÚÚ %
.
ÚÚ% &
Fonts
ÚÚ& +
.
ÚÚ+ ,
AppendChild
ÚÚ, 7
(
ÚÚ7 8
font
ÚÚ8 <
)
ÚÚ< =
;
ÚÚ= >

stylesPart
ÛÛ 
.
ÛÛ 

Stylesheet
ÛÛ %
.
ÛÛ% &
Fonts
ÛÛ& +
.
ÛÛ+ ,
AppendChild
ÛÛ, 7
(
ÛÛ7 8
new
ÛÛ8 ;
Font
ÛÛ< @
{
ÛÛA B
Color
ÛÛC H
=
ÛÛI J
new
ÛÛK N
Color
ÛÛO T
(
ÛÛT U
)
ÛÛU V
{
ÛÛW X
Rgb
ÛÛY \
=
ÛÛ] ^
$str
ÛÛ_ g
}
ÛÛh i
}
ÛÛj k
)
ÛÛk l
;
ÛÛl m

stylesPart
ÙÙ 
.
ÙÙ 

Stylesheet
ÙÙ %
.
ÙÙ% &
Fonts
ÙÙ& +
.
ÙÙ+ ,
AppendChild
ÙÙ, 7
(
ÙÙ7 8
new
ÙÙ8 ;
Font
ÙÙ< @
{
ÙÙA B
Color
ÙÙC H
=
ÙÙI J
new
ÙÙK N
Color
ÙÙO T
(
ÙÙT U
)
ÙÙU V
{
ÙÙW X
Rgb
ÙÙY \
=
ÙÙ] ^
$str
ÙÙ_ g
}
ÙÙh i
,
ÙÙi j
Bold
ÙÙk o
=
ÙÙp q
new
ÙÙr u
Bold
ÙÙv z
(
ÙÙz {
)
ÙÙ{ |
}
ÙÙ} ~
)
ÙÙ~ 
;ÙÙ Ä

stylesPart
ıı 
.
ıı 

Stylesheet
ıı %
.
ıı% &
Fonts
ıı& +
.
ıı+ ,
AppendChild
ıı, 7
(
ıı7 8
new
ıı8 ;
Font
ıı< @
{
ııA B
Color
ııC H
=
ııI J
new
ııK N
Color
ııO T
(
ııT U
)
ııU V
{
ııW X
Rgb
ııY \
=
ıı] ^
$str
ıı_ g
}
ııh i
,
ııi j
Bold
ıık o
=
ııp q
new
ıır u
Bold
ııv z
(
ıız {
)
ıı{ |
}
ıı} ~
)
ıı~ 
;ıı Ä

stylesPart
ˆˆ 
.
ˆˆ 

Stylesheet
ˆˆ %
.
ˆˆ% &
Fonts
ˆˆ& +
.
ˆˆ+ ,
Count
ˆˆ, 1
=
ˆˆ2 3
$num
ˆˆ4 5
;
ˆˆ5 6

stylesPart
˘˘ 
.
˘˘ 

Stylesheet
˘˘ %
.
˘˘% &
Fills
˘˘& +
=
˘˘, -
new
˘˘. 1
Fills
˘˘2 7
(
˘˘7 8
)
˘˘8 9
;
˘˘9 :
var
¸¸ 
solidRed
¸¸ 
=
¸¸ 
new
¸¸ "
PatternFill
¸¸# .
(
¸¸. /
)
¸¸/ 0
{
¸¸1 2
PatternType
¸¸3 >
=
¸¸? @
PatternValues
¸¸A N
.
¸¸N O
Solid
¸¸O T
}
¸¸U V
;
¸¸V W
solidRed
˝˝ 
.
˝˝ 
ForegroundColor
˝˝ (
=
˝˝) *
new
˝˝+ .
ForegroundColor
˝˝/ >
{
˝˝? @
Rgb
˝˝A D
=
˝˝E F
HexBinaryValue
˝˝G U
.
˝˝U V

FromString
˝˝V `
(
˝˝` a
$str
˝˝a i
)
˝˝i j
}
˝˝k l
;
˝˝l m
solidRed
˛˛ 
.
˛˛ 
BackgroundColor
˛˛ (
=
˛˛) *
new
˛˛+ .
BackgroundColor
˛˛/ >
{
˛˛? @
Indexed
˛˛A H
=
˛˛I J
$num
˛˛K M
}
˛˛N O
;
˛˛O P
var
Ä	Ä	 
solidCeleste
Ä	Ä	  
=
Ä	Ä	! "
new
Ä	Ä	# &
PatternFill
Ä	Ä	' 2
(
Ä	Ä	2 3
)
Ä	Ä	3 4
{
Ä	Ä	5 6
PatternType
Ä	Ä	7 B
=
Ä	Ä	C D
PatternValues
Ä	Ä	E R
.
Ä	Ä	R S
Solid
Ä	Ä	S X
}
Ä	Ä	Y Z
;
Ä	Ä	Z [
solidCeleste
Å	Å	 
.
Å	Å	 
ForegroundColor
Å	Å	 ,
=
Å	Å	- .
new
Å	Å	/ 2
ForegroundColor
Å	Å	3 B
{
Å	Å	C D
Rgb
Å	Å	E H
=
Å	Å	I J
HexBinaryValue
Å	Å	K Y
.
Å	Å	Y Z

FromString
Å	Å	Z d
(
Å	Å	d e
$str
Å	Å	e m
)
Å	Å	m n
}
Å	Å	o p
;
Å	Å	p q
solidCeleste
Ç	Ç	 
.
Ç	Ç	 
BackgroundColor
Ç	Ç	 ,
=
Ç	Ç	- .
new
Ç	Ç	/ 2
BackgroundColor
Ç	Ç	3 B
{
Ç	Ç	C D
Indexed
Ç	Ç	E L
=
Ç	Ç	M N
$num
Ç	Ç	O Q
}
Ç	Ç	R S
;
Ç	Ç	S T
var
Ñ	Ñ	 
fondo_semaforo_01
Ñ	Ñ	 %
=
Ñ	Ñ	& '
new
Ñ	Ñ	( +
PatternFill
Ñ	Ñ	, 7
(
Ñ	Ñ	7 8
)
Ñ	Ñ	8 9
{
Ñ	Ñ	: ;
PatternType
Ñ	Ñ	< G
=
Ñ	Ñ	H I
PatternValues
Ñ	Ñ	J W
.
Ñ	Ñ	W X
Solid
Ñ	Ñ	X ]
}
Ñ	Ñ	^ _
;
Ñ	Ñ	_ `
fondo_semaforo_01
Ö	Ö	 !
.
Ö	Ö	! "
ForegroundColor
Ö	Ö	" 1
=
Ö	Ö	2 3
new
Ö	Ö	4 7
ForegroundColor
Ö	Ö	8 G
{
Ö	Ö	H I
Rgb
Ö	Ö	J M
=
Ö	Ö	N O
HexBinaryValue
Ö	Ö	P ^
.
Ö	Ö	^ _

FromString
Ö	Ö	_ i
(
Ö	Ö	i j
$str
Ö	Ö	j r
)
Ö	Ö	r s
}
Ö	Ö	t u
;
Ö	Ö	u v
fondo_semaforo_01
Ü	Ü	 !
.
Ü	Ü	! "
BackgroundColor
Ü	Ü	" 1
=
Ü	Ü	2 3
new
Ü	Ü	4 7
BackgroundColor
Ü	Ü	8 G
{
Ü	Ü	H I
Indexed
Ü	Ü	J Q
=
Ü	Ü	R S
$num
Ü	Ü	T V
}
Ü	Ü	W X
;
Ü	Ü	X Y
var
à	à	 
fondo_semaforo_02
à	à	 %
=
à	à	& '
new
à	à	( +
PatternFill
à	à	, 7
(
à	à	7 8
)
à	à	8 9
{
à	à	: ;
PatternType
à	à	< G
=
à	à	H I
PatternValues
à	à	J W
.
à	à	W X
Solid
à	à	X ]
}
à	à	^ _
;
à	à	_ `
fondo_semaforo_02
â	â	 !
.
â	â	! "
ForegroundColor
â	â	" 1
=
â	â	2 3
new
â	â	4 7
ForegroundColor
â	â	8 G
{
â	â	H I
Rgb
â	â	J M
=
â	â	N O
HexBinaryValue
â	â	P ^
.
â	â	^ _

FromString
â	â	_ i
(
â	â	i j
$str
â	â	j r
)
â	â	r s
}
â	â	t u
;
â	â	u v
fondo_semaforo_02
ä	ä	 !
.
ä	ä	! "
BackgroundColor
ä	ä	" 1
=
ä	ä	2 3
new
ä	ä	4 7
BackgroundColor
ä	ä	8 G
{
ä	ä	H I
Indexed
ä	ä	J Q
=
ä	ä	R S
$num
ä	ä	T V
}
ä	ä	W X
;
ä	ä	X Y
var
å	å	 
fondo_semaforo_03
å	å	 %
=
å	å	& '
new
å	å	( +
PatternFill
å	å	, 7
(
å	å	7 8
)
å	å	8 9
{
å	å	: ;
PatternType
å	å	< G
=
å	å	H I
PatternValues
å	å	J W
.
å	å	W X
Solid
å	å	X ]
}
å	å	^ _
;
å	å	_ `
fondo_semaforo_03
ç	ç	 !
.
ç	ç	! "
ForegroundColor
ç	ç	" 1
=
ç	ç	2 3
new
ç	ç	4 7
ForegroundColor
ç	ç	8 G
{
ç	ç	H I
Rgb
ç	ç	J M
=
ç	ç	N O
HexBinaryValue
ç	ç	P ^
.
ç	ç	^ _

FromString
ç	ç	_ i
(
ç	ç	i j
$str
ç	ç	j r
)
ç	ç	r s
}
ç	ç	t u
;
ç	ç	u v
fondo_semaforo_03
é	é	 !
.
é	é	! "
BackgroundColor
é	é	" 1
=
é	é	2 3
new
é	é	4 7
BackgroundColor
é	é	8 G
{
é	é	H I
Indexed
é	é	J Q
=
é	é	R S
$num
é	é	T V
}
é	é	W X
;
é	é	X Y
var
ê	ê	 
fondo_semaforo_04
ê	ê	 %
=
ê	ê	& '
new
ê	ê	( +
PatternFill
ê	ê	, 7
(
ê	ê	7 8
)
ê	ê	8 9
{
ê	ê	: ;
PatternType
ê	ê	< G
=
ê	ê	H I
PatternValues
ê	ê	J W
.
ê	ê	W X
Solid
ê	ê	X ]
}
ê	ê	^ _
;
ê	ê	_ `
fondo_semaforo_04
ë	ë	 !
.
ë	ë	! "
ForegroundColor
ë	ë	" 1
=
ë	ë	2 3
new
ë	ë	4 7
ForegroundColor
ë	ë	8 G
{
ë	ë	H I
Rgb
ë	ë	J M
=
ë	ë	N O
HexBinaryValue
ë	ë	P ^
.
ë	ë	^ _

FromString
ë	ë	_ i
(
ë	ë	i j
$str
ë	ë	j r
)
ë	ë	r s
}
ë	ë	t u
;
ë	ë	u v
fondo_semaforo_04
í	í	 !
.
í	í	! "
BackgroundColor
í	í	" 1
=
í	í	2 3
new
í	í	4 7
BackgroundColor
í	í	8 G
{
í	í	H I
Indexed
í	í	J Q
=
í	í	R S
$num
í	í	T V
}
í	í	W X
;
í	í	X Y
var
ï	ï	 
fondo_semaforo_05
ï	ï	 %
=
ï	ï	& '
new
ï	ï	( +
PatternFill
ï	ï	, 7
(
ï	ï	7 8
)
ï	ï	8 9
{
ï	ï	: ;
PatternType
ï	ï	< G
=
ï	ï	H I
PatternValues
ï	ï	J W
.
ï	ï	W X
Solid
ï	ï	X ]
}
ï	ï	^ _
;
ï	ï	_ `
fondo_semaforo_05
ñ	ñ	 !
.
ñ	ñ	! "
ForegroundColor
ñ	ñ	" 1
=
ñ	ñ	2 3
new
ñ	ñ	4 7
ForegroundColor
ñ	ñ	8 G
{
ñ	ñ	H I
Rgb
ñ	ñ	J M
=
ñ	ñ	N O
HexBinaryValue
ñ	ñ	P ^
.
ñ	ñ	^ _

FromString
ñ	ñ	_ i
(
ñ	ñ	i j
$str
ñ	ñ	j r
)
ñ	ñ	r s
}
ñ	ñ	t u
;
ñ	ñ	u v
fondo_semaforo_05
ó	ó	 !
.
ó	ó	! "
BackgroundColor
ó	ó	" 1
=
ó	ó	2 3
new
ó	ó	4 7
BackgroundColor
ó	ó	8 G
{
ó	ó	H I
Indexed
ó	ó	J Q
=
ó	ó	R S
$num
ó	ó	T V
}
ó	ó	W X
;
ó	ó	X Y

stylesPart
ô	ô	 
.
ô	ô	 

Stylesheet
ô	ô	 %
.
ô	ô	% &
Fills
ô	ô	& +
.
ô	ô	+ ,
AppendChild
ô	ô	, 7
(
ô	ô	7 8
new
ô	ô	8 ;
Fill
ô	ô	< @
{
ô	ô	A B
PatternFill
ô	ô	C N
=
ô	ô	O P
new
ô	ô	Q T
PatternFill
ô	ô	U `
{
ô	ô	a b
PatternType
ô	ô	c n
=
ô	ô	o p
PatternValues
ô	ô	q ~
.
ô	ô	~ 
Noneô	ô	 É
}ô	ô	Ñ Ö
}ô	ô	Ü á
)ô	ô	á à
;ô	ô	à â

stylesPart
ö	ö	 
.
ö	ö	 

Stylesheet
ö	ö	 %
.
ö	ö	% &
Fills
ö	ö	& +
.
ö	ö	+ ,
AppendChild
ö	ö	, 7
(
ö	ö	7 8
new
ö	ö	8 ;
Fill
ö	ö	< @
{
ö	ö	A B
PatternFill
ö	ö	C N
=
ö	ö	O P
new
ö	ö	Q T
PatternFill
ö	ö	U `
{
ö	ö	a b
PatternType
ö	ö	c n
=
ö	ö	o p
PatternValues
ö	ö	q ~
.
ö	ö	~ 
Gray125ö	ö	 Ü
}ö	ö	á à
}ö	ö	â ä
)ö	ö	ä ã
;ö	ö	ã å

stylesPart
õ	õ	 
.
õ	õ	 

Stylesheet
õ	õ	 %
.
õ	õ	% &
Fills
õ	õ	& +
.
õ	õ	+ ,
AppendChild
õ	õ	, 7
(
õ	õ	7 8
new
õ	õ	8 ;
Fill
õ	õ	< @
{
õ	õ	A B
PatternFill
õ	õ	C N
=
õ	õ	O P
solidRed
õ	õ	Q Y
}
õ	õ	Z [
)
õ	õ	[ \
;
õ	õ	\ ]

stylesPart
ú	ú	 
.
ú	ú	 

Stylesheet
ú	ú	 %
.
ú	ú	% &
Fills
ú	ú	& +
.
ú	ú	+ ,
AppendChild
ú	ú	, 7
(
ú	ú	7 8
new
ú	ú	8 ;
Fill
ú	ú	< @
{
ú	ú	A B
PatternFill
ú	ú	C N
=
ú	ú	O P
solidCeleste
ú	ú	Q ]
}
ú	ú	^ _
)
ú	ú	_ `
;
ú	ú	` a

stylesPart
û	û	 
.
û	û	 

Stylesheet
û	û	 %
.
û	û	% &
Fills
û	û	& +
.
û	û	+ ,
AppendChild
û	û	, 7
(
û	û	7 8
new
û	û	8 ;
Fill
û	û	< @
{
û	û	A B
PatternFill
û	û	C N
=
û	û	O P
fondo_semaforo_01
û	û	Q b
}
û	û	c d
)
û	û	d e
;
û	û	e f

stylesPart
ü	ü	 
.
ü	ü	 

Stylesheet
ü	ü	 %
.
ü	ü	% &
Fills
ü	ü	& +
.
ü	ü	+ ,
AppendChild
ü	ü	, 7
(
ü	ü	7 8
new
ü	ü	8 ;
Fill
ü	ü	< @
{
ü	ü	A B
PatternFill
ü	ü	C N
=
ü	ü	O P
fondo_semaforo_02
ü	ü	Q b
}
ü	ü	c d
)
ü	ü	d e
;
ü	ü	e f

stylesPart
†	†	 
.
†	†	 

Stylesheet
†	†	 %
.
†	†	% &
Fills
†	†	& +
.
†	†	+ ,
AppendChild
†	†	, 7
(
†	†	7 8
new
†	†	8 ;
Fill
†	†	< @
{
†	†	A B
PatternFill
†	†	C N
=
†	†	O P
fondo_semaforo_03
†	†	Q b
}
†	†	c d
)
†	†	d e
;
†	†	e f

stylesPart
°	°	 
.
°	°	 

Stylesheet
°	°	 %
.
°	°	% &
Fills
°	°	& +
.
°	°	+ ,
AppendChild
°	°	, 7
(
°	°	7 8
new
°	°	8 ;
Fill
°	°	< @
{
°	°	A B
PatternFill
°	°	C N
=
°	°	O P
fondo_semaforo_04
°	°	Q b
}
°	°	c d
)
°	°	d e
;
°	°	e f

stylesPart
¢	¢	 
.
¢	¢	 

Stylesheet
¢	¢	 %
.
¢	¢	% &
Fills
¢	¢	& +
.
¢	¢	+ ,
AppendChild
¢	¢	, 7
(
¢	¢	7 8
new
¢	¢	8 ;
Fill
¢	¢	< @
{
¢	¢	A B
PatternFill
¢	¢	C N
=
¢	¢	O P
fondo_semaforo_05
¢	¢	Q b
}
¢	¢	c d
)
¢	¢	d e
;
¢	¢	e f

stylesPart
•	•	 
.
•	•	 

Stylesheet
•	•	 %
.
•	•	% &
Fills
•	•	& +
.
•	•	+ ,
Count
•	•	, 1
=
•	•	2 3
$num
•	•	4 5
;
•	•	5 6

stylesPart
®	®	 
.
®	®	 

Stylesheet
®	®	 %
.
®	®	% &
Borders
®	®	& -
=
®	®	. /
new
®	®	0 3
Borders
®	®	4 ;
(
®	®	; <
)
®	®	< =
;
®	®	= >

stylesPart
©	©	 
.
©	©	 

Stylesheet
©	©	 %
.
©	©	% &
Borders
©	©	& -
.
©	©	- .
AppendChild
©	©	. 9
(
©	©	9 :
new
©	©	: =
Border
©	©	> D
(
©	©	D E
)
©	©	E F
)
©	©	F G
;
©	©	G H

stylesPart
™	™	 
.
™	™	 

Stylesheet
™	™	 %
.
™	™	% &
Borders
™	™	& -
.
™	™	- .
AppendChild
™	™	. 9
(
™	™	9 :
new
™	™	: =
Border
™	™	> D
(
™	™	D E
)
™	™	E F
{
´	´	 

LeftBorder
¨	¨	 
=
¨	¨	  
new
¨	¨	! $

LeftBorder
¨	¨	% /
(
¨	¨	/ 0
)
¨	¨	0 1
{
¨	¨	2 3
Style
¨	¨	4 9
=
¨	¨	: ;
BorderStyleValues
¨	¨	< M
.
¨	¨	M N
Thin
¨	¨	N R
}
¨	¨	S T
,
¨	¨	T U
RightBorder
≠	≠	 
=
≠	≠	  !
new
≠	≠	" %
RightBorder
≠	≠	& 1
(
≠	≠	1 2
)
≠	≠	2 3
{
≠	≠	4 5
Style
≠	≠	6 ;
=
≠	≠	< =
BorderStyleValues
≠	≠	> O
.
≠	≠	O P
Thin
≠	≠	P T
}
≠	≠	U V
,
Æ	Æ	 
BottomBorder
Ø	Ø	  
=
Ø	Ø	! "
new
Ø	Ø	# &
BottomBorder
Ø	Ø	' 3
(
Ø	Ø	3 4
)
Ø	Ø	4 5
{
Ø	Ø	6 7
Style
Ø	Ø	8 =
=
Ø	Ø	> ?
BorderStyleValues
Ø	Ø	@ Q
.
Ø	Ø	Q R
Thin
Ø	Ø	R V
}
Ø	Ø	W X
,
Ø	Ø	X Y
	TopBorder
∞	∞	 
=
∞	∞	 
new
∞	∞	  #
	TopBorder
∞	∞	$ -
(
∞	∞	- .
)
∞	∞	. /
{
∞	∞	0 1
Style
∞	∞	2 7
=
∞	∞	8 9
BorderStyleValues
∞	∞	: K
.
∞	∞	K L
Thin
∞	∞	L P
}
∞	∞	Q R
}
±	±	 
)
±	±	 
;
±	±	 

stylesPart
≤	≤	 
.
≤	≤	 

Stylesheet
≤	≤	 %
.
≤	≤	% &
Borders
≤	≤	& -
.
≤	≤	- .
Count
≤	≤	. 3
=
≤	≤	4 5
$num
≤	≤	6 7
;
≤	≤	7 8

stylesPart
µ	µ	 
.
µ	µ	 

Stylesheet
µ	µ	 %
.
µ	µ	% &
CellStyleFormats
µ	µ	& 6
=
µ	µ	7 8
new
µ	µ	9 <
CellStyleFormats
µ	µ	= M
(
µ	µ	M N
)
µ	µ	N O
;
µ	µ	O P

stylesPart
∂	∂	 
.
∂	∂	 

Stylesheet
∂	∂	 %
.
∂	∂	% &
CellStyleFormats
∂	∂	& 6
.
∂	∂	6 7
Count
∂	∂	7 <
=
∂	∂	= >
$num
∂	∂	? @
;
∂	∂	@ A

stylesPart
∑	∑	 
.
∑	∑	 

Stylesheet
∑	∑	 %
.
∑	∑	% &
CellStyleFormats
∑	∑	& 6
.
∑	∑	6 7
AppendChild
∑	∑	7 B
(
∑	∑	B C
new
∑	∑	C F

CellFormat
∑	∑	G Q
(
∑	∑	Q R
)
∑	∑	R S
)
∑	∑	S T
;
∑	∑	T U

stylesPart
∫	∫	 
.
∫	∫	 

Stylesheet
∫	∫	 %
.
∫	∫	% &
CellFormats
∫	∫	& 1
=
∫	∫	2 3
new
∫	∫	4 7
CellFormats
∫	∫	8 C
(
∫	∫	C D
)
∫	∫	D E
;
∫	∫	E F

stylesPart
ª	ª	 
.
ª	ª	 

Stylesheet
ª	ª	 %
.
ª	ª	% &
CellFormats
ª	ª	& 1
.
ª	ª	1 2
AppendChild
ª	ª	2 =
(
ª	ª	= >
new
ª	ª	> A

CellFormat
ª	ª	B L
(
ª	ª	L M
)
ª	ª	M N
)
ª	ª	N O
;
ª	ª	O P

stylesPart
º	º	 
.
º	º	 

Stylesheet
º	º	 %
.
º	º	% &
CellFormats
º	º	& 1
.
º	º	1 2
AppendChild
º	º	2 =
(
º	º	= >
new
º	º	> A

CellFormat
º	º	B L
{
º	º	M N
FormatId
º	º	O W
=
º	º	X Y
$num
º	º	Z [
,
º	º	[ \
FontId
º	º	] c
=
º	º	d e
$num
º	º	f g
,
º	º	g h
BorderId
º	º	i q
=
º	º	r s
$num
º	º	t u
,
º	º	u v
FillId
º	º	w }
=
º	º	~ 
$numº	º	Ä Å
,º	º	Å Ç
	ApplyFillº	º	É å
=º	º	ç é
trueº	º	è ì
}º	º	î ï
)º	º	ï ñ
.º	º	ñ ó
AppendChildº	º	ó ¢
(º	º	¢ £
newº	º	£ ¶
	Alignmentº	º	ß ∞
{º	º	± ≤

Horizontalº	º	≥ Ω
=º	º	æ ø)
HorizontalAlignmentValuesº	º	¿ Ÿ
.º	º	Ÿ ⁄
Centerº	º	⁄ ‡
}º	º	· ‚
)º	º	‚ „
;º	º	„ ‰

stylesPart
Ω	Ω	 
.
Ω	Ω	 

Stylesheet
Ω	Ω	 %
.
Ω	Ω	% &
CellFormats
Ω	Ω	& 1
.
Ω	Ω	1 2
AppendChild
Ω	Ω	2 =
(
Ω	Ω	= >
new
Ω	Ω	> A

CellFormat
Ω	Ω	B L
{
Ω	Ω	M N
FormatId
Ω	Ω	O W
=
Ω	Ω	X Y
$num
Ω	Ω	Z [
,
Ω	Ω	[ \
FontId
Ω	Ω	] c
=
Ω	Ω	d e
$num
Ω	Ω	f g
,
Ω	Ω	g h
BorderId
Ω	Ω	i q
=
Ω	Ω	r s
$num
Ω	Ω	t u
,
Ω	Ω	u v
FillId
Ω	Ω	w }
=
Ω	Ω	~ 
$numΩ	Ω	Ä Å
,Ω	Ω	Å Ç
	ApplyFillΩ	Ω	É å
=Ω	Ω	ç é
trueΩ	Ω	è ì
}Ω	Ω	î ï
)Ω	Ω	ï ñ
.Ω	Ω	ñ ó
AppendChildΩ	Ω	ó ¢
(Ω	Ω	¢ £
newΩ	Ω	£ ¶
	AlignmentΩ	Ω	ß ∞
{Ω	Ω	± ≤

HorizontalΩ	Ω	≥ Ω
=Ω	Ω	æ ø)
HorizontalAlignmentValuesΩ	Ω	¿ Ÿ
.Ω	Ω	Ÿ ⁄
LeftΩ	Ω	⁄ ﬁ
}Ω	Ω	ﬂ ‡
)Ω	Ω	‡ ·
;Ω	Ω	· ‚

stylesPart
ø	ø	 
.
ø	ø	 

Stylesheet
ø	ø	 %
.
ø	ø	% &
CellFormats
ø	ø	& 1
.
ø	ø	1 2
AppendChild
ø	ø	2 =
(
ø	ø	= >
new
ø	ø	> A

CellFormat
ø	ø	B L
{
ø	ø	M N
FormatId
ø	ø	O W
=
ø	ø	X Y
$num
ø	ø	Z [
,
ø	ø	[ \
FontId
ø	ø	] c
=
ø	ø	d e
$num
ø	ø	f g
,
ø	ø	g h
BorderId
ø	ø	i q
=
ø	ø	r s
$num
ø	ø	t u
,
ø	ø	u v
FillId
ø	ø	w }
=
ø	ø	~ 
$numø	ø	Ä Å
,ø	ø	Å Ç
	ApplyFillø	ø	É å
=ø	ø	ç é
trueø	ø	è ì
}ø	ø	î ï
)ø	ø	ï ñ
.ø	ø	ñ ó
AppendChildø	ø	ó ¢
(ø	ø	¢ £
newø	ø	£ ¶
	Alignmentø	ø	ß ∞
{ø	ø	± ≤

Horizontalø	ø	≥ Ω
=ø	ø	æ ø)
HorizontalAlignmentValuesø	ø	¿ Ÿ
.ø	ø	Ÿ ⁄
Centerø	ø	⁄ ‡
}ø	ø	· ‚
)ø	ø	‚ „
;ø	ø	„ ‰

stylesPart
¿	¿	 
.
¿	¿	 

Stylesheet
¿	¿	 %
.
¿	¿	% &
CellFormats
¿	¿	& 1
.
¿	¿	1 2
AppendChild
¿	¿	2 =
(
¿	¿	= >
new
¿	¿	> A

CellFormat
¿	¿	B L
{
¿	¿	M N
ApplyNumberFormat
¿	¿	O `
=
¿	¿	a b
true
¿	¿	c g
,
¿	¿	g h
NumberFormatId
¿	¿	i w
=
¿	¿	x y
$num
¿	¿	z |
,
¿	¿	| }
FormatId¿	¿	~ Ü
=¿	¿	á à
$num¿	¿	â ä
,¿	¿	ä ã
FontId¿	¿	å í
=¿	¿	ì î
$num¿	¿	ï ñ
,¿	¿	ñ ó
BorderId¿	¿	ò †
=¿	¿	° ¢
$num¿	¿	£ §
,¿	¿	§ •
FillId¿	¿	¶ ¨
=¿	¿	≠ Æ
$num¿	¿	Ø ∞
,¿	¿	∞ ±
	ApplyFill¿	¿	≤ ª
=¿	¿	º Ω
true¿	¿	æ ¬
}¿	¿	√ ƒ
)¿	¿	ƒ ≈
.¿	¿	≈ ∆
AppendChild¿	¿	∆ —
(¿	¿	— “
new¿	¿	“ ’
	Alignment¿	¿	÷ ﬂ
{¿	¿	‡ ·

Horizontal¿	¿	‚ Ï
=¿	¿	Ì Ó)
HorizontalAlignmentValues¿	¿	Ô à
.¿	¿	à â
Center¿	¿	â è
}¿	¿	ê ë
)¿	¿	ë í
;¿	¿	í ì

stylesPart
¡	¡	 
.
¡	¡	 

Stylesheet
¡	¡	 %
.
¡	¡	% &
CellFormats
¡	¡	& 1
.
¡	¡	1 2
AppendChild
¡	¡	2 =
(
¡	¡	= >
new
¡	¡	> A

CellFormat
¡	¡	B L
{
¡	¡	M N
ApplyNumberFormat
¡	¡	O `
=
¡	¡	a b
true
¡	¡	c g
,
¡	¡	g h
NumberFormatId
¡	¡	i w
=
¡	¡	x y
$num
¡	¡	z {
,
¡	¡	{ |
FormatId¡	¡	} Ö
=¡	¡	Ü á
$num¡	¡	à â
,¡	¡	â ä
FontId¡	¡	ã ë
=¡	¡	í ì
$num¡	¡	î ï
,¡	¡	ï ñ
BorderId¡	¡	ó ü
=¡	¡	† °
$num¡	¡	¢ £
,¡	¡	£ §
FillId¡	¡	• ´
=¡	¡	¨ ≠
$num¡	¡	Æ Ø
,¡	¡	Ø ∞
	ApplyFill¡	¡	± ∫
=¡	¡	ª º
true¡	¡	Ω ¡
}¡	¡	¬ √
)¡	¡	√ ƒ
.¡	¡	ƒ ≈
AppendChild¡	¡	≈ –
(¡	¡	– —
new¡	¡	— ‘
	Alignment¡	¡	’ ﬁ
{¡	¡	ﬂ ‡

Horizontal¡	¡	· Î
=¡	¡	Ï Ì)
HorizontalAlignmentValues¡	¡	Ó á
.¡	¡	á à
Right¡	¡	à ç
}¡	¡	é è
)¡	¡	è ê
;¡	¡	ê ë

stylesPart
√	√	 
.
√	√	 

Stylesheet
√	√	 %
.
√	√	% &
CellFormats
√	√	& 1
.
√	√	1 2
AppendChild
√	√	2 =
(
√	√	= >
new
√	√	> A

CellFormat
√	√	B L
{
√	√	M N
FormatId
√	√	O W
=
√	√	X Y
$num
√	√	Z [
,
√	√	[ \
FontId
√	√	] c
=
√	√	d e
$num
√	√	f g
,
√	√	g h
BorderId
√	√	i q
=
√	√	r s
$num
√	√	t u
,
√	√	u v
FillId
√	√	w }
=
√	√	~ 
$num√	√	Ä Å
,√	√	Å Ç
	ApplyFill√	√	É å
=√	√	ç é
true√	√	è ì
}√	√	î ï
)√	√	ï ñ
.√	√	ñ ó
AppendChild√	√	ó ¢
(√	√	¢ £
new√	√	£ ¶
	Alignment√	√	ß ∞
{√	√	± ≤

Horizontal√	√	≥ Ω
=√	√	æ ø)
HorizontalAlignmentValues√	√	¿ Ÿ
.√	√	Ÿ ⁄
Center√	√	⁄ ‡
}√	√	· ‚
)√	√	‚ „
;√	√	„ ‰

stylesPart
ƒ	ƒ	 
.
ƒ	ƒ	 

Stylesheet
ƒ	ƒ	 %
.
ƒ	ƒ	% &
CellFormats
ƒ	ƒ	& 1
.
ƒ	ƒ	1 2
AppendChild
ƒ	ƒ	2 =
(
ƒ	ƒ	= >
new
ƒ	ƒ	> A

CellFormat
ƒ	ƒ	B L
{
ƒ	ƒ	M N
FormatId
ƒ	ƒ	O W
=
ƒ	ƒ	X Y
$num
ƒ	ƒ	Z [
,
ƒ	ƒ	[ \
FontId
ƒ	ƒ	] c
=
ƒ	ƒ	d e
$num
ƒ	ƒ	f g
,
ƒ	ƒ	g h
BorderId
ƒ	ƒ	i q
=
ƒ	ƒ	r s
$num
ƒ	ƒ	t u
,
ƒ	ƒ	u v
FillId
ƒ	ƒ	w }
=
ƒ	ƒ	~ 
$numƒ	ƒ	Ä Å
,ƒ	ƒ	Å Ç
	ApplyFillƒ	ƒ	É å
=ƒ	ƒ	ç é
trueƒ	ƒ	è ì
}ƒ	ƒ	î ï
)ƒ	ƒ	ï ñ
.ƒ	ƒ	ñ ó
AppendChildƒ	ƒ	ó ¢
(ƒ	ƒ	¢ £
newƒ	ƒ	£ ¶
	Alignmentƒ	ƒ	ß ∞
{ƒ	ƒ	± ≤

Horizontalƒ	ƒ	≥ Ω
=ƒ	ƒ	æ ø)
HorizontalAlignmentValuesƒ	ƒ	¿ Ÿ
.ƒ	ƒ	Ÿ ⁄
Centerƒ	ƒ	⁄ ‡
}ƒ	ƒ	· ‚
)ƒ	ƒ	‚ „
;ƒ	ƒ	„ ‰

stylesPart
≈	≈	 
.
≈	≈	 

Stylesheet
≈	≈	 %
.
≈	≈	% &
CellFormats
≈	≈	& 1
.
≈	≈	1 2
AppendChild
≈	≈	2 =
(
≈	≈	= >
new
≈	≈	> A

CellFormat
≈	≈	B L
{
≈	≈	M N
FormatId
≈	≈	O W
=
≈	≈	X Y
$num
≈	≈	Z [
,
≈	≈	[ \
FontId
≈	≈	] c
=
≈	≈	d e
$num
≈	≈	f g
,
≈	≈	g h
BorderId
≈	≈	i q
=
≈	≈	r s
$num
≈	≈	t u
,
≈	≈	u v
FillId
≈	≈	w }
=
≈	≈	~ 
$num≈	≈	Ä Å
,≈	≈	Å Ç
	ApplyFill≈	≈	É å
=≈	≈	ç é
true≈	≈	è ì
}≈	≈	î ï
)≈	≈	ï ñ
.≈	≈	ñ ó
AppendChild≈	≈	ó ¢
(≈	≈	¢ £
new≈	≈	£ ¶
	Alignment≈	≈	ß ∞
{≈	≈	± ≤

Horizontal≈	≈	≥ Ω
=≈	≈	æ ø)
HorizontalAlignmentValues≈	≈	¿ Ÿ
.≈	≈	Ÿ ⁄
Center≈	≈	⁄ ‡
}≈	≈	· ‚
)≈	≈	‚ „
;≈	≈	„ ‰

stylesPart
∆	∆	 
.
∆	∆	 

Stylesheet
∆	∆	 %
.
∆	∆	% &
CellFormats
∆	∆	& 1
.
∆	∆	1 2
AppendChild
∆	∆	2 =
(
∆	∆	= >
new
∆	∆	> A

CellFormat
∆	∆	B L
{
∆	∆	M N
FormatId
∆	∆	O W
=
∆	∆	X Y
$num
∆	∆	Z [
,
∆	∆	[ \
FontId
∆	∆	] c
=
∆	∆	d e
$num
∆	∆	f g
,
∆	∆	g h
BorderId
∆	∆	i q
=
∆	∆	r s
$num
∆	∆	t u
,
∆	∆	u v
FillId
∆	∆	w }
=
∆	∆	~ 
$num∆	∆	Ä Å
,∆	∆	Å Ç
	ApplyFill∆	∆	É å
=∆	∆	ç é
true∆	∆	è ì
}∆	∆	î ï
)∆	∆	ï ñ
.∆	∆	ñ ó
AppendChild∆	∆	ó ¢
(∆	∆	¢ £
new∆	∆	£ ¶
	Alignment∆	∆	ß ∞
{∆	∆	± ≤

Horizontal∆	∆	≥ Ω
=∆	∆	æ ø)
HorizontalAlignmentValues∆	∆	¿ Ÿ
.∆	∆	Ÿ ⁄
Center∆	∆	⁄ ‡
}∆	∆	· ‚
)∆	∆	‚ „
;∆	∆	„ ‰

stylesPart
«	«	 
.
«	«	 

Stylesheet
«	«	 %
.
«	«	% &
CellFormats
«	«	& 1
.
«	«	1 2
AppendChild
«	«	2 =
(
«	«	= >
new
«	«	> A

CellFormat
«	«	B L
{
«	«	M N
FormatId
«	«	O W
=
«	«	X Y
$num
«	«	Z [
,
«	«	[ \
FontId
«	«	] c
=
«	«	d e
$num
«	«	f g
,
«	«	g h
BorderId
«	«	i q
=
«	«	r s
$num
«	«	t u
,
«	«	u v
FillId
«	«	w }
=
«	«	~ 
$num«	«	Ä Å
,«	«	Å Ç
	ApplyFill«	«	É å
=«	«	ç é
true«	«	è ì
}«	«	î ï
)«	«	ï ñ
.«	«	ñ ó
AppendChild«	«	ó ¢
(«	«	¢ £
new«	«	£ ¶
	Alignment«	«	ß ∞
{«	«	± ≤

Horizontal«	«	≥ Ω
=«	«	æ ø)
HorizontalAlignmentValues«	«	¿ Ÿ
.«	«	Ÿ ⁄
Center«	«	⁄ ‡
}«	«	· ‚
)«	«	‚ „
;«	«	„ ‰

stylesPart
Õ	Õ	 
.
Õ	Õ	 

Stylesheet
Õ	Õ	 %
.
Õ	Õ	% &
CellFormats
Õ	Õ	& 1
.
Õ	Õ	1 2
Count
Õ	Õ	2 7
=
Õ	Õ	8 9
$num
Õ	Õ	: <
;
Õ	Õ	< =

stylesPart
œ	œ	 
.
œ	œ	 

Stylesheet
œ	œ	 %
.
œ	œ	% &
Save
œ	œ	& *
(
œ	œ	* +
)
œ	œ	+ ,
;
œ	œ	, -
List
—	—	 
<
—	—	 
string
—	—	 
>
—	—	 
columnasstring
—	—	 +
=
—	—	, -
new
—	—	. 1
List
—	—	2 6
<
—	—	6 7
string
—	—	7 =
>
—	—	= >
(
—	—	> ?
)
—	—	? @
;
—	—	@ A
List
“	“	 
<
“	“	 
string
“	“	 
>
“	“	 
columnasfecha
“	“	 *
=
“	“	+ ,
new
“	“	- 0
List
“	“	1 5
<
“	“	5 6
string
“	“	6 <
>
“	“	< =
(
“	“	= >
)
“	“	> ?
;
“	“	? @
List
”	”	 
<
”	”	 
string
”	”	 
>
”	”	 
columnasmonto
”	”	 *
=
”	”	+ ,
new
”	”	- 0
List
”	”	1 5
<
”	”	5 6
string
”	”	6 <
>
”	”	< =
(
”	”	= >
)
”	”	> ?
;
”	”	? @
List
‘	‘	 
<
‘	‘	 
string
‘	‘	 
>
‘	‘	 
columnassemaforos
‘	‘	 .
=
‘	‘	/ 0
new
‘	‘	1 4
List
‘	‘	5 9
<
‘	‘	9 :
string
‘	‘	: @
>
‘	‘	@ A
(
‘	‘	A B
)
‘	‘	B C
;
‘	‘	C D
columnasstring
ÿ	ÿ	 
.
ÿ	ÿ	 
Add
ÿ	ÿ	 "
(
ÿ	ÿ	" #
$str
ÿ	ÿ	# +
)
ÿ	ÿ	+ ,
;
ÿ	ÿ	, -
columnasstring
Ÿ	Ÿ	 
.
Ÿ	Ÿ	 
Add
Ÿ	Ÿ	 "
(
Ÿ	Ÿ	" #
$str
Ÿ	Ÿ	# +
)
Ÿ	Ÿ	+ ,
;
Ÿ	Ÿ	, -
columnasstring
⁄	⁄	 
.
⁄	⁄	 
Add
⁄	⁄	 "
(
⁄	⁄	" #
$str
⁄	⁄	# *
)
⁄	⁄	* +
;
⁄	⁄	+ ,
columnasstring
€	€	 
.
€	€	 
Add
€	€	 "
(
€	€	" #
$str
€	€	# )
)
€	€	) *
;
€	€	* +
columnasstring
‹	‹	 
.
‹	‹	 
Add
‹	‹	 "
(
‹	‹	" #
$str
‹	‹	# .
)
‹	‹	. /
;
‹	‹	/ 0
columnasfecha
›	›	 
.
›	›	 
Add
›	›	 !
(
›	›	! "
$str
›	›	" 1
)
›	›	1 2
;
›	›	2 3
columnasstring
ﬁ	ﬁ	 
.
ﬁ	ﬁ	 
Add
ﬁ	ﬁ	 "
(
ﬁ	ﬁ	" #
$str
ﬁ	ﬁ	# 5
)
ﬁ	ﬁ	5 6
;
ﬁ	ﬁ	6 7
columnasmonto
ﬂ	ﬂ	 
.
ﬂ	ﬂ	 
Add
ﬂ	ﬂ	 !
(
ﬂ	ﬂ	! "
$str
ﬂ	ﬂ	" 1
)
ﬂ	ﬂ	1 2
;
ﬂ	ﬂ	2 3
columnasmonto
‡	‡	 
.
‡	‡	 
Add
‡	‡	 !
(
‡	‡	! "
$str
‡	‡	" (
)
‡	‡	( )
;
‡	‡	) *
columnasmonto
‚	‚	 
.
‚	‚	 
Add
‚	‚	 !
(
‚	‚	! "
$str
‚	‚	" B
)
‚	‚	B C
;
‚	‚	C D
columnasmonto
„	„	 
.
„	„	 
Add
„	„	 !
(
„	„	! "
$str
„	„	" C
)
„	„	C D
;
„	„	D E
columnasmonto
‰	‰	 
.
‰	‰	 
Add
‰	‰	 !
(
‰	‰	! "
$str
‰	‰	" 1
)
‰	‰	1 2
;
‰	‰	2 3
columnasmonto
Â	Â	 
.
Â	Â	 
Add
Â	Â	 !
(
Â	Â	! "
$str
Â	Â	" 5
)
Â	Â	5 6
;
Â	Â	6 7
columnasmonto
Ê	Ê	 
.
Ê	Ê	 
Add
Ê	Ê	 !
(
Ê	Ê	! "
$str
Ê	Ê	" 6
)
Ê	Ê	6 7
;
Ê	Ê	7 8
columnasmonto
Á	Á	 
.
Á	Á	 
Add
Á	Á	 !
(
Á	Á	! "
$str
Á	Á	" @
)
Á	Á	@ A
;
Á	Á	A B
columnasmonto
Ë	Ë	 
.
Ë	Ë	 
Add
Ë	Ë	 !
(
Ë	Ë	! "
$str
Ë	Ë	" 5
)
Ë	Ë	5 6
;
Ë	Ë	6 7
columnasmonto
È	È	 
.
È	È	 
Add
È	È	 !
(
È	È	! "
$str
È	È	" :
)
È	È	: ;
;
È	È	; <
columnasstring
Î	Î	 
.
Î	Î	 
Add
Î	Î	 "
(
Î	Î	" #
$str
Î	Î	# 4
)
Î	Î	4 5
;
Î	Î	5 6
columnasmonto
Ï	Ï	 
.
Ï	Ï	 
Add
Ï	Ï	 !
(
Ï	Ï	! "
$str
Ï	Ï	" -
)
Ï	Ï	- .
;
Ï	Ï	. /
columnasmonto
Ì	Ì	 
.
Ì	Ì	 
Add
Ì	Ì	 !
(
Ì	Ì	! "
$str
Ì	Ì	" ,
)
Ì	Ì	, -
;
Ì	Ì	- .
columnasmonto
Ó	Ó	 
.
Ó	Ó	 
Add
Ó	Ó	 !
(
Ó	Ó	! "
$str
Ó	Ó	" -
)
Ó	Ó	- .
;
Ó	Ó	. /
columnasmonto
Ô	Ô	 
.
Ô	Ô	 
Add
Ô	Ô	 !
(
Ô	Ô	! "
$str
Ô	Ô	" /
)
Ô	Ô	/ 0
;
Ô	Ô	0 1
columnassemaforos
		 !
.
		! "
Add
		" %
(
		% &
$str
		& .
)
		. /
;
		/ 0
columnassemaforos
Ò	Ò	 !
.
Ò	Ò	! "
Add
Ò	Ò	" %
(
Ò	Ò	% &
$str
Ò	Ò	& .
)
Ò	Ò	. /
;
Ò	Ò	/ 0
columnassemaforos
Ú	Ú	 !
.
Ú	Ú	! "
Add
Ú	Ú	" %
(
Ú	Ú	% &
$str
Ú	Ú	& .
)
Ú	Ú	. /
;
Ú	Ú	/ 0
columnassemaforos
Û	Û	 !
.
Û	Û	! "
Add
Û	Û	" %
(
Û	Û	% &
$str
Û	Û	& .
)
Û	Û	. /
;
Û	Û	/ 0
columnassemaforos
Ù	Ù	 !
.
Ù	Ù	! "
Add
Ù	Ù	" %
(
Ù	Ù	% &
$str
Ù	Ù	& .
)
Ù	Ù	. /
;
Ù	Ù	/ 0
columnassemaforos
ı	ı	 !
.
ı	ı	! "
Add
ı	ı	" %
(
ı	ı	% &
$str
ı	ı	& .
)
ı	ı	. /
;
ı	ı	/ 0
columnassemaforos
ˆ	ˆ	 !
.
ˆ	ˆ	! "
Add
ˆ	ˆ	" %
(
ˆ	ˆ	% &
$str
ˆ	ˆ	& .
)
ˆ	ˆ	. /
;
ˆ	ˆ	/ 0
columnassemaforos
˜	˜	 !
.
˜	˜	! "
Add
˜	˜	" %
(
˜	˜	% &
$str
˜	˜	& .
)
˜	˜	. /
;
˜	˜	/ 0
columnassemaforos
¯	¯	 !
.
¯	¯	! "
Add
¯	¯	" %
(
¯	¯	% &
$str
¯	¯	& .
)
¯	¯	. /
;
¯	¯	/ 0
columnassemaforos
˘	˘	 !
.
˘	˘	! "
Add
˘	˘	" %
(
˘	˘	% &
$str
˘	˘	& /
)
˘	˘	/ 0
;
˘	˘	0 1
columnassemaforos
˙	˙	 !
.
˙	˙	! "
Add
˙	˙	" %
(
˙	˙	% &
$str
˙	˙	& /
)
˙	˙	/ 0
;
˙	˙	0 1
columnassemaforos
˚	˚	 !
.
˚	˚	! "
Add
˚	˚	" %
(
˚	˚	% &
$str
˚	˚	& /
)
˚	˚	/ 0
;
˚	˚	0 1
columnassemaforos
¸	¸	 !
.
¸	¸	! "
Add
¸	¸	" %
(
¸	¸	% &
$str
¸	¸	& /
)
¸	¸	/ 0
;
¸	¸	0 1
columnassemaforos
˝	˝	 !
.
˝	˝	! "
Add
˝	˝	" %
(
˝	˝	% &
$str
˝	˝	& /
)
˝	˝	/ 0
;
˝	˝	0 1
columnassemaforos
˛	˛	 !
.
˛	˛	! "
Add
˛	˛	" %
(
˛	˛	% &
$str
˛	˛	& /
)
˛	˛	/ 0
;
˛	˛	0 1
columnassemaforos
ˇ	ˇ	 !
.
ˇ	ˇ	! "
Add
ˇ	ˇ	" %
(
ˇ	ˇ	% &
$str
ˇ	ˇ	& /
)
ˇ	ˇ	/ 0
;
ˇ	ˇ	0 1
columnassemaforos
Ä
Ä
 !
.
Ä
Ä
! "
Add
Ä
Ä
" %
(
Ä
Ä
% &
$str
Ä
Ä
& /
)
Ä
Ä
/ 0
;
Ä
Ä
0 1
columnassemaforos
Å
Å
 !
.
Å
Å
! "
Add
Å
Å
" %
(
Å
Å
% &
$str
Å
Å
& /
)
Å
Å
/ 0
;
Å
Å
0 1
columnassemaforos
Ç
Ç
 !
.
Ç
Ç
! "
Add
Ç
Ç
" %
(
Ç
Ç
% &
$str
Ç
Ç
& /
)
Ç
Ç
/ 0
;
Ç
Ç
0 1
columnassemaforos
É
É
 !
.
É
É
! "
Add
É
É
" %
(
É
É
% &
$str
É
É
& /
)
É
É
/ 0
;
É
É
0 1
columnassemaforos
Ñ
Ñ
 !
.
Ñ
Ñ
! "
Add
Ñ
Ñ
" %
(
Ñ
Ñ
% &
$str
Ñ
Ñ
& /
)
Ñ
Ñ
/ 0
;
Ñ
Ñ
0 1
columnassemaforos
Ö
Ö
 !
.
Ö
Ö
! "
Add
Ö
Ö
" %
(
Ö
Ö
% &
$str
Ö
Ö
& /
)
Ö
Ö
/ 0
;
Ö
Ö
0 1
Columns
ä
ä
 
columnExcel
ä
ä
 #
=
ä
ä
$ %
new
ä
ä
& )
Columns
ä
ä
* 1
(
ä
ä
1 2
)
ä
ä
2 3
;
ä
ä
3 4
int
ã
ã
 
contadorColumn
ã
ã
 "
=
ã
ã
# $
$num
ã
ã
% &
;
ã
ã
& '
columnExcel
è
è
 
.
è
è
 
Append
è
è
 "
(
è
è
" #
new
è
è
# &
Column
è
è
' -
(
è
è
- .
)
è
è
. /
{
è
è
0 1
Min
è
è
2 5
=
è
è
6 7
Convert
è
è
8 ?
.
è
è
? @
ToUInt32
è
è
@ H
(
è
è
H I
contadorColumn
è
è
I W
)
è
è
W X
,
è
è
X Y
Max
è
è
Z ]
=
è
è
^ _
Convert
è
è
` g
.
è
è
g h
ToUInt32
è
è
h p
(
è
è
p q
contadorColumn
è
è
q 
)è
è
 Ä
,è
è
Ä Å
Widthè
è
Ç á
=è
è
à â
$numè
è
ä è
,è
è
è ê
CustomWidthè
è
ë ú
=è
è
ù û
trueè
è
ü £
}è
è
§ •
)è
è
• ¶
;è
è
¶ ß
contadorColumnè
è
® ∂
++è
è
∂ ∏
;è
è
∏ π
columnExcel
ê
ê
 
.
ê
ê
 
Append
ê
ê
 "
(
ê
ê
" #
new
ê
ê
# &
Column
ê
ê
' -
(
ê
ê
- .
)
ê
ê
. /
{
ê
ê
0 1
Min
ê
ê
2 5
=
ê
ê
6 7
Convert
ê
ê
8 ?
.
ê
ê
? @
ToUInt32
ê
ê
@ H
(
ê
ê
H I
contadorColumn
ê
ê
I W
)
ê
ê
W X
,
ê
ê
X Y
Max
ê
ê
Z ]
=
ê
ê
^ _
Convert
ê
ê
` g
.
ê
ê
g h
ToUInt32
ê
ê
h p
(
ê
ê
p q
contadorColumn
ê
ê
q 
)ê
ê
 Ä
,ê
ê
Ä Å
Widthê
ê
Ç á
=ê
ê
à â
$numê
ê
ä è
,ê
ê
è ê
CustomWidthê
ê
ë ú
=ê
ê
ù û
trueê
ê
ü £
}ê
ê
§ •
)ê
ê
• ¶
;ê
ê
¶ ß
contadorColumnê
ê
® ∂
++ê
ê
∂ ∏
;ê
ê
∏ π
columnExcel
ë
ë
 
.
ë
ë
 
Append
ë
ë
 "
(
ë
ë
" #
new
ë
ë
# &
Column
ë
ë
' -
(
ë
ë
- .
)
ë
ë
. /
{
ë
ë
0 1
Min
ë
ë
2 5
=
ë
ë
6 7
Convert
ë
ë
8 ?
.
ë
ë
? @
ToUInt32
ë
ë
@ H
(
ë
ë
H I
contadorColumn
ë
ë
I W
)
ë
ë
W X
,
ë
ë
X Y
Max
ë
ë
Z ]
=
ë
ë
^ _
Convert
ë
ë
` g
.
ë
ë
g h
ToUInt32
ë
ë
h p
(
ë
ë
p q
contadorColumn
ë
ë
q 
)ë
ë
 Ä
,ë
ë
Ä Å
Widthë
ë
Ç á
=ë
ë
à â
$numë
ë
ä å
,ë
ë
å ç
CustomWidthë
ë
é ô
=ë
ë
ö õ
trueë
ë
ú †
}ë
ë
° ¢
)ë
ë
¢ £
;ë
ë
£ §
contadorColumnë
ë
• ≥
++ë
ë
≥ µ
;ë
ë
µ ∂
columnExcel
í
í
 
.
í
í
 
Append
í
í
 "
(
í
í
" #
new
í
í
# &
Column
í
í
' -
(
í
í
- .
)
í
í
. /
{
í
í
0 1
Min
í
í
2 5
=
í
í
6 7
Convert
í
í
8 ?
.
í
í
? @
ToUInt32
í
í
@ H
(
í
í
H I
contadorColumn
í
í
I W
)
í
í
W X
,
í
í
X Y
Max
í
í
Z ]
=
í
í
^ _
Convert
í
í
` g
.
í
í
g h
ToUInt32
í
í
h p
(
í
í
p q
contadorColumn
í
í
q 
)í
í
 Ä
,í
í
Ä Å
Widthí
í
Ç á
=í
í
à â
$numí
í
ä è
,í
í
è ê
CustomWidthí
í
ë ú
=í
í
ù û
trueí
í
ü £
}í
í
§ •
)í
í
• ¶
;í
í
¶ ß
contadorColumní
í
® ∂
++í
í
∂ ∏
;í
í
∏ π
columnExcel
ì
ì
 
.
ì
ì
 
Append
ì
ì
 "
(
ì
ì
" #
new
ì
ì
# &
Column
ì
ì
' -
(
ì
ì
- .
)
ì
ì
. /
{
ì
ì
0 1
Min
ì
ì
2 5
=
ì
ì
6 7
Convert
ì
ì
8 ?
.
ì
ì
? @
ToUInt32
ì
ì
@ H
(
ì
ì
H I
contadorColumn
ì
ì
I W
)
ì
ì
W X
,
ì
ì
X Y
Max
ì
ì
Z ]
=
ì
ì
^ _
Convert
ì
ì
` g
.
ì
ì
g h
ToUInt32
ì
ì
h p
(
ì
ì
p q
contadorColumn
ì
ì
q 
)ì
ì
 Ä
,ì
ì
Ä Å
Widthì
ì
Ç á
=ì
ì
à â
$numì
ì
ä è
,ì
ì
è ê
CustomWidthì
ì
ë ú
=ì
ì
ù û
trueì
ì
ü £
}ì
ì
§ •
)ì
ì
• ¶
;ì
ì
¶ ß
contadorColumnì
ì
® ∂
++ì
ì
∂ ∏
;ì
ì
∏ π
columnExcel
î
î
 
.
î
î
 
Append
î
î
 "
(
î
î
" #
new
î
î
# &
Column
î
î
' -
(
î
î
- .
)
î
î
. /
{
î
î
0 1
Min
î
î
2 5
=
î
î
6 7
Convert
î
î
8 ?
.
î
î
? @
ToUInt32
î
î
@ H
(
î
î
H I
contadorColumn
î
î
I W
)
î
î
W X
,
î
î
X Y
Max
î
î
Z ]
=
î
î
^ _
Convert
î
î
` g
.
î
î
g h
ToUInt32
î
î
h p
(
î
î
p q
contadorColumn
î
î
q 
)î
î
 Ä
,î
î
Ä Å
Widthî
î
Ç á
=î
î
à â
$numî
î
ä é
,î
î
é è
CustomWidthî
î
ê õ
=î
î
ú ù
trueî
î
û ¢
}î
î
£ §
)î
î
§ •
;î
î
• ¶
contadorColumnî
î
ß µ
++î
î
µ ∑
;î
î
∑ ∏
columnExcel
ï
ï
 
.
ï
ï
 
Append
ï
ï
 "
(
ï
ï
" #
new
ï
ï
# &
Column
ï
ï
' -
(
ï
ï
- .
)
ï
ï
. /
{
ï
ï
0 1
Min
ï
ï
2 5
=
ï
ï
6 7
Convert
ï
ï
8 ?
.
ï
ï
? @
ToUInt32
ï
ï
@ H
(
ï
ï
H I
contadorColumn
ï
ï
I W
)
ï
ï
W X
,
ï
ï
X Y
Max
ï
ï
Z ]
=
ï
ï
^ _
Convert
ï
ï
` g
.
ï
ï
g h
ToUInt32
ï
ï
h p
(
ï
ï
p q
contadorColumn
ï
ï
q 
)ï
ï
 Ä
,ï
ï
Ä Å
Widthï
ï
Ç á
=ï
ï
à â
$numï
ï
ä è
,ï
ï
è ê
CustomWidthï
ï
ë ú
=ï
ï
ù û
trueï
ï
ü £
}ï
ï
§ •
)ï
ï
• ¶
;ï
ï
¶ ß
contadorColumnï
ï
® ∂
++ï
ï
∂ ∏
;ï
ï
∏ π
columnExcel
ñ
ñ
 
.
ñ
ñ
 
Append
ñ
ñ
 "
(
ñ
ñ
" #
new
ñ
ñ
# &
Column
ñ
ñ
' -
(
ñ
ñ
- .
)
ñ
ñ
. /
{
ñ
ñ
0 1
Min
ñ
ñ
2 5
=
ñ
ñ
6 7
Convert
ñ
ñ
8 ?
.
ñ
ñ
? @
ToUInt32
ñ
ñ
@ H
(
ñ
ñ
H I
contadorColumn
ñ
ñ
I W
)
ñ
ñ
W X
,
ñ
ñ
X Y
Max
ñ
ñ
Z ]
=
ñ
ñ
^ _
Convert
ñ
ñ
` g
.
ñ
ñ
g h
ToUInt32
ñ
ñ
h p
(
ñ
ñ
p q
contadorColumn
ñ
ñ
q 
)ñ
ñ
 Ä
,ñ
ñ
Ä Å
Widthñ
ñ
Ç á
=ñ
ñ
à â
$numñ
ñ
ä é
,ñ
ñ
é è
CustomWidthñ
ñ
ê õ
=ñ
ñ
ú ù
trueñ
ñ
û ¢
}ñ
ñ
£ §
)ñ
ñ
§ •
;ñ
ñ
• ¶
contadorColumnñ
ñ
ß µ
++ñ
ñ
µ ∑
;ñ
ñ
∑ ∏
columnExcel
ó
ó
 
.
ó
ó
 
Append
ó
ó
 "
(
ó
ó
" #
new
ó
ó
# &
Column
ó
ó
' -
(
ó
ó
- .
)
ó
ó
. /
{
ó
ó
0 1
Min
ó
ó
2 5
=
ó
ó
6 7
Convert
ó
ó
8 ?
.
ó
ó
? @
ToUInt32
ó
ó
@ H
(
ó
ó
H I
contadorColumn
ó
ó
I W
)
ó
ó
W X
,
ó
ó
X Y
Max
ó
ó
Z ]
=
ó
ó
^ _
Convert
ó
ó
` g
.
ó
ó
g h
ToUInt32
ó
ó
h p
(
ó
ó
p q
contadorColumn
ó
ó
q 
)ó
ó
 Ä
,ó
ó
Ä Å
Widthó
ó
Ç á
=ó
ó
à â
$numó
ó
ä è
,ó
ó
è ê
CustomWidthó
ó
ë ú
=ó
ó
ù û
trueó
ó
ü £
}ó
ó
§ •
)ó
ó
• ¶
;ó
ó
¶ ß
contadorColumnó
ó
® ∂
++ó
ó
∂ ∏
;ó
ó
∏ π
columnExcel
ò
ò
 
.
ò
ò
 
Append
ò
ò
 "
(
ò
ò
" #
new
ò
ò
# &
Column
ò
ò
' -
(
ò
ò
- .
)
ò
ò
. /
{
ò
ò
0 1
Min
ò
ò
2 5
=
ò
ò
6 7
Convert
ò
ò
8 ?
.
ò
ò
? @
ToUInt32
ò
ò
@ H
(
ò
ò
H I
contadorColumn
ò
ò
I W
)
ò
ò
W X
,
ò
ò
X Y
Max
ò
ò
Z ]
=
ò
ò
^ _
Convert
ò
ò
` g
.
ò
ò
g h
ToUInt32
ò
ò
h p
(
ò
ò
p q
contadorColumn
ò
ò
q 
)ò
ò
 Ä
,ò
ò
Ä Å
Widthò
ò
Ç á
=ò
ò
à â
$numò
ò
ä é
,ò
ò
é è
CustomWidthò
ò
ê õ
=ò
ò
ú ù
trueò
ò
û ¢
}ò
ò
£ §
)ò
ò
§ •
;ò
ò
• ¶
contadorColumnò
ò
ß µ
++ò
ò
µ ∑
;ò
ò
∑ ∏
columnExcel
ô
ô
 
.
ô
ô
 
Append
ô
ô
 "
(
ô
ô
" #
new
ô
ô
# &
Column
ô
ô
' -
(
ô
ô
- .
)
ô
ô
. /
{
ô
ô
0 1
Min
ô
ô
2 5
=
ô
ô
6 7
Convert
ô
ô
8 ?
.
ô
ô
? @
ToUInt32
ô
ô
@ H
(
ô
ô
H I
contadorColumn
ô
ô
I W
)
ô
ô
W X
,
ô
ô
X Y
Max
ô
ô
Z ]
=
ô
ô
^ _
Convert
ô
ô
` g
.
ô
ô
g h
ToUInt32
ô
ô
h p
(
ô
ô
p q
contadorColumn
ô
ô
q 
)ô
ô
 Ä
,ô
ô
Ä Å
Widthô
ô
Ç á
=ô
ô
à â
$numô
ô
ä è
,ô
ô
è ê
CustomWidthô
ô
ë ú
=ô
ô
ù û
trueô
ô
ü £
}ô
ô
§ •
)ô
ô
• ¶
;ô
ô
¶ ß
contadorColumnô
ô
® ∂
++ô
ô
∂ ∏
;ô
ô
∏ π
columnExcel
ö
ö
 
.
ö
ö
 
Append
ö
ö
 "
(
ö
ö
" #
new
ö
ö
# &
Column
ö
ö
' -
(
ö
ö
- .
)
ö
ö
. /
{
ö
ö
0 1
Min
ö
ö
2 5
=
ö
ö
6 7
Convert
ö
ö
8 ?
.
ö
ö
? @
ToUInt32
ö
ö
@ H
(
ö
ö
H I
contadorColumn
ö
ö
I W
)
ö
ö
W X
,
ö
ö
X Y
Max
ö
ö
Z ]
=
ö
ö
^ _
Convert
ö
ö
` g
.
ö
ö
g h
ToUInt32
ö
ö
h p
(
ö
ö
p q
contadorColumn
ö
ö
q 
)ö
ö
 Ä
,ö
ö
Ä Å
Widthö
ö
Ç á
=ö
ö
à â
$numö
ö
ä è
,ö
ö
è ê
CustomWidthö
ö
ë ú
=ö
ö
ù û
trueö
ö
ü £
}ö
ö
§ •
)ö
ö
• ¶
;ö
ö
¶ ß
contadorColumnö
ö
® ∂
++ö
ö
∂ ∏
;ö
ö
∏ π
columnExcel
õ
õ
 
.
õ
õ
 
Append
õ
õ
 "
(
õ
õ
" #
new
õ
õ
# &
Column
õ
õ
' -
(
õ
õ
- .
)
õ
õ
. /
{
õ
õ
0 1
Min
õ
õ
2 5
=
õ
õ
6 7
Convert
õ
õ
8 ?
.
õ
õ
? @
ToUInt32
õ
õ
@ H
(
õ
õ
H I
contadorColumn
õ
õ
I W
)
õ
õ
W X
,
õ
õ
X Y
Max
õ
õ
Z ]
=
õ
õ
^ _
Convert
õ
õ
` g
.
õ
õ
g h
ToUInt32
õ
õ
h p
(
õ
õ
p q
contadorColumn
õ
õ
q 
)õ
õ
 Ä
,õ
õ
Ä Å
Widthõ
õ
Ç á
=õ
õ
à â
$numõ
õ
ä è
,õ
õ
è ê
CustomWidthõ
õ
ë ú
=õ
õ
ù û
trueõ
õ
ü £
}õ
õ
§ •
)õ
õ
• ¶
;õ
õ
¶ ß
contadorColumnõ
õ
® ∂
++õ
õ
∂ ∏
;õ
õ
∏ π
columnExcel
ú
ú
 
.
ú
ú
 
Append
ú
ú
 "
(
ú
ú
" #
new
ú
ú
# &
Column
ú
ú
' -
(
ú
ú
- .
)
ú
ú
. /
{
ú
ú
0 1
Min
ú
ú
2 5
=
ú
ú
6 7
Convert
ú
ú
8 ?
.
ú
ú
? @
ToUInt32
ú
ú
@ H
(
ú
ú
H I
contadorColumn
ú
ú
I W
)
ú
ú
W X
,
ú
ú
X Y
Max
ú
ú
Z ]
=
ú
ú
^ _
Convert
ú
ú
` g
.
ú
ú
g h
ToUInt32
ú
ú
h p
(
ú
ú
p q
contadorColumn
ú
ú
q 
)ú
ú
 Ä
,ú
ú
Ä Å
Widthú
ú
Ç á
=ú
ú
à â
$numú
ú
ä é
,ú
ú
é è
CustomWidthú
ú
ê õ
=ú
ú
ú ù
trueú
ú
û ¢
}ú
ú
£ §
)ú
ú
§ •
;ú
ú
• ¶
contadorColumnú
ú
ß µ
++ú
ú
µ ∑
;ú
ú
∑ ∏
columnExcel
ù
ù
 
.
ù
ù
 
Append
ù
ù
 "
(
ù
ù
" #
new
ù
ù
# &
Column
ù
ù
' -
(
ù
ù
- .
)
ù
ù
. /
{
ù
ù
0 1
Min
ù
ù
2 5
=
ù
ù
6 7
Convert
ù
ù
8 ?
.
ù
ù
? @
ToUInt32
ù
ù
@ H
(
ù
ù
H I
contadorColumn
ù
ù
I W
)
ù
ù
W X
,
ù
ù
X Y
Max
ù
ù
Z ]
=
ù
ù
^ _
Convert
ù
ù
` g
.
ù
ù
g h
ToUInt32
ù
ù
h p
(
ù
ù
p q
contadorColumn
ù
ù
q 
)ù
ù
 Ä
,ù
ù
Ä Å
Widthù
ù
Ç á
=ù
ù
à â
$numù
ù
ä é
,ù
ù
é è
CustomWidthù
ù
ê õ
=ù
ù
ú ù
trueù
ù
û ¢
}ù
ù
£ §
)ù
ù
§ •
;ù
ù
• ¶
contadorColumnù
ù
ß µ
++ù
ù
µ ∑
;ù
ù
∑ ∏
columnExcel
û
û
 
.
û
û
 
Append
û
û
 "
(
û
û
" #
new
û
û
# &
Column
û
û
' -
(
û
û
- .
)
û
û
. /
{
û
û
0 1
Min
û
û
2 5
=
û
û
6 7
Convert
û
û
8 ?
.
û
û
? @
ToUInt32
û
û
@ H
(
û
û
H I
contadorColumn
û
û
I W
)
û
û
W X
,
û
û
X Y
Max
û
û
Z ]
=
û
û
^ _
Convert
û
û
` g
.
û
û
g h
ToUInt32
û
û
h p
(
û
û
p q
contadorColumn
û
û
q 
)û
û
 Ä
,û
û
Ä Å
Widthû
û
Ç á
=û
û
à â
$numû
û
ä é
,û
û
é è
CustomWidthû
û
ê õ
=û
û
ú ù
trueû
û
û ¢
}û
û
£ §
)û
û
§ •
;û
û
• ¶
contadorColumnû
û
ß µ
++û
û
µ ∑
;û
û
∑ ∏
columnExcel
ü
ü
 
.
ü
ü
 
Append
ü
ü
 "
(
ü
ü
" #
new
ü
ü
# &
Column
ü
ü
' -
(
ü
ü
- .
)
ü
ü
. /
{
ü
ü
0 1
Min
ü
ü
2 5
=
ü
ü
6 7
Convert
ü
ü
8 ?
.
ü
ü
? @
ToUInt32
ü
ü
@ H
(
ü
ü
H I
contadorColumn
ü
ü
I W
)
ü
ü
W X
,
ü
ü
X Y
Max
ü
ü
Z ]
=
ü
ü
^ _
Convert
ü
ü
` g
.
ü
ü
g h
ToUInt32
ü
ü
h p
(
ü
ü
p q
contadorColumn
ü
ü
q 
)ü
ü
 Ä
,ü
ü
Ä Å
Widthü
ü
Ç á
=ü
ü
à â
$numü
ü
ä ã
,ü
ü
ã å
CustomWidthü
ü
ç ò
=ü
ü
ô ö
trueü
ü
õ ü
}ü
ü
† °
)ü
ü
° ¢
;ü
ü
¢ £
contadorColumnü
ü
§ ≤
++ü
ü
≤ ¥
;ü
ü
¥ µ
columnExcel
†
†
 
.
†
†
 
Append
†
†
 "
(
†
†
" #
new
†
†
# &
Column
†
†
' -
(
†
†
- .
)
†
†
. /
{
†
†
0 1
Min
†
†
2 5
=
†
†
6 7
Convert
†
†
8 ?
.
†
†
? @
ToUInt32
†
†
@ H
(
†
†
H I
contadorColumn
†
†
I W
)
†
†
W X
,
†
†
X Y
Max
†
†
Z ]
=
†
†
^ _
Convert
†
†
` g
.
†
†
g h
ToUInt32
†
†
h p
(
†
†
p q
contadorColumn
†
†
q 
)†
†
 Ä
,†
†
Ä Å
Width†
†
Ç á
=†
†
à â
$num†
†
ä ã
,†
†
ã å
CustomWidth†
†
ç ò
=†
†
ô ö
true†
†
õ ü
}†
†
† °
)†
†
° ¢
;†
†
¢ £
contadorColumn†
†
§ ≤
++†
†
≤ ¥
;†
†
¥ µ
columnExcel
°
°
 
.
°
°
 
Append
°
°
 "
(
°
°
" #
new
°
°
# &
Column
°
°
' -
(
°
°
- .
)
°
°
. /
{
°
°
0 1
Min
°
°
2 5
=
°
°
6 7
Convert
°
°
8 ?
.
°
°
? @
ToUInt32
°
°
@ H
(
°
°
H I
contadorColumn
°
°
I W
)
°
°
W X
,
°
°
X Y
Max
°
°
Z ]
=
°
°
^ _
Convert
°
°
` g
.
°
°
g h
ToUInt32
°
°
h p
(
°
°
p q
contadorColumn
°
°
q 
)°
°
 Ä
,°
°
Ä Å
Width°
°
Ç á
=°
°
à â
$num°
°
ä é
,°
°
é è
CustomWidth°
°
ê õ
=°
°
ú ù
true°
°
û ¢
}°
°
£ §
)°
°
§ •
;°
°
• ¶
contadorColumn°
°
ß µ
++°
°
µ ∑
;°
°
∑ ∏
columnExcel
¢
¢
 
.
¢
¢
 
Append
¢
¢
 "
(
¢
¢
" #
new
¢
¢
# &
Column
¢
¢
' -
(
¢
¢
- .
)
¢
¢
. /
{
¢
¢
0 1
Min
¢
¢
2 5
=
¢
¢
6 7
Convert
¢
¢
8 ?
.
¢
¢
? @
ToUInt32
¢
¢
@ H
(
¢
¢
H I
contadorColumn
¢
¢
I W
)
¢
¢
W X
,
¢
¢
X Y
Max
¢
¢
Z ]
=
¢
¢
^ _
Convert
¢
¢
` g
.
¢
¢
g h
ToUInt32
¢
¢
h p
(
¢
¢
p q
contadorColumn
¢
¢
q 
)¢
¢
 Ä
,¢
¢
Ä Å
Width¢
¢
Ç á
=¢
¢
à â
$num¢
¢
ä é
,¢
¢
é è
CustomWidth¢
¢
ê õ
=¢
¢
ú ù
true¢
¢
û ¢
}¢
¢
£ §
)¢
¢
§ •
;¢
¢
• ¶
contadorColumn¢
¢
ß µ
++¢
¢
µ ∑
;¢
¢
∑ ∏
columnExcel
£
£
 
.
£
£
 
Append
£
£
 "
(
£
£
" #
new
£
£
# &
Column
£
£
' -
(
£
£
- .
)
£
£
. /
{
£
£
0 1
Min
£
£
2 5
=
£
£
6 7
Convert
£
£
8 ?
.
£
£
? @
ToUInt32
£
£
@ H
(
£
£
H I
contadorColumn
£
£
I W
)
£
£
W X
,
£
£
X Y
Max
£
£
Z ]
=
£
£
^ _
Convert
£
£
` g
.
£
£
g h
ToUInt32
£
£
h p
(
£
£
p q
contadorColumn
£
£
q 
)£
£
 Ä
,£
£
Ä Å
Width£
£
Ç á
=£
£
à â
$num£
£
ä è
,£
£
è ê
CustomWidth£
£
ë ú
=£
£
ù û
true£
£
ü £
}£
£
§ •
)£
£
• ¶
;£
£
¶ ß
contadorColumn£
£
® ∂
++£
£
∂ ∏
;£
£
∏ π
columnExcel
§
§
 
.
§
§
 
Append
§
§
 "
(
§
§
" #
new
§
§
# &
Column
§
§
' -
(
§
§
- .
)
§
§
. /
{
§
§
0 1
Min
§
§
2 5
=
§
§
6 7
Convert
§
§
8 ?
.
§
§
? @
ToUInt32
§
§
@ H
(
§
§
H I
contadorColumn
§
§
I W
)
§
§
W X
,
§
§
X Y
Max
§
§
Z ]
=
§
§
^ _
Convert
§
§
` g
.
§
§
g h
ToUInt32
§
§
h p
(
§
§
p q
contadorColumn
§
§
q 
)§
§
 Ä
,§
§
Ä Å
Width§
§
Ç á
=§
§
à â
$num§
§
ä è
,§
§
è ê
CustomWidth§
§
ë ú
=§
§
ù û
true§
§
ü £
}§
§
§ •
)§
§
• ¶
;§
§
¶ ß
contadorColumn§
§
® ∂
++§
§
∂ ∏
;§
§
∏ π
columnExcel
•
•
 
.
•
•
 
Append
•
•
 "
(
•
•
" #
new
•
•
# &
Column
•
•
' -
(
•
•
- .
)
•
•
. /
{
•
•
0 1
Min
•
•
2 5
=
•
•
6 7
Convert
•
•
8 ?
.
•
•
? @
ToUInt32
•
•
@ H
(
•
•
H I
contadorColumn
•
•
I W
)
•
•
W X
,
•
•
X Y
Max
•
•
Z ]
=
•
•
^ _
Convert
•
•
` g
.
•
•
g h
ToUInt32
•
•
h p
(
•
•
p q
contadorColumn
•
•
q 
)•
•
 Ä
,•
•
Ä Å
Width•
•
Ç á
=•
•
à â
$num•
•
ä è
,•
•
è ê
CustomWidth•
•
ë ú
=•
•
ù û
true•
•
ü £
}•
•
§ •
)•
•
• ¶
;•
•
¶ ß
contadorColumn•
•
® ∂
++•
•
∂ ∏
;•
•
∏ π
columnExcel
¶
¶
 
.
¶
¶
 
Append
¶
¶
 "
(
¶
¶
" #
new
¶
¶
# &
Column
¶
¶
' -
(
¶
¶
- .
)
¶
¶
. /
{
¶
¶
0 1
Min
¶
¶
2 5
=
¶
¶
6 7
Convert
¶
¶
8 ?
.
¶
¶
? @
ToUInt32
¶
¶
@ H
(
¶
¶
H I
contadorColumn
¶
¶
I W
)
¶
¶
W X
,
¶
¶
X Y
Max
¶
¶
Z ]
=
¶
¶
^ _
Convert
¶
¶
` g
.
¶
¶
g h
ToUInt32
¶
¶
h p
(
¶
¶
p q
contadorColumn
¶
¶
q 
)¶
¶
 Ä
,¶
¶
Ä Å
Width¶
¶
Ç á
=¶
¶
à â
$num¶
¶
ä é
,¶
¶
é è
CustomWidth¶
¶
ê õ
=¶
¶
ú ù
true¶
¶
û ¢
}¶
¶
£ §
)¶
¶
§ •
;¶
¶
• ¶
contadorColumn¶
¶
ß µ
++¶
¶
µ ∑
;¶
¶
∑ ∏
columnExcel
ß
ß
 
.
ß
ß
 
Append
ß
ß
 "
(
ß
ß
" #
new
ß
ß
# &
Column
ß
ß
' -
(
ß
ß
- .
)
ß
ß
. /
{
ß
ß
0 1
Min
ß
ß
2 5
=
ß
ß
6 7
Convert
ß
ß
8 ?
.
ß
ß
? @
ToUInt32
ß
ß
@ H
(
ß
ß
H I
contadorColumn
ß
ß
I W
)
ß
ß
W X
,
ß
ß
X Y
Max
ß
ß
Z ]
=
ß
ß
^ _
Convert
ß
ß
` g
.
ß
ß
g h
ToUInt32
ß
ß
h p
(
ß
ß
p q
contadorColumn
ß
ß
q 
)ß
ß
 Ä
,ß
ß
Ä Å
Widthß
ß
Ç á
=ß
ß
à â
$numß
ß
ä é
,ß
ß
é è
CustomWidthß
ß
ê õ
=ß
ß
ú ù
trueß
ß
û ¢
}ß
ß
£ §
)ß
ß
§ •
;ß
ß
• ¶
contadorColumnß
ß
ß µ
++ß
ß
µ ∑
;ß
ß
∑ ∏
columnExcel
®
®
 
.
®
®
 
Append
®
®
 "
(
®
®
" #
new
®
®
# &
Column
®
®
' -
(
®
®
- .
)
®
®
. /
{
®
®
0 1
Min
®
®
2 5
=
®
®
6 7
Convert
®
®
8 ?
.
®
®
? @
ToUInt32
®
®
@ H
(
®
®
H I
contadorColumn
®
®
I W
)
®
®
W X
,
®
®
X Y
Max
®
®
Z ]
=
®
®
^ _
Convert
®
®
` g
.
®
®
g h
ToUInt32
®
®
h p
(
®
®
p q
contadorColumn
®
®
q 
)®
®
 Ä
,®
®
Ä Å
Width®
®
Ç á
=®
®
à â
$num®
®
ä é
,®
®
é è
CustomWidth®
®
ê õ
=®
®
ú ù
true®
®
û ¢
}®
®
£ §
)®
®
§ •
;®
®
• ¶
contadorColumn®
®
ß µ
++®
®
µ ∑
;®
®
∑ ∏
columnExcel
©
©
 
.
©
©
 
Append
©
©
 "
(
©
©
" #
new
©
©
# &
Column
©
©
' -
(
©
©
- .
)
©
©
. /
{
©
©
0 1
Min
©
©
2 5
=
©
©
6 7
Convert
©
©
8 ?
.
©
©
? @
ToUInt32
©
©
@ H
(
©
©
H I
contadorColumn
©
©
I W
)
©
©
W X
,
©
©
X Y
Max
©
©
Z ]
=
©
©
^ _
Convert
©
©
` g
.
©
©
g h
ToUInt32
©
©
h p
(
©
©
p q
contadorColumn
©
©
q 
)©
©
 Ä
,©
©
Ä Å
Width©
©
Ç á
=©
©
à â
$num©
©
ä é
,©
©
é è
CustomWidth©
©
ê õ
=©
©
ú ù
true©
©
û ¢
}©
©
£ §
)©
©
§ •
;©
©
• ¶
contadorColumn©
©
ß µ
++©
©
µ ∑
;©
©
∑ ∏
columnExcel
™
™
 
.
™
™
 
Append
™
™
 "
(
™
™
" #
new
™
™
# &
Column
™
™
' -
(
™
™
- .
)
™
™
. /
{
™
™
0 1
Min
™
™
2 5
=
™
™
6 7
Convert
™
™
8 ?
.
™
™
? @
ToUInt32
™
™
@ H
(
™
™
H I
contadorColumn
™
™
I W
)
™
™
W X
,
™
™
X Y
Max
™
™
Z ]
=
™
™
^ _
Convert
™
™
` g
.
™
™
g h
ToUInt32
™
™
h p
(
™
™
p q
contadorColumn
™
™
q 
)™
™
 Ä
,™
™
Ä Å
Width™
™
Ç á
=™
™
à â
$num™
™
ä é
,™
™
é è
CustomWidth™
™
ê õ
=™
™
ú ù
true™
™
û ¢
}™
™
£ §
)™
™
§ •
;™
™
• ¶
contadorColumn™
™
ß µ
++™
™
µ ∑
;™
™
∑ ∏
columnExcel
´
´
 
.
´
´
 
Append
´
´
 "
(
´
´
" #
new
´
´
# &
Column
´
´
' -
(
´
´
- .
)
´
´
. /
{
´
´
0 1
Min
´
´
2 5
=
´
´
6 7
Convert
´
´
8 ?
.
´
´
? @
ToUInt32
´
´
@ H
(
´
´
H I
contadorColumn
´
´
I W
)
´
´
W X
,
´
´
X Y
Max
´
´
Z ]
=
´
´
^ _
Convert
´
´
` g
.
´
´
g h
ToUInt32
´
´
h p
(
´
´
p q
contadorColumn
´
´
q 
)´
´
 Ä
,´
´
Ä Å
Width´
´
Ç á
=´
´
à â
$num´
´
ä é
,´
´
é è
CustomWidth´
´
ê õ
=´
´
ú ù
true´
´
û ¢
}´
´
£ §
)´
´
§ •
;´
´
• ¶
contadorColumn´
´
ß µ
++´
´
µ ∑
;´
´
∑ ∏
columnExcel
¨
¨
 
.
¨
¨
 
Append
¨
¨
 "
(
¨
¨
" #
new
¨
¨
# &
Column
¨
¨
' -
(
¨
¨
- .
)
¨
¨
. /
{
¨
¨
0 1
Min
¨
¨
2 5
=
¨
¨
6 7
Convert
¨
¨
8 ?
.
¨
¨
? @
ToUInt32
¨
¨
@ H
(
¨
¨
H I
contadorColumn
¨
¨
I W
)
¨
¨
W X
,
¨
¨
X Y
Max
¨
¨
Z ]
=
¨
¨
^ _
Convert
¨
¨
` g
.
¨
¨
g h
ToUInt32
¨
¨
h p
(
¨
¨
p q
contadorColumn
¨
¨
q 
)¨
¨
 Ä
,¨
¨
Ä Å
Width¨
¨
Ç á
=¨
¨
à â
$num¨
¨
ä é
,¨
¨
é è
CustomWidth¨
¨
ê õ
=¨
¨
ú ù
true¨
¨
û ¢
}¨
¨
£ §
)¨
¨
§ •
;¨
¨
• ¶
contadorColumn¨
¨
ß µ
++¨
¨
µ ∑
;¨
¨
∑ ∏
columnExcel
≠
≠
 
.
≠
≠
 
Append
≠
≠
 "
(
≠
≠
" #
new
≠
≠
# &
Column
≠
≠
' -
(
≠
≠
- .
)
≠
≠
. /
{
≠
≠
0 1
Min
≠
≠
2 5
=
≠
≠
6 7
Convert
≠
≠
8 ?
.
≠
≠
? @
ToUInt32
≠
≠
@ H
(
≠
≠
H I
contadorColumn
≠
≠
I W
)
≠
≠
W X
,
≠
≠
X Y
Max
≠
≠
Z ]
=
≠
≠
^ _
Convert
≠
≠
` g
.
≠
≠
g h
ToUInt32
≠
≠
h p
(
≠
≠
p q
contadorColumn
≠
≠
q 
)≠
≠
 Ä
,≠
≠
Ä Å
Width≠
≠
Ç á
=≠
≠
à â
$num≠
≠
ä é
,≠
≠
é è
CustomWidth≠
≠
ê õ
=≠
≠
ú ù
true≠
≠
û ¢
}≠
≠
£ §
)≠
≠
§ •
;≠
≠
• ¶
contadorColumn≠
≠
ß µ
++≠
≠
µ ∑
;≠
≠
∑ ∏
columnExcel
Æ
Æ
 
.
Æ
Æ
 
Append
Æ
Æ
 "
(
Æ
Æ
" #
new
Æ
Æ
# &
Column
Æ
Æ
' -
(
Æ
Æ
- .
)
Æ
Æ
. /
{
Æ
Æ
0 1
Min
Æ
Æ
2 5
=
Æ
Æ
6 7
Convert
Æ
Æ
8 ?
.
Æ
Æ
? @
ToUInt32
Æ
Æ
@ H
(
Æ
Æ
H I
contadorColumn
Æ
Æ
I W
)
Æ
Æ
W X
,
Æ
Æ
X Y
Max
Æ
Æ
Z ]
=
Æ
Æ
^ _
Convert
Æ
Æ
` g
.
Æ
Æ
g h
ToUInt32
Æ
Æ
h p
(
Æ
Æ
p q
contadorColumn
Æ
Æ
q 
)Æ
Æ
 Ä
,Æ
Æ
Ä Å
WidthÆ
Æ
Ç á
=Æ
Æ
à â
$numÆ
Æ
ä é
,Æ
Æ
é è
CustomWidthÆ
Æ
ê õ
=Æ
Æ
ú ù
trueÆ
Æ
û ¢
}Æ
Æ
£ §
)Æ
Æ
§ •
;Æ
Æ
• ¶
contadorColumnÆ
Æ
ß µ
++Æ
Æ
µ ∑
;Æ
Æ
∑ ∏
columnExcel
Ø
Ø
 
.
Ø
Ø
 
Append
Ø
Ø
 "
(
Ø
Ø
" #
new
Ø
Ø
# &
Column
Ø
Ø
' -
(
Ø
Ø
- .
)
Ø
Ø
. /
{
Ø
Ø
0 1
Min
Ø
Ø
2 5
=
Ø
Ø
6 7
Convert
Ø
Ø
8 ?
.
Ø
Ø
? @
ToUInt32
Ø
Ø
@ H
(
Ø
Ø
H I
contadorColumn
Ø
Ø
I W
)
Ø
Ø
W X
,
Ø
Ø
X Y
Max
Ø
Ø
Z ]
=
Ø
Ø
^ _
Convert
Ø
Ø
` g
.
Ø
Ø
g h
ToUInt32
Ø
Ø
h p
(
Ø
Ø
p q
contadorColumn
Ø
Ø
q 
)Ø
Ø
 Ä
,Ø
Ø
Ä Å
WidthØ
Ø
Ç á
=Ø
Ø
à â
$numØ
Ø
ä é
,Ø
Ø
é è
CustomWidthØ
Ø
ê õ
=Ø
Ø
ú ù
trueØ
Ø
û ¢
}Ø
Ø
£ §
)Ø
Ø
§ •
;Ø
Ø
• ¶
contadorColumnØ
Ø
ß µ
++Ø
Ø
µ ∑
;Ø
Ø
∑ ∏
columnExcel
∞
∞
 
.
∞
∞
 
Append
∞
∞
 "
(
∞
∞
" #
new
∞
∞
# &
Column
∞
∞
' -
(
∞
∞
- .
)
∞
∞
. /
{
∞
∞
0 1
Min
∞
∞
2 5
=
∞
∞
6 7
Convert
∞
∞
8 ?
.
∞
∞
? @
ToUInt32
∞
∞
@ H
(
∞
∞
H I
contadorColumn
∞
∞
I W
)
∞
∞
W X
,
∞
∞
X Y
Max
∞
∞
Z ]
=
∞
∞
^ _
Convert
∞
∞
` g
.
∞
∞
g h
ToUInt32
∞
∞
h p
(
∞
∞
p q
contadorColumn
∞
∞
q 
)∞
∞
 Ä
,∞
∞
Ä Å
Width∞
∞
Ç á
=∞
∞
à â
$num∞
∞
ä é
,∞
∞
é è
CustomWidth∞
∞
ê õ
=∞
∞
ú ù
true∞
∞
û ¢
}∞
∞
£ §
)∞
∞
§ •
;∞
∞
• ¶
contadorColumn∞
∞
ß µ
++∞
∞
µ ∑
;∞
∞
∑ ∏
columnExcel
±
±
 
.
±
±
 
Append
±
±
 "
(
±
±
" #
new
±
±
# &
Column
±
±
' -
(
±
±
- .
)
±
±
. /
{
±
±
0 1
Min
±
±
2 5
=
±
±
6 7
Convert
±
±
8 ?
.
±
±
? @
ToUInt32
±
±
@ H
(
±
±
H I
contadorColumn
±
±
I W
)
±
±
W X
,
±
±
X Y
Max
±
±
Z ]
=
±
±
^ _
Convert
±
±
` g
.
±
±
g h
ToUInt32
±
±
h p
(
±
±
p q
contadorColumn
±
±
q 
)±
±
 Ä
,±
±
Ä Å
Width±
±
Ç á
=±
±
à â
$num±
±
ä é
,±
±
é è
CustomWidth±
±
ê õ
=±
±
ú ù
true±
±
û ¢
}±
±
£ §
)±
±
§ •
;±
±
• ¶
contadorColumn±
±
ß µ
++±
±
µ ∑
;±
±
∑ ∏
columnExcel
≤
≤
 
.
≤
≤
 
Append
≤
≤
 "
(
≤
≤
" #
new
≤
≤
# &
Column
≤
≤
' -
(
≤
≤
- .
)
≤
≤
. /
{
≤
≤
0 1
Min
≤
≤
2 5
=
≤
≤
6 7
Convert
≤
≤
8 ?
.
≤
≤
? @
ToUInt32
≤
≤
@ H
(
≤
≤
H I
contadorColumn
≤
≤
I W
)
≤
≤
W X
,
≤
≤
X Y
Max
≤
≤
Z ]
=
≤
≤
^ _
Convert
≤
≤
` g
.
≤
≤
g h
ToUInt32
≤
≤
h p
(
≤
≤
p q
contadorColumn
≤
≤
q 
)≤
≤
 Ä
,≤
≤
Ä Å
Width≤
≤
Ç á
=≤
≤
à â
$num≤
≤
ä é
,≤
≤
é è
CustomWidth≤
≤
ê õ
=≤
≤
ú ù
true≤
≤
û ¢
}≤
≤
£ §
)≤
≤
§ •
;≤
≤
• ¶
contadorColumn≤
≤
ß µ
++≤
≤
µ ∑
;≤
≤
∑ ∏
columnExcel
≥
≥
 
.
≥
≥
 
Append
≥
≥
 "
(
≥
≥
" #
new
≥
≥
# &
Column
≥
≥
' -
(
≥
≥
- .
)
≥
≥
. /
{
≥
≥
0 1
Min
≥
≥
2 5
=
≥
≥
6 7
Convert
≥
≥
8 ?
.
≥
≥
? @
ToUInt32
≥
≥
@ H
(
≥
≥
H I
contadorColumn
≥
≥
I W
)
≥
≥
W X
,
≥
≥
X Y
Max
≥
≥
Z ]
=
≥
≥
^ _
Convert
≥
≥
` g
.
≥
≥
g h
ToUInt32
≥
≥
h p
(
≥
≥
p q
contadorColumn
≥
≥
q 
)≥
≥
 Ä
,≥
≥
Ä Å
Width≥
≥
Ç á
=≥
≥
à â
$num≥
≥
ä é
,≥
≥
é è
CustomWidth≥
≥
ê õ
=≥
≥
ú ù
true≥
≥
û ¢
}≥
≥
£ §
)≥
≥
§ •
;≥
≥
• ¶
contadorColumn≥
≥
ß µ
++≥
≥
µ ∑
;≥
≥
∑ ∏
columnExcel
¥
¥
 
.
¥
¥
 
Append
¥
¥
 "
(
¥
¥
" #
new
¥
¥
# &
Column
¥
¥
' -
(
¥
¥
- .
)
¥
¥
. /
{
¥
¥
0 1
Min
¥
¥
2 5
=
¥
¥
6 7
Convert
¥
¥
8 ?
.
¥
¥
? @
ToUInt32
¥
¥
@ H
(
¥
¥
H I
contadorColumn
¥
¥
I W
)
¥
¥
W X
,
¥
¥
X Y
Max
¥
¥
Z ]
=
¥
¥
^ _
Convert
¥
¥
` g
.
¥
¥
g h
ToUInt32
¥
¥
h p
(
¥
¥
p q
contadorColumn
¥
¥
q 
)¥
¥
 Ä
,¥
¥
Ä Å
Width¥
¥
Ç á
=¥
¥
à â
$num¥
¥
ä é
,¥
¥
é è
CustomWidth¥
¥
ê õ
=¥
¥
ú ù
true¥
¥
û ¢
}¥
¥
£ §
)¥
¥
§ •
;¥
¥
• ¶
contadorColumn¥
¥
ß µ
++¥
¥
µ ∑
;¥
¥
∑ ∏
columnExcel
µ
µ
 
.
µ
µ
 
Append
µ
µ
 "
(
µ
µ
" #
new
µ
µ
# &
Column
µ
µ
' -
(
µ
µ
- .
)
µ
µ
. /
{
µ
µ
0 1
Min
µ
µ
2 5
=
µ
µ
6 7
Convert
µ
µ
8 ?
.
µ
µ
? @
ToUInt32
µ
µ
@ H
(
µ
µ
H I
contadorColumn
µ
µ
I W
)
µ
µ
W X
,
µ
µ
X Y
Max
µ
µ
Z ]
=
µ
µ
^ _
Convert
µ
µ
` g
.
µ
µ
g h
ToUInt32
µ
µ
h p
(
µ
µ
p q
contadorColumn
µ
µ
q 
)µ
µ
 Ä
,µ
µ
Ä Å
Widthµ
µ
Ç á
=µ
µ
à â
$numµ
µ
ä é
,µ
µ
é è
CustomWidthµ
µ
ê õ
=µ
µ
ú ù
trueµ
µ
û ¢
}µ
µ
£ §
)µ
µ
§ •
;µ
µ
• ¶
contadorColumnµ
µ
ß µ
++µ
µ
µ ∑
;µ
µ
∑ ∏
columnExcel
∂
∂
 
.
∂
∂
 
Append
∂
∂
 "
(
∂
∂
" #
new
∂
∂
# &
Column
∂
∂
' -
(
∂
∂
- .
)
∂
∂
. /
{
∂
∂
0 1
Min
∂
∂
2 5
=
∂
∂
6 7
Convert
∂
∂
8 ?
.
∂
∂
? @
ToUInt32
∂
∂
@ H
(
∂
∂
H I
contadorColumn
∂
∂
I W
)
∂
∂
W X
,
∂
∂
X Y
Max
∂
∂
Z ]
=
∂
∂
^ _
Convert
∂
∂
` g
.
∂
∂
g h
ToUInt32
∂
∂
h p
(
∂
∂
p q
contadorColumn
∂
∂
q 
)∂
∂
 Ä
,∂
∂
Ä Å
Width∂
∂
Ç á
=∂
∂
à â
$num∂
∂
ä é
,∂
∂
é è
CustomWidth∂
∂
ê õ
=∂
∂
ú ù
true∂
∂
û ¢
}∂
∂
£ §
)∂
∂
§ •
;∂
∂
• ¶
contadorColumn∂
∂
ß µ
++∂
∂
µ ∑
;∂
∂
∑ ∏
columnExcel
∑
∑
 
.
∑
∑
 
Append
∑
∑
 "
(
∑
∑
" #
new
∑
∑
# &
Column
∑
∑
' -
(
∑
∑
- .
)
∑
∑
. /
{
∑
∑
0 1
Min
∑
∑
2 5
=
∑
∑
6 7
Convert
∑
∑
8 ?
.
∑
∑
? @
ToUInt32
∑
∑
@ H
(
∑
∑
H I
contadorColumn
∑
∑
I W
)
∑
∑
W X
,
∑
∑
X Y
Max
∑
∑
Z ]
=
∑
∑
^ _
Convert
∑
∑
` g
.
∑
∑
g h
ToUInt32
∑
∑
h p
(
∑
∑
p q
contadorColumn
∑
∑
q 
)∑
∑
 Ä
,∑
∑
Ä Å
Width∑
∑
Ç á
=∑
∑
à â
$num∑
∑
ä é
,∑
∑
é è
CustomWidth∑
∑
ê õ
=∑
∑
ú ù
true∑
∑
û ¢
}∑
∑
£ §
)∑
∑
§ •
;∑
∑
• ¶
contadorColumn∑
∑
ß µ
++∑
∑
µ ∑
;∑
∑
∑ ∏
columnExcel
∏
∏
 
.
∏
∏
 
Append
∏
∏
 "
(
∏
∏
" #
new
∏
∏
# &
Column
∏
∏
' -
(
∏
∏
- .
)
∏
∏
. /
{
∏
∏
0 1
Min
∏
∏
2 5
=
∏
∏
6 7
Convert
∏
∏
8 ?
.
∏
∏
? @
ToUInt32
∏
∏
@ H
(
∏
∏
H I
contadorColumn
∏
∏
I W
)
∏
∏
W X
,
∏
∏
X Y
Max
∏
∏
Z ]
=
∏
∏
^ _
Convert
∏
∏
` g
.
∏
∏
g h
ToUInt32
∏
∏
h p
(
∏
∏
p q
contadorColumn
∏
∏
q 
)∏
∏
 Ä
,∏
∏
Ä Å
Width∏
∏
Ç á
=∏
∏
à â
$num∏
∏
ä é
,∏
∏
é è
CustomWidth∏
∏
ê õ
=∏
∏
ú ù
true∏
∏
û ¢
}∏
∏
£ §
)∏
∏
§ •
;∏
∏
• ¶
contadorColumn∏
∏
ß µ
++∏
∏
µ ∑
;∏
∏
∑ ∏
columnExcel
π
π
 
.
π
π
 
Append
π
π
 "
(
π
π
" #
new
π
π
# &
Column
π
π
' -
(
π
π
- .
)
π
π
. /
{
π
π
0 1
Min
π
π
2 5
=
π
π
6 7
Convert
π
π
8 ?
.
π
π
? @
ToUInt32
π
π
@ H
(
π
π
H I
contadorColumn
π
π
I W
)
π
π
W X
,
π
π
X Y
Max
π
π
Z ]
=
π
π
^ _
Convert
π
π
` g
.
π
π
g h
ToUInt32
π
π
h p
(
π
π
p q
contadorColumn
π
π
q 
)π
π
 Ä
,π
π
Ä Å
Widthπ
π
Ç á
=π
π
à â
$numπ
π
ä é
,π
π
é è
CustomWidthπ
π
ê õ
=π
π
ú ù
trueπ
π
û ¢
}π
π
£ §
)π
π
§ •
;π
π
• ¶
contadorColumnπ
π
ß µ
++π
π
µ ∑
;π
π
∑ ∏
columnExcel
∫
∫
 
.
∫
∫
 
Append
∫
∫
 "
(
∫
∫
" #
new
∫
∫
# &
Column
∫
∫
' -
(
∫
∫
- .
)
∫
∫
. /
{
∫
∫
0 1
Min
∫
∫
2 5
=
∫
∫
6 7
Convert
∫
∫
8 ?
.
∫
∫
? @
ToUInt32
∫
∫
@ H
(
∫
∫
H I
contadorColumn
∫
∫
I W
)
∫
∫
W X
,
∫
∫
X Y
Max
∫
∫
Z ]
=
∫
∫
^ _
Convert
∫
∫
` g
.
∫
∫
g h
ToUInt32
∫
∫
h p
(
∫
∫
p q
contadorColumn
∫
∫
q 
)∫
∫
 Ä
,∫
∫
Ä Å
Width∫
∫
Ç á
=∫
∫
à â
$num∫
∫
ä é
,∫
∫
é è
CustomWidth∫
∫
ê õ
=∫
∫
ú ù
true∫
∫
û ¢
}∫
∫
£ §
)∫
∫
§ •
;∫
∫
• ¶
contadorColumn∫
∫
ß µ
++∫
∫
µ ∑
;∫
∫
∑ ∏
columnExcel
ª
ª
 
.
ª
ª
 
Append
ª
ª
 "
(
ª
ª
" #
new
ª
ª
# &
Column
ª
ª
' -
(
ª
ª
- .
)
ª
ª
. /
{
ª
ª
0 1
Min
ª
ª
2 5
=
ª
ª
6 7
Convert
ª
ª
8 ?
.
ª
ª
? @
ToUInt32
ª
ª
@ H
(
ª
ª
H I
contadorColumn
ª
ª
I W
)
ª
ª
W X
,
ª
ª
X Y
Max
ª
ª
Z ]
=
ª
ª
^ _
Convert
ª
ª
` g
.
ª
ª
g h
ToUInt32
ª
ª
h p
(
ª
ª
p q
contadorColumn
ª
ª
q 
)ª
ª
 Ä
,ª
ª
Ä Å
Widthª
ª
Ç á
=ª
ª
à â
$numª
ª
ä é
,ª
ª
é è
CustomWidthª
ª
ê õ
=ª
ª
ú ù
trueª
ª
û ¢
}ª
ª
£ §
)ª
ª
§ •
;ª
ª
• ¶
contadorColumnª
ª
ß µ
++ª
ª
µ ∑
;ª
ª
∑ ∏
columnExcel
º
º
 
.
º
º
 
Append
º
º
 "
(
º
º
" #
new
º
º
# &
Column
º
º
' -
(
º
º
- .
)
º
º
. /
{
º
º
0 1
Min
º
º
2 5
=
º
º
6 7
Convert
º
º
8 ?
.
º
º
? @
ToUInt32
º
º
@ H
(
º
º
H I
contadorColumn
º
º
I W
)
º
º
W X
,
º
º
X Y
Max
º
º
Z ]
=
º
º
^ _
Convert
º
º
` g
.
º
º
g h
ToUInt32
º
º
h p
(
º
º
p q
contadorColumn
º
º
q 
)º
º
 Ä
,º
º
Ä Å
Widthº
º
Ç á
=º
º
à â
$numº
º
ä é
,º
º
é è
CustomWidthº
º
ê õ
=º
º
ú ù
trueº
º
û ¢
}º
º
£ §
)º
º
§ •
;º
º
• ¶
contadorColumnº
º
ß µ
++º
º
µ ∑
;º
º
∑ ∏
wsPart
≈
≈
 
.
≈
≈
 
	Worksheet
≈
≈
  
.
≈
≈
  !
Append
≈
≈
! '
(
≈
≈
' (
columnExcel
≈
≈
( 3
)
≈
≈
3 4
;
≈
≈
4 5
var
«
«
 
	sheetData
«
«
 
=
«
«
 
wsPart
«
«
  &
.
«
«
& '
	Worksheet
«
«
' 0
.
«
«
0 1
AppendChild
«
«
1 <
(
«
«
< =
new
«
«
= @
	SheetData
«
«
A J
(
«
«
J K
)
«
«
K L
)
«
«
L M
;
«
«
M N
DocumentFormat
 
 
 
.
 
 
 
OpenXml
 
 
 &
.
 
 
& '
Spreadsheet
 
 
' 2
.
 
 
2 3
Row
 
 
3 6
	headerRow
 
 
7 @
=
 
 
A B
new
 
 
C F
DocumentFormat
 
 
G U
.
 
 
U V
OpenXml
 
 
V ]
.
 
 
] ^
Spreadsheet
 
 
^ i
.
 
 
i j
Row
 
 
j m
(
 
 
m n
)
 
 
n o
;
 
 
o p
List
À
À
 
<
À
À
 
String
À
À
 
>
À
À
 
columns
À
À
 $
=
À
À
% &
new
À
À
' *
List
À
À
+ /
<
À
À
/ 0
string
À
À
0 6
>
À
À
6 7
(
À
À
7 8
)
À
À
8 9
;
À
À
9 :
foreach
Ã
Ã
 
(
Ã
Ã
 

DataColumn
Ã
Ã
 #
column
Ã
Ã
$ *
in
Ã
Ã
+ -
table
Ã
Ã
. 3
.
Ã
Ã
3 4
Columns
Ã
Ã
4 ;
)
Ã
Ã
; <
{
Õ
Õ
 
columns
Œ
Œ
 
.
Œ
Œ
 
Add
Œ
Œ
 
(
Œ
Œ
  
column
Œ
Œ
  &
.
Œ
Œ
& '

ColumnName
Œ
Œ
' 1
)
Œ
Œ
1 2
;
Œ
Œ
2 3
DocumentFormat
–
–
 "
.
–
–
" #
OpenXml
–
–
# *
.
–
–
* +
Spreadsheet
–
–
+ 6
.
–
–
6 7
Cell
–
–
7 ;
cell
–
–
< @
=
–
–
A B
new
–
–
C F
DocumentFormat
–
–
G U
.
–
–
U V
OpenXml
–
–
V ]
.
–
–
] ^
Spreadsheet
–
–
^ i
.
–
–
i j
Cell
–
–
j n
(
–
–
n o
)
–
–
o p
;
–
–
p q
cell
“
“
 
.
“
“
 
DataType
“
“
 !
=
“
“
" #
DocumentFormat
“
“
$ 2
.
“
“
2 3
OpenXml
“
“
3 :
.
“
“
: ;
Spreadsheet
“
“
; F
.
“
“
F G

CellValues
“
“
G Q
.
“
“
Q R
String
“
“
R X
;
“
“
X Y
cell
”
”
 
.
”
”
 
	CellValue
”
”
 "
=
”
”
# $
new
”
”
% (
DocumentFormat
”
”
) 7
.
”
”
7 8
OpenXml
”
”
8 ?
.
”
”
? @
Spreadsheet
”
”
@ K
.
”
”
K L
	CellValue
”
”
L U
(
”
”
U V
column
”
”
V \
.
”
”
\ ]

ColumnName
”
”
] g
)
”
”
g h
;
”
”
h i
cell
‘
‘
 
.
‘
‘
 

StyleIndex
‘
‘
 #
=
‘
‘
$ %
$num
‘
‘
& '
;
‘
‘
' (
	headerRow
’
’
 
.
’
’
 
AppendChild
’
’
 )
(
’
’
) *
cell
’
’
* .
)
’
’
. /
;
’
’
/ 0
}
÷
÷
 
	sheetData
◊
◊
 
.
◊
◊
 
AppendChild
◊
◊
 %
(
◊
◊
% &
	headerRow
◊
◊
& /
)
◊
◊
/ 0
;
◊
◊
0 1
foreach
Ÿ
Ÿ
 
(
Ÿ
Ÿ
 
DataRow
Ÿ
Ÿ
  
dsrow
Ÿ
Ÿ
! &
in
Ÿ
Ÿ
' )
table
Ÿ
Ÿ
* /
.
Ÿ
Ÿ
/ 0
Rows
Ÿ
Ÿ
0 4
)
Ÿ
Ÿ
4 5
{
⁄
⁄
 
DocumentFormat
€
€
 "
.
€
€
" #
OpenXml
€
€
# *
.
€
€
* +
Spreadsheet
€
€
+ 6
.
€
€
6 7
Row
€
€
7 :
newRow
€
€
; A
=
€
€
B C
new
€
€
D G
DocumentFormat
€
€
H V
.
€
€
V W
OpenXml
€
€
W ^
.
€
€
^ _
Spreadsheet
€
€
_ j
.
€
€
j k
Row
€
€
k n
(
€
€
n o
)
€
€
o p
;
€
€
p q
foreach
‹
‹
 
(
‹
‹
 
String
‹
‹
 #
col
‹
‹
$ '
in
‹
‹
( *
columns
‹
‹
+ 2
)
‹
‹
2 3
{
›
›
 
DocumentFormat
ﬁ
ﬁ
 &
.
ﬁ
ﬁ
& '
OpenXml
ﬁ
ﬁ
' .
.
ﬁ
ﬁ
. /
Spreadsheet
ﬁ
ﬁ
/ :
.
ﬁ
ﬁ
: ;
Cell
ﬁ
ﬁ
; ?
cell
ﬁ
ﬁ
@ D
=
ﬁ
ﬁ
E F
new
ﬁ
ﬁ
G J
DocumentFormat
ﬁ
ﬁ
K Y
.
ﬁ
ﬁ
Y Z
OpenXml
ﬁ
ﬁ
Z a
.
ﬁ
ﬁ
a b
Spreadsheet
ﬁ
ﬁ
b m
.
ﬁ
ﬁ
m n
Cell
ﬁ
ﬁ
n r
(
ﬁ
ﬁ
r s
)
ﬁ
ﬁ
s t
;
ﬁ
ﬁ
t u
if
Ê
Ê
 
(
Ê
Ê
 
columnasfecha
Ê
Ê
 )
.
Ê
Ê
) *
Contains
Ê
Ê
* 2
(
Ê
Ê
2 3
col
Ê
Ê
3 6
)
Ê
Ê
6 7
)
Ê
Ê
7 8
{
Á
Á
 
DateTime
È
È
 $
celdadt
È
È
% ,
=
È
È
- .
DateTime
È
È
/ 7
.
È
È
7 8
Parse
È
È
8 =
(
È
È
= >
dsrow
È
È
> C
[
È
È
C D
col
È
È
D G
]
È
È
G H
.
È
È
H I
ToString
È
È
I Q
(
È
È
Q R
)
È
È
R S
)
È
È
S T
;
È
È
T U
string
Í
Í
 "
valueString
Í
Í
# .
=
Í
Í
/ 0
celdadt
Í
Í
1 8
.
Í
Í
8 9
ToOADate
Í
Í
9 A
(
Í
Í
A B
)
Í
Í
B C
.
Í
Í
C D
ToString
Í
Í
D L
(
Í
Í
L M
)
Í
Í
M N
;
Í
Í
N O
	CellValue
Î
Î
 %
	cellValue
Î
Î
& /
=
Î
Î
0 1
new
Î
Î
2 5
	CellValue
Î
Î
6 ?
(
Î
Î
? @
valueString
Î
Î
@ K
)
Î
Î
K L
;
Î
Î
L M
cell
Ï
Ï
  
.
Ï
Ï
  !
DataType
Ï
Ï
! )
=
Ï
Ï
* +
new
Ï
Ï
, /
	EnumValue
Ï
Ï
0 9
<
Ï
Ï
9 :

CellValues
Ï
Ï
: D
>
Ï
Ï
D E
(
Ï
Ï
E F

CellValues
Ï
Ï
F P
.
Ï
Ï
P Q
Number
Ï
Ï
Q W
)
Ï
Ï
W X
;
Ï
Ï
X Y
cell
Ì
Ì
  
.
Ì
Ì
  !

StyleIndex
Ì
Ì
! +
=
Ì
Ì
, -
$num
Ì
Ì
. /
;
Ì
Ì
/ 0
cell
Ó
Ó
  
.
Ó
Ó
  !
Append
Ó
Ó
! '
(
Ó
Ó
' (
	cellValue
Ó
Ó
( 1
)
Ó
Ó
1 2
;
Ó
Ó
2 3
}
Ô
Ô
 
else


 
if


 
(


  !
columnasmonto


! .
.


. /
Contains


/ 7
(


7 8
col


8 ;
)


; <
)


< =
{
Ò
Ò
 
cell
Ú
Ú
  
.
Ú
Ú
  !
DataType
Ú
Ú
! )
=
Ú
Ú
* +
DocumentFormat
Ú
Ú
, :
.
Ú
Ú
: ;
OpenXml
Ú
Ú
; B
.
Ú
Ú
B C
Spreadsheet
Ú
Ú
C N
.
Ú
Ú
N O

CellValues
Ú
Ú
O Y
.
Ú
Ú
Y Z
Number
Ú
Ú
Z `
;
Ú
Ú
` a
cell
Û
Û
  
.
Û
Û
  !
	CellValue
Û
Û
! *
=
Û
Û
+ ,
new
Û
Û
- 0
DocumentFormat
Û
Û
1 ?
.
Û
Û
? @
OpenXml
Û
Û
@ G
.
Û
Û
G H
Spreadsheet
Û
Û
H S
.
Û
Û
S T
	CellValue
Û
Û
T ]
(
Û
Û
] ^
dsrow
Û
Û
^ c
[
Û
Û
c d
col
Û
Û
d g
]
Û
Û
g h
.
Û
Û
h i
ToString
Û
Û
i q
(
Û
Û
q r
)
Û
Û
r s
)
Û
Û
s t
;
Û
Û
t u
cell
Ù
Ù
  
.
Ù
Ù
  !

StyleIndex
Ù
Ù
! +
=
Ù
Ù
, -
$num
Ù
Ù
. /
;
Ù
Ù
/ 0
}
ı
ı
 
else
ˆ
ˆ
 
if
ˆ
ˆ
 
(
ˆ
ˆ
  !
columnasstring
ˆ
ˆ
! /
.
ˆ
ˆ
/ 0
Contains
ˆ
ˆ
0 8
(
ˆ
ˆ
8 9
col
ˆ
ˆ
9 <
)
ˆ
ˆ
< =
)
ˆ
ˆ
= >
{
˜
˜
 
cell
˘
˘
  
.
˘
˘
  !

StyleIndex
˘
˘
! +
=
˘
˘
, -
$num
˘
˘
. /
;
˘
˘
/ 0
cell
˙
˙
  
.
˙
˙
  !
DataType
˙
˙
! )
=
˙
˙
* +
DocumentFormat
˙
˙
, :
.
˙
˙
: ;
OpenXml
˙
˙
; B
.
˙
˙
B C
Spreadsheet
˙
˙
C N
.
˙
˙
N O

CellValues
˙
˙
O Y
.
˙
˙
Y Z
String
˙
˙
Z `
;
˙
˙
` a
cell
˚
˚
  
.
˚
˚
  !
	CellValue
˚
˚
! *
=
˚
˚
+ ,
new
˚
˚
- 0
DocumentFormat
˚
˚
1 ?
.
˚
˚
? @
OpenXml
˚
˚
@ G
.
˚
˚
G H
Spreadsheet
˚
˚
H S
.
˚
˚
S T
	CellValue
˚
˚
T ]
(
˚
˚
] ^
dsrow
˚
˚
^ c
[
˚
˚
c d
col
˚
˚
d g
]
˚
˚
g h
.
˚
˚
h i
ToString
˚
˚
i q
(
˚
˚
q r
)
˚
˚
r s
)
˚
˚
s t
;
˚
˚
t u
}
¸
¸
 
else
˝
˝
 
if
˝
˝
 
(
˝
˝
  !
col
˝
˝
! $
.
˝
˝
$ %
Contains
˝
˝
% -
(
˝
˝
- .
$str
˝
˝
. B
)
˝
˝
B C
)
˝
˝
C D
{
˛
˛
 
string
ˇ
ˇ
 "
valorsemaforo
ˇ
ˇ
# 0
=
ˇ
ˇ
1 2
dsrow
ˇ
ˇ
3 8
[
ˇ
ˇ
8 9
col
ˇ
ˇ
9 <
]
ˇ
ˇ
< =
.
ˇ
ˇ
= >
ToString
ˇ
ˇ
> F
(
ˇ
ˇ
F G
)
ˇ
ˇ
G H
;
ˇ
ˇ
H I
if
ÅÅ 
(
ÅÅ  
valorsemaforo
ÅÅ  -
==
ÅÅ. 0
$str
ÅÅ1 6
)
ÅÅ6 7
{
ÇÇ 
cell
ÉÉ  $
.
ÉÉ$ %

StyleIndex
ÉÉ% /
=
ÉÉ0 1
$num
ÉÉ2 3
;
ÉÉ3 4
}
ÑÑ 
else
ÖÖ  
if
ÖÖ! #
(
ÖÖ$ %
valorsemaforo
ÖÖ% 2
==
ÖÖ3 5
$str
ÖÖ6 ;
)
ÖÖ; <
{
ÜÜ 
cell
áá  $
.
áá$ %

StyleIndex
áá% /
=
áá0 1
$num
áá2 3
;
áá3 4
}
àà 
else
ââ  
if
ââ! #
(
ââ$ %
valorsemaforo
ââ% 2
==
ââ3 5
$str
ââ6 ;
)
ââ; <
{
ää 
cell
ãã  $
.
ãã$ %

StyleIndex
ãã% /
=
ãã0 1
$num
ãã2 3
;
ãã3 4
}
åå 
else
çç  
if
çç! #
(
çç$ %
valorsemaforo
çç% 2
==
çç3 5
$str
çç6 ;
)
çç; <
{
éé 
cell
èè  $
.
èè$ %

StyleIndex
èè% /
=
èè0 1
$num
èè2 3
;
èè3 4
}
êê 
else
ëë  
{
íí 
cell
ìì  $
.
ìì$ %

StyleIndex
ìì% /
=
ìì0 1
$num
ìì2 4
;
ìì4 5
}
îî 
cell
ññ  
.
ññ  !
DataType
ññ! )
=
ññ* +
DocumentFormat
ññ, :
.
ññ: ;
OpenXml
ññ; B
.
ññB C
Spreadsheet
ññC N
.
ññN O

CellValues
ññO Y
.
ññY Z
String
ññZ `
;
ññ` a
cell
óó  
.
óó  !
	CellValue
óó! *
=
óó+ ,
new
óó- 0
DocumentFormat
óó1 ?
.
óó? @
OpenXml
óó@ G
.
óóG H
Spreadsheet
óóH S
.
óóS T
	CellValue
óóT ]
(
óó] ^
valorsemaforo
óó^ k
)
óók l
;
óól m
}
òò 
else
ôô 
if
ôô 
(
ôô  !
columnassemaforos
ôô! 2
.
ôô2 3
Contains
ôô3 ;
(
ôô; <
col
ôô< ?
)
ôô? @
)
ôô@ A
{
ôôB C
cell
öö  
.
öö  !

StyleIndex
öö! +
=
öö, -
$num
öö. 0
;
öö0 1
cell
õõ  
.
õõ  !
DataType
õõ! )
=
õõ* +
DocumentFormat
õõ, :
.
õõ: ;
OpenXml
õõ; B
.
õõB C
Spreadsheet
õõC N
.
õõN O

CellValues
õõO Y
.
õõY Z
String
õõZ `
;
õõ` a
cell
úú  
.
úú  !
	CellValue
úú! *
=
úú+ ,
new
úú- 0
DocumentFormat
úú1 ?
.
úú? @
OpenXml
úú@ G
.
úúG H
Spreadsheet
úúH S
.
úúS T
	CellValue
úúT ]
(
úú] ^
dsrow
úú^ c
[
úúc d
col
úúd g
]
úúg h
.
úúh i
ToString
úúi q
(
úúq r
)
úúr s
)
úús t
;
úút u
}
ùù 
else
ûû 
{
üü 
cell
°°  
.
°°  !

StyleIndex
°°! +
=
°°, -
$num
°°. /
;
°°/ 0
cell
¢¢  
.
¢¢  !
DataType
¢¢! )
=
¢¢* +
DocumentFormat
¢¢, :
.
¢¢: ;
OpenXml
¢¢; B
.
¢¢B C
Spreadsheet
¢¢C N
.
¢¢N O

CellValues
¢¢O Y
.
¢¢Y Z
String
¢¢Z `
;
¢¢` a
cell
££  
.
££  !
	CellValue
££! *
=
££+ ,
new
££- 0
DocumentFormat
££1 ?
.
££? @
OpenXml
££@ G
.
££G H
Spreadsheet
££H S
.
££S T
	CellValue
££T ]
(
££] ^
dsrow
££^ c
[
££c d
col
££d g
]
££g h
.
££h i
ToString
££i q
(
££q r
)
££r s
)
££s t
;
££t u
}
§§ 
newRow
®® 
.
®® 
AppendChild
®® *
(
®®* +
cell
®®+ /
)
®®/ 0
;
®®0 1
}
™™ 
	sheetData
´´ 
.
´´ 
AppendChild
´´ )
(
´´) *
newRow
´´* 0
)
´´0 1
;
´´1 2
}
¨¨ 
wsPart
ÆÆ 
.
ÆÆ 
	Worksheet
ÆÆ  
.
ÆÆ  !
Save
ÆÆ! %
(
ÆÆ% &
)
ÆÆ& '
;
ÆÆ' (
var
∞∞ 
sheets
∞∞ 
=
∞∞ 
spreadsheet
∞∞ (
.
∞∞( )
WorkbookPart
∞∞) 5
.
∞∞5 6
Workbook
∞∞6 >
.
∞∞> ?
AppendChild
∞∞? J
(
∞∞J K
new
∞∞K N
Sheets
∞∞O U
(
∞∞U V
)
∞∞V W
)
∞∞W X
;
∞∞X Y
sheets
±± 
.
±± 
AppendChild
±± "
(
±±" #
new
±±# &
Sheet
±±' ,
(
±±, -
)
±±- .
{
±±/ 0
Id
±±1 3
=
±±4 5
spreadsheet
±±6 A
.
±±A B
WorkbookPart
±±B N
.
±±N O
GetIdOfPart
±±O Z
(
±±Z [
wsPart
±±[ a
)
±±a b
,
±±b c
SheetId
±±d k
=
±±l m
$num
±±n o
,
±±o p
Name
±±q u
=
±±v w
$str±±x è
}±±ê ë
)±±ë í
;±±í ì
spreadsheet
≥≥ 
.
≥≥ 
WorkbookPart
≥≥ (
.
≥≥( )
Workbook
≥≥) 1
.
≥≥1 2
Save
≥≥2 6
(
≥≥6 7
)
≥≥7 8
;
≥≥8 9
}
µµ 
}
∂∂ 	
public
∫∫ 
static
∫∫ 
void
∫∫ 
	AddToCell
∫∫ $
(
∫∫$ %
	SheetData
∫∫% .
	sheetData
∫∫/ 8
,
∫∫8 9
UInt32Value
∫∫: E

styleIndex
∫∫F P
,
∫∫P Q
UInt32
∫∫R X
uint32rowIndex
∫∫Y g
,
∫∫g h
string
∫∫i o
strColumnName
∫∫p }
,
∫∫} ~
DocumentFormat∫∫ ç
.∫∫ç é
OpenXml∫∫é ï
.∫∫ï ñ
	EnumValue∫∫ñ ü
<∫∫ü †

CellValues∫∫† ™
>∫∫™ ´
CellDataType∫∫¨ ∏
,∫∫∏ π
string∫∫∫ ¿
strCellValue∫∫¡ Õ
)∫∫Õ Œ
{
ªª 	
Row
ºº 
row
ºº 
=
ºº 
new
ºº 
Row
ºº 
(
ºº 
)
ºº 
{
ºº  !
RowIndex
ºº" *
=
ºº+ ,
uint32rowIndex
ºº- ;
}
ºº< =
;
ºº= >
Cell
ΩΩ 
cell
ΩΩ 
=
ΩΩ 
new
ΩΩ 
Cell
ΩΩ  
(
ΩΩ  !
)
ΩΩ! "
;
ΩΩ" #
cell
øø 
=
øø 
new
øø 
Cell
øø 
(
øø 
)
øø 
{
øø 

StyleIndex
øø  *
=
øø+ ,

styleIndex
øø- 7
}
øø8 9
;
øø9 :
cell
¿¿ 
.
¿¿ 
CellReference
¿¿ 
=
¿¿  
strColumnName
¿¿! .
+
¿¿/ 0
row
¿¿1 4
.
¿¿4 5
RowIndex
¿¿5 =
.
¿¿= >
ToString
¿¿> F
(
¿¿F G
)
¿¿G H
;
¿¿H I
cell
¡¡ 
.
¡¡ 
DataType
¡¡ 
=
¡¡ 
CellDataType
¡¡ (
;
¡¡( )
cell
¬¬ 
.
¬¬ 
	CellValue
¬¬ 
=
¬¬ 
new
¬¬  
	CellValue
¬¬! *
(
¬¬* +
strCellValue
¬¬+ 7
)
¬¬7 8
;
¬¬8 9
row
√√ 
.
√√ 
AppendChild
√√ 
(
√√ 
cell
√√  
)
√√  !
;
√√! "
	sheetData
≈≈ 
.
≈≈ 
Append
≈≈ 
(
≈≈ 
row
≈≈  
)
≈≈  !
;
≈≈! "
}
∆∆ 	
public
   
static
   
void
   
	ReadExcel
   $
(
  $ %
string
  % +
path
  , 0
,
  0 1
DataSet
  2 9
ds
  : <
)
  < =
{
ÀÀ 	
using
ÃÃ 
(
ÃÃ 

FileStream
ÃÃ 
fs
ÃÃ  
=
ÃÃ! "
new
ÃÃ# &

FileStream
ÃÃ' 1
(
ÃÃ1 2
path
ÃÃ2 6
,
ÃÃ6 7
FileMode
ÃÃ8 @
.
ÃÃ@ A
Open
ÃÃA E
,
ÃÃE F

FileAccess
ÃÃG Q
.
ÃÃQ R
Read
ÃÃR V
,
ÃÃV W
	FileShare
ÃÃX a
.
ÃÃa b
	ReadWrite
ÃÃb k
)
ÃÃk l
)
ÃÃl m
{
ÕÕ 
using
ŒŒ 
(
ŒŒ !
SpreadsheetDocument
ŒŒ *
doc
ŒŒ+ .
=
ŒŒ/ 0!
SpreadsheetDocument
ŒŒ1 D
.
ŒŒD E
Open
ŒŒE I
(
ŒŒI J
fs
ŒŒJ L
,
ŒŒL M
false
ŒŒN S
)
ŒŒS T
)
ŒŒT U
{
œœ 
WorkbookPart
––  
workbookPart
––! -
=
––. /
doc
––0 3
.
––3 4
WorkbookPart
––4 @
;
––@ A#
SharedStringTablePart
—— )
sstpart
——* 1
=
——2 3
workbookPart
——4 @
.
——@ A
GetPartsOfType
——A O
<
——O P#
SharedStringTablePart
——P e
>
——e f
(
——f g
)
——g h
.
——h i
First
——i n
(
——n o
)
——o p
;
——p q
SharedStringTable
““ %
sst
““& )
=
““* +
sstpart
““, 3
.
““3 4
SharedStringTable
““4 E
;
““E F
WorksheetPart
‘‘ !
worksheetPart
‘‘" /
=
‘‘0 1
workbookPart
‘‘2 >
.
‘‘> ?
WorksheetParts
‘‘? M
.
‘‘M N
First
‘‘N S
(
‘‘S T
)
‘‘T U
;
‘‘U V
	Worksheet
’’ 
sheet
’’ #
=
’’$ %
worksheetPart
’’& 3
.
’’3 4
	Worksheet
’’4 =
;
’’= >
var
◊◊ 
cells
◊◊ 
=
◊◊ 
sheet
◊◊  %
.
◊◊% &
Descendants
◊◊& 1
<
◊◊1 2
Cell
◊◊2 6
>
◊◊6 7
(
◊◊7 8
)
◊◊8 9
;
◊◊9 :
var
ÿÿ 
rows
ÿÿ 
=
ÿÿ 
sheet
ÿÿ $
.
ÿÿ$ %
Descendants
ÿÿ% 0
<
ÿÿ0 1
Row
ÿÿ1 4
>
ÿÿ4 5
(
ÿÿ5 6
)
ÿÿ6 7
;
ÿÿ7 8
Console
⁄⁄ 
.
⁄⁄ 
	WriteLine
⁄⁄ %
(
⁄⁄% &
$str
⁄⁄& 7
,
⁄⁄7 8
rows
⁄⁄9 =
.
⁄⁄= >
	LongCount
⁄⁄> G
(
⁄⁄G H
)
⁄⁄H I
)
⁄⁄I J
;
⁄⁄J K
Console
€€ 
.
€€ 
	WriteLine
€€ %
(
€€% &
$str
€€& 8
,
€€8 9
cells
€€: ?
.
€€? @
	LongCount
€€@ I
(
€€I J
)
€€J K
)
€€K L
;
€€L M
foreach
ﬁﬁ 
(
ﬁﬁ 
Cell
ﬁﬁ !
cell
ﬁﬁ" &
in
ﬁﬁ' )
cells
ﬁﬁ* /
)
ﬁﬁ/ 0
{
ﬂﬂ 
if
‡‡ 
(
‡‡ 
(
‡‡ 
cell
‡‡ !
.
‡‡! "
DataType
‡‡" *
!=
‡‡+ -
null
‡‡. 2
)
‡‡2 3
&&
‡‡4 6
(
‡‡7 8
cell
‡‡8 <
.
‡‡< =
DataType
‡‡= E
==
‡‡F H

CellValues
‡‡I S
.
‡‡S T
SharedString
‡‡T `
)
‡‡` a
)
‡‡a b
{
·· 
int
‚‚ 
ssid
‚‚  $
=
‚‚% &
int
‚‚' *
.
‚‚* +
Parse
‚‚+ 0
(
‚‚0 1
cell
‚‚1 5
.
‚‚5 6
	CellValue
‚‚6 ?
.
‚‚? @
Text
‚‚@ D
)
‚‚D E
;
‚‚E F
string
„„ "
str
„„# &
=
„„' (
sst
„„) ,
.
„„, -
ChildElements
„„- :
[
„„: ;
ssid
„„; ?
]
„„? @
.
„„@ A
	InnerText
„„A J
;
„„J K
Console
‰‰ #
.
‰‰# $
	WriteLine
‰‰$ -
(
‰‰- .
$str
‰‰. F
,
‰‰F G
ssid
‰‰H L
,
‰‰L M
str
‰‰N Q
)
‰‰Q R
;
‰‰R S
}
ÂÂ 
else
ÊÊ 
if
ÊÊ 
(
ÊÊ  !
cell
ÊÊ! %
.
ÊÊ% &
	CellValue
ÊÊ& /
!=
ÊÊ0 2
null
ÊÊ3 7
)
ÊÊ7 8
{
ÁÁ 
Console
ËË #
.
ËË# $
	WriteLine
ËË$ -
(
ËË- .
$str
ËË. B
,
ËËB C
cell
ËËD H
.
ËËH I
	CellValue
ËËI R
.
ËËR S
Text
ËËS W
)
ËËW X
;
ËËX Y
}
ÈÈ 
}
ÍÍ 
foreach
ÌÌ 
(
ÌÌ 
Row
ÌÌ  
row
ÌÌ! $
in
ÌÌ% '
rows
ÌÌ( ,
)
ÌÌ, -
{
ÓÓ 
foreach
ÔÔ 
(
ÔÔ  !
Cell
ÔÔ! %
c
ÔÔ& '
in
ÔÔ( *
row
ÔÔ+ .
.
ÔÔ. /
Elements
ÔÔ/ 7
<
ÔÔ7 8
Cell
ÔÔ8 <
>
ÔÔ< =
(
ÔÔ= >
)
ÔÔ> ?
)
ÔÔ? @
{
 
if
ÒÒ 
(
ÒÒ  
(
ÒÒ  !
c
ÒÒ! "
.
ÒÒ" #
DataType
ÒÒ# +
!=
ÒÒ, .
null
ÒÒ/ 3
)
ÒÒ3 4
&&
ÒÒ5 7
(
ÒÒ8 9
c
ÒÒ9 :
.
ÒÒ: ;
DataType
ÒÒ; C
==
ÒÒD F

CellValues
ÒÒG Q
.
ÒÒQ R
SharedString
ÒÒR ^
)
ÒÒ^ _
)
ÒÒ_ `
{
ÚÚ 
int
ÛÛ  #
ssid
ÛÛ$ (
=
ÛÛ) *
int
ÛÛ+ .
.
ÛÛ. /
Parse
ÛÛ/ 4
(
ÛÛ4 5
c
ÛÛ5 6
.
ÛÛ6 7
	CellValue
ÛÛ7 @
.
ÛÛ@ A
Text
ÛÛA E
)
ÛÛE F
;
ÛÛF G
string
ÙÙ  &
str
ÙÙ' *
=
ÙÙ+ ,
sst
ÙÙ- 0
.
ÙÙ0 1
ChildElements
ÙÙ1 >
[
ÙÙ> ?
ssid
ÙÙ? C
]
ÙÙC D
.
ÙÙD E
	InnerText
ÙÙE N
;
ÙÙN O
Console
ıı  '
.
ıı' (
	WriteLine
ıı( 1
(
ıı1 2
$str
ıı2 J
,
ııJ K
ssid
ııL P
,
ııP Q
str
ııR U
)
ııU V
;
ııV W
}
ˆˆ 
else
˜˜  
if
˜˜! #
(
˜˜$ %
c
˜˜% &
.
˜˜& '
	CellValue
˜˜' 0
!=
˜˜1 3
null
˜˜4 8
)
˜˜8 9
{
¯¯ 
Console
˘˘  '
.
˘˘' (
	WriteLine
˘˘( 1
(
˘˘1 2
$str
˘˘2 F
,
˘˘F G
c
˘˘H I
.
˘˘I J
	CellValue
˘˘J S
.
˘˘S T
Text
˘˘T X
)
˘˘X Y
;
˘˘Y Z
}
˙˙ 
}
˚˚ 
}
¸¸ 
}
˝˝ 
}
˛˛ 
}
ˇˇ 	
public
ÅÅ 
static
ÅÅ 
string
ÅÅ  
MonthByDescription
ÅÅ /
(
ÅÅ/ 0
string
ÅÅ0 6
descriptionMonth
ÅÅ7 G
)
ÅÅG H
{
ÇÇ 	
string
ÉÉ 
_month
ÉÉ 
=
ÉÉ 
string
ÉÉ "
.
ÉÉ" #
Empty
ÉÉ# (
;
ÉÉ( )
switch
ÑÑ 
(
ÑÑ 
descriptionMonth
ÑÑ #
.
ÑÑ# $
ToUpper
ÑÑ$ +
(
ÑÑ+ ,
)
ÑÑ, -
.
ÑÑ- .
Trim
ÑÑ. 2
(
ÑÑ2 3
)
ÑÑ3 4
)
ÑÑ4 5
{
ÖÖ 
case
ÜÜ 
$str
ÜÜ 
:
ÜÜ 
_month
áá 
=
áá 
$str
áá !
;
áá! "
break
àà 
;
àà 
case
ââ 
$str
ââ 
:
ââ 
_month
ää 
=
ää 
$str
ää !
;
ää! "
break
ãã 
;
ãã 
case
åå 
$str
åå 
:
åå 
_month
çç 
=
çç 
$str
çç !
;
çç! "
break
éé 
;
éé 
case
èè 
$str
èè 
:
èè 
_month
êê 
=
êê 
$str
êê !
;
êê! "
break
ëë 
;
ëë 
case
íí 
$str
íí 
:
íí 
_month
ìì 
=
ìì 
$str
ìì !
;
ìì! "
break
îî 
;
îî 
case
ïï 
$str
ïï 
:
ïï 
_month
ññ 
=
ññ 
$str
ññ !
;
ññ! "
break
óó 
;
óó 
case
òò 
$str
òò 
:
òò 
_month
ôô 
=
ôô 
$str
ôô !
;
ôô! "
break
öö 
;
öö 
case
õõ 
$str
õõ 
:
õõ 
_month
úú 
=
úú 
$str
úú !
;
úú! "
break
ùù 
;
ùù 
case
ûû 
$str
ûû  
:
ûû  !
_month
üü 
=
üü 
$str
üü !
;
üü! "
break
†† 
;
†† 
case
°° 
$str
°° !
:
°°! "
_month
¢¢ 
=
¢¢ 
$str
¢¢ !
;
¢¢! "
break
££ 
;
££ 
case
§§ 
$str
§§ 
:
§§ 
_month
•• 
=
•• 
$str
•• !
;
••! "
break
¶¶ 
;
¶¶ 
case
ßß 
$str
ßß  
:
ßß  !
_month
®® 
=
®® 
$str
®® !
;
®®! "
break
©© 
;
©© 
case
™™ 
$str
™™  
:
™™  !
_month
´´ 
=
´´ 
$str
´´ !
;
´´! "
break
¨¨ 
;
¨¨ 
}
≠≠ 
return
ÆÆ 
_month
ÆÆ 
;
ÆÆ 
}
ØØ 	
public
±± 
static
±± 
string
±± 
CleanBase64File
±± ,
(
±±, -
string
±±- 3
base64String
±±4 @
)
±±@ A
{
≤≤ 	
base64String
≥≥ 
=
≥≥ 
base64String
≥≥ '
.
≥≥' (
Replace
≥≥( /
(
≥≥/ 0
$str≥≥0 Ä
,≥≥Ä Å
$str≥≥Ç Ñ
)≥≥Ñ Ö
;≥≥Ö Ü
base64String
¥¥ 
=
¥¥ 
base64String
¥¥ '
.
¥¥' (
Replace
¥¥( /
(
¥¥/ 0
$str¥¥0 Ü
,¥¥Ü á
$str¥¥à ä
)¥¥ä ã
;¥¥ã å
base64String
µµ 
=
µµ 
base64String
µµ '
.
µµ' (
Replace
µµ( /
(
µµ/ 0
$str
µµ0 N
,
µµN O
$str
µµP R
)
µµR S
;
µµS T
base64String
∂∂ 
=
∂∂ 
base64String
∂∂ '
.
∂∂' (
Replace
∂∂( /
(
∂∂/ 0
$str
∂∂0 I
,
∂∂I J
$str
∂∂K M
)
∂∂M N
;
∂∂N O
base64String
∑∑ 
=
∑∑ 
base64String
∑∑ '
.
∑∑' (
Replace
∑∑( /
(
∑∑/ 0
$str
∑∑0 H
,
∑∑H I
$str
∑∑J L
)
∑∑L M
;
∑∑M N
base64String
∏∏ 
=
∏∏ 
base64String
∏∏ '
.
∏∏' (
Replace
∏∏( /
(
∏∏/ 0
$str
∏∏0 W
,
∏∏W X
$str
∏∏Y [
)
∏∏[ \
;
∏∏\ ]
return
ππ 
base64String
ππ 
;
ππ  
}
∫∫ 	
}
ªª 
}ºº ˘
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
} ç
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