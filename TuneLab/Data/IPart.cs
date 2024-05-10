﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneLab.Audio;
using TuneLab.Base.Data;
using TuneLab.Base.Structures;
using TuneLab.Extensions.Formats.DataInfo;

namespace TuneLab.Data;

internal interface IPart : IReadOnlyDataObject<PartInfo>, ITimeline, IDuration, IAudioSource, ISelectable, ILinkedNode<IPart>
{
    new IPart? Next { get; }
    new IPart? Last { get; }
    IDataProperty<string> Name { get; }
    IDataProperty<double> Pos { get; }
    IDataProperty<double> Dur { get; }
}

internal static class IPartExtension
{
    public static double StartPos(this IPart part)
    {
        return part.Pos.Value;
    }

    public static double EndPos(this IPart part)
    {
        return part.Pos.Value + part.Dur.Value;
    }
}