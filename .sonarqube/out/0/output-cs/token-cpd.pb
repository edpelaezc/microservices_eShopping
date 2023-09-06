µ
o/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Entities/BaseEntity.cs
	namespace 	
Catalog
 
. 
Core 
. 
Entities 
;  
public 
class 

BaseEntity 
{ 
[ 
BsonId 
] 
[		 
BsonRepresentation		 
(		 
BsonType		  
.		  !
ObjectId		! )
)		) *
]		* +
public

 

string

 
?

 
Id

 
{

 
get

 
;

 
set

  
;

  !
}

" #
} ¹
ƒ/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Entities/Exceptions/BadRequestException.cs
	namespace 	
Catalog
 
. 
Core 
. 
Entities 
.  

Exceptions  *
;* +
public 
abstract 
class 
BadRequestException )
:* +
	Exception, 5
{ 
	protected 
BadRequestException !
(! "
string" (
message) 0
)0 1
:2 3
base4 8
(8 9
message9 @
)@ A
{B C
}C D
} ³
/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Entities/Exceptions/NotFoundException.cs
	namespace 	
Catalog
 
. 
Core 
. 
Entities 
.  

Exceptions  *
;* +
public 
abstract 
class 
NotFoundException '
:( )
	Exception* 3
{ 
	protected 
NotFoundException 
(  
string  &
message' .
). /
:0 1
base2 6
(6 7
message7 >
)> ?
{@ A
}A B
} ¢
ˆ/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Entities/Exceptions/ProductNotFoundException.cs
	namespace 	
Catalog
 
. 
Core 
. 
Entities 
.  

Exceptions  *
;* +
public 
sealed 
class $
ProductNotFoundException ,
:- .
NotFoundException/ @
{ 
public 
$
ProductNotFoundException #
(# $
string$ *
Id+ -
)- .
:/ 0
base1 5
(5 6
$"6 8
$str8 M
{M N
IdN P
}P Q
$strQ f
"f g
)g h
{ 
} 
} 
Š/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Entities/Exceptions/ResourceCreationBadRequest.cs
	namespace 	
Catalog
 
. 
Core 
. 
Entities 
.  

Exceptions  *
;* +
public 
class &
ResourceCreationBadRequest '
:( )
BadRequestException* =
{ 
public 
&
ResourceCreationBadRequest %
(% &
string& ,
resource- 5
)5 6
:7 8
base9 =
(= >
$"> @
$str@ n
{n o
resourceo w
}w x
"x y
)y z
{ 
} 
} ˜
l/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Entities/Product.cs
	namespace 	
Catalog
 
. 
Core 
. 
Entities 
;  
public 
class 
Product 
: 

BaseEntity !
{ 
[ 
BsonElement 
( 
$str 
) 
] 
public		 

string		 
?		 
Name		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public 

string 
? 
Summary 
{ 
get  
;  !
set" %
;% &
}' (
public 

string 
? 
Description 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

string 
? 
	ImageFile 
{ 
get "
;" #
set$ '
;' (
}) *
public 

ProductBrand 
? 
Brands 
{  !
get" %
;% &
set' *
;* +
}, -
public 

ProductType 
? 
Types 
{ 
get  #
;# $
set% (
;( )
}* +
[ 
BsonRepresentation 
( 
BsonType  
.  !

Decimal128! +
)+ ,
], -
public 

decimal 
? 
price 
{ 
get 
;  
set! $
;$ %
}& '
} €
q/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Entities/ProductBrand.cs
	namespace 	
Catalog
 
. 
Core 
. 
Entities 
;  
public 
class 
ProductBrand 
: 

BaseEntity &
{ 
[ 
BsonElement 
( 
$str 
) 
] 
public 

string 
? 
Name 
{ 
get 
; 
set "
;" #
}$ %
}		 þ
p/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Entities/ProductType.cs
	namespace 	
Catalog
 
. 
Core 
. 
Entities 
;  
public 
class 
ProductType 
: 

BaseEntity %
{ 
[ 
BsonElement 
( 
$str 
) 
] 
public 

string 
? 
Name 
{ 
get 
; 
set "
;" #
}$ %
}		 §
y/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Repositories/IBrandRepository.cs
	namespace 	
Catalog
 
. 
Core 
. 
Repositories #
;# $
public 
	interface 
IBrandRepository !
{ 
Task 
< 	
IEnumerable	 
< 
ProductBrand !
>! "
>" #
GetAllBrands$ 0
(0 1
)1 2
;2 3
} ¼
{/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Repositories/IProductRepository.cs
	namespace 	
Catalog
 
. 
Core 
. 
Repositories #
;# $
public 
	interface 
IProductRepository #
{ 
Task 
< 	
IEnumerable	 
< 
Product 
> 
> 
GetAllProducts -
(- .
). /
;/ 0
Task 
< 	
Product	 
> 

GetProduct 
( 
string #
id$ &
)& '
;' (
Task		 
<		 	
IEnumerable			 
<		 
Product		 
>		 
>		 
GetProductByName		 /
(		/ 0
string		0 6
name		7 ;
)		; <
;		< =
Task

 
<

 	
IEnumerable

	 
<

 
Product

 
>

 
>

 
GetProductByBrand

 0
(

0 1
string

1 7
	brandName

8 A
)

A B
;

B C
Task 
CreateProduct	 
( 
Product 
product &
)& '
;' (
Task 
UpdateProduct	 
( 
Product 
product &
)& '
;' (
Task 
DeleteProduct	 
( 
string 
id  
)  !
;! "
} ¥
y/Users/eduardopelaez/RiderProjects/microservices_eShopping/Services/Catalog/Catalog.Core/Repositories/ITypesRepository.cs
	namespace 	
Catalog
 
. 
Core 
. 
Repositories #
;# $
public 
	interface 
ITypesRepository !
{ 
Task 
< 	
IEnumerable	 
< 
ProductType  
>  !
>! "
GetAllTypes# .
(. /
)/ 0
;0 1
} 