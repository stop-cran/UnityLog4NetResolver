# Synopsis

An extension for Unity container that resolves all `log4net.ILog` dependencies basing on a type name of an object being created.

# Use case

A conventional way to create log4net loggers:

```
class ClassA
{
   private static readonly ILog logger = LogManager.GetLogger(typeof(ClassA));
}
```

An alternative way, using this package:

```
class ClassA
{
    private readonly ILog logger;

    public ClassA(ILog logger)
    {
        this.logger = logger;
    }
}

void Main()
{
    var container = new UnityContainer();
    container.AddNewExtension<LogByTypeResolverExtension>();
    
    var a = container.Resolve<ClassA>();
}
```

# Remarks

Following the second way, one can avoid copy-pasting of logger initialization code, which is prone to mistakes in the logger name, if one forgets to amend it after copying.
Also constructor-injected `ILog` may be more convenient for mocking and unit-testing than test log appenders, e.g. [`MemoryAppender`](https://logging.apache.org/log4net/release/sdk/html/T_log4net_Appender_MemoryAppender.htm).
