using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace BossChecklist
{
	// normal access rules apply - type and methods have to be public
	public class BossChecklistAPI : IBossChecklistAPI
	{
		private BossTracker bossTracker;

		internal BossChecklistAPI(BossTracker bossTracker) {
			this.bossTracker = bossTracker;
		}

		public void AddBoss(Mod source, string name, List<int> id, float val, Func<bool> down, Func<bool> available, List<int> collect, List<int> spawn, string info, Func<NPC, string> despawn = null, Action<SpriteBatch, Rectangle, Color> drawing = null)
			=> bossTracker.AddBoss(source, name, id, val, down, available, collect, spawn, info, despawn, drawing);

		public void AddBoss(IBossChecklistAPI.IBossDefinition definition)
			=> bossTracker.AddBoss(
				definition.Source,
				definition.Name,
				definition.IDs,
				definition.Progress,
				() => definition.IsDowned,
				() => definition.IsAvailable,
				definition.Collection,
				definition.SpawnItems,
				definition.SpawnInfo,
				definition.UsesCustomDespawnMessage ? (npc) => definition.GetDespawnMessage(npc) : null,
				definition.DoesCustomDrawing ? (sb, r, c) => definition.Draw(sb, r, c) : null
			);
	}
}