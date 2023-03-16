# [WinUI3 CSharp] 离幻 UWP 音乐播放器
### Disenchant Music Player

##### 当前进度

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
	
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_23-30-13.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_23-28-34.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_23-28-46.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_23-29-09.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_23-29-46.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_23-30-57.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-15_23-31-12.png)
- 2023/3/16-19:18: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 实现自适应布局（小中大），同时设置了最小宽高来保证元素的完整性。
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-16_19-13-40.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-16_19-14-47.png)
	![](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-16_19-13-52.png)