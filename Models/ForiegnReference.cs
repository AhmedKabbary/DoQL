﻿namespace DoQL.Models
{
    public class ForiegnReference
    {
        public string TableId { get; set; }
        public Action OnUpdateAction { get; set; }
        public Action OnDeleteAction { get; set; }
    }

    public enum Action
    {
        NoAction,
        Restrict,
        Cascade,
        SetNull,
        SetDefault
    }
}