module Fable.Helpers.ReactToolbox

open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.React
open Fable.Core.JsInterop
open React.Props
open System

[<AutoOpen>]
module Props =

    type Props =
        | ClassName of string
        | Key of string
        | OnClick of Function
        | OnMouseUp of Function
        | OnMouseEnter of Function
        | OnMouseLeave of Function
        | OnMouseDown of Function
        | OnContextMenu of Function
        | OnDoubleClick of Function
        | OnDrag of Function
        | OnDragEnd of Function
        | OnDragEnter of Function
        | OnDragExit of Function
        | OnDragLeave of Function
        | OnDragOver of Function
        | OnDragStart of Function
        | OnDrop of Function
        | OnMouseMove of Function
        | OnMouseOut of Function
        | OnMouseOver of Function
        | OnTouchCancel of Function
        | OnTouchEnd of Function
        | OnTouchMove of Function
        | OnTouchStart of Function
        | Style of CSSProperties
        interface Fable.Helpers.React.Props.IHTMLProp
        interface Fable.Helpers.React.Props.ICSSProp

    type internal IReactToolboxProp =
        inherit Fable.Helpers.React.Props.IHTMLProp
        inherit Fable.Helpers.React.Props.ICSSProp

open Props

let styles = JsInterop.importAll<obj> "react-toolbox/lib/commons.scss"

