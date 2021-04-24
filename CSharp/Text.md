#<center> C#知识点汇总
#一 语法
##1.命名： 
	Fetch/Download比get好
	建议使用的单词： 
	send/deliver/dispatch/announce(宣布)/distribute(分配)/route(路由)
	find/search/extract(抽出)/locate/recover
	start/launch/create/begin/open
	make/create/setup/build/generate/compose
	add/new
	args/seq/arr/list/registers/text/item
	hasMore/hasNext
	使用具体的名字来描述：ServerCanStart()比CanListenOnPort好
	给变量带上重要细节：表示毫秒_ms，表示未处理raw_
	if(不断变化的值 < 固定值)
	ConditionalAttribute 代替#if #endif
##2.Limq本质：Lambda表达式和扩展方法。
			Lambda表达式本质：匿名方法。
			扩展方法：由参数调用方法，不用声明对象，因为类和方法都是静态的。
##3.集合类的选用：
	HashSet：不重复
	SortedSet:排序且不重复
	Queue:先入先出
	Stack：后入先出
	Hashtable:哈希表键值对，不支持泛型，多线程推荐使用
	LinkedList:频繁插入或删除，把XX元素移到第XX位时
	SortedList:排序；排好序的键值对，查找数据极快，但添加新元素，删除元素较慢	
	Dictionary:不排序；通过键来检索值的速度快，接近于 O(1)，支持泛型，单线程使用
	SortedDictionary:排序；查找，添加，删除速度都比较平均
##4.IOC：
	1.解耦 2.屏蔽细节。DI依赖注入，是实现IOC的手段。DI：构造对象，能自动把依赖的对象生成并传入，支持递归无限级的。 IOC是目标，DI是手段。
##5.默认字段：
	初始化优于赋值语句：值类型初始化为0，引用类型初始化为null
##6.非托管资源与非托管资源
	非托管资源：I/O流，数据库连接，Socket连接，窗口句柄 -- 人工控制
	托管资源：“对象在堆中的内存”
##7.泛型的类型参数约束
	- where T : struct 		| T必须是一个结构类型
	- where T : class  		| T必须是一个class类型
	- where T : new()  		| T必须有一个无参构造函数
  	- where T : BaseService 	| T 必须继承了BaseService
    - where T : IService		| T必须实现IService 
##8.为什么要自定义异常类
	a.没有具体系统异常相对应
	b.不希望再catch块中处理
	c.希望明确标识出错误种类的异常
##9.快捷产生字符
产生8个'#'
`new string('#', 8)`

产生1到10个数字
`new List<int>(Enumerable.Range(1, 10))`

#二 .net core
##.net core生命周期：
	AddTransient //瞬时生命周期
	AddSingleton //单例：全程唯一实例
	AddScoped	//作用域单例，一个请求一个实例
	没有线程单例，不建议太多单例，多个线程对单例操作，线程不安全。
	适合单例：配置文件、容器实例、连接池、线程池
	大部分是瞬时生命周期
##6.AOP异常：
	三种方法：1.直接用特性 2.用内置的ServiceFilter 3.全局注册AddControllersWithViews

####什么时候用Scope？
	请求单例：一次Http请求就是一个实例，一次请求创建一个容器实例



	