// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#pragma once

#include "StatisticPage.g.h"

namespace winrt::DisenchantMusicPlayer::implementation
{
    struct StatisticPage : StatisticPageT<StatisticPage>
    {
        StatisticPage();

        int32_t MyProperty();
        void MyProperty(int32_t value);

    };
}

namespace winrt::DisenchantMusicPlayer::factory_implementation
{
    struct StatisticPage : StatisticPageT<StatisticPage, implementation::StatisticPage>
    {
    };
}
