ResolverClass resolves = new();
FileProcessor procs = new(resolves, args.ToBasicList());
await procs.ProcessAsync();