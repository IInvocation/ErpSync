namespace ErpSync.Bpl.Models;

public class DataSet
{
    /// <summary>   Constructor. </summary>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when one or more required arguments are
    ///     null.
    /// </exception>
    /// <param name="name">         The name. </param>
    /// <param name="description">  The description. </param>
    public DataSet(string name, string description)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
        Name = name;
        Description = description;
        Fields = new List<DataField?>();
        Children = new List<DataSet>();
    }

    /// <summary>   Constructor. </summary>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when one or more required arguments are
    ///     null.
    /// </exception>
    /// <param name="name">         The name. </param>
    /// <param name="description">  The description. </param>
    /// <param name="parent">       The parent. </param>
    public DataSet(string name, string description, DataSet parent) : this(name, description)
    {
        Parent = parent ?? throw new ArgumentNullException(nameof(parent));
    }

    /// <summary>   Gets or sets the name. </summary>
    /// <value> The name. </value>
    public string Name { get; set; }

    /// <summary>   Gets or sets the description. </summary>
    /// <value> The description. </value>
    public string Description { get; set; }

    /// <summary>   Gets or sets the parent. </summary>
    /// <value> The parent. </value>
    public DataSet? Parent { get; set; }

    /// <summary>   Gets a value indicating whether this object has parent. </summary>
    /// <value> True if this object has parent, false if not. </value>
    public bool HasParent => Parent != null;

    /// <summary>   Gets or sets the children. </summary>
    /// <value> The children. </value>
    public List<DataSet> Children { get; set; }

    /// <summary>   Gets a value indicating whether this object has children. </summary>
    /// <value> True if this object has children, false if not. </value>
    public bool HasChildren => Children.Any();

    /// <summary>   Gets or sets the fields. </summary>
    /// <value> The fields. </value>
    public List<DataField?> Fields { get; set; }
}