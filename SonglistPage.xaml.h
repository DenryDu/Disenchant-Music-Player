// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#pragma once

#include "SonglistPage.g.h"

namespace winrt::DisenchantMusicPlayer::implementation
{
    struct SonglistPage : SonglistPageT<SonglistPage>
    {
        SonglistPage();

        int32_t MyProperty();
        void MyProperty(int32_t value);

    };
}

namespace winrt::DisenchantMusicPlayer::factory_implementation
{
    struct SonglistPage : SonglistPageT<SonglistPage, implementation::SonglistPage>
    {
    };
}
