•
Ä/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Commands/CreateProductCommand.cs
	namespace 	
Catalog
 
. 
Application 
. 
Commands &
;& '
public 
sealed 
record  
CreateProductCommand )
() *!
ProductForCreationDto* ?
product@ G
)G H
:I J
IRequestK S
<S T

ProductDtoT ^
>^ _
;_ `ã
Ä/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Commands/DeleteProductCommand.cs
	namespace 	
Catalog
 
. 
Application 
. 
Commands &
;& '
public 
sealed 
record  
DeleteProductCommand )
() *
string* 0
Id1 3
)3 4
:5 6
IRequest7 ?
<? @
Unit@ D
>D E
;E F“
Ä/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Commands/UpdateProductCommand.cs
	namespace 	
Catalog
 
. 
Application 
. 
Commands &
;& '
public 
sealed 
record  
UpdateProductCommand )
() *
string* 0
Id1 3
,3 4!
ProductForCreationDto5 J
productK R
)R S
:T U
IRequestV ^
<^ _
Unit_ c
>c d
;d e¥
Ä/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/CreateProductHandler.cs
	namespace		 	
Catalog		
 
.		 
Application		 
.		 
Handlers		 &
;		& '
public 
class  
CreateProductHandler !
:" #
IRequestHandler$ 3
<3 4 
CreateProductCommand4 H
,H I

ProductDtoJ T
>T U
{ 
private 
readonly 
IProductRepository '
_repository( 3
;3 4
public 
 
CreateProductHandler 
(  
IProductRepository  2

repository3 =
)= >
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 

ProductDto  
>  !
Handle" (
(( ) 
CreateProductCommand) =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 
var 
productEntity 
= 
CatalogMapper )
.) *
Mapper* 0
.0 1
Map1 4
<4 5
Product5 <
>< =
(= >
request> E
.E F
productF M
)M N
;N O
if 

( 
productEntity 
is 
null !
)! "
{ 	
throw 
new &
ResourceCreationBadRequest 0
(0 1
nameof1 7
(7 8
request8 ?
.? @
product@ G
)G H
)H I
;I J
} 	
await 
_repository 
. 
CreateProduct '
(' (
productEntity( 5
)5 6
;6 7
var 
response 
= 
CatalogMapper $
.$ %
Mapper% +
.+ ,
Map, /
</ 0

ProductDto0 :
>: ;
(; <
productEntity< I
)I J
;J K
return   
response   
;   
}!! 
}"" —
Ä/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/DeleteProductHandler.cs
	namespace 	
Catalog
 
. 
Application 
. 
Handlers &
;& '
public		 
class		  
DeleteProductHandler		 !
:		" #
IRequestHandler		$ 3
<		3 4 
DeleteProductCommand		4 H
,		H I
Unit		J N
>		N O
{

 
private 
readonly 
IProductRepository '
_repository( 3
;3 4
public 
 
DeleteProductHandler 
(  
IProductRepository  2

repository3 =
)= >
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 
Unit 
> 
Handle "
(" # 
DeleteProductCommand# 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
var 
productEntity 
= 
await !
_repository" -
.- .

GetProduct. 8
(8 9
request9 @
.@ A
IdA C
)C D
;D E
if 

( 
productEntity 
is 
null !
)! "
{ 	
throw 
new $
ProductNotFoundException .
(. /
request/ 6
.6 7
Id7 9
)9 :
;: ;
} 	
await 
_repository 
. 
DeleteProduct '
(' (
request( /
./ 0
Id0 2
)2 3
;3 4
return 
Unit 
. 
Value 
; 
} 
} ¿
/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/GetAllBrandsHandler.cs
	namespace		 	
Catalog		
 
.		 
Application		 
.		 
Handlers		 &
;		& '
public 
class 
GetAllBrandsHandler  
:! "
IRequestHandler# 2
<2 3
GetAllBrandsQuery3 D
,D E
IListF K
<K L
BrandDtoL T
>T U
>U V
{ 
private 
readonly 
IBrandRepository %
_repository& 1
;1 2
public 

GetAllBrandsHandler 
( 
IBrandRepository /

repository0 :
): ;
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 
IList 
< 
BrandDto $
>$ %
>% &
Handle' -
(- .
GetAllBrandsQuery. ?
request@ G
,G H
CancellationTokenI Z
cancellationToken[ l
)l m
{ 
var 
brands 
= 
await 
_repository &
.& '
GetAllBrands' 3
(3 4
)4 5
;5 6
var 
response 
= 
CatalogMapper 
. 
Mapper  
.  !
Map 
< 
IList 
< 
ProductBrand "
>" #
,# $
IList% *
<* +
BrandDto+ 3
>3 4
>4 5
(5 6
brands6 <
.< =
ToList= C
(C D
)D E
)E F
;F G
return 
response 
; 
} 
} ÷
Å/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/GetAllProductsHandler.cs
	namespace 	
Catalog
 
. 
Application 
. 
Handlers &
;& '
public

 
class

 !
GetAllProductsHandler

 "
:

# $
IRequestHandler

% 4
<

4 5
GetAllProductsQuery

5 H
,

H I
IList

J O
<

O P

ProductDto

P Z
>

Z [
>

[ \
{ 
private 
readonly 
IProductRepository '
_repository( 3
;3 4
public 
!
GetAllProductsHandler  
(  !
IProductRepository! 3

repository4 >
)> ?
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 
IList 
< 

ProductDto &
>& '
>' (
Handle) /
(/ 0
GetAllProductsQuery0 C
requestD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 
var 
products 
= 
await 
_repository (
.( )
GetAllProducts) 7
(7 8
)8 9
;9 :
var 
response 
= 
CatalogMapper 
. 
Mapper  
.  !
Map 
< 
IList 
< 
Product 
> 
, 
IList  %
<% &

ProductDto& 0
>0 1
>1 2
(2 3
products3 ;
.; <
ToList< B
(B C
)C D
)D E
;E F
return 
response 
; 
} 
} ¥
~/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/GetAllTypesHandler.cs
	namespace 	
Catalog
 
. 
Application 
. 
Handlers &
;& '
public

 
class

 
GetAllTypesHandler

 
:

  !
IRequestHandler

" 1
<

1 2
GetAllTypesQuery

2 B
,

B C
IList

D I
<

I J
TypeDto

J Q
>

Q R
>

R S
{ 
private 
readonly 
ITypesRepository %
_repository& 1
;1 2
public 

GetAllTypesHandler 
( 
ITypesRepository .

repository/ 9
)9 :
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 
IList 
< 
TypeDto #
># $
>$ %
Handle& ,
(, -
GetAllTypesQuery- =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 
var 
types 
= 
await 
_repository %
.% &
GetAllTypes& 1
(1 2
)2 3
;3 4
var 
response 
= 
CatalogMapper 
. 
Mapper  
.  !
Map 
< 
IList 
< 
ProductType %
>% &
,& '
IList( -
<- .
TypeDto. 5
>5 6
>6 7
(7 8
types8 =
.= >
ToList> D
(D E
)E F
)F G
;G H
return 
response 
; 
} 
} ç
Ñ/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/GetProductByBrandHandler.cs
	namespace 	
Catalog
 
. 
Application 
. 
Handlers &
;& '
public		 
class		 $
GetProductByBrandHandler		 %
:		& '
IRequestHandler		( 7
<		7 8"
GetProductByBrandQuery		8 N
,		N O
IList		P U
<		U V

ProductDto		V `
>		` a
>		a b
{

 
private 
readonly 
IProductRepository '
_repository( 3
;3 4
public 
$
GetProductByBrandHandler #
(# $
IProductRepository$ 6

repository7 A
)A B
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 
IList 
< 

ProductDto &
>& '
>' (
Handle) /
(/ 0"
GetProductByBrandQuery0 F
requestG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 
var 
products 
= 
await 
_repository (
.( )
GetProductByBrand) :
(: ;
request; B
.B C
	brandNameC L
)L M
;M N
var 
response 
= 
CatalogMapper $
.$ %
Mapper% +
.+ ,
Map, /
</ 0
IList0 5
<5 6

ProductDto6 @
>@ A
>A B
(B C
productsC K
)K L
;L M
return 
response 
; 
} 
} â
É/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/GetProductByNameHandler.cs
	namespace 	
Catalog
 
. 
Application 
. 
Handlers &
;& '
public		 
class		 #
GetProductByNameHandler		 $
:		% &
IRequestHandler		' 6
<		6 7!
GetProductByNameQuery		7 L
,		L M
IList		N S
<		S T

ProductDto		T ^
>		^ _
>		_ `
{

 
private 
readonly 
IProductRepository '
_repository( 3
;3 4
public 
#
GetProductByNameHandler "
(" #
IProductRepository# 5

repository6 @
)@ A
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 
IList 
< 

ProductDto &
>& '
>' (
Handle) /
(/ 0!
GetProductByNameQuery0 E
requestF M
,M N
CancellationTokenO `
cancellationTokena r
)r s
{ 
var 
products 
= 
await 
_repository (
.( )
GetProductByName) 9
(9 :
request: A
.A B
productNameB M
)M N
;N O
var 
response 
= 
CatalogMapper $
.$ %
Mapper% +
.+ ,
Map, /
</ 0
IList0 5
<5 6

ProductDto6 @
>@ A
>A B
(B C
productsC K
)K L
;L M
return 
response 
; 
} 
} ∆
}/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/GetProductHandler.cs
	namespace 	
Catalog
 
. 
Application 
. 
Handlers &
;& '
public

 
class

 
GetProductHandler

 
:

  
IRequestHandler

! 0
<

0 1
GetProductQuery

1 @
,

@ A

ProductDto

B L
>

L M
{ 
private 
readonly 
IProductRepository '
_repository( 3
;3 4
public 

GetProductHandler 
( 
IProductRepository /

repository0 :
): ;
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 

ProductDto  
>  !
Handle" (
(( )
GetProductQuery) 8
request9 @
,@ A
CancellationTokenB S
cancellationTokenT e
)e f
{ 
var 
product 
= 
await 
_repository '
.' (

GetProduct( 2
(2 3
request3 :
.: ;
Id; =
)= >
;> ?
var 
response 
= 
CatalogMapper $
.$ %
Mapper% +
.+ ,
Map, /
</ 0

ProductDto0 :
>: ;
(; <
product< C
)C D
;D E
return 
response 
; 
} 
} —
Ä/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Handlers/UpdateProductHandler.cs
	namespace 	
Catalog
 
. 
Application 
. 
Handlers &
;& '
public

 
class

  
UpdateProductHandler

 !
:

" #
IRequestHandler

$ 3
<

3 4 
UpdateProductCommand

4 H
,

H I
Unit

J N
>

N O
{ 
private 
readonly 
IProductRepository '
_repository( 3
;3 4
public 
 
UpdateProductHandler 
(  
IProductRepository  2

repository3 =
)= >
{ 
_repository 
= 

repository  
;  !
} 
public 

async 
Task 
< 
Unit 
> 
Handle "
(" # 
UpdateProductCommand# 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 
var 
product 
= 
await 
_repository '
.' (

GetProduct( 2
(2 3
request3 :
.: ;
Id; =
)= >
;> ?
if 

( 
product 
is 
null 
) 
{ 	
throw 
new $
ProductNotFoundException .
(. /
request/ 6
.6 7
Id7 9
)9 :
;: ;
} 	
var 
updatedProduct 
= 
CatalogMapper *
.* +
Mapper+ 1
.1 2
Map2 5
(5 6
request6 =
.= >
product> E
,E F
productG N
)N O
;O P
await 
_repository 
. 
UpdateProduct '
(' (
updatedProduct( 6
)6 7
;7 8
return 
Unit 
. 
Value 
; 
} 
}   ¥
x/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Mappers/CatalogMapper.cs
	namespace 	
Catalog
 
. 
Application 
. 
Mappers %
;% &
public 
static 
class 
CatalogMapper !
{ 
private 
static 
readonly 
Lazy  
<  !
IMapper! (
>( )
Lazy* .
=/ 0
new1 4
Lazy5 9
<9 :
IMapper: A
>A B
(B C
(C D
)D E
=>F H
{ 
var		 
config		 
=		 
new		 
MapperConfiguration		 ,
(		, -
config		- 3
=>		4 6
{

 	
config 
. 
ShouldMapProperty $
=% &
p' (
=>) +
p, -
.- .
	GetMethod. 7
!7 8
.8 9
IsPublic9 A
||B D
pE F
.F G
	GetMethodG P
.P Q

IsAssemblyQ [
;[ \
config 
. 

AddProfile 
< !
ProductMappingProfile 3
>3 4
(4 5
)5 6
;6 7
} 	
)	 

;
 
var 

lazyMapper 
= 
config 
.  
CreateMapper  ,
(, -
)- .
;. /
return 

lazyMapper 
; 
} 
) 
; 
public 

static 
IMapper 
Mapper  
=>! #
Lazy$ (
.( )
Value) .
;. /
} ú
Ä/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Mappers/ProductMappingProfile.cs
	namespace 	
Catalog
 
. 
Application 
. 
Mappers %
;% &
public 
class !
ProductMappingProfile "
:# $
Profile% ,
{ 
public		 
!
ProductMappingProfile		  
(		  !
)		! "
{

 
	CreateMap 
< 
ProductBrand 
, 
BrandDto  (
>( )
() *
)* +
.+ ,

ReverseMap, 6
(6 7
)7 8
;8 9
	CreateMap 
< 
Product 
, 

ProductDto %
>% &
(& '
)' (
.( )

ReverseMap) 3
(3 4
)4 5
;5 6
	CreateMap 
< 
ProductType 
, 
TypeDto &
>& '
(' (
)( )
.) *

ReverseMap* 4
(4 5
)5 6
;6 7
	CreateMap 
< 
Product 
, !
ProductForCreationDto 0
>0 1
(1 2
)2 3
.3 4

ReverseMap4 >
(> ?
)? @
;@ A
} 
} ı
|/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Queries/GetAllBrandsQuery.cs
	namespace 	
Catalog
 
. 
Application 
. 
Queries %
;% &
public 
sealed 
record 
GetAllBrandsQuery &
:' (
IRequest) 1
<1 2
IList2 7
<7 8
BrandDto8 @
>@ A
>A B
;B C˚
~/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Queries/GetAllProductsQuery.cs
	namespace 	
Catalog
 
. 
Application 
. 
Queries %
;% &
public 
sealed 
record 
GetAllProductsQuery (
:) *
IRequest+ 3
<3 4
IList4 9
<9 :

ProductDto: D
>D E
>E F
;F GÚ
{/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Queries/GetAllTypesQuery.cs
	namespace 	
Catalog
 
. 
Application 
. 
Queries %
;% &
public 
sealed 
record 
GetAllTypesQuery %
:& '
IRequest( 0
<0 1
IList1 6
<6 7
TypeDto7 >
>> ?
>? @
;@ AÀ
Å/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Queries/GetProductByBrandQuery.cs
	namespace 	
Catalog
 
. 
Application 
. 
Queries %
;% &
public 
sealed 
record "
GetProductByBrandQuery +
(+ ,
string, 2
	brandName3 <
)< =
:> ?
IRequest@ H
<H I
IListI N
<N O

ProductDtoO Y
>Y Z
>Z [
;[ \À
Ä/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Queries/GetProductByNameQuery.cs
	namespace 	
Catalog
 
. 
Application 
. 
Queries %
;% &
public 
sealed 
record !
GetProductByNameQuery *
(* +
string+ 1
productName2 =
)= >
:? @
IRequestA I
<I J
IListJ O
<O P

ProductDtoP Z
>Z [
>[ \
;\ ]Ñ
z/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Queries/GetProductQuery.cs
	namespace 	
Catalog
 
. 
Application 
. 
Queries %
;% &
public 
sealed 
record 
GetProductQuery $
($ %
string% +
Id, .
). /
:0 1
IRequest2 :
<: ;

ProductDto; E
>E F
;F G¢
u/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Responses/BrandDto.cs
	namespace 	
Catalog
 
. 
Application 
. 
	Responses '
;' (
public 
record 
BrandDto 
{ 
public 

string 
? 
Id 
{ 
get 
; 
init !
;! "
}# $
public 

string 
? 
Name 
{ 
get 
; 
init #
;# $
}% &
} µ
w/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Responses/ProductDto.cs
	namespace 	
Catalog
 
. 
Application 
. 
	Responses '
;' (
public 
record 

ProductDto 
{ 
public 

string 
? 
Id 
{ 
get 
; 
init !
;! "
}# $
public 

string 
? 
Name 
{ 
get 
; 
init #
;# $
}% &
public		 

string		 
?		 
Summary		 
{		 
get		  
;		  !
init		" &
;		& '
}		( )
public

 

string

 
?

 
Description

 
{

  
get

! $
;

$ %
init

& *
;

* +
}

, -
public 

string 
? 
	ImageFile 
{ 
get "
;" #
init$ (
;( )
}* +
public 

ProductBrand 
? 
Brands 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 

ProductType 
? 
Types 
{ 
get  #
;# $
init% )
;) *
}+ ,
public 

decimal 
? 
price 
{ 
get 
;  
init! %
;% &
}' (
} ¶
Ç/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Responses/ProductForCreationDto.cs
	namespace 	
Catalog
 
. 
Application 
. 
	Responses '
;' (
public 
record !
ProductForCreationDto #
{ 
public 

string 
? 
Name 
{ 
get 
; 
init #
;# $
}% &
public 

string 
? 
Summary 
{ 
get  
;  !
init" &
;& '
}( )
public		 

string		 
?		 
Description		 
{		  
get		! $
;		$ %
init		& *
;		* +
}		, -
public

 

string

 
?

 
	ImageFile

 
{

 
get

 "
;

" #
init

$ (
;

( )
}

* +
public 

ProductBrand 
? 
Brands 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 

ProductType 
? 
Types 
{ 
get  #
;# $
init% )
;) *
}+ ,
public 

decimal 
? 
price 
{ 
get 
;  
init! %
;% &
}' (
} †
t/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Application/Responses/TypeDto.cs
	namespace 	
Catalog
 
. 
Application 
. 
	Responses '
;' (
public 
record 
TypeDto 
{ 
public 

string 
? 
Id 
{ 
get 
; 
init !
;! "
}# $
public 

string 
? 
Name 
{ 
get 
; 
init #
;# $
}% &
} 