module Fable.FakerJS

open Fable.Core
open System
open Fable.Core.JsInterop
open System.Text.RegularExpressions

[<StringEnum>]
type AircraftType =
    | Regional
    | Narrowbody
    | Widebody

[<StringEnum>]
type ColorFormat =
    | Binary
    | Css
    | Decimal

[<StringEnum>]
type CssColorSpace =
    | [<CompiledName("a98-rgb")>] A98Rgb
    | [<CompiledName("display-p3")>] DisplayP3
    | [<CompiledName("prophoto-rgb")>] ProphotoRgb
    | [<CompiledName("rec2020")>] Rec2020
    | [<CompiledName("sRGB")>] SRgb

[<StringEnum>]
type CssSupportedFunction =
    | Rgb
    | Color
    | Lab
    | Rgba
    | Hsl
    | Hsla
    | Hwb
    | Cmyk
    | Lch

[<StringEnum>]
type Casing =
    | Lower
    | Mixed
    | Upper

[<StringEnum>]
type RgbFormat =
    | Binary
    | Css
    | Decimal
    | Hex

[<StringEnum>]
type BirthdateMode =
    | Age
    | Year

[<StringEnum>]
type EndOfLine =
    | [<CompiledName("CRLF")>] CRLF
    | [<CompiledName("LF")>] LF

type ImageBlur =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6
    | Seven = 7
    | Eight = 8
    | Nine = 9
    | Ten = 10

[<StringEnum>]
type ImageFormat =
    | Gif
    | Jpeg
    | Jpg
    | Png
    | Webp

[<StringEnum>]
type HttpMethod =
    | [<CompiledName("GET")>] GET
    | [<CompiledName("POST")>] POST
    | [<CompiledName("PUT")>] PUT
    | [<CompiledName("DELETE")>] DELETE
    | [<CompiledName("PATCH")>] PATCH

[<StringEnum>]
type Protocol =
    | Http
    | Https

[<StringEnum>]
type CountryCodeVariant =
    | [<CompiledName("alpha-2")>] Alpha2
    | [<CompiledName("alpha-3")>] Alpha3

[<StringEnum>]
type WordGenerationStrategy =
    | [<CompiledName("any-length")>] AnyLength
    | Closest
    | Fail
    | Longest
    | Shortest

[<StringEnum>]
type EmojiType =
    | Smiley
    | Body
    | Person
    | Nature
    | Food
    | Travel
    | Activity
    | Object
    | Symbol
    | Flag

[<StringEnum>]
type HttpStatusCodeType =
    | Informational
    | Success
    | ClientError
    | ServerError
    | Redirection

[<StringEnum>]
type Sex =
    | Female
    | Male

[<StringEnum>]
type InterfaceSchema =
    | Index
    | Mac
    | Pci
    | Slot

[<StringEnum>]
type InterfaceType =
    | En
    | Wl
    | Ww

type IAirport =
    abstract member name: string
    abstract member iataCode: string

type IAirline =
    abstract member name: string
    abstract member iataCode: string

type IAirplane =
    abstract member name: string
    abstract member iataCode: string

type ICurrency =
    abstract member code: string
    abstract member name: string
    abstract member symbol: string

type IUnit =
    abstract member name: string
    abstract member symbol: string

type IFakerAirline =
    abstract member airport: unit -> IAirport
    abstract member airline: unit -> IAirline
    abstract member airplane: unit -> IAirplane

    [<ParamObject>]
    abstract member flightNumber: ?addLeadingZeros: bool * ?length: int -> string

    [<ParamObject>]
    abstract member flightNumber: ?addLeadingZeros: bool * ?length: {| min: int; max: int |} -> string

    [<ParamObject>]
    abstract member recordLocator: ?allowNumerics: bool * ?allowVisuallySimilarCharacters: bool -> string

    [<ParamObject>]
    abstract member seat: ?aircraftType: AircraftType -> string

    abstract member aircraftType: unit -> AircraftType

type IFakerAnimal =
    abstract member bear: unit -> string
    abstract member bird: unit -> string
    abstract member cat: unit -> string
    abstract member cetacean: unit -> string
    abstract member cow: unit -> string
    abstract member crocodilia: unit -> string
    abstract member dog: unit -> string
    abstract member fish: unit -> string
    abstract member horse: unit -> string
    abstract member insect: unit -> string
    abstract member lion: unit -> string
    abstract member rabbit: unit -> string
    abstract member rodent: unit -> string
    abstract member snake: unit -> string
    abstract member ``type``: unit -> string

