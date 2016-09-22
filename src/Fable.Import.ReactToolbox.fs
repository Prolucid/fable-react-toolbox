namespace Fable.Import.ReactToolbox

open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.React

[<AutoOpen>]
module Props =

    type [<Erase>] Props =
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