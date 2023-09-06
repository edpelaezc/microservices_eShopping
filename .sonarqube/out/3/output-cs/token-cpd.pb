Ý	
w/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.API/Extensions/ServiceExtensions.cs
	namespace 	
Catalog
 
. 
API 
. 

Extensions  
;  !
public 
static 
class 
ServiceExtensions %
{ 
public 

static 
void 
ConfigureCors $
($ %
this% )
IServiceCollection* <
services= E
)E F
=>G I
services 
. 
AddCors 
( 
options  
=>! #
{ 	
options 
. 
	AddPolicy 
( 
$str *
,* +
builder, 3
=>4 6
builder		 
.		 
AllowAnyOrigin		 &
(		& '
)		' (
.

 
AllowAnyMethod

 #
(

# $
)

$ %
. 
AllowAnyHeader #
(# $
)$ %
. 
WithExposedHeaders '
(' (
$str( 6
)6 7
)7 8
;8 9
} 	
)	 

;
 
} ‰
b/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.API/Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. 
ConfigureCors 
( 
)  
;  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsProduction  
(  !
)! "
)" #
{ 
app 
. 
UseHsts 
( 
) 
; 
} 
app 
. 
UseStaticFiles 
( 
) 
; 
app 
. 
UseAuthorization 
( 
) 
; 
app 
. 
MapControllers 
( 
) 
; 
app 
. 
Run 
( 
) 	
;	 