let inline rtEl<[<Pojo>]'P when 'P :> IHTMLProp> (a:ComponentClass<'P>) (b:IHTMLProp list) c = Fable.Helpers.React.from a (keyValueList CaseRules.LowerFirst b |> unbox) c

type AppBarTheme =
    | AppBar of string
    | Fixed of string
    | Flat of string
    | Title of string
    | LeftIcon of string
    | RightIcon of string
type AppBarProps =
    | Children of React.ReactNode
    | Fixed of bool
    | Flat of bool
    | Title of string
    | LeftIcon of string
    | OnLeftIconClick of Function
    | RightIcon of string
    | OnRightIconClick of Function
    | Theme of AppBarTheme
    interface IReactToolboxProp
let AppBar = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/app_bar"

let inline appBar b c = rtEl AppBar b c


type AutocompleteTheme =
    /// Used for a suggestion when it's active.
    | Active of string
    /// Used for the root element.
    | Autocomplete of string
    /// Used when the input is focused.
    | Focus of string
    /// Used to style the Input component.
    | Input of string
    /// Used to style each suggestion.
    | Suggestion of string
    /// Used to style the suggestions container.
    | Suggestions of string
    /// Used for the suggestions when it's opening to the top.
    | Up of string
    /// Classname used for a single value.
    | Value of string
    /// Classname used for the values container.
    | Values of string

[<StringEnum>]
type AutocompleteDirection = | Auto | Up | Down

[<StringEnum>]
type SelectedPosition = | Above | Below | None

[<StringEnum>]
type SuggestionMatch = | Start | Anywhere | Word

type AutocompleteProps =
    /// Determines if user can create a new option with the current typed value.
    /// default: `false`
    | AllowCreate of bool
    /// Determines the opening direction. It can be auto, up or down.
    /// default: `auto`
    | Direction of AutocompleteDirection
    /// If true, component will be disabled.
    /// default: `false`
    | Disabled of bool
    /// Sets the error string for the internal input element.
    | Error of U2<string, React.ReactNode>
    /// Whether component should keep focus after value change.
    /// default: `false`
    | KeepFocusOnChange of bool
    /// The text string to use for the floating label element.
    | Label of U2<string, React.ReactNode>
    /// If true, component can hold multiple values.
    /// default: `true`
    | Multiple of bool
    /// Callback function that is fired when component is blurred.
    /// The first argument is event
    /// The second argument is the currently selected value in the dropdown
    | OnBlur of ((obj * string) -> unit)
    /// Callback function that is fired when the components's value changes.
    /// First argument is the current value of the autocomplete
    /// Second argument is the event
    | OnChange of ((U2<string, string[]> * obj) -> unit)
    /// Callback function that is fired when component is focused.
    /// The argument is event
    | OnFocus of (obj -> unit)
    /// Callback function that is fired when the components's query input value changes.
    /// First argument is the typed text
    /// Second argument is event
    | OnQueryChange of ((string * obj) -> unit)
    /// Determines if the selected list is shown above or below input. It can be above or below.
    /// default: `above`
    | SelectedPosition of SelectedPosition
    /// Determines if the selected list is shown if the `value` keys don't exist in the source. Only works if passing the `value` prop as an Object.
    /// default: `false`
    | ShowSelectedWhenNotInSource of bool
    /// If true, the list of suggestions will not be filtered when a value is selected, until the query is modified.
    /// default: `false`
    | ShowSuggestionsWhenValueIsSet of bool
    /// Object of key/values or array representing all items suggested.
    | Source of obj
    ///  Determines how suggestions are supplied.
    /// default: `start`
    | SuggestionMatch of SuggestionMatch
    | Theme of AutocompleteTheme
    /// Value or array of values currently selected component.
    /// Either the key of the selected element (as string), or an array of string, if multiple selection is enabled
    | Value of U2<string, string[]>
    interface IReactToolboxProp
let Autocomplete = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/autocomplete"
let inline autocomplete b c = rtEl Autocomplete b c


type AvatarTheme =
    | Avatar of string
    | Image of string
    | Letter of string

type AvatarProps =
    | Children of React.ReactNode
    | Cover of bool
    | Icon of U2<React.ReactNode, string>
    | Image of U2<React.ReactNode, string>
    | Theme of AvatarTheme
    | Title of string
    interface IReactToolboxProp
let Avatar = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/avatar"
let inline avatar b c = rtEl Avatar b c


type ButtonTheme =
    | Accent of string
    | Button of string
    | Flat of string
    | Floating of string
    | Icon of string
    | Inverse of string
    | Mini of string
    | Neutral of string
    | Primary of string
    | Raised of string
    | RippleWrapper of string
    | Toggle of string

type ButtonProps =
    | Accent of bool
    | Children of React.ReactNode
    | Disabled of bool
    | Flat of bool
    | Floating of bool
    | Href of string
    | Icon of U2<React.ReactNode, string>
    | Inverse of bool
    | Label of string
    | Mini of bool
    | Neutral of bool
    | Primary of bool
    | Raised of bool
    | Ripple of bool
    | Theme of ButtonTheme
    interface IReactToolboxProp
let Button = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/button"
let inline button b c = rtEl Button b c

type IconButtonTheme =
    | Accent of string
    | Button of string
    | Icon of string
    | Inverse of string
    | Neutral of string
    | Primary of string
    | RippleWrapper of string
    | Toggle of string

type IconButtonProps =
    | Accent of bool
    | Children of React.ReactNode
    | Disabled of bool
    | Href of string
    | Icon of U2<React.ReactNode, string>
    | Inverse of bool
    | Neutral of bool
    | Primary of bool
    | Ripple of bool
    | Theme of IconButtonTheme
    interface IReactToolboxProp
let IconButton = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/button"
let inline iconButton b c = rtEl IconButton b c


type CardTheme =
    | Card of string
    | Raised of string

type CardProps =
    | Children of React.ReactNode
    | Raised of bool
    | Theme of CardTheme
    interface IReactToolboxProp
let Card = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/card"
let inline card b c = rtEl Card b c

type CardActionsTheme =
    | CardActions of string

type CardActionsProps =
    | Children of React.ReactNode
    | Theme of CardActionsTheme
    interface IReactToolboxProp
let CardActions = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/card"
let inline cardActions b c = rtEl CardActions b c

type CardMediaTheme =
    | CardMedia of string
    | Content of string
    | ContentOverlay of string
    | Square of string
    | Wide of string

type CardMediaProps =
    | AspectRatio of (* TODO StringEnum wide | square *) string
    | Children of React.ReactNode
    | Color of string
    | ContentOverlay of bool
    | Image of U2<React.ReactNode, string>
    | Theme of CardMediaTheme
    interface IReactToolboxProp
let CardMedia = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/card"
let inline cardMedia b c = rtEl CardMedia b c

type CardTextTheme =
    | CardText of string

type CardTextProps =
    | Children of React.ReactNode
    | Theme of CardTextTheme
    interface IReactToolboxProp
let CardText = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/card"
let inline cardText b c = rtEl CardText b c

type CardTitleTheme =
    | Large of string
    | Title of string
    | Small of string
    | Subtitle of string

type CardTitleProps =
    | Avatar of U2<React.ReactNode, string>
    | Children of React.ReactNode
    | Subtitle of U2<React.ReactNode, string>
    | Theme of CardTitleTheme
    | Title of U2<React.ReactNode, string>
    interface IReactToolboxProp
let CardTitle = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/card"
let inline cardTitle b c = rtEl CardTitle b c


type CheckboxTheme =
    | Check of string
    | Checked of string
    | Disabled of string
    | Field of string
    | Input of string
    | Ripple of string
    | Text of string

type CheckboxProps =
    | Checked of bool
    | Disabled of bool
    | Label of U2<React.ReactNode, string>
    | Name of string
    | OnBlur of Function
    | OnChange of (bool -> unit)
    | Theme of CheckboxTheme
    interface IReactToolboxProp
let Checkbox  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/checkbox"
let inline checkbox b c = rtEl Checkbox b c


type ChipTheme =
    | Avatar of string
    | Chip of string
    | Deletable of string
    | Delete of string
    | DeleteIcon of string
    | DeleteX of string

type ChipProps =
    | Children of React.ReactNode
    | Deletable of bool
    | OnDeleteClick of (unit -> unit)
    | Theme of ChipTheme
    interface IReactToolboxProp
let Chip  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/chip"
let inline chip b c = rtEl Chip b c


type DatePickerTheme =
    | Active of string
    | Button of string
    | Calendar of string
    | CalendarWrapper of string
    | Date of string
    | Day of string
    | Days of string
    | Dialog of string
    | Disabled of string
    | Header of string
    | Input of string
    | Month of string
    | MonthsDisplay of string
    | Next of string
    | Prev of string
    | Title of string
    | Week of string
    | Year of string
    | Years of string
    | YearsDisplay of string

type DatePickerProps =
    | AutoOk of bool
    | Error of string
    | Icon of U2<React.ReactNode, string>
    | InputClassName of string
    | InputFormat of Function
    | Label of string
    | MaxDate of DateTime
    | MinDate of DateTime
    | Name of string
    | OnChange of Function
    | OnEscKeyDown of Function
    | OnOverlayClick of Function
    | Readonly of bool
    | Theme of DatePickerTheme
    | Value of U2<DateTime, string>
    interface IReactToolboxProp
let DatePicker  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/date_picker"
let inline datePicker b c = rtEl DatePicker b c


type DialogTheme =
    | Active of string
    | Body of string
    | Button of string
    | Dialog of string
    | Navigation of string
    | Title of string

[<Pojo>]
type DialogActionProp =
    { label: string
      onClick: unit -> unit }

type DialogProps =
    | Actions of obj array
    | Active of bool
    | Children of React.ReactNode
    | OnEscKeyDown of Function
    | OnOverlayClick of Function
    | OnOverlayMouseDown of Function
    | OnOverlayMouseMove of Function
    | OnOverlayMouseUp of Function
    | Theme of DialogTheme
    | Title of string
    | Type of string
    interface IReactToolboxProp
let Dialog  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/dialog"
let inline dialog b c = rtEl Dialog b c


type DrawerTheme =
    | Active of string
    | Content of string
    | Drawer of string
    | Left of string
    | Right of string

type DrawerProps =
    | Active of bool
    | Children of React.ReactNode
    | OnOverlayClick of (React.MouseEvent -> unit)
    | Theme of DrawerTheme
    | Type of (* TODO StringEnum left | right *) string
    interface IReactToolboxProp
let Drawer  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/drawer"
let inline drawer b c = rtEl Drawer b c


type DropdownWrapper<'TVal,'T> =
    { item: 'T
      value: 'TVal }

type DropdownTheme =
    | Active of string
    | Disabled of string
    | Dropdown of string
    | Error of string
    | Errored of string
    | Field of string
    | Label of string
    | Selected of string
    | TemplateValue of string
    | Up of string
    | Value of string
    | Values of string

type DropdownProps<'TVal,'T> =
    | AllowBlank of bool
    | Auto of bool
    | Disabled of bool
    | Error of string
    | Label of string
    | Name of string
    | OnBlur of Function
    | OnChange of ('TVal -> unit)
    | OnFocus of Function
    | Source of DropdownWrapper<'TVal,'T> array
    | Template of (DropdownWrapper<'TVal,'T> -> ReactElement)
    | Theme of DropdownTheme
    | Value of 'TVal
    interface IReactToolboxProp
let Dropdown  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/dropdown"
let inline dropdown b c = rtEl Dropdown b c


type FontIconProps =
    | Children of React.ReactNode
    | Value of U2<React.ReactNode, string>
    interface IReactToolboxProp
let FontIcon  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/font_icon"
let inline fontIcon b c = rtEl FontIcon b c


type InputTheme =
    | Bar of string
    | Counter of string
    | Disabled of string
    | Error of string
    | Errored of string
    | Hidden of string
    | Hint of string
    | Icon of string
    | Input of string
    | InputElement of string
    | Required of string
    | WithIcon of string

type InputProps =
    | Children of React.ReactNode
    | Disabled of bool
    | Error of string
    | Floating of bool
    | Hint of string
    | Icon of U2<React.ReactNode, string>
    | Label of string
    | MaxLength of float
    | Multiline of bool
    | Name of string
    | OnBlur of Function
    | OnChange of (string -> unit)
    | OnFocus of Function
    | OnKeyPress of Function
    | Required of bool
    | Theme of InputTheme
    | Type of string
    | Value of obj
    interface IReactToolboxProp
let Input  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/input"
let inline input b c = rtEl Input b c


type LayoutTheme =
    | Layout of string

type LayoutProps =
    | Children of ReactElement // U3<NavDrawer, Panel, Sidebar>
    | Theme of LayoutTheme
    interface IReactToolboxProp
let Layout = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/layout"
let inline layout b c = rtEl Layout b c

type NavDrawerTheme =
    | Active of string
    | DrawerContent of string
    | LgPermangent of string
    | MdPermangent of string
    | NavDrawer of string
    | Pinned of string
    | Scrim of string
    | ScrollY of string
    | SmPermanent of string
    | Wide of string
    | XlPermanent of string
    | XxlPermangent of string
    | XxxlPermangent of string

type NavDrawerProps =
    | Active of bool
    | Children of React.ReactNode
    | OnOverlayClick of (React.MouseEvent -> unit)
    | PermanentAt of (* TODO StringEnum sm | md | lg | xl | xxl | xxxl *) string
    | Pinned of bool
    | ScrollY of bool
    | Theme of NavDrawerTheme
    | Width of (* TODO StringEnum normal | wide *) string
    interface IReactToolboxProp
let NavDrawer = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/layout"
let inline navDrawer b c = rtEl NavDrawer b c

type PanelTheme =
    | Panel of string
    | ScrollY of string

type PanelProps =
    | Children of React.ReactNode
    | ScrollY of bool
    | Theme of PanelTheme
    interface IReactToolboxProp
let Panel = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/layout"
let inline panel b c = rtEl Panel b c

type SidebarTheme =
    | Pinned of string
    | ScrollY of string
    | Sidebar of string
    | SidebarContent of string

type SidebarProps =
    | Children of React.ReactNode
    | Pinned of bool
    | ScrollY of bool
    | Theme of SidebarTheme
    | Width of float
    interface IReactToolboxProp
let Sidebar = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/layout"
let inline sidebar b c = rtEl Sidebar b c


type LinkTheme =
    | Active of string
    | Icon of string
    | Link of string

type LinkProps =
    | Active of bool
    | Children of React.ReactNode
    | Count of float
    | Href of string
    | Icon of U2<React.ReactNode, string>
    | Label of string
    | Theme of LinkTheme
    interface IReactToolboxProp
let Link  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/link"
let inline link b c = rtEl Link b c


type ListTheme =
    | List of string

type ListProps =
    | Children of React.ReactNode
    | Ripple of bool
    | Selectable of bool
    | Theme of ListTheme
    interface IReactToolboxProp
let List = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/list"
let inline list b c = rtEl List b c

type ListCheckboxTheme =
    | Checkbox of string
    | CheckboxItem of string
    | Disabled of string
    | Item of string
    | ItemContentRoot of string
    | ItemText of string
    | Large of string
    | Primary of string

type ListCheckboxProps =
    | Caption of string
    | Checked of bool
    | Disabled of bool
    | Legend of string
    | Name of string
    | OnBlur of Function
    | OnChange of Function
    | OnFocus of Function
    | Theme of ListCheckboxTheme
    interface IReactToolboxProp
let ListCheckbox = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/list"
let inline listCheckbox b c = rtEl ListCheckbox b c

type ListDividerTheme =
    | Divider of string
    | Inset of string
and ListDividerProps =
    | Inset of bool
    | Theme of ListDividerTheme
    interface IReactToolboxProp
let ListDivider = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/list"
let inline listDivider b c = rtEl ListDivider b c

type ListItemTheme =
    | Disabled of string
    | Item of string
    | ItemAction of string
    | ItemContentRoot of string
    | ItemText of string
    | Large of string
    | Left of string
    | ListItem of string
    | Primary of string
    | Right of string
    | Selectable of string

type ListItemProps =
    | Avatar of U2<React.ReactNode, string>
    | Caption of string
    | Children of React.ReactNode
    | Disabled of bool
    | ItemContent of React.ReactNode
    | LeftActions of ReactElement array
    | LeftIcon of U2<React.ReactNode, string>
    | Legend of string
    | RightActions of ReactElement array
    | RightIcon of U2<ReactElement, string>
    | Ripple of bool
    | Selectable of bool
    | Theme of ListItemTheme
    | To of string
    interface IReactToolboxProp
let ListItem = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/list"
let inline listItem b c = rtEl ListItem b c

type ListSubHeaderTheme =
    | Subheader of string

type ListSubHeaderProps =
    | Caption of string
    | Theme of ListSubHeaderTheme
    interface IReactToolboxProp
let ListSubHeader = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/list"
let inline listSubHeader b c = rtEl ListSubHeader b c


type MenuTheme =
    | Active of string
    | BottomLeft of string
    | BottomRight of string
    | Menu of string
    | MenuInner of string
    | Outline of string
    | Rippled of string
    | Static of string
    | TopLeft of string
    | TopRight of string

type MenuProps =
    | Active of bool
    | Children of React.ReactNode
    | OnHide of (unit -> unit)
    | OnSelect of (obj -> unit)
    | OnShow of (unit -> unit)
    | Outline of bool
    | Position of (* TODO StringEnum auto | static | topLeft | topRight | bottomLeft | bottomRight *) string
    | Ripple of bool
    | Selectable of bool
    | Selected of obj
    | Theme of MenuTheme
    interface IReactToolboxProp
let Menu = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/menu"
let inline menu b c = rtEl Menu b c

type IconMenuTheme =
    | Icon of string
    | IconMenu of string

type IconMenuProps =
    | Children of React.ReactNode
    | Icon of U2<React.ReactNode, string>
    | IconRipple of bool
    | MenuRipple of bool
    | OnHide of Function
    | OnSelect of Function
    | OnShow of Function
    | Position of (* TODO StringEnum auto | static | topLeft | topRight | bottomLeft | bottomRight *) string
    | Selectable of bool
    | Selected of obj
    | Theme of IconMenuTheme
    interface IReactToolboxProp
let IconMenu = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/menu"
let inline iconMenu b c = rtEl IconMenu b c

type MenuDividerTheme =
    | MenuDivider of string

type MenuDividerProps =
    | Theme of MenuDividerTheme
    interface IReactToolboxProp
let MenuDivider = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/menu"
let inline menuDivider b c = rtEl MenuDivider b c

type MenuItemTheme =
    | Caption of string
    | Disabled of string
    | Icon of string
    | MenuItem of string
    | Selected of string
    | Shortcut of string

type MenuItemProps =
    | Caption of string
    | Children of React.ReactNode
    | Disabled of bool
    | Icon of U2<React.ReactNode, string>
    | Selected of bool
    | Shortcut of string
    | Theme of MenuItemTheme
    | Value of obj
    interface IReactToolboxProp
let MenuItem = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/menu"
let inline menuItem b c = rtEl MenuItem b c


type NavigationTheme =
    | Button of string
    | Horizontal of string
    | Link of string
    | Vertical of string

type NavigationProps =
    | Actions of ResizeArray<obj>
    | Children of React.ReactNode
    | Routes of ResizeArray<obj>
    | Theme of NavigationTheme
    | Type of (* TODO StringEnum vertical | horizontal *) string
    interface IReactToolboxProp
let Navigation  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/navigation"
let inline navigation b c = rtEl Navigation b c


type ProgressBarTheme =
    | Buffer of string
    | Circle of string
    | Circular of string
    | Indeterminate of string
    | Linear of string
    | Multicolor of string
    | Path of string
    | Value of string

type ProgressBarProps =
    | Buffer of float
    | Max of float
    | Min of float
    | Mode of (* TODO StringEnum determinate | indeterminate *) string
    | Multicolor of bool
    | Theme of ProgressBarTheme
    | Type of (* TODO StringEnum linear | circular *) string
    | Value of float
    interface IReactToolboxProp
let ProgressBar  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/progress_bar"
let inline progressBar b c = rtEl ProgressBar b c


type RadioGroupProps =
    | Children of React.ReactNode
    | Disabled of bool
    | Name of string
    | OnChange of Function
    | Value of obj
    interface IReactToolboxProp
let RadioGroup  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/radio"
let inline radioGroup b c = rtEl RadioGroup b c

type RadioButtonTheme =
    | Radio of string
    | RadioChecked of string
    | Ripple of string
    | Disabled of string
    | Field of string
    | Input of string
    | Text of string

type RadioButtonProps =
    | Checked of bool
    | Disabled of bool
    | Label of U2<React.ReactNode, string>
    | Name of string
    | OnBlur of Function
    | OnChange of Function
    | OnFocus of Function
    | Theme of RadioButtonTheme
    | Value of obj
    interface IReactToolboxProp
let RadioButton  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/radio"
let inline radioButton b c = rtEl RadioButton b c


type RippleTheme =
    | Ripple of string
    | RippleActive of string
    | RippleRestarting of string
    | RippleWrapper of string

type RippleProps =
    | Children of React.ReactNode
    | Disabled of bool
    | OnRippleEnded of Function
    | Spread of float
    | Theme of RippleTheme
    interface IReactToolboxProp
let Ripple  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/ripple"
let inline ripple b c = rtEl Ripple b c


type SliderTheme =
    | Container of string
    | Editable of string
    | Innerknob of string
    | Innerprogress of string
    | Input of string
    | Knob of string
    | Pinned of string
    | Pressed of string
    | Progress of string
    | Ring of string
    | Slider of string
    | Snap of string
    | Snaps of string

type SliderProps =
    | Editable of bool
    | Max of float
    | Min of float
    | OnChange of Function
    | Pinned of bool
    | Snaps of bool
    | Step of float
    | Theme of SliderTheme
    | Value of float
    interface IReactToolboxProp
let Slider  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/slider"
let inline slider b c = rtEl Slider b c


type SnackbarTheme =
    | Accept of string
    | Active of string
    | Button of string
    | Cancel of string
    | Icon of string
    | Label of string
    | Snackbar of string
    | Warning of string

type SnackbarProps =
    | Action of string
    | Active of bool
    | Icon of U2<React.ReactNode, string>
    | Label of string
    | OnTimeout of (obj->unit)
    | OnClick of (obj->unit)
    | Theme of SnackbarTheme
    | Timeout of float
    | Type of (* TODO StringEnum accept | cancel | warning *) string
    interface IReactToolboxProp
let Snackbar  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/snackbar"
let inline snackbar b c = rtEl Snackbar b c


type SwitchTheme =
    | Disabled of string
    | Field of string
    | Input of string
    | Off of string
    | On of string
    | Ripple of string
    | Text of string
    | Thumb of string

type SwitchProps =
    | Checked of bool
    | Disabled of bool
    | Label of string
    | Name of string
    | OnBlur of Function
    | OnChange of (bool -> unit)
    | OnFocus of Function
    | Theme of SwitchTheme
    interface IReactToolboxProp
let Switch  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/switch"
let inline switch b c = rtEl Switch b c


type TableTheme =
    | Editable of string
    | Row of string
    | Selectable of string
    | Selected of string
    | Table of string

type TableProps =
    | Heading of bool
    | Model of obj
    | OnChange of (int -> int -> obj -> unit)
    | OnSelect of (obj -> unit)
    | Selectable of bool
    | MultiSelectable of bool
    | Selected of ResizeArray<obj>
    | Source of ResizeArray<obj>
    | Theme of TableTheme
    interface IReactToolboxProp
let Table  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/table"
let inline table b c = rtEl Table b c


type TabsTheme =
    | Active of string
    | Navigation of string
    | Pointer of string
    | Tabs of string
    | Tab of string

type TabsProps =
    | Children of React.ReactNode
    | DisableAnimatedBottomBorder of bool
    | Index of int
    | OnChange of (int -> unit)
    | Theme of TabsTheme
    interface IReactToolboxProp
let Tabs = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/tabs"
let inline tabs b c = rtEl Tabs b c

type TabTheme =
    | Active of string
    | Disabled of string
    | Hidden of string
    | Label of string

type TabProps =
    | Active of bool
    | ActiveClassName of string
    | Disabled of bool
    | Hidden of bool
    | Label of string
    | OnActive of Function
    | Theme of TabTheme
    interface IReactToolboxProp
let Tab = importMember<ComponentClass<IHTMLProp>> "react-toolbox/lib/tabs"
let inline tab b c = rtEl Tab b c


type TimePickerTheme =
    | Active of string
    | Am of string
    | AmFormat of string
    | Ampm of string
    | Button of string
    | Clock of string
    | ClockWrapper of string
    | Dialog of string
    | Face of string
    | Hand of string
    | Header of string
    | Hours of string
    | HoursDisplay of string
    | Input of string
    | Knob of string
    | Minutes of string
    | MinutesDisplay of string
    | Number of string
    | Placeholder of string
    | Pm of string
    | PmFormat of string
    | Separator of string
    | Small of string

type TimePickerProps =
    | Error of string
    | Icon of U2<React.ReactNode, string>
    | InputClassName of string
    | Format of (* TODO StringEnum 24hr | ampm *) string
    | Label of string
    | OnChange of Function
    | Theme of TimePickerTheme
    | Value of DateTime
    interface IReactToolboxProp
let TimePicker  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/time_picker"
let inline timePicker b c = rtEl TimePicker b c


type TooltipTheme =
    | Tooltip of string
    | TooltipActive of string
    | TooltipWrapper of string

type TooltipProps =
    | Theme of TooltipTheme
    | Tooltip of string
    | TooltipDelay of float
    | TooltipHideOnClick of bool
    interface IReactToolboxProp
let Tooltip  = importDefault<ComponentClass<IHTMLProp>> "react-toolbox/lib/tooltip"
let inline tooltip b c = rtEl Tooltip b c
