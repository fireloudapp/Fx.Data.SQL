﻿using RepoDb.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fx.Data.SQL.Helpers;


public class FilterParams
{
    public List<string> Fields { get; set; }
    public List<Sort> Sort { get; set; }
    public List<Filter> Filter { get; set; }
    public int Page { get; set; } = 0;
    public int RowsPerBatch { get; set; } = 10;
}

public class InputParams
{    public string Field { get; set; }
    public object _value = string.Empty;
    public object Value
    {
        get
        {
            //Currently supports primary items, we should extend this.
            var convertedValue = Conversions.GetType(_value.ToString());
            return convertedValue;
        }
        set
        {
            _value = value;
        }
    }
    public string Condition { get; set; }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<FilterParams>(myJsonResponse);
public class And : InputParams
{
    
}
public class Or : InputParams
{
}
public class Filter
{
    public List<And> And { get; set; }
    public List<Or> Or { get; set; }
}



public class Sort
{
    public string Field { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Order OrderBy { get; set; }
}





/*
 
{
    "Fields":["Id","Date","DateTime"],
    "Sort":[
        {
            "Field": "Date",
            "OrderBy":"Desc"

        },
        {
            "Field": "Date",
            "OrderBy":"Desc"
        }
    ],
    "Filter":[
        {
            "And":[
                {
                    "Field":"Date",
                    "Value":"2024-10-04",
                    "Condition":"eq"
                }
            ],
            "Or":[
                {
                    "Field":"Bit",
                    "Value":"false",
                    "Condition":"eq"
                }
            ]
        }
    ],
    "Page":"0",
    "RowsPerBatch":"5"
}
 */