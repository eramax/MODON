using Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using Queries;

namespace UiBuilder
{
    public class ViewBuilder<T> where T : class
    {
        private readonly UiView _uv = new UiView();
        private readonly UiPage<T> _model;
        private readonly IMDResponse _res;
        private List<T> _data;
        private T _single;
        public ViewBuilder(UiPage<T> page, IMDResponse response = null)
        {
            this._model = page;
            this._res = response;
        }

        public  UiView List(List<T> data = null)
        {
            this._data = data;
            _uv.Html = $@"<div class=""card border-success"">
                         <div class=""card-header bg-success"">
                           <div class=""row"">
                            <div class=""col-md-6"">{_model?.Title}</div>
                            <div class=""ml-auto"">
                              <button onclick=""location.href='/{_model?.Url}/Set'"" class=""btn waves-effect waves-light btn-light"" 
                                type=""button"">أضافة {_model?.Name}  جديدة  <i class=""fa fa-plus""></i></button>
                                 &nbsp;<button onclick=""LoadModal('/{_model?.Url}/Filter');""class=""btn waves-effect waves-light btn-light"">بحث
                                <i class=""fa fa-search""></i></button>
                            </div>
                          </div>
                        </div>";
            Alert();
            Table();
            _uv.Html += "</div>";
            return _uv;
        }
        public UiView Details(T single = null)
        {
            this._single = single;
            _uv.Html = $@"<div class=""card border-success"">
                         <div class=""card-header bg-success"">
                          <div class=""row"">
                            <div class=""col-md-6"">{_model?.Name}</div>
                            <div class=""ml-auto"">
                            <button onclick=""location.href='/{_model?.Url}/'"" class=""btn waves-effect waves-light btn-light"" 
                                type=""button""> {_model?.Title} <i class=""fa fa-list""></i></button>
                            </div>
                        </div>
                        </div>";
            Alert();
            var panelstyle = "";
            if (_model != null)
            {
                var uiParameters = _model.Parameters.Select(x => x.Value)
                    .Where(x => x.PanelId == null && x.UiType != ParameterTypes.Hidden && (x.Condition == null || x.Condition(_single))).ToList();
                GetPanel(null,ref uiParameters,  ref panelstyle,  true);
                for (var id = 0; _model.Panels.Count > id; id++)
                {
                    uiParameters = _model.Parameters.Select(x => x.Value)
                        .Where(x => x.PanelId == id && x.UiType != ParameterTypes.Hidden && (x.Condition == null || x.Condition(_single))).ToList();
                    GetPanel(id, ref uiParameters, ref panelstyle, true);
                }
            }
            _uv.Html += "</div>";
            return _uv;
        }
        public UiView Filter(T single = null) 
        {
            _uv.Html = $@"<form action=""/{_model?.Url}/"" method=""POST"" class=""col-md-12"" data-parsley-validate=""true"">
                <div class=""modal-header"">
                <h5 class=""modal-title"" id=""ModalIdLabel"" style=""float: right;font-size:large;"">البحث فى {_model?.Title}</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""أغلاق"" style=""float: left;"">
                <span aria-hidden=""true"">&times;</span></button></div>
                <div class=""modal-body row"">";

            if (_model != null)
                foreach (var prop in _model.Parameters.Select(x => x.Value).Where(x => x.FilterOk == true))
                {
                    var val = (_single != null) ? prop.Value(_single) : null;
                    PropEdit(prop, ref val, true);
                }

            _uv.Html += $@" </div> <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">الغاء</button>
                <button type=""submit"" class=""btn btn-primary"">بحث</button></div></form>";

            return _uv;
        }
        public UiView Form(T single = null)
        {
            this._single = single;
            var actionUrl = _model.Action ?? $"{_model.Url}/Save";
            const string multipart = (false) ? @"enctype = ""multipart/form-data""" : "";
            _uv.Html = $@"<div class=""card border-success"">
                         <div class=""card-header bg-success"">
                          <div class=""row"">
                            <div class=""col-md-6"">{_model?.Name}</div>
                            <div class=""ml-auto"">
                            <button onclick=""location.href='/{_model?.Url}/'"" class=""btn waves-effect waves-light btn-light"" 
                                type=""button""> {_model?.Title} <i class=""fa fa-list""></i></button>
                            </div>
                        </div>
                        </div>";

            _uv.Html += $@" <div class=""card-body row"">
                        <form action=""/{actionUrl}"" method=""post"" class=""col-md-12"" {multipart}>
                        <div class=""form-body""><div class=""card-body row p-t-20"">";
            Alert();
            var panelstyle = "";
            var uiParameters = _model.Parameters.Select(x => x.Value)
                .Where(x => x.PanelId == null && ( x.Condition == null || x.Condition(_single)) ).ToList();
            GetPanel(null ,ref uiParameters, ref panelstyle);
            for (var id = 0; _model.Panels.Count > id; id++)
            {
                uiParameters = _model.Parameters.Select(x => x.Value)
                    .Where(x => x.PanelId == id && (x.Condition == null || x.Condition(_single))).ToList();
                GetPanel( id, ref uiParameters, ref panelstyle);
            }
            _uv.Html += @"</div><div class=""form-actions"">
                         <div class=""card-body"">
                            <button type=""submit"" class=""btn btn-success""> <i class=""fa fa-check""></i> حفظ</button>
                            <button type=""button"" class=""btn btn-dark"" onclick=""window.history.back();"">الغاء</button>
                          </div></div></div></form></div></div>";
            return _uv;
        }
        public void GetPanel(int? panelId, ref List<UiParameter<T>> uiParameters,  ref string panelstyle , bool details = false )
        {
            if (uiParameters.Count == 0) return;
            panelstyle = (panelstyle == "bg-light") ? "bg-light2" : "bg-light";

            var panelIDint = panelId.GetValueOrDefault();
            var panelName = (panelId == null) ? "البيانات الرئيسية" : _model.Panels.ElementAtOrDefault(panelIDint);
            _uv.Html += $@"<div class=""card-body col-md-12 {panelstyle}""><h4 class=""card-title m-t-10 font-weight-bold"">{panelName}</h4><hr><div class=""row"">";
            foreach (var prop in uiParameters)
            {
                var val = prop.Value(_single);
                if (prop.Condition != null && !prop.Condition(_single)) continue;
                if (details)
                    PropShow(prop, ref val);
                else PropEdit(prop, ref val);
            }
            _uv.Html += "</div></div>";
        }
        public void PropEdit(UiParameter<T> prop, ref object val , bool IsFilter = false) 
        {
            var required = (prop.Required && !IsFilter) ? "required" : "";
            var requiredStar = (required == "required") ? @"&nbsp;<span class=""text-danger"">*</span>" : "";
            var disabled = (prop.UiType == "readOnly") ? @"disabled = ""true""" : "";
            var isMuliple = (prop.UiType == "MultipleSelect" || prop.UiType == "MultipleFile" || prop.UiType == "LookupMulipleSelect");
            var multiple = (isMuliple) ? @"multiple=""multiple""" : "";
            var type = prop.UiType;
            var label = prop.Label;
            var width = (IsFilter) ? 3 : prop.Width;
            var name = prop.Name;
            switch (type)
            {
                case "readOnly":
                case "number":
                case "email":
                case "password":
                    _uv.Html += $@"<div class=""form-group col-md-{width}"">
                                <label class=""col-form-label"">{label}{requiredStar}</label>
                                <input type=""{type}"" class=""form-control"" {disabled}  {required} 
                                name=""{name}"" value=""{val}"" maxlength=""100""/></div>"; break;

                case "file":
                case "MultipleFile":
                    var maxfiles = (isMuliple) ? 5 : 1;
                    _uv.Html += $@"<div class=""form-group col-md-{width}"">
                                <label class=""col-form-label"">{label}{requiredStar}</label>
                                <input hidden value=""{val}"" name=""{name}"" id=""{name}"" {required}/>
                                    <div class=""UppyInput-{name}""></div><div class=""UppyInput-Progress-{name}""></div></div>";
                    _uv.Scripts += $@"UppySetup(""{name}"", {maxfiles});";
                    break;

                case "Hidden": _uv.Html += $@"<input hidden value=""{val}"" name=""{name}""/>"; break;
                case "Button":
                case "Submit":
                    _uv.Html += $@"<div class=""form-group col-md-{width}"">
                               <button type=""{type}"" class=""btn btn-default"" 
                                onclick=""location.href='{val}';"" />{label}</div>"; break;

                case "DropDownList":
                case "MultipleSelect":
                case "LookupSelect":
                case "LookupMulipleSelect":
                case "LookupParantSelect":
                    _uv.Html += $@"<div class=""form-group col-md-{width} sel2"">
                                <label class=""col-form-label"">{label}{requiredStar}</label>
                                <select name=""{name}"" {required} {multiple} class=""select2 form-control custom-select"" 
                                id=""{name}"" style=""height: 36px;width: 100%;"">";
                    GetSelectOptions(prop, ref val, IsFilter, isMuliple); break;

                case "Date":
                case "HijriDate":
                    var hijriMode = (prop.UiType == "HijriDate") ? "true" : "false";
                    var datestring = GetPropValue(prop, val);
                    _uv.Html += $@"<div class=""form-group col-md-{prop.Width}"">
                                <label class=""col-form-label"">{prop.Label}{requiredStar}</label>
                                <input type=""hidden"" value=""{val}"" name=""{name}"" id=""{name}"" {required}/>
                                <input type=""text"" onclick=""pickDate(event,'{name}',{hijriMode})"" class=""w3-input form-control"" 
                                name=""{name}-display"" id=""{name}-display"" 
                                value=""{datestring}"" maxlength=""100""/></div>"; break;

                case "CommentBox":
                    break;

                case "RepeaterInput":
                    _uv.Html += $@"<div class=""input-repeater form-group col-md-12""><div data-repeater-list=""{name}"">
                                 <div data-repeater-item class=""row m-b-15"">   <div class=""form-group col-md-6"">
                                 <input type=""text"" required="""" class=""form-control"" name=""Value"" value="""" maxlength=""150"">       
                                 </div> <div class=""col-md-2"">          
                                 <button data-repeater-delete="""" class=""btn btn-danger waves-effect waves-light"" type=""button"">               
                                 <i class=""ti-close""></i>   </button>  </div>   </div>   </div>
                                 <button type=""button"" data-repeater-create="""" class=""btn btn-info waves-effect waves-light""> أضف المزيد </button>  </div>"; break;

                default:
                    _uv.Html += $@"<div class=""form-group col-md-{width}"">
                                <label class=""col-form-label"">{label}{requiredStar}</label>
                                <input type=""text"" {required} class=""form-control"" name=""{name}"" 
                                value=""{val}"" maxlength =""150""/></div>"; break;
            }
        }
        public void PropShow(UiParameter<T> prop, ref object val) 
        {
            _uv.Html += $@"<div class=""col-md-6"">
                             <div class=""form-group row"">
                                <label class=""control-label text-right col-md-5"">{prop.Label}</label>
                                    <div class=""col-md-7"">
                                       <p class=""form-control-static""> {GetPropValue(prop, val)} </p>
                                     </div>
                             </div>
                         </div>";
        }
        public string GetPropValue(UiParameter<T> prop, object val) 
        {
            if (val == null) return null;
            switch (prop.UiType)
            {
                case "HijriDate":
                    return Convert.ToDateTime(val).ToDateHijriFullDetails();
                case "Date":
                    return Convert.ToDateTime(val).ToDateFullDetails();
                case "file":
                case "MultipleFile":
                    return "TBD";
                case "DropDownList":
                case "LookupSelect":
                case "MultipleSelect":
                case "LookupMulipleSelect":
                case "LookupParantSelect":
                    return LookupService.Names(prop.LookupType, val, prop.ParantLevel, prop.UiType == "LookupParantSelect");
                default: return val.ToString(); 
            }
        }
        public void GetSelectOptions<T>(UiParameter<T> prop, ref object val, bool IsFilter = false, bool multiple = false) where T : class
        {
            if (prop.LookupType == null) return;
            if (!prop.Required || IsFilter == true) _uv.Html += @"<option value=""""></option>";
            foreach (var it in LookupService.PopList(prop.LookupType, val, prop.ParantLevel, prop.UiType == "LookupParantSelect"))
            {
                var selected = (it.Selected.HasValue && it.Selected.Value) ? "selected" : "";
                _uv.Html += $@"<option value=""{it.Id}"" class=""{it.ParantID}"" {selected}>{it.Name}</option>";
            }
            if (!string.IsNullOrEmpty(prop.ChainedTo))
                _uv.Scripts += $@"$(""#{prop.Name}"").chained(""#{prop.ChainedTo}"");";
            _uv.Html += "</select></div>";
        }
        public void Table()
        {
            _uv.Html += $@" <div class=""table-responsive"">
                    <table id=""zero_config"" class=""table table-striped table-bordered display"">
                         <thead><tr>";

            if (_model.TableNumbering) _uv.Html += $@"<th>#</th>";
            var parlist = _model.Parameters.Select(x=> x.Value).Where(x => x.UiType != ParameterTypes.Hidden).ToList();
            foreach (var thread in parlist.Data())
                _uv.Html += $@"<th>{thread.Label}</th>";
            _uv.Html += $@"<th>الاجراءات</th></tr></thead><tbody>";
            var i = 1;
            foreach (var item in _data)
            {
                _uv.Html += "<tr>";
                if (_model.TableNumbering) _uv.Html += $"<td> {i++} </td>";
                foreach (var prop in parlist)
                {
                    var val = (item != null) ? prop.Value(item) : null;
                    _uv.Html += $"<td> {GetPropValue(prop, val)} </td>";
                }
                _uv.Html += "<td>";
                GetButtons(item);
                _uv.Html += "</td></tr>";
            }
            _uv.Html += "</tbody></table></div>";
        }
        public void GetButtons(T item)
        {
            if (_model.RowButtons == null) return;
            var buttonClass = "btn btn-success btn-sm ml-1";
            var buttonGrpTail = "";
            if (_model.RowButtonsGroup)
            {
                _uv.Html += $@"<div class=""btn-group"">
                <button type=""button"" class=""btn  btn-success dropdown-toggle"" 
                    data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                    <i class=""far fa-sun""></i>
                </button>
                <div class=""dropdown-menu"">";
                buttonClass = "dropdown-item";
                buttonGrpTail = "</div></div>";
            }
            foreach (var btn in _model.RowButtons.Data())
            {
                if (btn.Condition == null || btn.Condition(item))
                    _uv.Html += $@"<a href=""{btn.Url(item)}"" class=""{buttonClass}"">{btn.Name}</a>";
            }
            _uv.Html += buttonGrpTail;
        }

        public void Alert()
        {
            if (_res.IsNull()) return;
            if (_res.HasErrors)
            {
                _uv.Html +=
                    $@"<div class=""container-fluid alert alert-danger""><button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                     <span aria-hidden=""true"">×</span> </button>
                    <h4 class=""text-danger""><i class=""fa fa-window-close""></i> رسالة خطأ</h4> <li>";
                foreach (var x in _res.Errors) _uv.Html += $"<i> {x} </i>";
                _uv.Html += "</li></div>";
            }

            foreach (var x in _res.Alerts.Data())
            {
                _uv.Html +=
                    $@"<div class=""container-fluid alert alert-{x.Style}""> <i class=""ti-user""></i> {x.Message}
                             <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close""> <span aria-hidden=""true"">×</span> </button></div>";
                _uv.Html += "</li></div>";
            }
        }
    }
}
