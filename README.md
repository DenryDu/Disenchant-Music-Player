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


##### 当前进度

- 2023/2/22：[WinUI3 C++/WinRT]
	![2023/2/22](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-02-22_17-32-19.png)

- 2023/3/6：[WinUI2 C#] 学习了MVVM开发模式，在此基础上构建了音乐信息相关类，完成基本信息（路径名、专辑名、歌名、艺术家）的读取整合操作，鉴于该操作基本上属于数据获取范畴，并不涉及直接为页面准备数据，所以目前放在Model层。同时，由于该软件不需要大规模频繁的插入删除修改和复杂查询，初步决定不采用数据库进行开发。
- 2023/3/7：[WinUI2 C#] 完成了一些音乐信息（封面，采样率，比特率，歌词，时长）的提取工作，同时解决文件访问受限情况下使用taglib读取音乐文件的问题。初步解决音乐文件夹导入问题。
- 2023/3/8：[WinUI2 C#] 完成了音乐库文件夹指定与取消的逻辑，以及指定文件夹后导入数据的逻辑，同时将之前使用项目中的UI进行了简单的迁移，主要完成了SongListPage和SettingsPage的View层UI设计和ViewModel层数据绑定。下一步希望分析运行时内存占用过大的原因并解决，同时解决类间权限受限情况下的参数传递。
	![2023/3/8-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-35-02.png)
	![2023/3/8-2](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-35-54.png)
	![2023/3/8-3](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-36-11.png)
	![2023/3/8-4](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-36-39.png)




