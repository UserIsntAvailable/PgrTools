# PgrTools
Tools for Punishing: Gray Raven.

## Tools
* **ConfigReader**: Reads a pgr xml config file.
* **ConfigParser**: Parses values of a particular config key.

#### Parsable Config Keys
* **PlayerKeyMapping**
* **CustomUI**

## Usage
You can found every tool method on ```PgrTools``` class.

```c#
using System.Collections.Generic;
using PgrTools;

IDictionnary<string, string> dict = PgrTools.ReadXmlConfig("Pgr-Config-File-Path.xml"); 
```

You could also instantiate the classes tools if you would want to modify their default dependencies. You can found every class tool on the ```PgrTools.Tools``` namespace.

```c#
using System.Collections.Generic;
using PgrTools.Tools;

ConfigReader configReader = new(HexToString);
IDictionnary<string, string> dict = configReader.ReadXmlConfig("Pgr-Config-File-Path.xml");

private string HexToString(string value)
{
    // logic here...
}
```
