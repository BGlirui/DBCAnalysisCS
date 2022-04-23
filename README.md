## 第一章、系统概述

1.1 功能特点

该程序作为第三方类库项目，可以嵌入到使用者的程序内部，为使用者提供解析DBC文件以及根据DBC文件中的描述信息解析与封装Can通信报文的功能。该程序的功能主要分为三部分，首先该程序具有将DBC文件中的相关描述信息解析成可操作对象的功能，另外该程序具有管理DBC文件中有关信号数据的功能，最后该程序具有Can通信报文解析与封装的功能。

1.2 软件使用流程概述

该软件的使用流程如下所示。

步骤一：设置DBC文件路径。通过调用程序中DBCAnalysis.DbcFileAnalysis.SetDbcFile(

string dbcFilePath)方法即可完成设置DBC文件路径。需要注意该程序可以同时管理多个DBC文件，因此可以通过多次调用该方法来设置DBC文件路径。

步骤二：设置DBC关键字解析器。由于DBC文件中包含很多类型（关键字不同）的描述信息，但使用者可能不想解析所有的描述信息，因此，通过设置DBC关键字解析器即可灵活的解析出使用者所关注的描述信息，从而提升程序的执行效率。通过调用程序中DBCAnalysis.DbcFileAnalysis.SetAnalysisMachine(AnalysisMachine analysisMachine)方法即可设置使用者所关注的DBC关键字解析器。其中使用者可以通过DBCAnalysis.DbcAnalysis. KeyWordAnalysisMachine.QueryAnalysisMachineObject中的静态方法来获取AnalysisMachine类型的解析器对象。

步骤三：执行解析程序。通过调用DBCAnalysis.DbcFileAnalysis.Execute()方法即可开始执行DBC文件解析操作。

步骤四：获取结果集。完成DBC文件解析后，可以通过DBCAnalysis.Result.ResultObjectOpe类中的相关操作来获取结果集信息。在此步骤完成后，用户即可开始使用DBC文件中的描述信息。

步骤五：Can通信报文的解析与封装。通过调用DBCAnalysis.CommunicationHandle.

CommunicationDataManage类中的相关方法，将可以把Can通信报文解析为信号值并存储到信号值池中，另外该类中还包含Can通信数据打包操作以及信号值获取操作。

1.3 软件开发、编译环境

\1. 编程序言：C#编程序言。

\2. 项目类型：C#类库项目。

\3. 开发工具：Microsoft Visual Studio 2017

\4. 开发平台：.Net Framework 4.5

## 第二章、使用环境

由于该类库程序是依赖于.Net Framework 4.5平台开发，所以调用该程序包的主体程序应该也为.Net Framework 4.5项目。另外该程序只支持C#编程语言相关的程序项目。

## 第三章、使用说明

3.1 类库文件的引用

在Microsoft Visual Studio开发工具界面的右侧的解决方案资源管理器中选中要引用类库文件的项目名称，如图1所示。

