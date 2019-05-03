using System;
using Domains;

using System.Collections.Generic;

namespace UiBuilder
{
    public class UiPage<T> where T : class
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public bool TableNumbering { get; set; } = true;
        public bool RowButtonsGroup { get; set; } = true;
        public List<string> Panels { get; set; } = new List<string>();
        public List<FormButton<T>> RowButtons { get; set; } = new List<FormButton<T>>();
        public Dictionary<string, UiParameter<T>> Parameters { get; set; } = new Dictionary<string, UiParameter<T>>();
        public UiPage(string name , string title , string url)
        {
            Name = name;Title = title; Url = url;
        }
        public UiPage()
        {
            Parameters = new Dictionary<string, UiParameter<T>>();
        }
        public UiPage(UiPage<T> MainPage)
        {
            Title = MainPage.Title;
            Name = MainPage.Name;
            Url = MainPage.Url;
            Panels = MainPage.Panels;
            Parameters = new Dictionary<string, UiParameter<T>>(MainPage.Parameters);
        }
        public UiPage<T> Remove(string name )
        {
            Parameters.Remove(name);
            return this;
        }

        public void Hidden(string Name, Func<T, object> Value)
        {
            var uip = new UiParameter<T>() { Name = Name, Value = Value, UiType = ParameterTypes.Hidden, FilterOk=false };
            Parameters.Push(Name,uip);
        }
        public void Field(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.Input };
            Parameters.Push(Name, uip);
        }
        public void FileInput(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 12, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.FileInput, FilterOk = false };
            Parameters.Push(Name, uip);
        }
        public void MultipleFile(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 12, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.MultipleFile, FilterOk = false };
            Parameters.Push(Name, uip);

        }
        public void RepeaterInput(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 12, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.RepeaterInput, FilterOk = false };
            Parameters.Push(Name, uip);
        }
        public void Password(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.Password, FilterOk = false };
            Parameters.Push(Name, uip);
        }
        public void Email(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.Email };
            Parameters.Push(Name, uip);
        }
        public void Number(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.Number };
            Parameters.Push(Name, uip);
        }
        public void Select(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, string ChainedTo = null, int width = 6,  Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.DropDownList, ChainedTo = ChainedTo };
            Parameters.Push(Name, uip);
        }
        public void MulipleSelect(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, string ChainedTo = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.MultipleSelect, ChainedTo = ChainedTo };
            Parameters.Push(Name, uip);
        }
        public void Date(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.Date };
            Parameters.Push(Name, uip);
        }
        public void HijriDate(string Name, string Label, Func<T, object> Value, bool Required = false, int? panelId = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.HijriDate };
            Parameters.Push(Name, uip);
        }
        public void LookupMulipleSelect(string Name, string Label, Func<T, object> Value, LookupType type, int? ParantLevel = null, bool Required = false, int? panelId = null, string ChainedTo = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, ParantLevel = ParantLevel, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.LookupMulipleSelect, LookupType = type, ChainedTo = ChainedTo };
            Parameters.Push(Name, uip);
        }
        public void LookupSelect(string Name, string Label, Func<T, object> Value, LookupType type, int? ParantLevel = null, bool Required = false, int? panelId = null, string ChainedTo = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, ParantLevel= ParantLevel, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.LookupSelect, LookupType = type, ChainedTo = ChainedTo };
            Parameters.Push(Name, uip);
        }
        public void LookupParantSelect(string Name, string Label, Func<T, object> Value, LookupType type, int? ParantLevel = null, bool Required = false, int? panelId = null, string ChainedTo = null, int width = 6, Func<T, bool> Condition = null)
        {
            var uip = new UiParameter<T>() { Name = Name, Label = Label, Value = Value, ParantLevel = ParantLevel, Required = Required, PanelId = panelId, Condition = Condition, Width = width, UiType = ParameterTypes.LookupParantSelect, LookupType = type, ChainedTo = ChainedTo };
            Parameters.Push(Name, uip);
        }
    }

}
