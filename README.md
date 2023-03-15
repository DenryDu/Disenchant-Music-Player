# 离幻 UWP 音乐播放器
### Disenchant Music Player

###### 结项日期：待定
###### 进度计划：随缘

> 知幻即离，离幻即觉

> 音声既可入幻，亦可出幻

市面上虽然各式各样的音乐播放器金玉在前，但在windows平板本地播放的需求方面仍存在缺口：
- 微软自家出品的windows媒体播放器（Media Player，旧称Groove）交互适配了触摸屏，但播放列表无法显示歌曲封面缩略图、无法正确识别音乐文件内嵌歌词。
- 大受好评的偏专业播放器诸如 foobar 2000、AIMP 虽然支持多种解码格式，支持频谱、频响可视化，但由于其设置项过于繁杂、UI老旧，尽管有第三方主题解决了UI老旧的部分问题，但同时这些主题大多数对于触摸屏适配又较差，不支持列表滑动等操作，交互逻辑反人类，不易用。另：foobar的专辑分类归总也比较弱智（智能性较弱），比不上安卓端的椒盐音乐。
- 椒盐音乐在UI、交互、功能性上都表现优秀，但很可惜，这是一款安卓软件
- Musbox Player的UI比较合格，支持触屏操作，但很可惜，音乐列表一塌糊涂，且不支持显示歌词。
- LyricEase UI、交互等方面均符合要求，但可惜这是一个第三方网易云客户端，且开发者尚未回复是否有本地播放器版本的开发计划

综上，天行健，君子以自强不息，不如自己上手试试，正好可以丰富生活，避免精神失常。


本项目旨在开发一款符合UWP~~WinUI3~~（在了解完WinUI3的得失利弊和现状之后，还是准备用WinUI2的UWP进行开发，并且在进行过实际使用之后，考虑到微软砍刀部对c++/winnrt的不怎么上心以及文档和讨论的稀缺以及层出不穷的bug，还是决定后撤二十里，使用c#进行学习和开发，WinUI3 c++/winrt版本的代码将封存在[WinUI3-CppWinRT分支](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CppWinRT)）规范、采用现代化UI、简洁易用的本地音乐播放器，应当满足如下基本要求：
1. 功能：能够对本地文件夹进行科学扫描、分类和文件提取
2. 交互：能够在如下方面良好支持触屏操作
    - 列表滑动
    - 音量调节
    - 界面切换
    - 进度调节
3. 界面：
    - UI自适应横竖屏及各种大小屏幕
    - 控件大小采用偏大式样方便手指操控
    
##### 现有功能介绍
- 播放页：
	
	支持单曲循环、随机(Shuffle, not Random)播放、列表循环，支持音量调节，支持进度条拖拽，支持歌词滚动特效，支持上一首、下一首
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-08-31.png)
- 歌曲列表
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-14_21-44-57.png)
- 专辑列表
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-06-43.png)
- 专辑详情
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-07-09.png)
- 艺术家列表
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-07-27.png)
- 艺术家详情
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-07-55.png)




- 指定音乐文件夹
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-14_21-45-23.png)


##### 当前进度

- 2023/2/22：[WinUI3 C++/WinRT](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CppWinRT)
	![2023/2/22](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-02-22_17-32-19.png)

- 2023/3/6：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 学习了MVVM开发模式，在此基础上构建了音乐信息相关类，完成基本信息（路径名、专辑名、歌名、艺术家）的读取整合操作，鉴于该操作基本上属于数据获取范畴，并不涉及直接为页面准备数据，所以目前放在Model层。同时，由于该软件不需要大规模频繁的插入删除修改和复杂查询，初步决定不采用数据库进行开发。
- 2023/3/7：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 完成了一些音乐信息（封面，采样率，比特率，歌词，时长）的提取工作，同时解决文件访问受限情况下使用taglib读取音乐文件的问题。初步解决音乐文件夹导入问题。
- 2023/3/8-19:36：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 完成了音乐库文件夹指定与取消的逻辑，以及指定文件夹后导入数据的逻辑，同时将之前使用项目中的UI进行了简单的迁移，主要完成了SongListPage和SettingsPage的View层UI设计和ViewModel层数据绑定。下一步希望分析运行时内存占用过大的原因并解决，同时解决类间权限受限情况下的参数传递。
	![2023/3/8-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-35-02.png)
	![2023/3/8-2](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-35-54.png)
	![2023/3/8-3](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-36-11.png)
	![2023/3/8-4](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-36-39.png)
