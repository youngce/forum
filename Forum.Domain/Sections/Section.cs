﻿using System;
using ENode.Domain;
using ENode.Eventing;
using Forum.Events.Section;

namespace Forum.Domain.Sections
{
    [Serializable]
    public class Section : AggregateRoot<Guid>,
        IEventHandler<SectionCreated>,
        IEventHandler<SectionNameChanged>
    {
        public string Name { get; private set; }

        public Section() { }
        public Section(string name) : base(Guid.NewGuid())
        {
            RaiseEvent(new SectionCreated(Id, name));
        }

        public void ChangeName(string name)
        {
            RaiseEvent(new SectionNameChanged(Id, name));
        }

        void IEventHandler<SectionCreated>.Handle(SectionCreated evnt)
        {
            Name = evnt.Name;
        }
        void IEventHandler<SectionNameChanged>.Handle(SectionNameChanged evnt)
        {
            Name = evnt.Name;
        }
    }
}
