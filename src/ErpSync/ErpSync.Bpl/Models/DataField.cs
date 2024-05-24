using System.ComponentModel.DataAnnotations;

namespace ErpSync.Bpl.Models;

/// <summary>   A data field. </summary>
public class DataField
{
    /// <summary>   Constructor. </summary>
    /// <param name="name">         The name. </param>
    /// <param name="description">  The description. </param>
    /// <param name="type">         The type. </param>
    /// <param name="dataType">     The type of the data. </param>
    public DataField(string name, string description, Type type, DataType dataType)
    {
        Name = name;
        Description = description;
        Type = type;
        DataType = dataType;
    }

    /// <summary>   Constructor. </summary>
    /// <param name="name">         The name. </param>
    /// <param name="description">  The description. </param>
    /// <param name="type">         The type. </param>
    /// <param name="dataType">     The type of the data. </param>
    /// <param name="minimum">      The minimum value. </param>
    /// <param name="maximum">      The maximum value. </param>
    public DataField(string name, string description, Type type, DataType dataType, int minimum, int maximum)
        : this(name, description, type, dataType)
    {
        IsNumeric = true;
        Minimum = minimum;
        Maximum = maximum;
    }

    /// <summary>   Gets or initializes the name. </summary>
    /// <value> The name. </value>
    public string Name { get; init; }

    /// <summary>   Gets or initializes the description. </summary>
    /// <value> The description. </value>
    public string Description { get; init; }

    /// <summary>   Gets or initializes the type. </summary>
    /// <value> The type. </value>
    public Type Type { get; init; }

    /// <summary>   Gets or initializes the type of the data. </summary>
    /// <value> The type of the data. </value>
    public DataType DataType { get; init; }

    /// <summary>   Gets or initializes a value indicating whether this object is numeric. </summary>
    /// <value> True if this object is numeric, false if not. </value>
    public bool IsNumeric { get; init; }

    /// <summary>   Gets or initializes the minimum. </summary>
    /// <value> The minimum value. </value>
    public int? Minimum { get; init; }

    /// <summary>   Gets or initializes the maximum. </summary>
    /// <value> The maximum value. </value>
    public int? Maximum { get; init; }
}