- 2023/3/8-22:00：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 解决了函数调用问题，找到了从一窗体中调用另一窗体受保护函数的方法。
	![2023/3/8-5](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_22-00-51.png)
- 2023/3/9-12:40：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 初步解决了内存占用过大问题，下一步希望完成音乐播放功能。
	![2023/3/9-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-09_12-39-26.png)
- 2023/3/9-21:54：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 使用WASAPI初步解决了播放问题，但是无法获取播放进度，下一步可能会尝试NAudio来进行播放（尝试了，但是没有安装完成，遇到了很多问题）。同时，为播放组件添加了一些元素，重新设计布局以适应屏幕的伸缩。
	![2023/3/9-2](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-09_21-54-25.png)
- 2023/3/12-21:16: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 由于uwp应用安装naudio问题颇多，所以将项目整体迁移到[WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp)了，今天完成了播放组件的动态数据绑定，优化了项目文件结构，优化标题栏，优化进度条。下一步编写歌曲展开页。
	![2023/3/12-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-12_21-15-09.png)
- 2023/3/13-11:46: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 完成音量控制
	![2023/3/12-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-13_11-43-31.png)	
- 2023/3/13-21:00: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 使用NAudio编写Audio Player类，实现了包括进度条更新、音量更新、暂停、播放、上一曲、下一曲、Shuffle播放、列表循环播放、单曲循环播放等功能，但存在严重缺陷，就是由于NAudio中的AudioFileReader缓冲区大小的问题，导致部分音乐在拖拽进度条时发生进度无法顺利更新的问题，如
	- 在播放歌曲 梦里花 时，将进度条拉到第4秒处，但声音仍然从第0秒处开始
	- 在播放大部分歌曲时，将进度条拉满，但从AudioFileReader中拿到的CurrentTime竟然比TotalTime还要大，而且仍然有音乐从大概90%进度开始播放。
	上述问题在使用NAudio官网上的WpfDemo时也有发生，同时我也进行了细致的Debug，确信不是我编程中可能出现的参数精度、线程同步所导致的，所以使用NAudio完成音乐播放的全程控制，是具有天生缺陷的，遂放弃。
- 2023/3/14-10:50: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 使用MediaPlayer编写MAudioPlayer类，重新实现了进度条更新、音量更新、暂停、播放、上一曲、下一曲、Shuffle播放、列表循环播放、单曲循环播放等功能，无昨天那些缺陷，窗口最小化后仍然能够播放，目前很满意。由于不需要使用NAudio，甚至有考虑将目前进度重新移植回UWP。
	![2023/3/14-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-14_10-45-30.png)	
- 2023/3/14-21:12: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 编写了歌曲详情（展开）页，处理了一些页面跳转逻辑和动效，手动实现了歌词滚动特效，对今天的工作非常满意。实现了我所需要的最基础的功能，接下来的更新可能会放缓。
	![2023/3/14-2](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-14_21-12-21.png)	
- 2023/3/15-21:15: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 
	
	更新播放详情页，增加一个小按钮方便下滑：
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-08-31.png)
	
	新增专辑列表页、新增专辑详情页，并做了左滑右滑的页面导航效果，以及两个页面间相同元素的连贯动画：
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-06-43.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-07-09.png)	
	
	新增艺术家列表页、新增艺术家详情页，并做了左滑右滑的页面导航效果，以及两个页面间相同元素的连贯动画：
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-07-27.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-07-55.png)
- 2023/3/15-23:34: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 小小修改了艺术家详情页，使得歌曲封面能够展现。同时，引进Acrylic样式（可以在设置中选择关闭或开启）
	
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-07-27.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_21-07-55.png)