![img](file:///C:\Users\THLR\AppData\Local\Temp\ksohtml13076\wps1.jpg) 

图1 解决方案资源管理器

选中要引用类库文件的项目后，通过点击Microsoft Visual Studio开发工具的菜单栏中的项目->添加引用按钮后将会弹出如图2所示界面。

![img](file:///C:\Users\THLR\AppData\Local\Temp\ksohtml13076\wps2.jpg) 

图2 引用管理器

点击图2引用管理器界面中的浏览按钮后将会弹出文件选择界面，在文件选择界面中选中要引用的“.dl”l后缀的文件即可完成引用操作。

 

3.2 DBC文件路径的设定

通过DBCAnalysis.DbcFileAnalysis.SetDbcFile(string dbcFilePath)方法即可设置DBC文件路径。该程序可以同时管理多个DBC文件，通过多次调用路径设置方法即可完成多个DBC文件路径的设定，使程序可以同时管理多个路径。

3.3 DBC关键字解析器设置

DBC文件中存在多种类型的描述信息，不同类型的描述信息主要由各自的关键字来进行标识。因此，通过关键字信息即可灵活管理不同类型的描述信息。在该程序中，对不同类型的描述信息都各自存在一个描述信息解析器，由于描述信息解析器主要通过DBC关键字类进行区分，所以称描述信息解析器为DBC关键字解析器。

DBC文件中存在多种类型的描述信息，但是使用者在使用时大多都只关注DBC文件中的某一部分描述信息，因此在使用时通过预设置DBC关键字解析器的方法可以使程序在运行使只解析使用者所关注的描述信息，从而提升程序的执行效率。

通过DBCAnalysis.DbcFileAnalysis.SetAnalysisMachine(AnalysisMachine analysisMachine)方法即可设置DBC关键字解析器，多次调用该方法将可以设置多个DBC关键字解析器。另外，调用该方法时需要传入AnalysisMachine类型的DBC关键字解析器参数，该类型的对象可从DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.QueryAnalysisMachineObject类中的静态方法获取。该类中静态方法的名称将直接表明了DBC关键字解析器的名称。

该程序设置了默认的DBC关键字解析器设置，默认的DBC关键字解析器主要是围绕Can通信数据信息描述而设定的，其解析器内容如下：

\1. QueryAnalysisMachineObject.GetNodeAnalysisMachine()：节点描述信息解析器。

\2. QueryAnalysisMachineObject.GetMessageAnalysisMachine()：消息描述信息解析器。

\3. QueryAnalysisMachineObject.GetMessageTransmitterAnalysisMachine()：消息传输方向信息解析器。

\4. QueryAnalysisMachineObject.GetSignalAnalysisMachine()：信号信息解析器。

\5. QueryAnalysisMachineObject.GetSignalExtendedValueTypeListAnalysisMachine()：信号扩展值类型列表信息解析器。

\6. QueryAnalysisMachineObject.GetValueDescriptionsForSignalAanlysisMachine()：信号值描述信号信息解析器。

\7. QueryAnalysisMachineObject.GetCommentAnalysisMachine()：注释信息解析器。

\8. QueryAnalysisMachineObject.GetAttributeDefaultAnalysisMachine()：属性默认值信息解析器。

\9. QueryAnalysisMachineObject.GetAttributeDefinitionAnalysisMachine()：属性定义信息解析器。

\10. QueryAnalysisMachineObject.GetAttributeValueForObjectAnalysisMachine()：对象值属性信息解析器。

3.4 DBC文件解析执行

在完成DBC文件路径设置以及DBC关键字解析器设置后，通过调用DBCAnalysis.DbcFileAnalysis.Execute()方法即可开始执行DBC文件解析程序。完成文件解析后即可通过结果集来操作解析结果。

3.5 结果集操作

在该程序中可以通过DBCAnalysis.Result.ResultObjectOpe类中的方法来操作结果集。在该类中提供了以下方法：

\1. 获取全部结果集方法。

\2. 根据路径获取单个DBC文件的结果集方法。

\3. 根据单个DBC文件结果集对象以及DBC关键字解析器类名称来获取所有对应的DBC关键字信息对象。

在对结果集进行操作的过程中主要涉及了如下几种类对象：

\1. DBCAnalysis.Models.Result.ResultObject：该类中存储了单个DBC文件中的所有已解析出的描述信息对象。

\2. DBCAnalysis.Models.DbcContent.BaseKeyModelOpe：该类作为描述信息的父类，其存储了DBC文件中单条描述信息中已被解析出的内容对象。该类中将描述信息以键值对的形式存储，其中键为描述信息标识，值为实际描述信息列表。

\3. DBCAnalysis.Models.DbcContent.BaseKeyModelOpe的子类：DBC文件中存在多种类型的描述信息，每一种类型的描述信息都对应着一个子类。在该子类中存在着所有描述信息标识的静态属性，在使用过程中可以通过访问静态属性的方法来获取描述信息标识。

DBCAnalysis.Models.DbcContent.BaseKeyModelOpe类中存在描述信息键值对，使用者在使用时可通过键信息来获取具体的DBC描述信息。在该键值对中实际的DBC描述信息是以列表的形式存在，其原因在于部分DBC描述信息是以多个并列关系存在的，所以在存储时将以列表的形式存在。

3.6 Can通信数据的解析与封装

对于Can通信数据的解析与封装功能而言，需要信号值的管理功能、Can通信报文解析为信号值功能（拆包）、信号值封装为Can通信报文功能（打包）。在该程序中提供了一种非常便捷的方法来实现Can通信报文的打包与拆包操作，信号数据值的获取与设定操作，具体操作方法如下所示。

DBCAnalysis.CommunicationHandle.CommunicationDataManage类中存在操作Can通信数据的功能，具体功能与方法如下所示：

\1. bool SetSignalValue(string signalName, UInt64 signalValue)：使用该方法可以通过信号名以及Uint64类型的信号值来设置信号值。

\2. UInt64 GetSignalValueBySignalName(string signalName)：使用该方法可以通过信号名称来获取最新的Uint64类型的信号值。

\3. byte[] GetMessageData(uint messageId)：使用该方法可以通过Can通信ID来获取通信报文数据。其中通信的数据都是从信号池中获取的最新信号值，数据打包操作都是依照与DBC文件描述信息完成的。

\4. bool AnalysisMessage(uint messageId, byte[] data)：使用该方法可以通过Can通信ID以及通信报文数据参数来向信号池中设置最新信号值数据。

## 第四章、关键函数说明

4.1 DBC文件解析相关函数

DBCAnalysis.DbcFileAnalysis类，该类主要包括了DBC文件解析操作相关的功能函数。

\1. bool SetDbcFile(string dbcFilePath)：设置DBC文件路径。完成文件路径设置后，程序内部将会开始管理该DBC文件。

\2. bool SetAnalysisMachine(AnalysisMachine analysisMachine)：设置DBC关键字解析器。只有设置了DBC关键字解析器的DBC关键字信息才会被解析，否则将无法解析DBC信息。

\3. bool Execute()：调用该方法后将会开始执行DBC文件解析操作。

4.2 结果集操作相关函数

DBCAnalysis.Result.ResultObjectOpe类，在DBC文件解析完成后，可通过该类中的方法函数来访问所有解析出的DBC描述信息对象。

\1. string GetDbcPathByMessageId(uint messageId)：通过Can通信的消息ID来获取DBC路径信息。

\2. Dictionary<string,ResultObject> GetAllResultObject()：获取所有DBC文件的结果集。返回的结果集以键值对的形式存在，其中键为DBC文件路径，值为单个DBC文件的结果集对象。

\3. ResultObject GetResultObjectByFilePath(string path)：通过DBC文件路径来获取单个DBC文件的结果集对象。

\4. List<BaseKeyModelOpe> GetBaseKeyModelOpesByClassFullName(ResultObject 

resultObject, string classFullName)：通过单个DBC文件结果集对象以及DBC关键字解析器类全名来获取所有该DBC关键字所对应的描述信息列表。

4.3 Can通信数据操作相关函数

DBCAnalysis.CommunicationHandle.CommunicationDataManage类，该类主要包括了Can通信数据的打包与拆包操作以及信号值的设定与读取操作。

\1. UInt64 GetSignalValueBySignalName(string signalName)：通过信号名来从信号池中获取信号值。

\2. bool SetSignalValue(string signalName, UInt64 signalValue)：向信号池中设置信号值。

\3. byte[] GetMessageData(uint messageId)：从信号池中获取数据来打包成Can通信数据。

\4. bool AnalysisMessage(uint messageId, byte[] data)：通过Can通信ID以及Can通信数据来更新信号池中的数据信息。