type IFakerColor =
    [<ParamObject>]
    abstract member cmyk: ?format: ColorFormat -> U2<string, float array>

    [<ParamObject>]
    abstract member colorByCSSColorSpace: ?format: ColorFormat * ?space: CssColorSpace -> U2<string, float array>

    abstract member cssSupportedFunction: unit -> CssSupportedFunction
    abstract member cssSupportedFace: unit -> CssColorSpace

    [<ParamObject>]
    abstract member hsl: ?format: ColorFormat * ?includeAlpha: bool -> U2<string, float array>

    abstract member human: unit -> string

    [<ParamObject>]
    abstract member hwb: ?format: ColorFormat -> U2<string, float array>

    [<ParamObject>]
    abstract member lab: ?format: ColorFormat -> U2<string, float array>

    [<ParamObject>]
    abstract member lch: ?format: ColorFormat -> U2<string, float array>

    [<ParamObject>]
    abstract member rgb:
        ?casing: Casing * ?format: RgbFormat * ?includeAlpha: bool * ?prefix: string -> U2<string, float array>

    abstract member space: unit -> string

type IFakerCommerce =
    abstract member department: unit -> string

    [<ParamObject>]
    abstract member price: ?dec: int * ?max: int * ?min: int * ?symbol: string -> string

    abstract member product: unit -> string
    abstract member productAdjective: unit -> string
    abstract member productDescription: unit -> string
    abstract member productMaterial: unit -> string
    abstract member productName: unit -> string

type IFakerCompany =
    abstract member buzzAdjective: unit -> string
    abstract member buzzNoun: unit -> string
    abstract member buzzPhrase: unit -> string
    abstract member buzzVerb: unit -> string
    abstract member catchPhrase: unit -> string
    abstract member catchPhraseAdjective: unit -> string
    abstract member catchPhraseDescriptor: unit -> string
    abstract member catchPhraseNoun: unit -> string
    abstract member name: unit -> string

type IFakerDatabase =
    abstract member collation: unit -> string
    abstract member column: unit -> string
    abstract member engine: unit -> string
    abstract member mongodbObjectId: unit -> string
    abstract member ``type``: unit -> string

type IFakerDatatype =
    [<ParamObject>]
    abstract member boolean: ?probability: float -> bool

// TODO: come back to this.
type IFakerDate =
    [<ParamObject>]
    abstract member anytime: ?refDate: U3<DateOnly, float, string> -> DateOnly

    abstract member between: unit -> DateOnly
    abstract member between: U3<DateOnly, float, string> -> DateOnly

    [<ParamObject>]
    abstract member between: from: U3<DateOnly, float, string> * ``to``: U3<DateOnly, float, string> -> DateOnly

    abstract member betweens: unit -> DateOnly
    abstract member betweens: U3<DateOnly, float, string> -> DateOnly

    [<ParamObject>]
    abstract member betweens:
        from: U3<DateOnly, float, string> *
        ``to``: U3<DateOnly, float, string> *
        ?count: U2<int, {| min: int; max: int |}> ->
            DateOnly array

    [<ParamObject>]
    abstract member birthdate:
        ?max: int * ?min: int * ?mode: BirthdateMode * ?refDate: U3<DateOnly, float, string> -> DateOnly

    [<ParamObject>]
    abstract member future: ?refDate: U3<DateOnly, float, string> * ?years: int -> DateOnly

    [<ParamObject>]
    abstract member month: ?abbreviated: bool * ?context: bool -> string

    [<ParamObject>]
    abstract member past: ?refDate: U3<DateOnly, float, string> * ?years: int -> DateOnly

    [<ParamObject>]
    abstract member recent: ?refDate: U3<DateOnly, float, string> * ?days: int -> DateOnly

    [<ParamObject>]
    abstract member soon: ?refDate: U3<DateOnly, float, string> * ?days: int -> DateOnly

    [<ParamObject>]
    abstract member weekday: ?abbreviated: bool * ?context: bool -> string

