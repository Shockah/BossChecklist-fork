﻿using System;

namespace BossChecklist
{
	internal enum EntryType
	{
		Boss,
		MiniBoss,
		Event
	}

	internal enum OrphanType
	{
		Loot,
		Collection,
		SpawnItem,
		EventNPC
	}

	internal enum CollectionType
	{
		Generic,
		Trophy,
		Mask,
		MusicBox,
		Relic,
		Pet,
		Mount
	}

	internal enum CategoryPage
	{
		Record,
		Spawn,
		Loot
	}

	enum PacketMessageType : byte
	{
		RequestHideBoss,
		RequestClearHidden,
		SendRecordsToServer,
		RecordUpdate,
		WorldRecordUpdate
	}

	[Flags]
	internal enum RecordID : int
	{
		None = 0,
		Duration = 1,
		HitsTaken = 2,
		ResetAll = 4
	}

	internal enum RecordType : int
	{
		PreviousAttempt,
		FirstRecord,
		BestRecord,
		WorldRecord,
		None
	}
}
