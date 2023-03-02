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
2023/2/22 WinUI3 C++/WinRT：
![2023/2/22](https://github.com/DenryDu/Disenchant-Music-Player/blob/WinUI3-CppWinRT/Assets/Images/Snipaste_2023-02-22_17-32-19.png)