type IFakerFinance =
    abstract member accountName: unit -> string

    [<ParamObject>]
    abstract member accountNumber: ?length: int -> string

    [<ParamObject>]
    abstract member amount: ?autoFormat: bool * ?desc: int * ?min: int * ?max: int * ?symbol: string -> string

    [<ParamObject>]
    abstract member bic: ?includeBranchCode: bool -> string

    abstract member bitcoinAddress: unit -> string
    abstract member creditCardCVV: unit -> string
    abstract member creditCardIssuer: unit -> string

    [<ParamObject>]
    abstract member creditCardNumber: ?issuer: string -> string

    abstract member currency: unit -> ICurrency
    abstract member currencyCode: unit -> string
    abstract member currencyName: unit -> string
    abstract member currencySymbol: unit -> string
    abstract member ethereumAddress: unit -> string

    [<ParamObject>]
    abstract member iban: ?countryCode: string * ?formatted: bool -> string

    abstract member litecoinAddress: unit -> string

    abstract member maskedNumber: int -> string

    [<ParamObject>]
    abstract member maskedNumber: ?ellipsis: bool * ?length: int * ?parens: bool -> string

    [<ParamObject>]
    abstract member pin: ?length: int -> string

    abstract member routingNumber: unit -> string
    abstract member transactionDescription: unit -> string
    abstract member transactionType: unit -> string

type IFakerGit =
    abstract member branch: unit -> string

    [<ParamObject>]
    abstract member commitDate: ?refDate: U3<DateOnly, float, string> -> string

    [<ParamObject>]
    abstract member commitEntry: ?eol: EndOfLine * ?merge: bool * ?refDate: U3<DateOnly, float, string> -> string

    abstract member commitMessage: unit -> string

    [<ParamObject>]
    abstract member commitSha: ?length: int -> string

type IFakerHacker =
    abstract member abbreviation: unit -> string
    abstract member adjective: unit -> string
    abstract member ingverb: unit -> string
    abstract member noun: unit -> string
    abstract member phrase: unit -> string
    abstract member verb: unit -> string

type IFakerImage =
    abstract member avatar: unit -> string
    abstract member avatarGitHub: unit -> string
    abstract member avatarLegacy: unit -> string

    [<ParamObject>]
    abstract member dataUri: ?color: string * ?height: int * ?width: int -> string

    [<ParamObject>]
    abstract member url: ?height: int * ?width: int -> string

    [<ParamObject>]
    abstract member urlLoremFlickr: ?category: string * ?height: int * ?width: int -> string

    [<ParamObject>]
    abstract member urlPicsumPhotos: ?blur: ImageBlur * ?grayscale: bool * ?height: int * ?width: int -> string

    [<ParamObject>]
    abstract member urlPlaceholder:
        ?backgroundColor: string *
        ?format: ImageFormat *
        ?height: int *
        ?text: string *
        ?textColor: string *
        ?width: int ->
            string

type IFakerInternet =
    abstract member avatar: unit -> string

    [<ParamObject>]
    abstract member color: ?blueBase: byte * ?greenBase: byte * ?redBase: byte -> string

    [<ParamObject>]
    abstract member displayName: ?firstName: string * ?lastName: string -> string

    abstract member domainName: unit -> string
    abstract member domainSuffix: unit -> string
    abstract member domainWord: unit -> string

    [<ParamObject>]
    abstract member email:
        ?allowSpecialCharacters: bool * ?firstName: string * ?lastName: string * ?provider: string -> string

    [<ParamObject>]
    abstract member emojiType: ?types: EmojiType list -> string

    [<ParamObject>]
    abstract member exampleEmail: ?allowSpecialCharacters: bool * ?firstName: string * ?lastName: string -> string

    abstract member httpMethod: unit -> HttpMethod

    [<ParamObject>]
    abstract member httpStatusCode: ?types: HttpStatusCodeType list -> int

    abstract member ip: unit -> string
    abstract member ipv4: unit -> string
    abstract member ipv6: unit -> string

    [<ParamObject>]
    abstract member mac: ?seperator: string -> string

    [<ParamObject>]
    abstract member password: ?length: int * ?memorable: bool * ?pattern: Regex * ?prefix: string -> string

    abstract member port: unit -> int
    abstract member protocol: unit -> Protocol

    [<ParamObject>]
    abstract member url: ?appendSlash: bool * ?protocol: Protocol -> string

    abstract member userAgent: string -> unit

    [<ParamObject>]
    abstract member userName: ?firstName: string * ?lastName: string -> string

