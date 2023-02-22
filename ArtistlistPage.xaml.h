// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#pragma once

#include "ArtistlistPage.g.h"

namespace winrt::DisenchantMusicPlayer::implementation
{
    struct ArtistlistPage : ArtistlistPageT<ArtistlistPage>
    {
        ArtistlistPage();

        int32_t MyProperty();
        void MyProperty(int32_t value);

    };
}

namespace winrt::DisenchantMusicPlayer::factory_implementation
{
    struct ArtistlistPage : ArtistlistPageT<ArtistlistPage, implementation::ArtistlistPage>
    {
    };
}