type IFakerLocation =
    abstract member buildingNumber: unit -> string

    [<ParamObject>]
    abstract member cardinalDirection: ?abbreviated: bool -> string

    abstract member city: unit -> string
    abstract member country: unit -> string

    [<ParamObject>]
    abstract member countryCode: ?variant: CountryCodeVariant -> string

    abstract member county: unit -> string

    [<ParamObject>]
    abstract member direction: ?abbreviated: bool -> string

    [<ParamObject>]
    abstract member latitude: ?max: int * ?min: int * ?precision: int -> float

    [<ParamObject>]
    abstract member longitude: ?max: int * ?min: int * ?precision: int -> float

    [<ParamObject>]
    abstract member nearbyGPSCoordinate: ?isMetric: bool * ?origin: int array * ?radius: int -> int array

    [<ParamObject>]
    abstract member ordinalDirection: ?abbreviated: bool -> string

    abstract member secondaryAddress: unit -> string

    [<ParamObject>]
    abstract member state: ?abbreviated: bool -> string

    abstract member street: unit -> string

    [<ParamObject>]
    abstract member streetAddress: ?useFullAddress: bool -> string

    abstract member timeZone: unit -> string

    [<ParamObject>]
    abstract member zipCode: ?format: string * ?state: string -> string

type IFakerLorem =
    [<ParamObject>]
    abstract member lines: min: int * max: int -> string

    [<ParamObject>]
    abstract member paragraph: min: int * max: int -> string

    [<NamedParams>]
    abstract member paragraphs: ?paragraphCount: U2<int, {| min: int; max: int |}> * ?separator: string -> string

    [<ParamObject>]
    abstract member sentence: ?min: int * ?max: int -> string

    [<NamedParams>]
    abstract member sentences: ?sentenceCount: U2<int, {| min: int; max: int |}> * ?separator: string -> string

    abstract member slug: unit -> string
    abstract member slug: int -> string

    [<ParamObject>]
    abstract member slug: min: int * max: int -> string

    abstract member text: unit -> string
    abstract member word: unit -> string
    abstract member word: int -> string

    [<ParamObject>]
    abstract member word: ?strategy: WordGenerationStrategy * ?length: {| min: int; max: int |} -> string

    abstract member words: unit -> string
    abstract member words: int -> string

    [<ParamObject>]
    abstract member words: min: int * max: int -> string

type IFakerMusic =
    abstract member genre: unit -> string
    abstract member songName: unit -> string

type IFakerNumber =
    [<ParamObject>]
    abstract member bigint: ?max: U4<bigint, bool, int, string> * ?min: U4<bigint, bool, int, string> -> bigint

    [<ParamObject>]
    abstract member binary: ?max: int * ?min: int -> string

    [<ParamObject>]
    abstract member hex: ?max: int * ?min: int -> string

    [<ParamObject>]
    abstract member int: ?max: int * ?min: int -> int

    abstract member octcal: ?max: int * ?min: int -> string

type IFakerPerson =
    abstract member bio: unit -> string
    abstract member firstName: ?sex: Sex -> string

    [<ParamObject>]
    abstract member fullName: ?ifrstName: string * ?lastName: string * ?sex: Sex -> string

    abstract member gender: unit -> string
    abstract member jobArea: unit -> string
    abstract member jobTitle: unit -> string
    abstract member jobType: unit -> string
    abstract member lastName: ?sex: Sex -> string
    abstract member middleName: ?sex: Sex -> string
    abstract member prefix: ?sex: Sex -> string
    abstract member sex: unit -> string
    abstract member sexType: unit -> Sex
    abstract member suffix: unit -> string
    abstract member zodiacSign: unit -> string

type IFakerPhone =
    abstract member imei: unit -> string
    abstract member number: ?format: string -> string

type IFakerScience =
    abstract member chemicalElement: unit -> string
    abstract member unit: unit -> IUnit

type IFakerString =
    // TODO: `exclude` isn't a union here as it should be, but it's probably easier for the consumer.
    [<ParamObject>]
    abstract member alpha: ?casing: Casing * ?exclude: string * ?length: U2<int, {| min: int; max: int |}> -> string

    // TODO: `exclude` isn't a union here as it should be, but it's probably easier for the consumer.
    [<ParamObject>]
    abstract member alphanumeric:
        ?casing: Casing * ?exclude: string * ?length: U2<int, {| min: int; max: int |}> -> string

    [<ParamObject>]
    abstract member binary: ?length: U2<int, {| min: int; max: int |}> * ?prefix: string -> string

    abstract member fromCharacters: U2<string, string list> * ?length: U2<int, {| min: int; max: int |}> -> string

    [<ParamObject>]
    abstract member hexadecimal:
        ?casing: Casing * ?length: U2<int, {| min: int; max: int |}> * ?prefix: string -> string

    abstract member nanoid: ?length: U2<int, {| min: int; max: int |}> -> string

    // TODO: `exclude` isn't a union here as it should be, but it's probably easier for the consumer.
    [<ParamObject>]
    abstract member numeric:
        ?allowLeadingZeros: bool * ?exclude: string * ?length: U2<int, {| min: int; max: int |}> -> string

    [<ParamObject>]
    abstract member octal: ?length: U2<int, {| min: int; max: int |}> * ?prefix: string -> string

    abstract member sample: ?length: U2<int, {| min: int; max: int |}> -> string
    abstract member symbol: ?length: U2<int, {| min: int; max: int |}> -> string
    abstract member uuid: unit -> string // TODO: possible to make this a guid?

type IFakerSystem =
    abstract member commonFileExt: unit -> string
    abstract member commonFileName: ?ext: string -> string
    abstract member commonFileType: unit -> string

    [<ParamObject>]
    abstract member cron: ?includeNonStandard: bool * ?includeYear: bool -> string

    abstract member directoryPath: unit -> string
    abstract member fileExt: ?mimeType: string -> string

    [<ParamObject>]
    abstract member fileName: ?extensionCount: U2<int, {| min: int; max: int |}> -> string

    abstract member filePath: unit -> string
    abstract member fileType: unit -> string
    abstract member mimeType: unit -> string

    [<ParamObject>]
    abstract member networkInterface: ?interfaceSchema: InterfaceSchema * ?interfaceType: InterfaceType -> string

    abstract member semver: unit -> string

type IFakerVehicle =
    abstract member bicycle: unit -> string
    abstract member color: unit -> string
    abstract member fuel: unit -> string
    abstract member manufacturer: unit -> string
    abstract member model: unit -> string
    abstract member ``type``: unit -> string
    abstract member vehicle: unit -> string
    abstract member vin: unit -> string
    abstract member vrm: unit -> string

type IFakerWord =
    [<ParamObject>]
    abstract member adjective: ?length: U2<int, {| min: int; max: int |}> * ?strategy: WordGenerationStrategy -> string

    [<ParamObject>]
    abstract member adverb: ?length: U2<int, {| min: int; max: int |}> * ?strategy: WordGenerationStrategy -> string

    [<ParamObject>]
    abstract member conjunction:
        ?length: U2<int, {| min: int; max: int |}> * ?strategy: WordGenerationStrategy -> string

    [<ParamObject>]
    abstract member interjection:
        ?length: U2<int, {| min: int; max: int |}> * ?strategy: WordGenerationStrategy -> string

    [<ParamObject>]
    abstract member noun: ?length: U2<int, {| min: int; max: int |}> * ?strategy: WordGenerationStrategy -> string

    [<ParamObject>]
    abstract member preposition:
        ?length: U2<int, {| min: int; max: int |}> * ?strategy: WordGenerationStrategy -> string

    [<ParamObject>]
    abstract member sample: ?length: U2<int, {| min: int; max: int |}> * ?strategy: WordGenerationStrategy -> string

    [<ParamObject>]
    abstract member verb: ?length: U2<int, {| min: int; max: int |}> * ?strategy: WordGenerationStrategy -> string

    [<ParamObject>]
    abstract member words: ?count: U2<int, {| min: int; max: int |}> -> string

type IFaker =
    abstract airline: IFakerAirline
    abstract animal: IFakerAnimal
    abstract color: IFakerColor
    abstract commerce: IFakerCommerce
    abstract company: IFakerCompany
    abstract database: IFakerDatabase
    abstract datatype: IFakerDatatype
    abstract date: IFakerDate
    abstract finance: IFakerFinance
    abstract git: IFakerGit
    abstract hacker: IFakerHacker
    abstract image: IFakerImage
    abstract internet: IFakerInternet
    abstract location: IFakerLocation
    abstract lorem: IFakerLorem
    abstract music: IFakerMusic
    abstract number: IFakerNumber
    abstract person: IFakerPerson
    abstract phone: IFakerPhone
    abstract science: IFakerScience
    abstract string: IFakerString
    abstract system: IFakerSystem
    abstract vehicle: IFakerVehicle
    abstract word: IFakerWord
    abstract seed: int -> unit
    abstract seed: int array -> unit

// TODO: https://fakerjs.dev/api/faker.html
// TODO: https://fakerjs.dev/api/helpers.html
// TODO: https://fakerjs.dev/api/utils.html
// TODO: Might need to add some additional member overloads... some functions support multiple types of inputs
// TODO: Some functions might need named params instead of [<ParamObject>]
// TODO: Need to make sure union and numeric inputs/outputs are appropriate.
// TODO: Should I create overloads for consumers to avoid passing in a Union instance (U2, U3, etc...)

[<Import("faker", "@faker-js/faker")>]
let faker: IFaker = jsNative
